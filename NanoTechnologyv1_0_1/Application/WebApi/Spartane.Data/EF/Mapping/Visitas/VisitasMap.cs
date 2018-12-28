using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Visitas
{
    public partial class VisitasMap : EntityTypeConfiguration<Spartane.Core.Classes.Visitas.Visitas>
    {
        public VisitasMap()
        {
            this.ToTable("Visitas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
