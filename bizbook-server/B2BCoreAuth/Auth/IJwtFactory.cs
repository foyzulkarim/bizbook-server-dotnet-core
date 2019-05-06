using System.Security.Claims;
using System.Threading.Tasks;

namespace B2BCoreApi.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id, string shopId);
    }
}
