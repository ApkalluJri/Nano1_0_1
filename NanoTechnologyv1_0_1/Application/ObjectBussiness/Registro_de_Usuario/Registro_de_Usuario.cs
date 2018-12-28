using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Registro_de_UsuarioCS
{
    public class Registro_de_UsuarioFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varFolio =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Folio{
            get { return varFolio; }
            set { varFolio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varUsuario_que_Registra =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varUsuario_que_Registra;
        public TTClassSpecials.FiltersTypes.Dependientes Usuario_que_Registra{
            get { return varUsuario_que_Registra; }
            set { varUsuario_que_Registra = value; }
        }
        private TTClassSpecials.FiltersTypes.filDate  varFecha_de_Registro =new TTClassSpecials.FiltersTypes.filDate();
        public TTClassSpecials.FiltersTypes.filDate Fecha_de_Registro{
            get { return varFecha_de_Registro; }
            set { varFecha_de_Registro = value; }
        }
        private TTClassSpecials.FiltersTypes.String varHora_de_Registro = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Hora_de_Registro
        {
            get { return varHora_de_Registro; }
            set { varHora_de_Registro = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.String varApellido = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Apellido
        {
            get { return varApellido; }
            set { varApellido = value; }
        }
        private TTClassSpecials.FiltersTypes.String varNombre_Completo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre_Completo
        {
            get { return varNombre_Completo; }
            set { varNombre_Completo = value; }
        }
        private TTClassSpecials.FiltersTypes.String varCorreo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Correo
        {
            get { return varCorreo; }
            set { varCorreo = value; }
        }
        private TTClassSpecials.FiltersTypes.String varContrasena = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Contrasena
        {
            get { return varContrasena; }
            set { varContrasena = value; }
        }
        private TTClassSpecials.FiltersTypes.String varConfirmar_Contrasena = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Confirmar_Contrasena
        {
            get { return varConfirmar_Contrasena; }
            set { varConfirmar_Contrasena = value; }
        }
        private TTClassSpecials.FiltersTypes.Logic varAcepta_Terminos = new TTClassSpecials.FiltersTypes.Logic();
        public TTClassSpecials.FiltersTypes.Logic Acepta_Terminos
        {
            get { return varAcepta_Terminos; }
            set { varAcepta_Terminos = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varFoto_de_Perfil =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Foto_de_Perfil{
            get { return varFoto_de_Perfil; }
            set { varFoto_de_Perfil = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varUsuario_del_Sistema =new TTClassSpecials.FiltersTypes.Dependientes();
//        private TTUsuariosCS.TTUsuariosFilters[] varUsuario_del_Sistema;
        public TTClassSpecials.FiltersTypes.Dependientes Usuario_del_Sistema{
            get { return varUsuario_del_Sistema; }
            set { varUsuario_del_Sistema = value; }
        }

    }
public class objectBussinessRegistro_de_Usuario : IDisposable
{
    public int iProcess = 29981;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private Registro_de_UsuarioFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private int? varUsuario_que_Registra;
	private DateTime? varFecha_de_Registro;
	private String varHora_de_Registro;
	private String varNombre;
	private String varApellido;
	private String varNombre_Completo;
	private String varCorreo;
	private String varContrasena;
	private String varConfirmar_Contrasena;
	private Boolean varAcepta_Terminos;
	private int? varFoto_de_Perfil;
	private int? varUsuario_del_Sistema;


    bool disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                //dispose managed ressources
            }
        }
        //dispose unmanaged ressources
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }		
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

    public Registro_de_UsuarioFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public Registro_de_UsuarioFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new Registro_de_UsuarioFilters[1];
            filters[0] = value;
        }
    }

    public int? Folio{
        get { return varFolio;}
        set { varFolio = value;}
    }
    public int? Usuario_que_Registra{
        get { return varUsuario_que_Registra;}
        set { varUsuario_que_Registra = value;}
    }
    public DateTime? Fecha_de_Registro{
        get { return varFecha_de_Registro;}
        set { varFecha_de_Registro = value;}
    }
    public String Hora_de_Registro{
        get { return varHora_de_Registro;}
        set { varHora_de_Registro = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public String Apellido{
        get { return varApellido;}
        set { varApellido = value;}
    }
    public String Nombre_Completo{
        get { return varNombre_Completo;}
        set { varNombre_Completo = value;}
    }
    public String Correo{
        get { return varCorreo;}
        set { varCorreo = value;}
    }
    public String Contrasena{
        get { return varContrasena;}
        set { varContrasena = value;}
    }
    public String Confirmar_Contrasena{
        get { return varConfirmar_Contrasena;}
        set { varConfirmar_Contrasena = value;}
    }
    public Boolean Acepta_Terminos{
        get { return varAcepta_Terminos;}
        set { varAcepta_Terminos = value;}
    }
    public int? Foto_de_Perfil{
        get { return varFoto_de_Perfil;}
        set { varFoto_de_Perfil = value;}
    }
    public int? Usuario_del_Sistema{
        get { return varUsuario_del_Sistema;}
        set { varUsuario_del_Sistema = value;}
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
            com.CommandText = "sp_SelAllComplete_Registro_de_Usuario_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Registro_de_Usuario";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (Registro_de_UsuarioCS.Registro_de_UsuarioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Usuario", fil);
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
                com.CommandText = "sp_SelAllComplete_Registro_de_Usuario_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Registro_de_Usuario";
        else
            com.CommandText="sp_SelAllRegistro_de_Usuario";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (Registro_de_UsuarioCS.Registro_de_UsuarioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Usuario", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Registro_de_Usuario", fil);
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

    //-----------------------------------------------------------Métodos para paginación--------------------------------------------------------------
    public int SelCount(string sortDirection, string sortExpression, int maximumRows, int startRowIndex)
    {
            DataSet ds;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.Text;
            
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

        
        if (swhere != string.Empty)
                swhere = (!swhere.ToLower().Trim().StartsWith("where") ? " WHERE " + swhere : swhere);

        string sPagingCountTemplate = @"SELECT COUNT(*) {0}";
                  string from = " from ((( Registro_de_Usuario WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos as Foto_de_Perfil WITH(NoLock) ON Foto_de_Perfil.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as Usuario_del_Sistema WITH(NoLock) ON Usuario_del_Sistema.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)        " + swhere; 

        sPagingCountTemplate = string.Format(sPagingCountTemplate, from);

        com.CommandText = sPagingCountTemplate;

        ds = db.Consulta(com);
        fullQueryCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
        return fullQueryCount;
    }

    public DataSet SelAll(string sortDirection, string sortExpression, int maximumRows, int startRowIndex)
    {
        DataSet ds;
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType=CommandType.Text;
        
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
                if (sOrderBy=="")
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

                    switch (sortExpression)             {                 case "Registro_de_Usuario_Folio": sortExpression = "Registro_de_Usuario.Folio"; break;  case "Registro_de_Usuario_Usuario_que_Registra": sortExpression = "Registro_de_Usuario.Usuario_que_Registra"; break;  case "Usuario_que_Registra_Nombre": sortExpression = "Usuario_que_Registra.Nombre"; break;  case "Registro_de_Usuario_Fecha_de_Registro": sortExpression = "Registro_de_Usuario.Fecha_de_Registro"; break;  case "Registro_de_Usuario_Hora_de_Registro": sortExpression = "Registro_de_Usuario.Hora_de_Registro"; break;  case "Registro_de_Usuario_Nombre": sortExpression = "Registro_de_Usuario.Nombre"; break;  case "Registro_de_Usuario_Apellido": sortExpression = "Registro_de_Usuario.Apellido"; break;  case "Registro_de_Usuario_Nombre_Completo": sortExpression = "Registro_de_Usuario.Nombre_Completo"; break;  case "Registro_de_Usuario_Correo": sortExpression = "Registro_de_Usuario.Correo"; break;  case "Registro_de_Usuario_Contrasena": sortExpression = "Registro_de_Usuario.Contrasena"; break;  case "Registro_de_Usuario_Confirmar_Contrasena": sortExpression = "Registro_de_Usuario.Confirmar_Contrasena"; break;  case "Registro_de_Usuario_Acepta_Terminos": sortExpression = "Registro_de_Usuario.Acepta_Terminos"; break;  case "Registro_de_Usuario_Foto_de_Perfil": sortExpression = "Registro_de_Usuario.Foto_de_Perfil"; break;  case "Foto_de_Perfil_Nombre": sortExpression = "Foto_de_Perfil.Nombre"; break;  case "Registro_de_Usuario_Usuario_del_Sistema": sortExpression = "Registro_de_Usuario.Usuario_del_Sistema"; break;  case "Usuario_del_Sistema_Nombre": sortExpression = "Usuario_del_Sistema.Nombre"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Registro_de_Usuario.Folio, Registro_de_Usuario.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Usuario.Fecha_de_Registro, Registro_de_Usuario.Hora_de_Registro, Registro_de_Usuario.Nombre, Registro_de_Usuario.Apellido, Registro_de_Usuario.Nombre_Completo, Registro_de_Usuario.Correo, Registro_de_Usuario.Contrasena, Registro_de_Usuario.Confirmar_Contrasena, Registro_de_Usuario.Acepta_Terminos, Registro_de_Usuario.Foto_de_Perfil, Foto_de_Perfil.Nombre, Registro_de_Usuario.Usuario_del_Sistema, Usuario_del_Sistema.Nombre" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        Foto_de_Perfil.Nombre AS Foto_de_Perfil_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        Usuario_del_Sistema.Nombre AS Usuario_del_Sistema_Nombre ";             string fieldsForExport = " Registro_de_Usuario.Folio As [Folio],        Registro_de_Usuario.Usuario_que_Registra AS [Usuario que Registra],        Usuario_que_Registra.Nombre AS [Usuario que Registra Nombre],        Registro_de_Usuario.Fecha_de_Registro As [Fecha de Registro],        Registro_de_Usuario.Hora_de_Registro As [Hora de Registro],        Registro_de_Usuario.Nombre As [Nombre],        Registro_de_Usuario.Apellido As [Apellido],        Registro_de_Usuario.Nombre_Completo As [Nombre Completo],        Registro_de_Usuario.Correo As [Correo],        Registro_de_Usuario.Contrasena As [Contrasena],        Registro_de_Usuario.Confirmar_Contrasena As [Confirmar Contrasena],        Registro_de_Usuario.Acepta_Terminos As [Acepta Terminos],        Registro_de_Usuario.Foto_de_Perfil AS [Foto de Perfil],        Foto_de_Perfil.Nombre AS [Foto de Perfil Nombre],        Registro_de_Usuario.Usuario_del_Sistema AS [Usuario del Sistema],        Usuario_del_Sistema.Nombre AS [Usuario del Sistema Nombre] ";             string from = " from ((( Registro_de_Usuario WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos as Foto_de_Perfil WITH(NoLock) ON Foto_de_Perfil.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as Usuario_del_Sistema WITH(NoLock) ON Usuario_del_Sistema.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)        " + swhere; 

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

        

        return ds;
    }
    

    //-----------------------------------------------------------Métodos para rad Grid----------------------------------------------------------------
    public string GetFullQuery(string where, string Order)
    {
        	swhere = where; 	string fieldsWithAlias = " Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        Foto_de_Perfil.Nombre AS Foto_de_Perfil_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        Usuario_del_Sistema.Nombre AS Usuario_del_Sistema_Nombre ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Usuario.Folio, Registro_de_Usuario.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Usuario.Fecha_de_Registro, Registro_de_Usuario.Hora_de_Registro, Registro_de_Usuario.Nombre, Registro_de_Usuario.Apellido, Registro_de_Usuario.Nombre_Completo, Registro_de_Usuario.Correo, Registro_de_Usuario.Contrasena, Registro_de_Usuario.Confirmar_Contrasena, Registro_de_Usuario.Acepta_Terminos, Registro_de_Usuario.Foto_de_Perfil, Foto_de_Perfil.Nombre, Registro_de_Usuario.Usuario_del_Sistema, Usuario_del_Sistema.Nombre" : Order);         string from = " from ((( Registro_de_Usuario WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos as Foto_de_Perfil WITH(NoLock) ON Foto_de_Perfil.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as Usuario_del_Sistema WITH(NoLock) ON Usuario_del_Sistema.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)        " + swhere;
        return string.Format(this.fullQueryForExport,  fieldsWithAlias + " " + from,Order);
    }

    public DataSet SelAll(int startRowIndex, int maximumRows, string where, string Order)
    {
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            WHERE RowNumber BETWEEN ({2}+1) and {2} + {3}";

       	swhere = where; 	string fieldsWithAlias = " Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        Foto_de_Perfil.Nombre AS Foto_de_Perfil_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        Usuario_del_Sistema.Nombre AS Usuario_del_Sistema_Nombre ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Usuario.Folio, Registro_de_Usuario.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Usuario.Fecha_de_Registro, Registro_de_Usuario.Hora_de_Registro, Registro_de_Usuario.Nombre, Registro_de_Usuario.Apellido, Registro_de_Usuario.Nombre_Completo, Registro_de_Usuario.Correo, Registro_de_Usuario.Contrasena, Registro_de_Usuario.Confirmar_Contrasena, Registro_de_Usuario.Acepta_Terminos, Registro_de_Usuario.Foto_de_Perfil, Foto_de_Perfil.Nombre, Registro_de_Usuario.Usuario_del_Sistema, Usuario_del_Sistema.Nombre" : Order);         string from = " from ((( Registro_de_Usuario WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos as Foto_de_Perfil WITH(NoLock) ON Foto_de_Perfil.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as Usuario_del_Sistema WITH(NoLock) ON Usuario_del_Sistema.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, Order, fieldsWithAlias + " " + from, startRowIndex, maximumRows);

        com.CommandText = sPagingTemplate;

        ds = db.Consulta(com);

        return ds;
    }

    public DataSet SelAll(string where, string Order)
    {
        DataSet ds;
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"WITH ResultSet AS 
                          (SELECT 
                          ROW_NUMBER() OVER (ORDER BY {0}) as RowNumber,
                          {1} ) 
                            SELECT * FROM ResultSet 
                            ";

        	swhere = where; 	string fieldsWithAlias = " Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        Foto_de_Perfil.Nombre AS Foto_de_Perfil_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        Usuario_del_Sistema.Nombre AS Usuario_del_Sistema_Nombre ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Usuario.Folio, Registro_de_Usuario.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Usuario.Fecha_de_Registro, Registro_de_Usuario.Hora_de_Registro, Registro_de_Usuario.Nombre, Registro_de_Usuario.Apellido, Registro_de_Usuario.Nombre_Completo, Registro_de_Usuario.Correo, Registro_de_Usuario.Contrasena, Registro_de_Usuario.Confirmar_Contrasena, Registro_de_Usuario.Acepta_Terminos, Registro_de_Usuario.Foto_de_Perfil, Foto_de_Perfil.Nombre, Registro_de_Usuario.Usuario_del_Sistema, Usuario_del_Sistema.Nombre" : Order);         string from = " from ((( Registro_de_Usuario WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos as Foto_de_Perfil WITH(NoLock) ON Foto_de_Perfil.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as Usuario_del_Sistema WITH(NoLock) ON Usuario_del_Sistema.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, Order, fieldsWithAlias + " " + from);

        com.CommandText = sPagingTemplate;

        ds = db.Consulta(com);

        return ds;
    }

    public int SelCount(string where)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.Text;
        string sPagingTemplate = @"SELECT COUNT(*) {0}" ;
        string Order="";
        	swhere = where; 	string fieldsWithAlias = " Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        Foto_de_Perfil.Nombre AS Foto_de_Perfil_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        Usuario_del_Sistema.Nombre AS Usuario_del_Sistema_Nombre ";         Order = (Order == string.Empty || Order == null ? "Registro_de_Usuario.Folio, Registro_de_Usuario.Usuario_que_Registra, Usuario_que_Registra.Nombre, Registro_de_Usuario.Fecha_de_Registro, Registro_de_Usuario.Hora_de_Registro, Registro_de_Usuario.Nombre, Registro_de_Usuario.Apellido, Registro_de_Usuario.Nombre_Completo, Registro_de_Usuario.Correo, Registro_de_Usuario.Contrasena, Registro_de_Usuario.Confirmar_Contrasena, Registro_de_Usuario.Acepta_Terminos, Registro_de_Usuario.Foto_de_Perfil, Foto_de_Perfil.Nombre, Registro_de_Usuario.Usuario_del_Sistema, Usuario_del_Sistema.Nombre" : Order);         string from = " from ((( Registro_de_Usuario WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos as Foto_de_Perfil WITH(NoLock) ON Foto_de_Perfil.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as Usuario_del_Sistema WITH(NoLock) ON Usuario_del_Sistema.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)        " + swhere;

        sPagingTemplate = string.Format(sPagingTemplate, from);

        com.CommandText = sPagingTemplate;

        return (int)db.ExecuteScalar(com);
   }
    //------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------------------------------------------------------------------------------
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
                com.CommandText = "sp_SelAllComplete_Registro_de_Usuario_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Registro_de_Usuario";
        else
            com.CommandText="sp_SelAllRegistro_de_Usuario";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (Registro_de_UsuarioCS.Registro_de_UsuarioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Usuario", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Registro_de_Usuario", fil);
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

    private String Convierte(String Valor,Int32 Convierte){
        String ValorConvertido = "";
        if (Convierte == 1)
        {
                ValorConvertido = Valor.ToUpper();
        }else{
                ValorConvertido = Valor;
        }
        return ValorConvertido;
    }

    public void Insert(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("Registro_de_Usuario");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsRegistro_de_Usuario";
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro",varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varNombre!=null)
            {
                if (varNombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }            if (varApellido!=null)
            {
                if (varApellido != "")
                    com.Parameters.AddWithValue("@Apellido", Convierte(varApellido, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Apellido", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Apellido", DBNull.Value);
            }            if (varNombre_Completo!=null)
            {
                if (varNombre_Completo != "")
                    com.Parameters.AddWithValue("@Nombre_Completo", Convierte(varNombre_Completo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre_Completo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre_Completo", DBNull.Value);
            }            if (varCorreo!=null)
            {
                if (varCorreo != "")
                    com.Parameters.AddWithValue("@Correo", Convierte(varCorreo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }            if (varContrasena!=null)
            {
                if (varContrasena != "")
                    com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }            if (varConfirmar_Contrasena!=null)
            {
                if (varConfirmar_Contrasena != "")
                    com.Parameters.AddWithValue("@Confirmar_Contrasena", Convierte(varConfirmar_Contrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Confirmar_Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Confirmar_Contrasena", DBNull.Value);
            }            com.Parameters.AddWithValue("@Acepta_Terminos", varAcepta_Terminos);
            com.Parameters.AddWithValue("@Foto_de_Perfil",Conversion.FormatNull(varFoto_de_Perfil));
            com.Parameters.AddWithValue("@Usuario_del_Sistema",Conversion.FormatNull(varUsuario_del_Sistema));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Registro_de_Usuario");
            }
            catch{}
            throw ex; 
        }
        //return sKey;
    }
    
    public object InsertWithReturnValue(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("Registro_de_Usuario");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsRegistro_de_Usuario";
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro",varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varNombre!=null)
            {
                if (varNombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }            if (varApellido!=null)
            {
                if (varApellido != "")
                    com.Parameters.AddWithValue("@Apellido", Convierte(varApellido, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Apellido", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Apellido", DBNull.Value);
            }            if (varNombre_Completo!=null)
            {
                if (varNombre_Completo != "")
                    com.Parameters.AddWithValue("@Nombre_Completo", Convierte(varNombre_Completo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre_Completo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre_Completo", DBNull.Value);
            }            if (varCorreo!=null)
            {
                if (varCorreo != "")
                    com.Parameters.AddWithValue("@Correo", Convierte(varCorreo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }            if (varContrasena!=null)
            {
                if (varContrasena != "")
                    com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }            if (varConfirmar_Contrasena!=null)
            {
                if (varConfirmar_Contrasena != "")
                    com.Parameters.AddWithValue("@Confirmar_Contrasena", Convierte(varConfirmar_Contrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Confirmar_Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Confirmar_Contrasena", DBNull.Value);
            }            com.Parameters.AddWithValue("@Acepta_Terminos", varAcepta_Terminos);
            com.Parameters.AddWithValue("@Foto_de_Perfil",Conversion.FormatNull(varFoto_de_Perfil));
            com.Parameters.AddWithValue("@Usuario_del_Sistema",Conversion.FormatNull(varUsuario_del_Sistema));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Registro_de_Usuario");
            }
            catch{}
            throw ex; 
        }
        return sKeyFolio;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("Registro_de_Usuario");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdRegistro_de_Usuario";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro", varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varNombre!=null)
            {
                if (varNombre != "")
                    com.Parameters.AddWithValue("@Nombre", Convierte(varNombre, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }            if (varApellido!=null)
            {
                if (varApellido != "")
                    com.Parameters.AddWithValue("@Apellido", Convierte(varApellido, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Apellido", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Apellido", DBNull.Value);
            }            if (varNombre_Completo!=null)
            {
                if (varNombre_Completo != "")
                    com.Parameters.AddWithValue("@Nombre_Completo", Convierte(varNombre_Completo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Nombre_Completo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Nombre_Completo", DBNull.Value);
            }            if (varCorreo!=null)
            {
                if (varCorreo != "")
                    com.Parameters.AddWithValue("@Correo", Convierte(varCorreo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Correo", DBNull.Value);
            }            if (varContrasena!=null)
            {
                if (varContrasena != "")
                    com.Parameters.AddWithValue("@Contrasena", Convierte(varContrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contrasena", DBNull.Value);
            }            if (varConfirmar_Contrasena!=null)
            {
                if (varConfirmar_Contrasena != "")
                    com.Parameters.AddWithValue("@Confirmar_Contrasena", Convierte(varConfirmar_Contrasena, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Confirmar_Contrasena", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Confirmar_Contrasena", DBNull.Value);
            }            com.Parameters.AddWithValue("@Acepta_Terminos", varAcepta_Terminos);
            com.Parameters.AddWithValue("@Foto_de_Perfil",Conversion.FormatNull(varFoto_de_Perfil));
            com.Parameters.AddWithValue("@Usuario_del_Sistema",Conversion.FormatNull(varUsuario_del_Sistema));

            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Registro_de_Usuario");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyFolio, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
            Boolean result;
            string Error = "";
            DataReference.Folio =  KeyFolio.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("Registro_de_Usuario");
            try
            {


                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelRegistro_de_Usuario";
com.Parameters.AddWithValue("@Folio",KeyFolio);
                com.CommandType =CommandType.StoredProcedure;
                db.EjecutaDelete(com, UserInformation, DataReference);
                db.CommitTransaction();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                try
                {
                    db.RollBackTransaction("Registro_de_Usuario");
                }
                catch{}
                throw ex; 
            }
            return result;
        //}
    }
    private DataSet GetByKey(DataSet ds)
    {
            if (ds.Tables[0].Rows.Count > 0)
            {
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Usuario_Folio"]);
            Usuario_que_Registra = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Usuario_Usuario_que_Registra"]);
            Fecha_de_Registro = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Registro_de_Usuario_Fecha_de_Registro"]);
            Hora_de_Registro = ds.Tables[0].Rows[0]["Registro_de_Usuario_Hora_de_Registro"].ToString().TrimEnd(' ');
            Nombre = ds.Tables[0].Rows[0]["Registro_de_Usuario_Nombre"].ToString();
            Apellido = ds.Tables[0].Rows[0]["Registro_de_Usuario_Apellido"].ToString();
            Nombre_Completo = ds.Tables[0].Rows[0]["Registro_de_Usuario_Nombre_Completo"].ToString();
            Correo = ds.Tables[0].Rows[0]["Registro_de_Usuario_Correo"].ToString();
            Contrasena = ds.Tables[0].Rows[0]["Registro_de_Usuario_Contrasena"].ToString();
            Confirmar_Contrasena = ds.Tables[0].Rows[0]["Registro_de_Usuario_Confirmar_Contrasena"].ToString();
            if (ds.Tables[0].Rows[0]["Registro_de_Usuario_Acepta_Terminos"] != DBNull.Value)
                Acepta_Terminos = Convert.ToBoolean(ds.Tables[0].Rows[0]["Registro_de_Usuario_Acepta_Terminos"]);
            Foto_de_Perfil = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Usuario_Foto_de_Perfil"]);
            Usuario_del_Sistema = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Registro_de_Usuario_Usuario_del_Sistema"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyFolio, Boolean ConRelaciones){
        DataSet ds;
        if (KeyFolio == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_Registro_de_Usuario";
            else
                com.CommandText="sp_GetRegistro_de_Usuario";
com.Parameters.AddWithValue("@Folio",KeyFolio);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFolio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Folio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyUsuario_que_Registra(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Usuario_que_Registra = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFecha_de_Registro(DateTime Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Fecha_de_Registro = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyHora_de_Registro(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Hora_de_Registro = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyNombre(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyApellido(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Apellido = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyNombre_Completo(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Nombre_Completo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCorreo(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Correo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyContrasena(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Contrasena = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyConfirmar_Contrasena(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Confirmar_Contrasena = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyAcepta_Terminos(Boolean Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Acepta_Terminos = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyFoto_de_Perfil(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Foto_de_Perfil = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyUsuario_del_Sistema(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Registro_de_Usuario.Folio As Registro_de_Usuario_Folio,        Registro_de_Usuario.Usuario_que_Registra AS Registro_de_Usuario_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Registro_de_Usuario.Fecha_de_Registro As Registro_de_Usuario_Fecha_de_Registro,        Registro_de_Usuario.Hora_de_Registro As Registro_de_Usuario_Hora_de_Registro,        Registro_de_Usuario.Nombre As Registro_de_Usuario_Nombre,        Registro_de_Usuario.Apellido As Registro_de_Usuario_Apellido,        Registro_de_Usuario.Nombre_Completo As Registro_de_Usuario_Nombre_Completo,        Registro_de_Usuario.Correo As Registro_de_Usuario_Correo,        Registro_de_Usuario.Contrasena As Registro_de_Usuario_Contrasena,        Registro_de_Usuario.Confirmar_Contrasena As Registro_de_Usuario_Confirmar_Contrasena,        Registro_de_Usuario.Acepta_Terminos As Registro_de_Usuario_Acepta_Terminos,        Registro_de_Usuario.Foto_de_Perfil AS Registro_de_Usuario_Foto_de_Perfil,        TTArchivos.Nombre AS TTArchivos_Nombre,        Registro_de_Usuario.Usuario_del_Sistema AS Registro_de_Usuario_Usuario_del_Sistema,        TTUsuarios1.Nombre AS TTUsuarios1_Nombre   from ((( Registro_de_Usuario       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Registro_de_Usuario.Usuario_que_Registra)       LEFT JOIN TTArchivos ON TTArchivos.Folio=Registro_de_Usuario.Foto_de_Perfil)       LEFT JOIN TTUsuarios as TTUsuarios1 ON TTUsuarios1.IdUsuario=Registro_de_Usuario.Usuario_del_Sistema)           Where Registro_de_Usuario.Usuario_del_Sistema = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Registro_de_Usuario";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (Registro_de_UsuarioCS.Registro_de_UsuarioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Registro_de_Usuario", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Registro_de_Usuario_Folio"]) == KeyFolio)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyFolio){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetRegistro_de_Usuario";
com.Parameters.AddWithValue("@Folio",KeyFolio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataUsuario_que_RegistraControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataUsuario_que_Registra(Object ctr, String Filtro){
            public DataTable FillDataUsuario_que_Registra(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Usuario_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataUsuario_que_RegistraControl(ctr, dt);
                return dt;
            }
//            public void FillDataUsuario_que_Registra(Object ctr){
            public DataTable FillDataUsuario_que_Registra(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Usuario_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuario_que_RegistraControl(ctr, dt);
                return dt;
            }
/*            private void FillDataUsuario_del_SistemaControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataUsuario_del_Sistema(Object ctr, String Filtro){
            public DataTable FillDataUsuario_del_Sistema(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Usuario_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataUsuario_del_SistemaControl(ctr, dt);
                return dt;
            }
//            public void FillDataUsuario_del_Sistema(Object ctr){
            public DataTable FillDataUsuario_del_Sistema(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selRegistro_de_Usuario_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuario_del_SistemaControl(ctr, dt);
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
                //Prismaproj.TTSearchAdvanced MySearchAdvanced = new Prismaproj.TTSearchAdvanced();
                //Prismaproj.TTSearchAdvancedData MySearch = MySearchAdvanced.GetStructView(iVistaID);
                //MyFiltersObligatories[iViews] = MySearch.Filter;
                //MyConfigurationColumnsObligatories[iViews] = MySearch.Configuration;
            }
        }
    }
}
