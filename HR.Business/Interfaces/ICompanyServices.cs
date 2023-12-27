using HR.Core.Entities;

namespace HR.Business.Interfaces;

public interface ICompanyServices
{
    void Create(string name);
    /// <summary>
    /// If company is empty
    /// </summary>
    /// <param name="name"></param>
    void Delete(int? id);
    void GetAllDepartment(int? id);
    void GetCompanyIncluded(int? id);
    void ShowAllCompanies();
    
}
