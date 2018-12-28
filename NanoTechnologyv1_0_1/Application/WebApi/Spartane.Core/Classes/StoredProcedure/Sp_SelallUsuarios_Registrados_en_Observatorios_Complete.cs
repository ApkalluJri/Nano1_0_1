using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallUsuarios_Registrados_en_Observatorios_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int? Observatorio { get; set; }
        public string Observatorio_Nombre { get; set; }
        public int? Usuario { get; set; }
        public string Usuario_Nombre { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public DateTime? Fecha_de_Ingreso { get; set; }
        public string Token { get; set; }
        public string Identificador_Dispositivo { get; set; }
        public int? Tipo_de_Dispositivo { get; set; }
        public string Tipo_de_Dispositivo_Tipo { get; set; }
        public bool? Estado_Token { get; set; }

    }
}
