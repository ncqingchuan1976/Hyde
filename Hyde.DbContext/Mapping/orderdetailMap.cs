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
    public class orderdetailMap : EntityTypeConfiguration<orderdetailDto>
    {
        public orderdetailMap()
        {
            this.HasKey(t => t.key);

            this.Property(t => t.key).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("orderdetailid");

            this.Property(t => t.lastchanged).IsRowVersion();

            this.Property(t => t.unitprice).HasPrecision(18, 4);
            this.Property(t => t.saleprice).HasPrecision(18, 4);
            this.Property(t => t.orderquantity).HasPrecision(18, 4);
            this.Property(t => t.canclequantity).HasPrecision(18, 4);
            this.Property(t => t.lostquantity).HasPrecision(18, 4);
            this.Property(t => t.realquantity).HasPrecision(18, 4);

            ToTable("orderdetail");

            HasRequired(t => t.product).WithMany().HasForeignKey(t => t.productid);

            HasRequired(t => t.size).WithMany().HasForeignKey(t => t.sizeid);

            HasRequired(t => t.supply).WithMany().HasForeignKey(t => t.supplyid);
        }
    }
}
