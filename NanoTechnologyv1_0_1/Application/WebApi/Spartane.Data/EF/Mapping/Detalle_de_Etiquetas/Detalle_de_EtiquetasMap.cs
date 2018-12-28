using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Etiquetas
{
    public partial class Detalle_de_EtiquetasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas>
    {
        public Detalle_de_EtiquetasMap()
        {
            this.ToTable("Detalle_de_Etiquetas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
