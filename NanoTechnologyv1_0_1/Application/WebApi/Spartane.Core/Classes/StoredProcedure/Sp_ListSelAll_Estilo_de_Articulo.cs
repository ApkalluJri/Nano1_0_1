using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstilo_de_Articulo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estilo_de_Articulo_Clave { get; set; }
        public string Estilo_de_Articulo_Descripcion { get; set; }

    }
}
