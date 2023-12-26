using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;
using System.Xml.Linq;

namespace HR.Business.Services;

public class DepartmentService : IDepartmentServices
{
    
    public void CreateDepartment(string name, int companyId, int employeeLimit)
    {
        Company? dbCompany =
                HRDbContext.Companies.Find(c => c.Id == companyId);
        if (dbCompany is null)
        {
            throw new NotFoundException($"Company with id:{companyId} not exist.");
        }
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? dbDepartment =
             HRDbContext.Departments.Find(a => a.Name.ToLower() == name.ToLower());
        if (dbDepartment is not null)
        {

            if (dbDepartment.Id == companyId)
            {
                throw new AlreadyExistException($"IN company with id:{companyId} department with name{name} is already exist");
            }
        }
        Department department = new(name, employeeLimit);
        HRDbContext.Departments.Add(department);
        if (employeeLimit > 6)
        {
            throw new CapacityLimitException($"Maximum employee count should be 6");
        }

        
    }
    public void AddEmployee(Employee employee, int departmentId)
    {
        if (employee.Id is null) throw new ArgumentNullException();
        Employee? dbEmployee =
            HRDbContext.Employees.Find(a => a.Id == employee.Id);
        Department? dbDepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);
        if (dbDepartment is null)
        {
            throw new NotFoundException($"Department with id:{departmentId} not found");
        }
        if (employee.DepartmentId == departmentId)
        {
            throw new AlreadyExistException($" Employee with id:{employee.Id} already exists in department with id:{departmentId}.");
        }
        dbDepartment.CurrentEmployeeCount++;
        if (dbDepartment.CurrentEmployeeCount > dbDepartment.EmployeeLimit)
        {
            throw new CapacityLimitException($"Maximum employee count should be {dbDepartment.EmployeeLimit}");
        }
        employee.DepartmentId = departmentId;

        Employee employee1 = new(employee.Name, employee.DepartmentId);

        HRDbContext.Employees.Add(employee1);
    }
    public void GetDepartmentById(int departmentId)
    {
        Department? dbDepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);

        if (dbDepartment is null) throw new NotFoundException($"Department with id:{departmentId} doesn't exict");
        foreach (var item in HRDbContext.Departments)
        {
            if (item.Id == departmentId)
            {
                Console.WriteLine($" Department id:{item.Id}   Department name:{item.Name}  ");
            }
        }
    }
    public void UpdateDepartment(string name, string newName, int employeeLimit)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? dbDepartment =
             HRDbContext.Departments.Find(a => a.Name.ToLower() == name.ToLower());
        if (dbDepartment is not null)
        {
            dbDepartment.Name = newName;
            dbDepartment.EmployeeLimit = employeeLimit;
        }
    }
    public void GetDepartmentEmployees(int departmentId)
    {

        Department? dbdepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);
        if (dbdepartment is null)
            throw new NotFoundException($"company with id:{departmentId}  not found");
        Console.WriteLine($"id: {dbdepartment.Id}\n" +
                          $"Company name: {dbdepartment.Name}\n");
        foreach (var employee in HRDbContext.Employees)
        {
            if (employee.Id == departmentId)
                Console.WriteLine($"Employee id:{employee.Id}  Employee name:{employee.Name}");
        }
    }

    public void DeleteDepartment(int departmentId)
    {
        Department? dbdepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);
        if (dbdepartment is null) throw new NotFiniteNumberException($" Department with ID:{departmentId} doesn't exist");
        dbdepartment.isActive = false;
        Console.WriteLine($"Department with ID: {departmentId} was deleted.");
    }
    public void ShowAllDepartments()
    {
        foreach(var department  in HRDbContext.Departments)
        {
            if(department.isActive = true)
            {
                Console.WriteLine( $"Department ID:{department.Id}   Department Name:{department.Name}");
            }
        }
    }
}



















