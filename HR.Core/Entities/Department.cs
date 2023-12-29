using HR.Core.Interface;
using System.Security.Cryptography;

namespace HR.Core.Entities;

public class Department : IEntity
{
    public int ?Id {  get;  }
    public string Name { get; set; }
    public Company Company { get; set; }
    public int? EmployeeLimit { get; set; }
    public int CurrentEmployeeCount { get; set; } = 0;
    public int CompanyId { get; set; }
    public bool isActive { get; set; } = true;
    private static int _id;
    public Department(string name,int? employeelimit)
    {
        Id = _id++;
        Name = name;
        EmployeeLimit = employeelimit;
        
    }

}
