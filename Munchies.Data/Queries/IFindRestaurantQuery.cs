using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchies.Data.Queries
{
    public interface IFindRestaurantQuery : IQuery
    {
        IEnumerable<Restaurant> Execute(string postalCode, int? foodTypeId);

        Task<IEnumerable<Restaurant>> ExecuteAsync(string postalCode, int? foodTypeId);
    }
}
