using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using KnowledgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace KnowledgeAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private IEmployeeService employeeService = new EmployeeService();

        // GET: api/Employees
        public IEnumerable<EmployeeDTO> Get()
        {
            var employees = employeeService.Get();
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);
        }

        // GET: api/Employees/5
        [ResponseType(typeof(EmployeeDTO))]
        public IHttpActionResult Get(int id)
        {
            Employee emp;
            try
            {
                emp = employeeService.GetOne(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Employee, EmployeeDTO>(emp));
            //new EmployeeDTO { Email = emp.Email, FullName = emp.FullName, Id = emp.Id, Position = emp.Position, StartDate = emp.StartDate};
        }

        // POST: api/Employees
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Employee emp = Mapper.Map<EmployeeDTO, Employee>(employee);
                employeeService.Add(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtRoute("DefaultApi", new { id = employee.Id}, employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                employeeService.Update(Mapper.Map<EmployeeDTO, Employee>(employee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id, EmployeeDTO employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                employeeService.Delete(Mapper.Map<EmployeeDTO,Employee>(employee));
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
