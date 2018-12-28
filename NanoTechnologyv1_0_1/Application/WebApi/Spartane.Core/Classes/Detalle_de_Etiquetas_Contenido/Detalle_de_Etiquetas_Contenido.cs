using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido
{
    /// <summary>
    /// Detalle_de_Etiquetas_Contenido table
    /// </summary>
    public class Detalle_de_Etiquetas_Contenido: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

