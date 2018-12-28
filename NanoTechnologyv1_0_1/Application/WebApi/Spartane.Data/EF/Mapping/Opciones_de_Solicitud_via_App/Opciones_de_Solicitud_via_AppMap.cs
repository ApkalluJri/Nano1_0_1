using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Opciones_de_Solicitud_via_App
{
    public partial class Opciones_de_Solicitud_via_AppMap : EntityTypeConfiguration<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App>
    {
        public Opciones_de_Solicitud_via_AppMap()
        {
            this.ToTable("Opciones_de_Solicitud_via_App");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
