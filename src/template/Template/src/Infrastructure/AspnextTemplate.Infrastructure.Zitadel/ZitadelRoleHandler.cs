using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace AspnextTemplate.Infrastructure.Zitadel;

public class HasZitadelRoleRequirement : IAuthorizationRequirement
{
    public string Role { get; }

    public HasZitadelRoleRequirement(string role)
    {
        Role = role;
    }
}

public class ZitadelRoleHandler : AuthorizationHandler<HasZitadelRoleRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        HasZitadelRoleRequirement requirement)
    {
        var rolesClaim = context.User.Claims.FirstOrDefault(c => c.Type == "urn:zitadel:iam:org:project:roles");
        if (rolesClaim != null)
        {
            var rolesData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(rolesClaim.Value);
            if (rolesData?.ContainsKey(requirement.Role) ?? false)
            {
                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }
}
