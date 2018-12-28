using System;
using Spartane.Core.Classes.Detalle_de_Observatorio_Privado;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_de_Observatorio_Privado
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_Observatorio_PrivadoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado entity);
        Int32 Update(Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado entity);
        IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_PrivadoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_de_Observatorio_Privado.Detalle_de_Observatorio_Privado> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
