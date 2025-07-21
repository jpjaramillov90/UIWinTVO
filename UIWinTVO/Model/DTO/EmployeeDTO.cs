using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIWinTVO.Model.DTO
{
    public class EmployeeDTO
    {
        public int idEmployee { get; set; }
        public int? idSpecialties { get; set; }
        public int? idRolEmployee { get; set; }
        public string nui { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string addressEmp { get; set; }
        public string mail { get; set; }
    }
}
