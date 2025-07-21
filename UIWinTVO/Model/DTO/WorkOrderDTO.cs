using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Model.DTO
{
    public class WorkOrderDTO
    {
        public int idWorkOrder { get; set; }
        public int? idEmployee { get; set; }
        public int? idOrderStatus { get; set; }
        public string descriptionWO { get; set; }
        public DateOnly expires { get; set; }
    }
}
