using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllCategoria : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Categoria_Clave { get; set; }
        public string Categoria_Descripcion { get; set; }
        public int? Categoria_Icono { get; set; }
        public string Categoria_Icono_Nombre { get; set; }
        public int? Categoria_Color_Franja { get; set; }
        public string Categoria_Color_Franja_Descripcion { get; set; }
        public int? Categoria_Imagen { get; set; }
        public string Categoria_Imagen_Nombre { get; set; }

    }
}
