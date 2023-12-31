using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;
using System.Xml.Linq;

namespace HR.Business.Services;

public class DepartmentService : IDepartmentServices
{

    public void CreateDepartment(string name, int? companyId, int? employeeLimit)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        if (companyId is null) throw new ArgumentNullException();
        if (employeeLimit is null) throw new ArgumentNullException();

        Company? dbCompany =
                HRDbContext.Companies.Find(c => c.Id == companyId);
        if (dbCompany is null)
        {
            throw new NotFoundException($"Company with id:{companyId} not exist.");
        }
        if(dbCompany.IsActive == false)
        {
            throw new NotFoundException($"The company with id : {companyId} doesn't exist.");
        }
        Department? dbDepartment =
             HRDbContext.Departments.Find(a => a.Name.ToLower() == name.ToLower());
        if (dbDepartment is not null)
        {

            if (dbDepartment.Id == companyId)
            {
                throw new AlreadyExistException($"IN company with id:{companyId} department with name{name} is already exist");
            }
        }
        if (employeeLimit > 6)
        {
            throw new CapacityLimitException($"Maximum employee count should be 6");
        }
        //    dbDepartment.CompanyId = companyId;
        //dbDepartment.EmployeeLimit = employeeLimit;
        //dbDepartment.Name = name;
        Department department = new(name,companyId, employeeLimit);
        HRDbContext.Departments.Add(department);
        department.isActive = true;


    }
    public void AddEmployee(Employee employee, int departmentId)
    {
        if (employee.Id is null) throw new ArgumentNullException();
        if(string.IsNullOrEmpty(employee.Name)) throw new ArgumentNullException();
        if(string.IsNullOrEmpty(employee.Surname)) throw new ArgumentNullException();
        if(employee.Salary is null) throw new ArgumentNullException();
        if (employee.DepartmentId is null)  throw new ArgumentNullException(); 
        Employee? dbEmployee =
            HRDbContext.Employees.Find(a => a.Id == employee.Id);
        Department? dbDepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);
        if (dbDepartment is null)
        {
            throw new NotFoundException($"Department with id:{departmentId} not found");
        }
        //if (employee.DepartmentId == departmentId)
        //{
        //    throw new AlreadyExistException($" Employee with id:{employee.Id} already exists in department with id:{departmentId}.");
        //}
        dbDepartment.CurrentEmployeeCount++;
        employee.IsActive= true;    
        if (dbDepartment.CurrentEmployeeCount > dbDepartment.EmployeeLimit)
        {
            throw new CapacityLimitException($"Maximum employee count should be {dbDepartment.EmployeeLimit}");
        }
        
        employee.DepartmentId = departmentId;
        

        

        HRDbContext.Employees.Add(employee);
    }
    public void GetDepartmentById(int? departmentId)
    {
        if (departmentId is null) throw new ArgumentNullException();
        Department? dbDepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);

        if (dbDepartment is null) throw new NotFoundException($"Department with id:{departmentId} doesn't exict");
        foreach (var item in HRDbContext.Departments)
        {
            if (item.Id == departmentId && item.isActive == true)
            {
                Console.WriteLine($" Department id:{item.Id}   Department name:{item.Name}  ");
            }
            else
            {
                throw new NotFoundException($"Department with id : {departmentId} doesn't exist.");
            }
        }
    }
    public void UpdateDepartment(int? departmentId, string newName, int? newemployeeLimit)
    {
        if (departmentId is null) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(newName)) throw new ArgumentNullException();
        if (newemployeeLimit is null) throw new ArgumentNullException();
        Department? dbDepartment =
             HRDbContext.Departments.Find(a => a.Id == departmentId);
        if (dbDepartment is not null)
        {
            if (newemployeeLimit < dbDepartment.CurrentEmployeeCount) throw new CouldNotUptadeDepartment($"Youe EmployeeLimit is less than Current count of Employee,set EmployeeLimit more than{dbDepartment.CurrentEmployeeCount}");
            dbDepartment.Name = newName;
            dbDepartment.EmployeeLimit = newemployeeLimit;
        }
    }
    public void GetDepartmentEmployees(int? departmentId)
    {
        if (departmentId is null) throw new ArgumentNullException();

        Department? dbdepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);
        if (dbdepartment is null)
            throw new NotFoundException($"company with id:{departmentId}  not found");
        //Console.WriteLine($"id: {dbdepartment.Id}\n" +
        //                  $"Company name: {dbdepartment.Name}\n");
        if (dbdepartment.isActive == true)
        {
            foreach (var employee in HRDbContext.Employees)
            {
                if (employee.IsActive == true)
                {
                    if (employee.DepartmentId == departmentId)
                        Console.WriteLine($"Employee id:{employee.Id}  Employee name:{employee.Name}  Employee surname : {employee.Surname}  Employee salary : {employee.Salary}");

                }
            }

        }
    }

    public void DeactiveDepartment(int? departmentId)
    {
        if (departmentId is null) throw new ArgumentNullException();
        Department? dbdepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);
        if (dbdepartment is null) throw new NotFiniteNumberException($" Department with ID:{departmentId} doesn't exist");
        dbdepartment.isActive = false;
        foreach (var employee in HRDbContext.Employees)
        {
            ///////////////////////////////////////////////////////////////////////////////////
            if (employee.Id == departmentId)
            {
                employee.IsActive = false;
            }
        }
    }
    public void ShowAllDepartments()
    {
        foreach (var department in HRDbContext.Departments)
        {
            if (department.isActive == true)
            {
                Console.WriteLine($"Department ID:{department.Id} | Department Name:{department.Name}");
            }
        }
    }
    public bool IsDepartmentExist( bool isAcive)
    {
        foreach (var department in HRDbContext.Departments)
        {
            if (department is not null && department.isActive == isAcive) return true;
        }
        return false;
    }
    public void ActivateDepartment(int? departmentId, int? newCompanyId)
    {
        if (departmentId is null) throw new ArgumentNullException();
        Department? dbdepartment =
            HRDbContext.Departments.Find(c => c.Id == departmentId);
        if (dbdepartment is null) throw new NotFiniteNumberException($" Department with ID:{departmentId} doesn't exist");
        dbdepartment.isActive = true;
        dbdepartment.CompanyId = newCompanyId;
        foreach (var employee in HRDbContext.Employees)
        {
            ///////////////////////////////////////////////////////////////////////////////////
            if (employee.Id == departmentId)
            {
                employee.IsActive = true;
                employee.CompanyId = newCompanyId;
            }
        }
    }
    public void ShowDeactiveDepartment()
    {
        foreach (var department in HRDbContext.Departments)
        {
            if (IsDepartmentExist(false) == true)
            {
                if (department is null) { throw new NotFoundException(" There isn't any deactive department"); }

                Console.WriteLine($" Department ID :{department.Id} | Department Name : {department.Name}");
            }
            else
            {
                throw new NotFoundException("There isn't any deactive department");
            }
        }
    }
    public void DeleteDepartment(int? id)
    {
        if (id is null) { throw new ArgumentNullException(); }
        Department? department =
            HRDbContext.Departments.Find(c => c.Id == id);
        if (department is null) { throw new NotFoundException($"The department with id :{id} doesn't exist"); }
        if(department.isActive == false) 
        {
        
        HRDbContext.Departments.Remove(department);
        }
        
        //foreach (var employee in HRDbContext.Employees)
        //{
        //    if (employee.IsActive == false)
        //    {
        //        HRDbContext.Employees.Remove(employee);
        //    }
        //}
    }
}



















