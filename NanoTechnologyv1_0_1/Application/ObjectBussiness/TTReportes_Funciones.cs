using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace TTReportes
{
    public class TTReportes_FuncionesFilters
    {
        private Boolean obligatory;
        private Boolean defaultview;
        private Boolean vacia;
        public Boolean Obligatory
        {
            get { return obligatory; }
            set { obligatory = value; }
        }
        public Boolean Defaultview
        {
            get { return defaultview; }
            set { defaultview = value; }
        }
        public Boolean Vacia
        {
            get { return vacia; }
            set { vacia = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varidReporte = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTReportesCS.TTReportesFilters[] varidReporte;
        public TTClassSpecials.FiltersTypes.Dependientes idReporte
        {
            get { return varidReporte; }
            set { varidReporte = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varFolio = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Folio
        {
            get { return varFolio; }
            set { varFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.String varText = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Text
        {
            get { return varText; }
            set { varText = value; }
        }
        private TTClassSpecials.FiltersTypes.String varFullPath = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String FullPath
        {
            get { return varFullPath; }
            set { varFullPath = value; }
        }
        private TTClassSpecials.FiltersTypes.String varFullPathDT = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String FullPathDT
        {
            get { return varFullPathDT; }
            set { varFullPathDT = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varFuncion = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Funcion
        {
            get { return varFuncion; }
            set { varFuncion = value; }
        }

    }
    public class objectBussinessTTReportes_Funciones
    {
        public int iProcess = 6802;
        private TTFunctions.Functions Function = new TTFunctions.Functions();
        private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
        private TTReportes_FuncionesFilters[] filters;
        private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
        private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
        private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
        private int? varidReporte;
        private int? varFolio;
        private String varText;
        private String varFullPath;
        private String varFullPathDT;
        private TTReportsConfigurationsEnumfunctions varFuncion = TTReportsConfigurationsEnumfunctions.None;
        private int? varMinimo_Alerta;
        private int? varMaximo_Alerta;
        private Boolean varMostrar_Vacios;
        private TTReportsConfigurationsEnumFormatDate varFormat;
        private TTReportsConfigurationsEnumOrderBy varOrderBy;

        private String varOrderClickHeaderCellType = "";
        private String varOrderClickHeaderCell = "";
        public String OrderClickHeaderCell
        {
            get { return varOrderClickHeaderCell; }
            set { varOrderClickHeaderCell = value; }
        }
        public String OrderClickHeaderCellType
        {
            get { return varOrderClickHeaderCellType; }
            set { varOrderClickHeaderCellType = value; }
        }
        public ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] MyConfigurationColumns
        {
            get { return myConfigurationColumns; }
            set { myConfigurationColumns = value; }
        }
        public ControlsLibrary.objectBussinessTTFiltro[] MyFilters
        {
            get { return myFilters; }
            set { myFilters = value; }
        }
        public ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] MyConfigurationColumnsObligatories
        {
            get { return myConfigurationColumnsObligatories; }
            set { myConfigurationColumnsObligatories = value; }
        }
        public ControlsLibrary.objectBussinessTTFiltro[] MyFiltersObligatories
        {
            get { return myFiltersObligatories; }
            set { myFiltersObligatories = value; }
        }
        public ControlsLibrary.objectBussinessTTFiltro MyFiltersQuick
        {
            get { return myFiltersQuick; }
            set { myFiltersQuick = value; }
        }

        public TTReportes_FuncionesFilters[] Filters
        {
            get { return filters; }
            set { filters = value; }
        }
        public TTReportes_FuncionesFilters Filter
        {
            ///Cuando es llamada desde las relaciones de algun catalago
            set
            {
                filters = new TTReportes_FuncionesFilters[1];
                filters[0] = value;
            }
        }
        private Boolean isGroup;
        public Boolean IsGroup
        {
            get { return isGroup; }
            set { isGroup = value; }
        }

        public int? idReporte
        {
            get { return varidReporte; }
            set { varidReporte = value; }
        }
        public int? Folio
        {
            get { return varFolio; }
            set { varFolio = value; }
        }
        public String Text
        {
            get { return varText; }
            set { varText = value; }
        }
        public String FullPath
        {
            get { return varFullPath; }
            set { varFullPath = value; }
        }
        public String FullPathDT
        {
            get { return varFullPathDT; }
            set { varFullPathDT = value; }
        }
        public TTReportsConfigurationsEnumfunctions Funcion
        {
            get { return varFuncion; }
            set { varFuncion = value; }
        }
        public int? Minimo_Alerta
        {
            get { return varMinimo_Alerta; }
            set { varMinimo_Alerta = value; }
        }
        public int? Maximo_Alerta
        {
            get { return varMaximo_Alerta; }
            set { varMaximo_Alerta = value; }
        }
        public Boolean Mostrar_Vacios
        {
            get { return varMostrar_Vacios; }
            set { varMostrar_Vacios = value; }
        }
        public TTReportsConfigurationsEnumFormatDate Format
        {
            get { return varFormat; }
            set { varFormat = value; }
        }
        public TTReportsConfigurationsEnumOrderBy OrderBy
        {
            get { return varOrderBy; }
            set { varOrderBy = value; }
        }


        public Int32 SelCount()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Funciones";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            string swhere = "";
            if (this.filters != null)
                foreach (TTReportes_FuncionesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTReportes_Funciones", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            if (this.myFilters != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myFiltersObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myFiltersQuick != null)
                if (swhere == "")
                    swhere += this.myFiltersQuick.GenerateWhere();
                else
                    swhere += " and " + this.myFiltersQuick.GenerateWhere();
            if (swhere.Length >= 4)
                if (swhere.Substring(swhere.Length - 4) == "and ")
                    swhere = swhere.Substring(0, swhere.Length - 4);

            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, ""));
            return ds2.Tables[0].Rows.Count;
        }

        public DataSet SelAll(Boolean ConRelaciones)
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones == true)
                com.CommandText = "sp_SelAllComplete_TTReportes_Funciones";
            else
                com.CommandText = "sp_SelAllTTReportes_Funciones";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTReportes_FuncionesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTReportes_Funciones", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTReportes_Funciones", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            if (this.myFilters != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myConfigurationColumns != null)
                foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumns)
                    if (sOrderBy == "")
                        sOrderBy += fil.GenerateOrderBy();
            //else
            //sOrderBy += "," + fil.GenerateOrderBy();
            if (this.myFiltersObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myConfigurationColumnsObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                    if (sOrderBy == "")
                        sOrderBy += fil.GenerateOrderBy();
            //else
            //sOrderBy += ","+fil.GenerateOrderBy();
            if (this.myFiltersQuick != null)
                if (swhere == "")
                    swhere += this.myFiltersQuick.GenerateWhere();
                else
                    swhere += " and " + this.myFiltersQuick.GenerateWhere();
            if (swhere.Length >= 4)
                if (swhere.Substring(swhere.Length - 4) == "and ")
                    swhere = swhere.Substring(0, swhere.Length - 4);
            if (varOrderClickHeaderCell != "")
            {
                if (varOrderClickHeaderCellType != " Desc")
                    sOrderBy = varOrderClickHeaderCell + " Asc";
                else
                    sOrderBy = varOrderClickHeaderCell + " Desc";
            }

            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy));
            return ds2;
        }

        public DataTable SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones == true)
                com.CommandText = "sp_SelAllComplete_TTReportes_Funciones";
            else
                com.CommandText = "sp_SelAllTTReportes_Funciones";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTReportes_FuncionesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTReportes_Funciones", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTReportes_Funciones", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            if (this.myFilters != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myConfigurationColumns != null)
                foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumns)
                    if (sOrderBy == "")
                        sOrderBy += fil.GenerateOrderBy();
            //else
            //sOrderBy += "," + fil.GenerateOrderBy();
            if (this.myFiltersObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
                {
                    String sWhereT = fil.GenerateWhere();
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myConfigurationColumnsObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn fil in this.myConfigurationColumnsObligatories)
                    if (sOrderBy == "")
                        sOrderBy += fil.GenerateOrderBy();
            //else
            //sOrderBy += ","+fil.GenerateOrderBy();
            if (this.myFiltersQuick != null)
                if (swhere == "")
                    swhere += this.myFiltersQuick.GenerateWhere();
                else
                    swhere += " and " + this.myFiltersQuick.GenerateWhere();
            if (swhere.Length >= 4)
                if (swhere.Substring(swhere.Length - 4) == "and ")
                    swhere = swhere.Substring(0, swhere.Length - 4);
            if (varOrderClickHeaderCell != "")
            {
                if (varOrderClickHeaderCellType != " Desc")
                    sOrderBy = varOrderClickHeaderCell + " Asc";
                else
                    sOrderBy = varOrderClickHeaderCell + " Desc";
            }
            return Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy, CurrentRecordInt32, RecordsDisplayedInt32);
        }
        public Int32 CurrentPosicion(int? Key)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTReportes_Funciones";
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters != null)
                foreach (TTReportes_FuncionesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTReportes_Funciones", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Function.FormatNumberNull(dt.Rows[i]["TTReportes_Funciones_idReporte"]) == Key)
                    return i;
            }
            return -1;
        }
        public DataSet GetByKey(int? Key, Boolean ConRelaciones)
        {
            DataSet ds;
            if (Key == null)
            {
                //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
            else
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                if (ConRelaciones == true)
                    com.CommandText = "sp_GetComplete_TTReportes_Funciones";
                else
                    com.CommandText = "sp_GetTTReportes_Funciones";
                com.Parameters.AddWithValue("@idReporte", Key);

                com.CommandType = CommandType.StoredProcedure;
                ds = db.Consulta(com);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idReporte = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_Funciones_idReporte"]);
                    Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_Funciones_Folio"]);
                    Text = ds.Tables[0].Rows[0]["TTReportes_Funciones_Text"].ToString().TrimEnd(' ');
                    FullPath = ds.Tables[0].Rows[0]["TTReportes_Funciones_FullPath"].ToString().TrimEnd(' ');
                    FullPathDT = ds.Tables[0].Rows[0]["TTReportes_Funciones_FullPathDT"].ToString().TrimEnd(' ');
                    Funcion = (TTReportsConfigurationsEnumfunctions)Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_Funciones_Funcion"]);
                    Minimo_Alerta = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_Funciones_Minimo_Alerta"]);
                    Maximo_Alerta = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_Funciones_Maximo_Alerta"]);
                    Mostrar_Vacios = Boolean.Parse(ds.Tables[0].Rows[0]["TTReportes_Funciones_Maximo_Alerta"].ToString());
                    Format = (TTReportsConfigurationsEnumFormatDate)Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_Funciones_Format"].ToString().TrimEnd(' '));
                    OrderBy = (TTReportsConfigurationsEnumOrderBy)Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTReportes_Funciones_OrderBy"].ToString().TrimEnd(' '));
                }
                return ds;
            }
        }

        public bool Delete(int? Key, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            if (Key == null)
            {
                //MessageBox.Show("Para poder borrar el registro debe proporcionar la llave", "Borrar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                //if (MessageBox.Show("Estas seguro de eliminar este registro", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                //    return false;
                Boolean result;
                DataReference.Folio = Key.ToString();
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                db.BeginTransaction("TTReportes_Funciones");
                try
                {


                    SqlCommand com = new SqlCommand();
                    com.CommandText = "sp_DelTTReportes_Funciones";
                    com.Parameters.AddWithValue("@idReporte", Key);

                    com.CommandType = CommandType.StoredProcedure;
                    Boolean bDelete = db.EjecutaDelete(com, UserInformation, DataReference);
                    db.CommitTransaction();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    db.RollBackTransaction("TTReportes_Funciones");
                    throw ex;
                }
                return result;
            }
        }

        public Int32 Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTReportes_Funciones");
            Int32 sKey = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_InsTTReportes_Funciones";
                com.Parameters.AddWithValue("@idReporte", Conversion.FormatNull(varidReporte));
                if (varText != null)
                    com.Parameters.AddWithValue("@Text", varText);
                else
                    com.Parameters.AddWithValue("@Text", DBNull.Value);
                if (varFullPath != null)
                    com.Parameters.AddWithValue("@FullPath", varFullPath);
                else
                    com.Parameters.AddWithValue("@FullPath", DBNull.Value);
                if (varFullPathDT != null)
                    com.Parameters.AddWithValue("@FullPathDT", varFullPath);
                else
                    com.Parameters.AddWithValue("@FullPathDT", DBNull.Value);
                com.Parameters.AddWithValue("@Funcion", varFuncion.GetHashCode());
                com.Parameters.AddWithValue("@Minimo_Alerta", Conversion.FormatNull(varMinimo_Alerta));
                com.Parameters.AddWithValue("@Maximo_Alerta", Conversion.FormatNull(varMaximo_Alerta));
                com.Parameters.AddWithValue("@Mostrar_Vacios", varMostrar_Vacios);
                com.Parameters.AddWithValue("@Format", varFormat.GetHashCode());
                com.Parameters.AddWithValue("@OrderBy", varOrderBy.GetHashCode());

                com.CommandType = CommandType.StoredProcedure;
                sKey = Convert.ToInt32(db.EjecutaInsert(com, UserInformation, DataReference));


                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTReportes_Funciones");
                throw ex;
            }
            return sKey;
        }
        public Int32 Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTReportes_Funciones");
            Int32 sKey = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_UpdTTReportes_Funciones";
                com.Parameters.AddWithValue("@idReporte", Conversion.FormatNull(varidReporte));
                com.Parameters.AddWithValue("@Folio", Conversion.FormatNull(varFolio));
                if (varText != null)
                    com.Parameters.AddWithValue("@Text", varText);
                else
                    com.Parameters.AddWithValue("@Text", DBNull.Value);
                if (varFullPath != null)
                    com.Parameters.AddWithValue("@FullPath", varFullPath);
                else
                    com.Parameters.AddWithValue("@FullPath", DBNull.Value);
                if (varFullPathDT != null)
                    com.Parameters.AddWithValue("@FullPathDT", varFullPath);
                else
                    com.Parameters.AddWithValue("@FullPathDT", DBNull.Value);
                com.Parameters.AddWithValue("@Funcion", varFuncion.GetHashCode());
                com.Parameters.AddWithValue("@Minimo_Alerta", Conversion.FormatNull(varMinimo_Alerta));
                com.Parameters.AddWithValue("@Maximo_Alerta", Conversion.FormatNull(varMaximo_Alerta));
                com.Parameters.AddWithValue("@Mostrar_Vacios", varMostrar_Vacios);
                com.Parameters.AddWithValue("@Format", varFormat.GetHashCode());
                com.Parameters.AddWithValue("@OrderBy", varOrderBy.GetHashCode());

                com.CommandType = CommandType.StoredProcedure;
                sKey = Convert.ToInt32(db.EjecutaUpdate(com, UserInformation, DataReference));


                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTReportes_Funciones");
                throw ex;
            }
            return sKey;
        }

        public Boolean ValidaExistencia(int? Key)
        {
            Boolean result;
            DataSet ds;
            if (Key == null)
            {
                //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_GetTTReportes_Funciones";
            com.Parameters.AddWithValue("@idReporte", Key);

            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count == 0)
                result = false;
            else
                result = true;
            return result;
        }
                
        public DataTable FillDataidReporte(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Funciones_Relacion_TTReportes";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            return dt;            
        }

        public DataTable FillDataidReporte()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Funciones_Relacion_TTReportes";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
        }

        public DataSet FillDataidReporteDS()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTReportes_Funciones_Relacion_TTReportes";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataSet ds = db.Consulta(com);
            return ds;
        }

    }
}
