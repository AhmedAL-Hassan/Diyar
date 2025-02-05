namespace DiyarTask.Api.Controllers.v1;
using DiyarTask.Contracts.Notifications;
using DiyarTask.Shared.Models.Response.Notification;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/v{v:apiVersion}/notifications")]
[Asp.Versioning.ApiVersion("1.0")]
public sealed class NotificationsController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public NotificationsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Gets a list of all Notificationss.
    /// </summary>
    [HttpGet(Name = "GetNotificationss")]
    public async Task<ActionResult<List<NotificationDto>>> GetNotificationss([FromQuery] NotificationsParametersDto NotificationsParametersDto)
    {
        var query = _mapper.Map<GetFilteredNotificationssQuery>(NotificationsParametersDto);
        var response = await _mediator.Send(query);

        return Ok(response);
    }
}
