using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Munchies.Data.EF.Mappings
{
    internal class FoodTypeMap : EntityTypeConfiguration<FoodType>
    {
        public FoodTypeMap()
        {
            ToTable("Foodtypes");

            Property(ft => ft.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(ft => ft.Name).HasMaxLength(16).IsUnicode().IsVariableLength().IsRequired();
        }
    }
}