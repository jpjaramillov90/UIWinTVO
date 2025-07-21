using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Model.DTO
{
    public class BudgetDTO
    {
        public int idBudget { get; set; }

        public int? idWorkOrder { get; set; }

        public int? idTransportData { get; set; }

        public int? idBudgetStatement { get; set; }

        public int? idBrands { get; set; }

        public DateOnly? issueDate { get; set; }

        public DateOnly? validUntil { get; set; }

        public string comments { get; set; }
    }
}
