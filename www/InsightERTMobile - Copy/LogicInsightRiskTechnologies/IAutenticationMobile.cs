using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using InsightRiskTechnologiesEntity;

namespace LogicInsightRiskTechnologies
{
    [ServiceContract(SessionMode = SessionMode.Allowed, Namespace = "https://www.chancesrmis.com/wcfphonegap/AutenticationMobile")]
    public interface IAutenticationMobile
    {
        [OperationContract]
        [Description("Returns a copy of the restaurant menu.")]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Login/{UserName}/{Password}")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        BEAutentication Login(string UserName, string Password);

        [OperationContract]
        [Description("Returns Entity of Autentication")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        UserApplication AutenticationUser(string IdUsername, string Password, int IdAplication);

        [OperationContract]
        [Description("Returns List Entity of Member ERT")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        List<Member> ListMember(int IdCompany, int TypeMember, int IdInsightBCP);

        [OperationContract]
        [Description("Returns List Entity of Status ERT")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        List<StatusERT> ListStatusERT(int IdCompany);

        [OperationContract]
        [Description("Returns number row saved")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        bool SaveCommentsERT(int IdCompany, int IdContact, int IdStatus, string Comments);

        [OperationContract]
        [Description("Returns List Entity of Comments ERT")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        [AspNetCacheProfile("CacheFor10Seconds")]
        List<CommentsERT> ListCommentsERT(int IdCompany, int IdContact);

    }
}
