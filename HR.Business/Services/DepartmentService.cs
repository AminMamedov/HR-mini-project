using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

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
    public void AddEmployee(Employee employee)
    {
        throw new NotImplementedException();

    }

    public void UpdateDepartment(string newName, int employeeLimit)
    {
        
    }

    public void GetDepartmentEmployees(string name)
    {
        throw new NotImplementedException();
    }
}
