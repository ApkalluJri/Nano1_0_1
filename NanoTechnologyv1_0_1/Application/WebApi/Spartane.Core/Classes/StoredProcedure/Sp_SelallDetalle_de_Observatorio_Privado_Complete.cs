﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_de_Observatorio_Privado_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int Observatorio { get; set; }
        public string Codigo { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public DateTime? Expiracion { get; set; }
        public int? Accesos { get; set; }

    }
}
