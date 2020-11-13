﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bai29_10.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
