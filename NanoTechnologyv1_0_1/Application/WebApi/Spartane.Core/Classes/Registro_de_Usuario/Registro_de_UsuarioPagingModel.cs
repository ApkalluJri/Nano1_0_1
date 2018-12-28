using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Registro_de_Usuario
{
    public class Registro_de_UsuarioPagingModel
    {
        public List<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario> Registro_de_Usuarios { set; get; }
        public int RowCount { set; get; }
    }
}
