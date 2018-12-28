using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Observatorio
{
    public partial class ObservatorioMap : EntityTypeConfiguration<Spartane.Core.Classes.Observatorio.Observatorio>
    {
        public ObservatorioMap()
        {
            this.ToTable("Observatorio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
