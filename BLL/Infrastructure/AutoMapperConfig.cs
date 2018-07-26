using AutoMapper;
using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public static class AutoMapperConfig
    {
        public static void AutoMapperConfigInit()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DBEmployee, Employee>();
                //cfg.CreateMap<DBProduct, Product>().ForMember(d => d.SupplierId, x => x.MapFrom(c => c.Supplier.SupplierId));
                cfg.CreateMap<Employee, DBEmployee>();
                //.ForMember(dest => dest.EmployeeSkills, opt => opt.Ignore());

                cfg.CreateMap<DBSkill, Skill>();
                cfg.CreateMap<Skill, DBSkill>();

                cfg.CreateMap<DBEmployeeSkill, EmployeeSkill>();
                cfg.CreateMap<EmployeeSkill, DBEmployeeSkill>();

            }
            );

            Mapper.Configuration.CreateMapper();
        }

    }
}
