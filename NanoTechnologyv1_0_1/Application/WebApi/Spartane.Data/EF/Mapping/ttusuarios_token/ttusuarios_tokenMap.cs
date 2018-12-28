using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.ttusuarios_token
{
    public partial class ttusuarios_tokenMap : EntityTypeConfiguration<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token>
    {
        public ttusuarios_tokenMap()
        {
            this.ToTable("ttusuarios_token");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
