namespace DiyarTask.Api.Controllers.v1;

using DiyarTask.Application.Commands.Customers.CreateCustomerCommand;
using DiyarTask.Application.Commands.Customers.DeleteCustomerCommand;
using DiyarTask.Application.Commands.Customers.UpdateCustomerCommand;
using DiyarTask.Application.Queries.Customers.GetCustomerQuery;
using DiyarTask.Application.Queries.Customers.GetFilteredCustomersQuery;
using DiyarTask.Contracts.Customers;
using DiyarTask.Shared.Models.Response.Customer;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/v{v:apiVersion}/customers")]
[Asp.Versioning.ApiVersion("1.0")]
public sealed class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Customer record.
    /// </summary>
    [HttpPost(Name = "AddCustomer")]
    public async Task<ActionResult<CustomerDto>> AddCustomer([FromBody] CustomerForCreationDto customerForCreationDto)
    {
        var command = _mapper.Map<CreateCustomerCommand>(customerForCreationDto);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }

    /// <summary>
    /// Gets a single Customer by ID.
    /// </summary>
    [HttpGet("{customerId:guid}", Name = "GetCustomer")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(Guid customerId)
    {
        var query = new GetCustomerQuery(customerId);
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    /// <summary>
    /// Gets a list of all Customers.
    /// </summary>
    [HttpGet(Name = "GetCustomers")]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomers([FromQuery] CustomerParametersDto customerParametersDto)
    { 
        var query = _mapper.Map<GetFilteredCustomersQuery>(customerParametersDto);
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    /// <summary>
    /// Updates an existing Customer.
    /// </summary>
    [HttpPut("{customerId:guid}", Name = "UpdateCustomer")]
    public async Task<ActionResult<CustomerDto>> UpdateCustomer(Guid customerId, [FromBody] CustomerForUpdateDto customerForUpdateDto)
    {
        var command = _mapper.Map<UpdateCustomerCommand>(customerForUpdateDto);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }

    
    [HttpDelete("{customerId:guid}", Name = "DeleteCustomer")]
    public async Task<IActionResult> DeleteCustomer(Guid customerId)
    {
        var command = new DeleteCustomerCommand(customerId);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }
}
