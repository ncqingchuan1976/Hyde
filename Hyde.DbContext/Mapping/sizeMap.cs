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
    public class sizeMap:EntityTypeConfiguration<sizeDto>
    {
        public sizeMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("sizeid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.sizegroup).HasMaxLength(50).IsUnicode().IsRequired();

            this.Property(t => t.code).HasMaxLength(50).IsUnicode().IsRequired();

            this.Property(t => t.displaycode).HasMaxLength(50).IsUnicode();

            ToTable("size");


        }
    }
}
