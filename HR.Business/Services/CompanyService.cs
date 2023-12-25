using HR.Business.Interfaces;
using HR.Business.Utilities.Exceptions;
using HR.Core.Entities;
using HR.DataAccess.Contexts;

namespace HR.Business.Services;

internal class CompanyService : ICompanyServices
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
        foreach(var company in HRDbContext.Companies)
        {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
            if (company.Name.ToLower()== name.ToLower())
                company.IsActive = false;
            break;
        }

    }

    

    public void GetAllDepartment(string  name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException();
        foreach (var department in HRDbContext.Departments)
        {
            //verilen compani adi olub olmadigini yoxlamaq(exception vermek)
            //eger company adi vardisa ,verilen company adinin  id'sini 
            //ve movcud olan butun departmentlerin id'lerini muqaise edib
            //eyni id'si olanlari gorsedmek(foreach)
        }
        

    }

    public void ShowAllCompanies()
    {
        foreach (var company in HRDbContext.Companies)
        {
            Console.WriteLine($"id:{company.Id}  name:{company.Name}");
        }
    }
}
