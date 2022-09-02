using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.EntityFramework.Abstracts;
using Dtos.SocialMedias;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;

        public SocialMediaManager(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<SocialMediaDto>> AddAsync(SocialMediaCreateDto entity)
        {
            var socialMedia = await _socialMediaRepository.AddAsync(_mapper.Map<SocialMedia>(entity));

            if (socialMedia is null)
                return new ErrorDataResult<SocialMediaDto>(Messages.AddFail);

            return new SuccessDataResult<SocialMediaDto>(_mapper.Map<SocialMediaDto>(socialMedia), Messages.AddSuccessfully);
        }
    }
}
