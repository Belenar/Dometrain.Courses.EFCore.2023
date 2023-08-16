namespace Dometrain.EFCore.Tenants.Databases.Tenants;

/// <summary>
/// This could get the tenant from anywhere (token, database, ...).
/// This implementation gets it from the header for brevity.
/// </summary>
public class TenantService
{
   private readonly IHttpContextAccessor _contextAccessor;

   public TenantService(IHttpContextAccessor contextAccessor)
   {
      _contextAccessor = contextAccessor;
   }

   private string? _tenantId = null;

   public string? GetTenantId()
   {
      if (_tenantId is not null)
         return _tenantId;
      
      var header = _contextAccessor.HttpContext?.Request.Headers
         .FirstOrDefault(h => h.Key.ToLower() == "x-tenant");
        
      if(header is { Value: { } value })
      {
         if(value.Any())
            _tenantId = value.First()!;
      }
      return _tenantId;
   }
}