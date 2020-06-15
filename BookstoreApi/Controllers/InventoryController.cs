using BookstoreApi.Commands;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.Controllers
{
    public class InventoryController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public InventoryController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        [Route("inventories")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpsertInventory([FromBody] UpsertInventoryRequest request, CancellationToken cancellationToken)
        {
            var command = new UpsertInventoryCommand(request.LegacyId, request.LegacyBookId, request.StockLevelUsed, request.StockLevelNew);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.InventoryId);

            return StatusCode(500);
        }
    }
}
