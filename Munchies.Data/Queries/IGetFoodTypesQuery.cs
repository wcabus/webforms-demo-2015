﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchies.Data.Queries
{
    public interface IGetFoodTypesQuery : IQuery
    {
        IEnumerable<FoodType> Execute();
        Task<IEnumerable<FoodType>> ExecuteAsync();
    }
}
