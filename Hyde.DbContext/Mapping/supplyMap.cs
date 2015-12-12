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
   public class supplyMap:EntityTypeConfiguration<supplyDto>
    {
        public supplyMap()
        {
            HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("supplyid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.code).HasMaxLength(50).IsRequired().IsUnicode();

            this.Property(t => t.name).HasMaxLength(50).IsRequired().IsUnicode();

            this.Property(t => t.remark).HasMaxLength(255).IsUnicode();

            ToTable("supply");
        }
    }
}
