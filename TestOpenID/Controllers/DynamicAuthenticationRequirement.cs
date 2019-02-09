using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TestOpenID.Controllers
{
    public class DynamicAuthenticationRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }
        public string Type { get; }

        public DynamicAuthenticationRequirement(string scope,string issuer, string type)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
            Type = type ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
}
