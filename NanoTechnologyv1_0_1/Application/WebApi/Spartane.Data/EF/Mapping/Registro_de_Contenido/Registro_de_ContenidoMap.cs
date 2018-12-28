using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Registro_de_Contenido
{
    public partial class Registro_de_ContenidoMap : EntityTypeConfiguration<Spartane.Core.Classes.Registro_de_Contenido.Registro_de_Contenido>
    {
        public Registro_de_ContenidoMap()
        {
            this.ToTable("Registro_de_Contenido");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
