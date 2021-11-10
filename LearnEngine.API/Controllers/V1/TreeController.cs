using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnEngine.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class TreeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TreeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{materialId}")]
        public ActionResult GetTree(string materialId)
        {
            return null;
        }
    }
}
