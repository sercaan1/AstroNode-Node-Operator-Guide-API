using Core.Utilities.Abstracts;
using Dtos.Hardwares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IHardwareService
    {
        Task<IDataResult<HardwareDto>> AddAsync(HardwareCreateDto entity);
    }
}
