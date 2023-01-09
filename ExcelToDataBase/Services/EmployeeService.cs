using ExcelToDataBase.Models;
using ExcelToDataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelToDataBase.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo ;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo ;
        }
        public void AddEmployee(List<Employee> employees)
        {
            _employeeRepo.AddEmployee(employees);
        }

        public async Task<List<EmployeeDetails>> Get()
        {
            return await _employeeRepo.Get();
        }
    }
}
