using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllApp : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int FolioContenido { get; set; }
        public string titulo { get; set; }
       public string descripcion { get; set; }
       public int? ImagenMiniaturaFolio { get; set; }
       public string Imagen_Miniatura { get; set; }
       public string estilo { get; set; }
       public int? PDFFolio { get; set; }
       public string PDF { get; set; }
       public string CategoriaDescripcion { get; set; }
       public int? CategoriaIconoFolio { get; set; }
       public string CategoriaIcono { get; set; }
       public string CategoriaColorIcono { get; set; }
       public int? CategoriaImagenFolio { get; set; }
       public string CategoriaImagen { get; set; }
       public DateTime? Fecha_de_Inicio_de_Publicacion { get; set; }
    }

   public class SpSelObservatorioContenido : BaseEntity
   {
       public string Descripcion { get; set; }
       public int? IconoFolio { get; set; }
       public string Icono { get; set; }
       public string Color { get; set; }
   }

   public class SpSelEtiquetaContenido : BaseEntity
   {
       public string Descripcion { get; set; }
   }
}
