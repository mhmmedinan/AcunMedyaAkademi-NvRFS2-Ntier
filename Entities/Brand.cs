using Core.Entities;

namespace Entities;

public class Brand:BaseEntity<Guid>
{
    public string Name { get; set; }


    public virtual ICollection<Model> Models { get; set; } //OneTOMany

    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(Guid id,string name)
    {
        Id = id;
        Name = name;
    }
}
