using Microsoft.EntityFrameworkCore;
using NetCore_Employee_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Employee_API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await employeeContext.Employees.AddAsync(employee);
            _ = await employeeContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmployee(int employeeId)
        {
            var result = await employeeContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            if(result != null)
            {
                employeeContext.Employees.Remove(result);
                await employeeContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await employeeContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await employeeContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await employeeContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (result != null)
            {
                result.Name = employee.Name;
                result.Designation = employee.Designation;
                result.Address = employee.Address;
                result.Salary = employee.Salary;
                result.DateJoin = employee.DateJoin;

                await employeeContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
