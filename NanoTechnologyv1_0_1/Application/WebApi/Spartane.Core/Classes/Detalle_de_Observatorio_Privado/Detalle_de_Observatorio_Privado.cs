using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Observatorio;
using Spartane.Core.Classes.Estatus_Codigo;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_de_Observatorio_Privado
{
    /// <summary>
    /// Detalle_de_Observatorio_Privado table
    /// </summary>
    public class Detalle_de_Observatorio_Privado: BaseEntity
    {
        public int Clave { get; set; }
        public int? Observatorio { get; set; }
        public string Codigo { get; set; }
        public int? Estatus { get; set; }
        public DateTime? Expiracion { get; set; }
        public int? Accesos { get; set; }

        [ForeignKey("Observatorio")]
        public virtual Spartane.Core.Classes.Observatorio.Observatorio Observatorio_Observatorio { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo Estatus_Estatus_Codigo { get; set; }

    }
}

