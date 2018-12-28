using System;
using Spartane.Core.Classes.Codigos_por_Cliente;
using System.Collections.Generic;


namespace Spartane.Services.Codigos_por_Cliente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICodigos_por_ClienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente entity);
        Int32 Update(Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente entity);
        IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_ClientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Codigos_por_Cliente.Codigos_por_Cliente> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
