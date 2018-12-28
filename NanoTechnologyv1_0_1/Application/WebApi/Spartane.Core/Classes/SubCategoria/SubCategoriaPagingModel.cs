using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.SubCategoria
{
    public class SubCategoriaPagingModel
    {
        public List<Spartane.Core.Classes.SubCategoria.SubCategoria> SubCategorias { set; get; }
        public int RowCount { set; get; }
    }
}
