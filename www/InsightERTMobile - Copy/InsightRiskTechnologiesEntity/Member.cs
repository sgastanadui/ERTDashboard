using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightRiskTechnologiesEntity
{
    public class Member
    {
        public int IdCompany { set; get; }
        public int IdInsightBCP { set; get; }
        public int IdContact { set; get; }
        public string Rol { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Cell { set; get; }
        public string Status { set; get; }
        public string Level { set; get; }
    }
}
