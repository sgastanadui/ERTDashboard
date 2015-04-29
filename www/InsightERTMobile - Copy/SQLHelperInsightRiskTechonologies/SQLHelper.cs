using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SQLHelperInsightRiskTechonologies
{
    public class SQLHelper : IDisposable
    {
        private SqlConnection mConexion;
        private SqlCommand mComando;
        private bool disposedValue;
        private SqlTransaction mTransaccion;
        public SqlTransaction Transaccion
        {
            get
            {
                return mTransaccion;
            }
            set
            {
                mTransaccion = value;
            }

        }

        private const String cg_EcryptDesencrypt = "&%#@?,:*";

        public SQLHelper(CommandType pCommandType, string pCommandText)
        {
            mConexion = new SqlConnection();
            mComando = new SqlCommand();
            mConexion.ConnectionString = ObtenerCadenaConexion();
            mComando.Connection = mConexion;
            mComando.CommandText = pCommandText;
            mComando.CommandType = pCommandType;
        }
        public SQLHelper(CommandType pCommandType, string pCommandText, SqlTransaction pSqlTransaction)
        {
            mConexion = new SqlConnection();
            mComando = new SqlCommand();
            mConexion.ConnectionString = ObtenerCadenaConexion();
            mConexion.Open();
            mTransaccion = mConexion.BeginTransaction();
            mComando.Connection = mConexion;
            mComando.Transaction = mTransaccion;
            mComando.CommandText = pCommandText;
            mComando.CommandType = pCommandType;

        }
        public SQLHelper(CommandType pCommandType, string pCommandText, int pCommandTimeout)
            : this(pCommandType, pCommandText)
        {
            mComando.CommandTimeout = pCommandTimeout;
        }

        private static string ObtenerCadenaConexion()
        {
            try
            {
                RegistryKey keyNueva = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\INSIGHTRISK", true);
                return COMEncryptDesencrypt.Decrypt((string)keyNueva.GetValue("CadenaConexionErtMobile"), cg_EcryptDesencrypt).ToString();
                //return @"Data Source=MW7PHPZDRHSDJA\SQLEXPRESS_2008;Initial Catalog=BDInsightRisk_Security;user id=sa;password=Gretta2014;";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteNonQuery()
        {
            try
            {
                if (mConexion.State == ConnectionState.Closed) mConexion.Open();
                return mComando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                //mConexion.Close();
                //mConexion.Dispose();
            }
        }

        public SqlDataReader ExecuteDataReader()
        {

            try
            {
                mConexion.Open();
                return mComando.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public SqlDataAdapter ExecuteSqlDataAdapter()
        {
            try
            {
                mConexion.Open();
                return new SqlDataAdapter(mComando);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public object ExecuteScalar()
        {
            try
            {
                mConexion.Open();
                return mComando.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                mConexion.Close();
                mConexion.Dispose();
            }
        }

        public void AgregarParametro(string nombre, SqlDbType tipo, ParameterDirection direccion, object valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.SqlDbType = tipo;
            parametro.Direction = direccion;
            parametro.Value = valor;

            mComando.Parameters.Add(parametro);
            parametro = null;
        }

        public void AgregarParametro(string nombre, SqlDbType tipo, int tamanio, ParameterDirection direccion, object valor)
        {
            SqlParameter parametro = new SqlParameter();

            parametro.ParameterName = nombre;
            parametro.SqlDbType = tipo;
            parametro.Direction = direccion;
            parametro.Value = valor;
            parametro.Size = tamanio;

            mComando.Parameters.Add(parametro);
            parametro = null;
        }

        public void AgregarParametro(string nombre, SqlDbType tipo, int tamanio, int precision, ParameterDirection direccion, object valor)
        {
            SqlParameter parametro = new SqlParameter();

            parametro.ParameterName = nombre;
            parametro.SqlDbType = tipo;
            parametro.Direction = direccion;
            parametro.Value = valor;
            parametro.Size = tamanio;
            parametro.Size = precision;

            mComando.Parameters.Add(parametro);
            parametro = null;
        }

        public object ObtenerParametro(string nombre)
        {

            return mComando.Parameters[nombre].Value;

        }

        public static object ValorSidbNull(object pValorAnalizado, object pNuevoValor)
        {
            if (pValorAnalizado is DBNull)
            {
                return pNuevoValor;
            }
            else
            {
                return pValorAnalizado;
            }
        }

        public static object DbNullSivacio(string pValorAnalizado)
        {
            if (pValorAnalizado == null)
            {
                return DBNull.Value;
            }
            else if (pValorAnalizado.Trim().Length == 0)
            {
                return DBNull.Value;
            }
            else
            {
                return pValorAnalizado.Trim();
            }

        }

        public static object DbNullSivalor(object pValorAnalizado, object pValorEsperado)
        {
            if (pValorAnalizado == pValorEsperado)
            {
                return DBNull.Value;
            }
            else
            {
                return pValorAnalizado;
            }
        }

        public static string AnalizarFechaNula(string pValorAnalizado)
        {
            if (pValorAnalizado == "01/01/1900")
            {
                return "";
            }
            else
            {
                return pValorAnalizado;
            }
        }

        public static string ConvertirFecha(object pValorAnalizado)
        {
            return AnalizarFechaNula(Convert.ToDateTime(pValorAnalizado, CultureInfo.CurrentCulture).ToString("dd/MM/yyyy", CultureInfo.CurrentCulture));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (mComando != null)
                    {
                        mComando.Dispose();
                    }
                    mComando = null;

                    if (mConexion != null)
                    {
                        if (mConexion.State == ConnectionState.Open)
                        {
                            mConexion.Close();
                        }
                        mConexion.Dispose();
                    }
                    mConexion = null;

                }

                // TODO: free shared unmanaged resources
            }
            this.disposedValue = true;
        }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new NotImplementedException();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    public class DAOConstantes
    {
        public const string strCabeceraCombo = "Select";
        public const string strCabeceraDate = "New Hedging";

        public static string CabeceraCombo()
        {
            return strCabeceraCombo;
        }
    }

}
