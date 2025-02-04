namespace DiyarTask.Api.Controllers.v1;

using ReminderTaskManagement.Domain.Notifications.Features;
using ReminderTaskManagement.Domain.Notifications.Dtos;
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
[Route("api/v{v:apiVersion}/notifications")]
[ApiVersion("1.0")]
public sealed class NotificationsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Gets a list of all Notifications.
    /// </summary>
    [HttpGet(Name = "GetNotifications")]
    public async Task<IActionResult> GetNotifications([FromQuery] NotificationParametersDto notificationParametersDto)
    {
        var query = new GetNotificationList.Query(notificationParametersDto);
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
}
