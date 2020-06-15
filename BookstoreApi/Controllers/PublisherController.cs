using BookstoreApi.Commands;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.Controllers
{
    public class PublisherController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public PublisherController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        [Route("publishers")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpsertPublisher([FromBody] UpsertPublisherRequest request, CancellationToken cancellationToken)
        {
            var command = new UpsertPublisherCommand(request.LegacyId, request.Name, request.Country);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.PublisherId);

            return StatusCode(500);
        }
    }
}
