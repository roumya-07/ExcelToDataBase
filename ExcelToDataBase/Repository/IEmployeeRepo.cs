using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelToDataBase.Models;

namespace ExcelToDataBase.Repository
{
   public interface IEmployeeRepo
    {
        Task<List<EmployeeDetails>> Get();
        void AddEmployee(List<Employee> employees);
    }
}
