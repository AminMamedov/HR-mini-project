using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

public class CompanyService : ICompanyServices
{
    private IDepartmentServices _departmentservice;
    public CompanyService()
    {
        _departmentservice = new DepartmentService();
    }
   
    public void Create(string name)
    {
       if(String.IsNullOrEmpty(name)) throw new ArgumentNullException();
       
       Company? dbCompany =
            HRDbContext.Companies.Find(c=>c.Name.ToLower()== name.ToLower());
        if (dbCompany is not null && dbCompany.IsActive == true)
            throw new AlreadyExistException($"{dbCompany.Name} is already exist");
        
        Company company = new(name);
        HRDbContext.Companies.Add(company);
    }

    

    public void Delete(int? id)
    {
        if(id is null) throw new ArgumentNullException();
        Company? dbCompany =
            HRDbContext.Companies.Find(c => c.Id == id);
        if (dbCompany is null)
            throw new NotFoundException($"{id} Company not found");
        dbCompany.IsActive = false;

    }

    

    public void GetAllDepartment(int?  id)
    {
        if (id == null) throw new ArgumentNullException();
        Company? dbcompany =
            HRDbContext.Companies.Find(c => c.Id == id);
        if (dbcompany is null)
            throw new NotFoundException($"Company with id :{id} doesn't exist");
        Console.WriteLine($"id: {dbcompany.Id}\n" +
                          $"Company name: {dbcompany.Name}\n");

        GetCompanyIncluded(dbcompany.Id);


    }
    public void GetCompanyIncluded(int? id)
    {
        foreach (var department in HRDbContext.Departments)
        {
            if (department.CompanyId == id)
            {
                Console.WriteLine($"Id: {department.Id}; Department name:{department.Name}");
                Console.WriteLine("------------------------------------------");
            }
        }
    }

    public void ShowAllCompanies()
    {
        foreach (var company in HRDbContext.Companies)
        {
            if(company.IsActive == true)
            {
                Console.WriteLine($"id:{company.Id}  name:{company.Name}");
            }
        }
    }
}
