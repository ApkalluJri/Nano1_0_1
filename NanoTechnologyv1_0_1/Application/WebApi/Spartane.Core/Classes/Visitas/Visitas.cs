using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_de_Contenido;
using Spartane.Core.Classes.Registro_de_Usuario;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Visitas
{
    /// <summary>
    /// Visitas table
    /// </summary>
    public class Visitas: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_visita { get; set; }
        public string Hora_de_visita { get; set; }
        public int? ContenidoId { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("ContenidoId")]
        public virtual Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido ContenidoId_Registro_de_Contenido { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario UsuarioId_Registro_de_Usuario { get; set; }

    }
}

