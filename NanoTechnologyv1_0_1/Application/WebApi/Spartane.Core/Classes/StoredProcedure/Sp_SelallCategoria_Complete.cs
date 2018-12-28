using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallCategoria_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Icono { get; set; }
        public string Icono_Nombre { get; set; }
        public int? Color_Franja { get; set; }
        public string Color_Franja_Descripcion { get; set; }
        public int? Imagen { get; set; }
        public string Imagen_Nombre { get; set; }

    }
}
