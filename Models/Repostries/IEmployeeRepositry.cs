using Dependency_Injection.Models.Interfaces;

namespace Dependency_Injection.Models.Repostries
{
    public class IEmployeeRepositry : IEmployee
    {
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employeeList = new List<Employee>();
            for(int i = 0; i < 10; i++)
            {
                Employee employee = new Employee();
                employee.id = i;
                employee.Name = "iqra";
                employeeList.Add(employee);
            }
            return employeeList;
        }
    }
}
