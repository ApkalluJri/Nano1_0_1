using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllVisitas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Visitas_Folio { get; set; }
        public DateTime? Visitas_Fecha_de_visita { get; set; }
        public string Visitas_Hora_de_visita { get; set; }
        public int? Visitas_ContenidoId { get; set; }
        public string Visitas_ContenidoId_Descripcion { get; set; }
        public int? Visitas_UsuarioId { get; set; }
        public string Visitas_UsuarioId_Nombre_Completo { get; set; }

    }
}
