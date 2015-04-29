using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using DataAccessInsightRiskTechnologies;
using InsightRiskTechnologiesEntity;
using Newtonsoft.Json;

namespace LogicInsightRiskTechnologies
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, Namespace = "https://www.chancesrmis.com/wcfphonegap/AutenticationMobile")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AutenticationMobile:IAutenticationMobile
    {
        public BEAutentication Login(string UserName, string Password)
        {
            try
            {
                var obj = new BEAutentication();
                obj.Name = "Santiago Gastanadui Lujan";
                obj.IdUsername = "sgastanadui";
                obj.Username = ((UserName == null) ? "nulo":UserName);
                obj.Rol = ((Password == null) ? "nulo" : Password);
                return obj;

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

        public UserApplication AutenticationUser(string IdUsername, string Password, int IdAplication)
        {
            Autentication obj = new Autentication();
            try
            {
                return obj.autenticacion(IdUsername, Password, IdAplication);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
            }
        }

        public List<Member> ListMember(int IdCompany, int TypeMember, int IdInsightBCP)
        {
            MemberERT obj = new MemberERT();
            List<Member> lsobj = new List<Member>();
            try
            {
                lsobj = obj.ListMemberBCP(IdCompany, TypeMember, IdInsightBCP);
                return lsobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                lsobj = null;
            }
        }

        public List<StatusERT> ListStatusERT(int IdCompany)
        {
            MemberERT obj = new MemberERT();
            List<StatusERT> lsobjStatus = new List<StatusERT>();
            try
            {
                lsobjStatus = obj.ListStatusERT(IdCompany);
                return lsobjStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                lsobjStatus = null;
            }
        }

        public List<CommentsERT> ListCommentsERT(int IdCompany, int IdContact)
        {
            MemberERT obj = new MemberERT();
            List<CommentsERT> lsobjComments = new List<CommentsERT>();
            try
            {
                lsobjComments = obj.ListCommentsERT(IdCompany, IdContact);
                return lsobjComments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                lsobjComments = null;
            }
        }

        public bool SaveCommentsERT(int IdCompany, int IdContact, int IdStatus, string Comments)
        {
            MemberERT obj = new MemberERT();
            bool RowSaved = false;
            try
            {
                RowSaved = (obj.SaveCommentsERT(IdCompany, IdContact, IdStatus, Comments) == 0 ? false : true);
                return RowSaved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
            }
        }

    }
}
