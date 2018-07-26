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
    public class SkillsController : ApiController
    {
        private ISkillService skillService = new SkillService();

        // GET: api/Skills
        public IEnumerable<SkillDTO> Get()
        {
            var skills = skillService.Get();
            return Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDTO>>(skills);
        }

        // GET: api/Skills/5
        [ResponseType(typeof(SkillDTO))]
        public IHttpActionResult Get(int id)
        {
            Skill record;
            try
            {
                record = skillService.GetOne(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Skill, SkillDTO>(record));
            //new SkillDTO { Email = record.Email, FullName = record.FullName, Id = record.Id, Position = record.Position, StartDate = record.StartDate};
        }

        // POST: api/Skills
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(SkillDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Skill record = Mapper.Map<SkillDTO, Skill>(employee);
                skillService.Add(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // PUT: api/Skills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, SkillDTO employee)
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
                skillService.Update(Mapper.Map<SkillDTO, Skill>(employee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Skills/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id, SkillDTO employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                skillService.Delete(Mapper.Map<SkillDTO, Skill>(employee));
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
