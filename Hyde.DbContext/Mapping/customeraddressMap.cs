using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Hyde.Domain.Model;
namespace Hyde.Context.Mapping
{
    public class customeraddressMap : EntityTypeConfiguration<customerAddressDto>
    {
        public customeraddressMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("customeraddressid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable("customeraddress");

            this.HasRequired(t => t.area).WithMany().HasForeignKey(t => t.areaid);

        }
    }
}
