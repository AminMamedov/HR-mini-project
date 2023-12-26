using HR.Core.Entities;
using System.Globalization;

namespace HR.Business.Interfaces
{
    public  interface IEmployeeServices
    {
        void CreateEmployee(string name, string surname, int salary,Department? departmentId);
        void DeleteEmployee(string employeeId);










    }
}
