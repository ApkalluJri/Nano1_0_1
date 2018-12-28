using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallObservatorio_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Icono { get; set; }
        public string Icono_Nombre { get; set; }
        public int? Color { get; set; }
        public string Color_Descripcion { get; set; }
        public int? Tipo_de_Observatorio { get; set; }
        public string Tipo_de_Observatorio_Descripcion { get; set; }
        public int? Administrador { get; set; }
        public string Administrador_Nombre { get; set; }

    }
}
