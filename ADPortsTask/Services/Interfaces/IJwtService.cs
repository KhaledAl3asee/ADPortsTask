using ADPortsTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ADPortsTask.Services.Interfaces
{
    public interface IJwtService
    {
        DateTime ExpirationTime { get; }
        string GenerateJwtAccessToken(IEnumerable<Claim> claims);
        Task<Claim[]> GetClaimsAsync(ApplicationUser userInfo);
        ClaimsPrincipal GetPrincipalFromExpiredAccessToken(string accessToken);
    }
}
