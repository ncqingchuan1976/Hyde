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
    public class orderpayMap : EntityTypeConfiguration<orderpayDto>
    {
        public orderpayMap()
        {
            HasKey(t => t.key);

            this.Property(t => t.key).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("orderpayid");

            this.Property(t => t.lastchanged).IsRowVersion();

            this.Property(t => t.othercode).HasMaxLength(50);

            this.Property(t => t.amount).HasPrecision(18, 4);

            ToTable("orderpay");

            HasRequired(t => t.payment).WithMany().HasForeignKey(t => t.paymentid);

        }
    }
}
