using System;
using System.Linq;
using DAL.Interfaces;
using DAL.EF;
using DAL.Models;
using System.Data.Entity.Infrastructure;

namespace DAL.Repos
{
    public class UnitOfWork: IUnitOfWork, IDisposable 
    {
        #region repos initialization
        private KnowledgeAuditContext db = new KnowledgeAuditContext();

        private EmployeeRepo employeeRepo;
        private SkillRepo skillRepo;
        private EmployeeSkillRepo employeeSkillRepo;

        public EmployeeRepo Employees
        {
            get
            {
                if (employeeRepo == null)
                    employeeRepo = new EmployeeRepo(db);
                return employeeRepo;
            }
        }

        public SkillRepo Skills
        {
            get
            {
                if (skillRepo == null)
                    skillRepo = new SkillRepo(db);
                return skillRepo;
            }
        }

        public EmployeeSkillRepo EmployeeSkills
        {
            get
            {
                if (employeeSkillRepo == null)
                    employeeSkillRepo = new EmployeeSkillRepo(db);
                return employeeSkillRepo;
            }
        }

        #endregion

        public void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Thrown when there is a concurrency errors
                //If Entries propery is null, no records were modified
                //entities in Entries threw error due to timestamp/conncurrency
                //for now, just rethrow the exception
                throw;
            }
            catch (DbUpdateException ex)
            {
                //Thrown when database update fails
                //Examine the inner execption(s) for additional 
                //details and affected objects
                //for now, just rethrow the exception
                throw;
            }
            catch (CommitFailedException ex)
            {
                //handle transaction failures here
                //for now, just rethrow the exception
                throw;
            }
            catch (Exception ex)
            {
                //some other exception happened and should be handled
                throw;
            }
        }

        #region IDisposable

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
