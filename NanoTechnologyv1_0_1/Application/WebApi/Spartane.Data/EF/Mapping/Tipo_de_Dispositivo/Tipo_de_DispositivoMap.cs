using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Dispositivo
{
    public partial class Tipo_de_DispositivoMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo>
    {
        public Tipo_de_DispositivoMap()
        {
            this.ToTable("Tipo_de_Dispositivo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
