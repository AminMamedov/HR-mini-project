using HR.Core.Entities;
using System.Globalization;

namespace HR.Business.Interfaces
{
    public  interface IEmployeeServices
    {
        void CreateEmployee(string name, string surname, int? salary, int? departmentId);
        
        void DeactivateEmployee(int? employeeId);
        void ShowAllEmployees();
        void ChangeEmployeeDepartment(int? employeeId,int? newdepartmentId);
        bool IsEmployeeExist(bool isActive);
        void ActivateEmployee(int? employeeId);
        void DeleteEmployee(int? employeeId);
        void ShowDeactiveEmployee();













    }
}
