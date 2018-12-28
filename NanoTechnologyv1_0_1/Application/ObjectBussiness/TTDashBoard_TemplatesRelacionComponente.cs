using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTDashBoard_TemplatesRelacionComponenteCS
{
    public class TTDashBoard_TemplatesRelacionComponenteFilters
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
        private TTClassSpecials.FiltersTypes.Dependientes varidDashBoardTemplate =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDashBoard_TemplatesCS.TTDashBoard_TemplatesFilters[] varidDashBoardTemplate;
        public TTClassSpecials.FiltersTypes.Dependientes idDashBoardTemplate{
            get { return varidDashBoardTemplate; }
            set { varidDashBoardTemplate = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFolio =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Folio{
            get { return varFolio; }
            set { varFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varidTipoComponente =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDashBoard_ComponentTypeCS.TTDashBoard_ComponentTypeFilters[] varidTipoComponente;
        public TTClassSpecials.FiltersTypes.Dependientes idTipoComponente{
            get { return varidTipoComponente; }
            set { varidTipoComponente = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varPosicionX1 =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric PosicionX1{
            get { return varPosicionX1; }
            set { varPosicionX1 = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varPosicionY1 =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric PosicionY1{
            get { return varPosicionY1; }
            set { varPosicionY1 = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varPosicionX2 =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric PosicionX2{
            get { return varPosicionX2; }
            set { varPosicionX2 = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varPosicionY2 =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric PosicionY2{
            get { return varPosicionY2; }
            set { varPosicionY2 = value; }
        }

    }
public class objectBussinessTTDashBoard_TemplatesRelacionComponente{
    public int iProcess = 6809;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTDashBoard_TemplatesRelacionComponenteFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varidDashBoardTemplate;
	private int? varFolio;
	private int? varidTipoComponente;
	private int? varPosicionX1;
	private int? varPosicionY1;
	private int? varPosicionX2;
	private int? varPosicionY2;
		
    private String varOrderClickHeaderCellType="";
    private String varOrderClickHeaderCell="";
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
        get { return myFilters;} 
        set { myFilters = value;}
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

    public TTDashBoard_TemplatesRelacionComponenteFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTDashBoard_TemplatesRelacionComponenteFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTDashBoard_TemplatesRelacionComponenteFilters[1];
            filters[0] = value;
        }
    }

    public int? idDashBoardTemplate{
        get { return varidDashBoardTemplate;}
        set { varidDashBoardTemplate = value;}
    }
    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public int? idTipoComponente{
        get { return varidTipoComponente;}
        set { varidTipoComponente = value;}
    }
    public int? PosicionX1{
        get { return varPosicionX1;}
        set { varPosicionX1 = value;}
    }
    public int? PosicionY1{
        get { return varPosicionY1;}
        set { varPosicionY1 = value;}
    }
    public int? PosicionX2{
        get { return varPosicionX2;}
        set { varPosicionX2 = value;}
    }
    public int? PosicionY2{
        get { return varPosicionY2;}
        set { varPosicionY2 = value;}
    }


    public Int32 SelCount()
    {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            string swhere = "";
        if (this.myFilters!=null)
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

        if (swhere != "")
        {
            com.Parameters.AddWithValue("@Filter"," where " + swhere);
            com.CommandText = "sp_SelAllComplete_TTDashBoard_TemplatesRelacionComponente_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTDashBoard_TemplatesRelacionComponente";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoard_TemplatesRelacionComponente", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);

            DataSet ds2 = new DataSet();
            ds2.Tables.Add(Function.SelectDataTable(ds.Tables[0], swhere, ""));
            return ds2.Tables[0].Rows.Count;
    }

    public DataSet SelAll(Boolean ConRelaciones)
    {
                DataSet ds;
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType=CommandType.StoredProcedure;

        String swhere="";
        String sOrderBy = "";
        if (this.myFilters!=null)
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
                //else
                    //sOrderBy += "," + fil.GenerateOrderBy();
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
                if (sOrderBy=="")
                    sOrderBy += fil.GenerateOrderBy();
                //else
                    //sOrderBy += ","+fil.GenerateOrderBy();
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);

        if (ConRelaciones ==true)
            if (swhere != "")
            {
                com.Parameters.AddWithValue("@Filter"," where " + swhere);
                com.CommandText = "sp_SelAllComplete_TTDashBoard_TemplatesRelacionComponente_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTDashBoard_TemplatesRelacionComponente";
        else
            com.CommandText="sp_SelAllTTDashBoard_TemplatesRelacionComponente";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoard_TemplatesRelacionComponente", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTDashBoard_TemplatesRelacionComponente", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
        if (swhere != "")
            swhere = swhere.Substring(4);
        if (varOrderClickHeaderCell!="")
        {
            if (varOrderClickHeaderCellType !=" Desc")
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
        com.CommandType = CommandType.StoredProcedure;
        String sOrderBy = "";
        String swhere="";
        if (this.myFilters!=null)
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
                //else
                    //sOrderBy += "," + fil.GenerateOrderBy();
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
                if (sOrderBy=="")
                    sOrderBy += fil.GenerateOrderBy();
                //else
                    //sOrderBy += ","+fil.GenerateOrderBy();
        if (this.myFiltersQuick != null)
            if (swhere == "")
                swhere += this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
            else
                swhere += " and " + this.myFiltersQuick.GenerateWhereWithOutLeftJoin(null);
        if (swhere.Length >= 4)
            if (swhere.Substring(swhere.Length - 4) == "and ")
                swhere = swhere.Substring(0, swhere.Length - 4);



        if (ConRelaciones ==true)
            if (swhere != "")
            {
                com.Parameters.AddWithValue("@Filter"," where " + swhere);
                com.CommandText = "sp_SelAllComplete_TTDashBoard_TemplatesRelacionComponente_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTDashBoard_TemplatesRelacionComponente";
        else
            com.CommandText="sp_SelAllTTDashBoard_TemplatesRelacionComponente";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoard_TemplatesRelacionComponente", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTDashBoard_TemplatesRelacionComponente", fil);
                    if (sOrderByT != "")
                        sOrderBy = sOrderByT;
                }
        if (swhere != "")
            swhere = swhere.Substring(4);
        if (varOrderClickHeaderCell!="")
        {
            if (varOrderClickHeaderCellType !=" Desc")
                sOrderBy = varOrderClickHeaderCell + " Asc";
            else
                sOrderBy = varOrderClickHeaderCell + " Desc";
        }
        return Function.SelectDataTable(ds.Tables[0], swhere, sOrderBy, CurrentRecordInt32, RecordsDisplayedInt32);
    }
    public void Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        db.BeginTransaction("TTDashBoard_TemplatesRelacionComponente");
        int? sKey1 = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTDashBoard_TemplatesRelacionComponente";
            com.Parameters.AddWithValue("@idDashBoardTemplate",Conversion.FormatNull(varidDashBoardTemplate));
            com.Parameters.AddWithValue("@idTipoComponente",Conversion.FormatNull(varidTipoComponente));
            com.Parameters.AddWithValue("@PosicionX1",Conversion.FormatNull(varPosicionX1));
            com.Parameters.AddWithValue("@PosicionY1",Conversion.FormatNull(varPosicionY1));
            com.Parameters.AddWithValue("@PosicionX2",Conversion.FormatNull(varPosicionX2));
            com.Parameters.AddWithValue("@PosicionY2",Conversion.FormatNull(varPosicionY2));

            com.CommandType =CommandType.StoredProcedure;
            sKey1 = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKey1;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTDashBoard_TemplatesRelacionComponente");
            throw ex; 
        }
        //return sKey;
    }
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        db.BeginTransaction("TTDashBoard_TemplatesRelacionComponente");
        int? sKey1 = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTDashBoard_TemplatesRelacionComponente";
            com.Parameters.AddWithValue("@idDashBoardTemplate",Conversion.FormatNull(varidDashBoardTemplate));
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@idTipoComponente",Conversion.FormatNull(varidTipoComponente));
            com.Parameters.AddWithValue("@PosicionX1",Conversion.FormatNull(varPosicionX1));
            com.Parameters.AddWithValue("@PosicionY1",Conversion.FormatNull(varPosicionY1));
            com.Parameters.AddWithValue("@PosicionX2",Conversion.FormatNull(varPosicionX2));
            com.Parameters.AddWithValue("@PosicionY2",Conversion.FormatNull(varPosicionY2));

            com.CommandType =CommandType.StoredProcedure;
            sKey1 = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKey1;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTDashBoard_TemplatesRelacionComponente");
            throw ex; 
        }
    }

    public bool Delete(int? Key1, int? Key2, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  Key1.ToString()+ ","+ Key2.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTDashBoard_TemplatesRelacionComponente");
            try
            {


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTDashBoard_TemplatesRelacionComponente";
com.Parameters.AddWithValue("@idDashBoardTemplate",Key1);com.Parameters.AddWithValue("@Folio",Key2);
                com.CommandType =CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTDashBoard_TemplatesRelacionComponente");
                throw ex; 
            }
            return result;
        //}
    }
    public DataSet GetByKey(int? Key1, int? Key2, Boolean ConRelaciones){
        DataSet ds;
        if (Key1 == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_TTDashBoard_TemplatesRelacionComponente";
            else
                com.CommandText="sp_GetTTDashBoard_TemplatesRelacionComponente";
com.Parameters.AddWithValue("@idDashBoardTemplate",Key1);com.Parameters.AddWithValue("@Folio",Key2);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
            idDashBoardTemplate = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_TemplatesRelacionComponente_idDashBoardTemplate"]);
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_TemplatesRelacionComponente_Folio"]);
            idTipoComponente = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_TemplatesRelacionComponente_idTipoComponente"]);
            PosicionX1 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_TemplatesRelacionComponente_PosicionX1"]);
            PosicionY1 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_TemplatesRelacionComponente_PosicionY1"]);
            PosicionX2 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_TemplatesRelacionComponente_PosicionX2"]);
            PosicionY2 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_TemplatesRelacionComponente_PosicionY2"]);



            }
            return ds;
        //}
    }
    public Int32 CurrentPosicion(int? Key1, int? Key2)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTDashBoard_TemplatesRelacionComponente";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoard_TemplatesRelacionComponente", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTDashBoard_TemplatesRelacionComponente_idDashBoardTemplate"]) == Key1&& Function.FormatNumberNull(dt.Rows[i]["TTDashBoard_TemplatesRelacionComponente_Folio"]) == Key2)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? Key1, int? Key2){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTDashBoard_TemplatesRelacionComponente";
com.Parameters.AddWithValue("@idDashBoardTemplate",Key1);com.Parameters.AddWithValue("@Folio",Key2);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataidDashBoardTemplateControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "idTemplate";
                        ((ComboBox)ctr).ValueMember = "idTemplate";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["idTemplate"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "idTemplate";
                        ((ListBox)ctr).ValueMember = "idTemplate";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "idTemplate";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "idTemplate";
                }
            }
*///            public DataTable FillDataidDashBoardTemplate(Object ctr, String Filtro){
            public DataTable FillDataidDashBoardTemplate(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoard_TemplatesRelacionComponente_Relacion_TTDashBoard_Templates";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataidDashBoardTemplateControl(ctr, dt);
                return dt;
            }
//            public void FillDataidDashBoardTemplate(Object ctr){
            public DataTable FillDataidDashBoardTemplate(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoard_TemplatesRelacionComponente_Relacion_TTDashBoard_Templates";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataidDashBoardTemplateControl(ctr, dt);
                return dt;
            }
/*            private void FillDataidTipoComponenteControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "idType";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Descripcion"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Descripcion";
                        ((ListBox)ctr).ValueMember = "idType";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "idType";
                }
            }
*///            public DataTable FillDataidTipoComponente(Object ctr, String Filtro){
            public DataTable FillDataidTipoComponente(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoard_TemplatesRelacionComponente_Relacion_TTDashBoard_ComponentType";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataidTipoComponenteControl(ctr, dt);
                return dt;
            }
//            public void FillDataidTipoComponente(Object ctr){
            public DataTable FillDataidTipoComponente(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoard_TemplatesRelacionComponente_Relacion_TTDashBoard_ComponentType";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataidTipoComponenteControl(ctr, dt);
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
                        if (tTSearchAdvancedDataDetails.ListaDependientes.Length >0)
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
        public void Print(TTSecurity.GlobalData GlobalInformation)
        {
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pd_PrintPage);
            pd.Print();
        }
    private void pd_PrintPage(Object sender, System.Drawing.Printing.PrintPageEventArgs ev)
    {
        float yPos = 0;
        float xWidth = ev.PageSettings.PrintableArea.Width;
        Font printFont = new Font("Arial", 13, FontStyle.Underline);
        Pen pHight = new Pen(Color.Black, 3);
        Pen pLight = new Pen(Color.Black, 1);
        ev.Graphics.DrawString("TTDashBoard TemplatesRelacionComponente", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        if (this.varidDashBoardTemplate != null)
        {
            TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates myRelationWhitTTDashBoard_Templates = new TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates();
            myRelationWhitTTDashBoard_Templates.GetByKey(this.varidDashBoardTemplate, true);
            ev.Graphics.DrawString("Folio de Template: " + myRelationWhitTTDashBoard_Templates.idTemplate , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("Folio de Template: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        ev.Graphics.DrawString("Folio: " + this.varFolio, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varidTipoComponente != null)
        {
            TTDashBoard_ComponentTypeCS.objectBussinessTTDashBoard_ComponentType myRelationWhitTTDashBoard_ComponentType = new TTDashBoard_ComponentTypeCS.objectBussinessTTDashBoard_ComponentType();
            myRelationWhitTTDashBoard_ComponentType.GetByKey(this.varidTipoComponente, true);
            ev.Graphics.DrawString("Tipo de Componente: " + myRelationWhitTTDashBoard_ComponentType.Descripcion , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("Tipo de Componente: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        ev.Graphics.DrawString("Posicion X1: " + this.varPosicionX1, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Posicion Y1: " + this.varPosicionY1, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Posicion X2: " + this.varPosicionX2, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Posicion Y2: " + this.varPosicionY2, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            if (sDTid == "15221")
            {
                this.Filters[indexFilter].idDashBoardTemplate = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDashBoard_TemplatesCS.TTDashBoard_TemplatesFilters[])filter;
            }
            if (sDTid == "15222")
            {
                this.Filters[indexFilter].Folio = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15225")
            {
                this.Filters[indexFilter].idTipoComponente = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDashBoard_ComponentTypeCS.TTDashBoard_ComponentTypeFilters[])filter;
            }
            if (sDTid == "15226")
            {
                this.Filters[indexFilter].PosicionX1 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15227")
            {
                this.Filters[indexFilter].PosicionY1 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15228")
            {
                this.Filters[indexFilter].PosicionX2 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15229")
            {
                this.Filters[indexFilter].PosicionY2 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }

        }
    }
}
