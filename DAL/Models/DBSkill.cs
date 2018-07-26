using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Skills")]
    public class DBSkill
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public string SkillName { get; set; }
        [MaxLength(100)]
        public string SkillGroup { get; set; }

        public virtual ICollection<DBEmployeeSkill> EmployeeSkills { get; set; }
    }
}
