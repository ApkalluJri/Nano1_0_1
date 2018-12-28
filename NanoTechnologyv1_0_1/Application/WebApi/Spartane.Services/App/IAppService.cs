using System;
using Spartane.Core.Classes.App;
using System.Collections.Generic;


namespace Spartane.Services.App
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IAppService
    {

        Spartane.Core.Classes.App.AppPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order, string uri, string ArchivosFiles);
    }
}
