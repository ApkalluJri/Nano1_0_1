using System;
using Spartane.Core.Classes.Tipo_de_Dispositivo;
using System.Collections.Generic;


namespace Spartane.Services.Tipo_de_Dispositivo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_DispositivoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo entity);
        Int32 Update(Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo entity);
        IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_DispositivoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Tipo_de_Dispositivo.Tipo_de_Dispositivo> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
