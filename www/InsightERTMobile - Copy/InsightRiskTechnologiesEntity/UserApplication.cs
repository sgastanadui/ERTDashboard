using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightRiskTechnologiesEntity
{
    public class UserApplication
    {
            public string IdUsuario { set; get; }
            public List<Permisos> listaPermisos { set; get; }
            public Error error { set; get; }
            public int IdGroupCompany { set; get; }
            public int IdCompany { set; get; }
            public string CompanyName { set; get; }
            public int IdContact { set; get; }
            public string ContactName { set; get; }
            public int IdORM { set; get; }
            public string ORM { set; get; }
            public string EmailORM { set; get; }
            public string Address1 { set; get; }
            public string Address2 { set; get; }
            public string CellPhone { set; get; }
            public string City { set; get; }
            public string Email { set; get; }
            public string DBA { set; get; }
            public string IdCountry { set; get; }
            public string Country { set; get; }
            public string IdState { set; get; }
            public string State { set; get; }
            public Boolean Bloqueado { set; get; }
            public string Names { set; get; }
            public string LastName { set; get; }
            public byte[] ImageData { set; get; }
            public string GroupName { set; get; }
            public string AddressG { set; get; }
            public string CityG { set; get; }
            public string StateG { set; get; }
            public string ZipG { set; get; }
            public string TelG { set; get; }
            public string CodRol { set; get; }
            public string NombreRol { set; get; }
    }

}
