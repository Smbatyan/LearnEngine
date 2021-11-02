using LearnEngine.Application.Queries.Material.GetAllCousesesQuery;
using LearnEngine.Application.ResponseModels;
using LearnEngine.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [HttpGet("Courses")]
        public async Task<IActionResult> GetCoureses()
        {
            GetAllMaterialMetadatasQuery getAllCouseses = new();
            List<MaterialResponse> response = await _mediator.Send(getAllCouseses);

            return Ok(response);
        }


        [HttpGet("Example")]
        [ProducesResponseType(typeof(MaterialResponse), 200)]
        public IActionResult Get()
        {
            string jsonMaterial = "{\"color\":\"#f09348\", \"width\":\"100px\", \"border\": {\"size\" : \"3px\", \"radius\":5, \"margin\":\"5%\" }, \"required\": \"true\"}";
            string jsonMaterialGroup = "{\"color\":\"#f09348\", \"width\":\"100px\", \"border\": {\"size\" : \"3px\", \"radius\":5, \"margin\":\"5%\" }}";

            var dictMaterial = JsonSerializer.Deserialize<object>(jsonMaterial);
            var dictMaterialGroup = JsonSerializer.Deserialize<object>(jsonMaterialGroup);

            #region MG1

            MaterialMetadataResponse metadata1 = new MaterialMetadataResponse()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "",
                MaterialTypeId = Core.Enums.MaterialTypes.Text,
                MetaTypeId = Core.Enums.MaterialMetaTypes.Material,
                Body = "<h1><span>Welcome to C#</span></h1><p><span> C# is an elegant object-oriented language that enables developers to build a variety of secure and robust applications that run on the&nbsp;</span><strong class=\"sl - description - styled sl - description - styled--bold\"><span> .NET Framework.</span></strong><br /><span>You can use C# to create Windows applications, Web services, mobile applications, client-server applications, database applications, and much, much more.</span></p>",
                Configurations = dictMaterial,
            };

            MaterialResponse material1 = new()
            {
                Metadata = metadata1,
                Configurations = dictMaterial
            };

            MaterialMetadataResponse metadata2 = new MaterialMetadataResponse()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Welcome to C#",
                MaterialTypeId = Core.Enums.MaterialTypes.Question,
                MetaTypeId = Core.Enums.MaterialMetaTypes.Material,
                Body = "<h2>C# applications run:</div>",
                Answer = new AnswerResponse { Options = new List<string> { "on the .NET Framework", "using Java", "only on Linux" }, RightAnswerHash = "on the .NET Framework", AnswerTypeId = AnswerTypes.SingleChoice },
                Configurations = dictMaterial,
            };

            MaterialResponse material2 = new()
            {
                Metadata = metadata2,
                Configurations = dictMaterial
            };

            MaterialMetadataResponse materialGroupMetadata1 = new MaterialMetadataResponse()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Welcome to C#",
                MaterialTypeId = Core.Enums.MaterialTypes.Text,
                MetaTypeId = Core.Enums.MaterialMetaTypes.MaterialGroup,
            };

            MaterialResponse materialGroup1 = new MaterialResponse
            {
                Materials = new List<MaterialResponse> { material1, material2 },
                Metadata = materialGroupMetadata1,
                Configurations = dictMaterialGroup
            };

            #endregion

            #region MG2

            MaterialMetadataResponse metadata3 = new MaterialMetadataResponse()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "",
                MaterialTypeId = Core.Enums.MaterialTypes.Text,
                MetaTypeId = Core.Enums.MaterialMetaTypes.Material,
                Body = "<p><span>The .NET Framework consists of the&nbsp;</span><strong><span>Common Language Runtime (CLR)</span></strong><span>&nbsp;and the .NET Framework&nbsp;</span><strong><span>class library</span></strong><span>.</span><br /><span>The&nbsp;</span><strong><span>CLR&nbsp;</span></strong><span>is the foundation of the .NET Framework. It manages code at execution time, providing core services such as memory management, code accuracy, and many other aspects of your code.</span><br /><span>The</span><strong><span>&nbsp;class library</span></strong><span>&nbsp;is a collection of classes, interfaces, and value types that enable you to accomplish a range of common programming tasks, such as data collection, file access, and working with text.</span><br /><span>C# programs use the .NET Framework class library extensively to do common tasks and provide various functionalities.</span></p>",
                Configurations = dictMaterial,
            };

            MaterialResponse material3 = new()
            {
                Metadata = metadata3,
                Configurations = dictMaterial
            };

            MaterialMetadataResponse metadata4 = new MaterialMetadataResponse()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Welcome to C#",
                MaterialTypeId = Core.Enums.MaterialTypes.Text,
                MetaTypeId = Core.Enums.MaterialMetaTypes.Material,
                Body = "<h2>Which one is NOT part of the .NET Framework?</h2>",
                Answer = new AnswerResponse { AnswerTypeId = AnswerTypes.SingleChoice, Options = new List<string> { ".Net Framework Class Library", "Operation System", "Common Language Runtime" }, RightAnswerHash = "Operation System" },
                Configurations = dictMaterial,
            };
            //<p>&nbsp;</p><ul><li><div>.Net Framework Class Library</div></li><li>Operation System</li><li>Common Language Runtime</li></ul>
            MaterialResponse material4 = new()
            {
                Metadata = metadata4,
                Configurations = dictMaterial
            };

            MaterialMetadataResponse materialGroupMetadata2 = new MaterialMetadataResponse()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "The .NET Framework",
                MetaTypeId = Core.Enums.MaterialMetaTypes.MaterialGroup,
            };

            MaterialResponse materialGroup2 = new MaterialResponse
            {
                Materials = new List<MaterialResponse> { material3, material4 },
                Metadata = materialGroupMetadata2,
                Configurations = dictMaterialGroup
            };

            MaterialMetadataResponse materialGroupMetadata3 = new MaterialMetadataResponse()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "1.1 Lesson",
                MetaTypeId = Core.Enums.MaterialMetaTypes.MaterialGroup,
                MaterialTypeId = Core.Enums.MaterialTypes.Lesson,
                Configurations = dictMaterialGroup
            };


            MaterialResponse materialGroup3 = new()
            {
                Materials = new List<MaterialResponse> { materialGroup1, materialGroup2 },
                Metadata = materialGroupMetadata3,
                Configurations = dictMaterialGroup
            };

            #endregion



            return Ok(materialGroup3);
        }
    }
}