using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External.Highwave;
namespace Hyde.Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new HighwaveOp();

            var acc = service.GetAccessTocken("hk013", "123").Result;

            if (acc.err_code == 0)
            {
                Console.WriteLine(acc.entity.access_token);

                var result = service.GetHighwaveProduct(acc.entity.access_token, new string[] { "耐克" }, new DateTime(2015, 12, 31)).Result;

                var barcode = service.GetHighwaveBarcode(acc.entity.access_token, result.entity.Data.Select(t => t.Goods_no).ToArray()).Result;

                var a = barcode.entity.Select(t => t.Goods_no).Distinct();
            }
            Console.ReadLine();
        }
    }
}
