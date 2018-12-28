using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Prismaproj
{
    class TTSearchAdvanced
    {
        public TTSearchAdvanced(TTSecurity.GlobalData GlobalInformation)
        {
            myUserdata = GlobalInformation;
        }
        public TTSearchAdvanced()
        {
            //myUserdata = GlobalInformation;
        }
        private TTFunctions.Conversiones MyConversions = new TTFunctions.Conversiones();
        private TTSecurity.GlobalData myUserdata;
        public TTSecurity.GlobalData Userdata
        {
            get{return myUserdata;}
            set { myUserdata = value; }
        }
        public TTSearchAdvancedData GetStructView(int viewID)
        {
            TTSearchAdvancedData MyView = new TTSearchAdvancedData();
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "spTTVista_X_VistaID";
            com.Parameters.AddWithValue("@VistaID", viewID);
            com.CommandType = CommandType.StoredProcedure;
            ds=db.Consulta(com);
            if (ds.Tables[0].Rows.Count >0 )
            {
                MyView.VistaID = MyConversions.CambiaToShort(ds.Tables[0].Rows[0]["VistaID"]).Value ;
                MyView.Name = ds.Tables[0].Rows[0]["Nombre"].ToString();
                MyView.Default = Boolean.Parse(ds.Tables[0].Rows[0]["Default"].ToString());
                MyView.Empty = Boolean.Parse(ds.Tables[0].Rows[0]["Vacio"].ToString());
                MyView.Obligatory = Boolean.Parse(ds.Tables[0].Rows[0]["Obligatorio"].ToString());
                MyView.ProcessID = MyConversions.CambiaToShort(ds.Tables[0].Rows[0]["ProcesoID"]).Value ;
                MyView.UserID = MyConversions.CambiaToShort(ds.Tables[0].Rows[0]["Usuario"]).Value;
                MyView.Sql = ds.Tables[0].Rows[0]["SQL"].ToString().TrimEnd(' ');
                MyView.FilterID = MyConversions.CambiaToShort(ds.Tables[0].Rows[0]["Filtros"]).Value;
                MyView.ConfigurationID = MyConversions.CambiaToShort(ds.Tables[0].Rows[0]["Configuracion"]).Value;

                MyView.Filter = new ControlsLibrary.objectBussinessTTFiltro();
                MyView.Filter.GlobalInformation = myUserdata;
                MyView.Filter.GetByKey(MyView.FilterID,true);
                MyView.Configuration = new ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn();
                MyView.Configuration.GlobalInformation = myUserdata;
                MyView.Configuration.GetByKey(MyView.ConfigurationID , true);


                com = new SqlCommand();
                com.CommandText = "spTtVista_Detalle_X_VistaID";
                com.Parameters.AddWithValue("@VistaID", viewID);
                com.CommandType = CommandType.StoredProcedure;
                ds = db.Consulta(com);

                MyView.Details = new TTSearchAdvancedDataDetails[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MyView.Details[i] = new TTSearchAdvancedDataDetails();
                    MyView.Details[i].DNTID = MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["DNTID"]).Value;
                    MyView.Details[i].DTID = MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["DTID"]).Value ;
                    MyView.Details[i].NombreDT = ds.Tables[0].Rows[i]["NombreDT"].ToString().TrimEnd(' ');
                    MyView.Details[i].ConditionText = (TTClassSpecials.FiltersTypes.TypesTextFilter)MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["Condicion"]);
                    MyView.Details[i].From = ds.Tables[0].Rows[i]["Orden_Desde"].ToString().TrimEnd(' ');
                    MyView.Details[i].To = ds.Tables[0].Rows[i]["Orden_Hasta"].ToString().TrimEnd(' ');
                    MyView.Details[i].FromDate =MyConversions.CambiaToDatetime(ds.Tables[0].Rows[i]["Orden_Desde_Date"]);
                    MyView.Details[i].ToDate = MyConversions.CambiaToDatetime(ds.Tables[0].Rows[i]["Orden_Hasta_Date"]);
                    MyView.Details[i].Year = MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["Año"]);
                    MyView.Details[i].Month = MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["Mes"]);
                    MyView.Details[i].Week = MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["Semana"]);
                    MyView.Details[i].Order = MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["Orden"]).Value ;
                    MyView.Details[i].Visible = Boolean.Parse(ds.Tables[0].Rows[i]["Visible"].ToString());
                    MyView.Details[i].Presentation = (TTFunctions.TypeControlPresentation) MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["Presentacion"]).Value;
                    MyView.Details[i].Yes_Not = MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["Si_No"].ToString());
                    MyView.Details[i].ControlScreenSearchAdvanced = (ControlsLibrary.TypeControlSearchAdvanced)MyConversions.CambiaToShort(ds.Tables[0].Rows[i]["TipoDeControlBusqueda"].ToString()).Value;

                    //MyView.Details[i].ListaDependientes  = ds.Tables[0].Rows[i]["Lista"].ToString().TrimEnd(' ');
                    SqlCommand cmDep = new SqlCommand();
                    DataSet dsDep;
                    cmDep.CommandText = "spTTVista_ListaDependientes_X_VistaID";
                    cmDep.Parameters.AddWithValue("@VistaID", viewID);
                    cmDep.Parameters.AddWithValue("@DTID", MyView.Details[i].DTID);
                    cmDep.CommandType = CommandType.StoredProcedure;
                    dsDep = db.Consulta(cmDep);
                    MyView.Details[i].ListaDependientes = new String[dsDep.Tables[0].Rows.Count];
                    for (int o = 0; o < dsDep.Tables[0].Rows.Count; o++)
                    {
                        //MyView.Details[i] = new TTSearchAdvancedDataDetails();
                        MyView.Details[i].ListaDependientes[o] = dsDep.Tables[0].Rows[o]["Valor"].ToString().TrimEnd(' ');
                    }
                }
                com = new SqlCommand();
                com.CommandText = "spTtVista_GrupoUsuario_X_VistaID";
                com.Parameters.AddWithValue("@VistaID", viewID);
                com.CommandType = CommandType.StoredProcedure;
                ds = db.Consulta(com);
                MyView.UserGroups = new String[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MyView.UserGroups[i] = ds.Tables[0].Rows[i]["Grupo_Usuario"].ToString();
                }

            }

            return MyView;

        }

        internal void Delete(int iVistaID, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "spDelTTVista";
            com.Parameters.AddWithValue("@VistaID", iVistaID);
            com.CommandType = CommandType.StoredProcedure;
            db.EjecutaDelete(com, UserInformation, DataReference);
        }
    }
    public class TTSearchAdvancedData
    {
        private int vistaID;
        private String name;
        private Boolean defaul;
        private Boolean obligatory;
        private Boolean empty;
        private int processID;
        private int userID;
        private String sql;
        private int? filterID;
        private ControlsLibrary.objectBussinessTTFiltro filter;
        private int? configurationID;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn configuration;
        private String[] userGroups;
        private TTSearchAdvancedDataDetails[] details;
        public int VistaID
        {
            get { return vistaID; }
            set { vistaID=value; }
        }
        public String  Name
        {
            get { return name; }
            set { name = value; }
        }
        public Boolean Default
        {
            get { return defaul; }
            set { defaul = value; }
        }
        public Boolean Obligatory
        {
            get { return obligatory; }
            set { obligatory = value; }
        }
        public Boolean Empty
        {
            get { return empty; }
            set { empty = value; }
        }
        public int ProcessID
        {
            get { return processID; }
            set { processID = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int? FilterID
        {
            get { return filterID; }
            set { filterID = value; }
        }
        public ControlsLibrary.objectBussinessTTFiltro Filter
        {
            get { return filter; }
            set { filter= value; }
        }
        public int? ConfigurationID
        {
            get { return configurationID; }
            set { configurationID = value; }
        }
        public ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn Configuration
        {
            get { return configuration; }
            set { configuration = value; }
        }
        public String Sql
        {
            get { return sql; }
            set { sql = value; }
        }
        public String[] UserGroups
        {
            get { return userGroups; }
            set { userGroups = value; }
        }
        public TTSearchAdvancedDataDetails[] Details
        {
            get { return details; }
            set { details = value; }
        }
    }
    public class TTSearchAdvancedDataDetails
    {
        private int dntID;
        private int dtID;
        private String nombreDT;
        private Boolean visible;
        private int order;
        private String from;
        private String to;
        private DateTime? fromDate;
        private DateTime? toDate;
        private int? year;
        private int? month;
        private int? week;
        private int? yes_not;
        private TTClassSpecials.FiltersTypes.TypesTextFilter conditionText;
        private String[] listaDependientes;
        private TTFunctions.TypeControlPresentation presentation;
        private ControlsLibrary.TypeControlSearchAdvanced controlScreenSearchAdvanced;
        public int DNTID
        {
            get { return dntID; }
            set { dntID = value; }
        }
        public int DTID
        {
            get { return dtID; }
            set { dtID = value; }
        }
        public String NombreDT
        {
            get { return nombreDT; }
            set { nombreDT = value; }
        }
        public Boolean Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        public int Order
        {
            get { return order; }
            set { order = value; }
        }
        public String From
        {
            get { return from; }
            set { from = value; }
        }
        public String To
        {
            get { return to; }
            set { to = value; }
        }
        public DateTime? FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        public DateTime? ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }
        public int? Year
        {
            get { return year; }
            set { year = value; }
        }
        public int? Month
        {
            get { return month; }
            set { month = value; }
        }
        public int? Week
        {
            get { return week; }
            set { week = value; }
        }
        public int? Yes_Not
        {
            get { return yes_not; }
            set { yes_not = value; }
        }
        public TTClassSpecials.FiltersTypes.TypesTextFilter  ConditionText
        {
            get { return conditionText; }
            set { conditionText = value; }
        }
        public String[] ListaDependientes
        {
            get { return listaDependientes; }
            set { listaDependientes = value; }
        }
        public TTFunctions.TypeControlPresentation Presentation
        {
            get { return presentation; }
            set { presentation = value; }
        }
        public ControlsLibrary.TypeControlSearchAdvanced ControlScreenSearchAdvanced
        {
            get { return controlScreenSearchAdvanced; }
            set { controlScreenSearchAdvanced = value; }
        }
    
    }


        //public enum TypeControlSearchAdvanced ///Tipo de control de la pantalla searchAdvanced
        //{
        //    Numeric = 1,
        //    Money = 2,
        //    Decimal = 3,
        //    Text = 4,
        //    Logic = 5,
        //    Date = 6,
        //    Hour = 7,
        //    Dependiente=8,
        //    Color =11,
        //    MultiRenglon = 12
        //}

}
