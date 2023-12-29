using HR.Business.Services;
using HR.Business.Utilities.Helpers;
using HR.Core.Entities;

Console.WriteLine("HR project start");
CompanyService companyService = new();
DepartmentService departmentService = new();
EmployeeService employeeService = new();

//companyService.Create("salam");
//companyService.ShowAllCompanies();
//departmentService.CreateDepartment("amin", 0, 5);
//departmentService.ShowAllDepartments();
//employeeService.CreateEmployee("Emil", "Memmedov", 1000, 0);
//employeeService.ShowAllEmployees();
bool isContinue = true;
while (isContinue)
{

    Console.WriteLine("Choose the option:");
    Console.WriteLine("----------------------------------");
    Console.WriteLine("-- Company--\n" +
                      "1 - Create Company \n" +
                      "2 - Show All Company \n" +
                      "3 - Delete Company \n" +
                      "4 - Get Company's Demaprtments \n" +


                      "-- Department--\n" +
                      "5 - Create Department \n" +
                      "6 - Show All Departments \n" +
                      "7 - Delete Department \n" +
                      "8 - Get Department's Employee \n" +
                      "9 - Add Employee \n" +


                      "-- Employee--\n" +
                      "10 - Create Employee \n" +
                      
                      "11 - Show All Employee \n" +
                      "12 - Change Employee's Department \n "+
                      " 13 - Delete Employee \n "+
                      "0 - Quit \n"+
                     "----------------------------------");
    string? option = Console.ReadLine();
    int optionNumber;
    bool isInt = int.TryParse(option, out optionNumber);
    if(isInt)
    {
        if(optionNumber>=0 && optionNumber<=15)
        {
            switch(optionNumber)
            {
                case (int)Menu.CreateCompany:
                    try
                    {
                        Console.WriteLine(  "Enter company name:");
                        string? compnanyName = Console.ReadLine();
                        companyService.Create(compnanyName);
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Company was successfully created");
                        Console.WriteLine("----------------------");

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.CreateCompany;
                    }
                    break;
                
                case (int)Menu.ShowAllCompany:
                    try
                    {
                        companyService.ShowAllCompanies();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.ShowAllCompany;

                    }
                    break;
                case (int)Menu.DeleteCompany:
                    try
                    {
                        Console.WriteLine( "Enter Company's ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        companyService.Delete(id);
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Company was successfully deleted");
                        Console.WriteLine("----------------------");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.DeleteCompany;
                    }
                    break;
                case (int)Menu.GetCompanyDemaprtments:
                    try
                    {
                        Console.WriteLine(  "Enter Company id:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        companyService.GetCompanyIncluded(id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.GetCompanyDemaprtments;
                    }
                    break;
                case (int)Menu.CreateDepartment:
                    try
                    {
                        Console.WriteLine("Enter Department name :");
                        string? name = Console.ReadLine();
                        Console.WriteLine("Enter Company ID : ");
                        int companyId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Employee Limit :");
                        int employeeLimit = Convert.ToInt32(Console.ReadLine());
                        departmentService.CreateDepartment(name, companyId, employeeLimit);
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Department was successfully created");
                        Console.WriteLine("----------------------");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.CreateDepartment;

                    }
                    break;
                case (int)Menu.ShowAllDepartments:
                    try
                    {
                        departmentService.ShowAllDepartments();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.ShowAllDepartments;

                    }
                    break;
                case (int)Menu.DeleteDepartment:
                    try
                    {
                        Console.WriteLine(  "Enter Department ID :");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Department was successfully deleted");
                        Console.WriteLine("----------------------");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.DeleteDepartment;

                    }
                    break;
                case (int)Menu.GetDepartmentsEmployees:
                    try
                    {
                        Console.WriteLine("Enter Department ID :");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        departmentService.GetDepartmentEmployees(departmentId);
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.GetDepartmentsEmployees;

                    }
                    break;
                case (int)Menu.GetDepartmentById:
                    try
                    {
                        Console.WriteLine(  "Enter Department ID :");
                        int departmentId = Convert.ToInt32(Console.ReadLine()) ;
                        departmentService.GetDepartmentById(departmentId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.GetDepartmentById;

                    }
                    break;
                case (int)Menu.UpdateDepartment:
                    try
                    {
                        Console.WriteLine(  "Enter Department Id :");
                        int departmentId = Convert.ToInt32(Console.ReadLine()) ;
                        Console.WriteLine(  "Enter Department's new name :");
                        string newName = Console.ReadLine();
                        Console.WriteLine(  "Enter Department's new employee limit :");
                        int newEmployeeLimit = Convert.ToInt32(Console.ReadLine());
                        departmentService.UpdateDepartment(departmentId, newName, newEmployeeLimit);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.UpdateDepartment;

                    }
                    break;
                case (int)Menu.AddEmployee:
                    try
                    {
                        Console.WriteLine("Enter Employee name :");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Employee surname :");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Enter Employee salary :");
                        int salary = Convert.ToInt32(Console.ReadLine());
                        
                        Console.WriteLine(" Enter department id :");
                        int departmentId = Convert.ToInt32(Console.ReadLine());

                        Employee employee = new(name ,surname,salary,departmentId);
                        departmentService.AddEmployee(employee, departmentId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.AddEmployee;

                    }
                    break;
                case (int)Menu.CreateEmployee:
                    try
                    {
                        Console.WriteLine("Enter Employee name :");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Employee surname :");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Enter Employee salary :");
                        int salary = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Employee department Id :");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        employeeService.CreateEmployee(name, surname, salary, departmentId);
                        Console.WriteLine("----------------------");
                        Console.WriteLine("Employee was successfully created");
                        Console.WriteLine("----------------------");



                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.CreateEmployee;

                    }
                    break;
                case (int)Menu.ShowAllEmployee:
                    try
                    {
                        employeeService.ShowAllEmployees();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("----------------------");
                        goto case (int)Menu.ShowAllEmployee;

                    }
                    break;
                
            }
        }
    }


}

