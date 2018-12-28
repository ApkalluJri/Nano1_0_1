using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.App
{
    public class AppPagingModel
    {
        public List<Spartane.Core.Classes.App.App> Apps { set; get; }
        public int RowCount { set; get; }
    }
}
