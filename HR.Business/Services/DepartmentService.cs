using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

public class DepartmentService : IDepartmentServices
{
    public void CreateDepartment(string name, int employeeLimit)
    {
       if(string.IsNullOrEmpty(name)) throw new ArgumentNullException();
       Department? dbDepartment =
            HRDbContext.Departments.Find(a=>a.Name.ToLower() == name.ToLower());
        if(dbDepartment is not null)
            throw new AlreadyExistException($"{dbDepartment.Name} already exists.");
        //maxstudentcount yaratmax ve muqaise etmek
        //companinin var oldugunun yoxlamaq
        //eger bir exceptiona yoxdursa yaratmaq
        Department department = new(name);
        HRDbContext.Departments.Add(department);
            




    }
    public void AddEmployee(Employee employee)
    {
        throw new NotImplementedException();
        
    }

}
