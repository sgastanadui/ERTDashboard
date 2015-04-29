using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InsightRiskTechnologiesEntity
{
    //[Serializable()]    
    //[DataContract(Namespace = "https://www.chancesrmis.com/wcfphonegap/AutenticationMobile")]
    public class BEAutentication
    {
        //[DataMember]
        public string Username { set; get; }
        //[DataMember]
        public string IdUsername { set; get; }
        //[DataMember]
        public string Name { set; get; }
        //[DataMember]
        public string Rol { set; get; }
    }
}
