using Microsoft.AspNetCore.Mvc;

using MediatR;

namespace SignalGrapher.API.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly ISender Sender;

        protected ApiController(ISender sender) => Sender = sender;
    }
}
