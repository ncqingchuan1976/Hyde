using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Hyde.Api.Validation;
using Hyde.Domain.Model;
namespace Hyde.Api.Models.RequestModels
{
    /// <summary>
    /// 供应商模型
    /// </summary>
    public class Supply
    {
        public int key { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "供应商编码")]
        public string code { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "名称")]
        public string name { get; set; }
        [StringLength(255)]
        [Display(Name = "备注")]
        public string remark { get; set; }
        [Required]
        [Display(Name = "停用")]
        public bool shutout { get; set; }
        /// <summary>
        ///供应商优先级
        /// </summary>
        [Display(Name = "优先级")]
        [Required]
        [Minimum(1)]
        public int priorlevel { get; set; }
    }
}
