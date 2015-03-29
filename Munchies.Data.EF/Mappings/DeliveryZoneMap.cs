using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Munchies.Data.EF.Mappings
{
    internal class DeliveryZoneMap : EntityTypeConfiguration<DeliveryZone>
    {
        public DeliveryZoneMap()
        {
            ToTable("DeliveryZones");

            Property(dz => dz.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(dz => dz.PostalCode).HasMaxLength(32).IsUnicode(false).IsVariableLength().IsRequired();
        }
    }
}