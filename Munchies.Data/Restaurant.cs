using System.Collections.Generic;

namespace Munchies.Data
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Website { get; set; }
        public string Telephone { get; set; }
        
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<DeliveryZone> DeliveryZones { get; set; }

        /// <summary>
        /// A list of <see cref="FoodType"/> being served by this restaurant.
        /// </summary>
        public virtual ICollection<FoodType> FoodTypes { get; set; }
    }
}
