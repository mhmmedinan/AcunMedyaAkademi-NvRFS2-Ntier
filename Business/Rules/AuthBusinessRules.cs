using Core.Exceptions.Types;
using Core.Rules;
using Core.Security.Entities;
using Core.Security.Hashing;
using Repositories.Abstracts;

namespace Business.Rules;

public class AuthBusinessRules:BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void UserEmailShouldBeNotExists(string email)
    {
        User? user = _userRepository.Get(x=>x.Email==email);
        if (user is not null) throw new BusinessException("User mail already exists");
    }

    public void UserEmailShouldBeExists(string email)
    {
        User? user = _userRepository.Get(x => x.Email == email);
        if (user is null) throw new BusinessException("Email or Password don't match");
    }

    public void UserShouldBeExists(User? user)
    {
        if (user is null) throw new BusinessException("Email or Password don't match");
    }

    public void UserPasswordShouldBeExists(Guid id,string password)
    {
        User? user = _userRepository.Get(x => x.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            throw new BusinessException("Email or Password don't match");
    }
}
