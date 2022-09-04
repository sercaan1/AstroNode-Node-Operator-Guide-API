using Core.Utilities.Abstracts;
using Dtos.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IReviewService
    {
        Task<IDataResult<ReviewDto>> AddAsync(ReviewCreateDto entity);
    }
}
