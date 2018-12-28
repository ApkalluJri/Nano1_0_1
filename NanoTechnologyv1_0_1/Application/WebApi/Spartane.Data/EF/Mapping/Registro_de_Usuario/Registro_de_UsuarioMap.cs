using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Registro_de_Usuario
{
    public partial class Registro_de_UsuarioMap : EntityTypeConfiguration<Spartane.Core.Classes.Registro_de_Usuario.Registro_de_Usuario>
    {
        public Registro_de_UsuarioMap()
        {
            this.ToTable("Registro_de_Usuario");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
