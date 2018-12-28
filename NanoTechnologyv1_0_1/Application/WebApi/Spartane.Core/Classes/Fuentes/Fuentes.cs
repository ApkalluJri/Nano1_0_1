using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_de_Contenido;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Fuentes
{
    /// <summary>
    /// Fuentes table
    /// </summary>
    public class Fuentes: BaseEntity
    {
        public int Clave { get; set; }
        public int? Articulo { get; set; }
        public string Fuente { get; set; }

        [ForeignKey("Articulo")]
        public virtual Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido Articulo_Registro_de_Contenido { get; set; }

    }
}

