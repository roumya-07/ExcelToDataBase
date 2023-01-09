using ExcelToDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelToDataBase.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDetails>> Get();
        void AddEmployee(List<Employee> employees);
    }
}
