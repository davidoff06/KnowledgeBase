using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class EmployeeSkill
    {
        public int Id { get; set; }
        public int? LastUsedYear { get; set; }
        public string Evaluation { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int SkillId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Skill Skill { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
