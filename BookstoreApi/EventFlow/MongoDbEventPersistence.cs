using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates;
using EventFlow.Core;
using EventFlow.EventStores;
using EventFlow.Exceptions;
using EventFlow.Logs;
using EventFlow.MongoDB.ValueObjects;
using MongoDB.Driver;

namespace BookstoreApi.EventFlow
{
    public class MongoDbEventPersistence : IEventPersistence
    {
        public static readonly string CollectionName = "eventflow.events";
        private readonly ILog _log;
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbEventPersistence(ILog log, IMongoDatabase mongoDatabase)
        {
            _log = log;
            _mongoDatabase = mongoDatabase;
        }

        public async Task<AllCommittedEventsPage> LoadAllCommittedEvents(GlobalPosition globalPosition, int pageSize, CancellationToken cancellationToken)
        {
            var startPosition = globalPosition.IsStart ? 0 : long.Parse(globalPosition.Value, CultureInfo.InvariantCulture);

            var eventDataModels = await (await MongoDbEventStoreCollection
                .FindAsync(model => model._id >= startPosition,
                    new FindOptions<MongoDbEventDataModel, MongoDbEventDataModel> { Limit = pageSize }, cancellationToken)
                    .ConfigureAwait(false))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            var nextPosition = eventDataModels.Any()
                ? eventDataModels.Max(e => e._id) + 1
                : startPosition;

            return new AllCommittedEventsPage(new GlobalPosition(nextPosition.ToString(CultureInfo.InvariantCulture)), eventDataModels);
        }

        public async Task<IReadOnlyCollection<ICommittedDomainEvent>> CommitEventsAsync(IIdentity id, IReadOnlyCollection<SerializedEvent> serializedEvents, CancellationToken cancellationToken)
        {
            if (!serializedEvents.Any())
            {
                return Array.Empty<ICommittedDomainEvent>();
            }

            var eventDataModels = serializedEvents
                .Select((e, i) => new MongoDbEventDataModel
                {
                    _id = DateTime.UtcNow.Ticks,
                    AggregateId = id.Value,
                    AggregateName = e.Metadata[MetadataKeys.AggregateName],
                    BatchId = Guid.Parse(e.Metadata[MetadataKeys.BatchId]),
                    Data = e.SerializedData,
                    Metadata = e.SerializedMetadata,
                    AggregateSequenceNumber = e.AggregateSequenceNumber
                })
                .OrderBy(x => x.AggregateSequenceNumber)
                .ToList();

            _log.Verbose("Committing {0} events to MongoDb event store for entity with ID '{1}'", eventDataModels.Count, id);
            try
            {
                await MongoDbEventStoreCollection
                    .InsertManyAsync(eventDataModels, cancellationToken: cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (MongoBulkWriteException e)
            {
                throw new OptimisticConcurrencyException(e.Message, e);

            }
            return eventDataModels;
        }

        public async Task<IReadOnlyCollection<ICommittedDomainEvent>> LoadCommittedEventsAsync(IIdentity id, int fromEventSequenceNumber, CancellationToken cancellationToken)
        {
            return await (await MongoDbEventStoreCollection
                .FindAsync(model => model.AggregateId == id.Value && model.AggregateSequenceNumber >= fromEventSequenceNumber, cancellationToken: cancellationToken)
                .ConfigureAwait(false))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task DeleteEventsAsync(IIdentity id, CancellationToken cancellationToken)
        {
            DeleteResult affectedRows = await MongoDbEventStoreCollection
                .DeleteManyAsync(x => x.AggregateId == id.Value, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            _log.Verbose("Deleted entity with ID '{0}' by deleting all of its {1} events", id, affectedRows.DeletedCount);
        }

        private IMongoCollection<MongoDbEventDataModel> MongoDbEventStoreCollection => _mongoDatabase.GetCollection<MongoDbEventDataModel>(CollectionName);
    }
}
