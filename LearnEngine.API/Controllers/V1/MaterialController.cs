using LearnEngine.Application.Commands.Material;
using LearnEngine.Application.Queries.Material;
using LearnEngine.Application.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearnEngine.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> CreateMaterial(CreateMaterialCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("Group")]
        public async Task<IActionResult> CreateMaterialGroup(CreateMaterialGroupCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        //[HttpGet("Tree/{materialId}")]
        //public async Task<IActionResult> GetTree(string materialId)
        //{
        //    return null;
        //}
    }
}