namespace DiyarTask.Api.Controllers.v1;

using DiyarTask.Application.Commands.Reminders.CreateReminderCommand;
using DiyarTask.Application.Commands.Reminders.UpdateReminderCommand;
using DiyarTask.Application.Queries.Reminders.GetFilteredRemindersQuery;
using DiyarTask.Application.Queries.Reminders.GetReminderQuery;
using DiyarTask.Application.Reminders.Commands;
using DiyarTask.Contracts.Reminders;
using DiyarTask.Shared.Models.Response.Reminder;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/v{v:apiVersion}/Reminders")]
[Asp.Versioning.ApiVersion("1.0")]
public sealed class RemindersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public RemindersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Reminder record.
    /// </summary>
    [HttpPost(Name = "AddReminder")]
    public async Task<ActionResult<ReminderDto>> AddReminder([FromBody] ReminderForCreationDto ReminderForCreationDto)
    {
        var command = _mapper.Map<CreateReminderCommand>(ReminderForCreationDto);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }

    /// <summary>
    /// Gets a single Reminder by ID.
    /// </summary>
    [HttpGet("{ReminderId:guid}", Name = "GetReminder")]
    public async Task<ActionResult<ReminderDto>> GetReminder(Guid ReminderId)
    {
        var query = new GetReminderQuery(ReminderId);
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    /// <summary>
    /// Gets a list of all Reminders.
    /// </summary>
    [HttpGet(Name = "GetReminders")]
    public async Task<ActionResult<List<ReminderDto>>> GetReminders([FromQuery] ReminderParametersDto ReminderParametersDto)
    {
        var query = _mapper.Map<GetFilteredRemindersQuery>(ReminderParametersDto);
        var response = await _mediator.Send(query);

        return Ok(response);
    }

    /// <summary>
    /// Updates an existing Reminder.
    /// </summary>
    [HttpPut("{ReminderId:guid}", Name = "UpdateReminder")]
    public async Task<ActionResult<ReminderDto>> UpdateReminder(Guid ReminderId, [FromBody] ReminderForUpdateDto ReminderForUpdateDto)
    {
        var command = _mapper.Map<UpdateReminderCommand>(ReminderForUpdateDto);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }


    [HttpDelete("{ReminderId:guid}", Name = "DeleteReminder")]
    public async Task<IActionResult> DeleteReminder(Guid ReminderId)
    {
        var command = new DeleteReminderCommand(ReminderId);
        var commandResponse = await _mediator.Send(command);

        return Ok(commandResponse);
    }
}