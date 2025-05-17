using Core.Repositories.EntityFramework;
using Core.Security.Entities;
using Repositories.Abstracts;
using Repositories.Concretes.EntityFramework.Contexts;

namespace Repositories.Concretes;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}

