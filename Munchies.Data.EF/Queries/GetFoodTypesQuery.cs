using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Munchies.Data;
using Munchies.Data.Queries;

namespace Munchies.Data.EF.Queries
{
    public class GetFoodTypesQuery : IGetFoodTypesQuery
    {
        private readonly MunchiesDbContext _context;

        public GetFoodTypesQuery(MunchiesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FoodType> Execute()
        {
            return _context.FoodTypes.OrderBy(f => f.Name).ToList();
        }

        public async Task<IEnumerable<FoodType>> ExecuteAsync()
        {
            return await _context.FoodTypes.OrderBy(f => f.Name).ToListAsync();
        }
    }
}
