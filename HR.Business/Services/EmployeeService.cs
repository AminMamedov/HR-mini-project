using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;
using System.Net.Http.Headers;

namespace HR.Business.Services;

public class EmployeeService : IEmployeeServices
{
    public void CreateEmployee(string name, string? surname, int salary, int  departmentId)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();

        
            Department? dbdepartment =
            HRDbContext.Departments.Find(c =>c.Id == departmentId);
        if (dbdepartment is null) throw new NotFoundException($"Department with id;{departmentId} doesn't exist");
        if (dbdepartment.CurrentEmployeeCount > dbdepartment.EmployeeLimit)
        {
            throw new CapacityLimitException($"Maximum employee count should be {dbdepartment.EmployeeLimit}");
        }
        Employee employee = new(name, surname,salary,departmentId);
        employee.CompanyId = dbdepartment.CompanyId;
        employee.Name = name;
        employee.Surname = surname;
        dbdepartment.CurrentEmployeeCount++;
        employee.Salary =  salary;
        employee.DepartmentId = departmentId;
       HRDbContext.Employees.Add( employee );

        //if (dbdepartment is not null )
        //{
        //    Employee employee = new(name, surname, salary,departmentId );
        //    HRDbContext.Employees.Add(employee);
        //}

    }
    public void ChangeEmployeeDepartment(int employeeId, int newdepartmentId)
    {
        Employee? dbEmployee =
            HRDbContext.Employees.Find(c=>c.Id == employeeId);
        if (dbEmployee is null) throw new NotFoundException($"Employee with id:{employeeId} doesn't exist!");
        Department? dbdepartment =
            HRDbContext.Departments.Find(c => c.Id == newdepartmentId);
        if (dbdepartment is null) throw new NotFoundException($"Department with id:{newdepartmentId} doesn't exist!");
        Department? dbDepartment =
            HRDbContext.Departments.Find(c => c.Id == dbEmployee.DepartmentId);
        if (dbDepartment is null) throw new NotFoundException($"This employee not have department to change it!");
        if (dbdepartment.CurrentEmployeeCount > dbdepartment.EmployeeLimit)
        {
            throw new CapacityLimitException($"Maximum employee count should be {dbdepartment.EmployeeLimit}");
        }
        dbDepartment.CurrentEmployeeCount--;
        dbEmployee.DepartmentId = newdepartmentId;
        dbdepartment.CurrentEmployeeCount++;
        dbEmployee.CompanyId= dbdepartment.CompanyId;


    }


    public void DeleteEmployee(int employeeId)
    {
        Employee? dbEmployee =
            HRDbContext.Employees.Find(c => c.Id == employeeId);
        if (dbEmployee is null) throw new NotFoundException($"Employee with id:{employeeId} doesn't exist");
        Department? dbdepartment=
            HRDbContext.Departments.Find(c=>c.Id == dbEmployee.DepartmentId);
        dbEmployee.IsActive = false;
        dbdepartment.CurrentEmployeeCount--;
        
        
    }

    public void ShowAllEmployees()
    {
        foreach(var employee in HRDbContext.Employees)
        {
            if(employee.IsActive == true) 
            {
                Console.WriteLine( $"Employee id:{employee.Id} Employee Name: {employee.Name} Employee Surname:{employee.Surname}");
            }
        }
    }
}
