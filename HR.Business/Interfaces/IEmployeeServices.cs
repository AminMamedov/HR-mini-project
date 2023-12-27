using HR.Core.Entities;
using System.Globalization;

namespace HR.Business.Interfaces
{
    public  interface IEmployeeServices
    {
        void CreateEmployee(string name, string surname, int salary,int departmentId);
        void DeleteEmployee(int employeeId);
        void ShowAllEmployees();
        void ChangeDepartment(int employeeId,int newdepartmentId);













    }
}
