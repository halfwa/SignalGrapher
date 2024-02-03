using Microsoft.AspNetCore.Mvc;

using MediatR;
using SignalGrapher.Application.SinusoidalSignals.Create;
using SignalGrapher.API.Contracts;
using SignalGrapher.Application.SinusoidalSignals.GetById;

namespace SignalGrapher.API.Controllers
{

    [Route("api/signals")]
    public sealed class SignalsController : ApiController
    {
        public SignalsController(ISender sender) 
            : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateSignalImage(
            [FromBody] CreateSinusoidalSignalRequest request, 
            CancellationToken cancellationToken) 
        {
            var command = new CreateSinusoidalSignalCommand(
                Guid.NewGuid(),
                request.Amplitude,
                request.SamplingFrequency,
                request.SignalFrequency,
                request.PeriodValue);

            await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetByIdSignalImage), new { signalId = command.Id }, command);
        }

        [HttpGet("{signalId:guid}")]
        public async Task<IActionResult> GetByIdSignalImage(Guid signalId, CancellationToken cancellationToken)
        {
            var query = new GetByIdSinusoidalSignalQuery(signalId);

            var response = await Sender.Send(query, cancellationToken);

            var fileName = $"signal_image.jpeg";
            var contentType = "application/octet-stream"; ;
            Response.Headers.Append("Content-Disposition", $"attachment; filename={fileName}");

            return File(response.ImageBytes, contentType, fileName);
        }          
    }
}
