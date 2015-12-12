using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Hyde.Api.Model.Validation;
using Hyde.Domain.Model;
namespace Hyde.Api.Model.RequestModels
{
    /// <summary>
    /// 供应商模型
    /// </summary>
    public abstract class SupplyBase
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "供应商编码")]
        public string Code { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "名称")]
        public string Name { get; set; }
        [StringLength(255)]
        [Display(Name = "备注")]
        public string Remark { get; set; }
        [Required]
        [Display(Name = "停用")]
        public bool ShutOut { get; set; }
        /// <summary>
        ///供应商优先级
        /// </summary>
        [Display(Name = "优先级")]
        [Required]
        [Minimum(1)]
        public int PriorLevel { get; set; }
    }

    public class SupplyAdd : SupplyBase
    {
        [Display(Name = "供应商编码")]
        public int SupplyID { get; set; }
    }

    public class SupplyEdit : SupplyBase
    {

    }

    public static class SupplyExtension
    {
        public static SupplyAdd Mapper(this supplyDto Item)
        {
            if (Item == null)
                return null;

            return new SupplyAdd()
            {
                SupplyID = Item.key,
                Name = Item.name,
                ShutOut = Item.shutout,
                PriorLevel = Item.priorlevel,
                Remark = Item.remark,
                Code = Item.code
            };

        }

        public static supplyDto Mapper(this SupplyEdit Item)
        {
            if (Item == null)
                return null;

            return new supplyDto()
            {
                name = Item.Name,
                shutout = Item.ShutOut,
                priorlevel = Item.PriorLevel,
                remark = Item.Remark,
                code = Item.Code
            };

        }
    }
}
