using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Codigos_por_Cliente
{
    public partial class Codigos_por_ClienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente>
    {
        public Codigos_por_ClienteMap()
        {
            this.ToTable("Codigos_por_Cliente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
