using System;
using System.Collections.Generic;
using System.Text;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TTReportes
{
    public class DockStateWithTemplate : DockState
    {
        public int idReporte { get; set; }
        public bool WithTemplate { get; set; }
        public bool esTexto { get; set; }

        public DockStateWithTemplate(int idReporte,bool Closed, bool Collapsed, string DockZoneID, int ExpandedHeight, Unit Height, int Index,
            Unit Left, bool Pinned, bool Resizable, string Tag, string Text, string Title, Unit Top, string UniqueName, Unit Width
            , bool WithTemplate, bool esTexto)
        {
            this.idReporte = idReporte;
            this.Closed = Closed;
            this.Collapsed = Collapsed;
            this.DockZoneID = DockZoneID;
            this.ExpandedHeight = ExpandedHeight;
            this.Height = Height;
            this.Index = Index;
            this.Left = Left;
            this.Pinned = Pinned;
            this.Resizable = Resizable;
            this.Tag = Tag;
            this.Text = Text;
            this.Title = Title;
            this.Top = Top;
            this.UniqueName = UniqueName;
            this.Width = Width;
            this.WithTemplate = WithTemplate;
            this.esTexto = esTexto;
        }

        public static DataSet SeeAll(int idReporte)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Headers_Docks";
            com.Parameters.AddWithValue("@idReporte", idReporte);
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }

        public static DataSet SeeAllFooter(int idReporte)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Footers_Docks";
            com.Parameters.AddWithValue("@idReporte", idReporte);
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }

    }
}
