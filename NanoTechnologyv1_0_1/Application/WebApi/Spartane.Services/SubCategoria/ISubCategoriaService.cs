using System;
using Spartane.Core.Classes.SubCategoria;
using System.Collections.Generic;


namespace Spartane.Services.SubCategoria
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISubCategoriaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.SubCategoria.SubCategoria> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.SubCategoria.SubCategoria> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.SubCategoria.SubCategoria> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.SubCategoria.SubCategoria GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.SubCategoria.SubCategoria entity);
        Int32 Update(Spartane.Core.Classes.SubCategoria.SubCategoria entity);
        IList<Spartane.Core.Classes.SubCategoria.SubCategoria> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.SubCategoria.SubCategoria> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.SubCategoria.SubCategoriaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.SubCategoria.SubCategoria> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
