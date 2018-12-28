using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllUsuarios_Registrados_en_Observatorios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Usuarios_Registrados_en_Observatorios_Clave { get; set; }
        public int? Usuarios_Registrados_en_Observatorios_Observatorio { get; set; }
        public string Usuarios_Registrados_en_Observatorios_Observatorio_Nombre { get; set; }
        public int? Usuarios_Registrados_en_Observatorios_Usuario { get; set; }
        public string Usuarios_Registrados_en_Observatorios_Usuario_Nombre { get; set; }
        public string Usuarios_Registrados_en_Observatorios_Nombre { get; set; }
        public string Usuarios_Registrados_en_Observatorios_Correo { get; set; }
        public string Usuarios_Registrados_en_Observatorios_Contrasena { get; set; }
        public DateTime? Usuarios_Registrados_en_Observatorios_Fecha_de_Ingreso { get; set; }
        public string Usuarios_Registrados_en_Observatorios_Token { get; set; }
        public string Usuarios_Registrados_en_Observatorios_Identificador_Dispositivo { get; set; }
        public int? Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo { get; set; }
        public string Usuarios_Registrados_en_Observatorios_Tipo_de_Dispositivo_Tipo { get; set; }
        public bool? Usuarios_Registrados_en_Observatorios_Estado_Token { get; set; }

    }
}
