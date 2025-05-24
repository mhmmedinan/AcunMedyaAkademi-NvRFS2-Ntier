using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    AccessToken Register(UserForRegisterDto userForRegisterDto);
    AccessToken Login(UserForLoginDto userForLoginDto);
    AccessToken CreateAccessToken(User user);
}
