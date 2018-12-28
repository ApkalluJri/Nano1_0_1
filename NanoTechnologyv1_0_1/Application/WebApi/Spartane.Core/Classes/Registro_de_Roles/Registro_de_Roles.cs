using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTUsuarios;
using Spartane.Core.Classes.Rol_de_Usuario;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Registro_de_Roles
{
    /// <summary>
    /// Registro_de_Roles table
    /// </summary>
    public class Registro_de_Roles: BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Nombre { get; set; }
        public string Clave_de_Acceso { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public int? Rol { get; set; }
        public int? Usuario_de_Sistema { get; set; }
        public string Observatorios { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Usuario_que_Registra_TTUsuarios { get; set; }
        [ForeignKey("Rol")]
        public virtual Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario Rol_Rol_de_Usuario { get; set; }
        [ForeignKey("Usuario_de_Sistema")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Usuario_de_Sistema_TTUsuarios { get; set; }

    }
}

