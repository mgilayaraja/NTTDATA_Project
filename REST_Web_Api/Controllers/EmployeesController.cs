using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using REST_Web_Api.Entity;

namespace REST_Web_Api.Controllers
{
    public class EmployeesController : ApiController
    {
        private NTTDATA_DBEntities db = new NTTDATA_DBEntities();
        [HttpGet]
        public IQueryable<Employee> GetEmployees()
        {
            return db.Employees;
        }

        [HttpGet]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.Employee_Code }, employee);
        }

        [HttpDelete]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}