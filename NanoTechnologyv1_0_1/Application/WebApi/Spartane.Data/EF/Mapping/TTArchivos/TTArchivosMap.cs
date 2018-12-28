using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.TTUsuarios
{
    public partial class TTArchivosMap : EntityTypeConfiguration<Spartane.Core.Classes.TTArchivos.TTArchivos>
    {
        public TTArchivosMap()
        {
            this.ToTable("TTArchivos");
            this.HasKey(a => a.Folio);
            this.Ignore(a => a.Id);
        }
    }
}
