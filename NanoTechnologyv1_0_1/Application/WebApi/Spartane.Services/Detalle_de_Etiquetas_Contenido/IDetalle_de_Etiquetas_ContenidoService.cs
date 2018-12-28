﻿using System;
using Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_de_Etiquetas_Contenido
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_Etiquetas_ContenidoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido entity);
        Int32 Update(Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido entity);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_ContenidoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_de_Etiquetas_Contenido.Detalle_de_Etiquetas_Contenido> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
