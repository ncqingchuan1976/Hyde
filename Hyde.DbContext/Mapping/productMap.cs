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
    public class productMap : EntityTypeConfiguration<productDto>
    {
        public productMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("productid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.code).IsUnicode().IsRequired().HasMaxLength(50);

            this.Property(t => t.unitprice).HasPrecision(18, 4);

            this.Property(t => t.name).HasMaxLength(50).IsUnicode().IsRequired();

            this.Property(t => t.sizegroup).IsUnicode().HasMaxLength(50).IsRequired();

            this.Property(t => t.description).IsUnicode().HasMaxLength(255);

            this.Property(t => t.imagemain).IsUnicode().HasMaxLength(255);

            this.Property(t => t.createdate).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable("product");

            HasRequired(t => t.brand).WithMany().HasForeignKey(t => t.brandid);

            HasRequired(t => t.category).WithMany().HasForeignKey(t => t.categroyid);

            HasRequired(t => t.gender).WithMany().HasForeignKey(t => t.genderid);

            HasMany(t => t.images).WithRequired().HasForeignKey(t => t.productid);

            HasOptional(t => t.range).WithMany().HasForeignKey(t => t.rangeid);
        }
    }
}
