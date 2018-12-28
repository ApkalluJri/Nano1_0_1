using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Rol_de_Usuario
{
    public partial class Rol_de_UsuarioMap : EntityTypeConfiguration<Spartane.Core.Classes.Rol_de_Usuario.Rol_de_Usuario>
    {
        public Rol_de_UsuarioMap()
        {
            this.ToTable("Rol_de_Usuario");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
