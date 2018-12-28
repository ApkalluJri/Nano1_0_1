using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Observatorio
{
    public class ObservatorioPagingModel
    {
        public List<Spartane.Core.Classes.Observatorio.Observatorio> Observatorios { set; get; }
        public int RowCount { set; get; }
    }
}
