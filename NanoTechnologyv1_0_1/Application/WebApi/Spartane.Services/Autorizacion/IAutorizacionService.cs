using System;
using Spartane.Core.Classes.Autorizacion;
using System.Collections.Generic;


namespace Spartane.Services.Autorizacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IAutorizacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Autorizacion.Autorizacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Autorizacion.Autorizacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Autorizacion.Autorizacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Autorizacion.Autorizacion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Autorizacion.Autorizacion entity);
        Int32 Update(Spartane.Core.Classes.Autorizacion.Autorizacion entity);
        IList<Spartane.Core.Classes.Autorizacion.Autorizacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Autorizacion.Autorizacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Autorizacion.AutorizacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Autorizacion.Autorizacion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
