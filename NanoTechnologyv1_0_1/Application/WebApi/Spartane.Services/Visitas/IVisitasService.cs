using System;
using Spartane.Core.Classes.Visitas;
using System.Collections.Generic;


namespace Spartane.Services.Visitas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IVisitasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Visitas.Visitas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Visitas.Visitas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Visitas.Visitas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Visitas.Visitas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Visitas.Visitas entity);
        Int32 Update(Spartane.Core.Classes.Visitas.Visitas entity);
        IList<Spartane.Core.Classes.Visitas.Visitas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Visitas.Visitas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Visitas.VisitasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Visitas.Visitas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
