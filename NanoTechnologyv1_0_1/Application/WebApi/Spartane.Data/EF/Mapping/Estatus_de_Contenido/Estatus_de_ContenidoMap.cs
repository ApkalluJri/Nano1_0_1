using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_de_Contenido
{
    public partial class Estatus_de_ContenidoMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_de_Contenido.Estatus_de_Contenido>
    {
        public Estatus_de_ContenidoMap()
        {
            this.ToTable("Estatus_de_Contenido");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
