using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTUsuarios;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Codigos_por_Cliente
{
    /// <summary>
    /// Codigos_por_Cliente table
    /// </summary>
    public class Codigos_por_Cliente: BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Cliente { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Usuario_que_Registra_TTUsuarios { get; set; }

    }
}

