using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DemoAuth.Configs
{
    public class CustomSchemaFilters : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var excludeProperties = new[] { "CorrelationId" };

            excludeProperties.ToList().ForEach(prop =>
            {
                if (schema.Properties.ContainsKey(prop))
                    schema.Properties.Remove(prop);
            });
        }

    }
}
