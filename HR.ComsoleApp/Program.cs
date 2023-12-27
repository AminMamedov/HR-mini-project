using HR.Business.Services;
using HR.Business.Utilities.Helpers;

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
                      "8 - Get Department's Student \n" +


                      "-- Employee--\n" +
                      "9 - Create Employee \n" +
                      "10 - Show All Employee \n" +
                      "11 - Change Employee's Department \n " +
                     "12 - Delete Employee \n " +
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
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.GetCompanyDemaprtments;

                    }
                    break;
            }
        }
    }


}

