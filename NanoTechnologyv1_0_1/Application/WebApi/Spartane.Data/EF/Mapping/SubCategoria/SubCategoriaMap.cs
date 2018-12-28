using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.SubCategoria
{
    public partial class SubCategoriaMap : EntityTypeConfiguration<Spartane.Core.Classes.SubCategoria.SubCategoria>
    {
        public SubCategoriaMap()
        {
            this.ToTable("SubCategoria");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
