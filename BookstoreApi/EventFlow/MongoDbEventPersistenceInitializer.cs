using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventFlow.MongoDB.ValueObjects;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookstoreApi.EventFlow
{
    public interface IMongoDbEventPersistenceInitializer
    {
        Task Initialize(bool? useLocalDeployment);
    }

    public class MongoDbEventPersistenceInitializer : IMongoDbEventPersistenceInitializer
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbEventPersistenceInitializer(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task Initialize(bool? useLocalDeployment)
        {
            if (useLocalDeployment is null || useLocalDeployment == false)
            {
                await Task.WhenAll(new List<Task>
                {
                    ShardCollectionAsHashed("eventflow.events", "AggregateId"),
                    ShardCollectionAsHashed("snapShots", "AggregateId"),

                }).ConfigureAwait(false);
            }

            var events = _mongoDatabase.GetCollection<MongoDbEventDataModel>(global::EventFlow.MongoDB.EventStore.MongoDbEventPersistence.CollectionName);
            IndexKeysDefinition<MongoDbEventDataModel> keys =
                Builders<MongoDbEventDataModel>.IndexKeys.Ascending("AggregateId")
                    .Ascending("AggregateSequenceNumber");
            events.Indexes.CreateOne(
                new CreateIndexModel<MongoDbEventDataModel>(keys, new CreateIndexOptions { Unique = true }));
        }

        private async Task ShardCollectionAsHashed(string collectionName, string shardKey)
        {
            try
            {
                if (CollectionExists(collectionName))
                    return;
                var shellCommand = new BsonDocumentCommand<BsonDocument>(new BsonDocument
                {
                    { "shardCollection", $"Events.{collectionName}" },
                    { "key",  new BsonDocument{{ shardKey, "hashed" }}}

                });

                await _mongoDatabase.RunCommandAsync(shellCommand).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("Sharding is not supported for existing collections.", StringComparison.InvariantCultureIgnoreCase))
                    return;
                throw;
            }
        }

        public bool CollectionExists(string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var options = new ListCollectionNamesOptions { Filter = filter };

            return _mongoDatabase.ListCollectionNames(options).Any();
        }
    }
}
