using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTArchivos;
using Spartane.Core.Classes.Color;
using Spartane.Core.Classes.Tipo_de_Observatorio;
using Spartane.Core.Classes.Registro_de_Roles;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Observatorio
{
    /// <summary>
    /// Observatorio table
    /// </summary>
    public class Observatorio: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Icono { get; set; }
        public int? Color { get; set; }
        public int? Tipo_de_Observatorio { get; set; }
        public int? Administrador { get; set; }

        [ForeignKey("Icono")]
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos Icono_TTArchivos { get; set; }
        [ForeignKey("Color")]
        public virtual Spartane.Core.Classes.Color.Color Color_Color { get; set; }
        [ForeignKey("Tipo_de_Observatorio")]
        public virtual Spartane.Core.Classes.Tipo_de_Observatorio.Tipo_de_Observatorio Tipo_de_Observatorio_Tipo_de_Observatorio { get; set; }
        [ForeignKey("Administrador")]
        public virtual Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles Administrador_Registro_de_Roles { get; set; }

    }
}

