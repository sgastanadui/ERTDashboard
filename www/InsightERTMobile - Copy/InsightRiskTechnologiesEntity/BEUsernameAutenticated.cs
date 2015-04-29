using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InsightRiskTechnologiesEntity
{
    //[DataContract]
    public class BEUsernameAutenticated : Collection<BEAutentication>
    {
        public BEUsernameAutenticated()
        {
            //Pre-load the instance of RestaurantMenu with MenuItem(s) for the demo
            Add(new BEAutentication() { Username = "Santiago", IdUsername = "sgastanadui", Name = "Santiago Gastanadui", Rol ="Admin" });
        }

        public BEUsernameAutenticated(IList<BEAutentication> list)
            : base(list)
        {
        }
    }
}
