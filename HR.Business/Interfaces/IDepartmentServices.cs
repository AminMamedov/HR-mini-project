using HR.Core.Entities;
using System.Drawing;

namespace HR.Business.Interfaces
{
    public  interface IDepartmentServices
    {
        void CreateDepartment(string name, int employeeLimit);
        void AddEmployee(Employee employee);
    }
}
