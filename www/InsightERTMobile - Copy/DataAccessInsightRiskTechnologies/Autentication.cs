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
    public class Autentication
    {
        public UserApplication autenticacion(string IdUsuario, string password, int idAplicacion)
        {
            SqlDataReader rs = null;
            SQLHelper comando = new SQLHelper(System.Data.CommandType.StoredProcedure, "sp_autenticacion");

            UserApplication usuario = new UserApplication();
            Error erro = new Error();
            List<Permisos> permiso = new List<Permisos>();
            Permisos obj = new Permisos();

            try
            {
                comando.AgregarParametro("@IdUsuario", SqlDbType.VarChar, ParameterDirection.Input, IdUsuario);
                comando.AgregarParametro("@password", SqlDbType.VarChar, ParameterDirection.Input, password);
                comando.AgregarParametro("@idAplicacion", SqlDbType.Int, ParameterDirection.Input, idAplicacion);

                rs = comando.ExecuteDataReader();

                if (rs.HasRows)
                {
                    while (rs.Read())
                    {
                        erro.Descripcion = rs["Error"].ToString();
                    }
                    usuario.error = erro;

                    rs.NextResult();
                    while (rs.Read())
                    {
                        /*******************************************/
                        usuario.IdUsuario = rs["UserName"].ToString();
                        usuario.IdGroupCompany = Convert.ToInt16(rs["IdGroupCompany"].ToString());
                        usuario.Address1 = rs["Address1"].ToString();
                        usuario.Address2 = rs["Address2"].ToString();
                        usuario.CellPhone = rs["CellPhone"].ToString();
                        usuario.City = rs["City"].ToString();
                        usuario.CompanyName = rs["CompanyName"].ToString();
                        usuario.ContactName = rs["ContactName"].ToString();
                        usuario.Email = rs["Email"].ToString();
                        usuario.DBA = rs["DBA"].ToString();
                        usuario.IdCompany = Convert.ToInt16(rs["IdCompany"].ToString());
                        usuario.IdContact = Convert.ToInt16(rs["IdContact"].ToString());
                        usuario.IdCountry = rs["IdCountry"].ToString();
                        usuario.IdState = rs["IdState"].ToString();
                        usuario.State = rs["State"].ToString();
                        /*******************************************/
                        if (rs["ImageData"] is DBNull)
                            usuario.ImageData = usuario.ImageData;
                        else
                            usuario.ImageData = (byte[])rs["ImageData"];
                        /*******************************************/
                        usuario.IdORM = Convert.ToInt16(rs["IdORM"].ToString());
                        usuario.EmailORM = rs["EmailORM"].ToString();
                        usuario.ORM = rs["ORM"].ToString();
                        /*******************************************/
                        usuario.GroupName = rs["GroupName"].ToString();
                        usuario.AddressG = rs["AddressG"].ToString();
                        usuario.CityG = rs["CityG"].ToString();
                        usuario.StateG = rs["StateG"].ToString();
                        usuario.ZipG = rs["ZipG"].ToString();
                        usuario.TelG = rs["TelG"].ToString();
                        /*******************************************/
                    }
                    rs.NextResult();
                    while (rs.Read())
                    {
                        obj = new Permisos();
                        obj.Codigo_Accion = rs["Codigo_Accion"].ToString();
                        obj.NombreAccion = rs["Nombre_Accion"].ToString();
                        obj.Secuencia_Orden = (int)rs["Secuencia_Accion"];
                        obj.IdObjeto = (int)rs["IdObjeto"];
                        obj.Codigo_Objeto = rs["Codigo_Objeto"].ToString();
                        obj.NombreObjeto = rs["Nombre_Objeto"].ToString();
                        //obj.Permitido = (int)rs["Permitido"];
                        permiso.Add(obj);
                        obj = null;
                    }
                    usuario.listaPermisos = permiso;

                    rs.NextResult();
                    while (rs.Read())
                    {
                        usuario.CodRol = rs["IdRol"].ToString();
                        usuario.NombreRol = rs["Nombre_Rol"].ToString();
                    }
                }

                return usuario;

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
                usuario = null;
                erro = null;
                permiso = null;
                obj = null;
                //************
            }
        }
    }
}
