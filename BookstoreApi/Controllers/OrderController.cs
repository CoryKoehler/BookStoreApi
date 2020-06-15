using BookstoreApi.Commands;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public OrderController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        [Route("orders")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpsertOrder([FromBody] UpsertOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new UpsertOrderCommand(request.LegacyId, request.LegacyCustomerId, request.OrderDate, request.OrderTotal, request.OrderedItems);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.OrderId);

            return StatusCode(500);
        }
    }
}
