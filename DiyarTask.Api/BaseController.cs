namespace DiyarTask.Api;

using MapsterMapper;
using MediatR;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Asp.Versioning.ApiVersion("1.0")]
[Route("api/v{v:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
    protected BaseController(IMediator mediator, IMapper mapper)
    {
        Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected IMediator Mediator { get; }

    protected IMapper Mapper { get; }
}