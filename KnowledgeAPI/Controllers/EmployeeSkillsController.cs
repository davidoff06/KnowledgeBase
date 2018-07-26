using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using KnowledgeAPI.Models;

namespace KnowledgeAPI.Controllers
{
    public class EmployeeSkillsController : ApiController
    {

        private IEmployeeSkillService emplSkillService = new EmployeeSkillService();

        // GET: api/EmployeeSkills
        public IEnumerable<EmployeeSkillDTO> Get()
        {
            var emplSkills = emplSkillService.Get();
            return Mapper.Map<IEnumerable<EmployeeSkill>, IEnumerable<EmployeeSkillDTO>>(emplSkills);
        }

        // GET: api/EmployeeSkills/5
        [ResponseType(typeof(EmployeeSkillDTO))]
        public IHttpActionResult Get(int id)
        {
            EmployeeSkill record;
            try
            {
                record = emplSkillService.GetOne(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<EmployeeSkill, EmployeeSkillDTO>(record));
            //new EmployeeSkillDTO { Email = record.Email, FullName = record.FullName, Id = record.Id, Position = record.Position, StartDate = record.StartDate};
        }

        // POST: api/EmployeeSkills
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(EmployeeSkillDTO emplSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                EmployeeSkill record = Mapper.Map<EmployeeSkillDTO, EmployeeSkill>(emplSkill);
                emplSkillService.Add(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtRoute("DefaultApi", new { id = emplSkill.Id }, emplSkill);
        }

        // PUT: api/EmployeeSkills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, EmployeeSkillDTO emplSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emplSkill.Id)
            {
                return BadRequest();
            }

            try
            {
                emplSkillService.Update(Mapper.Map<EmployeeSkillDTO, EmployeeSkill>(emplSkill));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/EmployeeSkills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id, EmployeeSkillDTO emplSkill)
        {
            if (id != emplSkill.Id)
            {
                return BadRequest();
            }

            try
            {
                emplSkillService.Delete(Mapper.Map<EmployeeSkillDTO, EmployeeSkill>(emplSkill));
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
