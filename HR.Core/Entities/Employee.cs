using HR.Core.Interface;

namespace HR.Core.Entities;

public class Employee :IEntity
{
    public int ?Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int? Salary { get; set; }
    public bool IsActive {  get; set; }=true;
    public int? DepartmentId { get; set; } = null;
    public int? CompanyId {  get; set; }
    private static int _id;
    public Employee(string name,string surname,int? salary,int? departmentId)
    {
        Id = _id++;
        Name = name;
        Salary = salary;
        Surname = surname;
        DepartmentId = departmentId;
        
    }

    public Employee(string name, int? departmentId)
    {
        Name = name;
        
    }
}
