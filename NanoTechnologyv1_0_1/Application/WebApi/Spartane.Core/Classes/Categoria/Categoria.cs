using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTArchivos;
using Spartane.Core.Classes.Color;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Categoria
{
    /// <summary>
    /// Categoria table
    /// </summary>
    public class Categoria: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Icono { get; set; }
        public int? Color_Franja { get; set; }
        public int? Imagen { get; set; }

        [ForeignKey("Icono")]
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos Icono_TTArchivos { get; set; }
        [ForeignKey("Color_Franja")]
        public virtual Spartane.Core.Classes.Color.Color Color_Franja_Color { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos Imagen_TTArchivos { get; set; }

    }
}

