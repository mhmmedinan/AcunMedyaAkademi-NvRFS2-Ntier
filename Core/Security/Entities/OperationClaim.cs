using Core.Entities;

namespace Core.Security.Entities;

public class OperationClaim:BaseEntity<int>
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    public OperationClaim()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }

    public OperationClaim(int id,string name)
    {
        Id = id;
        Name = name;
    }
}
