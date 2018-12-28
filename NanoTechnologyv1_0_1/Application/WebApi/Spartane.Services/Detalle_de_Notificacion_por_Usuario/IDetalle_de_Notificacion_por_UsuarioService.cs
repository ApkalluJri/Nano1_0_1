using System;
using Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_de_Notificacion_por_Usuario
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_Notificacion_por_UsuarioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario entity);
        Int32 Update(Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario entity);
        IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_UsuarioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_de_Notificacion_por_Usuario.Detalle_de_Notificacion_por_Usuario> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
