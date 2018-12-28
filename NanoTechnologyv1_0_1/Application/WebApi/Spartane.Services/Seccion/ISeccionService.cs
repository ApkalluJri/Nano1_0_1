using System;
using Spartane.Core.Classes.Seccion;
using System.Collections.Generic;


namespace Spartane.Services.Seccion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISeccionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Seccion.Seccion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Seccion.Seccion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Seccion.Seccion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Seccion.Seccion GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Seccion.Seccion entity);
        Int32 Update(Spartane.Core.Classes.Seccion.Seccion entity);
        IList<Spartane.Core.Classes.Seccion.Seccion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Seccion.Seccion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Seccion.SeccionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Seccion.Seccion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
