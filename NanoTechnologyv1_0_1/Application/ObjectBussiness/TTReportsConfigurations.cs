using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TTReportes
{
    public class TTReportsConfigurations
    {
        private String text;
        private String fullPath;
        private String fullPathDT;
        private TTReportsConfigurationsEnumFormatDate format;
        private TTReportsConfigurationsEnumOrderBy orderBy;
        private int? rango;
        public String Text
        {
            get { return text; }
            set { text = value; }
        }
        public String FullPath
        {
            get { return fullPath; }
            set { fullPath = value; }
        }
        public String FullPathDT
        {
            get { return fullPathDT; }
            set { fullPathDT = value; }
        }
        public TTReportsConfigurationsEnumFormatDate Format
        {
            get { return format; }
            set { format = value; }
        }
        public TTReportsConfigurationsEnumOrderBy OrderBy
        {
            get { return orderBy; }
            set { orderBy = value; }
        }
        public int? Rango
        {
            get { return rango; }
            set { rango = value; }
        }

    }
    public class TTReportsConfigurationsFunctions : TTReportsConfigurations
    {
        private TTReportsConfigurationsEnumfunctions function;
        private int? minimo_Alerta;
        private int? maximo_Alerta;
        private Boolean mostrar_Vacios;
        public TTReportsConfigurationsEnumfunctions Function
        {
            get { return function; }
            set { function = value; }
        }
        public int? Minimo_Alerta
        {
            get { return minimo_Alerta; }
            set { minimo_Alerta = value; }
        }
        public int? Maximo_Alerta
        {
            get { return maximo_Alerta; }
            set { maximo_Alerta = value; }
        }
        public Boolean Mostrar_Vacios
        {
            get { return mostrar_Vacios; }
            set { mostrar_Vacios = value; }
        }
    }
    public class TTReportsConfigurationsColumns : TTReportsConfigurations
    {
        private TTReportsConfigurationsEnumfunctions function;
        private Boolean subtotal;
        private Boolean total;
        private int? minimo_Alerta;
        private int? maximo_Alerta;
        private Boolean mostrar_Vacios;
        public TTReportsConfigurationsEnumfunctions Function
        {
            get { return function; }
            set { function = value; }
        }
        public Boolean SubTotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        public Boolean Total
        {
            get { return total; }
            set { total = value; }
        }
        public int? Minimo_Alerta
        {
            get { return minimo_Alerta; }
            set { minimo_Alerta = value; }
        }
        public int? Maximo_Alerta
        {
            get { return maximo_Alerta; }
            set { maximo_Alerta = value; }
        }
        public Boolean Mostrar_Vacios
        {
            get { return mostrar_Vacios; }
            set { mostrar_Vacios = value; }
        }
    }
    public class TTReportsConfigurationsRows : TTReportsConfigurations
    {
    }
    public enum TTReportsConfigurationsEnumFormatDate
    {
        None = 0,
        Dia = 1,
        Semana = 2,
        Mes = 3,
        //Bimestre = 4,
        //Semestre = 5,
        Año = 6,
        AñoMesDia = 7,
        AñoMes = 8,
        MesDia = 9,
        DiasContraHoy = 10

    }
    public enum TTReportsConfigurationsEnumOrderBy
    {
        None = 0,
        Ascendente = 1,
        descendente = 2,
    }

    public enum TTReportsConfigurationsEnumfunctions
    {
        None = 0,
        Conteo = 1,
        Suma = 2,
        Max = 3,
        Min = 4,
        Promedio = 5,
        ConteoDistinto = 6
    }
    public enum TTReportsConfigurationsEnumSubPresentation
    {
        None = 0,
        Detalle = 1,
        Cruzado = 2,
        PieChart = 3,
        Barras = 4,
        Lines = 5
    }
    internal class TTReportsConfigurationsPieData
    {
        private ArrayList texts;
        private ArrayList values;
        private ArrayList colors;
        private ArrayList displacements;
        public ArrayList Texts
        {
            get { return texts; }
            set { texts = value; }
        }
        public ArrayList Values
        {
            get { return values; }
            set { values = value; }
        }
        public ArrayList Colors
        {
            get { return colors; }
            set { colors = value; }
        }
        public ArrayList Displacements
        {
            get { return displacements; }
            set { displacements = value; }
        }
    }
    internal class TTReportsConfigurationsAlarms
    {
        private String colName;
        private Decimal valColumn;
        private Boolean isUnderRange;
        public String ColName
        {
            get { return colName; }
            set { colName = value; }
        }
        public Decimal ValColumn
        {
            get { return valColumn; }
            set { valColumn = value; }
        }
        public Boolean IsUnderRange
        {
            get { return isUnderRange; }
            set { isUnderRange = value; }
        }
    }

    public class TTReportsConfigurationscells
    {
        public double CM { get; set; }        

        public DataSet SeeAll(int idReporte,string tipo)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Headers";
            com.Parameters.AddWithValue("@idReporte", idReporte);
            com.Parameters.AddWithValue("@tipo", tipo);
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }

        public DataSet SeeAllFooter(int idReporte, string tipo)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Footers";
            com.Parameters.AddWithValue("@idReporte", idReporte);
            com.Parameters.AddWithValue("@tipo", tipo);
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }

    }

    public class TTReportsConfigurationsMatriz
    {
        public static DataSet SeeAll(int idReporte)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Headers_Matriz";
            com.Parameters.AddWithValue("@idReporte", idReporte);
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }

        public static DataSet SeeAllFooter(int idReporte)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Footers_Matriz";
            com.Parameters.AddWithValue("@idReporte", idReporte);
            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }
    }

    public class TTReportsConfigurationsZones
    {
        public string Key { get; set; }
        public string Celda { get; set; }

        public DataSet SeeAll(int idReporte)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Headers_Zones";
            com.Parameters.AddWithValue("@idReporte", idReporte);

            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }

        public DataSet SeeAllFooter(int idReporte)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Footers_Zones";
            com.Parameters.AddWithValue("@idReporte", idReporte);

            com.CommandType = CommandType.StoredProcedure;
            return db.Consulta(com);
        }

    }
}
