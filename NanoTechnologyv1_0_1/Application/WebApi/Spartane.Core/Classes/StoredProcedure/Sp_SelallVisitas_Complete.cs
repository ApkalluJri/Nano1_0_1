using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallVisitas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_visita { get; set; }
        public string Hora_de_visita { get; set; }
        public int? ContenidoId { get; set; }
        public string ContenidoId_Descripcion { get; set; }
        public int? UsuarioId { get; set; }
        public string UsuarioId_Nombre_Completo { get; set; }

    }
}
