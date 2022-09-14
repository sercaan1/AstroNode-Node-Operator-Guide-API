using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.EntityFramework.Abstracts;
using Dtos.Guides;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GuideManager : IGuideService
    {
        private readonly IGuideRepository _guideRepository;
        private readonly IMapper _mapper;

        public GuideManager(IGuideRepository guideRepository, IMapper mapper)
        {
            _guideRepository = guideRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GuideDto>> AddAsync(GuideCreateDto guideCreateDto)
        {
            var guide = await _guideRepository.AddAsync(_mapper.Map<Guide>(guideCreateDto));

            if (guide is null)
                return new ErrorDataResult<GuideDto>(Messages.AddFail);

            return new SuccessDataResult<GuideDto>(_mapper.Map<GuideDto>(guide), Messages.AddSuccessfully);
        }
    }
}
