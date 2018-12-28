using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estilo_de_Articulo
{
    public partial class Estilo_de_ArticuloMap : EntityTypeConfiguration<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo>
    {
        public Estilo_de_ArticuloMap()
        {
            this.ToTable("Estilo_de_Articulo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
