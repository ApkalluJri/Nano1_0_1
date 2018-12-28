using System;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;
//using System.Drawing;

namespace TTGrupoFuncionalCS
{
    public class TTGrupoFuncionalFilters
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
        private TTClassSpecials.FiltersTypes.Numeric varidGrupo = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idGrupo
        {
            get { return varidGrupo; }
            set { varidGrupo = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.String varProposito = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Proposito
        {
            get { return varProposito; }
            set { varProposito = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varGrupoUsuario = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTGrupoFuncional_RelacionGrupoUsuariosCS.TTGrupoFuncional_RelacionGrupoUsuariosFilters[] varGrupoUsuario;
        public TTClassSpecials.FiltersTypes.Dependientes GrupoUsuario
        {
            get { return varGrupoUsuario; }
            set { varGrupoUsuario = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varUsuarios = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTGrupoFuncional_RelacionUsuariosCS.TTGrupoFuncional_RelacionUsuariosFilters[] varUsuarios;
        public TTClassSpecials.FiltersTypes.Dependientes Usuarios
        {
            get { return varUsuarios; }
            set { varUsuarios = value; }
        }

    }
    public class objectBussinessTTGrupoFuncional
    {
        public int iProcess = 6783;
        private TTFunctions.Functions Function = new TTFunctions.Functions();
        private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
        private TTGrupoFuncionalFilters[] filters;
        private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
        private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
        private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
        private int? varidGrupo;
        private String varNombre;
        private String varProposito;
        private TTGrupoFuncional_RelacionGrupoUsuariosCS.objectBussinessTTGrupoFuncional_RelacionGrupoUsuarios[] varGrupoUsuario;
        private TTGrupoFuncional_RelacionUsuariosCS.objectBussinessTTGrupoFuncional_RelacionUsuarios[] varUsuarios;

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

        public TTGrupoFuncionalFilters[] Filters
        {
            get { return filters; }
            set { filters = value; }
        }
        public TTGrupoFuncionalFilters Filter
        {
            ///Cuando es llamada desde las relaciones de algun catalago
            set
            {
                filters = new TTGrupoFuncionalFilters[1];
                filters[0] = value;
            }
        }

        public int? idGrupo
        {
            get { return varidGrupo; }
            set { varidGrupo = value; }
        }
        public String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        public String Proposito
        {
            get { return varProposito; }
            set { varProposito = value; }
        }
        public TTGrupoFuncional_RelacionGrupoUsuariosCS.objectBussinessTTGrupoFuncional_RelacionGrupoUsuarios[] GrupoUsuario
        {
            get { return varGrupoUsuario; }
            set { varGrupoUsuario = value; }
        }
        public TTGrupoFuncional_RelacionUsuariosCS.objectBussinessTTGrupoFuncional_RelacionUsuarios[] Usuarios
        {
            get { return varUsuarios; }
            set { varUsuarios = value; }
        }


        public Int32 SelCount()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTGrupoFuncional";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            string swhere = "";
            if (this.filters != null)
                foreach (TTGrupoFuncionalCS.TTGrupoFuncionalFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTGrupoFuncional", fil);
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
                com.CommandText = "sp_SelAllComplete_TTGrupoFuncional";
            else
                com.CommandText = "sp_SelAllTTGrupoFuncional";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTGrupoFuncionalCS.TTGrupoFuncionalFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTGrupoFuncional", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTGrupoFuncional", fil);
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
                com.CommandText = "sp_SelAllComplete_TTGrupoFuncional";
            else
                com.CommandText = "sp_SelAllTTGrupoFuncional";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTGrupoFuncionalCS.TTGrupoFuncionalFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTGrupoFuncional", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTGrupoFuncional", fil);
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
            db.BeginTransaction("TTGrupoFuncional");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_InsTTGrupoFuncional";
                if (varNombre != null)
                    com.Parameters.AddWithValue("@Nombre", varNombre);
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
                if (varProposito != null)
                    com.Parameters.AddWithValue("@Proposito", varProposito);
                else
                    com.Parameters.AddWithValue("@Proposito", DBNull.Value);

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaInsert(com, UserInformation, DataReference));
                varidGrupo = sKey1;


                for (int i = 0; i < varGrupoUsuario.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTGrupoFuncional_RelacionGrupoUsuarios";
                    com.Parameters.AddWithValue("@idGrupoFuncional", sKey1);
                    com.Parameters.AddWithValue("@idGrupoUsuario", varGrupoUsuario[i].idGrupoUsuario);
                    //@@DatosDT.ParametrosInsertListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                for (int i = 0; i < varUsuarios.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTGrupoFuncional_RelacionUsuarios";
                    com.Parameters.AddWithValue("@idGrupoFuncional", sKey1);
                    com.Parameters.AddWithValue("@idUsuario", varUsuarios[i].idUsuario);
                    //@@DatosDT.ParametrosInsertListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTGrupoFuncional");
                throw ex;
            }
            //return sKey;
        }
        public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTGrupoFuncional");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_UpdTTGrupoFuncional";
                com.Parameters.AddWithValue("@idGrupo", Conversion.FormatNull(varidGrupo));
                if (varNombre != null)
                    com.Parameters.AddWithValue("@Nombre", varNombre);
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
                if (varProposito != null)
                    com.Parameters.AddWithValue("@Proposito", varProposito);
                else
                    com.Parameters.AddWithValue("@Proposito", DBNull.Value);

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaUpdate(com, UserInformation, DataReference));
                //            varidGrupo = sKey1;

                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTGrupoFuncional_RelacionGrupoUsuarios Where idGrupoFuncional = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < varGrupoUsuario.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTGrupoFuncional_RelacionGrupoUsuarios";
                    com.Parameters.AddWithValue("@idGrupoFuncional", sKey1);
                    com.Parameters.AddWithValue("@idGrupoUsuario", varGrupoUsuario[i].idGrupoUsuario);
                    //@@DatosDT.ParametrosUpdateListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
                //TODO Falta Saber como borrar los campos
                DataReference.Folio = sKey1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTGrupoFuncional_RelacionUsuarios Where idGrupoFuncional = '" + sKey1.ToString() + "'"), UserInformation, DataReference);
                for (int i = 0; i < varUsuarios.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsTTGrupoFuncional_RelacionUsuarios";
                    com.Parameters.AddWithValue("@idGrupoFuncional", sKey1);
                    com.Parameters.AddWithValue("@idUsuario", varUsuarios[i].idUsuario);
                    //@@DatosDT.ParametrosUpdateListBox@@
                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }

                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTGrupoFuncional");
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
            db.BeginTransaction("TTGrupoFuncional");
            try
            {

                DataReference.Folio = Key1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTGrupoFuncional_RelacionGrupoUsuarios Where idGrupoFuncional = '" + Key1.ToString() + "'"), UserInformation, DataReference);
                DataReference.Folio = Key1.ToString();
                db.EjecutaDelete(new SqlCommand("Delete from TTGrupoFuncional_RelacionUsuarios Where idGrupoFuncional = '" + Key1.ToString() + "'"), UserInformation, DataReference);

                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_DelTTGrupoFuncional";
                com.Parameters.AddWithValue("@idGrupo", Key1);
                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTGrupoFuncional");
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
                com.CommandText = "sp_GetComplete_TTGrupoFuncional";
            else
                com.CommandText = "sp_GetTTGrupoFuncional";
            com.Parameters.AddWithValue("@idGrupo", Key1);

            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
                idGrupo = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTGrupoFuncional_idGrupo"]);
                Nombre = ds.Tables[0].Rows[0]["TTGrupoFuncional_Nombre"].ToString().TrimEnd(' ');
                Proposito = ds.Tables[0].Rows[0]["TTGrupoFuncional_Proposito"].ToString().TrimEnd(' ');
                {
                    TTGrupoFuncional_RelacionGrupoUsuariosCS.objectBussinessTTGrupoFuncional_RelacionGrupoUsuarios MyDataGrupoUsuario = new TTGrupoFuncional_RelacionGrupoUsuariosCS.objectBussinessTTGrupoFuncional_RelacionGrupoUsuarios();
                    TTGrupoFuncional_RelacionGrupoUsuariosCS.TTGrupoFuncional_RelacionGrupoUsuariosFilters MyDataFilterGrupoUsuario = new TTGrupoFuncional_RelacionGrupoUsuariosCS.TTGrupoFuncional_RelacionGrupoUsuariosFilters();
                    MyDataFilterGrupoUsuario.idGrupoFuncional.List = new String[1];
                    MyDataFilterGrupoUsuario.idGrupoFuncional.List[0] = Key1.Value.ToString();
                    MyDataGrupoUsuario.Filters = new TTGrupoFuncional_RelacionGrupoUsuariosCS.TTGrupoFuncional_RelacionGrupoUsuariosFilters[1];
                    MyDataGrupoUsuario.Filters[0] = MyDataFilterGrupoUsuario;
                    DataSet dsListBox = MyDataGrupoUsuario.SelAll(true);
                    GrupoUsuario = new TTGrupoFuncional_RelacionGrupoUsuariosCS.objectBussinessTTGrupoFuncional_RelacionGrupoUsuarios[dsListBox.Tables[0].Rows.Count];
                    for (int i = 0; i < dsListBox.Tables[0].Rows.Count; i++)
                    {
                        GrupoUsuario[i] = new TTGrupoFuncional_RelacionGrupoUsuariosCS.objectBussinessTTGrupoFuncional_RelacionGrupoUsuarios();
                        GrupoUsuario[i].idGrupoUsuario = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["TTGrupoFuncional_RelacionGrupoUsuarios_idGrupoUsuario"].ToString());

                    }
                }
                {
                    TTGrupoFuncional_RelacionUsuariosCS.objectBussinessTTGrupoFuncional_RelacionUsuarios MyDataUsuarios = new TTGrupoFuncional_RelacionUsuariosCS.objectBussinessTTGrupoFuncional_RelacionUsuarios();
                    TTGrupoFuncional_RelacionUsuariosCS.TTGrupoFuncional_RelacionUsuariosFilters MyDataFilterUsuarios = new TTGrupoFuncional_RelacionUsuariosCS.TTGrupoFuncional_RelacionUsuariosFilters();
                    MyDataFilterUsuarios.idGrupoFuncional.List = new String[1];
                    MyDataFilterUsuarios.idGrupoFuncional.List[0] = Key1.Value.ToString();
                    MyDataUsuarios.Filters = new TTGrupoFuncional_RelacionUsuariosCS.TTGrupoFuncional_RelacionUsuariosFilters[1];
                    MyDataUsuarios.Filters[0] = MyDataFilterUsuarios;
                    DataSet dsListBox = MyDataUsuarios.SelAll(true);
                    Usuarios = new TTGrupoFuncional_RelacionUsuariosCS.objectBussinessTTGrupoFuncional_RelacionUsuarios[dsListBox.Tables[0].Rows.Count];
                    for (int i = 0; i < dsListBox.Tables[0].Rows.Count; i++)
                    {
                        Usuarios[i] = new TTGrupoFuncional_RelacionUsuariosCS.objectBussinessTTGrupoFuncional_RelacionUsuarios();
                        Usuarios[i].idUsuario = Function.FormatNumberNull(dsListBox.Tables[0].Rows[i]["TTGrupoFuncional_RelacionUsuarios_idUsuario"].ToString());

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
            com.CommandText = "sp_SelAllComplete_TTGrupoFuncional";
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters != null)
                foreach (TTGrupoFuncionalCS.TTGrupoFuncionalFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTGrupoFuncional", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Function.FormatNumberNull(dt.Rows[i]["TTGrupoFuncional_idGrupo"]) == Key1)
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
            com.CommandText = "sp_GetTTGrupoFuncional";
            com.Parameters.AddWithValue("@idGrupo", Key1);
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count == 0)
                result = false;
            else
                result = true;
            return result;
        }

        public DataTable FillDataGrupoUsuario()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTGrupoFuncional_RelacionGrupoUsuarios_Relacion_TTGrupo_de_Usuario";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            ds = db.Consulta(com);
            //DisplayMember = "Descripcion";
            //ValueMember = "IdGrupoUsuario";
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;            
        }
        public DataTable FillDataUsuarios()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTGrupoFuncional_RelacionUsuarios_Relacion_TTUsuarios";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            ds = db.Consulta(com);
            //DisplayMember = "Nombre";
            //ValueMember = "IdUsuario";
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;                        
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
            if (sDTid == "15046")
            {
                this.Filters[indexFilter].idGrupo = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15047")
            {
                this.Filters[indexFilter].Nombre = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15048")
            {
                this.Filters[indexFilter].Proposito = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15051")
            {
                this.Filters[indexFilter].GrupoUsuario = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTGrupoFuncional_RelacionGrupoUsuariosCS.TTGrupoFuncional_RelacionGrupoUsuariosFilters[])filter;
            }
            if (sDTid == "15054")
            {
                this.Filters[indexFilter].Usuarios = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTGrupoFuncional_RelacionUsuariosCS.TTGrupoFuncional_RelacionUsuariosFilters[])filter;
            }

        }
    }
}