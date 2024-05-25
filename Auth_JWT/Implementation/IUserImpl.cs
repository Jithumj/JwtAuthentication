using Auth_JWT.Models;

namespace Auth_JWT.Implementation
{
    public interface IUserImpl
    {
        string Login(UserModel user);
    }
}
