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
using kirillov_chat_api_api_api.Models;
using kirillov_chat_api_api_api.Response;

namespace kirillov_chat_api_api_api.Controllers
{
    public class EmployeesController : ApiController
    {
        private kirillov_apichatEntities db = new kirillov_apichatEntities();

        // GET: api/Employees
        public IQueryable<Employee> GetEmployee()
        {
            return db.Employee;
        }

        [Route("api/Login")]
        [ResponseType(typeof(ResponseEmployee))]
        public IHttpActionResult Login([FromBody] Data data)
        {
            var user = db.Employee.ToList()
                .Where(i => i.username == data.username && i.password == data.password)
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new ResponseEmployee(user));
            }
        }

        public class Data
        {
            public string username { get; set; }
            public string password { get; set; }
        }
        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employee.Remove(employee);
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

        private bool EmployeeExists(int id)
        {
            return db.Employee.Count(e => e.id == id) > 0;
        }
    }
}