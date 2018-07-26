using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> Get();
        Employee GetOne(int? id);
        void Add(Employee entity);
        //void AddRange(IList<Employee> entities);
        void Delete(Employee entity);
        void Update(Employee entity);
        void Dispose();
    }
}
