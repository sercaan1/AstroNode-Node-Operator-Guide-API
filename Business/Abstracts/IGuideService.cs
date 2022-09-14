using Core.Utilities.Abstracts;
using Dtos.Guides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IGuideService
    {
        Task<IDataResult<GuideDto>> AddAsync(GuideCreateDto entity);
    }
}
