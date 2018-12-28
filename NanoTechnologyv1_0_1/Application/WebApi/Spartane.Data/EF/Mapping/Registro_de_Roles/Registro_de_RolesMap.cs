using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Registro_de_Roles
{
    public partial class Registro_de_RolesMap : EntityTypeConfiguration<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles>
    {
        public Registro_de_RolesMap()
        {
            this.ToTable("Registro_de_Roles");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
