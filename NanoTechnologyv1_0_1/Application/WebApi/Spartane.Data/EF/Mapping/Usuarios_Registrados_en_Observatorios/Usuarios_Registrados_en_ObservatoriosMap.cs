using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Usuarios_Registrados_en_Observatorios
{
    public partial class Usuarios_Registrados_en_ObservatoriosMap : EntityTypeConfiguration<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios>
    {
        public Usuarios_Registrados_en_ObservatoriosMap()
        {
            this.ToTable("Usuarios_Registrados_en_Observatorios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
