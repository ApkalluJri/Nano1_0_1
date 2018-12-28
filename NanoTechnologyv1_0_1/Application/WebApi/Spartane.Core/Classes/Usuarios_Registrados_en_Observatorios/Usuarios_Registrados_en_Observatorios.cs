using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Observatorio;
using Spartane.Core.Classes.Registro_de_Usuario;
using Spartane.Core.Classes.Tipo_de_Dispositivo;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios
{
    /// <summary>
    /// Usuarios_Registrados_en_Observatorios table
    /// </summary>
    public class Usuarios_Registrados_en_Observatorios: BaseEntity
    {
        public int Clave { get; set; }
        public int? Observatorio { get; set; }
        public int? Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public DateTime? Fecha_de_Ingreso { get; set; }
        public string Token { get; set; }
        public string Identificador_Dispositivo { get; set; }
        public int? Tipo_de_Dispositivo { get; set; }
        public bool? Estado_Token { get; set; }

        [ForeignKey("Observatorio")]
        public virtual Spartane.Core.Classes.Observatorio.Observatorio Observatorio_Observatorio { get; set; }
        [ForeignKey("Usuario")]
        public virtual Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario Usuario_Registro_de_Usuario { get; set; }
        [ForeignKey("Tipo_de_Dispositivo")]
        public virtual Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo Tipo_de_Dispositivo_Tipo_de_Dispositivo { get; set; }

    }
}

