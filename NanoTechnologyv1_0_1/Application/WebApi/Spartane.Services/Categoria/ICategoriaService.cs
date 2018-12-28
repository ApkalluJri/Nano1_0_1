using System;
using Spartane.Core.Classes.Categoria;
using System.Collections.Generic;


namespace Spartane.Services.Categoria
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ICategoriaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Categoria.Categoria> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Categoria.Categoria> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Categoria.Categoria> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Categoria.Categoria GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Categoria.Categoria entity);
        Int32 Update(Spartane.Core.Classes.Categoria.Categoria entity);
        IList<Spartane.Core.Classes.Categoria.Categoria> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Categoria.Categoria> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Categoria.CategoriaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Categoria.Categoria> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
