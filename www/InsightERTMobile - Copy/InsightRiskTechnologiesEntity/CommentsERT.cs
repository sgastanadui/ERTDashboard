using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightRiskTechnologiesEntity
{
    public class CommentsERT
    {
        public int IdComment { set; get; }
        public int IdCompany { set; get; }
        public int IdContact { set; get; }
        public int IdStatus { set; get; }
        public string Status { set; get; }
        public string Comments { set; get; }
        public string DateRegister { set; get; }
    }
}
