using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Hyde.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hyde.DataBase.Mapping
{
    public class areaMap : EntityTypeConfiguration<areaDto>
    {
        public areaMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("areaid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.name).HasMaxLength(30).IsUnicode().IsRequired();

            this.Property(t => t.code).HasMaxLength(20).IsUnicode().IsRequired();

            this.Property(t => t.zip).HasMaxLength(20).IsUnicode();

            ToTable("area");

            this.HasMany(t => t.children).WithOptional().HasForeignKey(t => t.pid);
        }
    }
}
