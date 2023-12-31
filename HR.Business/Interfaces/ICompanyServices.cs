using HR.Core.Entities;

namespace HR.Business.Interfaces;

public interface ICompanyServices
{
    void Create(string name);
    /// <summary>
    /// If company is empty
    /// </summary>
    /// <param name="name"></param>
    void Deactivate(int? id);
    void Activate(int? id);
    void GetCompanyDepartments(int? id);
    //void GetCompanyIncluded(int? id);
    void ShowAllCompanies();
    void ShowDeactiveCompanies();
    bool IsCompanyExist(bool isAcive);
    void DeleteCompany(int? id);
    
}
