using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTTDATA_Web.Controllers;
using NTTDATA_Web.Models;
using System.Threading.Tasks;
using NTTDATA_Web;
using System.Net.Http;

namespace NTTDATA_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateEmployee()
        {
            EmployeesController employeesController = new EmployeesController();
            Employee employee = new Employee();
            employee.FirstName = "Kevin";
            employee.LastName = "Peter";
            employee.Designation = "Associate";
            employee.Salary = 100000;

            employee.Created_Time_Stamp = DateTime.Now;
            employee.Updated_Time_Stamp = DateTime.Now;

            string requestUrl = "Employees/PostEmployee/";

            using (var client = new ApiClient(requestUrl, "POST"))
            {
                Task.Run(async () =>
                {
                    await client.PostAsJsonAsync(requestUrl, employee);
                });
            }
        }
    }
}
