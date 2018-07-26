using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork DB = new UnitOfWork();

        public IEnumerable<Skill> Get()
        {
            var dbSkills = DB.Skills.Get();
            return Mapper.Map<IEnumerable<DBSkill>, IEnumerable<Skill>>(dbSkills);
        }

        public Skill GetOne(int? id)
        {
            var dbSkill = DB.Skills.GetOne(id);
            if (dbSkill == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            //return new Skill { Email = dbSkill.Email, FullName = dbSkill.FullName, Id = dbSkill.Id, Position = dbSkill.Position, StartDate = dbSkill.StartDate };
            return Mapper.Map<DBSkill, Skill>(dbSkill);
        }

        public void Add(Skill entity)
        {
            DBSkill dbSkill =
                Mapper.Map<Skill, DBSkill>(entity);
            //new DBSkill { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, StartDate = entity.StartDate, Position = entity.Position }; 
            DB.Skills.Add(dbSkill);
            DB.SaveChanges();
        }

        public void Delete(Skill entity)
        {
            DBSkill dbSkill =
            //new DBSkill { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, Position = entity.Position, StartDate = entity.StartDate };
            Mapper.Map<Skill, DBSkill>(entity);
            DB.Skills.Delete(dbSkill);
            DB.SaveChanges();
        }

        public void Update(Skill entity)
        {
            DBSkill dbSkill =
                Mapper.Map<Skill, DBSkill>(entity);
            //new DBSkill { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, Position = entity.Position, StartDate = entity.StartDate };
            DB.Skills.Update(dbSkill);
            DB.SaveChanges();
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
