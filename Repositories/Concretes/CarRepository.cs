using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstracts;
using Repositories.Concretes.EntityFramework.Contexts;

namespace Repositories.Concretes;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }
}
