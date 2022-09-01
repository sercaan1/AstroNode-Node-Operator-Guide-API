using Core.DataAccess.Abstracts;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Abstracts
{
    public interface IAdminRepository : IRepository<Admin>
    {
    }
}
