using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Model.DTO
{
    public class ServicePriceDTO
    {
        public int idServicePrice { get; set; }
        public int? idService { get; set; }
        public decimal? price { get; set; }
    }
}
