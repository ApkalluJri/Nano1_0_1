using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TTModuloCS
{
    public class TTModuloFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varIdModulo =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric IdModulo{
            get { return varIdModulo; }
            set { varIdModulo = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varProcesos =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters[] varProcesos;
        public TTClassSpecials.FiltersTypes.Dependientes Procesos{
            get { return varProcesos; }
            set { varProcesos = value; }
        }

    }
public class objectBussinessTTModulo{
    public int iProcess = 6393;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private TTModuloFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varIdModulo;
	private String varNombre;
	private TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo[] varProcesos;
		
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

    public TTModuloFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public TTModuloFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new TTModuloFilters[1];
            filters[0] = value;
        }
    }

    public int? IdModulo{
        get { return varIdModulo;}
        set { varIdModulo = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo[] Procesos{
        get { return varProcesos;}
        set { varProcesos = value;}
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
            com.CommandText = "sp_SelAllComplete_TTModulo_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_TTModulo";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (TTModuloCS.TTModuloFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTModulo", fil);
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
                com.CommandText = "sp_SelAllComplete_TTModulo_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTModulo";
        else
            com.CommandText="sp_SelAllTTModulo";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (TTModuloCS.TTModuloFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTModulo", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTModulo", fil);
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
                com.CommandText = "sp_SelAllComplete_TTModulo_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_TTModulo";
        else
            com.CommandText="sp_SelAllTTModulo";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (TTModuloCS.TTModuloFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTModulo", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTModulo", fil);
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
        db.BeginTransaction("TTModulo");
        int? sKeyIdModulo = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsTTModulo";
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", varNombre);
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);

            com.CommandType =CommandType.StoredProcedure;
            sKeyIdModulo = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varIdModulo = sKeyIdModulo;
            

            if(varProcesos != null)
            {
                for (int i = 0;i< varProcesos.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTProceso_del_Modulo";
                    com.Parameters.AddWithValue("@IdModulo", sKeyIdModulo);
                    com.Parameters.AddWithValue("@IdProceso", varProcesos[i].IdProceso );
//@@DatosDT.ParametrosInsertListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }

            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTModulo");
            throw ex; 
        }
        //return sKey;
    }
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        db.BeginTransaction("TTModulo");
        int? sKeyIdModulo = -1;
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdTTModulo";
            com.Parameters.AddWithValue("@IdModulo",Conversion.FormatNull(varIdModulo));
            if (varNombre!=null)
                com.Parameters.AddWithValue("@Nombre", varNombre);
            else
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);

            com.CommandType =CommandType.StoredProcedure;
            sKeyIdModulo = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varIdModulo = sKeyIdModulo;

        //TODO Falta Saber como borrar los campos
        DataReference.Folio = sKeyIdModulo.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from TTProceso_del_Modulo Where IdModulo = '" + sKeyIdModulo.ToString() + "'"), UserInformation, DataReference);
            if(varProcesos != null)
            {
                for (int i = 0;i< varProcesos.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTProceso_del_Modulo";
                    com.Parameters.AddWithValue("@IdModulo", sKeyIdModulo);
                    com.Parameters.AddWithValue("@IdProceso", varProcesos[i].IdProceso );
//@@DatosDT.ParametrosUpdateListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }

            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTModulo");
            throw ex; 
        }
    }

    public bool Delete(int? KeyIdModulo, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
//        if (Key == ""){
//            MessageBox.Show("Para poder borrar el registro debe proporcionar la llave","Borrar Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//                return false;
//        }else{
            Boolean result;
            DataReference.Folio =  KeyIdModulo.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("TTModulo");
            try
            {

        DataReference.Folio = KeyIdModulo.ToString();
        db.EjecutaDelete(new SqlCommand("Delete from TTProceso_del_Modulo Where IdModulo = '" + KeyIdModulo.ToString() + "'"), UserInformation, DataReference);

                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelTTModulo";
com.Parameters.AddWithValue("@IdModulo",KeyIdModulo);
                com.CommandType =CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTModulo");
                throw ex; 
            }
            return result;
        //}
    }
    private DataSet GetByKey(DataSet ds)
    {
            if (ds.Tables[0].Rows.Count > 0)
            {
            IdModulo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTModulo_IdModulo"]);
            Nombre = ds.Tables[0].Rows[0]["TTModulo_Nombre"].ToString();
                {
                    TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo MyDataProcesos = new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo();
                    TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters MyDataFilterProcesos = new TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters();
                    MyDataFilterProcesos.IdModulo.List = new String[1];
                    MyDataFilterProcesos.IdModulo.List[0] = IdModulo.Value.ToString();
                    MyDataProcesos.Filters = new TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters[1];
                    MyDataProcesos.Filters[0] = MyDataFilterProcesos;
                    DataSet dsListBox = MyDataProcesos.SelAll(true);
                    Procesos = new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo[dsListBox.Tables[0].Rows.Count];
                    for (int i =0;i<dsListBox.Tables[0].Rows.Count;i++)
                    {
                        Procesos[i] = new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo();
                    Procesos[i].IdProceso = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["TTProceso_del_Modulo_IdProceso"].ToString());

                    }
                }



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyIdModulo, Boolean ConRelaciones){
        DataSet ds;
        if (KeyIdModulo == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_TTModulo";
            else
                com.CommandText="sp_GetTTModulo";
com.Parameters.AddWithValue("@IdModulo",KeyIdModulo);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIdModulo(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTModulo.IdModulo As TTModulo_IdModulo,        TTModulo.Nombre As TTModulo_Nombre,        '' AS TTModulo_Procesos   from  TTModulo           Where TTModulo.IdModulo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyNombre(String Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTModulo.IdModulo As TTModulo_IdModulo,        TTModulo.Nombre As TTModulo_Nombre,        '' AS TTModulo_Procesos   from  TTModulo           Where TTModulo.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyProcesos(int? Key){
        DataSet ds;
        if (Key == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         TTModulo.IdModulo As TTModulo_IdModulo,        TTModulo.Nombre As TTModulo_Nombre,        '' AS TTModulo_Procesos   from  TTModulo           Where TTModulo.Procesos = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyIdModulo)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_TTModulo";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (TTModuloCS.TTModuloFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTModulo", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["TTModulo_IdModulo"]) == KeyIdModulo)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyIdModulo){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetTTModulo";
        com.Parameters.AddWithValue("@IdModulo",KeyIdModulo);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

        	public DataTable FillDataProcesos(){
        		DataSet ds;
        		TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        		SqlCommand com = new SqlCommand();
        		com.CommandText = "sp_selTTProceso_del_Modulo_Relacion_TTProceso";
        		com.CommandType = CommandType.StoredProcedure;
        		//ctr.Items.Clear();
        		ds = db.Consulta(com);
                                return ds.Tables[0];
//                if (ctr.GetType() == typeof(ComboBox))
//                {
//                        ((ComboBox)ctr).DataSource = ds.Tables[0];
//                        ((ComboBox)ctr).DisplayMember = "Nombre";
//                        ((ComboBox)ctr).ValueMember = "IdProceso";
//                        ((ComboBox)ctr).SelectedItem = null;
//                }
//                else if (ctr.GetType() == typeof(ListBox))
//                {
//                        ((ListBox)ctr).DataSource = ds.Tables[0];
//                        ((ListBox)ctr).DisplayMember = "Nombre";
//                        ((ListBox)ctr).ValueMember = "IdProceso";
//                        ((ListBox)ctr).ClearSelected();
//                }
//                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
//                {
//                        ((DataGridViewComboBoxColumn)ctr).DataSource = ds.Tables[0];
//                       ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
//                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdProceso";
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
        ev.Graphics.DrawString("TTModulo", printFont, Brushes.Black, 80, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
        ev.Graphics.DrawString("Clave del Modulo: " + this.varIdModulo, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        ev.Graphics.DrawString("Nombre: " + this.varNombre, printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height;

        yPos += 10;
        printFont = new Font("Arial", 12, FontStyle.Underline);
        ev.Graphics.DrawString("Procesos (" + this.Procesos.Length + ")", printFont, Brushes.Black, 10, yPos, new StringFormat());
        yPos += printFont.Height+5;
        printFont = new Font("Arial", 10, FontStyle.Regular);
//        ev.Graphics.DrawLine(pHight, 0, yPos, xWidth, yPos);
//        yPos += 8;
        foreach (TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo myRelationWhitTTProceso_del_Modulo in this.Procesos)
        {
            if (myRelationWhitTTProceso_del_Modulo.IdProceso != null)
            {
                TTProcesoCS.objectBussinessTTProceso myRelationMultiWhitTTProceso = new TTProcesoCS.objectBussinessTTProceso();
                myRelationMultiWhitTTProceso.GetByKeyIdProceso(myRelationWhitTTProceso_del_Modulo.IdProceso);
                ev.Graphics.DrawString(myRelationMultiWhitTTProceso.Nombre.ToString() , printFont, Brushes.Black, 10, yPos, new StringFormat());
                yPos += printFont.Height;
            }
        }
        ev.Graphics.DrawLine(pLight, 0, yPos, xWidth, yPos);
        yPos += 8;


    }
        public void AddFilterXDT(string sDTid, Object filter, int indexFilter)
        {
            if (sDTid == "13081")
            {
                this.Filters[indexFilter].IdModulo = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "13082")
            {
                this.Filters[indexFilter].Nombre = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "13083")
            {
                this.Filters[indexFilter].Procesos = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters[])filter;
            }

        }
    }
}
