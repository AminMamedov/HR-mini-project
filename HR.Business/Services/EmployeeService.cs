using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

public class EmployeeService : IEmployeeServices
{
    public void CreateEmployee(string name, string? surname, int salary, Department  departmentId)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();

        
            Department? dbdepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);
        if (dbdepartment is null) throw new NotFoundException($"Department with id;{departmentId} doesn't exist");
        Employee employee = new(name, surname,salary);
        if (dbdepartment.CurrentEmployeeCount > dbdepartment.EmployeeLimit)
        {
            throw new CapacityLimitException($"Maximum employee count should be {dbdepartment.EmployeeLimit}");
        }
        employee.CompanyId = dbdepartment.CompanyId;
        dbdepartment.CurrentEmployeeCount++;

        //if (dbdepartment is not null )
        //{
        //    Employee employee = new(name, surname, salary,departmentId );
        //    HRDbContext.Employees.Add(employee);
        //}

    }
    public void ChangeDepartment(int employeeId, int newdepartmentId)
    {

    }


    public void DeleteEmployee(string employeeId)
    {
        throw new NotImplementedException();
    }

    public void ShowAllEmployees()
    {
        throw new NotImplementedException();
    }
}
