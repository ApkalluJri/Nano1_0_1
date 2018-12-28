using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Rol_de_Usuario
{
    /// <summary>
    /// Rol_de_Usuario table
    /// </summary>
    public class Rol_de_Usuario: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

