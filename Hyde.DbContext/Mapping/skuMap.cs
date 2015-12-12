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
    public class skuMap : EntityTypeConfiguration<skuDto>
    {
        public skuMap()
        {
            HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("skuid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.barcode).HasMaxLength(50).IsUnicode().IsRequired();

            ToTable("sku");

            this.HasRequired(t => t.size).WithMany().HasForeignKey(t => t.sizeid);


            this.HasRequired(t => t.product).WithMany(t => t.skus).HasForeignKey(t => t.productid);
        }
    }
}
