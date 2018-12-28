﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_de_Contenido;
using Spartane.Core.Classes.Observatorio;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario
{
    /// <summary>
    /// Detalle_de_Notificacion_por_Usuario table
    /// </summary>
    public class Detalle_de_Notificacion_por_Usuario: BaseEntity
    {
        public int Clave { get; set; }
        public int? Contenido { get; set; }
        public bool? Notificar { get; set; }
        public int? Observatorio { get; set; }
        public int? ID_del_Cliente { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Contenido")]
        public virtual Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido Contenido_Registro_de_Contenido { get; set; }
        [ForeignKey("Observatorio")]
        public virtual Spartane.Core.Classes.Observatorio.Observatorio Observatorio_Observatorio { get; set; }

    }
}
