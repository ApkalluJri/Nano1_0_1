using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Observatorio_Privado
{
    public partial class Detalle_de_Observatorio_PrivadoMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado>
    {
        public Detalle_de_Observatorio_PrivadoMap()
        {
            this.ToTable("Detalle_de_Observatorio_Privado");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
