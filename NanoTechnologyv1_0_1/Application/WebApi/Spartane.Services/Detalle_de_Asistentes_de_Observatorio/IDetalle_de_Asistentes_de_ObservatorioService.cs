using System;
using Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_de_Asistentes_de_Observatorio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_Asistentes_de_ObservatorioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio entity);
        Int32 Update(Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio entity);
        IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_ObservatorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_de_Asistentes_de_Observatorio.Detalle_de_Asistentes_de_Observatorio> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
