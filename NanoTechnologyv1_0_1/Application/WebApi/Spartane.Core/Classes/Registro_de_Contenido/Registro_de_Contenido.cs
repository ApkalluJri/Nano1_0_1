using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTUsuarios;
using Spartane.Core.Classes.Categoria;
using Spartane.Core.Classes.Estatus_de_Contenido;
using Spartane.Core.Classes.TTArchivos;
using Spartane.Core.Classes.Estilo_de_Articulo;
using Spartane.Core.Classes.Autorizacion;
using Spartane.Core.Classes.Observatorio;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Registro_de_Contenido
{
    /// <summary>
    /// Registro_de_Contenido table
    /// </summary>
    public class Registro_de_Contenido: BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Categoria { get; set; }
        public string Descripcion_de_Solicitud { get; set; }
        public int? Reportero_Asignado { get; set; }
        public DateTime? Fecha_de_Compromiso { get; set; }
        public int? Estatus { get; set; }
        public int? Administrador_de_Observatorio { get; set; }
        public int? Reportero { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public int? Imagen { get; set; }
        public int? Imagen_Miniatura { get; set; }
        public int? Estilo { get; set; }
        public int? Adjuntar_PDF { get; set; }
        public bool? Captura_Terminada { get; set; }
        public int? Autorizado_por { get; set; }
        public DateTime? Fecha_de_Revision { get; set; }
        public string Hora_de_Revision { get; set; }
        public int? Autorizacion { get; set; }
        public string Motivo_de_Rechazo { get; set; }
        public DateTime? Fecha_de_Inicio_de_Publicacion { get; set; }
        public DateTime? Fecha_de_Termino { get; set; }
        public bool? Seleccionar_Todos_los_Observatorios { get; set; }
        public int? Filtrar_Usuarios_por_Observatorio { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Usuario_que_Registra_TTUsuarios { get; set; }
        [ForeignKey("Categoria")]
        public virtual Spartane.Core.Classes.Categoria.Categoria Categoria_Categoria { get; set; }
        [ForeignKey("Reportero_Asignado")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Reportero_Asignado_TTUsuarios { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_de_Contenido.Estatus_de_Contenido Estatus_Estatus_de_Contenido { get; set; }
        [ForeignKey("Administrador_de_Observatorio")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Administrador_de_Observatorio_TTUsuarios { get; set; }
        [ForeignKey("Reportero")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Reportero_TTUsuarios { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos Imagen_TTArchivos { get; set; }
        [ForeignKey("Imagen_Miniatura")]
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos Imagen_Miniatura_TTArchivos { get; set; }
        [ForeignKey("Estilo")]
        public virtual Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo Estilo_Estilo_de_Articulo { get; set; }
        [ForeignKey("Adjuntar_PDF")]
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos Adjuntar_PDF_TTArchivos { get; set; }
        [ForeignKey("Autorizado_por")]
        public virtual Spartane.Core.Classes.TTUsuarios.TTUsuarios Autorizado_por_TTUsuarios { get; set; }
        [ForeignKey("Autorizacion")]
        public virtual Spartane.Core.Classes.Autorizacion.Autorizacion Autorizacion_Autorizacion { get; set; }
        [ForeignKey("Filtrar_Usuarios_por_Observatorio")]
        public virtual Spartane.Core.Classes.Observatorio.Observatorio Filtrar_Usuarios_por_Observatorio_Observatorio { get; set; }

    }
}

