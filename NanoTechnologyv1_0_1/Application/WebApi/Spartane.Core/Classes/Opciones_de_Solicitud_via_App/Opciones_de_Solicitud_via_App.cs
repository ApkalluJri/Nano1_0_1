using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Opciones_de_Solicitud_via_App
{
    /// <summary>
    /// Opciones_de_Solicitud_via_App table
    /// </summary>
    public class Opciones_de_Solicitud_via_App: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

