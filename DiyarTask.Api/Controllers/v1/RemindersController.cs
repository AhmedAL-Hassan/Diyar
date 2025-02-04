namespace DiyarTask.Api.Controllers.v1;

using ReminderTaskManagement.Domain.Reminders.Features;
using ReminderTaskManagement.Domain.Reminders.Dtos;
using ReminderTaskManagement.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/reminders")]
[ApiVersion("1.0")]
public sealed class RemindersController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Reminder record.
    /// </summary>
    [HttpPost(Name = "AddReminder")]
    public async Task<ActionResult<ReminderDto>> AddReminder([FromBody]ReminderForCreationDto reminderForCreation)
    {
        var command = new AddReminder.Command(reminderForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetReminder",
            new { reminderId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Reminder by ID.
    /// </summary>
    [HttpGet("{reminderId:guid}", Name = "GetReminder")]
    public async Task<ActionResult<ReminderDto>> GetReminder(Guid reminderId)
    {
        var query = new GetReminder.Query(reminderId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Reminders.
    /// </summary>
    [HttpGet(Name = "GetReminders")]
    public async Task<IActionResult> GetReminders([FromQuery] ReminderParametersDto reminderParametersDto)
    {
        var query = new GetReminderList.Query(reminderParametersDto);
        var queryResponse = await mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Append("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Updates an entire existing Reminder.
    /// </summary>
    [HttpPut("{reminderId:guid}", Name = "UpdateReminder")]
    public async Task<IActionResult> UpdateReminder(Guid reminderId, ReminderForUpdateDto reminder)
    {
        var command = new UpdateReminder.Command(reminderId, reminder);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Reminder record.
    /// </summary>
    [HttpDelete("{reminderId:guid}", Name = "DeleteReminder")]
    public async Task<ActionResult> DeleteReminder(Guid reminderId)
    {
        var command = new DeleteReminder.Command(reminderId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
