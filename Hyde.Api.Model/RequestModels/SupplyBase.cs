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
    public class SupplyBase
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
            SupplyAdd Result = new SupplyAdd();

            Result.SupplyID = Item.key;
            Result.Name = Item.name;
            Result.ShutOut = Item.shutout;
            Result.PriorLevel = Item.priorlevel;
            Result.Remark = Item.remark;
            Result.Code = Item.code;
            return Result;
        }

        public static supplyDto Mapper(this SupplyBase Item)
        {
            if (Item == null)
                return null;

            supplyDto Result = new supplyDto();
            Result.name = Item.Name;
            Result.shutout = Item.ShutOut;
            Result.priorlevel = Item.PriorLevel;
            Result.remark = Item.Remark;
            Result.code = Item.Code;
            return Result;
        }
    }
}
