using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllOpciones_de_Solicitud_via_App : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Opciones_de_Solicitud_via_App_Clave { get; set; }
        public string Opciones_de_Solicitud_via_App_Descripcion { get; set; }

    }
}
