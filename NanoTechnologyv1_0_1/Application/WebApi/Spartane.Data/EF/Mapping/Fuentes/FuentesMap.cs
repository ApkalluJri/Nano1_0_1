using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Fuentes
{
    public partial class FuentesMap : EntityTypeConfiguration<Spartane.Core.Classes.Fuentes.Fuentes>
    {
        public FuentesMap()
        {
            this.ToTable("Fuentes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
