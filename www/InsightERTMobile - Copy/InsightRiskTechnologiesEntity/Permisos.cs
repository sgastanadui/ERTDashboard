using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightRiskTechnologiesEntity
{
    public class Permisos
    {
        public string Codigo_Accion { set; get; }
        public string NombreAccion { set; get; }
        public int Secuencia_Orden { set; get; }
        public int IdObjeto { set; get; }
        public string Codigo_Objeto { set; get; }
        public string NombreObjeto { set; get; }
        public int Permitido { set; get; }
    }
}
