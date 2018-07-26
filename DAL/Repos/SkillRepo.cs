using DAL.Models;
using DAL.EF;

namespace DAL.Repos
{
    public class SkillRepo : BaseRepo<DBSkill>
    {
        public SkillRepo(KnowledgeAuditContext db): base(db)
        {
            Table = Context.Skills;
        }
    }
}
