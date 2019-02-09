using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestOpenID.Controllers
{
    public class DynamicAuthenticationSelectorHandler : AuthorizationHandler<DynamicAuthenticationRequirement>
    {
        public enum AuthenticationType {OpenId,Password,Free};
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DynamicAuthenticationRequirement requirement)
        {
            String authenticationType = "";
            if (context.User.HasClaim(c => c.Type == "Type")) authenticationType = context.User.Claims.FirstOrDefault(c => c.Type == "Type").Value;
            Boolean isAValidAuthenticationType = Enum.IsDefined(typeof(AuthenticationType), authenticationType);
            if (isAValidAuthenticationType) {
                if (authenticationType  == "OpenId")
                {
                // If user does not have the scope claim, get out of here
                    if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
                        return Task.CompletedTask;

                    // Split the scopes string into an array
                    var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');

                    // Succeed if the scope array contains the required scope
                    if (scopes.Any(s => s == requirement.Scope))
                        context.Succeed(requirement);

                    return Task.CompletedTask;
                }
                else
                    {
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
            }
            else
            {
                return Task.CompletedTask;
            }
        }
    }
}
