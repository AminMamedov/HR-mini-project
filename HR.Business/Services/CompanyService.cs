using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

public class CompanyService : ICompanyServices
{
    private IDepartmentServices _departmentservice;
    private IEmployeeServices _employeeservice;
    public CompanyService()
    {
        _departmentservice = new DepartmentService();
        _employeeservice = new EmployeeService();

    }
    

    public void Create(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();

        Company? dbCompany =
             HRDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCompany is not null && dbCompany.IsActive == true)
            throw new AlreadyExistException($" Company with name :{dbCompany.Name} is already exist");

        Company company = new(name);
        HRDbContext.Companies.Add(company);
    }



    public void Deactivate(int? id)
    {
        if (id is null) throw new ArgumentNullException();
        Company? dbCompany =
            HRDbContext.Companies.Find(c => c.Id == id);
        if (dbCompany is null)
            throw new NotFoundException($"{id} Company not found");
        dbCompany.IsActive = false;
        foreach (var department in HRDbContext.Departments)
        {
            if(department.CompanyId == id)
            {
                //department.e = false;
                _departmentservice.DeactiveDepartment(department.Id); break;
            }
        }foreach (var employee in HRDbContext.Employees)
        {
            if(employee.DepartmentId == id)
            {
                _employeeservice.DeactivateEmployee(employee.Id); break;
            }
        }
        
    }
    public void Activate(int? id)
    {
        if (id is null) throw new ArgumentNullException();
        Company? dbCompany =
            HRDbContext.Companies.Find(c => c.Id == id);
        if (dbCompany is null)
            throw new NotFoundException($"{id} Company not found");
        dbCompany.IsActive = true;
        
    }



    public void GetCompanyDepartments(int? id)
    {
        if (id is null) throw new ArgumentNullException();
        Company? dbcompany =
            HRDbContext.Companies.Find(c => c.Id == id);
        if (dbcompany is null)
            throw new NotFoundException($"Company with id :{id} doesn't exist");

        //if (_departmentservice.IsDepartmentExist(true) == false) throw new NotFoundException("There isn't any dapartment created");
        foreach (var department in HRDbContext.Departments)
        {
            if (department.CompanyId == id)
            {

                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"Id: {department.Id}  | Department name: {department.Name}");
                Console.WriteLine("------------------------------------------");
            }

        }



    }


    public void ShowAllCompanies()
    {
        foreach (var company in HRDbContext.Companies)
        {
            if (company.IsActive == true)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine($"id:{company.Id}  | name:{company.Name}");
                Console.WriteLine("---------------------");
            }
        }
    }
    public bool IsCompanyExist( bool isActive)
    {
        foreach (var company in HRDbContext.Companies)
        {
            if (company is not null && company.IsActive == isActive) return true;
        }
        return false;
    }
     public void ShowDeactiveCompanies()
    {
        foreach(var company in HRDbContext.Companies)
        {
            if(company.IsActive == false)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine($"id:{company.Id}  | name:{company.Name}");
                Console.WriteLine("---------------------");
            }
        }
    }

    public void DeleteCompany(int? id)
    {
        if (id is null)  throw new ArgumentNullException(); 
        Company? company = 
            HRDbContext.Companies.Find(c=> c.Id == id); 
        if(company is null)  throw new NotFoundException($"The company with id :{id} doesn't exist"); 
       
        HRDbContext.Companies.Remove(company);
        
    }
}
