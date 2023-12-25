using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;
using System.Xml.Linq;

namespace HR.Business.Services;

public class DepartmentService : IDepartmentServices
{
    //private ICompanysService companyService { get; }
    //public DepartmentService()
    //{
    //    companyService = new ICompanysService();
    //}
    public void CreateDepartment(string name, int employeeLimit, int companyId)
    {
        foreach (var company in HRDbContext.Companies)
        {
            if (companyId != company.Id)
            {
                throw new NotFoundException($"Company with id:{companyId} doesn't exist");
            }


            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            Department? dbDepartment =
                 HRDbContext.Departments.Find(a => a.Name.ToLower() == name.ToLower());
            if (dbDepartment is not null)
                throw new AlreadyExistException($"{dbDepartment.Name} already exists.");
            //maxstudentcount yaratmax ve muqaise etmek
            //companinin var oldugunun yoxlamaq
            //eger bir exceptiona yoxdursa yaratmaq
            Department department = new(name);
            HRDbContext.Departments.Add(department);
        }







    }
    public void AddEmployee(Employee employee, int departmentId)
    {
        if(string.IsNullOrEmpty(employee.Name)) throw new ArgumentNullException();
        Employee? dbEmployee =
            HRDbContext.Employees.Find(a => a.Name.ToLower() == employee.Name.ToLower());
        if (dbEmployee is not null)
            throw new AlreadyExistException($"{employee.Name} already exists.");
        //employee.DepartmentId = departmentId; 
        //Employee employee1 = new(employee.Name,employee.DepartmentId);
        //HRDbContext.Employees.Add(employee1);









    }

    public void UpdateDepartment(string name,string newName, int employeeLimit)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Department? dbDepartment =
             HRDbContext.Departments.Find(a => a.Name.ToLower() == name.ToLower());
        if (dbDepartment is not null)
        {
            dbDepartment.Name = newName;
        }


    }

    public void GetDepartmentEmployees(string name)
    {
        throw new NotImplementedException();
    }

   
}
