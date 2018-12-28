using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Observatorio
{
    public partial class Tipo_de_ObservatorioMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Observatorio.Tipo_de_Observatorio>
    {
        public Tipo_de_ObservatorioMap()
        {
            this.ToTable("Tipo_de_Observatorio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
