using LearnEngine.Application.Commands.Material;
using LearnEngine.Application.Queries.Material;
using LearnEngine.Application.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LearnEngine.API.Controllers
{
    [ApiController]
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
            GetMaterialByIdQuery query = new()
            {
                Id = id
            };

            MaterialResponse response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterials()
        {
            GetAllMaterialsQuery getAllMaterials = new();
            List<MaterialResponse> response = await _mediator.Send(getAllMaterials);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMaterialCommand command)
        {
            MaterialResponse response = await _mediator.Send(command);

            return Ok(response);
        }

       
    }
}