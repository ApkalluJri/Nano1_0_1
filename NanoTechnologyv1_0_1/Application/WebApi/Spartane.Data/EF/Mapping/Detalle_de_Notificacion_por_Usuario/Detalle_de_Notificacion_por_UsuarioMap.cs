using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_de_Notificacion_por_Usuario
{
    public partial class Detalle_de_Notificacion_por_UsuarioMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario>
    {
        public Detalle_de_Notificacion_por_UsuarioMap()
        {
            this.ToTable("Detalle_de_Notificacion_por_Usuario");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
