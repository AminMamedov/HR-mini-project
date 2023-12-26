using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

public class CompanyService : ICompanyServices
{
    public void Create(string? name)
    {
       if(String.IsNullOrEmpty(name)) throw new ArgumentNullException();
       Company? dbCompany =
            HRDbContext.Companies.Find(c=>c.Name.ToLower()== name.ToLower());
        if (dbCompany is not null)
            throw new AlreadyExistException($"{dbCompany.Name} is already exist");
        Company company = new(name);
        HRDbContext.Companies.Add(company);
    }

    

    public void Delete(string name, bool isActive = true)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbCompany =
            HRDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbCompany is null)
            throw new NotFoundException($"{name} Company not found");
        dbCompany.IsActive = false;

    }

    

    public void GetAllDepartment(string  name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        Company? dbcompany =
            HRDbContext.Companies.Find(c => c.Name.ToLower() == name.ToLower());
        if (dbcompany is null)
            throw new NotFoundException($"{name} company not found");
        Console.WriteLine($"id: {dbcompany.Id}\n" +
                          $"Company name: {dbcompany.Name}\n");

        GetCompanyIncluded(dbcompany.Name);


    }
    public void GetCompanyIncluded(string name)
    {
        foreach (var department in HRDbContext.Departments)
        {
            if (department.Company.Name.ToLower() == name.ToLower())
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
