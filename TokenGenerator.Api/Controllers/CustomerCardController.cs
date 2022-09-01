namespace TokenGenerator.Api.Controllers
{
    using Domain.Commands;
    using Microsoft.AspNetCore.Mvc;
    using TokenGenerator.Domain.Handlers;

    [ApiController]
    [Route("v1/customercard")]
    public class CustomerCardController : ControllerBase
    {
        /// <summary>
        /// Receive customer card and save it on database
        /// </summary>
        [Route("save")]
        [HttpPost]
        public GenericCommandResult Save([FromBody]CreateCustomerCardCommand command, [FromServices]CreateCustomerCardHandler handler) =>
            (GenericCommandResult)handler.Handle(command);

        /// <summary>
        /// Validate the token provided in the request
        /// </summary>
        [Route("validate")]
        [HttpPost]
        public GenericCommandResult Validate([FromBody]ValidateCustomerCardCommand command, [FromServices]ValidateCustomerCardHandler handler) =>
            (GenericCommandResult)handler.Handle(command);
    }
}