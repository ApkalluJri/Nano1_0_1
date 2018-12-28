using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTDashBoard_TemplatesCS
{
    public class TTDashBoard_TemplatesFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varidTemplate =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idTemplate{
            get { return varidTemplate; }
            set { varidTemplate = value; }
        }
        private TTClassSpecials.FiltersTypes.String varDescripcion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Descripcion
        {
            get { return varDescripcion; }
            set { varDescripcion = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varImageTemplate =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric ImageTemplate{
            get { return varImageTemplate; }
            set { varImageTemplate = value; }
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
        private TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters varComponentes =new TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters();
        public TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters Componentes{
            get { return varComponentes; }
            set { varComponentes = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varImageExpanded =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric ImageExpanded{
            get { return varImageExpanded; }
            set { varImageExpanded = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFullScreen_X1 =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric FullScreen_X1{
            get { return varFullScreen_X1; }
            set { varFullScreen_X1 = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFullScreen_Y1 =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric FullScreen_Y1{
            get { return varFullScreen_Y1; }
            set { varFullScreen_Y1 = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFullScreen_X2 =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric FullScreen_X2{
            get { return varFullScreen_X2; }
            set { varFullScreen_X2 = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFullScreen_Y2 =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric FullScreen_Y2{
            get { return varFullScreen_Y2; }
            set { varFullScreen_Y2 = value; }
        }

    }
public class objectBussinessTTDashBoard_Templates{
    public int iProcess = 6808;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTDashBoard_TemplatesFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varidTemplate;
	private String varDescripcion;
	private int? varImageTemplate;
	private int? varPosicionX1;
	private int? varPosicionY1;
	private int? varPosicionX2;
	private int? varPosicionY2;
    private TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente[] varComponentes;
	private int? varImageExpanded;
	private int? varFullScreen_X1;
	private int? varFullScreen_Y1;
	private int? varFullScreen_X2;
	private int? varFullScreen_Y2;
		
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

    public TTDashBoard_TemplatesFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTDashBoard_TemplatesFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTDashBoard_TemplatesFilters[1];
            filters[0] = value;
        }
    }

    public int? idTemplate{
        get { return varidTemplate;}
        set { varidTemplate = value;}
    }
    public String Descripcion{
        get { return varDescripcion;}
        set { varDescripcion = value;}
    }
    public int? ImageTemplate{
        get { return varImageTemplate;}
        set { varImageTemplate = value;}
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
    public TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente[] Componentes{
        get { return varComponentes;}
        set { varComponentes = value;}
    }
    public int? ImageExpanded{
        get { return varImageExpanded;}
        set { varImageExpanded = value;}
    }
    public int? FullScreen_X1{
        get { return varFullScreen_X1;}
        set { varFullScreen_X1 = value;}
    }
    public int? FullScreen_Y1{
        get { return varFullScreen_Y1;}
        set { varFullScreen_Y1 = value;}
    }
    public int? FullScreen_X2{
        get { return varFullScreen_X2;}
        set { varFullScreen_X2 = value;}
    }
    public int? FullScreen_Y2{
        get { return varFullScreen_Y2;}
        set { varFullScreen_Y2 = value;}
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
            com.CommandText = "sp_SelAllComplete_TTDashBoard_Templates_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTDashBoard_Templates";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTDashBoard_TemplatesCS.TTDashBoard_TemplatesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoard_Templates", fil);
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
                com.CommandText = "sp_SelAllComplete_TTDashBoard_Templates_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTDashBoard_Templates";
        else
            com.CommandText="sp_SelAllTTDashBoard_Templates";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTDashBoard_TemplatesCS.TTDashBoard_TemplatesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoard_Templates", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTDashBoard_Templates", fil);
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
                com.CommandText = "sp_SelAllComplete_TTDashBoard_Templates_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTDashBoard_Templates";
        else
            com.CommandText="sp_SelAllTTDashBoard_Templates";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTDashBoard_TemplatesCS.TTDashBoard_TemplatesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoard_Templates", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTDashBoard_Templates", fil);
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
        db.BeginTransaction("TTDashBoard_Templates");
        int? sKey1 = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTDashBoard_Templates";
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", varDescripcion);
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            com.Parameters.AddWithValue("@ImageTemplate",Conversion.FormatNull(varImageTemplate));
            com.Parameters.AddWithValue("@PosicionX1",Conversion.FormatNull(varPosicionX1));
            com.Parameters.AddWithValue("@PosicionY1",Conversion.FormatNull(varPosicionY1));
            com.Parameters.AddWithValue("@PosicionX2",Conversion.FormatNull(varPosicionX2));
            com.Parameters.AddWithValue("@PosicionY2",Conversion.FormatNull(varPosicionY2));
            com.Parameters.AddWithValue("@ImageExpanded",Conversion.FormatNull(varImageExpanded));
            com.Parameters.AddWithValue("@FullScreen_X1",Conversion.FormatNull(varFullScreen_X1));
            com.Parameters.AddWithValue("@FullScreen_Y1",Conversion.FormatNull(varFullScreen_Y1));
            com.Parameters.AddWithValue("@FullScreen_X2",Conversion.FormatNull(varFullScreen_X2));
            com.Parameters.AddWithValue("@FullScreen_Y2",Conversion.FormatNull(varFullScreen_Y2));

            com.CommandType =CommandType.StoredProcedure;
            sKey1 = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varidTemplate = sKey1;
            
            for (int i = 0;i< varComponentes.Length; i++)
            {
                com = new SqlCommand();
                com.CommandText = "sp_InsTTDashBoard_TemplatesRelacionComponente";
                com.Parameters.AddWithValue("@idDashBoardTemplate", sKey1);
                com.Parameters.AddWithValue("@idTipoComponente", Conversion.FormatNull(varComponentes[i].idTipoComponente));
                com.Parameters.AddWithValue("@PosicionX1", Conversion.FormatNull(varComponentes[i].PosicionX1));
                com.Parameters.AddWithValue("@PosicionY1", Conversion.FormatNull(varComponentes[i].PosicionY1));
                com.Parameters.AddWithValue("@PosicionX2", Conversion.FormatNull(varComponentes[i].PosicionX2));
                com.Parameters.AddWithValue("@PosicionY2", Conversion.FormatNull(varComponentes[i].PosicionY2));

                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaInsert(com, UserInformation, DataReference);
            }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTDashBoard_Templates");
            throw ex; 
        }
        //return sKey;
    }
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        db.BeginTransaction("TTDashBoard_Templates");
        int? sKey1 = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTDashBoard_Templates";
            com.Parameters.AddWithValue("@idTemplate",Conversion.FormatNull(varidTemplate));
            if (varDescripcion!=null)
                com.Parameters.AddWithValue("@Descripcion", varDescripcion);
            else
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            com.Parameters.AddWithValue("@ImageTemplate",Conversion.FormatNull(varImageTemplate));
            com.Parameters.AddWithValue("@PosicionX1",Conversion.FormatNull(varPosicionX1));
            com.Parameters.AddWithValue("@PosicionY1",Conversion.FormatNull(varPosicionY1));
            com.Parameters.AddWithValue("@PosicionX2",Conversion.FormatNull(varPosicionX2));
            com.Parameters.AddWithValue("@PosicionY2",Conversion.FormatNull(varPosicionY2));
            com.Parameters.AddWithValue("@ImageExpanded",Conversion.FormatNull(varImageExpanded));
            com.Parameters.AddWithValue("@FullScreen_X1",Conversion.FormatNull(varFullScreen_X1));
            com.Parameters.AddWithValue("@FullScreen_Y1",Conversion.FormatNull(varFullScreen_Y1));
            com.Parameters.AddWithValue("@FullScreen_X2",Conversion.FormatNull(varFullScreen_X2));
            com.Parameters.AddWithValue("@FullScreen_Y2",Conversion.FormatNull(varFullScreen_Y2));

            com.CommandType =CommandType.StoredProcedure;
            sKey1 = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varidTemplate = sKey1;
        //TODO Falta Saber como borrar los campos
        DataReference.Folio = sKey1.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from TTDashBoard_TemplatesRelacionComponente Where idDashBoardTemplate = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
            for (int i = 0;i< varComponentes.Length; i++)
            {
                com = new SqlCommand();
                com.CommandText = "sp_InsTTDashBoard_TemplatesRelacionComponente";
                com.Parameters.AddWithValue("@idDashBoardTemplate", sKey1);
                com.Parameters.AddWithValue("@idTipoComponente", Conversion.FormatNull(varComponentes[i].idTipoComponente));
                com.Parameters.AddWithValue("@PosicionX1", Conversion.FormatNull(varComponentes[i].PosicionX1));
                com.Parameters.AddWithValue("@PosicionY1", Conversion.FormatNull(varComponentes[i].PosicionY1));
                com.Parameters.AddWithValue("@PosicionX2", Conversion.FormatNull(varComponentes[i].PosicionX2));
                com.Parameters.AddWithValue("@PosicionY2", Conversion.FormatNull(varComponentes[i].PosicionY2));

                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaInsert(com, UserInformation, DataReference);
            }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTDashBoard_Templates");
            throw ex; 
        }
    }

    public bool Delete(int? Key1, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  Key1.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTDashBoard_Templates");
            try
            {
        DataReference.Folio = Key1.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from TTDashBoard_TemplatesRelacionComponente Where idDashBoardTemplate = '" + Key1.ToString() + "'"), UserInformation, DataReference);


                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTDashBoard_Templates";
com.Parameters.AddWithValue("@idTemplate",Key1);
                com.CommandType =CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTDashBoard_Templates");
                throw ex; 
            }
            return result;
        //}
    }
    public DataSet GetByKey(int? Key1, Boolean ConRelaciones){
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
                com.CommandText="sp_GetComplete_TTDashBoard_Templates";
            else
                com.CommandText="sp_GetTTDashBoard_Templates";
com.Parameters.AddWithValue("@idTemplate",Key1);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
            idTemplate = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_idTemplate"]);
            Descripcion = ds.Tables[0].Rows[0]["TTDashBoard_Templates_Descripcion"].ToString().TrimEnd(' ');
            ImageTemplate = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_ImageTemplate"]);
            PosicionX1 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_PosicionX1"]);
            PosicionY1 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_PosicionY1"]);
            PosicionX2 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_PosicionX2"]);
            PosicionY2 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_PosicionY2"]);
            ImageExpanded = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_ImageExpanded"]);
            FullScreen_X1 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_FullScreen_X1"]);
            FullScreen_Y1 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_FullScreen_Y1"]);
            FullScreen_X2 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_FullScreen_X2"]);
            FullScreen_Y2 = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoard_Templates_FullScreen_Y2"]);

                {
                    TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente MyDataComponentes = new TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente();
                    TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters MyDataFilterComponentes = new TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters();
                    MyDataFilterComponentes.idDashBoardTemplate.List = new String[1];
                    MyDataFilterComponentes.idDashBoardTemplate.List[0] = Key1.Value.ToString();
                    MyDataComponentes.Filters = new TTDashBoard_TemplatesRelacionComponenteCS.TTDashBoard_TemplatesRelacionComponenteFilters[1];
                    MyDataComponentes.Filters[0] = MyDataFilterComponentes;
                    DataSet dsMulti = MyDataComponentes.SelAll(true);
                    Componentes = new TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Componentes[i] = new TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente();
                    Componentes[i].idTipoComponente = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTDashBoard_TemplatesRelacionComponente_idTipoComponente"]);
                    Componentes[i].PosicionX1 = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTDashBoard_TemplatesRelacionComponente_PosicionX1"]);
                    Componentes[i].PosicionY1 = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTDashBoard_TemplatesRelacionComponente_PosicionY1"]);
                    Componentes[i].PosicionX2 = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTDashBoard_TemplatesRelacionComponente_PosicionX2"]);
                    Componentes[i].PosicionY2 = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTDashBoard_TemplatesRelacionComponente_PosicionY2"]);

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
        com.CommandText = "sp_SelAllComplete_TTDashBoard_Templates";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTDashBoard_TemplatesCS.TTDashBoard_TemplatesFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoard_Templates", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTDashBoard_Templates_idTemplate"]) == Key1)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? Key1){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTDashBoard_Templates";
com.Parameters.AddWithValue("@idTemplate",Key1);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataComponentesControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Folio";
                        ((ComboBox)ctr).ValueMember = "Folio";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Folio"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Folio";
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Folio";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataComponentes(Object ctr, String Filtro){
            public DataTable FillDataComponentes(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoard_Templates_Relacion_TTDashBoard_TemplatesRelacionComponente";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataComponentesControl(ctr, dt);
                return dt;
            }
//            public void FillDataComponentes(Object ctr){
            public DataTable FillDataComponentes(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoard_Templates_Relacion_TTDashBoard_TemplatesRelacionComponente";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataComponentesControl(ctr, dt);
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
        ev.Graphics.DrawString("TTDashBoard Templates", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        ev.Graphics.DrawString("Folio: " + this.varidTemplate, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Descripción: " + this.varDescripcion, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Titulo Posicion X1: " + this.varPosicionX1, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Titulo Posicion Y1: " + this.varPosicionY1, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Titulo Posicion X2: " + this.varPosicionX2, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Titulo Posicion Y2: " + this.varPosicionY2, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        yPos += 10;
        printFont = new Font("Arial", 12, FontStyle.Underline);
        ev.Graphics.DrawString("Componentes (" + this.Componentes.Length + ")", printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
//        ev.Graphics.DrawLine (pHight,0,yPos,xWidth,yPos);
//        yPos += 8;
        foreach (TTDashBoard_TemplatesRelacionComponenteCS.objectBussinessTTDashBoard_TemplatesRelacionComponente myRelationWhitTTDashBoard_TemplatesRelacionComponente in this.Componentes)
        {
            if (myRelationWhitTTDashBoard_TemplatesRelacionComponente.idTipoComponente != null)
            {
                TTDashBoard_ComponentTypeCS.objectBussinessTTDashBoard_ComponentType myRelationMultiWhitTTDashBoard_ComponentType = new TTDashBoard_ComponentTypeCS.objectBussinessTTDashBoard_ComponentType();
                myRelationMultiWhitTTDashBoard_ComponentType.GetByKey(myRelationWhitTTDashBoard_TemplatesRelacionComponente.idTipoComponente, true);
                ev.Graphics.DrawString("Tipo de Componente: " + myRelationMultiWhitTTDashBoard_ComponentType.Descripcion , printFont, Brushes.Black, 10, yPos, new StringFormat());
                yPos += printFont.Height;
            }

                ev.Graphics.DrawString("Posicion X1: " + myRelationWhitTTDashBoard_TemplatesRelacionComponente.PosicionX1, printFont, Brushes.Black, 10, yPos, new StringFormat());
                yPos += printFont.Height;

                ev.Graphics.DrawString("Posicion Y1: " + myRelationWhitTTDashBoard_TemplatesRelacionComponente.PosicionY1, printFont, Brushes.Black, 10, yPos, new StringFormat());
                yPos += printFont.Height;

                ev.Graphics.DrawString("Posicion X2: " + myRelationWhitTTDashBoard_TemplatesRelacionComponente.PosicionX2, printFont, Brushes.Black, 10, yPos, new StringFormat());
                yPos += printFont.Height;

                ev.Graphics.DrawString("Posicion Y2: " + myRelationWhitTTDashBoard_TemplatesRelacionComponente.PosicionY2, printFont, Brushes.Black, 10, yPos, new StringFormat());
                yPos += printFont.Height;


                ev.Graphics.DrawLine(pLight, 0, yPos, xWidth, yPos);
                yPos += 8;
        }
        ev.Graphics.DrawString("Posicion X1: " + this.varFullScreen_X1, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Posicion Y1: " + this.varFullScreen_Y1, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Posicion X2: " + this.varFullScreen_X2, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Posicion Y2: " + this.varFullScreen_Y2, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            if (sDTid == "15214")
            {
                this.Filters[indexFilter].idTemplate = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15215")
            {
                this.Filters[indexFilter].Descripcion = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15216")
            {
                this.Filters[indexFilter].ImageTemplate = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15217")
            {
                this.Filters[indexFilter].PosicionX1 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15218")
            {
                this.Filters[indexFilter].PosicionY1 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15219")
            {
                this.Filters[indexFilter].PosicionX2 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15220")
            {
                this.Filters[indexFilter].PosicionY2 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "30014")
            {
                this.Filters[indexFilter].ImageExpanded = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "30015")
            {
                this.Filters[indexFilter].FullScreen_X1 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "30016")
            {
                this.Filters[indexFilter].FullScreen_Y1 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "30017")
            {
                this.Filters[indexFilter].FullScreen_X2 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "30018")
            {
                this.Filters[indexFilter].FullScreen_Y2 = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }

        }
    }
}
