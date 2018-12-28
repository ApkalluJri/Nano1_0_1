using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllObservatorio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Observatorio_Clave { get; set; }
        public string Observatorio_Nombre { get; set; }
        public int? Observatorio_Icono { get; set; }
        public string Observatorio_Icono_Nombre { get; set; }
        public int? Observatorio_Color { get; set; }
        public string Observatorio_Color_Descripcion { get; set; }
        public int? Observatorio_Tipo_de_Observatorio { get; set; }
        public string Observatorio_Tipo_de_Observatorio_Descripcion { get; set; }
        public int? Observatorio_Administrador { get; set; }
        public string Observatorio_Administrador_Nombre { get; set; }

    }
}
