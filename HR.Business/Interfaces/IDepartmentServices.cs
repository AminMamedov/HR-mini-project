﻿using HR.Core.Entities;
using System.Drawing;

namespace HR.Business.Interfaces
{
    public  interface IDepartmentServices
    {
        void CreateDepartment(string name, int employeeLimit,int companyId);
        void AddEmployee(Employee employee,int departmentId);
        void UpdateDepartment(string name,string newName, int employeeLimit);
        void GetDepartmentEmployees( int departmentId);
         void GetDepartmentById(int departmentId);
        void DeleteDepartment(int departmentId);
        void ShowAllDepartments();
    }
}
