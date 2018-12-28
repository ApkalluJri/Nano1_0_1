using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Etiquetas_Contenido
{
    public partial class Detalle_de_Etiquetas_ContenidoMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido>
    {
        public Detalle_de_Etiquetas_ContenidoMap()
        {
            this.ToTable("Detalle_de_Etiquetas_Contenido");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
