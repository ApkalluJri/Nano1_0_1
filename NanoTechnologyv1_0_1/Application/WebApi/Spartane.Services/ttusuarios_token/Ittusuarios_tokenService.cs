using System;
using Spartane.Core.Classes.ttusuarios_token;
using System.Collections.Generic;


namespace Spartane.Services.ttusuarios_token
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface Ittusuarios_tokenService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.ttusuarios_token.ttusuarios_token GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.ttusuarios_token.ttusuarios_token entity);
        Int32 Update(Spartane.Core.Classes.ttusuarios_token.ttusuarios_token entity);
        IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.ttusuarios_token.ttusuarios_tokenPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.ttusuarios_token.ttusuarios_token> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
