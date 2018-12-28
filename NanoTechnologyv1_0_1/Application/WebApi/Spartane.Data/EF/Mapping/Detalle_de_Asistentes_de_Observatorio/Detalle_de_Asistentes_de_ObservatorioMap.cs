using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Asistentes_de_Observatorio
{
    public partial class Detalle_de_Asistentes_de_ObservatorioMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio>
    {
        public Detalle_de_Asistentes_de_ObservatorioMap()
        {
            this.ToTable("Detalle_de_Asistentes_de_Observatorio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
