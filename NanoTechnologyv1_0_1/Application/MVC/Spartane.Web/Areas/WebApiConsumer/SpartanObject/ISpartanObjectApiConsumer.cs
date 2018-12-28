using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.SpartanObject
{
    public interface ISpartanObjectApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.SpartanObject.SpartanObject>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.SpartanObject.SpartanObject>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.SpartanObject.SpartanObject> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.SpartanObject.SpartanObjectPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData SpartanObjectInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.SpartanObject.SpartanObject entity, Spartane.Core.Domain.User.GlobalData SpartanObjectInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.SpartanObject.SpartanObject entity, Spartane.Core.Domain.User.GlobalData SpartanObjectInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.SpartanObject.SpartanObject>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.SpartanObject.SpartanObject>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.SpartanObject.SpartanObject>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.SpartanObject.SpartanObjectPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.SpartanObject.SpartanObject>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

