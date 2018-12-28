using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.App
{
    /// <summary>
    /// Color table
    /// </summary>
    public class App: BaseEntity
    {
        public int Folio { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string ImagenMiniatura { get; set; }
        public string Estilo { get; set; }
        public string PDF { get; set; }
        public string CategoriaDescripcion { get; set; }
        public string CategoriaIcono { get; set; }
        public string CategoriaColorIcono { get; set; }
        public string CategoriaImagen { get; set; }
        public List<AppObservatorio> Observatorios { get; set; }
        public List<AppEtiqueta> Etiquetas { get; set; }
        
    }

    public class AppObservatorio : BaseEntity
    {
        public string Descripcion { get; set; }
        public string Icono { get; set; }
        public string Color { get; set; }
    }

    public class AppEtiqueta : BaseEntity
    {
        public string Descripcion { get; set; }
    }


}

