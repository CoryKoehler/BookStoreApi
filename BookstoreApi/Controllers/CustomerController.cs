using BookstoreApi.Commands;
using EventFlow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public CustomerController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        [Route("customers")]
        [ProducesResponseType(200, Type = typeof(Guid))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpsertCustomer([FromBody] UpsertCustomerRequest request, CancellationToken cancellationToken)
        {
            var command = new UpsertCustomerCommand(request.LegacyId, request.Name, request.Address,
                request.PostalCode, request.State, request.Country, request.PhoneNumber);

            var result = await _commandBus.PublishAsync(command, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.CustomerId);

            return StatusCode(500);
        }
    }
}
