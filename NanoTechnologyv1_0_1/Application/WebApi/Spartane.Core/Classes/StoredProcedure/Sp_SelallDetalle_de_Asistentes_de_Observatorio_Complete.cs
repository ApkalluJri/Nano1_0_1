using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_de_Asistentes_de_Observatorio_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int Observatorio { get; set; }
        public int? Nombre { get; set; }
        public string Nombre_Nombre { get; set; }
        public int? Rol { get; set; }
        public string Rol_Descripcion { get; set; }

    }
}
