using HR.Core.Entities;

namespace HR.Business.Interfaces;

public interface ICompanyServices
{
    void Create(string name);
    /// <summary>
    /// If company is empty
    /// </summary>
    /// <param name="name"></param>
    void Delete(string name, bool isActive = true);
    void GetAllDepartment(string name);
    void GetCompanyIncluded(string name);
    void ShowAllCompanies();
    
}
