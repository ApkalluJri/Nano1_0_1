using Spartane.Core.Domain.Common;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Common.Mock
{
    public class MockSpartanObjectService : ISpartanObjectService
    {
        private IList<Spartan_Object> list = null;

        public MockSpartanObjectService()
        {
            list = new List<Spartan_Object>
            {
                new Spartan_Object{  ObjectId=1, Url="Object 1" },
                new Spartan_Object{  ObjectId=2, Url="Object 2" },
                new Spartan_Object{  ObjectId=3, Url="Object 3" },
                new Spartan_Object{  ObjectId=4, Url="Object 4" },
                new Spartan_Object{  ObjectId=5, Url="Object 5" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_Object> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_Object> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_Object GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.ObjectId == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.ObjectId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartan_Object entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.ObjectId = list.Last().ObjectId++;
            list.Add(entity);

            return entity.ObjectId;
        }

        public int Update(Spartan_Object entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.ObjectId == entity.ObjectId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
