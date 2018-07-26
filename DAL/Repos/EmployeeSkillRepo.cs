using DAL.Models;
using DAL.EF;

namespace DAL.Repos
{
    public class EmployeeSkillRepo : BaseRepo<DBEmployeeSkill>
    {
        public EmployeeSkillRepo(KnowledgeAuditContext db) : base(db)
        {
            Table = Context.EmployeeSkills;
        }
    }
}
