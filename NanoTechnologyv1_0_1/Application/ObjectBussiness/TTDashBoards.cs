using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTDashBoardsCS
{
    public class TTDashBoardsFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varidDashBorad =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idDashBorad{
            get { return varidDashBorad; }
            set { varidDashBorad = value; }
        }
        private TTClassSpecials.FiltersTypes.String varTitulo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Titulo
        {
            get { return varTitulo; }
            set { varTitulo = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varidTemplate =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDashBoard_TemplatesCS.TTDashBoard_TemplatesFilters[] varidTemplate;
        public TTClassSpecials.FiltersTypes.Dependientes idTemplate{
            get { return varidTemplate; }
            set { varidTemplate = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varTiempoRefrescar =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric TiempoRefrescar{
            get { return varTiempoRefrescar; }
            set { varTiempoRefrescar = value; }
        }
        private TTDashBoards_RelacionComponentesCS.TTDashBoards_RelacionComponentesFilters varComponentes =new TTDashBoards_RelacionComponentesCS.TTDashBoards_RelacionComponentesFilters();
        public TTDashBoards_RelacionComponentesCS.TTDashBoards_RelacionComponentesFilters Componentes{
            get { return varComponentes; }
            set { varComponentes = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varUsuario =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varUsuario;
        public TTClassSpecials.FiltersTypes.Dependientes Usuario{
            get { return varUsuario; }
            set { varUsuario = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varGrupoUsuario =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTDashBoards_RelacionGrupoUsuariosCS.TTDashBoards_RelacionGrupoUsuariosFilters[] varGrupoUsuario;
        public TTClassSpecials.FiltersTypes.Dependientes GrupoUsuario{
            get { return varGrupoUsuario; }
            set { varGrupoUsuario = value; }
        }

    }
public class objectBussinessTTDashBoards{
    public int iProcess = 6811;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTDashBoardsFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varidDashBorad;
	private String varTitulo;
	private int? varidTemplate;
	private int? varTiempoRefrescar;
    private TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes[] varComponentes;
	private int? varUsuario;
	private TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios[] varGrupoUsuario;
		
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

    public TTDashBoardsFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTDashBoardsFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTDashBoardsFilters[1];
            filters[0] = value;
        }
    }

    public int? idDashBorad{
        get { return varidDashBorad;}
        set { varidDashBorad = value;}
    }
    public String Titulo{
        get { return varTitulo;}
        set { varTitulo = value;}
    }
    public int? idTemplate{
        get { return varidTemplate;}
        set { varidTemplate = value;}
    }
    public int? TiempoRefrescar{
        get { return varTiempoRefrescar;}
        set { varTiempoRefrescar = value;}
    }
    public TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes[] Componentes{
        get { return varComponentes;}
        set { varComponentes = value;}
    }
    public int? Usuario{
        get { return varUsuario;}
        set { varUsuario = value;}
    }
    public TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios[] GrupoUsuario{
        get { return varGrupoUsuario;}
        set { varGrupoUsuario = value;}
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
            com.CommandText = "sp_SelAllComplete_TTDashBoards_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTDashBoards";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTDashBoardsCS.TTDashBoardsFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoards", fil);
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
                com.CommandText = "sp_SelAllComplete_TTDashBoards_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTDashBoards";
        else
            com.CommandText="sp_SelAllTTDashBoards";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTDashBoardsCS.TTDashBoardsFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoards", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTDashBoards", fil);
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
                com.CommandText = "sp_SelAllComplete_TTDashBoards_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTDashBoards";
        else
            com.CommandText="sp_SelAllTTDashBoards";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTDashBoardsCS.TTDashBoardsFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoards", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTDashBoards", fil);
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
        db.BeginTransaction("TTDashBoards");
        int? sKey1 = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTDashBoards";
            if (varTitulo!=null)
                com.Parameters.AddWithValue("@Titulo", varTitulo);
            else
                com.Parameters.AddWithValue("@Titulo", DBNull.Value);
            com.Parameters.AddWithValue("@idTemplate",Conversion.FormatNull(varidTemplate));
            com.Parameters.AddWithValue("@TiempoRefrescar",Conversion.FormatNull(varTiempoRefrescar));
            com.Parameters.AddWithValue("@Usuario",Conversion.FormatNull(varUsuario));

            com.CommandType =CommandType.StoredProcedure;
            sKey1 = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varidDashBorad = sKey1;
            
            for (int i = 0;i< varComponentes.Length; i++)
            {
                com = new SqlCommand();
                com.CommandText = "sp_InsTTDashBoards_RelacionComponentes";
                com.Parameters.AddWithValue("@idDashBoard", sKey1);
                com.Parameters.AddWithValue("@idComponente", Conversion.FormatNull(varComponentes[i].idComponente));

                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaInsert(com, UserInformation, DataReference);
            }

            for (int i = 0;i< varGrupoUsuario.Length; i++)
            {
                com = new SqlCommand();
                com.CommandText = "sp_InsTTDashBoards_RelacionGrupoUsuarios";
                com.Parameters.AddWithValue("@idDashBoard", sKey1);
                com.Parameters.AddWithValue("@idGrupoUsuario", varGrupoUsuario[i].idGrupoUsuario );
//@@DatosDT.ParametrosInsertListBox@@
                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaInsert(com, UserInformation, DataReference);
            }

            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTDashBoards");
            throw ex; 
        }
        //return sKey;
    }
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        db.BeginTransaction("TTDashBoards");
        int? sKey1 = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTDashBoards";
            com.Parameters.AddWithValue("@idDashBorad",Conversion.FormatNull(varidDashBorad));
            if (varTitulo!=null)
                com.Parameters.AddWithValue("@Titulo", varTitulo);
            else
                com.Parameters.AddWithValue("@Titulo", DBNull.Value);
            com.Parameters.AddWithValue("@idTemplate",Conversion.FormatNull(varidTemplate));
            com.Parameters.AddWithValue("@TiempoRefrescar",Conversion.FormatNull(varTiempoRefrescar));
            com.Parameters.AddWithValue("@Usuario",Conversion.FormatNull(varUsuario));

            com.CommandType =CommandType.StoredProcedure;
            sKey1 = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varidDashBorad = sKey1;
        //TODO Falta Saber como borrar los campos
        DataReference.Folio = sKey1.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from TTDashBoards_RelacionComponentes Where idDashBoard = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
            for (int i = 0;i< varComponentes.Length; i++)
            {
                com = new SqlCommand();
                com.CommandText = "sp_InsTTDashBoards_RelacionComponentes";
                com.Parameters.AddWithValue("@idDashBoard", sKey1);
                com.Parameters.AddWithValue("@idComponente", Conversion.FormatNull(varComponentes[i].idComponente));

                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaInsert(com, UserInformation, DataReference);
            }

        //TODO Falta Saber como borrar los campos
        DataReference.Folio = sKey1.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from TTDashBoards_RelacionGrupoUsuarios Where idDashBoard = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
            for (int i = 0;i< varGrupoUsuario.Length; i++)
            {
                com = new SqlCommand();
                com.CommandText = "sp_InsTTDashBoards_RelacionGrupoUsuarios";
                com.Parameters.AddWithValue("@idDashBoard", sKey1);
                com.Parameters.AddWithValue("@idGrupoUsuario", varGrupoUsuario[i].idGrupoUsuario );
//@@DatosDT.ParametrosUpdateListBox@@
                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaInsert(com, UserInformation, DataReference);
            }

            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTDashBoards");
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
            db.BeginTransaction("TTDashBoards");
            try
            {
        DataReference.Folio = Key1.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from TTDashBoards_RelacionComponentes Where idDashBoard = '" + Key1.ToString() + "'"), UserInformation, DataReference);

        DataReference.Folio = Key1.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from TTDashBoards_RelacionGrupoUsuarios Where idDashBoard = '" + Key1.ToString() + "'"), UserInformation, DataReference);

                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTDashBoards";
com.Parameters.AddWithValue("@idDashBorad",Key1);
                com.CommandType =CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTDashBoards");
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
                com.CommandText="sp_GetComplete_TTDashBoards";
            else
                com.CommandText="sp_GetTTDashBoards";
com.Parameters.AddWithValue("@idDashBorad",Key1);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
            idDashBorad = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoards_idDashBorad"]);
            Titulo = ds.Tables[0].Rows[0]["TTDashBoards_Titulo"].ToString().TrimEnd(' ');
            idTemplate = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoards_idTemplate"]);
            TiempoRefrescar = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoards_TiempoRefrescar"]);
            Usuario = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTDashBoards_Usuario"]);
                {
                    TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios MyDataGrupoUsuario = new TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios();
                    TTDashBoards_RelacionGrupoUsuariosCS.TTDashBoards_RelacionGrupoUsuariosFilters MyDataFilterGrupoUsuario = new TTDashBoards_RelacionGrupoUsuariosCS.TTDashBoards_RelacionGrupoUsuariosFilters();
                    MyDataFilterGrupoUsuario.idDashBoard.List = new String[1];
                    MyDataFilterGrupoUsuario.idDashBoard.List[0] = Key1.Value.ToString();
                    MyDataGrupoUsuario.Filters = new TTDashBoards_RelacionGrupoUsuariosCS.TTDashBoards_RelacionGrupoUsuariosFilters[1];
                    MyDataGrupoUsuario.Filters[0] = MyDataFilterGrupoUsuario;
                    DataSet dsListBox = MyDataGrupoUsuario.SelAll(true);
                    GrupoUsuario = new TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios[dsListBox.Tables[0].Rows.Count];
                    for (int i =0;i<dsListBox.Tables[0].Rows.Count;i++)
                    {
                        GrupoUsuario[i] = new TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios();
                    GrupoUsuario[i].idGrupoUsuario = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["TTDashBoards_RelacionGrupoUsuarios_idGrupoUsuario"].ToString());

                    }
                }

                {
                    TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes MyDataComponentes = new TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes();
                    TTDashBoards_RelacionComponentesCS.TTDashBoards_RelacionComponentesFilters MyDataFilterComponentes = new TTDashBoards_RelacionComponentesCS.TTDashBoards_RelacionComponentesFilters();
                    MyDataFilterComponentes.idDashBoard.List = new String[1];
                    MyDataFilterComponentes.idDashBoard.List[0] = Key1.Value.ToString();
                    MyDataComponentes.Filters = new TTDashBoards_RelacionComponentesCS.TTDashBoards_RelacionComponentesFilters[1];
                    MyDataComponentes.Filters[0] = MyDataFilterComponentes;
                    DataSet dsMulti = MyDataComponentes.SelAll(true);
                    Componentes = new TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Componentes[i] = new TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes();
                    Componentes[i].idComponente = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["TTDashBoards_RelacionComponentes_idComponente"]);

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
        com.CommandText = "sp_SelAllComplete_TTDashBoards";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTDashBoardsCS.TTDashBoardsFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTDashBoards", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTDashBoards_idDashBorad"]) == Key1)
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
        com.CommandText = "sp_GetTTDashBoards";
com.Parameters.AddWithValue("@idDashBorad",Key1);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataidTemplateControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "idTemplate";
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
                        ((ListBox)ctr).ValueMember = "idTemplate";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "idTemplate";
                }
            }
