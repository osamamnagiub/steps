using ASP.NETCoreWebApplication.Model;

namespace ASP.NETCoreWebApplication.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}