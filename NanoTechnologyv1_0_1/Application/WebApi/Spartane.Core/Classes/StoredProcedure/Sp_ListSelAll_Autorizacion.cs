﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllAutorizacion : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Autorizacion_Clave { get; set; }
        public string Autorizacion_Descripcion { get; set; }

    }
}
