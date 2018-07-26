using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL.EF
{
    class KnowledgeAuditInitializer : DropCreateDatabaseIfModelChanges<KnowledgeAuditContext>
    {
        protected override void Seed(KnowledgeAuditContext context)
        {
            var Skills = new List<DBSkill>()
            {
                new DBSkill{ SkillGroup = "Programming Languages", SkillName = "C#"},
                new DBSkill{ SkillGroup = "Programming Languages", SkillName = "Java"}
            };

            Skills.ForEach(x => context.Skills.Add(x));

            var Employees = new List<DBEmployee>()
            {
                new DBEmployee{ Email = "alex@gmail.com", FullName = "Alex D", Position = "SE", StartDate = DateTime.Parse("2018-01-01 00:00:00Z")},
                new DBEmployee{ Email = "kos@gmail.com", FullName = "Kostya R", Position = "SSE", StartDate = DateTime.Parse("2016-01-01 00:00:00Z")}
            };
            Employees.ForEach(x => context.Employees.Add(x));

            var EmployeeSkills = new List<DBEmployeeSkill>()
            {
                new DBEmployeeSkill{ Employee = Employees[0], Skill = Skills[0], Evaluation = "Novice", LastModifiedDate = DateTime.Now, LastUsedYear = 2015},
                new DBEmployeeSkill{ Employee = Employees[0], Skill = Skills[1], Evaluation = "Medium", LastModifiedDate = DateTime.Now, LastUsedYear = 2016},
                new DBEmployeeSkill{ Employee = Employees[1], Skill = Skills[0], Evaluation = "Advanced", LastModifiedDate = DateTime.Now, LastUsedYear = 2018},
                new DBEmployeeSkill{ Employee = Employees[1], Skill = Skills[1], Evaluation = "Expert", LastModifiedDate = DateTime.Now, LastUsedYear = 2018},
            };
            EmployeeSkills.ForEach(x => context.EmployeeSkills.Add(x));

            context.SaveChanges();
        }
    }
}
