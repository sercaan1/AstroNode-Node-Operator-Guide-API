using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Interfaces
{
    public interface IDeletableEntity : ICreatableEntity, IEntity, IUpdatableEntity
    {
        string DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
