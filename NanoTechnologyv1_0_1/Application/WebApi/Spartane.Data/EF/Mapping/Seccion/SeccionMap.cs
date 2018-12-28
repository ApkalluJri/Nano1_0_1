using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Seccion
{
    public partial class SeccionMap : EntityTypeConfiguration<Spartane.Core.Classes.Seccion.Seccion>
    {
        public SeccionMap()
        {
            this.ToTable("Seccion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
