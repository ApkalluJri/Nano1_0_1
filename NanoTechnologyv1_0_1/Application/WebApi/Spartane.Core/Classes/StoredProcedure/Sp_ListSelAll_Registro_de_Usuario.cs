using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegistro_de_Usuario : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Registro_de_Usuario_Folio { get; set; }
        public int? Registro_de_Usuario_Usuario_que_Registra { get; set; }
        public string Registro_de_Usuario_Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Registro_de_Usuario_Fecha_de_Registro { get; set; }
        public string Registro_de_Usuario_Hora_de_Registro { get; set; }
        public string Registro_de_Usuario_Nombre { get; set; }
        public string Registro_de_Usuario_Apellido { get; set; }
        public string Registro_de_Usuario_Nombre_Completo { get; set; }
        public string Registro_de_Usuario_Correo { get; set; }
        public string Registro_de_Usuario_Contrasena { get; set; }
        public string Registro_de_Usuario_Confirmar_Contrasena { get; set; }
        public bool? Registro_de_Usuario_Acepta_Terminos { get; set; }
        public int? Registro_de_Usuario_Foto_de_Perfil { get; set; }
        public string Registro_de_Usuario_Foto_de_Perfil_Nombre { get; set; }
        public int? Registro_de_Usuario_Usuario_del_Sistema { get; set; }
        public string Registro_de_Usuario_Usuario_del_Sistema_Nombre { get; set; }

    }
}
