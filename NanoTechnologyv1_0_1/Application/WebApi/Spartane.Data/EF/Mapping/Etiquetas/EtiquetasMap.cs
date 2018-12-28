using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Etiquetas
{
    public partial class EtiquetasMap : EntityTypeConfiguration<Spartane.Core.Classes.Etiquetas.Etiquetas>
    {
        public EtiquetasMap()
        {
            this.ToTable("Etiquetas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
