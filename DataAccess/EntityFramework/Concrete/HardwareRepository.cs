using Core.DataAccess.Concrete;
using DataAccess.EntityFramework.Abstracts;
using DataAccess.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Concrete
{
    public class HardwareRepository : GenericRepository<Hardware, AppDbContext>, IHardwareRepository
    {
        public HardwareRepository(AppDbContext context) : base(context)
        {

        }
    }
}
