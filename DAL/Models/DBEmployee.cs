using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DAL.Models
{
    [Table("Employees")]
    public class DBEmployee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100), Required]
        public string FullName { get; set; }
        [MaxLength(100), Required]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Position { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public virtual ICollection<DBEmployeeSkill> EmployeeSkills { get; set; }
    }
}
