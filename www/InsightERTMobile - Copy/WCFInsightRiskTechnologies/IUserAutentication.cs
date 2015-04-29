using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using InsightRiskTechnologiesEntity;

namespace WCFInsightRiskTechnologies
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserAutentication" in both code and config file together.
    [ServiceContract]
    public interface IUserAutentication
    {
        [OperationContract]
        [Description("Returns a copy of the restaurant menu.")]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Login/{UserName}/{Password}")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        BEUsernameAutenticated Login(string UserName, string Password);
    }
}
