using AutoMapper;
using Dtos.Nodes;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class NodeProfile : Profile
    {
        public NodeProfile()
        {
            CreateMap<NodeCreateDto, Node>();
            CreateMap<NodeUpdateDto, Node>();
            CreateMap<Node, NodeDto>();
            CreateMap<Node, NodeListDto>()
                .ForMember(x => x.ReviewRate, opt => opt.MapFrom(x => x.Review.Rate))
                .ForMember(x => x.ReviewDifficulty, opt => opt.MapFrom(x => x.Review.Difficulty));
        }
    }
}
