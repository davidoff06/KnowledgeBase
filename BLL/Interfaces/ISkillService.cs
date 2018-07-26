using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<Skill> Get();
        Skill GetOne(int? id);
        void Add(Skill entity);
        void Delete(Skill entity);
        void Update(Skill entity);
        void Dispose();
    }
}
