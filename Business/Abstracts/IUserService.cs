using Core.Security.Entities;

namespace Business.Abstracts;

public interface IUserService
{
    User GetById(Guid id);
    User GetByMail(string email);
    User Add(User user);
}
