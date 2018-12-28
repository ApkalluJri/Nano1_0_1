using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Autorizacion
{
    public class AutorizacionPagingModel
    {
        public List<Spartane.Core.Classes.Autorizacion.Autorizacion> Autorizacions { set; get; }
        public int RowCount { set; get; }
    }
}
