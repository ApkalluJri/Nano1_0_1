using System;
using Spartane.Core.Classes.Observatorio;
using System.Collections.Generic;


namespace Spartane.Services.Observatorio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IObservatorioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Observatorio.Observatorio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Observatorio.Observatorio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Observatorio.Observatorio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Observatorio.Observatorio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Observatorio.Observatorio entity);
        Int32 Update(Spartane.Core.Classes.Observatorio.Observatorio entity);
        IList<Spartane.Core.Classes.Observatorio.Observatorio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Observatorio.Observatorio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Observatorio.ObservatorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Observatorio.Observatorio> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
