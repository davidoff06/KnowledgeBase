using System.Linq;
using DAL.Models;
using DAL.Repos;

namespace DAL.Interfaces
{
    public interface IUnitOfWork 
    {
        EmployeeRepo Employees { get; }
        SkillRepo Skills { get; }
        EmployeeSkillRepo EmployeeSkills { get; }

        void SaveChanges();
        void Dispose();
    }

}
