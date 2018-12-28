using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSolicitudes_Via_App_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int? Opcion { get; set; }
        public string Opcion_Descripcion { get; set; }
        public string Descripcion { get; set; }
        public string Lada { get; set; }
        public string Telefono { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int? Observatorio { get; set; }
        public string Observatorio_Nombre { get; set; }

    }
}
