using System;
using Spartane.Core.Classes.Opciones_de_Solicitud_via_App;
using System.Collections.Generic;


namespace Spartane.Services.Opciones_de_Solicitud_via_App
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IOpciones_de_Solicitud_via_AppService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App entity);
        Int32 Update(Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App entity);
        IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_AppPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Opciones_de_Solicitud_via_App.Opciones_de_Solicitud_via_App> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
