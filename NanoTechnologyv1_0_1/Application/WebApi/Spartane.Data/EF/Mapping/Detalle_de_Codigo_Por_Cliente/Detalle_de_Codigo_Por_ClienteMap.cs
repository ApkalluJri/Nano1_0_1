using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Codigo_Por_Cliente
{
    public partial class Detalle_de_Codigo_Por_ClienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente>
    {
        public Detalle_de_Codigo_Por_ClienteMap()
        {
            this.ToTable("Detalle_de_Codigo_Por_Cliente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
