using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Color
{
    public partial class ColorMap : EntityTypeConfiguration<Spartane.Core.Classes.Color.Color>
    {
        public ColorMap()
        {
            this.ToTable("Color");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
