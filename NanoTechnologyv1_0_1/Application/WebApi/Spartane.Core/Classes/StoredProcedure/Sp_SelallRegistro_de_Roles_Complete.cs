using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRegistro_de_Roles_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Nombre { get; set; }
        public string Clave_de_Acceso { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public int? Rol { get; set; }
        public string Rol_Descripcion { get; set; }
        public int? Usuario_de_Sistema { get; set; }
        public string Usuario_de_Sistema_Nombre { get; set; }
        public string Observatorios { get; set; }

    }
}
