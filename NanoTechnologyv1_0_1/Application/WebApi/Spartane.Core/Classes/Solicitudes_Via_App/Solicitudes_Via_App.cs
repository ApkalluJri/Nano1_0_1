using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTUsuarios;
using Spartane.Core.Classes.Opciones_de_Solicitud_via_App;
using Spartane.Core.Classes.Estatus_de_Solicitud_Via_App;
using Spartane.Core.Classes.Observatorio;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Solicitudes_Via_App
{
    /// <summary>
    /// Solicitudes_Via_App table
    /// </summary>
    public class Solicitudes_Via_App: BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int? Opcion { get; set; }
        public string Descripcion { get; set; }
        public string Lada { get; set; }
        public string Telefono { get; set; }
        public int? Estatus { get; set; }
        public int? Observatorio { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Usuario_que_Registra_TTUsuarios { get; set; }
        [ForeignKey("Opcion")]
        public virtual Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App Opcion_Opciones_de_Solicitud_via_App { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App Estatus_Estatus_de_Solicitud_Via_App { get; set; }
        [ForeignKey("Observatorio")]
        public virtual Spartane.Core.Classes.Observatorio.Observatorio Observatorio_Observatorio { get; set; }

    }
}

