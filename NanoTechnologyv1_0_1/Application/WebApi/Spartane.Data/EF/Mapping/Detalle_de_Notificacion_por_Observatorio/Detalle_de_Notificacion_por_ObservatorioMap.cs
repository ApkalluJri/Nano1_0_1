using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Notificacion_por_Observatorio
{
    public partial class Detalle_de_Notificacion_por_ObservatorioMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Notificacion_por_Observatorio.Detalle_de_Notificacion_por_Observatorio>
    {
        public Detalle_de_Notificacion_por_ObservatorioMap()
        {
            this.ToTable("Detalle_de_Notificacion_por_Observatorio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
