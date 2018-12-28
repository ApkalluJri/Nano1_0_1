using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallFuentes_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int Articulo { get; set; }
        public string Fuente { get; set; }

    }
}
