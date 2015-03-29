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
    public class FindRestaurantQuery : IFindRestaurantQuery
    {
        private readonly MunchiesDbContext _context;

        public FindRestaurantQuery(MunchiesDbContext context)
        {
            _context = context;
        }

        private IQueryable<Restaurant> CreateQuery(string postalCode, int? foodTypeId)
        {
            var result = from restaurant in _context.Restaurants
                         where restaurant.DeliveryZones.Any(dz => dz.PostalCode == postalCode)
                         && (foodTypeId == null || restaurant.FoodTypes.Any(f => f.Id == foodTypeId))
                         select restaurant;

            return result.Include(r => r.DeliveryZones);
        }

        public IEnumerable<Restaurant> Execute(string postalCode, int? foodTypeId)
        {
            return CreateQuery(postalCode, foodTypeId).ToList();
        }

        public async Task<IEnumerable<Restaurant>> ExecuteAsync(string postalCode, int? foodTypeId)
        {
            return await CreateQuery(postalCode, foodTypeId).ToListAsync();
        }
    }
}
