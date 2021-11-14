using LearnEngine.Application.Commands.Material.V1;
using LearnEngine.Application.Queries.Material.V1;
using LearnEngine.Application.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnEngine.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Authorize(Roles = "User")]
    public class MaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MaterialController(IMediator mediator)
        { 
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialById(string id)
        {
            GetMaterialByIdV1Query query = new()
            {
                Id = id
            };

            MaterialResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterials()
        {
            GetAllMaterialsV1Query getAllMaterials = new();
            List<MaterialResponse> response = await _mediator.Send(getAllMaterials);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterial(CreateMaterialV1Command command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("Group")]
        public async Task<IActionResult> CreateMaterialGroup(CreateMaterialGroupV1Command command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        //[HttpGet("Learn/{materialId}")]
        //public async Task<IActionResult> GetLearn(string materialId)
        //{
        //    return null;
        //}
    }
}