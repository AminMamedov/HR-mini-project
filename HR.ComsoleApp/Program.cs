using HR.Business.Services;
using HR.Business.Utilities.Exceptions;
using HR.Business.Utilities.Helpers;
using HR.Core.Entities;
using System.Threading.Channels;

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
Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine(@"
   _____   _  _     __  __  _         _   _____              _              _   
  / ____|_| || |_  |  \/  |(_)       (_) |  __ \            (_)            | |  
 | |    |_  __  _| | \  / | _  _ __   _  | |__) |_ __  ___   _   ___   ___ | |_ 
 | |     _| || |_  | |\/| || || '_ \ | | |  ___/| '__|/ _ \ | | / _ \ / __|| __|
 | |____|_  __  _| | |  | || || | | || | | |    | |  | (_) || ||  __/| (__ | |_ 
  \_____| |_||_|   |_|  |_||_||_| |_||_| |_|    |_|   \___/ | | \___| \___| \__|
                                                           _/ |                 
                                                          |__/                  
");
Console.ResetColor();
while (isContinue)
{

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Choose the option:");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine(
                      "-------------Company--------------\n" +
                      " 1 - Create Company \n" +
                      " 2 - Show All Company \n" +
                      " 3 - Deactivate Company \n" +
                      " 4 - Activate Company \n" +
                      " 5 - Delete Company \n" +
                      " 6 - Get Company's Demaprtments \n \n" +


                      "------------Department------------\n" +
                      " 7 - Create Department \n" +
                      " 8 - Show All Departments \n" +
                      " 9 - Deactivate Department \n" +
                      "10 - Activate Department \n" +
                      "11 - Delete Department \n" +
                      "12 - Get Department's Employee \n" +
                      "13 - Get Department by ID \n" +
                      "14 - Update Department \n" +
                      "15 - Add Employee \n \n" +

                      "-------------Employee------------\n" +
                      "16 - Create Employee \n" +
                      "17 - Show All Employee \n" +
                      "18 - Change Employee's Department \n" +
                      "19 - Deactivate Employee \n" +
                      "20 - Activate Employee \n" +
                      "21 - Delete Employee \n" +
                      "22 - Quit \n" +
                     "----------------------------------");
    Console.ResetColor();
    string? option = Console.ReadLine();
    int optionNumber;
    bool isInt = int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if (optionNumber >= 0 && optionNumber <= 25)
        {
            switch (optionNumber)
            {
                case (int)Menu.CreateCompany:
                    try
                    {
                        Console.WriteLine("Enter company name:");
                        string? compnanyName = Console.ReadLine();
                        companyService.Create(compnanyName);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Company was successfully created");
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.CreateCompany;
                    }
                    break;

                case (int)Menu.ShowAllCompany:

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (companyService.IsCompanyExist(true) == true)
                    {
                        companyService.ShowAllCompanies();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Process is successful");
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("There isn't any company created");
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                    }

                    break;
                case (int)Menu.DeactivateCompany:
                    try
                    {
                        if (companyService.IsCompanyExist(true) == true)
                        {
                            companyService.ShowAllCompanies();
                            Console.WriteLine("Enter Company's ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            companyService.Deactivate(id);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Company was successfully deactivated");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any created company");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }


                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.DeactivateCompany;
                    }
                    break;
                case (int)Menu.ActivateCompany:
                    try
                    {
                        if (companyService.IsCompanyExist(false) == true)
                        {
                            companyService.ShowDeactiveCompanies();
                            Console.WriteLine("Enter Company's ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            companyService.Activate(id);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Company was successfully activated");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any deactive company");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.ActivateCompany;

                    }
                    break;
                case (int)Menu.DeleteCompany:
                    try
                    {
                        if(companyService.IsCompanyExist(false) == true) 
                        {
                           
                        Console.ForegroundColor= ConsoleColor.Green;
                            companyService.ShowDeactiveCompanies();
                        Console.WriteLine(  "Enter Company id:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        companyService.DeleteCompany(id);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You should deactivate company to delete it.");
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.ActivateDepartment;
                    }
                    break;
                case (int)Menu.GetCompanyDemaprtments:
                    try
                    {
                        if (companyService.IsCompanyExist(true) == true)
                        {

                            companyService.ShowAllCompanies();
                            Console.WriteLine("Enter Company id:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (departmentService.IsDepartmentExist(true) == true)
                            {
                                companyService.GetCompanyDepartments(id);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine("Process is successfull");
                                Console.WriteLine("--------------------------------");
                                Console.ResetColor();


                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine("This company doesn't have any departments.");
                                Console.WriteLine("--------------------------------");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any compnay created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.GetCompanyDemaprtments;
                    }
                    break;
                case (int)Menu.CreateDepartment:
                    try
                    {
                        if (companyService.IsCompanyExist(true) == true)
                        {
                            Console.WriteLine("Enter Department name :");
                            string? name = Console.ReadLine();
                            Console.WriteLine("Enter Company ID : ");
                            companyService.ShowAllCompanies();
                            int companyId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Employee Limit :");
                            int employeeLimit = Convert.ToInt32(Console.ReadLine());
                            departmentService.CreateDepartment(name, companyId, employeeLimit);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Department was successfully created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();



                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any compnay created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.CreateDepartment;

                    }
                    break;
                case (int)Menu.ShowAllDepartments:
                    if (departmentService.IsDepartmentExist(true) == true)
                    {
                        departmentService.ShowAllDepartments();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Process id successful");
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("There isn't any department created");
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                    }
                    break;
                case (int)Menu.DeactivateDepartment:
                    try
                    {
                        if (departmentService.IsDepartmentExist(true) == true)
                        {
                            departmentService.ShowAllDepartments();
                            Console.WriteLine("Enter Department ID :");
                            int departmentId = Convert.ToInt32(Console.ReadLine());
                            departmentService.DeactiveDepartment(departmentId);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("----------------------");
                            Console.WriteLine("Department was successfully deactivated");
                            Console.WriteLine("----------------------");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any department created.");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.DeactivateDepartment;

                    }
                case (int)Menu.ActivateDepartment:
                    try
                    {
                        if(companyService.IsCompanyExist(true) == true)
                        {

                        if (departmentService.IsDepartmentExist(false) == true)
                        {
                            departmentService.ShowDeactiveDepartment();
                            Console.WriteLine("Enter Department ID :");
                            int departmentId = Convert.ToInt32(Console.ReadLine());
                            companyService.ShowAllCompanies();
                            Console.WriteLine(  "Enter new company ID:");
                            int newCompanyId = Convert.ToInt32(Console.ReadLine());
                            departmentService.ActivateDepartment(departmentId, newCompanyId);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("----------------------");
                            Console.WriteLine("Department was successfully activated");
                            Console.WriteLine("----------------------");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any deactive department .");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any active company.");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.ActivateDepartment;

                    }
                    break;
                    
                
                case (int)Menu.DeleteDepartment:
                    try
                    {
                        if(departmentService.IsDepartmentExist(false)== true)
                        {
                            Console.ForegroundColor= ConsoleColor.Yellow;
                            departmentService.ShowDeactiveDepartment();
                            Console.WriteLine( "Enter department id :" );
                            int departmentId = Convert.ToInt32(Console.ReadLine());
                            departmentService.DeleteDepartment(departmentId);


                        }
                        else
                        {
                            Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("You should deactivate department to delete.");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.DeleteDepartment;
                    }
                    break;
                case (int)Menu.GetDepartmentsEmployees:
                    try
                    {
                        if (companyService.IsCompanyExist(true) == true)
                        {

                            if (departmentService.IsDepartmentExist(true) == true)
                            {

                                departmentService.ShowAllDepartments();
                                Console.WriteLine("Enter Department ID :");
                                int departmentId = Convert.ToInt32(Console.ReadLine());
                                if (employeeService.IsEmployeeExist(true) == true)
                                {
                                    departmentService.GetDepartmentEmployees(departmentId);

                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("This department doesn't have employees.");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There doesn't any department exist.");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any company created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.GetDepartmentsEmployees;
                    }
                    break;
                case (int)Menu.GetDepartmentById:
                    try
                    {
                        if(departmentService.IsDepartmentExist(true) == true) 
                        {
                        Console.WriteLine("Enter Department ID :");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        departmentService.GetDepartmentById(departmentId);
                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any department created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.GetDepartmentById;

                    }
                    break;
                case (int)Menu.UpdateDepartment:
                    try
                    {
                        if(departmentService.IsDepartmentExist(true) == true)
                        {
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        departmentService.ShowAllDepartments();

                        Console.WriteLine("Enter Department Id :");
                        int departmentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Department's new name :");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Enter Department's new employee limit :");
                        int newEmployeeLimit = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();
                        departmentService.UpdateDepartment(departmentId, newName, newEmployeeLimit);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Department was successfully uptadet");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any department created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.UpdateDepartment;

                    }
                    break;
                case (int)Menu.AddEmployee:
                    try
                    {
                        if(departmentService.IsDepartmentExist(true) == true)
                        {

                        Console.WriteLine("Enter Employee name :");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Employee surname :");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Enter Employee salary :");
                        int salary = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(" Enter department id :");
                        departmentService.ShowAllDepartments();
                        int departmentId = Convert.ToInt32(Console.ReadLine());

                        Employee employee = new(name, surname, salary, departmentId);
                        departmentService.AddEmployee(employee, departmentId);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Employee was successfully added");
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any department created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.AddEmployee;


                    }
                    break;
                case (int)Menu.CreateEmployee:
                    try
                    {
                        if (departmentService.IsDepartmentExist(true) == true)
                        {
                            Console.WriteLine("Enter Employee name :");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Employee surname :");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Enter Employee salary :");
                            int salary = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Employee department Id :");
                            departmentService.ShowAllDepartments();
                            int departmentId = Convert.ToInt32(Console.ReadLine());
                            employeeService.CreateEmployee(name, surname, salary, departmentId);
                            Console.WriteLine("----------------------");
                            Console.WriteLine("Employee was successfully created");
                            Console.WriteLine("----------------------");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any department created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }



                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.CreateEmployee;
                    }
                    break;
                case (int)Menu.ShowAllEmployee:
                    if (employeeService.IsEmployeeExist(true) == true)
                    {
                        employeeService.ShowAllEmployees();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Process id successful");
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("There isn't any employee created");
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                    }
                    break;
                case (int)Menu.ChangeEmployeeDepartment:
                    try
                    {
                        if(employeeService.IsEmployeeExist(true) == true)
                        {

                        Console.ForegroundColor= ConsoleColor.Yellow;
                        employeeService.ShowAllEmployees();
                        Console.WriteLine("Enter Employee ID :");
                        int employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter New Department ID :");
                        int newDepartmentId = Convert.ToInt32(Console.ReadLine());
                        employeeService.ChangeEmployeeDepartment(employeeId, newDepartmentId);
                        Console.ResetColor ();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any employee created");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }

                    }
                    catch (Exception ex)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.ChangeEmployeeDepartment;
                    }
                    break;
                case (int)Menu.DeactivateEmployee:
                    try
                    {
                        if (employeeService.IsEmployeeExist(true) == true)
                        {

                            employeeService.ShowAllEmployees();
                            Console.WriteLine("Enter Employee ID :");
                            int employeeId = Convert.ToInt32(Console.ReadLine());
                            employeeService.DeactivateEmployee(employeeId);
                        }
                        else
                        {
                            Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any employee created.");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        goto case (int)Menu.DeactivateEmployee;
                    }
                    break;
                case (int)Menu.ActivateEmployee:
                    try
                    {
                        if (employeeService.IsEmployeeExist(false) == true)
                        {

                            employeeService.ShowDeactiveEmployee();
                            Console.WriteLine("Enter Employee ID :");
                            int employeeId = Convert.ToInt32(Console.ReadLine());
                            employeeService.ActivateEmployee(employeeId);
                        }
                        else
                        {
                            Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("There isn't any deactive employee .");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.ActivateEmployee;

                    }
                    break;
                case (int)Menu.DeleteEmployee:
                    try
                    {
                        if (employeeService.IsEmployeeExist(false) == true)
                        {

                            employeeService.ShowDeactiveEmployee();
                            Console.WriteLine("Enter Employee ID :");
                            int employeeId = Convert.ToInt32(Console.ReadLine());
                            employeeService.DeleteEmployee(employeeId);
                        }
                        else
                        {
                            Console.ResetColor(); Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("You should deactivate employee to delete.");
                            Console.WriteLine("--------------------------------");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("--------------------------------");
                        Console.ResetColor();
                        goto case (int)Menu.DeleteEmployee;
                    }
                    break;
                case (int)Menu.Quit:
                    isContinue = false;
                    break;
            }
        }
    }


}

