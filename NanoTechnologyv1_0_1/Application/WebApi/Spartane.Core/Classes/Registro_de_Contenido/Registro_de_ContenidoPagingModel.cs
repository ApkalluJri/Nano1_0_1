using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Registro_de_Contenido
{
    public class Registro_de_ContenidoPagingModel
    {
        public List<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido> Registro_de_Contenidos { set; get; }
        public int RowCount { set; get; }
    }
}
