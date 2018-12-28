using System;
using Spartane.Core.Classes.Color;
using System.Collections.Generic;


namespace Spartane.Services.Color
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IColorService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Color.Color> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Color.Color> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Color.Color> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Color.Color GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Color.Color entity);
        Int32 Update(Spartane.Core.Classes.Color.Color entity);
        IList<Spartane.Core.Classes.Color.Color> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Color.Color> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Color.ColorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Color.Color> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
