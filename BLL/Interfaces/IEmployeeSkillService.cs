using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeSkillService
    {
        IEnumerable<EmployeeSkill> Get();
        EmployeeSkill GetOne(int? id);
        void Add(EmployeeSkill entity);
        //void AddRange(IList<Employee> entities);
        void Delete(EmployeeSkill entity);
        void Update(EmployeeSkill entity);
        void Dispose();

    }
}
