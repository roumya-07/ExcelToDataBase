using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ExcelToDataBase.Models;
using Dapper;

namespace ExcelToDataBase.Repository
{
    public class EmployeeRepo: DapperContext, IEmployeeRepo
    {
        public EmployeeRepo(IConfiguration configuration) : base(configuration)
        {

        }

        public void AddEmployee(List<Employee> employees)
        {
            try
            {
                DataTable dtMember = new DataTable();
                dtMember.Columns.Add("Id");
                dtMember.Columns.Add("Name");
                dtMember.Columns.Add("Email");
                dtMember.Columns.Add("Mobile");
                dtMember.Columns.Add("Specialization");
                if (employees != null && employees.Count > 0)
                {
                    foreach (var items in employees)
                    {
                        DataRow dr = dtMember.NewRow();
                        dr["Id"] = items.Id;
                        dr["Name"] = items.Name;
                        dr["Email"] = items.Email;
                        dr["Mobile"] = items.Mobile;
                        dr["Specialization"] = items.Specialization;
                        dtMember.Rows.Add(dr);
                    }
                }
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ParLessonType", dtMember, dbType: DbType.Object);
                param.Add("@Action", "Insert");
                cn.Execute("InsertEmp_1", param, commandType: CommandType.StoredProcedure);
                cn.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            
        }

        public async Task<List<EmployeeDetails>> Get()
        {
            List<EmployeeDetails> EmpList = null;
            try
            {
                using (var cn = CreateConnection())
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    DynamicParameters Param = new DynamicParameters();
                    Param.Add("@Action", "SelectAll");
                    var result = await cn.QueryAsync<EmployeeDetails>("InsertEmp_1", Param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return EmpList;
        }
    }
}
