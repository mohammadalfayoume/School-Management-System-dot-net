namespace EntityLayer.Entities;

public class University : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public ICollection<User> Users { get; set; }
}
