using System;
using Spartane.Core.Classes.Etiquetas;
using System.Collections.Generic;


namespace Spartane.Services.Etiquetas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEtiquetasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Etiquetas.Etiquetas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Etiquetas.Etiquetas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Etiquetas.Etiquetas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Etiquetas.Etiquetas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Etiquetas.Etiquetas entity);
        Int32 Update(Spartane.Core.Classes.Etiquetas.Etiquetas entity);
        IList<Spartane.Core.Classes.Etiquetas.Etiquetas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Etiquetas.Etiquetas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Etiquetas.EtiquetasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Etiquetas.Etiquetas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
