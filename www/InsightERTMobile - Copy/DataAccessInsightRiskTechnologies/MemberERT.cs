using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsightRiskTechnologiesEntity;
using SQLHelperInsightRiskTechonologies;

namespace DataAccessInsightRiskTechnologies
{
    public class MemberERT
    {
        public List<Member> ListMemberBCP(int IdCompany, int TypeMember, int IdInsightBCP)
        {
            SqlDataReader rs = null;
            SQLHelper comando = new SQLHelper(System.Data.CommandType.StoredProcedure, "ERT_SP_OBTENER_MEMBER_ROL_MOBILE");

            List<Member> lstobj = new List<Member>();
            Member obj = new Member();

            try
            {
                comando.AgregarParametro("@IdCompany", SqlDbType.VarChar, ParameterDirection.Input, IdCompany);
                comando.AgregarParametro("@TypeMember", SqlDbType.VarChar, ParameterDirection.Input, TypeMember);
                comando.AgregarParametro("@IdInsightBCP", SqlDbType.Int, ParameterDirection.Input, IdInsightBCP);

                rs = comando.ExecuteDataReader();

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        obj = new Member();
                        obj.IdCompany = (int)rs["IdCompany"];
                        obj.IdContact = (int)rs["IdContact"];
                        obj.IdInsightBCP = (int)rs["IdInsigthBCP"];
                        obj.Rol = rs["Title"].ToString();
                        obj.Name = rs["ContactName"].ToString();
                        obj.Email = rs["Email"].ToString();
                        obj.Phone = rs["Phone"].ToString();
                        obj.Cell = rs["CellPhone"].ToString();
                        obj.Level = rs["Level"].ToString();
                        obj.Status = rs["Status"].ToString();
                        lstobj.Add(obj);
                        obj = null;
                    }
                }
                return lstobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //************
                rs = null;
                comando.Dispose();
                //************
                lstobj = null;
                //************
            }
        }

        public List<StatusERT> ListStatusERT(int IdCompany)
        {
            SqlDataReader rs = null;
            SQLHelper comando = new SQLHelper(System.Data.CommandType.StoredProcedure, "ERT_SP_OBTENER_STATUS_ERT");

            List<StatusERT> lstobj = new List<StatusERT>();
            StatusERT obj = new StatusERT();

            try
            {
                comando.AgregarParametro("@IdCompany", SqlDbType.VarChar, ParameterDirection.Input, IdCompany);

                rs = comando.ExecuteDataReader();

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        obj = new StatusERT();
                        obj.IdStatus = (int)rs["IdStatus"];
                        obj.Status = rs["Status"].ToString();
                        lstobj.Add(obj);
                        obj = null;
                    }
                }
                return lstobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //************
                rs = null;
                comando.Dispose();
                //************
                lstobj = null;
                //************
            }
        }

        public List<CommentsERT> ListCommentsERT(int IdCompany, int IdContact)
        {
            SqlDataReader rs = null;
            SQLHelper comando = new SQLHelper(System.Data.CommandType.StoredProcedure, "ERT_SP_OBTENER_COMMENTS_ERT");

            List<CommentsERT> lstobj = new List<CommentsERT>();
            CommentsERT obj = new CommentsERT();

            try
            {
                comando.AgregarParametro("@IdCompany", SqlDbType.VarChar, ParameterDirection.Input, IdCompany);
                comando.AgregarParametro("@IdContact", SqlDbType.VarChar, ParameterDirection.Input, IdContact);

                rs = comando.ExecuteDataReader();

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        obj = new CommentsERT();
                        obj.IdComment = (int)rs["IdComment"];
                        obj.IdCompany = (int)rs["IdCompany"];
                        obj.IdContact = (int)rs["IdContact"];
                        obj.IdStatus = (int)rs["IdStatus"];
                        obj.Status = rs["Status"].ToString();
                        obj.Comments = rs["Comments"].ToString();
                        obj.DateRegister = rs["DateRegister"].ToString();
                        lstobj.Add(obj);
                        obj = null;
                    }
                }
                return lstobj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //************
                rs = null;
                comando.Dispose();
                //************
                lstobj = null;
                //************
            }
        }

        public int SaveCommentsERT(int IdCompany, int IdContact, int IdStatus, string Comments)
        {
            SqlTransaction trans = null;
            SQLHelper objcomando = new SQLHelper(System.Data.CommandType.StoredProcedure, "ERT_SP_SAVE_COMMENTS_ERT", trans);
            trans = objcomando.Transaccion;
            int respuesta = 0;
            try
            {
                objcomando.AgregarParametro("@IdCompany", SqlDbType.Int, ParameterDirection.Input, IdCompany);
                objcomando.AgregarParametro("@IdContact", SqlDbType.Int, ParameterDirection.Input, IdContact);
                objcomando.AgregarParametro("@IdStatus", SqlDbType.Int, ParameterDirection.Input, IdStatus);
                objcomando.AgregarParametro("@Comments", SqlDbType.NText, ParameterDirection.Input, Comments);
                respuesta = objcomando.ExecuteNonQuery();
                trans.Commit();
                return respuesta;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                if (objcomando != null) objcomando.Dispose();
            }
        }

    }
}
