using BookstoreApi.Commands;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public BookController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        [Route("books")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpsertBook([FromBody] UpsertBookRequest request, CancellationToken cancellationToken)
        {
            var command = new UpsertBookCommand(request.LegacyId, request.Price, request.Edition, request.LegacyAuthorId, request.LegacyPublisherId);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.BookId);

            return StatusCode(500);
        }
    }
}
