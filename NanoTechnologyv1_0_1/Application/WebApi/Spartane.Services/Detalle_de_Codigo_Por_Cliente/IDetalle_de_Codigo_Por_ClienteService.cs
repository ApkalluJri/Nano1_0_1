using System;
using Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_de_Codigo_Por_Cliente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_Codigo_Por_ClienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente entity);
        Int32 Update(Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente entity);
        IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_ClientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_de_Codigo_Por_Cliente.Detalle_de_Codigo_Por_Cliente> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
