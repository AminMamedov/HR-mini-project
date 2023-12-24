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

    public void Deactivate(string name, bool isActive = true)
    {
        throw new NotImplementedException();
    }

    public void Delete(string name)
    {
        throw new NotImplementedException();
    }

    public void GetAllDepartment(string name)
    {
        throw new NotImplementedException();
    }

    public void ShowAllCompanies()
    {
        throw new NotImplementedException();
    }
}
