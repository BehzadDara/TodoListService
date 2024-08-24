using System.Security.Claims;
namespace TodoList;

public class CurrentUser(IHttpContextAccessor httpContextAccessor)
{
    public string Id => httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
}
