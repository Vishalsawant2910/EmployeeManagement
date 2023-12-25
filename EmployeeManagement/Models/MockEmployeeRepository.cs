using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList= new List<Employee>()
            {  
                    new Employee(){Id=101, Name="Ethan Hunt", Department="Agent",Email="ethanhunt@agent.com"},
                    new Employee(){Id=102, Name="John Wick", Department="Killer",Email="johnwick@killer.com"},
                    new Employee(){Id=103, Name="Tony Stark", Department="Avenger",Email="tonystark@avenger.com"}

            };

        }

		public Employee Add(Employee employee)
		{
            employee.Id=_employeeList.Max(x => x.Id)+1;
			_employeeList.Add(employee);
            return employee;
		}

		public Employee Delete(int id)
		{
			Employee employee = _employeeList.FirstOrDefault(e  => e.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee); 
            }
            return employee;
		}

		public IEnumerable<Employee> GetAllEmployee()
		{
            return _employeeList;
		}

		public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id ==id);
        }

		public Employee Update(Employee employeeChanges)
		{
			Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
			if (employee != null)
			{
				employee.Name = employeeChanges.Name;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
			}
			return employee;
		}
	}
}
