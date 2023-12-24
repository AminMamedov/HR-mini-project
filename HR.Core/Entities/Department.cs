using HR.Core.Interface;
using System.Security.Cryptography;

namespace HR.Core.Entities;

public class Department : IEntity
{
    public int Id {  get;  }
    public string Name { get; set; }
    public int EmployeeLimit { get; set; }
    public int CompanyId { get; set; }
    private static int _id;
    public Department(string name)
    {
        Id = _id++;
        Name = name;
    }

}
