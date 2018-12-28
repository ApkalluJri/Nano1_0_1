using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_Selallttusuarios_token_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_Token_Campo { get; set; }
        public int? Id_Usuario { get; set; }
        public string Token { get; set; }
        public string Identificador { get; set; }
        public bool? Estado_Logico { get; set; }
        public int? TipoDispositivo { get; set; }
        public int? Id_Usuario_TTUsuarios { get; set; }
        public string Id_Usuario_TTUsuarios_Nombre { get; set; }
        public int? Id { get; set; }

    }
}
