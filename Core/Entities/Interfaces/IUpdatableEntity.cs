﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Interfaces
{
    public interface IUpdatableEntity : IEntity, ICreatableEntity
    {
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
