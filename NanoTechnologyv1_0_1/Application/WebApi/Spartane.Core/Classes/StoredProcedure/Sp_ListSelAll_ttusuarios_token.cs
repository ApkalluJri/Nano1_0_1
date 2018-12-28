using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllttusuarios_token : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int ttusuarios_token_Folio { get; set; }
        public int? ttusuarios_token_Usuario_Token_Campo { get; set; }
        public int? ttusuarios_token_Id_Usuario { get; set; }
        public string ttusuarios_token_Token { get; set; }
        public string ttusuarios_token_Identificador { get; set; }
        public bool? ttusuarios_token_Estado_Logico { get; set; }
        public int? ttusuarios_token_TipoDispositivo { get; set; }
        public int? ttusuarios_token_Id_Usuario_TTUsuarios { get; set; }
        public string ttusuarios_token_Id_Usuario_TTUsuarios_Nombre { get; set; }
        public int? ttusuarios_token_Id { get; set; }

    }
}
