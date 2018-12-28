using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.TTUsuarios
{
    public partial class TTUsuariosMap : EntityTypeConfiguration<Spartane.Core.Classes.TTUsuarios.TTUsuarios>
    {
        public TTUsuariosMap()
        {
            this.ToTable("TTUsuarios");
            this.HasKey(a => a.IdUsuario);
            this.Ignore(a => a.Id);
        }
    }
}
