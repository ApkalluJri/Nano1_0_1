using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRegistro_de_Usuario_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Nombre { get; set; }
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
        public string Foto_de_Perfil_Nombre { get; set; }
        public int? Usuario_del_Sistema { get; set; }
        public string Usuario_del_Sistema_Nombre { get; set; }

    }
}
