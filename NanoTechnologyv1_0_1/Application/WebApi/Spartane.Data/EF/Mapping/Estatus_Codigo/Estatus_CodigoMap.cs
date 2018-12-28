using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Codigo
{
    public partial class Estatus_CodigoMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo>
    {
        public Estatus_CodigoMap()
        {
            this.ToTable("Estatus_Codigo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
