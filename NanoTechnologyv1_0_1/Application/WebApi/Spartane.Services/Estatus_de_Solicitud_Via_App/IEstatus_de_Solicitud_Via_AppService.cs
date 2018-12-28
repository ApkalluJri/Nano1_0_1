using System;
using Spartane.Core.Classes.Estatus_de_Solicitud_Via_App;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_de_Solicitud_Via_App
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_de_Solicitud_Via_AppService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App entity);
        Int32 Update(Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App entity);
        IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_AppPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_de_Solicitud_Via_App.Estatus_de_Solicitud_Via_App> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
