using System;
using Spartane.Core.Classes.Registro_de_Roles;
using System.Collections.Generic;


namespace Spartane.Services.Registro_de_Roles
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegistro_de_RolesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles entity);
        Int32 Update(Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles entity);
        IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Registro_de_Roles.Registro_de_RolesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Registro_de_Roles.Registro_de_Roles> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
