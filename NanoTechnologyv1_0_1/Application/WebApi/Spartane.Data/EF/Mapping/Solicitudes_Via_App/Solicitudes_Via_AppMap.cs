using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Solicitudes_Via_App
{
    public partial class Solicitudes_Via_AppMap : EntityTypeConfiguration<Spartane.Core.Classes.Solicitudes_Via_App.Solicitudes_Via_App>
    {
        public Solicitudes_Via_AppMap()
        {
            this.ToTable("Solicitudes_Via_App");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
