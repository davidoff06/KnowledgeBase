using BLL.Models;
using BLL.Interfaces;
using DAL.Repos;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using System;
using AutoMapper;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork DB = new UnitOfWork();

        public IEnumerable<Employee> Get()
        {
            var dbEmployees = DB.Employees.Get();
            return Mapper.Map<IEnumerable<DBEmployee>, IEnumerable<Employee>>(dbEmployees);
        }

        public Employee GetOne(int? id)
        {
            var dbEmpl = DB.Employees.GetOne(id);
            if (dbEmpl == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            //return new Employee { Email = dbEmpl.Email, FullName = dbEmpl.FullName, Id = dbEmpl.Id, Position = dbEmpl.Position, StartDate = dbEmpl.StartDate };
            return Mapper.Map<DBEmployee, Employee>(dbEmpl);
        }

        public void Add(Employee entity)
        {
            DBEmployee dbEmpl = 
                Mapper.Map<Employee, DBEmployee>(entity);
                //new DBEmployee { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, StartDate = entity.StartDate, Position = entity.Position }; 
            DB.Employees.Add(dbEmpl);
            DB.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            DBEmployee dbEmpl =
            //new DBEmployee { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, Position = entity.Position, StartDate = entity.StartDate };
            Mapper.Map<Employee, DBEmployee>(entity);
            DB.Employees.Delete(dbEmpl);
            DB.SaveChanges();
        }

        public void Update(Employee entity)
        {
            DBEmployee dbEmpl =
                Mapper.Map<Employee, DBEmployee>(entity);
            //new DBEmployee { Email = entity.Email, FullName = entity.FullName, Id = entity.Id, Position = entity.Position, StartDate = entity.StartDate };
            DB.Employees.Update(dbEmpl);
            DB.SaveChanges();
        }

        public void Dispose()
        {
            DB.Dispose();
        }

    }
}
