using Core.Repositories.EntityFramework;
using Core.Security.Entities;
using Repositories.Abstracts;
using Repositories.Concretes.EntityFramework.Contexts;

namespace Repositories.Concretes;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}

