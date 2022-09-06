using AutoMapper;
using Dtos.SocialMedias;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<SocialMediaCreateDto, SocialMedia>();
            CreateMap<SocialMediaUpdateDto, SocialMedia>();
            CreateMap<SocialMedia, SocialMediaDto>();
        }
    }
}
