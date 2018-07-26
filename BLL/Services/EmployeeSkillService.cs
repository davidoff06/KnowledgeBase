using BLL.Models;
using BLL.Interfaces;
using DAL.Repos;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using System;
using AutoMapper;

namespace BLL.Services
{
    public class EmployeeSkillService : IEmployeeSkillService
    {
        private readonly IUnitOfWork DB = new UnitOfWork();

        public IEnumerable<EmployeeSkill> Get()
        {
            var dbEmplSk = DB.EmployeeSkills.Get();
            return Mapper.Map<IEnumerable<DBEmployeeSkill>, IEnumerable<EmployeeSkill>>(dbEmplSk);
        }

        public EmployeeSkill GetOne(int? id)
        {
            var dbEmplSk = DB.EmployeeSkills.GetOne(id);
            if (dbEmplSk == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            //return new EmployeeSkill { Email = dbEmplSk.Email, FullName = dbEmplSk.FullName, Id = dbEmplSk.Id, Position = dbEmplSk.Position, StartDate = dbEmplSk.StartDate };
            return Mapper.Map<DBEmployeeSkill, EmployeeSkill>(dbEmplSk);
        }

        public void Add(EmployeeSkill entity)
        {
            DBEmployeeSkill dbEmplSk =
                Mapper.Map<EmployeeSkill, DBEmployeeSkill>(entity);
            //new DBEmployeeSkill { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, StartDate = entity.StartDate, Position = entity.Position }; 
            DB.EmployeeSkills.Add(dbEmplSk);
            DB.SaveChanges();
        }

        public void Delete(EmployeeSkill entity)
        {
            DBEmployeeSkill dbEmplSk =
            //new DBEmployeeSkill { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, Position = entity.Position, StartDate = entity.StartDate };
            Mapper.Map<EmployeeSkill, DBEmployeeSkill>(entity);
            DB.EmployeeSkills.Delete(dbEmplSk);
            DB.SaveChanges();
        }

        public void Update(EmployeeSkill entity)
        {
            DBEmployeeSkill dbEmplSk =
                Mapper.Map<EmployeeSkill, DBEmployeeSkill>(entity);
            //new DBEmployeeSkill { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, Position = entity.Position, StartDate = entity.StartDate };
            DB.EmployeeSkills.Update(dbEmplSk);
            DB.SaveChanges();
        }

        public void Dispose()
        {
            DB.Dispose();
        }

    }
}
