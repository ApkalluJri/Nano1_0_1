using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTUsuarios;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.ttusuarios_token
{
    /// <summary>
    /// ttusuarios_token table
    /// </summary>
    public class ttusuarios_token: BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_Token_Campo { get; set; }
        public int? Id_Usuario { get; set; }
        public string Token { get; set; }
        public string Identificador { get; set; }
        public bool? Estado_Logico { get; set; }
        public int? TipoDispositivo { get; set; }
        public int? Id_Usuario_TTUsuarios { get; set; }
        public int? Id { get; set; }

        [ForeignKey("Id_Usuario_TTUsuarios")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Id_Usuario_TTUsuarios_TTUsuarios { get; set; }

    }
}

