using System;
using Spartane.Core.Classes.Estatus_Codigo;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_Codigo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_CodigoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo entity);
        Int32 Update(Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo entity);
        IList<Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_Codigo.Estatus_CodigoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_Codigo.Estatus_Codigo> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
