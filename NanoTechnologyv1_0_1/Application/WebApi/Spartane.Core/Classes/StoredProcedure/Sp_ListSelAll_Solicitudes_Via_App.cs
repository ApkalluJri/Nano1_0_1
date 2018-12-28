using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSolicitudes_Via_App : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Solicitudes_Via_App_Folio { get; set; }
        public int? Solicitudes_Via_App_Usuario_que_Registra { get; set; }
        public string Solicitudes_Via_App_Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Solicitudes_Via_App_Fecha_de_Registro { get; set; }
        public string Solicitudes_Via_App_Hora_de_Registro { get; set; }
        public string Solicitudes_Via_App_Nombre { get; set; }
        public string Solicitudes_Via_App_Correo { get; set; }
        public int? Solicitudes_Via_App_Opcion { get; set; }
        public string Solicitudes_Via_App_Opcion_Descripcion { get; set; }
        public string Solicitudes_Via_App_Descripcion { get; set; }
        public string Solicitudes_Via_App_Lada { get; set; }
        public string Solicitudes_Via_App_Telefono { get; set; }
        public int? Solicitudes_Via_App_Estatus { get; set; }
        public string Solicitudes_Via_App_Estatus_Descripcion { get; set; }
        public int? Solicitudes_Via_App_Observatorio { get; set; }
        public string Solicitudes_Via_App_Observatorio_Nombre { get; set; }

    }
}
