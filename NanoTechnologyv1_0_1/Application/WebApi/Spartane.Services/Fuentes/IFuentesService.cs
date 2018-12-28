using System;
using Spartane.Core.Classes.Fuentes;
using System.Collections.Generic;


namespace Spartane.Services.Fuentes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IFuentesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Fuentes.Fuentes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Fuentes.Fuentes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Fuentes.Fuentes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Fuentes.Fuentes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Fuentes.Fuentes entity);
        Int32 Update(Spartane.Core.Classes.Fuentes.Fuentes entity);
        IList<Spartane.Core.Classes.Fuentes.Fuentes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Fuentes.Fuentes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Fuentes.FuentesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Fuentes.Fuentes> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
