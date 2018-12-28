using System;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;
//using System.Drawing;

namespace TTBusinessRules_ActionType_Relac_ParamTyCS
{
    public class TTBusinessRules_ActionType_Relac_ParamTyFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varidBusinessRules_ActionType = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_ActionTypeCS.TTBusinessRules_ActionTypeFilters[] varidBusinessRules_ActionType;
        public TTClassSpecials.FiltersTypes.Dependientes idBusinessRules_ActionType
        {
            get { return varidBusinessRules_ActionType; }
            set { varidBusinessRules_ActionType = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varIdFolio = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric IdFolio
        {
            get { return varIdFolio; }
            set { varIdFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_Parametro = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_ActionParameterTypeCS.TTBusinessRules_ActionParameterTypeFilters[] varTipo_Parametro;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_Parametro
        {
            get { return varTipo_Parametro; }
            set { varTipo_Parametro = value; }
        }
        private TTClassSpecials.FiltersTypes.String varDescripcion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Descripcion
        {
            get { return varDescripcion; }
            set { varDescripcion = value; }
        }

    }
    public class objectBussinessTTBusinessRules_ActionType_Relac_ParamTy
    {
        public int iProcess = 6780;
        private TTFunctions.Functions Function = new TTFunctions.Functions();
        private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
        private TTBusinessRules_ActionType_Relac_ParamTyFilters[] filters;
        private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
        private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
        private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
        private int? varidBusinessRules_ActionType;
        private int? varIdFolio;
        private int? varTipo_Parametro;
        private String varDescripcion;

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

        public TTBusinessRules_ActionType_Relac_ParamTyFilters[] Filters
        {
            get { return filters; }
            set { filters = value; }
        }
        public TTBusinessRules_ActionType_Relac_ParamTyFilters Filter
        {
            ///Cuando es llamada desde las relaciones de algun catalago
            set
            {
                filters = new TTBusinessRules_ActionType_Relac_ParamTyFilters[1];
                filters[0] = value;
            }
        }

        public int? idBusinessRules_ActionType
        {
            get { return varidBusinessRules_ActionType; }
            set { varidBusinessRules_ActionType = value; }
        }
        public int? IdFolio
        {
            get { return varIdFolio; }
            set { varIdFolio = value; }
        }
        public int? Tipo_Parametro
        {
            get { return varTipo_Parametro; }
            set { varTipo_Parametro = value; }
        }
        public String Descripcion
        {
            get { return varDescripcion; }
            set { varDescripcion = value; }
        }


        public Int32 SelCount()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTBusinessRules_ActionType_Relac_ParamTy";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            string swhere = "";
            if (this.filters != null)
                foreach (TTBusinessRules_ActionType_Relac_ParamTyCS.TTBusinessRules_ActionType_Relac_ParamTyFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules_ActionType_Relac_ParamTy", fil);
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
                com.CommandText = "sp_SelAllComplete_TTBusinessRules_ActionType_Relac_ParamTy";
            else
                com.CommandText = "sp_SelAllTTBusinessRules_ActionType_Relac_ParamTy";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTBusinessRules_ActionType_Relac_ParamTyCS.TTBusinessRules_ActionType_Relac_ParamTyFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules_ActionType_Relac_ParamTy", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBusinessRules_ActionType_Relac_ParamTy", fil);
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
                com.CommandText = "sp_SelAllComplete_TTBusinessRules_ActionType_Relac_ParamTy";
            else
                com.CommandText = "sp_SelAllTTBusinessRules_ActionType_Relac_ParamTy";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTBusinessRules_ActionType_Relac_ParamTyCS.TTBusinessRules_ActionType_Relac_ParamTyFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules_ActionType_Relac_ParamTy", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBusinessRules_ActionType_Relac_ParamTy", fil);
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
        public void Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTBusinessRules_ActionType_Relac_ParamTy");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_InsTTBusinessRules_ActionType_Relac_ParamTy";
                com.Parameters.AddWithValue("@idBusinessRules_ActionType", Conversion.FormatNull(varidBusinessRules_ActionType));
                com.Parameters.AddWithValue("@Tipo_Parametro", Conversion.FormatNull(varTipo_Parametro));
                if (varDescripcion != null)
                    com.Parameters.AddWithValue("@Descripcion", varDescripcion);
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaInsert(com, UserInformation, DataReference));
                varIdFolio = sKey1;



                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTBusinessRules_ActionType_Relac_ParamTy");
                throw ex;
            }
            //return sKey;
        }
        public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTBusinessRules_ActionType_Relac_ParamTy");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_UpdTTBusinessRules_ActionType_Relac_ParamTy";
                com.Parameters.AddWithValue("@idBusinessRules_ActionType", Conversion.FormatNull(varidBusinessRules_ActionType));
                com.Parameters.AddWithValue("@IdFolio", Conversion.FormatNull(varIdFolio));
                com.Parameters.AddWithValue("@Tipo_Parametro", Conversion.FormatNull(varTipo_Parametro));
                if (varDescripcion != null)
                    com.Parameters.AddWithValue("@Descripcion", varDescripcion);
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaUpdate(com, UserInformation, DataReference));
                //            varIdFolio = sKey1;


                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTBusinessRules_ActionType_Relac_ParamTy");
                throw ex;
            }
        }

        public bool Delete(int? Key1, int? Key2, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            //        if (Key == ""){
            //            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //                return false;
            //        }else{
            //if (MessageBox.Show("Estas seguro de eliminar este registro", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            //    return false;
            Boolean result;
            DataReference.Folio = Key1.ToString() + "," + Key2.ToString();
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTBusinessRules_ActionType_Relac_ParamTy");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_DelTTBusinessRules_ActionType_Relac_ParamTy";
                com.Parameters.AddWithValue("@idBusinessRules_ActionType", Key1); com.Parameters.AddWithValue("@IdFolio", Key2);
                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTBusinessRules_ActionType_Relac_ParamTy");
                throw ex;
            }
            return result;
            //}
        }
        public DataSet GetByKey(int? Key1, int? Key2, Boolean ConRelaciones)
        {
            DataSet ds;
            if (Key1 == null)
            {
                //            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
            //        else
            //        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones == true)
                com.CommandText = "sp_GetComplete_TTBusinessRules_ActionType_Relac_ParamTy";
            else
                com.CommandText = "sp_GetTTBusinessRules_ActionType_Relac_ParamTy";
            com.Parameters.AddWithValue("@idBusinessRules_ActionType", Key1); com.Parameters.AddWithValue("@IdFolio", Key2);

            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
                idBusinessRules_ActionType = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_ActionType_Relac_ParamTy_idBusinessRules_ActionType"]);
                IdFolio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_ActionType_Relac_ParamTy_IdFolio"]);
                Tipo_Parametro = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_ActionType_Relac_ParamTy_Tipo_Parametro"]);
                Descripcion = ds.Tables[0].Rows[0]["TTBusinessRules_ActionType_Relac_ParamTy_Descripcion"].ToString().TrimEnd(' ');



            }
            return ds;
            //}
        }
        public Int32 CurrentPosicion(int? Key1, int? Key2)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTBusinessRules_ActionType_Relac_ParamTy";
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters != null)
                foreach (TTBusinessRules_ActionType_Relac_ParamTyCS.TTBusinessRules_ActionType_Relac_ParamTyFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules_ActionType_Relac_ParamTy", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Function.FormatNumberNull(dt.Rows[i]["TTBusinessRules_ActionType_Relac_ParamTy_idBusinessRules_ActionType"]) == Key1 && Function.FormatNumberNull(dt.Rows[i]["TTBusinessRules_ActionType_Relac_ParamTy_IdFolio"]) == Key2)
                    return i;
            }
            return -1;
        }
        public Boolean ValidaExistencia(int? Key1, int? Key2)
        {
            Boolean result;
            DataSet ds;
            //        if (Key == null ){
            //            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //            return false;
            //        }
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_GetTTBusinessRules_ActionType_Relac_ParamTy";
            com.Parameters.AddWithValue("@idBusinessRules_ActionType", Key1); com.Parameters.AddWithValue("@IdFolio", Key2);
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count == 0)
                result = false;
            else
                result = true;
            return result;
        }

        public DataTable FillDataidBusinessRules_ActionType(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_ActionType_Relac_ParamTy_Relacion_TTBusinessRules_ActionType";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "idAccion";
            //ValueMember = "idAccion";
            return dt;
        }
        public DataTable FillDataidBusinessRules_ActionType()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_ActionType_Relac_ParamTy_Relacion_TTBusinessRules_ActionType";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "idAccion";
            //ValueMember = "idAccion";
            return dt;
        }
        
        public DataTable FillDataTipo_Parametro(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_ActionType_Relac_ParamTy_Relacion_TTBusinessRules_ActionParameterType";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "Descripcion";
            //ValueMember = "idAccion";
            return dt;
        }
        public DataTable FillDataTipo_Parametro()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_ActionType_Relac_ParamTy_Relacion_TTBusinessRules_ActionParameterType";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "Descripcion";
            //ValueMember = "idAccion";
            return dt;
        }


        public void applyFilterToObject(Prismaproj.TTSearchAdvancedDataDetails tTSearchAdvancedDataDetails, int indexFilter)
        {
            switch (tTSearchAdvancedDataDetails.ControlScreenSearchAdvanced)
            {
                case ControlsLibrary.TypeControlSearchAdvanced.Text:
                    {
                        #region Variable Filter del Bussiness Object para Textos
                        TTClassSpecials.FiltersTypes.String filter = new TTClassSpecials.FiltersTypes.String();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.ConditionText != TTClassSpecials.FiltersTypes.TypesTextFilter.None)
                        {
                            if (tTSearchAdvancedDataDetails.From != "" && tTSearchAdvancedDataDetails.ConditionText != TTClassSpecials.FiltersTypes.TypesTextFilter.None)
                            {
                                switch (tTSearchAdvancedDataDetails.ConditionText)
                                {
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Igual:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Igual;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Contenga:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Contenga;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Empieze:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Empieze;
                                            break;
                                        }
                                    case TTClassSpecials.FiltersTypes.TypesTextFilter.Termine:
                                        {
                                            filter.FilterType = TTClassSpecials.FiltersTypes.TypesTextFilter.Termine;
                                            break;
                                        }
                                }
                                filter.Text = tTSearchAdvancedDataDetails.From;
                            }
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Numeric:
                    {
                        #region Variable Filter del Bussiness Object para Numericos
                        TTClassSpecials.FiltersTypes.Numeric filter = new TTClassSpecials.FiltersTypes.Numeric();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if ((tTSearchAdvancedDataDetails.ConditionText == TTClassSpecials.FiltersTypes.TypesTextFilter.None) && (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != ""))
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToShort(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToShort(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Logic:
                    {
                        #region Variable Filter del Bussiness Object para Logicos
                        TTClassSpecials.FiltersTypes.Logic filter = new TTClassSpecials.FiltersTypes.Logic();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.Yes_Not != null)
                            filter.Active = tTSearchAdvancedDataDetails.Yes_Not;
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Money:
                    {
                        #region Variable Filter del Bussiness Object para Decimal
                        TTClassSpecials.FiltersTypes.filDecimal filter = new TTClassSpecials.FiltersTypes.filDecimal();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != "")
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Hour:
                    {
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Dependiente:
                    {
                        #region Variable Filter del Bussiness Object para Dependientes
                        TTClassSpecials.FiltersTypes.Dependientes filter = new TTClassSpecials.FiltersTypes.Dependientes();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.ListaDependientes.Length > 0)
                        {
                            filter.List = new String[tTSearchAdvancedDataDetails.ListaDependientes.Length];
                            for (int i = 0; i < tTSearchAdvancedDataDetails.ListaDependientes.Length; i++)
                                filter.List[i] = tTSearchAdvancedDataDetails.ListaDependientes[i];
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Decimal:
                    {
                        #region Variable Filter del Bussiness Object para Decimal
                        TTClassSpecials.FiltersTypes.filDecimal filter = new TTClassSpecials.FiltersTypes.filDecimal();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != "")
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Conversion.CambiaToDecimal(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Date:
                    {
                        #region Variable Filter del Bussiness Object para Dates
                        TTClassSpecials.FiltersTypes.filDate filter = new TTClassSpecials.FiltersTypes.filDate();
                        filter.Order = (TTClassSpecials.FiltersTypes.FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.FromDate != null || tTSearchAdvancedDataDetails.ToDate != null)
                        {
                            if (tTSearchAdvancedDataDetails.FromDate != null)
                                filter.From = tTSearchAdvancedDataDetails.FromDate;
                            if (tTSearchAdvancedDataDetails.ToDate != null)
                                filter.To = (tTSearchAdvancedDataDetails.ToDate);
                        }
                        AddFilterXDT(tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case ControlsLibrary.TypeControlSearchAdvanced.Color:
                    {
                        break;
                    }
            }
        }
        public void FiltersObligatories(TTSecurity.GlobalData GlobalInformation)
        {
            DataTable dt;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "spTtVistasObligatories_X_ProcessAndUser";
            com.Parameters.AddWithValue("@ProcessId", iProcess);
            com.Parameters.AddWithValue("@UserID", GlobalInformation.UserID);
            com.CommandType = CommandType.StoredProcedure;
            dt = db.Consulta(com).Tables[0];
            MyFiltersObligatories = new ControlsLibrary.objectBussinessTTFiltro[dt.Rows.Count];
            MyConfigurationColumnsObligatories = new ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[dt.Rows.Count];
            for (int iViews = 0; iViews < dt.Rows.Count; iViews++)
            {
                int iVistaID = Conversion.CambiaToShort(dt.Rows[iViews]["VistaID"]).Value;
                Prismaproj.TTSearchAdvanced MySearchAdvanced = new Prismaproj.TTSearchAdvanced();
                Prismaproj.TTSearchAdvancedData MySearch = MySearchAdvanced.GetStructView(iVistaID);
                MyFiltersObligatories[iViews] = MySearch.Filter;
                MyConfigurationColumnsObligatories[iViews] = MySearch.Configuration;
            }
        }
        
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            if (sDTid == "15008")
            {
                this.Filters[indexFilter].idBusinessRules_ActionType = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_ActionTypeCS.TTBusinessRules_ActionTypeFilters[])filter;
            }
            if (sDTid == "15009")
            {
                this.Filters[indexFilter].IdFolio = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15010")
            {
                this.Filters[indexFilter].Tipo_Parametro = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_ActionParameterTypeCS.TTBusinessRules_ActionParameterTypeFilters[])filter;
            }
            if (sDTid == "15045")
            {
                this.Filters[indexFilter].Descripcion = (TTClassSpecials.FiltersTypes.String)filter;
            }

        }
    }
}
