using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.EntityFramework.Abstracts;
using Dtos.Nodes;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NodeManager : INodeService
    {
        private readonly INodeRepository _nodeRepository;
        private readonly IMapper _mapper;
        private readonly IHardwareRepository _hardwareRepository;
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IReviewRepository _reviewRepository;

        public NodeManager(INodeRepository nodeRepository, IMapper mapper, IHardwareRepository hardwareRepository, ISocialMediaRepository socialMediaRepository, IReviewRepository reviewRepository)
        {
            _nodeRepository = nodeRepository;
            _mapper = mapper;
            _hardwareRepository = hardwareRepository;
            _socialMediaRepository = socialMediaRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<IDataResult<NodeDto>> AddAsync(NodeCreateDto entity)
        {
            if (await _nodeRepository.AnyAsync(x => x.Name == entity.Name))
            {
                return new ErrorDataResult<NodeDto>(Messages.NodeAlreadyExist);
            }

            var node = await _nodeRepository.AddAsync(_mapper.Map<Node>(entity));

            if (node is null)
                return new ErrorDataResult<NodeDto>(Messages.AddFail);

            return new SuccessDataResult<NodeDto>(_mapper.Map<NodeDto>(node), Messages.AddSuccessfully);
        }

        public async Task<IDataResult<List<NodeListDto>>> GetAllAsync()
        {
            var nodes = await _nodeRepository.GetAllAsync();

            return new SuccessDataResult<List<NodeListDto>>(_mapper.Map<List<NodeListDto>>(nodes), Messages.ListedSuccessfully);
        }

        public async Task<IDataResult<NodeDto>> GetById(Guid id)
        {
            var node = await _nodeRepository.GetByIdAsync(id);

            if (node is null)
                return new ErrorDataResult<NodeDto>(Messages.NotFound);

            return new SuccessDataResult<NodeDto>(_mapper.Map<NodeDto>(node), Messages.FoundSuccessfully);
        }
    }
}
