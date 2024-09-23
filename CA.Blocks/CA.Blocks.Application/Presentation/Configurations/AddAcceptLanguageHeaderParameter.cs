using CA.Blocks.Domain.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CA.Blocks.Application.Presentation.Configurations;

public class AddAcceptLanguageHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var languages = Enum
            .GetValues(typeof(ApplicationLanguages))
            .Cast<ApplicationLanguages>()
            .Select(x => new OpenApiString(x.ToString()));

        operation.Parameters ??= [];

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "string",
                Enum = languages.Cast<IOpenApiAny>().ToList()
            }
        });
    }
}
