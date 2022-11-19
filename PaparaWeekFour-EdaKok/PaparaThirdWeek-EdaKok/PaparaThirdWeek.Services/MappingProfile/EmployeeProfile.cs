using AutoMapper;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Services.MappingProfile
{
   public class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
         //   CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
