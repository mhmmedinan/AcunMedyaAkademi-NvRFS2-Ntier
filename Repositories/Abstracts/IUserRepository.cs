using Core.Repositories;
using Core.Security.Entities;

namespace Repositories.Abstracts;

public interface IUserRepository : IRepository<User, Guid>
{
}
