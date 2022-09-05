using Core.Utilities.Abstracts;
using Dtos.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface INodeService
    {
        Task<IDataResult<List<NodeListDto>>> GetAllAsync();
        Task<IDataResult<NodeDto>> AddAsync(NodeCreateDto entity);
        Task<IDataResult<NodeDto>> GetById(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
