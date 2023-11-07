using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dometrain.EFCore.Tenants.QueryFilter.Tenants;

public class TenantHeaderSwaggerAttribute : IOperationFilter
{
     
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();
 
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "X-Tenant",
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema
            {
                Type = "string" 
            }
        });
    }
}