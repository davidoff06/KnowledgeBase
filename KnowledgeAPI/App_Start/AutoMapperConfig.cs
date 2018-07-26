using AutoMapper;
using BLL.Models;
using KnowledgeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeAPI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Employee, EmployeeDTO>(); //from Employee - source to EmployeeDTO - destination
                    cfg.CreateMap<EmployeeDTO, Employee>()
                        .ForMember(dest => dest.EmployeeSkills, opt => opt.Ignore());

                    cfg.CreateMap<Skill, SkillDTO>();
                    cfg.CreateMap<SkillDTO, Skill>()
                        .ForMember(dest => dest.EmployeeSkills, opt => opt.Ignore()); 

                    cfg.CreateMap<EmployeeSkill, EmployeeSkillDTO>()
                        .ForMember(d => d.EmployeeEmail, x => x.MapFrom(e => e.Employee.Email))
                        .ForMember(d => d.EmployeeFullName, x => x.MapFrom(e => e.Employee.FullName))
                        .ForMember(d => d.EmployeePosition, x => x.MapFrom(e => e.Employee.Position))
                        .ForMember(d => d.SkillGroup, x => x.MapFrom(e => e.Skill.SkillGroup))
                        .ForMember(d => d.SkillName, x => x.MapFrom(e => e.Skill.SkillName));
                    cfg.CreateMap<EmployeeSkillDTO, EmployeeSkill>()
                        .ForMember(dest => dest.Employee, opt => opt.Ignore())
                        .ForMember(dest => dest.Skill, opt => opt.Ignore());
                    
                });
        }
    }
}