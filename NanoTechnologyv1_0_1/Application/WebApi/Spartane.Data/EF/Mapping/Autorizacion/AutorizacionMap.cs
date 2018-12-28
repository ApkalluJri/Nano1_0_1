using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Autorizacion
{
    public partial class AutorizacionMap : EntityTypeConfiguration<Spartane.Core.Classes.Autorizacion.Autorizacion>
    {
        public AutorizacionMap()
        {
            this.ToTable("Autorizacion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
