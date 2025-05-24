using Business.Abstracts;
using Core.Security.Entities;
using Repositories.Abstracts;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Add(User user)
    {
        return _userRepository.Add(user);
    }

    public User GetById(Guid id)
    {
        return _userRepository.Get(x=>x.Id==id);
    }

    public User GetByMail(string email)
    {
        return _userRepository.Get(x => x.Email == email);
    }
}
