using System;
using Spartane.Core.Domain.SpartanObject;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.SpartanObject
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartanObjectService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.SpartanObject.SpartanObject> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.SpartanObject.SpartanObject> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.SpartanObject.SpartanObject> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.SpartanObject.SpartanObject GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.SpartanObject.SpartanObject entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.SpartanObject.SpartanObject entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.SpartanObject.SpartanObject> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.SpartanObject.SpartanObject> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.SpartanObject.SpartanObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.SpartanObject.SpartanObject> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
