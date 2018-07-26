using DAL.Models;
using DAL.EF;

namespace DAL.Repos
{
    public class EmployeeRepo : BaseRepo<DBEmployee>
    {
        public EmployeeRepo(KnowledgeAuditContext db) : base(db)
        {
            Table = Context.Employees;
        }
    }
}
