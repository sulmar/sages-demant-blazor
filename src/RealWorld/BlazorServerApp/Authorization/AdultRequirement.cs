using BlazorServerApp.Domain;
using Microsoft.AspNetCore.Authorization;

namespace BlazorServerApp.Authorization;

public record AdultRequirement(int MinimumAge) : IAuthorizationRequirement; // mark interface


public class AdultRequirementHandler : AuthorizationHandler<AdultRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdultRequirement requirement)
    {
        if (context.User.HasClaim(c => c.Type == "DateOfBirth"))
        {
            var dateOfBirth = DateTime.Parse(context.User.FindFirst(c => c.Type == "DateOfBirth").Value);

            var age = DateTime.Today.Year - dateOfBirth.Year;

            if (dateOfBirth > DateTime.Today.AddYears(-age))
                age--;

            if (age >= requirement.MinimumAge)
            {
                context.Succeed(requirement);
            }

            else
                context.Fail();
        }
        return Task.CompletedTask;
    }
}

public record DocumentOwnerRequirement : IAuthorizationRequirement;

public class DocumentOwnerRequirementHandler : AuthorizationHandler<DocumentOwnerRequirement, Customer>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DocumentOwnerRequirement requirement, Customer resource)
    {
        throw new NotImplementedException();
    }
}
