using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using NTTDATA_Web.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NTTDATA_Web.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public async System.Threading.Tasks.Task<ActionResult> Dashboard()
        {
            string requestUrl = "Employees/GetEmployees/";
            List<Employee> lstEmployee = new List<Employee>();

            using (var client = new ApiClient(requestUrl, "GET"))
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(requestUrl);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var EmpResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    lstEmployee = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);
                }
            }

            lstEmployee = lstEmployee.OrderByDescending(a => a.Updated_Time_Stamp).ToList();

            return View(lstEmployee);
        }

        // GET: Employees/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int? id)
        {
            int empCode = id ?? 0;
            if (empCode > 0)
            {
                Employee employee = new Employee();
                string requestUrl = "Employees/GetEmployee/" + empCode;
                using (var client = new ApiClient(requestUrl, "GET"))
                {
                    HttpResponseMessage httpResponseMessage = await client.GetAsync(requestUrl);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var EmpResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        employee = JsonConvert.DeserializeObject<Employee>(EmpResponse);
                        return View(employee);
                    }
                }

            }
            return HttpNotFound();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Created_Time_Stamp = DateTime.Now;
                employee.Updated_Time_Stamp = DateTime.Now;

                string requestUrl = "Employees/PostEmployee/";

                using (var client = new ApiClient(requestUrl, "POST"))
                {
                    HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(requestUrl, employee);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View(employee);
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(int? id)
        {
            int empCode = id ?? 0;
            if (empCode > 0)
            {
                Employee employee = new Employee();
                string requestUrl = "Employees/GetEmployee/" + empCode;
                using (var client = new ApiClient(requestUrl, "GET"))
                {
                    HttpResponseMessage httpResponseMessage = await client.GetAsync(requestUrl);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var EmpResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        employee = JsonConvert.DeserializeObject<Employee>(EmpResponse);
                        return View(employee);
                    }
                }

            }

            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Updated_Time_Stamp = DateTime.Now;
                string requestUrl = "Employees/PutEmployee/";

                using (var client = new ApiClient(requestUrl, "POST"))
                {
                    HttpResponseMessage httpResponseMessage = await client.PutAsJsonAsync(requestUrl, employee);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Dashboard");
                    }
                }
                return RedirectToAction("Dashboard");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> Delete(int? id)
        {
            int empCode = id ?? 0;
            if (empCode > 0)
            {
                Employee employee = new Employee();
                string requestUrl = "Employees/GetEmployee/" + empCode;
                using (var client = new ApiClient(requestUrl, "GET"))
                {
                    HttpResponseMessage httpResponseMessage = await client.GetAsync(requestUrl);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var EmpResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        employee = JsonConvert.DeserializeObject<Employee>(EmpResponse);
                        return View(employee);
                    }
                }

            }
            return HttpNotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> DeleteConfirmed(int? id)
        {

            int empCode = id ?? 0;
            if (empCode > 0)
            {
                Employee employee = new Employee();
                string requestUrl = "Employees/DeleteEmployee/" + empCode;
                using (var client = new ApiClient(requestUrl, "GET"))
                {
                    HttpResponseMessage httpResponseMessage = await client.DeleteAsync(requestUrl);

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        var EmpResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        employee = JsonConvert.DeserializeObject<Employee>(EmpResponse);
                    }
                }

            }
            return RedirectToAction("Dashboard");
        }
    }
}
