using System;
using System.Data;
using System.Data.SqlClient;
//using System.Windows.Forms;
//using System.Drawing;

namespace TTConfigurationServersCS
{
    public class TTConfigurationServersFilters
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
        private TTClassSpecials.FiltersTypes.Numeric varidConfiguracion = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric idConfiguracion
        {
            get { return varidConfiguracion; }
            set { varidConfiguracion = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombreConexion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String NombreConexion
        {
            get { return varNombreConexion; }
            set { varNombreConexion = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipoServidor = new TTClassSpecials.FiltersTypes.Dependientes();
        //        private TTConfigurationServers_TipoServidorCS.TTConfigurationServers_TipoServidorFilters[] varTipoServidor;
        public TTClassSpecials.FiltersTypes.Dependientes TipoServidor
        {
            get { return varTipoServidor; }
            set { varTipoServidor = value; }
        }
        private TTClassSpecials.FiltersTypes.String varServidor = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Servidor
        {
            get { return varServidor; }
            set { varServidor = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varPuerto = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Puerto
        {
            get { return varPuerto; }
            set { varPuerto = value; }
        }
        private TTClassSpecials.FiltersTypes.String varUsuario = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Usuario
        {
            get { return varUsuario; }
            set { varUsuario = value; }
        }
        private TTClassSpecials.FiltersTypes.String varContrasena = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Contrasena
        {
            get { return varContrasena; }
            set { varContrasena = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varRequiereAutenticacion = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic RequiereAutenticacion
        {
            get { return varRequiereAutenticacion; }
            set { varRequiereAutenticacion = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varProxy = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Proxy
        {
            get { return varProxy; }
            set { varProxy = value; }
        }
        private TTClassSpecials.FiltersTypes.String varServidorProxy = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String ServidorProxy
        {
            get { return varServidorProxy; }
            set { varServidorProxy = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varPuertoProxy = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric PuertoProxy
        {
            get { return varPuertoProxy; }
            set { varPuertoProxy = value; }
        }
        private TTClassSpecials.FiltersTypes.String varUsuarioProxy = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String UsuarioProxy
        {
            get { return varUsuarioProxy; }
            set { varUsuarioProxy = value; }
        }
        private TTClassSpecials.FiltersTypes.String varContrasenaProxy = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String ContrasenaProxy
        {
            get { return varContrasenaProxy; }
            set { varContrasenaProxy = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varReintentosConexion = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric ReintentosConexion
        {
            get { return varReintentosConexion; }
            set { varReintentosConexion = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varReconexion = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Reconexion
        {
            get { return varReconexion; }
            set { varReconexion = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric varTiemOut = new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric TiemOut
        {
            get { return varTiemOut; }
            set { varTiemOut = value; }
        }
        private TTClassSpecials.FiltersTypes.String varCarpetaLocal = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String CarpetaLocal
        {
            get { return varCarpetaLocal; }
            set { varCarpetaLocal = value; }
        }
        private TTClassSpecials.FiltersTypes.String varCarpetaRemota = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String CarpetaRemota
        {
            get { return varCarpetaRemota; }
            set { varCarpetaRemota = value; }
        }

    }
    public class objectBussinessTTConfigurationServers
    {
        public int iProcess = 6781;
        private TTFunctions.Functions Function = new TTFunctions.Functions();
        private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
        private TTConfigurationServersFilters[] filters;
        private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
        private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
        private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
        private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
        private int? varidConfiguracion;
        private String varNombreConexion;
        private int? varTipoServidor;
        private String varServidor;
        private int? varPuerto;
        private String varUsuario;
        private String varContrasena;
        private Boolean varRequiereAutenticacion;
        private Boolean varProxy;
        private String varServidorProxy;
        private int? varPuertoProxy;
        private String varUsuarioProxy;
        private String varContrasenaProxy;
        private int? varReintentosConexion;
        private int? varReconexion;
        private int? varTiemOut;
        private String varCarpetaLocal;
        private String varCarpetaRemota;

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

        public TTConfigurationServersFilters[] Filters
        {
            get { return filters; }
            set { filters = value; }
        }
        public TTConfigurationServersFilters Filter
        {
            ///Cuando es llamada desde las relaciones de algun catalago
            set
            {
                filters = new TTConfigurationServersFilters[1];
                filters[0] = value;
            }
        }

        public int? idConfiguracion
        {
            get { return varidConfiguracion; }
            set { varidConfiguracion = value; }
        }
        public String NombreConexion
        {
            get { return varNombreConexion; }
            set { varNombreConexion = value; }
        }
        public int? TipoServidor
        {
            get { return varTipoServidor; }
            set { varTipoServidor = value; }
        }
        public String Servidor
        {
            get { return varServidor; }
            set { varServidor = value; }
        }
        public int? Puerto
        {
            get { return varPuerto; }
            set { varPuerto = value; }
        }
        public String Usuario
        {
            get { return varUsuario; }
            set { varUsuario = value; }
        }
        public String Contrasena
        {
            get { return varContrasena; }
            set { varContrasena = value; }
        }
        public Boolean RequiereAutenticacion
        {
            get { return varRequiereAutenticacion; }
            set { varRequiereAutenticacion = value; }
        }
        public Boolean Proxy
        {
            get { return varProxy; }
            set { varProxy = value; }
        }
        public String ServidorProxy
        {
            get { return varServidorProxy; }
            set { varServidorProxy = value; }
        }
        public int? PuertoProxy
        {
            get { return varPuertoProxy; }
            set { varPuertoProxy = value; }
        }
        public String UsuarioProxy
        {
            get { return varUsuarioProxy; }
            set { varUsuarioProxy = value; }
        }
        public String ContrasenaProxy
        {
            get { return varContrasenaProxy; }
            set { varContrasenaProxy = value; }
        }
        public int? ReintentosConexion
        {
            get { return varReintentosConexion; }
            set { varReintentosConexion = value; }
        }
        public int? Reconexion
        {
            get { return varReconexion; }
            set { varReconexion = value; }
        }
        public int? TiemOut
        {
            get { return varTiemOut; }
            set { varTiemOut = value; }
        }
        public String CarpetaLocal
        {
            get { return varCarpetaLocal; }
            set { varCarpetaLocal = value; }
        }
        public String CarpetaRemota
        {
            get { return varCarpetaRemota; }
            set { varCarpetaRemota = value; }
        }


        public Int32 SelCount()
        {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTConfigurationServers";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            string swhere = "";
            if (this.filters != null)
                foreach (TTConfigurationServersCS.TTConfigurationServersFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTConfigurationServers", fil);
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
                com.CommandText = "sp_SelAllComplete_TTConfigurationServers";
            else
                com.CommandText = "sp_SelAllTTConfigurationServers";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTConfigurationServersCS.TTConfigurationServersFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTConfigurationServers", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTConfigurationServers", fil);
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
                com.CommandText = "sp_SelAllComplete_TTConfigurationServers";
            else
                com.CommandText = "sp_SelAllTTConfigurationServers";
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            String swhere = "";
            String sOrderBy = "";
            if (this.filters != null)
                foreach (TTConfigurationServersCS.TTConfigurationServersFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTConfigurationServers", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("TTConfigurationServers", fil);
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
            db.BeginTransaction("TTConfigurationServers");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_InsTTConfigurationServers";
                if (varNombreConexion != null)
                    com.Parameters.AddWithValue("@NombreConexion", varNombreConexion);
                else
                    com.Parameters.AddWithValue("@NombreConexion", DBNull.Value);
                com.Parameters.AddWithValue("@TipoServidor", Conversion.FormatNull(varTipoServidor));
                if (varServidor != null)
                    com.Parameters.AddWithValue("@Servidor", varServidor);
                else
                    com.Parameters.AddWithValue("@Servidor", DBNull.Value);
                com.Parameters.AddWithValue("@Puerto", Conversion.FormatNull(varPuerto));
                if (varUsuario != null)
                    com.Parameters.AddWithValue("@Usuario", varUsuario);
                else
                    com.Parameters.AddWithValue("@Usuario", DBNull.Value);
                if (varContrasena != null)
                    com.Parameters.AddWithValue("@Contrasena", varContrasena);
                else
                    com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
                com.Parameters.AddWithValue("@RequiereAutenticacion", varRequiereAutenticacion);
                com.Parameters.AddWithValue("@Proxy", varProxy);
                if (varServidorProxy != null)
                    com.Parameters.AddWithValue("@ServidorProxy", varServidorProxy);
                else
                    com.Parameters.AddWithValue("@ServidorProxy", DBNull.Value);
                com.Parameters.AddWithValue("@PuertoProxy", Conversion.FormatNull(varPuertoProxy));
                if (varUsuarioProxy != null)
                    com.Parameters.AddWithValue("@UsuarioProxy", varUsuarioProxy);
                else
                    com.Parameters.AddWithValue("@UsuarioProxy", DBNull.Value);
                if (varContrasenaProxy != null)
                    com.Parameters.AddWithValue("@ContrasenaProxy", varContrasenaProxy);
                else
                    com.Parameters.AddWithValue("@ContrasenaProxy", DBNull.Value);
                com.Parameters.AddWithValue("@ReintentosConexion", Conversion.FormatNull(varReintentosConexion));
                com.Parameters.AddWithValue("@Reconexion", Conversion.FormatNull(varReconexion));
                com.Parameters.AddWithValue("@TiemOut", Conversion.FormatNull(varTiemOut));
                if (varCarpetaLocal != null)
                    com.Parameters.AddWithValue("@CarpetaLocal", varCarpetaLocal);
                else
                    com.Parameters.AddWithValue("@CarpetaLocal", DBNull.Value);
                if (varCarpetaRemota != null)
                    com.Parameters.AddWithValue("@CarpetaRemota", varCarpetaRemota);
                else
                    com.Parameters.AddWithValue("@CarpetaRemota", DBNull.Value);

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaInsert(com, UserInformation, DataReference));
                varidConfiguracion = sKey1;



                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTConfigurationServers");
                throw ex;
            }
            //return sKey;
        }
        public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTConfigurationServers");
            int? sKey1 = -1;
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_UpdTTConfigurationServers";
                com.Parameters.AddWithValue("@idConfiguracion", Conversion.FormatNull(varidConfiguracion));
                if (varNombreConexion != null)
                    com.Parameters.AddWithValue("@NombreConexion", varNombreConexion);
                else
                    com.Parameters.AddWithValue("@NombreConexion", DBNull.Value);
                com.Parameters.AddWithValue("@TipoServidor", Conversion.FormatNull(varTipoServidor));
                if (varServidor != null)
                    com.Parameters.AddWithValue("@Servidor", varServidor);
                else
                    com.Parameters.AddWithValue("@Servidor", DBNull.Value);
                com.Parameters.AddWithValue("@Puerto", Conversion.FormatNull(varPuerto));
                if (varUsuario != null)
                    com.Parameters.AddWithValue("@Usuario", varUsuario);
                else
                    com.Parameters.AddWithValue("@Usuario", DBNull.Value);
                if (varContrasena != null)
                    com.Parameters.AddWithValue("@Contrasena", varContrasena);
                else
                    com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
                com.Parameters.AddWithValue("@RequiereAutenticacion", varRequiereAutenticacion);
                com.Parameters.AddWithValue("@Proxy", varProxy);
                if (varServidorProxy != null)
                    com.Parameters.AddWithValue("@ServidorProxy", varServidorProxy);
                else
                    com.Parameters.AddWithValue("@ServidorProxy", DBNull.Value);
                com.Parameters.AddWithValue("@PuertoProxy", Conversion.FormatNull(varPuertoProxy));
                if (varUsuarioProxy != null)
                    com.Parameters.AddWithValue("@UsuarioProxy", varUsuarioProxy);
                else
                    com.Parameters.AddWithValue("@UsuarioProxy", DBNull.Value);
                if (varContrasenaProxy != null)
                    com.Parameters.AddWithValue("@ContrasenaProxy", varContrasenaProxy);
                else
                    com.Parameters.AddWithValue("@ContrasenaProxy", DBNull.Value);
                com.Parameters.AddWithValue("@ReintentosConexion", Conversion.FormatNull(varReintentosConexion));
                com.Parameters.AddWithValue("@Reconexion", Conversion.FormatNull(varReconexion));
                com.Parameters.AddWithValue("@TiemOut", Conversion.FormatNull(varTiemOut));
                if (varCarpetaLocal != null)
                    com.Parameters.AddWithValue("@CarpetaLocal", varCarpetaLocal);
                else
                    com.Parameters.AddWithValue("@CarpetaLocal", DBNull.Value);
                if (varCarpetaRemota != null)
                    com.Parameters.AddWithValue("@CarpetaRemota", varCarpetaRemota);
                else
                    com.Parameters.AddWithValue("@CarpetaRemota", DBNull.Value);

                com.CommandType = CommandType.StoredProcedure;
                sKey1 = Function.FormatNumberNull(db.EjecutaUpdate(com, UserInformation, DataReference));
                //            varidConfiguracion = sKey1;


                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTConfigurationServers");
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
            db.BeginTransaction("TTConfigurationServers");
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_DelTTConfigurationServers";
                com.Parameters.AddWithValue("@idConfiguracion", Key1);
                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                db.RollBackTransaction("TTConfigurationServers");
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
                com.CommandText = "sp_GetComplete_TTConfigurationServers";
            else
                com.CommandText = "sp_GetTTConfigurationServers";
            com.Parameters.AddWithValue("@idConfiguracion", Key1);

            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count > 0)
            {
                idConfiguracion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTConfigurationServers_idConfiguracion"]);
                NombreConexion = ds.Tables[0].Rows[0]["TTConfigurationServers_NombreConexion"].ToString().TrimEnd(' ');
                TipoServidor = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTConfigurationServers_TipoServidor"]);
                Servidor = ds.Tables[0].Rows[0]["TTConfigurationServers_Servidor"].ToString().TrimEnd(' ');
                Puerto = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTConfigurationServers_Puerto"]);
                Usuario = ds.Tables[0].Rows[0]["TTConfigurationServers_Usuario"].ToString().TrimEnd(' ');
                Contrasena = ds.Tables[0].Rows[0]["TTConfigurationServers_Contrasena"].ToString().TrimEnd(' ');
                RequiereAutenticacion = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTConfigurationServers_RequiereAutenticacion"]);
                Proxy = Convert.ToBoolean(ds.Tables[0].Rows[0]["TTConfigurationServers_Proxy"]);
                ServidorProxy = ds.Tables[0].Rows[0]["TTConfigurationServers_ServidorProxy"].ToString().TrimEnd(' ');
                PuertoProxy = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTConfigurationServers_PuertoProxy"]);
                UsuarioProxy = ds.Tables[0].Rows[0]["TTConfigurationServers_UsuarioProxy"].ToString().TrimEnd(' ');
                ContrasenaProxy = ds.Tables[0].Rows[0]["TTConfigurationServers_ContrasenaProxy"].ToString().TrimEnd(' ');
                ReintentosConexion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTConfigurationServers_ReintentosConexion"]);
                Reconexion = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTConfigurationServers_Reconexion"]);
                TiemOut = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["TTConfigurationServers_TiemOut"]);
                CarpetaLocal = ds.Tables[0].Rows[0]["TTConfigurationServers_CarpetaLocal"].ToString().TrimEnd(' ');
                CarpetaRemota = ds.Tables[0].Rows[0]["TTConfigurationServers_CarpetaRemota"].ToString().TrimEnd(' ');
            }
            return ds;
            //}
        }
        public Int32 CurrentPosicion(int? Key1)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_SelAllComplete_TTConfigurationServers";
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters != null)
                foreach (TTConfigurationServersCS.TTConfigurationServersFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("TTConfigurationServers", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Function.FormatNumberNull(dt.Rows[i]["TTConfigurationServers_idConfiguracion"]) == Key1)
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
            com.CommandText = "sp_GetTTConfigurationServers";
            com.Parameters.AddWithValue("@idConfiguracion", Key1);
            com.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count == 0)
                result = false;
            else
                result = true;
            return result;
        }
                
        public DataTable FillDataTipoServidor(String Filtro)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTConfigurationServers_Relacion_TTConfigurationServers_TipoServidor";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
            dt = d.ToTable();
            //DisplayMember = "Nombre";
            //ValueMember = "idServer";
            return dt;
        }
        public DataTable FillDataTipoServidor()
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_selTTConfigurationServers_Relacion_TTConfigurationServers_TipoServidor";
            com.CommandType = CommandType.StoredProcedure;
            //ctr.Items.Clear();
            DataTable dt = db.Consulta(com).Tables[0];
            //DisplayMember = "Nombre";
            //ValueMember = "idServer";
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
            if (sDTid == "15025")
            {
                this.Filters[indexFilter].idConfiguracion = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15026")
            {
                this.Filters[indexFilter].NombreConexion = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15027")
            {
                this.Filters[indexFilter].TipoServidor = (TTClassSpecials.FiltersTypes.Dependientes)filter;//(TTConfigurationServers_TipoServidorCS.TTConfigurationServers_TipoServidorFilters[])filter;
            }
            if (sDTid == "15028")
            {
                this.Filters[indexFilter].Servidor = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15029")
            {
                this.Filters[indexFilter].Puerto = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15030")
            {
                this.Filters[indexFilter].Usuario = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15031")
            {
                this.Filters[indexFilter].Contrasena = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15032")
            {
                this.Filters[indexFilter].RequiereAutenticacion = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "15033")
            {
                this.Filters[indexFilter].Proxy = (TTClassSpecials.FiltersTypes.Logic)filter;
            }
            if (sDTid == "15034")
            {
                this.Filters[indexFilter].ServidorProxy = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15035")
            {
                this.Filters[indexFilter].PuertoProxy = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15036")
            {
                this.Filters[indexFilter].UsuarioProxy = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15039")
            {
                this.Filters[indexFilter].ContrasenaProxy = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15040")
            {
                this.Filters[indexFilter].ReintentosConexion = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15041")
            {
                this.Filters[indexFilter].Reconexion = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15042")
            {
                this.Filters[indexFilter].TiemOut = (TTClassSpecials.FiltersTypes.Numeric)filter;
            }
            if (sDTid == "15043")
            {
                this.Filters[indexFilter].CarpetaLocal = (TTClassSpecials.FiltersTypes.String)filter;
            }
            if (sDTid == "15044")
            {
                this.Filters[indexFilter].CarpetaRemota = (TTClassSpecials.FiltersTypes.String)filter;
            }

        }
    }
}
