using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_de_Solicitud_Via_App
{
    public partial class Estatus_de_Solicitud_Via_AppMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App>
    {
        public Estatus_de_Solicitud_Via_AppMap()
        {
            this.ToTable("Estatus_de_Solicitud_Via_App");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
