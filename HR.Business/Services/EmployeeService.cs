using HR.Business.Interfaces;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

public class EmployeeService : IEmployeeServices
{
    public void CreateEmployee(string name, string? surname, int salary, Department? departmentId)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        
            Department? dbdepartment =
            HRDbContext.Departments.Find(c =>Convert.ToString( c.Id) == Convert.ToString(departmentId));
        //if (dbdepartment is not null )
        //{
        //    Employee employee = new(name, surname, salary,departmentId );
        //    HRDbContext.Employees.Add(employee);
        //}

    }

    public void DeleteEmployee(string employeeId)
    {
        throw new NotImplementedException();
    }
}
