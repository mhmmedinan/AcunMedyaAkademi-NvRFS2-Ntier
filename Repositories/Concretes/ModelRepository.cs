using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstracts;
using Repositories.Concretes.EntityFramework.Contexts;

namespace Repositories.Concretes;

public class ModelRepository : EfRepositoryBase<Model, Guid, BaseDbContext>, IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)
    {
    }
}

