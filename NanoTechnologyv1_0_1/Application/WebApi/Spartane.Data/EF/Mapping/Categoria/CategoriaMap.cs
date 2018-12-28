using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Categoria
{
    public partial class CategoriaMap : EntityTypeConfiguration<Spartane.Core.Classes.Categoria.Categoria>
    {
        public CategoriaMap()
        {
            this.ToTable("Categoria");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
