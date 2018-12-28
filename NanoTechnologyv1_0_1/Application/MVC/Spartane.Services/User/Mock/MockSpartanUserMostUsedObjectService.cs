using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserMostUsedObjectService : ISpartanUserMostUsedObjectService
    {
        private IList<Spartan_User_Most_Used_Object> list = null;

        public MockSpartanUserMostUsedObjectService()
        {
            list = new List<Spartan_User_Most_Used_Object>
            {
                new Spartan_User_Most_Used_Object{ Most_Used_ObjectId=1, Order_Shown=1, Object = new Core.Domain.Common.Spartan_Object { Name = "Object #1", ObjectId = 1, Url = "Users/Index"}, User = new Spartane.Core.Domain.Spartan_User.Spartan_User {Id_User = 1, Name = "TotalTech"}},
                new Spartan_User_Most_Used_Object{ Most_Used_ObjectId=2, Order_Shown=2, Object = new Core.Domain.Common.Spartan_Object { Name = "Object #2", ObjectId = 2, Url = "Users/Index"}, User = new Spartane.Core.Domain.Spartan_User.Spartan_User {Id_User = 1, Name = "TotalTech"}},
                new Spartan_User_Most_Used_Object{ Most_Used_ObjectId=3, Order_Shown=3, Object = new Core.Domain.Common.Spartan_Object { Name = "Object #3", ObjectId = 3, Url = "Users/Index"}, User = new Spartane.Core.Domain.Spartan_User.Spartan_User {Id_User = 1, Name = "TotalTech"}},
                new Spartan_User_Most_Used_Object{ Most_Used_ObjectId=4, Order_Shown=4, Object = new Core.Domain.Common.Spartan_Object { Name = "Object #4", ObjectId = 4, Url = "Users/Index"}, User = new Spartane.Core.Domain.Spartan_User.Spartan_User {Id_User = 1, Name = "TotalTech"}},
                new Spartan_User_Most_Used_Object{ Most_Used_ObjectId=5, Order_Shown=5, Object = new Core.Domain.Common.Spartan_Object { Name = "Object #5", ObjectId = 5, Url = "Users/Index"}, User = new Spartane.Core.Domain.Spartan_User.Spartan_User {Id_User = 1, Name = "TotalTech"}},
                new Spartan_User_Most_Used_Object{ Most_Used_ObjectId=6, Order_Shown=6, Object = new Core.Domain.Common.Spartan_Object { Name = "Object #6", ObjectId = 6, Url = "Users/Index"}, User = new Spartane.Core.Domain.Spartan_User.Spartan_User {Id_User = 1, Name = "TotalTech"}}
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Core.Domain.User.Spartan_User_Most_Used_Object> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Core.Domain.User.Spartan_User_Most_Used_Object> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Core.Domain.User.Spartan_User_Most_Used_Object GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Most_Used_ObjectId == Key.Value);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.Most_Used_ObjectId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Core.Domain.User.Spartan_User_Most_Used_Object entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Most_Used_ObjectId = list.Last().Most_Used_ObjectId++;
            list.Add(entity);

            return entity.Most_Used_ObjectId;
        }

        public int Update(Core.Domain.User.Spartan_User_Most_Used_Object entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Most_Used_ObjectId == entity.Most_Used_ObjectId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
