using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Model.DTO
{
    public class ClientDTO
    {
        public int idClient { get; set; }

        public string nui { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string phone { get; set; }

        public string mail { get; set; }

        public string addressClient { get; set; }

        public string passwordClient { get; set; }

        public int? idClientStatus { get; set; }
    }
}
