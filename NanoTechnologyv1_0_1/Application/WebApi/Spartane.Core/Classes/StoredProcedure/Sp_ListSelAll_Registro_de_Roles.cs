using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegistro_de_Roles : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Registro_de_Roles_Folio { get; set; }
        public int? Registro_de_Roles_Usuario_que_Registra { get; set; }
        public string Registro_de_Roles_Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Registro_de_Roles_Fecha_de_Registro { get; set; }
        public string Registro_de_Roles_Hora_de_Registro { get; set; }
        public string Registro_de_Roles_Nombre { get; set; }
        public string Registro_de_Roles_Clave_de_Acceso { get; set; }
        public string Registro_de_Roles_Contrasena { get; set; }
        public string Registro_de_Roles_Correo { get; set; }
        public int? Registro_de_Roles_Rol { get; set; }
        public string Registro_de_Roles_Rol_Descripcion { get; set; }
        public int? Registro_de_Roles_Usuario_de_Sistema { get; set; }
        public string Registro_de_Roles_Usuario_de_Sistema_Nombre { get; set; }
        public string Registro_de_Roles_Observatorios { get; set; }

    }
}
