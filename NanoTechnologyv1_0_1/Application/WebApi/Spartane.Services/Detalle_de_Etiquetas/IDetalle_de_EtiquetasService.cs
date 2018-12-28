using System;
using Spartane.Core.Classes.Detalle_de_Etiquetas;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_de_Etiquetas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_EtiquetasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas entity);
        Int32 Update(Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas entity);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_EtiquetasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas.Detalle_de_Etiquetas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
