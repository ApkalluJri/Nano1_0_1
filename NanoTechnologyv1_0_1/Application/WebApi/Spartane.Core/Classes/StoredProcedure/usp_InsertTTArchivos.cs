using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class usp_InsertTTArchivos : BaseEntity
    {
        public int Folio { set; get; }

        public string Nombre { set; get; }
    }
}

