using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllCodigos_por_Cliente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Codigos_por_Cliente_Folio { get; set; }
        public int? Codigos_por_Cliente_Usuario_que_Registra { get; set; }
        public string Codigos_por_Cliente_Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Codigos_por_Cliente_Fecha_de_Registro { get; set; }
        public string Codigos_por_Cliente_Hora_de_Registro { get; set; }
        public string Codigos_por_Cliente_Cliente { get; set; }
        public string Codigos_por_Cliente_Contacto { get; set; }
        public string Codigos_por_Cliente_Correo { get; set; }

    }
}
