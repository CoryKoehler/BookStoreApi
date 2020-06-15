using BookstoreApi.Commands;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.Controllers
{
    public class AuthorController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public AuthorController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        [Route("authors")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpsertAuthor([FromBody] UpsertAuthorRequest request, CancellationToken cancellationToken)
        {
            var command = new UpsertAuthorCommand(request.LegacyId, request.Name, request.Country);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.AuthorId);

            return StatusCode(500);
        }
    }
}
