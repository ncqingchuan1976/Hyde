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
    public class customerMap : EntityTypeConfiguration<customerDto>
    {
        public customerMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("customerid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.groupname).HasMaxLength(50);

            this.Property(t => t.name).HasMaxLength(50).IsUnicode().IsRequired();

            this.Property(t => t.openid).HasMaxLength(50);

            ToTable("customer");

            this.HasMany(t => t.addresses).WithRequired().HasForeignKey(t => t.customerid);

        }
    }
}
