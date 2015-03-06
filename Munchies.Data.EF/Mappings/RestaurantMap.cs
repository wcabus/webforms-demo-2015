using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Munchies.Data.EF.Mappings
{
    internal class RestaurantMap : EntityTypeConfiguration<Restaurant>
    {
        public RestaurantMap()
        {
            ToTable("Restaurants");

            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.Name).HasMaxLength(128).IsUnicode().IsVariableLength().IsRequired();
            Property(r => r.Street).HasMaxLength(128).IsUnicode().IsVariableLength().IsRequired();
            Property(r => r.StreetNumber).HasMaxLength(16).IsUnicode(false).IsVariableLength().IsRequired();
            Property(r => r.PostalCode).HasMaxLength(32).IsUnicode(false).IsVariableLength().IsRequired();
            Property(r => r.City).HasMaxLength(128).IsUnicode().IsVariableLength().IsRequired();
            Property(r => r.Country).HasMaxLength(128).IsUnicode().IsVariableLength().IsRequired();
            Property(r => r.Telephone).HasMaxLength(32).IsUnicode(false).IsVariableLength().IsRequired();
            Property(r => r.Website).IsUnicode().IsVariableLength();

            HasMany(r => r.DeliveryZones).WithRequired(dz => dz.Restaurant).HasForeignKey(dz => dz.RestaurantId);
            HasMany(r => r.FoodTypes)
                .WithMany()
                .Map(m => m.MapLeftKey("RestaurantId").MapRightKey("FoodTypeId").ToTable("RestaurantFoodTypes"));
        }
    }
}