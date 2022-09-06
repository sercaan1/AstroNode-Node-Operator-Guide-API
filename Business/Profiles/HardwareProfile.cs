using AutoMapper;
using Dtos.Hardwares;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class HardwareProfile : Profile
    {
        public HardwareProfile()
        {
            CreateMap<HardwareCreateDto, Hardware>();
            CreateMap<HardwareUpdateDto, Hardware>();
            CreateMap<Hardware, HardwareDto>();
        }
    }
}
