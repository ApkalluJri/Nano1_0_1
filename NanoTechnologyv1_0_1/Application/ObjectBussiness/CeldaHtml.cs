using System.Data;
using System.Data.SqlClient;

namespace TTReportes
{
    public class CeldaHtml
    {
        public int idReporte { get; set; }
        public string Key { get; set; }
        public int colspan { get; set; }
        public int rowspan { get; set; }
        public string Row { get; set; }

        public CeldaHtml(int idReporte, string prKey, int prColspan, int prRowSpan, string prRow)
        {
            this.idReporte = idReporte;
            this.Key = prKey;
            this.colspan = prColspan;
            this.rowspan = prRowSpan;
            this.Row = prRow;
        }

        public static DataSet SeeAll(int idReporte)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Headers_Celdas";
            com.Parameters.AddWithValue("@idReporte", idReporte);
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }

        public static DataSet SeeAllFooter(int idReporte)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Footers_Celdas";
            com.Parameters.AddWithValue("@idReporte", idReporte);
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }
    }
}