using Core.Repositories;
using Core.Security.Entities;

namespace Repositories.Abstracts;

public interface IUserOperationClaimRepository : IRepository<UserOperationClaim, int>
{
}