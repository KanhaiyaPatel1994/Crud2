using Crud2.DataContext;
using Crud2.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2.Repositories
{
    public class EmployeeRepository
    {
        private AppDataContext _context;
        public EmployeeRepository(AppDataContext appDataContext) 
        {
            _context = appDataContext;
        }

        public List<Dto.Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }   

        public Dto.Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Dto.Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Dto.Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
