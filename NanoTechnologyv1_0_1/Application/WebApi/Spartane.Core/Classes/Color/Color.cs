using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Color
{
    /// <summary>
    /// Color table
    /// </summary>
    public class Color: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string Codigo_RGB { get; set; }


    }
}

