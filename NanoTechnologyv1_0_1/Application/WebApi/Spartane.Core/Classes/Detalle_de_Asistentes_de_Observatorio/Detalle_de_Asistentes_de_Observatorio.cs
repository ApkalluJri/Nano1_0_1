using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Observatorio;
using Spartane.Core.Classes.Registro_de_Roles;
using Spartane.Core.Classes.Rol_de_Usuario;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio
{
    /// <summary>
    /// Detalle_de_Asistentes_de_Observatorio table
    /// </summary>
    public class Detalle_de_Asistentes_de_Observatorio: BaseEntity
    {
        public int Clave { get; set; }
        public int? Observatorio { get; set; }
        public int? Nombre { get; set; }
        public int? Rol { get; set; }

        [ForeignKey("Observatorio")]
        public virtual Spartane.Core.Classes.Observatorio.Observatorio Observatorio_Observatorio { get; set; }
        [ForeignKey("Nombre")]
        public virtual Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles Nombre_Registro_de_Roles { get; set; }
        [ForeignKey("Rol")]
        public virtual Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario Rol_Rol_de_Usuario { get; set; }

    }
}

