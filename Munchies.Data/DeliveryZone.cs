namespace Munchies.Data
{
    public class DeliveryZone
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }
        
        public string PostalCode { get; set; }
        
        /// <summary>
        /// The distance in kilometers from the center of the city defined by <see cref="PostalCode"/> to the <see cref="Restaurant"/>.
        /// </summary>
        public float Distance { get; set; }
    }
}