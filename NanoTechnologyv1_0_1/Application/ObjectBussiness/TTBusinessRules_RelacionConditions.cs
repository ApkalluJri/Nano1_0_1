using System;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;
//using System.Drawing;

namespace TTBusinessRules_RelacionConditionsCS
{
    public class TTBusinessRules_RelacionConditionsFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varidBusinessRules = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRulesCS.TTBusinessRulesFilters[] varidBusinessRules;
        public TTClassSpecials.FiltersTypes.Dependientes idBusinessRules
        {
            get { return varidBusinessRules; }
            set { varidBusinessRules = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varidFolio = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idFolio
        {
            get { return varidFolio; }
            set { varidFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varCondicionOperador = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_CondicionOperatorCS.TTBusinessRules_CondicionOperatorFilters[] varCondicionOperador;
        public TTClassSpecials.FiltersTypes.Dependientes CondicionOperador
        {
            get { return varCondicionOperador; }
            set { varCondicionOperador = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_Operador1 = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_TypeOperatorCS.TTBusinessRules_TypeOperatorFilters[] varTipo_Operador1;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_Operador1
        {
            get { return varTipo_Operador1; }
            set { varTipo_Operador1 = value; }
        }
        private TTClassSpecials.FiltersTypes.String varValor_Operador1 = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Valor_Operador1
        {
            get { return varValor_Operador1; }
            set { varValor_Operador1 = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varCondicion = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_ConditionCS.TTBusinessRules_ConditionFilters[] varCondicion;
        public TTClassSpecials.FiltersTypes.Dependientes Condicion
        {
            get { return varCondicion; }
            set { varCondicion = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_Operador2 = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_TypeOperator2CS.TTBusinessRules_TypeOperator2Filters[] varTipo_Operador2;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_Operador2
        {
            get { return varTipo_Operador2; }
            set { varTipo_Operador2 = value; }
        }
        private TTClassSpecials.FiltersTypes.String varValor_Operador2 = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Valor_Operador2
        {
            get { return varValor_Operador2; }
            set { varValor_Operador2 = value; }
        }

    }
    public class objectBussinessTTBusinessRules_RelacionConditions
    {
        public int iProcess = 6777;
        private TTFunctions.Functions Function = new TTFunctions.Functions();
        private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
        private TTBusinessRules_RelacionConditionsFilters[] filters;
        private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
        private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
        private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
        private int? varidBusinessRules;
        private int? varidFolio;
        private int? varCondicionOperador;
        private int? varTipo_Operador1;
        private String varValor_Operador1;
        private int? varCondicion;
        private int? varTipo_Operador2;
        private String varValor_Operador2;

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

        public TTBusinessRules_RelacionConditionsFilters[] Filters
        {
            get { return filters; }
            set { filters = value; }
        }
        public TTBusinessRules_RelacionConditionsFilters Filter
        {
            ///Cuando es llamada desde las relaciones de algun catalago
            set
            {
                filters = new TTBusinessRules_RelacionConditionsFilters[1];
                filters[0] = value;
            }
        }

        public int? idBusinessRules
        {
            get { return varidBusinessRules; }
            set { varidBusinessRules = value; }
        }
        public int? idFolio
        {
            get { return varidFolio; }
            set { varidFolio = value; }
        }
        public int? CondicionOperador
        {
            get { return varCondicionOperador; }
            set { varCondicionOperador = value; }
        }
        public int? Tipo_Operador1
        {
            get { return varTipo_Operador1; }
            set { varTipo_Operador1 = value; }
        }
        public String Valor_Operador1
        {
            get { return varValor_Operador1; }
            set { varValor_Operador1 = value; }
        }
        public int? Condicion
        {
            get { return varCondicion; }
            set { varCondicion = value; }
        }
        public int? Tipo_Operador2
        {
            get { return varTipo_Operador2; }
            set { varTipo_Operador2 = value; }
        }
        public String Valor_Operador2
        {
            get { return varValor_Operador2; }
            set { varValor_Operador2 = value; }
        }

        private TTEnums.TTenumDBOperation dBOperation = TTEnums.TTenumDBOperation.None;
        public TTEnums.TTenumDBOperation DBOperation
        {
            get { return dBOperation; }
            set { dBOperation = value; }
        }

        public Int32 SelCount()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTBusinessRules_RelacionConditions";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            string swhere = "";
            if (this.filters != null)
                foreach (TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules_RelacionConditions", fil);
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
                com.CommandText = "sp_SelAllComplete_TTBusinessRules_RelacionConditions";
            else
                com.CommandText = "sp_SelAllTTBusinessRules_RelacionConditions";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules_RelacionConditions", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBusinessRules_RelacionConditions", fil);
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
                com.CommandText = "sp_SelAllComplete_TTBusinessRules_RelacionConditions";
            else
                com.CommandText = "sp_SelAllTTBusinessRules_RelacionConditions";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules_RelacionConditions", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBusinessRules_RelacionConditions", fil);
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
            db.BeginTransaction("TTBusinessRules_RelacionConditions");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_InsTTBusinessRules_RelacionConditions";
                com.Parameters.AddWithValue("@idBusinessRules", Conversion.FormatNull(varidBusinessRules));
                com.Parameters.AddWithValue("@CondicionOperador", Conversion.FormatNull(varCondicionOperador));
                com.Parameters.AddWithValue("@Tipo_Operador1", Conversion.FormatNull(varTipo_Operador1));
                if (varValor_Operador1 != null)
                    com.Parameters.AddWithValue("@Valor_Operador1", varValor_Operador1);
                else
                    com.Parameters.AddWithValue("@Valor_Operador1", DBNull.Value);
                com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(varCondicion));
                com.Parameters.AddWithValue("@Tipo_Operador2", Conversion.FormatNull(varTipo_Operador2));
                if (varValor_Operador2 != null)
                    com.Parameters.AddWithValue("@Valor_Operador2", varValor_Operador2);
                else
                    com.Parameters.AddWithValue("@Valor_Operador2", DBNull.Value);

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaInsert(com, UserInformation, DataReference));
                varidFolio = sKey1;



                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTBusinessRules_RelacionConditions");
                throw ex;
            }
            //return sKey;
        }
        public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTBusinessRules_RelacionConditions");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_UpdTTBusinessRules_RelacionConditions";
                com.Parameters.AddWithValue("@idBusinessRules", Conversion.FormatNull(varidBusinessRules));
                com.Parameters.AddWithValue("@idFolio", Conversion.FormatNull(varidFolio));
                com.Parameters.AddWithValue("@CondicionOperador", Conversion.FormatNull(varCondicionOperador));
                com.Parameters.AddWithValue("@Tipo_Operador1", Conversion.FormatNull(varTipo_Operador1));
                if (varValor_Operador1 != null)
                    com.Parameters.AddWithValue("@Valor_Operador1", varValor_Operador1);
                else
                    com.Parameters.AddWithValue("@Valor_Operador1", DBNull.Value);
                com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(varCondicion));
                com.Parameters.AddWithValue("@Tipo_Operador2", Conversion.FormatNull(varTipo_Operador2));
                if (varValor_Operador2 != null)
                    com.Parameters.AddWithValue("@Valor_Operador2", varValor_Operador2);
                else
                    com.Parameters.AddWithValue("@Valor_Operador2", DBNull.Value);

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaUpdate(com, UserInformation, DataReference));
                //            varidFolio = sKey1;


                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTBusinessRules_RelacionConditions");
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
            Boolean result = true;
            DataReference.Folio = Key1.ToString() + "," + Key2.ToString();
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTBusinessRules_RelacionConditions");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_DelTTBusinessRules_RelacionConditions";
                com.Parameters.AddWithValue("@idBusinessRules", Key1); com.Parameters.AddWithValue("@idFolio", Key2);
                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTBusinessRules_RelacionConditions");
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
                com.CommandText = "sp_GetComplete_TTBusinessRules_RelacionConditions";
            else
                com.CommandText = "sp_GetTTBusinessRules_RelacionConditions";
            com.Parameters.AddWithValue("@idBusinessRules", Key1); com.Parameters.AddWithValue("@idFolio", Key2);

            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
                idBusinessRules = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_RelacionConditions_idBusinessRules"]);
                idFolio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_RelacionConditions_idFolio"]);
                CondicionOperador = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_RelacionConditions_CondicionOperador"]);
                Tipo_Operador1 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_RelacionConditions_Tipo_Operador1"]);
                Valor_Operador1 = ds.Tables[0].Rows[0]["TTBusinessRules_RelacionConditions_Valor_Operador1"].ToString().TrimEnd(' ');
                Condicion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_RelacionConditions_Condicion"]);
                Tipo_Operador2 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_RelacionConditions_Tipo_Operador2"]);
                Valor_Operador2 = ds.Tables[0].Rows[0]["TTBusinessRules_RelacionConditions_Valor_Operador2"].ToString().TrimEnd(' ');
            }
            return ds;
            //}
        }
        public Int32 CurrentPosicion(int? Key1, int? Key2)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTBusinessRules_RelacionConditions";
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters != null)
                foreach (TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules_RelacionConditions", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Function.FormatNumberNull(dt.Rows[i]["TTBusinessRules_RelacionConditions_idBusinessRules"]) == Key1 && Function.FormatNumberNull(dt.Rows[i]["TTBusinessRules_RelacionConditions_idFolio"]) == Key2)
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
            com.CommandText = "sp_GetTTBusinessRules_RelacionConditions";
            com.Parameters.AddWithValue("@idBusinessRules", Key1); com.Parameters.AddWithValue("@idFolio", Key2);
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count == 0)
                result = false;
            else
                result = true;
            return result;
        }
               
        public DataTable FillDataidBusinessRules(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "idBusinessRule";
            //ValueMember = "idBusinessRule";
            return dt;
        }
        public DataTable FillDataidBusinessRules()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "idBusinessRule";
            //ValueMember = "idBusinessRule";
            return dt;
        }
        
        public DataTable FillDataCondicionOperador(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules_CondicionOperator";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "Descripcion";
            //ValueMember = "idOperator";
            return dt;
        }
        public DataTable FillDataCondicionOperador()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules_CondicionOperator";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "Descripcion";
            //ValueMember = "idOperator";
            return dt;
        }
        public DataTable FillDataTipo_Operador1(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules_TypeOperator";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "Descripcion";
            //ValueMember = "idOperator";
            return dt;
        }
        public DataTable FillDataTipo_Operador1()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules_TypeOperator";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "Descripcion";
            //ValueMember = "idOperator";
            return dt;
        }
        
        public DataTable FillDataCondicion(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules_Condition";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "Descripcion";
            //ValueMember = "idCondicion";
            return dt;
        }
        public DataTable FillDataCondicion()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules_Condition";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "Descripcion";
            //ValueMember = "idCondicion";
            return dt;
        }
        
        public DataTable FillDataTipo_Operador2(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules_TypeOperator2";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "Descripcion";
            //ValueMember = "idOperator";
            return dt;
        }
        public DataTable FillDataTipo_Operador2()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionConditions_Relacion_TTBusinessRules_TypeOperator2";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "Descripcion";
            //ValueMember = "idOperator";
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
            if (sDTid == "14988")
            {
                this.Filters[indexFilter].idBusinessRules = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRulesCS.TTBusinessRulesFilters[])filter;
            }
            if (sDTid == "14989")
            {
                this.Filters[indexFilter].idFolio = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "14990")
            {
                this.Filters[indexFilter].CondicionOperador = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_CondicionOperatorCS.TTBusinessRules_CondicionOperatorFilters[])filter;
            }
            if (sDTid == "14991")
            {
                this.Filters[indexFilter].Tipo_Operador1 = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_TypeOperatorCS.TTBusinessRules_TypeOperatorFilters[])filter;
            }
            if (sDTid == "14992")
            {
                this.Filters[indexFilter].Valor_Operador1 = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "14993")
            {
                this.Filters[indexFilter].Condicion = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_ConditionCS.TTBusinessRules_ConditionFilters[])filter;
            }
            if (sDTid == "14994")
            {
                this.Filters[indexFilter].Tipo_Operador2 = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_TypeOperator2CS.TTBusinessRules_TypeOperator2Filters[])filter;
            }
            if (sDTid == "14995")
            {
                this.Filters[indexFilter].Valor_Operador2 = (TTClassSpecials.FiltersTypes.String)filter;
            }

        }
    }
}
