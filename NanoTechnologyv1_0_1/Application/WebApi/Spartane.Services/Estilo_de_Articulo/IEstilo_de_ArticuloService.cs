using System;
using Spartane.Core.Classes.Estilo_de_Articulo;
using System.Collections.Generic;


namespace Spartane.Services.Estilo_de_Articulo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstilo_de_ArticuloService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo entity);
        Int32 Update(Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo entity);
        IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_ArticuloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estilo_de_Articulo.Estilo_de_Articulo> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
