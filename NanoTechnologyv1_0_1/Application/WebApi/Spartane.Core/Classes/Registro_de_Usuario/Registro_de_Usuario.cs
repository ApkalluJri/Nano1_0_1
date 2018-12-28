using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTUsuarios;
using Spartane.Core.Classes.TTArchivos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Registro_de_Usuario
{
    /// <summary>
    /// Registro_de_Usuario table
    /// </summary>
    public class Registro_de_Usuario: BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Confirmar_Contrasena { get; set; }
        public bool? Acepta_Terminos { get; set; }
        public int? Foto_de_Perfil { get; set; }
        public int? Usuario_del_Sistema { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Usuario_que_Registra_TTUsuarios { get; set; }
        [ForeignKey("Foto_de_Perfil")]
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos Foto_de_Perfil_TTArchivos { get; set; }
        [ForeignKey("Usuario_del_Sistema")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Usuario_del_Sistema_TTUsuarios { get; set; }

    }
}

