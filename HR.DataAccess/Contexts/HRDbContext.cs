using HR.Core.Entities;
namespace HR.DataAccess.Contexts
{
    public static class HRDbContext
    {
        public static List<Company> Companies {  get; set; }
        public static List<Department> Departments {  get; set; }
        public static List<Employee> Employees {  get; set; }

    }
}
