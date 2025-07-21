using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Model.DTO
{
    public class OrderDetailsDTO
    {
        public int idOrderDetails { get; set; }
        public int? idWorkOrder { get; set; }
        public int? idService { get; set; }
    }
}
