using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{

    public class RangeUntilCurrentYearAttribute : RangeAttribute
    {
        public RangeUntilCurrentYearAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }

    [Table("EmployeeSkills")]
    public class DBEmployeeSkill
    {
        [Key]
        public int Id { get; set; }
        [RangeUntilCurrentYearAttribute(1970)]
        public int LastUsedYear { get; set; }
        [MaxLength(100), Required]
        public string Evaluation { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }

        public int SkillId { get; set; }
        public virtual DBSkill Skill { get; set; }

        public int EmployeeId { get; set; }
        public virtual DBEmployee Employee { get; set; }
    }
}
