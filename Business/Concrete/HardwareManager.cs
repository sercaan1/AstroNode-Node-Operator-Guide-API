using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.EntityFramework.Abstracts;
using Dtos.Hardwares;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HardwareManager : IHardwareService
    {
        private readonly IHardwareRepository _hardwareRepository;
        private readonly IMapper _mapper;

        public HardwareManager(IHardwareRepository hardwareRepository, IMapper mapper)
        {
            _hardwareRepository = hardwareRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<HardwareDto>> AddAsync(HardwareCreateDto entity)
        {
            var hardware = await _hardwareRepository.AddAsync(_mapper.Map<Hardware>(entity));

            if (hardware is null)
                return new ErrorDataResult<HardwareDto>(Messages.AddFail);

            return new SuccessDataResult<HardwareDto>(_mapper.Map<HardwareDto>(hardware), Messages.AddSuccessfully);
        }
    }
}
