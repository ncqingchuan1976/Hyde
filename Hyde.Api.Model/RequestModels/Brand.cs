using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Hyde.Api.Model.RequestModels
{
    public class Brand
    {

        public int Key { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }
        [StringLength(20)]
        public string enname { get; set; }
        [Required]
        public bool shutout { get; set; } = false;
        [StringLength(255)]
        public string imgpath { get; set; }
    }


}
