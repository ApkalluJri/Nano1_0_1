using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_de_Contenido;
using Spartane.Core.Classes.Etiquetas;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_de_Etiquetas
{
    /// <summary>
    /// Detalle_de_Etiquetas table
    /// </summary>
    public class Detalle_de_Etiquetas: BaseEntity
    {
        public int Clave { get; set; }
        public int? Articulo { get; set; }
        public int? Etiqueta { get; set; }

        [ForeignKey("Articulo")]
        public virtual Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido Articulo_Registro_de_Contenido { get; set; }
        [ForeignKey("Etiqueta")]
        public virtual Spartane.Core.Classes.Etiquetas.Etiquetas Etiqueta_Etiquetas { get; set; }

    }
}

