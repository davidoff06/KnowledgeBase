using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL.EF
{
    public class KnowledgeAuditContext : DbContext
    {
        public KnowledgeAuditContext() : base("KnowledgeAuditConnection")
        {}

        static KnowledgeAuditContext()
        {
            Database.SetInitializer<KnowledgeAuditContext>(new KnowledgeAuditInitializer());
        }

        public DbSet<DBEmployee> Employees { get; set; }
        public DbSet<DBSkill> Skills { get; set; }
        public DbSet<DBEmployeeSkill> EmployeeSkills { get; set; }
    }
}
