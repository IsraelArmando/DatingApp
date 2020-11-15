using API.Entities;

namespace API.Interfaces
{
    //4.41{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
    //}4.41
}