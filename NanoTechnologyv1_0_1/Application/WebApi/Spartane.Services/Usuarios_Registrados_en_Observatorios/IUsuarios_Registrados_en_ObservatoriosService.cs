using System;
using Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios;
using System.Collections.Generic;


namespace Spartane.Services.Usuarios_Registrados_en_Observatorios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IUsuarios_Registrados_en_ObservatoriosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios entity);
        Int32 Update(Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios entity);
        IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_ObservatoriosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Usuarios_Registrados_en_Observatorios.Usuarios_Registrados_en_Observatorios> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
