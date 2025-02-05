namespace DiyarTask.Api.Controllers.v1;

using DiyarTask.Api;
using DiyarTask.Application.Commands.Customers.CreateCustomerCommand;
using DiyarTask.Application.Commands.Customers.DeleteCustomerCommand;
using DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;
using DiyarTask.Application.Queries.Customers.GetCustomerQuery;
using DiyarTask.Application.Queries.Customers.GetFilteredCustomersQuery;
using DiyarTask.Contracts.Customers.Request;
using DiyarTask.Shared.Models.Response.Customer;

public sealed class CustomersController : BaseController
{
    public CustomersController(IMediator mediator, IMapper mapper)
        : base(mediator, mapper)
    {
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerResponse>> GetCustomerByIdAsync(Guid id)
    {
        var getCustomerQuery = new GetCustomerQuery(id);

        var response = await Mediator.Send(getCustomerQuery);

        return Ok(response);
    }

    [HttpPost("create")]
    public async Task<ActionResult<CustomerResponse>> CreateCustomerAsync(CreateCustomerRequest createCustomerRequest)
    {
        var createCustomerCommand = Mapper.Map<CreateCustomerCommand>(createCustomerRequest);

        var commandResponse = await Mediator.Send(createCustomerCommand);

        return Ok(commandResponse);
    }

    [HttpPut("update")]
    public async Task<ActionResult<CustomerResponse>> UpdateCustomerAsync(UpdateCustomerRequest updateCustomerRequest)
    {
        var updateCustomerCommand = Mapper.Map<UpdateCustomerCommand>(updateCustomerRequest);

        var commandResponse = await Mediator.Send(updateCustomerCommand);

        return Ok(commandResponse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var deleteCustomerCommand = new DeleteCustomerCommand(id);

        var commandResponse = await Mediator.Send(deleteCustomerCommand);

        return Ok(commandResponse);
    }

    [HttpPost("search")]
    public async Task<ActionResult<List<CustomerResponse>>> GetCustomers([FromQuery] SearchCustomerRequest searchCustomerRequest)
    {
        var query = Mapper.Map<GetFilteredCustomersQuery>(searchCustomerRequest);

        var response = await Mediator.Send(query);

        return Ok(response);
    }
}