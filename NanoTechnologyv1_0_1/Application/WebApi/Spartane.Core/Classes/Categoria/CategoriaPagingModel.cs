using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Categoria
{
    public class CategoriaPagingModel
    {
        public List<Spartane.Core.Classes.Categoria.Categoria> Categorias { set; get; }
        public int RowCount { set; get; }
    }
}
