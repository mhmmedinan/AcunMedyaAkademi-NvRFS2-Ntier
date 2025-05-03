using Core.Repositories;
using Entities;

namespace Repositories.Abstracts;

public interface ICarRepository : IRepository<Car, Guid>
{
}
