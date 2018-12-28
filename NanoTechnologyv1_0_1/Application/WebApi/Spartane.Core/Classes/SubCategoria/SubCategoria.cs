using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Categoria;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.SubCategoria
{
    /// <summary>
    /// SubCategoria table
    /// </summary>
    public class SubCategoria: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Categoria { get; set; }

        [ForeignKey("Categoria")]
        public virtual Spartane.Core.Classes.Categoria.Categoria Categoria_Categoria { get; set; }

    }
}

