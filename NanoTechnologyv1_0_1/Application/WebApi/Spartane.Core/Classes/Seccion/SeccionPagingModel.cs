using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Seccion
{
    public class SeccionPagingModel
    {
        public List<Spartane.Core.Classes.Seccion.Seccion> Seccions { set; get; }
        public int RowCount { set; get; }
    }
}
