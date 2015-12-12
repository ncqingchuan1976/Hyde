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
   public class paymentMap:EntityTypeConfiguration<paymentDto>
    {
        public paymentMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("paymentid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.name).HasMaxLength(50).IsRequired().IsUnicode();

            ToTable("payment");


        }
    }
}
