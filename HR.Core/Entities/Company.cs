using HR.Core.Interface;

namespace HR.Core.Entities;

public class Company :IEntity

{
    public int Id {  get;  }
    public bool IsActive {  get; set; }
    public string Name { get; set; }
    private static int _id;
    public Company(string name )
    {
        Id = _id++;
        Name = name;
    }

}
