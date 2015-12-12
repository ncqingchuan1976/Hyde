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
    public class productimageMap : EntityTypeConfiguration<productimageDto>
    {
        public productimageMap()
        {
            HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("productimgid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.imgpath).HasMaxLength(255).IsUnicode();

            ToTable("productimage");
        }
    }
}
