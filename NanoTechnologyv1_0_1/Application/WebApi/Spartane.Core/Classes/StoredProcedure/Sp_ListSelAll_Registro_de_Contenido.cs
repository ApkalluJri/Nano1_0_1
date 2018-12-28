using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegistro_de_Contenido : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Registro_de_Contenido_Folio { get; set; }
        public int? Registro_de_Contenido_Usuario_que_Registra { get; set; }
        public string Registro_de_Contenido_Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Registro_de_Contenido_Fecha_de_Registro { get; set; }
        public string Registro_de_Contenido_Hora_de_Registro { get; set; }
        public int? Registro_de_Contenido_Categoria { get; set; }
        public string Registro_de_Contenido_Categoria_Descripcion { get; set; }
        public string Registro_de_Contenido_Descripcion_de_Solicitud { get; set; }
        public int? Registro_de_Contenido_Reportero_Asignado { get; set; }
        public string Registro_de_Contenido_Reportero_Asignado_Nombre { get; set; }
        public DateTime? Registro_de_Contenido_Fecha_de_Compromiso { get; set; }
        public int? Registro_de_Contenido_Estatus { get; set; }
        public string Registro_de_Contenido_Estatus_Descripcion { get; set; }
        public int? Registro_de_Contenido_Administrador_de_Observatorio { get; set; }
        public string Registro_de_Contenido_Administrador_de_Observatorio_Nombre { get; set; }
        public int? Registro_de_Contenido_Reportero { get; set; }
        public string Registro_de_Contenido_Reportero_Nombre { get; set; }
        public string Registro_de_Contenido_Titulo { get; set; }
        public string Registro_de_Contenido_Descripcion { get; set; }
        public string Registro_de_Contenido_Contenido { get; set; }
        public int? Registro_de_Contenido_Imagen { get; set; }
        public string Registro_de_Contenido_Imagen_Nombre { get; set; }
        public int? Registro_de_Contenido_Imagen_Miniatura { get; set; }
        public string Registro_de_Contenido_Imagen_Miniatura_Nombre { get; set; }
        public int? Registro_de_Contenido_Estilo { get; set; }
        public string Registro_de_Contenido_Estilo_Descripcion { get; set; }
        public int? Registro_de_Contenido_Adjuntar_PDF { get; set; }
        public string Registro_de_Contenido_Adjuntar_PDF_Nombre { get; set; }
        public bool? Registro_de_Contenido_Captura_Terminada { get; set; }
        public int? Registro_de_Contenido_Autorizado_por { get; set; }
        public string Registro_de_Contenido_Autorizado_por_Nombre { get; set; }
        public DateTime? Registro_de_Contenido_Fecha_de_Revision { get; set; }
        public string Registro_de_Contenido_Hora_de_Revision { get; set; }
        public int? Registro_de_Contenido_Autorizacion { get; set; }
        public string Registro_de_Contenido_Autorizacion_Descripcion { get; set; }
        public string Registro_de_Contenido_Motivo_de_Rechazo { get; set; }
        public DateTime? Registro_de_Contenido_Fecha_de_Inicio_de_Publicacion { get; set; }
        public DateTime? Registro_de_Contenido_Fecha_de_Termino { get; set; }
        public bool? Registro_de_Contenido_Seleccionar_Todos_los_Observatorios { get; set; }
        public int? Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio { get; set; }
        public string Registro_de_Contenido_Filtrar_Usuarios_por_Observatorio_Nombre { get; set; }

    }
}
