using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.EntityFramework.Abstracts;
using Dtos.Reviews;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReviewManager : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewManager(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<ReviewDto>> AddAsync(ReviewCreateDto entity)
        {
            var review = await _reviewRepository.AddAsync(_mapper.Map<Review>(entity));

            if (review is null)
                return new ErrorDataResult<ReviewDto>(Messages.AddFail);

            return new SuccessDataResult<ReviewDto>(_mapper.Map<ReviewDto>(review), Messages.AddSuccessfully);
        }
    }
}
