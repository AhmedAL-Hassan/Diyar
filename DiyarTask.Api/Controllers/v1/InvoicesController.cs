namespace DiyarTask.Api.Controllers.v1;

using DiyarTask.Application.Commands.Invoices.CreateInvoiceCommand;
using DiyarTask.Application.Commands.Invoices.DeleteInvoiceCommand;
using DiyarTask.Application.Commands.Invoices.UpdateInvoiceCommand;
using DiyarTask.Application.Queries.GetFilteredInvoicesQuery;
using DiyarTask.Contracts.Invoices;
using DiyarTask.Shared.Models.Response.Invoice;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/v{v:apiVersion}/Invoices")]
[Asp.Versioning.ApiVersion("1.0")]
public sealed class InvoicesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public InvoicesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Invoice record.
    /// </summary>
    [HttpPost(Name = "AddInvoice")]
    public async Task<ActionResult<InvoiceDto>> AddInvoice([FromBody] InvoiceForCreationDto InvoiceForCreationDto)
    {
        var command = _mapper.Map<CreateInvoiceCommand>(InvoiceForCreationDto);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }

    /// <summary>
    /// Gets a single Invoice by ID.
    /// </summary>
    [HttpGet("{InvoiceId:guid}", Name = "GetInvoice")]
    public async Task<ActionResult<InvoiceDto>> GetInvoice(Guid InvoiceId)
    {
        return Ok(new InvoiceDto());
    }

    /// <summary>
    /// Gets a list of all Invoices.
    /// </summary>
    [HttpGet(Name = "GetInvoices")]
    public async Task<ActionResult<List<InvoiceDto>>> GetInvoices([FromQuery] InvoiceParametersDto InvoiceParametersDto)
    {
        var query = _mapper.Map<GetFilteredInvoicesQuery>(InvoiceParametersDto);
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    /// <summary>
    /// Updates an existing Invoice.
    /// </summary>
    [HttpPut("{InvoiceId:guid}", Name = "UpdateInvoice")]
    public async Task<ActionResult<InvoiceDto>> UpdateInvoice(Guid InvoiceId, [FromBody] InvoiceForUpdateDto InvoiceForUpdateDto)
    {
        var command = _mapper.Map<UpdateInvoiceCommand>(InvoiceForUpdateDto);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }


    [HttpDelete("{InvoiceId:guid}", Name = "DeleteInvoice")]
    public async Task<IActionResult> DeleteInvoice(Guid InvoiceId)
    {
        var command = new DeleteInvoiceAccountCommand(InvoiceId);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }
}