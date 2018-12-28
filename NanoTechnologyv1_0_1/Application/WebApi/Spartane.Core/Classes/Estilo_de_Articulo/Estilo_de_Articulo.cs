using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estilo_de_Articulo
{
    /// <summary>
    /// Estilo_de_Articulo table
    /// </summary>
    public class Estilo_de_Articulo: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

