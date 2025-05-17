using Core.Entities;

namespace Core.Security.Entities;

public class UserOperationClaim:BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User{ get; set; }
    public virtual OperationClaim OperationClaim { get; set; }


    public UserOperationClaim()
    {
        
    }

    public UserOperationClaim(int id,Guid userId, int operationClaimId)
    {
        Id = id;
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}
