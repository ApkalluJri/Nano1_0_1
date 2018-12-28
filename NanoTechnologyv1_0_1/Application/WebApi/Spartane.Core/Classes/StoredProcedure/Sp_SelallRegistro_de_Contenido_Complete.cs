using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRegistro_de_Contenido_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Nombre { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Categoria { get; set; }
        public string Categoria_Descripcion { get; set; }
        public string Descripcion_de_Solicitud { get; set; }
        public int? Reportero_Asignado { get; set; }
        public string Reportero_Asignado_Nombre { get; set; }
        public DateTime? Fecha_de_Compromiso { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int? Administrador_de_Observatorio { get; set; }
        public string Administrador_de_Observatorio_Nombre { get; set; }
        public int? Reportero { get; set; }
        public string Reportero_Nombre { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public int? Imagen { get; set; }
        public string Imagen_Nombre { get; set; }
        public int? Imagen_Miniatura { get; set; }
        public string Imagen_Miniatura_Nombre { get; set; }
        public int? Estilo { get; set; }
        public string Estilo_Descripcion { get; set; }
        public int? Adjuntar_PDF { get; set; }
        public string Adjuntar_PDF_Nombre { get; set; }
        public bool? Captura_Terminada { get; set; }
        public int? Autorizado_por { get; set; }
        public string Autorizado_por_Nombre { get; set; }
        public DateTime? Fecha_de_Revision { get; set; }
        public string Hora_de_Revision { get; set; }
        public int? Autorizacion { get; set; }
        public string Autorizacion_Descripcion { get; set; }
        public string Motivo_de_Rechazo { get; set; }
        public DateTime? Fecha_de_Inicio_de_Publicacion { get; set; }
        public DateTime? Fecha_de_Termino { get; set; }
        public bool? Seleccionar_Todos_los_Observatorios { get; set; }
        public int? Filtrar_Usuarios_por_Observatorio { get; set; }
        public string Filtrar_Usuarios_por_Observatorio_Nombre { get; set; }

    }
}
