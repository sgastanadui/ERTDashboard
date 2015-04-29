using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using InsightRiskTechnologiesEntity;

namespace WCFInsightRiskTechnologies
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserAutentication" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserAutentication.svc or UserAutentication.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserAutentication : IUserAutentication
    {
        public BEUsernameAutenticated Login(string UserName, string Password)
        {
            var menuToReturn = new BEUsernameAutenticated();
            try
            {
                var menuToReturnOrdered = (
                    from items in menuToReturn
                    orderby items.Username
                    select items).ToList();

                menuToReturn = new BEUsernameAutenticated(menuToReturnOrdered);
                return menuToReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //obj = null;
            }
        }
    }
}
