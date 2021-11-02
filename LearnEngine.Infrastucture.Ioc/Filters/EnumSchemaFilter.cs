using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LearnEngine.Infrastucture.Ioc.Filters
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                model.Enum.Clear();

                var values = Enum.GetValues(context.Type).Cast<int>().ToArray();
                var names = Enum.GetNames(context.Type);
                for (int i = 0; i < names.Length; i++)
                {
                    model.Enum.Add(new OpenApiString($"{names[i]} - {values[i]}"));
                }
            }
        }
    }
}
