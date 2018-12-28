using System;
using System.Collections.Generic;


namespace Spartane.Services.TTArchivos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITTArchivosService
    {
        List<Spartane.Core.Classes.TTArchivos.TTArchivos> Insert(List<Spartane.Core.Classes.InputFile.InputFile> FileList);

        IList<Spartane.Core.Classes.TTArchivos.GetTTArchivos> SelAll(bool ConRelaciones);

        IList<Spartane.Core.Classes.TTArchivos.GetTTArchivos> SelAll(bool ConRelaciones, string FolioId);

        List<Spartane.Core.Classes.TTArchivos.TTArchivos> Update(List<Spartane.Core.Classes.TTArchivos.TTArchivos> ArchivosList);
        
    }
}
