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
   public class rangeMap:EntityTypeConfiguration<rangeDto>
    {
        public rangeMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("rangeid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.name).HasMaxLength(50).IsUnicode().IsRequired();

            ToTable("range");


        }
    }
}
