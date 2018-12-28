using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
////using System.Windows.Forms;
////using System.Drawing;

namespace TTBusinessRulesCS
{
    public class TTBusinessRulesFilters
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
        private TTClassSpecials.FiltersTypes.Numeric varidBusinessRule = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idBusinessRule
        {
            get { return varidBusinessRule; }
            set { varidBusinessRule = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varIdProceso = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTProcesoCS.TTProcesoFilters[] varIdProceso;
        public TTClassSpecials.FiltersTypes.Dependientes IdProceso
        {
            get { return varIdProceso; }
            set { varIdProceso = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate varFecha_de_Alta = new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Alta
        {
            get { return varFecha_de_Alta; }
            set { varFecha_de_Alta = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varAlcance = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_AlcanceCS.TTBusinessRules_AlcanceFilters[] varAlcance;
        public TTClassSpecials.FiltersTypes.Dependientes Alcance
        {
            get { return varAlcance; }
            set { varAlcance = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varOperacion = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_RelacionOperacionCS.TTBusinessRules_RelacionOperacionFilters[] varOperacion;
        public TTClassSpecials.FiltersTypes.Dependientes Operacion
        {
            get { return varOperacion; }
            set { varOperacion = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varEvento_Proceso = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_RelacionProcessEventCS.TTBusinessRules_RelacionProcessEventFilters[] varEvento_Proceso;
        public TTClassSpecials.FiltersTypes.Dependientes Evento_Proceso
        {
            get { return varEvento_Proceso; }
            set { varEvento_Proceso = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varEvento_Campo = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTBusinessRules_RelacionFieldEventCS.TTBusinessRules_RelacionFieldEventFilters[] varEvento_Campo;
        public TTClassSpecials.FiltersTypes.Dependientes Evento_Campo
        {
            get { return varEvento_Campo; }
            set { varEvento_Campo = value; }
        }
        private TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters varCondiciones = new TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters();
        public TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters Condiciones
        {
            get { return varCondiciones; }
            set { varCondiciones = value; }
        }
        private TTBusinessRules_RelacionAccionesTrueCS.TTBusinessRules_RelacionAccionesTrueFilters varAcciones_True = new TTBusinessRules_RelacionAccionesTrueCS.TTBusinessRules_RelacionAccionesTrueFilters();
        public TTBusinessRules_RelacionAccionesTrueCS.TTBusinessRules_RelacionAccionesTrueFilters Acciones_True
        {
            get { return varAcciones_True; }
            set { varAcciones_True = value; }
        }
        private TTBusinessRules_RelacionAccionesFalseCS.TTBusinessRules_RelacionAccionesFalseFilters varAcciones_False = new TTBusinessRules_RelacionAccionesFalseCS.TTBusinessRules_RelacionAccionesFalseFilters();
        public TTBusinessRules_RelacionAccionesFalseCS.TTBusinessRules_RelacionAccionesFalseFilters Acciones_False
        {
            get { return varAcciones_False; }
            set { varAcciones_False = value; }
        }

    }
    public class objectBussinessTTBusinessRules
    {
        public int iProcess = 6773;
        private TTFunctions.Functions Function = new TTFunctions.Functions();
        private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
        private TTBusinessRulesFilters[] filters;
        private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
        private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
        private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
        private int? varidBusinessRule;
        private int? varIdProceso;
        private String varNombre;
        private DateTime? varFecha_de_Alta;
        private int? varAlcance;
        private TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion[] varOperacion;        
        private TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent[] varEvento_Proceso;
        private TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent[] varEvento_Campo;
        //----------------------------------------------------------------------------------------------------------------------
        //private TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions[] varCondiciones;
        private List<TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions> varCondiciones;
        //private TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue[] varAcciones_True;
        private List<TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue> varAcciones_True;
        //private TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse[] varAcciones_False;
        private List<TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse> varAcciones_False;

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

        public TTBusinessRulesFilters[] Filters
        {
            get { return filters; }
            set { filters = value; }
        }
        public TTBusinessRulesFilters Filter
        {
            ///Cuando es llamada desde las relaciones de algun catalago
            set
            {
                filters = new TTBusinessRulesFilters[1];
                filters[0] = value;
            }
        }

        public int? idBusinessRule
        {
            get { return varidBusinessRule; }
            set { varidBusinessRule = value; }
        }
        public int? IdProceso
        {
            get { return varIdProceso; }
            set { varIdProceso = value; }
        }
        public String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        public DateTime? Fecha_de_Alta
        {
            get { return varFecha_de_Alta; }
            set { varFecha_de_Alta = value; }
        }
        public int? Alcance
        {
            get { return varAlcance; }
            set { varAlcance = value; }
        }
        public TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion[] Operacion
        {
            get { return varOperacion; }
            set { varOperacion = value; }
        }
        public TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent[] Evento_Proceso
        {
            get { return varEvento_Proceso; }
            set { varEvento_Proceso = value; }
        }
        public TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent[] Evento_Campo
        {
            get { return varEvento_Campo; }
            set { varEvento_Campo = value; }
        }
        //public TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions[] Condiciones
        //{
        //    get { return varCondiciones; }
        //    set { varCondiciones = value; }
        //}
        //public TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue[] Acciones_True
        //{
        //    get { return varAcciones_True; }
        //    set { varAcciones_True = value; }
        //}
        //public TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse[] Acciones_False
        //{
        //    get { return varAcciones_False; }
        //    set { varAcciones_False = value; }
        //}
        public List<TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions> Condiciones
        {
            get { return varCondiciones; }
            set { varCondiciones = value; }
        }
        public List<TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue> Acciones_True
        {
            get { return varAcciones_True; }
            set { varAcciones_True = value; }
        }
        public List<TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse> Acciones_False
        {
            get { return varAcciones_False; }
            set { varAcciones_False = value; }
        }

        private TTEnums.TTenumDBOperation dBOperation = TTEnums.TTenumDBOperation.None;
        public TTEnums.TTenumDBOperation DBOperation
        {
            get { return dBOperation; }
            set { dBOperation = value; }
        }

        private String swhere = String.Empty;
        public String sWhere
        {
            get { return swhere; }
            set { swhere = value; }
        }
        private String fullQuery = @"SELECT {0} ORDER BY {1} ";
        public String FullQuery
        {
            get { return fullQuery; }
        }
        private String fullQueryForExport = @"SELECT {0} ORDER BY {1} ";
        public String FullQueryForExport
        {
            get { return fullQueryForExport; }
        }
        private int fullQueryCount = 0;
        public int FullQueryCount
        {
            get { return fullQueryCount; }
        }

        public Int32 SelCount()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTBusinessRules";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            string swhere = "";
            if (this.filters != null)
                foreach (TTBusinessRulesCS.TTBusinessRulesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules", fil);
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
                com.CommandText = "sp_SelAllComplete_TTBusinessRules";
            else
                com.CommandText = "sp_SelAllTTBusinessRules";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTBusinessRulesCS.TTBusinessRulesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBusinessRules", fil);
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
                com.CommandText = "sp_SelAllComplete_TTBusinessRules";
            else
                com.CommandText = "sp_SelAllTTBusinessRules";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTBusinessRulesCS.TTBusinessRulesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTBusinessRules", fil);
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

        //-----------------------------------------------------------Métodos para paginación--------------------------------------------------------------
        public int SelCount(string sortDirection, string sortExpression, int maximumRows, int startRowIndex)
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;

            if (this.myFilters != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
                {
                    String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myFiltersObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
                {
                    String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
                    if (sWhereT != "")
                        if (swhere == "")
                            swhere = sWhereT;
                        else
                            swhere += " and " + sWhereT;
                }
            if (this.myFiltersQuick != null)
                if (swhere == "")
                    swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
                else
                    swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            if (swhere.Length >= 4)
                if (swhere.Substring(swhere.Length - 4) == "and ")
                    swhere = swhere.Substring(0, swhere.Length - 4);


            if (swhere != string.Empty)
                swhere = (!swhere.ToLower().Trim().StartsWith("where") ? " WHERE " + swhere : swhere);

            string sPagingCountTemplate = @"SELECT COUNT(*) {0}";
            string from = " from (( TTBusinessRules WITH(NoLock) LEFT JOIN TTProceso WITH(NoLock) ON TTProceso.IdProceso=TTBusinessRules.IdProceso)       LEFT JOIN TTBusinessRules_Alcance WITH(NoLock) ON TTBusinessRules_Alcance.idAlcance=TTBusinessRules.Alcance)        " + swhere;

            sPagingCountTemplate = string.Format(sPagingCountTemplate, from);

            com.CommandText = sPagingCountTemplate;

            ds = db.Consulta(com);
            fullQueryCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            return fullQueryCount;
        }

        public DataSet SelAll(string sortDirection, string sortExpression, int maximumRows, int startRowIndex)
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;

            String sOrderBy = "";
            if (this.myFilters != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFilters)
                {
                    String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
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
            //-------------------------------------------------------
            if (this.myFiltersObligatories != null)
                foreach (ControlsLibrary.objectBussinessTTFiltro fil in this.myFiltersObligatories)
                {
                    String sWhereT = fil.GenerateWhereWithOutLeftJoin(null);
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
            //-------------------------------------------------------
            if (this.myFiltersQuick != null)
                if (swhere == "")
                    swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
                else
                    swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            if (swhere.Length >= 4)
                if (swhere.Substring(swhere.Length - 4) == "and ")
                    swhere = swhere.Substring(0, swhere.Length - 4);

            if (swhere != string.Empty)
                swhere = (!swhere.ToLower().Trim().StartsWith("where") ? " WHERE " + swhere : swhere);

            switch (sortExpression) { case "TTBusinessRules_idBusinessRule": sortExpression = "TTBusinessRules.idBusinessRule"; break; case "TTBusinessRules_IdProceso": sortExpression = "TTBusinessRules.IdProceso"; break; case "TTProceso_Nombre": sortExpression = "TTProceso.Nombre"; break; case "TTBusinessRules_Nombre": sortExpression = "TTBusinessRules.Nombre"; break; case "TTBusinessRules_Fecha_de_Alta": sortExpression = "TTBusinessRules.Fecha_de_Alta"; break; case "TTBusinessRules_Alcance": sortExpression = "TTBusinessRules.Alcance"; break; case "TTBusinessRules_Alcance_Descripcion": sortExpression = "TTBusinessRules_Alcance.Descripcion"; break; case "TTBusinessRules_Operacion": sortExpression = "TTBusinessRules.Operacion"; break; case "TTBusinessRules_Evento_Proceso": sortExpression = "TTBusinessRules.Evento_Proceso"; break; case "TTBusinessRules_Evento_Campo": sortExpression = "TTBusinessRules.Evento_Campo"; break; } sortExpression = (sortExpression == string.Empty || sortExpression == null ? "TTBusinessRules.idBusinessRule, TTBusinessRules.IdProceso, TTProceso.Nombre, TTBusinessRules.Nombre, TTBusinessRules.Fecha_de_Alta, TTBusinessRules.Alcance, TTBusinessRules_Alcance.Descripcion, TTBusinessRules.Operacion, TTBusinessRules.Evento_Proceso, TTBusinessRules.Evento_Campo" : sortExpression); if (sortDirection != string.Empty) sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc"); string fieldsWithAlias = " TTBusinessRules.idBusinessRule As TTBusinessRules_idBusinessRule,        TTBusinessRules.IdProceso AS TTBusinessRules_IdProceso,        TTProceso.Nombre AS TTProceso_Nombre,        TTBusinessRules.Nombre As TTBusinessRules_Nombre,        TTBusinessRules.Fecha_de_Alta As TTBusinessRules_Fecha_de_Alta,        TTBusinessRules.Alcance AS TTBusinessRules_Alcance,        TTBusinessRules_Alcance.Descripcion AS TTBusinessRules_Alcance_Descripcion,        '' AS TTBusinessRules_Operacion,        '' AS TTBusinessRules_Evento_Proceso,        '' AS TTBusinessRules_Evento_Campo "; string fieldsForExport = " TTBusinessRules.idBusinessRule As [idBusinessRule],        TTBusinessRules.IdProceso AS [IdProceso],        TTProceso.Nombre AS [Nombre],        TTBusinessRules.Nombre As [Nombre],        TTBusinessRules.Fecha_de_Alta As [Fecha de Alta],        TTBusinessRules.Alcance AS [Alcance],        TTBusinessRules_Alcance.Descripcion AS [Descripcion],        '' AS [Operacion],        '' AS [Evento Proceso],        '' AS [Evento Campo] "; string from = " from (( TTBusinessRules WITH(NoLock) LEFT JOIN TTProceso WITH(NoLock) ON TTProceso.IdProceso=TTBusinessRules.IdProceso)       LEFT JOIN TTBusinessRules_Alcance WITH(NoLock) ON TTBusinessRules_Alcance.idAlcance=TTBusinessRules.Alcance)        " + swhere;

            string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            WHERE RowNumber BETWEEN ({2}+1) and {2} + {3}";


            sPagingTemplate = string.Format(sPagingTemplate, sortExpression + " " + sortDirection, fieldsWithAlias + " " + from, startRowIndex, maximumRows);

            fullQuery = string.Format(fullQuery, fieldsWithAlias + " " + from, sortExpression + " " + sortDirection);
            fullQueryForExport = string.Format(fullQueryForExport, fieldsForExport + " " + from, sortExpression + " " + sortDirection);

            com.CommandText = sPagingTemplate;

            ds = db.Consulta(com);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                object keyTTBusinessRules = dr["TTBusinessRules_idBusinessRule"];

                TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion MyDataOperacion = new TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion();
                TTBusinessRules_RelacionOperacionCS.TTBusinessRules_RelacionOperacionFilters MyDataFilterOperacion = new TTBusinessRules_RelacionOperacionCS.TTBusinessRules_RelacionOperacionFilters();

                MyDataFilterOperacion.idBusinessRules.List = new String[1];
                MyDataFilterOperacion.idBusinessRules.List[0] = keyTTBusinessRules.ToString();

                MyDataOperacion.Filters = new TTBusinessRules_RelacionOperacionCS.TTBusinessRules_RelacionOperacionFilters[1];
                MyDataOperacion.Filters[0] = MyDataFilterOperacion;
                DataSet dsListBox = MyDataOperacion.SelAll(true);

                int columnIndex = 0;
                if (dsListBox.Tables[0].Columns.Count >= 4)
                    columnIndex = 3;
                else if (dsListBox.Tables[0].Columns.Count >= 2)
                    columnIndex = 1;

                try
                {
                    foreach (DataRow drlist in dsListBox.Tables[0].Rows)
                        dr["TTBusinessRules_Operacion"] += (dr["TTBusinessRules_Operacion"].ToString() == string.Empty ? string.Empty : ", ") + drlist[columnIndex].ToString();
                }
                catch { }
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                object keyTTBusinessRules = dr["TTBusinessRules_idBusinessRule"];

                TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent MyDataEvento_Proceso = new TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent();
                TTBusinessRules_RelacionProcessEventCS.TTBusinessRules_RelacionProcessEventFilters MyDataFilterEvento_Proceso = new TTBusinessRules_RelacionProcessEventCS.TTBusinessRules_RelacionProcessEventFilters();

                MyDataFilterEvento_Proceso.idBusinessRules.List = new String[1];
                MyDataFilterEvento_Proceso.idBusinessRules.List[0] = keyTTBusinessRules.ToString();

                MyDataEvento_Proceso.Filters = new TTBusinessRules_RelacionProcessEventCS.TTBusinessRules_RelacionProcessEventFilters[1];
                MyDataEvento_Proceso.Filters[0] = MyDataFilterEvento_Proceso;
                DataSet dsListBox = MyDataEvento_Proceso.SelAll(true);

                int columnIndex = 0;
                if (dsListBox.Tables[0].Columns.Count >= 4)
                    columnIndex = 3;
                else if (dsListBox.Tables[0].Columns.Count >= 2)
                    columnIndex = 1;

                try
                {
                    foreach (DataRow drlist in dsListBox.Tables[0].Rows)
                        dr["TTBusinessRules_Evento_Proceso"] += (dr["TTBusinessRules_Evento_Proceso"].ToString() == string.Empty ? string.Empty : ", ") + drlist[columnIndex].ToString();
                }
                catch { }
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                object keyTTBusinessRules = dr["TTBusinessRules_idBusinessRule"];

                TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent MyDataEvento_Campo = new TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent();
                TTBusinessRules_RelacionFieldEventCS.TTBusinessRules_RelacionFieldEventFilters MyDataFilterEvento_Campo = new TTBusinessRules_RelacionFieldEventCS.TTBusinessRules_RelacionFieldEventFilters();

                MyDataFilterEvento_Campo.idBusinessRules.List = new String[1];
                MyDataFilterEvento_Campo.idBusinessRules.List[0] = keyTTBusinessRules.ToString();

                MyDataEvento_Campo.Filters = new TTBusinessRules_RelacionFieldEventCS.TTBusinessRules_RelacionFieldEventFilters[1];
                MyDataEvento_Campo.Filters[0] = MyDataFilterEvento_Campo;
                DataSet dsListBox = MyDataEvento_Campo.SelAll(true);

                int columnIndex = 0;
                if (dsListBox.Tables[0].Columns.Count >= 4)
                    columnIndex = 3;
                else if (dsListBox.Tables[0].Columns.Count >= 2)
                    columnIndex = 1;

                try
                {
                    foreach (DataRow drlist in dsListBox.Tables[0].Rows)
                        dr["TTBusinessRules_Evento_Campo"] += (dr["TTBusinessRules_Evento_Campo"].ToString() == string.Empty ? string.Empty : ", ") + drlist[columnIndex].ToString();
                }
                catch { }
            }


            return ds;
        }
    
        public void Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTBusinessRules");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_InsTTBusinessRules";
                com.Parameters.AddWithValue("@IdProceso", Conversion.FormatNull(varIdProceso));
                if (varNombre != null)
                    com.Parameters.AddWithValue("@Nombre", varNombre);
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
                com.Parameters.AddWithValue("@Fecha_de_Alta", Conversion.FormatNull(varFecha_de_Alta));
                com.Parameters.AddWithValue("@Alcance", Conversion.FormatNull(varAlcance));

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaInsert(com, UserInformation, DataReference));
                varidBusinessRule = sKey1;

                //for (int i = 0; i < varCondiciones.Length; i++)
                //{
                //    com = new SqlCommand();
                //    com.CommandText = "sp_InsTTBusinessRules_RelacionConditions";
                //    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                //    com.Parameters.AddWithValue("@CondicionOperador", Conversion.FormatNull(varCondiciones[i].CondicionOperador));
                //    com.Parameters.AddWithValue("@Tipo_Operador1", Conversion.FormatNull(varCondiciones[i].Tipo_Operador1));
                //    com.Parameters.AddWithValue("@Valor_Operador1", varCondiciones[i].Valor_Operador1);
                //    com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(varCondiciones[i].Condicion));
                //    com.Parameters.AddWithValue("@Tipo_Operador2", Conversion.FormatNull(varCondiciones[i].Tipo_Operador2));
                //    com.Parameters.AddWithValue("@Valor_Operador2", varCondiciones[i].Valor_Operador2);

                //    com.CommandType = CommandType.StoredProcedure;
                //    db.EjecutaInsert(com, UserInformation, DataReference);
                //}
                //for (int i = 0; i < varAcciones_True.Length; i++)
                //{
                //    com = new SqlCommand();
                //    com.CommandText = "sp_InsTTBusinessRules_RelacionAccionesTrue";
                //    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                //    com.Parameters.AddWithValue("@Tipo_Accion", Conversion.FormatNull(varAcciones_True[i].Tipo_Accion));
                //    com.Parameters.AddWithValue("@Tipo_Accion_Resultado", Conversion.FormatNull(varAcciones_True[i].Tipo_Accion_Resultado));
                //    com.Parameters.AddWithValue("@Parametro1", varAcciones_True[i].Parametro1);
                //    com.Parameters.AddWithValue("@Parametro2", varAcciones_True[i].Parametro2);
                //    com.Parameters.AddWithValue("@Parametro3", varAcciones_True[i].Parametro3);
                //    com.Parameters.AddWithValue("@Parametro4", varAcciones_True[i].Parametro4);
                //    com.Parameters.AddWithValue("@Parametro5", varAcciones_True[i].Parametro5);

                //    com.CommandType = CommandType.StoredProcedure;
                //    db.EjecutaInsert(com, UserInformation, DataReference);
                //}
                //for (int i = 0; i < varAcciones_False.Length; i++)
                //{
                //    com = new SqlCommand();
                //    com.CommandText = "sp_InsTTBusinessRules_RelacionAccionesFalse";
                //    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                //    com.Parameters.AddWithValue("@Tipo_Accion", Conversion.FormatNull(varAcciones_False[i].Tipo_Accion));
                //    com.Parameters.AddWithValue("@Tipo_Accion_Resultado", Conversion.FormatNull(varAcciones_False[i].Tipo_Accion_Resultado));
                //    com.Parameters.AddWithValue("@Parametro1", varAcciones_False[i].Parametro1);
                //    com.Parameters.AddWithValue("@Parametro2", varAcciones_False[i].Parametro2);
                //    com.Parameters.AddWithValue("@Parametro3", varAcciones_False[i].Parametro3);
                //    com.Parameters.AddWithValue("@Parametro4", varAcciones_False[i].Parametro4);
                //    com.Parameters.AddWithValue("@Parametro5", varAcciones_False[i].Parametro5);

                //    com.CommandType = CommandType.StoredProcedure;
                //    db.EjecutaInsert(com, UserInformation, DataReference);
                //}

                //for (int i = 0; i < varCondiciones.Length; i++)
                foreach(TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions objCondiciones in varCondiciones)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionConditions";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@CondicionOperador", Conversion.FormatNull(objCondiciones.CondicionOperador));
                    com.Parameters.AddWithValue("@Tipo_Operador1", Conversion.FormatNull(objCondiciones.Tipo_Operador1));
                    com.Parameters.AddWithValue("@Valor_Operador1", objCondiciones.Valor_Operador1);
                    com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(objCondiciones.Condicion));
                    com.Parameters.AddWithValue("@Tipo_Operador2", Conversion.FormatNull(objCondiciones.Tipo_Operador2));
                    com.Parameters.AddWithValue("@Valor_Operador2", objCondiciones.Valor_Operador2);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                //for (int i = 0; i < varAcciones_True.Length; i++)
                foreach (TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue objAcciones in varAcciones_True)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionAccionesTrue";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@Tipo_Accion", Conversion.FormatNull(objAcciones.Tipo_Accion));
                    com.Parameters.AddWithValue("@Tipo_Accion_Resultado", Conversion.FormatNull(objAcciones.Tipo_Accion_Resultado));
                    com.Parameters.AddWithValue("@Parametro1", objAcciones.Parametro1);
                    com.Parameters.AddWithValue("@Parametro2", objAcciones.Parametro2);
                    com.Parameters.AddWithValue("@Parametro3", objAcciones.Parametro3);
                    com.Parameters.AddWithValue("@Parametro4", objAcciones.Parametro4);
                    com.Parameters.AddWithValue("@Parametro5", objAcciones.Parametro5);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                //for (int i = 0; i < varAcciones_False.Length; i++)
                foreach (TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse objAccionesFalse in varAcciones_False)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionAccionesFalse";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@Tipo_Accion", Conversion.FormatNull(objAccionesFalse.Tipo_Accion));
                    com.Parameters.AddWithValue("@Tipo_Accion_Resultado", Conversion.FormatNull(objAccionesFalse.Tipo_Accion_Resultado));
                    com.Parameters.AddWithValue("@Parametro1", objAccionesFalse.Parametro1);
                    com.Parameters.AddWithValue("@Parametro2", objAccionesFalse.Parametro2);
                    com.Parameters.AddWithValue("@Parametro3", objAccionesFalse.Parametro3);
                    com.Parameters.AddWithValue("@Parametro4", objAccionesFalse.Parametro4);
                    com.Parameters.AddWithValue("@Parametro5", objAccionesFalse.Parametro5);

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                
                for (int i = 0; i < varOperacion.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionOperacion";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@idOperacion", varOperacion[i].idOperacion);
                    //@@DatosDT.ParametrosInsertListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                for (int i = 0; i < varEvento_Proceso.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionProcessEvent";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@idEvent", varEvento_Proceso[i].idEvent);
                    //@@DatosDT.ParametrosInsertListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                for (int i = 0; i < varEvento_Campo.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionFieldEvent";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@idEvent", varEvento_Campo[i].idEvent);
                    //@@DatosDT.ParametrosInsertListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTBusinessRules");
                throw ex;
            }
            //return sKey;
        }
        public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTBusinessRules");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_UpdTTBusinessRules";
                com.Parameters.AddWithValue("@idBusinessRule", Conversion.FormatNull(varidBusinessRule));
                com.Parameters.AddWithValue("@IdProceso", Conversion.FormatNull(varIdProceso));
                if (varNombre != null)
                    com.Parameters.AddWithValue("@Nombre", varNombre);
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
                com.Parameters.AddWithValue("@Fecha_de_Alta", Conversion.FormatNull(varFecha_de_Alta));
                com.Parameters.AddWithValue("@Alcance", Conversion.FormatNull(varAlcance));

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaUpdate(com, UserInformation, DataReference));
                //            varidBusinessRule = sKey1;
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey1.ToString();
                //db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionConditions Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                //for (int i = 0; i < varCondiciones.Length; i++)
                //{
                //    com = new SqlCommand();
                //    com.CommandText = "sp_InsTTBusinessRules_RelacionConditions";
                //    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                //    com.Parameters.AddWithValue("@CondicionOperador", Conversion.FormatNull(varCondiciones[i].CondicionOperador));
                //    com.Parameters.AddWithValue("@Tipo_Operador1", Conversion.FormatNull(varCondiciones[i].Tipo_Operador1));
                //    if (varCondiciones[i].Valor_Operador1 != null)
                //        com.Parameters.AddWithValue("@Valor_Operador1", varCondiciones[i].Valor_Operador1);
                //    else
                //        com.Parameters.AddWithValue("@Valor_Operador1", DBNull.Value);
                //    com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(varCondiciones[i].Condicion));
                //    com.Parameters.AddWithValue("@Tipo_Operador2", Conversion.FormatNull(varCondiciones[i].Tipo_Operador2));
                //    if (varCondiciones[i].Valor_Operador2 != null)
                //        com.Parameters.AddWithValue("@Valor_Operador2", varCondiciones[i].Valor_Operador2);
                //    else
                //        com.Parameters.AddWithValue("@Valor_Operador2", DBNull.Value);

                //    com.CommandType = CommandType.StoredProcedure;
                //    db.EjecutaInsert(com, UserInformation, DataReference);
                //}
                ////TODO Falta Saber como borrar los campos
                //DataReference.Folio = sKey1.ToString();
                //db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionAccionesTrue Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                //for (int i = 0; i < varAcciones_True.Length; i++)
                //{
                //    com = new SqlCommand();
                //    com.CommandText = "sp_InsTTBusinessRules_RelacionAccionesTrue";
                //    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                //    com.Parameters.AddWithValue("@Tipo_Accion", Conversion.FormatNull(varAcciones_True[i].Tipo_Accion));
                //    com.Parameters.AddWithValue("@Tipo_Accion_Resultado", Conversion.FormatNull(varAcciones_True[i].Tipo_Accion_Resultado));
                //    if (varAcciones_True[i].Parametro1 != null)
                //        com.Parameters.AddWithValue("@Parametro1", varAcciones_True[i].Parametro1);
                //    else
                //        com.Parameters.AddWithValue("@Parametro1", DBNull.Value);
                //    if (varAcciones_True[i].Parametro2 != null)
                //        com.Parameters.AddWithValue("@Parametro2", varAcciones_True[i].Parametro2);
                //    else
                //        com.Parameters.AddWithValue("@Parametro2", DBNull.Value);
                //    if (varAcciones_True[i].Parametro3 != null)
                //        com.Parameters.AddWithValue("@Parametro3", varAcciones_True[i].Parametro3);
                //    else
                //        com.Parameters.AddWithValue("@Parametro3", DBNull.Value);
                //    if (varAcciones_True[i].Parametro4 != null)
                //        com.Parameters.AddWithValue("@Parametro4", varAcciones_True[i].Parametro4);
                //    else
                //        com.Parameters.AddWithValue("@Parametro4", DBNull.Value);
                //    if (varAcciones_True[i].Parametro5 != null)
                //        com.Parameters.AddWithValue("@Parametro5", varAcciones_True[i].Parametro5);
                //    else
                //        com.Parameters.AddWithValue("@Parametro5", DBNull.Value);

                //    com.CommandType = CommandType.StoredProcedure;
                //    db.EjecutaInsert(com, UserInformation, DataReference);
                //}
                ////TODO Falta Saber como borrar los campos
                //DataReference.Folio = sKey1.ToString();
                //db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionAccionesFalse Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                //for (int i = 0; i < varAcciones_False.Length; i++)
                //{
                //    com = new SqlCommand();
                //    com.CommandText = "sp_InsTTBusinessRules_RelacionAccionesFalse";
                //    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                //    com.Parameters.AddWithValue("@Tipo_Accion", Conversion.FormatNull(varAcciones_False[i].Tipo_Accion));
                //    com.Parameters.AddWithValue("@Tipo_Accion_Resultado", Conversion.FormatNull(varAcciones_False[i].Tipo_Accion_Resultado));
                //    if (varAcciones_False[i].Parametro1 != null)
                //        com.Parameters.AddWithValue("@Parametro1", varAcciones_False[i].Parametro1);
                //    else
                //        com.Parameters.AddWithValue("@Parametro1", DBNull.Value);
                //    if (varAcciones_False[i].Parametro2 != null)
                //        com.Parameters.AddWithValue("@Parametro2", varAcciones_False[i].Parametro2);
                //    else
                //        com.Parameters.AddWithValue("@Parametro2", DBNull.Value);
                //    if (varAcciones_False[i].Parametro3 != null)
                //        com.Parameters.AddWithValue("@Parametro3", varAcciones_False[i].Parametro3);
                //    else
                //        com.Parameters.AddWithValue("@Parametro3", DBNull.Value);
                //    if (varAcciones_False[i].Parametro4 != null)
                //        com.Parameters.AddWithValue("@Parametro4", varAcciones_False[i].Parametro4);
                //    else
                //        com.Parameters.AddWithValue("@Parametro4", DBNull.Value);
                //    if (varAcciones_False[i].Parametro5 != null)
                //        com.Parameters.AddWithValue("@Parametro5", varAcciones_False[i].Parametro5);
                //    else
                //        com.Parameters.AddWithValue("@Parametro5", DBNull.Value);

                //    com.CommandType = CommandType.StoredProcedure;
                //    db.EjecutaInsert(com, UserInformation, DataReference);
                //}

                //db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionConditions Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                //for (int i = 0; i < varCondiciones.Length; i++)
                foreach (TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions objCondiciones in varCondiciones)
                {
                    com = new SqlCommand();
                    switch (objCondiciones.DBOperation)
                    {
                        case TTEnums.TTenumDBOperation.Delete:
                            com.CommandText = "[dbo].[sp_DelTTBusinessRules_RelacionConditions]";
                            com.Parameters.AddWithValue("@idFolio", objCondiciones.idFolio);
                            com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                                                        
                            com.CommandType = CommandType.StoredProcedure;
                            db.EjecutaDelete(com, UserInformation, DataReference);

                            break;
                        case TTEnums.TTenumDBOperation.Insert:
                        case TTEnums.TTenumDBOperation.Update:
                            if (objCondiciones.idBusinessRules == null)
                                com.CommandText = "sp_InsTTBusinessRules_RelacionConditions";
                            else if (objCondiciones.idBusinessRules != null)
                            {
                                com.CommandText = "[dbo].[sp_UpdTTBusinessRules_RelacionConditions]";
                                com.Parameters.AddWithValue("@idFolio", objCondiciones.idFolio);
                            }
                            com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                            com.Parameters.AddWithValue("@CondicionOperador", Conversion.FormatNull(objCondiciones.CondicionOperador));
                            com.Parameters.AddWithValue("@Tipo_Operador1", Conversion.FormatNull(objCondiciones.Tipo_Operador1));
                            if (objCondiciones.Valor_Operador1 != null)
                                com.Parameters.AddWithValue("@Valor_Operador1", objCondiciones.Valor_Operador1);
                            else
                                com.Parameters.AddWithValue("@Valor_Operador1", DBNull.Value);
                            com.Parameters.AddWithValue("@Condicion", Conversion.FormatNull(objCondiciones.Condicion));
                            com.Parameters.AddWithValue("@Tipo_Operador2", Conversion.FormatNull(objCondiciones.Tipo_Operador2));
                            if (objCondiciones.Valor_Operador2 != null)
                                com.Parameters.AddWithValue("@Valor_Operador2", objCondiciones.Valor_Operador2);
                            else
                                com.Parameters.AddWithValue("@Valor_Operador2", DBNull.Value);

                            com.CommandType = CommandType.StoredProcedure;
                            db.EjecutaInsert(com, UserInformation, DataReference);

                            break;
                        case TTEnums.TTenumDBOperation.None:
                        default:
                            break;                        
                    }
                }
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey1.ToString();
                //db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionAccionesTrue Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                //for (int i = 0; i < varAcciones_True.Length; i++)
                foreach (TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue objAccionesTrue in varAcciones_True)
                {
                    com = new SqlCommand();
                    switch (objAccionesTrue.DBOperation)
                    {
                        case TTEnums.TTenumDBOperation.Delete:
                            com.CommandText = "[dbo].[sp_DelTTBusinessRules_RelacionAccionesTrue]";
                            com.Parameters.AddWithValue("@idFolio", objAccionesTrue.idFolio);
                            com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                            
                            com.CommandType = CommandType.StoredProcedure;
                            db.EjecutaDelete(com, UserInformation, DataReference);
                            break;
                        case TTEnums.TTenumDBOperation.Insert:
                        case TTEnums.TTenumDBOperation.Update:
                            if (objAccionesTrue.idBusinessRules == null)
                                com.CommandText = "[dbo].[sp_InsTTBusinessRules_RelacionAccionesTrue]";
                            else if (objAccionesTrue.idBusinessRules != null)
                            {
                                com.CommandText = "[dbo].[sp_UpdTTBusinessRules_RelacionAccionesTrue]";
                                com.Parameters.AddWithValue("@idFolio", objAccionesTrue.idFolio);
                            }
                            com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                            com.Parameters.AddWithValue("@Tipo_Accion", Conversion.FormatNull(objAccionesTrue.Tipo_Accion));
                            com.Parameters.AddWithValue("@Tipo_Accion_Resultado", Conversion.FormatNull(objAccionesTrue.Tipo_Accion_Resultado));
                            if (objAccionesTrue.Parametro1 != null)
                                com.Parameters.AddWithValue("@Parametro1", objAccionesTrue.Parametro1);
                            else
                                com.Parameters.AddWithValue("@Parametro1", DBNull.Value);
                            if (objAccionesTrue.Parametro2 != null)
                                com.Parameters.AddWithValue("@Parametro2", objAccionesTrue.Parametro2);
                            else
                                com.Parameters.AddWithValue("@Parametro2", DBNull.Value);
                            if (objAccionesTrue.Parametro3 != null)
                                com.Parameters.AddWithValue("@Parametro3", objAccionesTrue.Parametro3);
                            else
                                com.Parameters.AddWithValue("@Parametro3", DBNull.Value);
                            if (objAccionesTrue.Parametro4 != null)
                                com.Parameters.AddWithValue("@Parametro4", objAccionesTrue.Parametro4);
                            else
                                com.Parameters.AddWithValue("@Parametro4", DBNull.Value);
                            if (objAccionesTrue.Parametro5 != null)
                                com.Parameters.AddWithValue("@Parametro5", objAccionesTrue.Parametro5);
                            else
                                com.Parameters.AddWithValue("@Parametro5", DBNull.Value);

                            com.CommandType = CommandType.StoredProcedure;
                            db.EjecutaInsert(com, UserInformation, DataReference);

                            break;
                        case TTEnums.TTenumDBOperation.None:
                        default:
                            break;
                    }
                }
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey1.ToString();
                //db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionAccionesFalse Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                //for (int i = 0; i < varAcciones_False.Length; i++)
                foreach (TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse objAccionesFalse in varAcciones_False)
                {
                    com = new SqlCommand();
                    switch (objAccionesFalse.DBOperation)
                    {
                        case TTEnums.TTenumDBOperation.Delete:
                            com.CommandText = "[dbo].[sp_DelTTBusinessRules_RelacionAccionesFalse]";
                            com.Parameters.AddWithValue("@idFolio", objAccionesFalse.idFolio);
                            com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                            
                            com.CommandType = CommandType.StoredProcedure;
                            db.EjecutaDelete(com, UserInformation, DataReference);
                            break;
                        case TTEnums.TTenumDBOperation.Insert:
                        case TTEnums.TTenumDBOperation.Update:
                            if (objAccionesFalse.idBusinessRules == null)
                                com.CommandText = "[dbo].[sp_InsTTBusinessRules_RelacionAccionesFalse]";
                            else if (objAccionesFalse.idBusinessRules != null)
                            {
                                com.CommandText = "[dbo].[sp_UpdTTBusinessRules_RelacionAccionesFalse]";
                                com.Parameters.AddWithValue("@idFolio", objAccionesFalse.idFolio);
                            }
                            com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                            com.Parameters.AddWithValue("@Tipo_Accion", Conversion.FormatNull(objAccionesFalse.Tipo_Accion));
                            com.Parameters.AddWithValue("@Tipo_Accion_Resultado", Conversion.FormatNull(objAccionesFalse.Tipo_Accion_Resultado));
                            if (objAccionesFalse.Parametro1 != null)
                                com.Parameters.AddWithValue("@Parametro1", objAccionesFalse.Parametro1);
                            else
                                com.Parameters.AddWithValue("@Parametro1", DBNull.Value);
                            if (objAccionesFalse.Parametro2 != null)
                                com.Parameters.AddWithValue("@Parametro2", objAccionesFalse.Parametro2);
                            else
                                com.Parameters.AddWithValue("@Parametro2", DBNull.Value);
                            if (objAccionesFalse.Parametro3 != null)
                                com.Parameters.AddWithValue("@Parametro3", objAccionesFalse.Parametro3);
                            else
                                com.Parameters.AddWithValue("@Parametro3", DBNull.Value);
                            if (objAccionesFalse.Parametro4 != null)
                                com.Parameters.AddWithValue("@Parametro4", objAccionesFalse.Parametro4);
                            else
                                com.Parameters.AddWithValue("@Parametro4", DBNull.Value);
                            if (objAccionesFalse.Parametro5 != null)
                                com.Parameters.AddWithValue("@Parametro5", objAccionesFalse.Parametro5);
                            else
                                com.Parameters.AddWithValue("@Parametro5", DBNull.Value);

                            com.CommandType = CommandType.StoredProcedure;
                            db.EjecutaInsert(com, UserInformation, DataReference);
                            break;
                        case TTEnums.TTenumDBOperation.None:
                        default:
                            break;
                    }
                }

                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionOperacion Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < varOperacion.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionOperacion";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@idOperacion", varOperacion[i].idOperacion);
                    //@@DatosDT.ParametrosUpdateListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionProcessEvent Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < varEvento_Proceso.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionProcessEvent";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@idEvent", varEvento_Proceso[i].idEvent);
                    //@@DatosDT.ParametrosUpdateListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionFieldEvent Where idBusinessRules = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < varEvento_Campo.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTBusinessRules_RelacionFieldEvent";
                    com.Parameters.AddWithValue("@idBusinessRules", sKey1);
                    com.Parameters.AddWithValue("@idEvent", varEvento_Campo[i].idEvent);
                    //@@DatosDT.ParametrosUpdateListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTBusinessRules");
                throw ex;
            }
        }

        public bool Delete(int? Key1, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            //        if (Key == ""){
            //            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //                return false;
            //        }else{
            //if (MessageBox.Show("Estas seguro de eliminar este registro", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
            //    return false;
            Boolean result;
            DataReference.Folio = Key1.ToString();
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTBusinessRules");
            try
            {
                DataReference.Folio = Key1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionConditions Where idBusinessRules = '" + Key1.ToString() + "'"), UserInformation, DataReference);
                DataReference.Folio = Key1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionAccionesTrue Where idBusinessRules = '" + Key1.ToString() + "'"), UserInformation, DataReference);
                DataReference.Folio = Key1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionAccionesFalse Where idBusinessRules = '" + Key1.ToString() + "'"), UserInformation, DataReference);

                DataReference.Folio = Key1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionOperacion Where idBusinessRules = '" + Key1.ToString() + "'"), UserInformation, DataReference);
                DataReference.Folio = Key1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionProcessEvent Where idBusinessRules = '" + Key1.ToString() + "'"), UserInformation, DataReference);
                DataReference.Folio = Key1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTBusinessRules_RelacionFieldEvent Where idBusinessRules = '" + Key1.ToString() + "'"), UserInformation, DataReference);

                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_DelTTBusinessRules";
                com.Parameters.AddWithValue("@idBusinessRule", Key1);
                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTBusinessRules");
                throw ex;
            }
            return result;
            //}
        }
        public DataSet GetByKey(int? Key1, Boolean ConRelaciones)
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
                com.CommandText = "sp_GetComplete_TTBusinessRules";
            else
                com.CommandText = "sp_GetTTBusinessRules";
            com.Parameters.AddWithValue("@idBusinessRule", Key1);

            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
                idBusinessRule = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_idBusinessRule"]);
                IdProceso = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_IdProceso"]);
                Nombre = ds.Tables[0].Rows[0]["TTBusinessRules_Nombre"].ToString().TrimEnd(' ');
                Fecha_de_Alta = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["TTBusinessRules_Fecha_de_Alta"]);
                Alcance = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTBusinessRules_Alcance"]);
                {
                    TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion MyDataOperacion = new TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion();
                    TTBusinessRules_RelacionOperacionCS.TTBusinessRules_RelacionOperacionFilters MyDataFilterOperacion = new TTBusinessRules_RelacionOperacionCS.TTBusinessRules_RelacionOperacionFilters();
                    MyDataFilterOperacion.idBusinessRules.List = new String[1];
                    MyDataFilterOperacion.idBusinessRules.List[0] = Key1.Value.ToString();
                    MyDataOperacion.Filters = new TTBusinessRules_RelacionOperacionCS.TTBusinessRules_RelacionOperacionFilters[1];
                    MyDataOperacion.Filters[0] = MyDataFilterOperacion;
                    DataSet dsListBox = MyDataOperacion.SelAll(true);
                    Operacion = new TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion[dsListBox.Tables[0].Rows.Count];
                    for (int i = 0; i < dsListBox.Tables[0].Rows.Count; i++)
                    {
                        Operacion[i] = new TTBusinessRules_RelacionOperacionCS.objectBussinessTTBusinessRules_RelacionOperacion();
                        Operacion[i].idOperacion = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["TTBusinessRules_RelacionOperacion_idOperacion"].ToString());

                    }
                }
                {
                    TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent MyDataEvento_Proceso = new TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent();
                    TTBusinessRules_RelacionProcessEventCS.TTBusinessRules_RelacionProcessEventFilters MyDataFilterEvento_Proceso = new TTBusinessRules_RelacionProcessEventCS.TTBusinessRules_RelacionProcessEventFilters();
                    MyDataFilterEvento_Proceso.idBusinessRules.List = new String[1];
                    MyDataFilterEvento_Proceso.idBusinessRules.List[0] = Key1.Value.ToString();
                    MyDataEvento_Proceso.Filters = new TTBusinessRules_RelacionProcessEventCS.TTBusinessRules_RelacionProcessEventFilters[1];
                    MyDataEvento_Proceso.Filters[0] = MyDataFilterEvento_Proceso;
                    DataSet dsListBox = MyDataEvento_Proceso.SelAll(true);
                    Evento_Proceso = new TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent[dsListBox.Tables[0].Rows.Count];
                    for (int i = 0; i < dsListBox.Tables[0].Rows.Count; i++)
                    {
                        Evento_Proceso[i] = new TTBusinessRules_RelacionProcessEventCS.objectBussinessTTBusinessRules_RelacionProcessEvent();
                        Evento_Proceso[i].idEvent = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["TTBusinessRules_RelacionProcessEvent_idEvent"].ToString());

                    }
                }
                {
                    TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent MyDataEvento_Campo = new TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent();
                    TTBusinessRules_RelacionFieldEventCS.TTBusinessRules_RelacionFieldEventFilters MyDataFilterEvento_Campo = new TTBusinessRules_RelacionFieldEventCS.TTBusinessRules_RelacionFieldEventFilters();
                    MyDataFilterEvento_Campo.idBusinessRules.List = new String[1];
                    MyDataFilterEvento_Campo.idBusinessRules.List[0] = Key1.Value.ToString();
                    MyDataEvento_Campo.Filters = new TTBusinessRules_RelacionFieldEventCS.TTBusinessRules_RelacionFieldEventFilters[1];
                    MyDataEvento_Campo.Filters[0] = MyDataFilterEvento_Campo;
                    DataSet dsListBox = MyDataEvento_Campo.SelAll(true);
                    Evento_Campo = new TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent[dsListBox.Tables[0].Rows.Count];
                    for (int i = 0; i < dsListBox.Tables[0].Rows.Count; i++)
                    {
                        Evento_Campo[i] = new TTBusinessRules_RelacionFieldEventCS.objectBussinessTTBusinessRules_RelacionFieldEvent();
                        Evento_Campo[i].idEvent = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["TTBusinessRules_RelacionFieldEvent_idEvent"].ToString());

                    }
                }

                {
                    TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions MyDataCondiciones = new TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions();
                    TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters MyDataFilterCondiciones = new TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters();
                    MyDataFilterCondiciones.idBusinessRules.List = new String[1];
                    MyDataFilterCondiciones.idBusinessRules.List[0] = Key1.Value.ToString();
                    MyDataCondiciones.Filters = new TTBusinessRules_RelacionConditionsCS.TTBusinessRules_RelacionConditionsFilters[1];
                    MyDataCondiciones.Filters[0] = MyDataFilterCondiciones;
                    DataSet dsMulti = MyDataCondiciones.SelAll(true);
                    Condiciones = new List<TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions>();
                    TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions objCondiciones;
                    for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                    {
                        objCondiciones = new TTBusinessRules_RelacionConditionsCS.objectBussinessTTBusinessRules_RelacionConditions();
                        objCondiciones.idBusinessRules = int.Parse(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionConditions_idBusinessRules"].ToString());
                        objCondiciones.idFolio = int.Parse(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionConditions_idFolio"].ToString());
                        objCondiciones.CondicionOperador = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionConditions_CondicionOperador"]);
                        objCondiciones.Tipo_Operador1 = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionConditions_Tipo_Operador1"]);
                        objCondiciones.Valor_Operador1 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionConditions_Valor_Operador1"].ToString().TrimEnd(' ');
                        objCondiciones.Condicion = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionConditions_Condicion"]);
                        objCondiciones.Tipo_Operador2 = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionConditions_Tipo_Operador2"]);
                        objCondiciones.Valor_Operador2 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionConditions_Valor_Operador2"].ToString().TrimEnd(' ');
                        Condiciones.Add(objCondiciones);
                    }
                }
                {
                    TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue MyDataAcciones_True = new TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue();
                    TTBusinessRules_RelacionAccionesTrueCS.TTBusinessRules_RelacionAccionesTrueFilters MyDataFilterAcciones_True = new TTBusinessRules_RelacionAccionesTrueCS.TTBusinessRules_RelacionAccionesTrueFilters();
                    MyDataFilterAcciones_True.idBusinessRules.List = new String[1];
                    MyDataFilterAcciones_True.idBusinessRules.List[0] = Key1.Value.ToString();
                    MyDataAcciones_True.Filters = new TTBusinessRules_RelacionAccionesTrueCS.TTBusinessRules_RelacionAccionesTrueFilters[1];
                    MyDataAcciones_True.Filters[0] = MyDataFilterAcciones_True;
                    DataSet dsMulti = MyDataAcciones_True.SelAll(true);
                    Acciones_True = new List<TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue>();
                    TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue objAcciones_True;
                    for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                    {
                        objAcciones_True = new TTBusinessRules_RelacionAccionesTrueCS.objectBussinessTTBusinessRules_RelacionAccionesTrue();
                        objAcciones_True.idBusinessRules = int.Parse(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_idBusinessRules"].ToString());
                        objAcciones_True.idFolio = int.Parse(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_idFolio"].ToString());
                        objAcciones_True.Tipo_Accion = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_Tipo_Accion"]);
                        objAcciones_True.Tipo_Accion_Resultado = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_Tipo_Accion_Resultado"]);
                        objAcciones_True.Parametro1 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_Parametro1"].ToString().TrimEnd(' ');
                        objAcciones_True.Parametro2 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_Parametro2"].ToString().TrimEnd(' ');
                        objAcciones_True.Parametro3 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_Parametro3"].ToString().TrimEnd(' ');
                        objAcciones_True.Parametro4 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_Parametro4"].ToString().TrimEnd(' ');
                        objAcciones_True.Parametro5 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesTrue_Parametro5"].ToString().TrimEnd(' ');
                        Acciones_True.Add(objAcciones_True);
                    }
                }
                {
                    TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse MyDataAcciones_False = new TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse();
                    TTBusinessRules_RelacionAccionesFalseCS.TTBusinessRules_RelacionAccionesFalseFilters MyDataFilterAcciones_False = new TTBusinessRules_RelacionAccionesFalseCS.TTBusinessRules_RelacionAccionesFalseFilters();
                    MyDataFilterAcciones_False.idBusinessRules.List = new String[1];
                    MyDataFilterAcciones_False.idBusinessRules.List[0] = Key1.Value.ToString();
                    MyDataAcciones_False.Filters = new TTBusinessRules_RelacionAccionesFalseCS.TTBusinessRules_RelacionAccionesFalseFilters[1];
                    MyDataAcciones_False.Filters[0] = MyDataFilterAcciones_False;
                    DataSet dsMulti = MyDataAcciones_False.SelAll(true);
                    Acciones_False = new List<TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse>();
                    TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse objAcciones_False;
                    for (int i = 0; i < dsMulti.Tables[0].Rows.Count; i++)
                    {
                        objAcciones_False = new TTBusinessRules_RelacionAccionesFalseCS.objectBussinessTTBusinessRules_RelacionAccionesFalse();
                        objAcciones_False.idBusinessRules = int.Parse(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_idBusinessRules"].ToString());
                        objAcciones_False.idFolio = int.Parse(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_idFolio"].ToString());
                        objAcciones_False.Tipo_Accion = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_Tipo_Accion"]);
                        objAcciones_False.Tipo_Accion_Resultado = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_Tipo_Accion_Resultado"]);
                        objAcciones_False.Parametro1 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_Parametro1"].ToString().TrimEnd(' ');
                        objAcciones_False.Parametro2 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_Parametro2"].ToString().TrimEnd(' ');
                        objAcciones_False.Parametro3 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_Parametro3"].ToString().TrimEnd(' ');
                        objAcciones_False.Parametro4 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_Parametro4"].ToString().TrimEnd(' ');
                        objAcciones_False.Parametro5 = dsMulti.Tables[0].Rows[i]["TTBusinessRules_RelacionAccionesFalse_Parametro5"].ToString().TrimEnd(' ');
                        Acciones_False.Add(objAcciones_False);
                    }
                }


            }
            return ds;
            //}
        }
        public Int32 CurrentPosicion(int? Key1)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTBusinessRules";
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters != null)
                foreach (TTBusinessRulesCS.TTBusinessRulesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTBusinessRules", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Function.FormatNumberNull(dt.Rows[i]["TTBusinessRules_idBusinessRule"]) == Key1)
                    return i;
            }
            return -1;
        }
        public Boolean ValidaExistencia(int? Key1)
        {
            Boolean result;
            DataSet ds;
            //        if (Key == null ){
            //            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //            return false;
            //        }
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_GetTTBusinessRules";
            com.Parameters.AddWithValue("@idBusinessRule", Key1);
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count == 0)
                result = false;
            else
                result = true;
            return result;
        }

        public DataTable FillDataIdProceso(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTProceso";
            com.CommandType = CommandType.StoredProcedure;

            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);

            dt = d.ToTable();
            return dt;

            //DisplayMember = "Nombre";
            //ValueMember = "IdProceso";
        }
        public DataTable FillDataIdProceso()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTProceso";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;

            //DisplayMember = "Nombre";
            //ValueMember = "IdProceso";
        }

        public DataTable FillDataAlcance(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTBusinessRules_Alcance";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();

            return dt;
            //DisplayMember = "Descripcion";
            //ValueMember = "idAlcance";
        }
        public DataTable FillDataAlcance()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTBusinessRules_Alcance";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            return dt;
            //DisplayMember = "Descripcion";
            //ValueMember = "idAlcance";
        }
        public DataTable FillDataOperacion()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionOperacion_Relacion_TTBusinessRules_Operacion";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            ds = db.Consulta(com);

            //DisplayMember = "Descripcion";
            //ValueMember = "idOperacion";
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable FillDataEvento_Proceso()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionProcessEvent_Relacion_TTBusinessRules_ProcessEvent";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            ds = db.Consulta(com);

            //DisplayMember = "Descripcion";
            //ValueMember = "idEvent";

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable FillDataEvento_Campo()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_RelacionFieldEvent_Relacion_TTBusinessRules_FieldEvent";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            ds = db.Consulta(com);

            //DisplayMember = "Descripcion";
            //ValueMember = "idEvent";
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public DataTable FillDataCondiciones(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTBusinessRules_RelacionConditions";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "idFolio";
            //ValueMember = "idFolio";
            return dt;
        }
        public DataTable FillDataCondiciones()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTBusinessRules_RelacionConditions";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "idFolio";
            //ValueMember = "idFolio";
            return dt;
        }

        public DataTable FillDataAcciones_True(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTBusinessRules_RelacionAccionesTrue";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "idBusinessRules";
            //ValueMember = "idBusinessRules";
            return dt;
        }
        public DataTable FillDataAcciones_True()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTBusinessRules_RelacionAccionesTrue";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "idBusinessRules";
            //ValueMember = "idBusinessRules";
            return dt;
        }

        public DataTable FillDataAcciones_False(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTBusinessRules_RelacionAccionesFalse";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "idBusinessRules";
            //ValueMember = "idBusinessRules";
            return dt;
        }
        public DataTable FillDataAcciones_False()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTBusinessRules_Relacion_TTBusinessRules_RelacionAccionesFalse";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "idBusinessRules";
            //ValueMember = "idBusinessRules";
            return dt;
        }

        public static DataTable FillBusinessRulesDTs_x_Process(int idProceso) 
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("spTTBusinessRulesDTs_x_Process");
            com.Parameters.AddWithValue("@ProcessID", idProceso);
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "Nombre"
            //ValueMember = "DNTID" + "." + "DTID";
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
            if (sDTid == "14975")
            {
                this.Filters[indexFilter].idBusinessRule = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15007")
            {
                this.Filters[indexFilter].IdProceso = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTProcesoCS.TTProcesoFilters[])filter;
            }
            if (sDTid == "14976")
            {
                this.Filters[indexFilter].Nombre = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "14977")
            {
                this.Filters[indexFilter].Fecha_de_Alta = (TTClassSpecials.FiltersTypes.filDate)filter;
            }
            if (sDTid == "14980")
            {
                this.Filters[indexFilter].Alcance = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_AlcanceCS.TTBusinessRules_AlcanceFilters[])filter;
            }
            if (sDTid == "14981")
            {
                this.Filters[indexFilter].Operacion = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_RelacionOperacionCS.TTBusinessRules_RelacionOperacionFilters[])filter;
            }
            if (sDTid == "14984")
            {
                this.Filters[indexFilter].Evento_Proceso = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_RelacionProcessEventCS.TTBusinessRules_RelacionProcessEventFilters[])filter;
            }
            if (sDTid == "14987")
            {
                this.Filters[indexFilter].Evento_Campo = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTBusinessRules_RelacionFieldEventCS.TTBusinessRules_RelacionFieldEventFilters[])filter;
            }

        }
    }
}
