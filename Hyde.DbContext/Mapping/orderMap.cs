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
   public class orderMap:EntityTypeConfiguration<orderDto>
    {
        public orderMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasColumnName("orderid").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.lastchanged).IsRowVersion();

            this.Property(t => t.remark).IsUnicode().HasMaxLength(255);

            this.Property(t => t.code).IsUnicode().HasMaxLength(20).IsRequired();

            this.Property(t => t.othercode).HasMaxLength(50).IsUnicode();

            ToTable("order");

            HasMany(t => t.orderdetails).WithRequired().HasForeignKey(t => t.orderid);

            HasMany(t => t.orderpays).WithRequired().HasForeignKey(t => t.orderid);

            HasRequired(t => t.customer).WithMany(t => t.orders).HasForeignKey(t => t.customerid);
        }
    }
}
