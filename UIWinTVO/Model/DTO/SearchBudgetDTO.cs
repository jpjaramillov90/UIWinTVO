using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Model.DTO
{
    public class SearchBudgetDTO
    {
        public int idWorkOrder { get; set; }
        public string orderStatus { get; set; }
        public int idOrderDetails { get; set; }
        public int idService { get; set; }
        public string descriptionServices { get; set; }
        public decimal? price { get; set; }
        public DateOnly expires { get; set; }
        public string clientNui { get; set; }
        public string clientName { get; set; }
        public string vehiclePlate { get; set; }
        public string vehicleBrand { get; set; }
        public string vehicleModel { get; set; }
    }
}
