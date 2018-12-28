using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_de_Contenido : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_de_Contenido_Clave { get; set; }
        public string Estatus_de_Contenido_Descripcion { get; set; }

    }
}
