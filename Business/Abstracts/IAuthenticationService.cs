using Core.Utilities.Abstracts;
using Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthenticationService
    {
        Task<IDataResult<Object>> LoginAsync(LoginDto loginDto);
    }
}
