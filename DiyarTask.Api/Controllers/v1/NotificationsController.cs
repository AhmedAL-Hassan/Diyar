//namespace DiyarTask.Api.Controllers.v1;

//using ReminderTaskManagement.Domain.Notifications.Features;
//using ReminderTaskManagement.Domain.Notifications.Dtos;
//using ReminderTaskManagement.Resources;
//using System.Text.Json;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System.Threading.Tasks;
//using System.Threading;
//using Asp.Versioning;
//using MediatR;
//using DiyarTask.Application.Queries.Notificationss.GetFilteredNotificationssQuery;
//using DiyarTask.Contracts.Notificationss;
//using DiyarTask.Shared.Models.Response.Notifications;

//[ApiController]
//[Route("api/v{v:apiVersion}/notifications")]
//[ApiVersion("1.0")]
//public sealed class NotificationsController(IMediator mediator): ControllerBase
//{

//    /// <summary>
//    /// Gets a list of all Notificationss.
//    /// </summary>
//    [HttpGet(Name = "GetNotificationss")]
//    public async Task<ActionResult<List<NotificationsDto>>> GetNotificationss([FromQuery] NotificationsParametersDto NotificationsParametersDto)
//    {
//        var query = _mapper.Map<GetFilteredNotificationssQuery>(NotificationsParametersDto);
//        var response = await _mediator.Send(query);

//        return Ok(response);
//    }
//}
