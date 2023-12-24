using HR.Core.Interface;

namespace HR.Core.Entities;

public class Employee :IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Salary { get; set; }
    public Department DepartmentId { get; set; }
    private static int _id;
    public Employee(string name, string surname, int salary)
    {
        Id = _id++;
        Name = name;
        Surname = surname;
        Salary = salary;
    }

}
