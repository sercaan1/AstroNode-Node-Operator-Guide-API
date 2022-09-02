using Core.Utilities.Abstracts;
using Dtos.SocialMedias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISocialMediaService
    {
        Task<IDataResult<SocialMediaDto>> AddAsync(SocialMediaCreateDto entity);
    }
}
