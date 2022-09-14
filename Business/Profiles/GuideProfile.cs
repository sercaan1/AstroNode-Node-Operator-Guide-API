using AutoMapper;
using Dtos.Guides;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class GuideProfile : Profile
    {
        public GuideProfile()
        {
            CreateMap<GuideCreateDto, Guide>();
            CreateMap<GuideUpdateDto, Guide>();
            CreateMap<Guide, GuideDto>();
        }
    }
}
