using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using Hyde.Domain.Model;
namespace Hyde.DataBase.Mapping
{
    public class warehouseMap : EntityTypeConfiguration<warehouseDto>
    {
        public warehouseMap()
        {
            HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("warehouseid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.name).IsUnicode().IsRequired().HasMaxLength(50);

            this.Property(t => t.code).IsUnicode().IsRequired().HasMaxLength(50);

            ToTable("warehouse");

            
        }
    }
}
