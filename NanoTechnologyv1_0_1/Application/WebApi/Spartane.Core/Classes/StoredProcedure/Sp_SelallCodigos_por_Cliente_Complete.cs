using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallCodigos_por_Cliente_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Cliente { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }

    }
}
