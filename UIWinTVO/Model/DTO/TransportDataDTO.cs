using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Model.DTO
{
    public class TransportDataDTO
    {
        public int idTransportData { get; set; }
        public int? idTransport { get; set; }
        public int? idCooperative { get; set; }
        public int? idClient { get; set; }
        public string plate { get; set; }
        public int num { get; set; }
        public string chassis { get; set; }
    }
}