*///            public DataTable FillDataidTemplate(Object ctr, String Filtro){
            public DataTable FillDataidTemplate(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoards_Relacion_TTDashBoard_Templates";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataidTemplateControl(ctr, dt);
                return dt;
            }
//            public void FillDataidTemplate(Object ctr){
            public DataTable FillDataidTemplate(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoards_Relacion_TTDashBoard_Templates";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataidTemplateControl(ctr, dt);
                return dt;
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
                com.CommandText = "sp_selTTDashBoards_Relacion_TTDashBoards_RelacionComponentes";
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
                com.CommandText = "sp_selTTDashBoards_Relacion_TTDashBoards_RelacionComponentes";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataComponentesControl(ctr, dt);
                return dt;
            }
/*            private void FillDataUsuarioControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "IdUsuario";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Nombre"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Nombre";
                        ((ListBox)ctr).ValueMember = "IdUsuario";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdUsuario";
                }
            }
*///            public DataTable FillDataUsuario(Object ctr, String Filtro){
            public DataTable FillDataUsuario(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoards_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataUsuarioControl(ctr, dt);
                return dt;
            }
//            public void FillDataUsuario(Object ctr){
            public DataTable FillDataUsuario(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selTTDashBoards_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuarioControl(ctr, dt);
                return dt;
            }
        	public DataTable FillDataGrupoUsuario(){
        		DataSet ds;
        		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        		SqlCommand com = new SqlCommand();
        		com.CommandText = "sp_selTTDashBoards_RelacionGrupoUsuarios_Relacion_TTGrupo_de_Usuario";
        		com.CommandType = CommandType.StoredProcedure;
        		//ctr.Items.Clear();
        		ds = db.Consulta(com);
                                return ds.Tables[0];
//                if (ctr.GetType() == typeof(ComboBox))
//                {
//                        ((ComboBox)ctr).DataSource = ds.Tables[0];
//                        ((ComboBox)ctr).DisplayMember = "Descripcion";
//                        ((ComboBox)ctr).ValueMember = "IdGrupoUsuario";
//                        ((ComboBox)ctr).SelectedItem = null;
//                }
//                else if (ctr.GetType() == typeof(ListBox))
//                {
//                        ((ListBox)ctr).DataSource = ds.Tables[0];
//                        ((ListBox)ctr).DisplayMember = "Descripcion";
//                        ((ListBox)ctr).ValueMember = "IdGrupoUsuario";
//                        ((ListBox)ctr).ClearSelected();
//                }
//                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
//                {
//                        ((DataGridViewComboBoxColumn)ctr).DataSource = ds.Tables[0];
//                       ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
//                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdGrupoUsuario";
//                }
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
        ev.Graphics.DrawString("TTDashBoards", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        ev.Graphics.DrawString("Folio: " + this.varidDashBorad, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Titulo: " + this.varTitulo, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        if (this.varidTemplate != null)
        {
            TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates myRelationWhitTTDashBoard_Templates = new TTDashBoard_TemplatesCS.objectBussinessTTDashBoard_Templates();
            myRelationWhitTTDashBoard_Templates.GetByKey(this.varidTemplate, true);
            ev.Graphics.DrawString("Template: " + myRelationWhitTTDashBoard_Templates.Descripcion , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("Template: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        ev.Graphics.DrawString("Refrescar cada (seg): " + this.varTiempoRefrescar, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        yPos += 10;
        printFont = new Font("Arial", 12, FontStyle.Underline);
        ev.Graphics.DrawString("Componentes (" + this.Componentes.Length + ")", printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
//        ev.Graphics.DrawLine (pHight,0,yPos,xWidth,yPos);
//        yPos += 8;
        foreach (TTDashBoards_RelacionComponentesCS.objectBussinessTTDashBoards_RelacionComponentes myRelationWhitTTDashBoards_RelacionComponentes in this.Componentes)
        {
                ev.Graphics.DrawString("Folio del Componente: " + myRelationWhitTTDashBoards_RelacionComponentes.idComponente, printFont, Brushes.Black, 10, yPos, new StringFormat());
                yPos += printFont.Height;


                ev.Graphics.DrawLine(pLight, 0, yPos, xWidth, yPos);
                yPos += 8;
        }
        if (this.varUsuario != null)
        {
            TTUsuariosCS.objectBussinessTTUsuarios myRelationWhitTTUsuarios = new TTUsuariosCS.objectBussinessTTUsuarios();
            myRelationWhitTTUsuarios.GetByKey(this.varUsuario, true);
            ev.Graphics.DrawString("Usuario: " + myRelationWhitTTUsuarios.Nombre , printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }
        else {
            ev.Graphics.DrawString("Usuario: ----", printFont, Brushes.Black, 10, yPos, new StringFormat());
            yPos += printFont.Height;
        }

        yPos += 10;
        printFont = new Font("Arial", 12, FontStyle.Underline);
        ev.Graphics.DrawString("Grupos de usuario (" + this.GrupoUsuario.Length + ")", printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
//        ev.Graphics.DrawLine(pHight, 0, yPos, xWidth, yPos);
//        yPos += 8;
        foreach (TTDashBoards_RelacionGrupoUsuariosCS.objectBussinessTTDashBoards_RelacionGrupoUsuarios myRelationWhitTTDashBoards_RelacionGrupoUsuarios in this.GrupoUsuario)
        {
            if (myRelationWhitTTDashBoards_RelacionGrupoUsuarios.idGrupoUsuario != null)
            {
                TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario myRelationMultiWhitTTGrupo_de_Usuario = new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();
                myRelationMultiWhitTTGrupo_de_Usuario.GetByKey(myRelationWhitTTDashBoards_RelacionGrupoUsuarios.idGrupoUsuario, true);
                ev.Graphics.DrawString(myRelationMultiWhitTTGrupo_de_Usuario.Descripcion.ToString() , printFont, Brushes.Black, 10, yPos, new StringFormat());
                yPos += printFont.Height;
            }
        }
        ev.Graphics.DrawLine(pLight, 0, yPos, xWidth, yPos);
        yPos += 8;


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            if (sDTid == "15231")
            {
                this.Filters[indexFilter].idDashBorad = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15232")
            {
                this.Filters[indexFilter].Titulo = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15238")
            {
                this.Filters[indexFilter].idTemplate = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDashBoard_TemplatesCS.TTDashBoard_TemplatesFilters[])filter;
            }
            if (sDTid == "15233")
            {
                this.Filters[indexFilter].TiempoRefrescar = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15239")
            {
                this.Filters[indexFilter].Usuario = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTUsuariosCS.TTUsuariosFilters[])filter;
            }
            if (sDTid == "15242")
            {
                this.Filters[indexFilter].GrupoUsuario = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTDashBoards_RelacionGrupoUsuariosCS.TTDashBoards_RelacionGrupoUsuariosFilters[])filter;
            }

        }
    }
}
