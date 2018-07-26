using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeAPI.Models
{
    public class EmployeeSkillDTO
    {
        public int Id { get; set; }
        public int? LastUsedYear { get; set; }
        public string Evaluation { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillGroup { get; set; }

        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePosition { get; set; }
    }
}