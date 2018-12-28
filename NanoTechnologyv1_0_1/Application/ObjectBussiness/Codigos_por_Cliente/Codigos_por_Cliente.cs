using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Codigos_por_ClienteCS
{
    public class Codigos_por_ClienteFilters
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
        private TTClassSpecials.FiltersTypes.String varCliente = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Cliente
        {
            get { return varCliente; }
            set { varCliente = value; }
        }
        private TTClassSpecials.FiltersTypes.String varContacto = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Contacto
        {
            get { return varContacto; }
            set { varContacto = value; }
        }
        private TTClassSpecials.FiltersTypes.String varCorreo = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Correo
        {
            get { return varCorreo; }
            set { varCorreo = value; }
        }
        private Detalle_de_Codigo_Por_ClienteCS.Detalle_de_Codigo_Por_ClienteFilters varDetalle_de_Codigos =new Detalle_de_Codigo_Por_ClienteCS.Detalle_de_Codigo_Por_ClienteFilters();
        public Detalle_de_Codigo_Por_ClienteCS.Detalle_de_Codigo_Por_ClienteFilters Detalle_de_Codigos{
            get { return varDetalle_de_Codigos; }
            set { varDetalle_de_Codigos = value; }
        }

    }
public class objectBussinessCodigos_por_Cliente : IDisposable
{
    public int iProcess = 30071;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private Codigos_por_ClienteFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varFolio;
	private int? varUsuario_que_Registra;
	private DateTime? varFecha_de_Registro;
	private String varHora_de_Registro;
	private String varCliente;
	private String varContacto;
	private String varCorreo;
    private Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente[] varDetalle_de_Codigos;


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

    public Codigos_por_ClienteFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public Codigos_por_ClienteFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new Codigos_por_ClienteFilters[1];
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
    public String Cliente{
        get { return varCliente;}
        set { varCliente = value;}
    }
    public String Contacto{
        get { return varContacto;}
        set { varContacto = value;}
    }
    public String Correo{
        get { return varCorreo;}
        set { varCorreo = value;}
    }
    public Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente[] Detalle_de_Codigos{
        get { return varDetalle_de_Codigos;}
        set { varDetalle_de_Codigos = value;}
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
            com.CommandText = "sp_SelAllComplete_Codigos_por_Cliente_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Codigos_por_Cliente";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (Codigos_por_ClienteCS.Codigos_por_ClienteFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Codigos_por_Cliente", fil);
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
                com.CommandText = "sp_SelAllComplete_Codigos_por_Cliente_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Codigos_por_Cliente";
        else
            com.CommandText="sp_SelAllCodigos_por_Cliente";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (Codigos_por_ClienteCS.Codigos_por_ClienteFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Codigos_por_Cliente", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Codigos_por_Cliente", fil);
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
                  string from = " from ( Codigos_por_Cliente WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)        " + swhere; 

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

                    switch (sortExpression)             {                 case "Codigos_por_Cliente_Folio": sortExpression = "Codigos_por_Cliente.Folio"; break;  case "Codigos_por_Cliente_Usuario_que_Registra": sortExpression = "Codigos_por_Cliente.Usuario_que_Registra"; break;  case "Usuario_que_Registra_Nombre": sortExpression = "Usuario_que_Registra.Nombre"; break;  case "Codigos_por_Cliente_Fecha_de_Registro": sortExpression = "Codigos_por_Cliente.Fecha_de_Registro"; break;  case "Codigos_por_Cliente_Hora_de_Registro": sortExpression = "Codigos_por_Cliente.Hora_de_Registro"; break;  case "Codigos_por_Cliente_Cliente": sortExpression = "Codigos_por_Cliente.Cliente"; break;  case "Codigos_por_Cliente_Contacto": sortExpression = "Codigos_por_Cliente.Contacto"; break;  case "Codigos_por_Cliente_Correo": sortExpression = "Codigos_por_Cliente.Correo"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Codigos_por_Cliente.Folio, Codigos_por_Cliente.Usuario_que_Registra, Usuario_que_Registra.Nombre, Codigos_por_Cliente.Fecha_de_Registro, Codigos_por_Cliente.Hora_de_Registro, Codigos_por_Cliente.Cliente, Codigos_por_Cliente.Contacto, Codigos_por_Cliente.Correo" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo ";             string fieldsForExport = " Codigos_por_Cliente.Folio As [Folio],        Codigos_por_Cliente.Usuario_que_Registra AS [Usuario que Registra],        Usuario_que_Registra.Nombre AS [Usuario que Registra Nombre],        Codigos_por_Cliente.Fecha_de_Registro As [Fecha de Registro],        Codigos_por_Cliente.Hora_de_Registro As [Hora de Registro],        Codigos_por_Cliente.Cliente As [Cliente],        Codigos_por_Cliente.Contacto As [Contacto],        Codigos_por_Cliente.Correo As [Correo] ";             string from = " from ( Codigos_por_Cliente WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo ";         Order = (Order == string.Empty || Order == null ? "Codigos_por_Cliente.Folio, Codigos_por_Cliente.Usuario_que_Registra, Usuario_que_Registra.Nombre, Codigos_por_Cliente.Fecha_de_Registro, Codigos_por_Cliente.Hora_de_Registro, Codigos_por_Cliente.Cliente, Codigos_por_Cliente.Contacto, Codigos_por_Cliente.Correo" : Order);         string from = " from ( Codigos_por_Cliente WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)        " + swhere;
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

       	swhere = where; 	string fieldsWithAlias = " Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo ";         Order = (Order == string.Empty || Order == null ? "Codigos_por_Cliente.Folio, Codigos_por_Cliente.Usuario_que_Registra, Usuario_que_Registra.Nombre, Codigos_por_Cliente.Fecha_de_Registro, Codigos_por_Cliente.Hora_de_Registro, Codigos_por_Cliente.Cliente, Codigos_por_Cliente.Contacto, Codigos_por_Cliente.Correo" : Order);         string from = " from ( Codigos_por_Cliente WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo ";         Order = (Order == string.Empty || Order == null ? "Codigos_por_Cliente.Folio, Codigos_por_Cliente.Usuario_que_Registra, Usuario_que_Registra.Nombre, Codigos_por_Cliente.Fecha_de_Registro, Codigos_por_Cliente.Hora_de_Registro, Codigos_por_Cliente.Cliente, Codigos_por_Cliente.Contacto, Codigos_por_Cliente.Correo" : Order);         string from = " from ( Codigos_por_Cliente WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        Usuario_que_Registra.Nombre AS Usuario_que_Registra_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo ";         Order = (Order == string.Empty || Order == null ? "Codigos_por_Cliente.Folio, Codigos_por_Cliente.Usuario_que_Registra, Usuario_que_Registra.Nombre, Codigos_por_Cliente.Fecha_de_Registro, Codigos_por_Cliente.Hora_de_Registro, Codigos_por_Cliente.Cliente, Codigos_por_Cliente.Contacto, Codigos_por_Cliente.Correo" : Order);         string from = " from ( Codigos_por_Cliente WITH(NoLock) LEFT JOIN TTUsuarios as Usuario_que_Registra WITH(NoLock) ON Usuario_que_Registra.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_Codigos_por_Cliente_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Codigos_por_Cliente";
        else
            com.CommandText="sp_SelAllCodigos_por_Cliente";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (Codigos_por_ClienteCS.Codigos_por_ClienteFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Codigos_por_Cliente", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Codigos_por_Cliente", fil);
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

        db.BeginTransaction("Codigos_por_Cliente");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsCodigos_por_Cliente";
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro",varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varCliente!=null)
            {
                if (varCliente != "")
                    com.Parameters.AddWithValue("@Cliente", Convierte(varCliente, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Cliente", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Cliente", DBNull.Value);
            }            if (varContacto!=null)
            {
                if (varContacto != "")
                    com.Parameters.AddWithValue("@Contacto", Convierte(varContacto, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contacto", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contacto", DBNull.Value);
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
            }
            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            
            if(varDetalle_de_Codigos != null)
            {
                for (int i = 0;i< varDetalle_de_Codigos.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Codigo_Por_Cliente";
                    com.Parameters.AddWithValue("@Cliente", sKeyFolio);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varDetalle_de_Codigos[i].Observatorio));
            if (varDetalle_de_Codigos[i].Codigo!=null)
            {
                if (varDetalle_de_Codigos[i].Codigo != "")
                    com.Parameters.AddWithValue("@Codigo", Convierte(varDetalle_de_Codigos[i].Codigo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }                com.Parameters.AddWithValue("@Estatus", Conversion.FormatNull(varDetalle_de_Codigos[i].Estatus));
                com.Parameters.AddWithValue("@Expiracion", Conversion.FormatNull(varDetalle_de_Codigos[i].Expiracion));
                com.Parameters.AddWithValue("@Accesos", Conversion.FormatNull(varDetalle_de_Codigos[i].Accesos));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Codigos_por_Cliente");
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

        db.BeginTransaction("Codigos_por_Cliente");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsCodigos_por_Cliente";
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro",varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varCliente!=null)
            {
                if (varCliente != "")
                    com.Parameters.AddWithValue("@Cliente", Convierte(varCliente, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Cliente", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Cliente", DBNull.Value);
            }            if (varContacto!=null)
            {
                if (varContacto != "")
                    com.Parameters.AddWithValue("@Contacto", Convierte(varContacto, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contacto", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contacto", DBNull.Value);
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
            }
            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varFolio = sKeyFolio;
            
            if(varDetalle_de_Codigos != null)
            {
                for (int i = 0;i< varDetalle_de_Codigos.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Codigo_Por_Cliente";
                    com.Parameters.AddWithValue("@Cliente", sKeyFolio);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varDetalle_de_Codigos[i].Observatorio));
            if (varDetalle_de_Codigos[i].Codigo!=null)
            {
                if (varDetalle_de_Codigos[i].Codigo != "")
                    com.Parameters.AddWithValue("@Codigo", Convierte(varDetalle_de_Codigos[i].Codigo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }                com.Parameters.AddWithValue("@Estatus", Conversion.FormatNull(varDetalle_de_Codigos[i].Estatus));
                com.Parameters.AddWithValue("@Expiracion", Conversion.FormatNull(varDetalle_de_Codigos[i].Expiracion));
                com.Parameters.AddWithValue("@Accesos", Conversion.FormatNull(varDetalle_de_Codigos[i].Accesos));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Codigos_por_Cliente");
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

        db.BeginTransaction("Codigos_por_Cliente");
        int? sKeyFolio = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdCodigos_por_Cliente";
            com.Parameters.AddWithValue("@Folio",Conversion.FormatNull(varFolio));
            com.Parameters.AddWithValue("@Usuario_que_Registra",Conversion.FormatNull(varUsuario_que_Registra));
            com.Parameters.AddWithValue("@Fecha_de_Registro",Conversion.FormatNull(varFecha_de_Registro));
            if (varHora_de_Registro!=null)
                com.Parameters.AddWithValue("@Hora_de_Registro", varHora_de_Registro);
            else
                com.Parameters.AddWithValue("@Hora_de_Registro", DBNull.Value);
            if (varCliente!=null)
            {
                if (varCliente != "")
                    com.Parameters.AddWithValue("@Cliente", Convierte(varCliente, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Cliente", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Cliente", DBNull.Value);
            }            if (varContacto!=null)
            {
                if (varContacto != "")
                    com.Parameters.AddWithValue("@Contacto", Convierte(varContacto, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Contacto", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Contacto", DBNull.Value);
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
            }
            com.CommandType =CommandType.StoredProcedure;
            sKeyFolio = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varFolio = sKeyFolio;
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyFolio.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Clave from Detalle_de_Codigo_Por_Cliente Where Cliente = '" + sKeyFolio.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varDetalle_de_Codigos != null)
            {
                for (int i = 0;i< varDetalle_de_Codigos.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varDetalle_de_Codigos[i].Clave.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@Cliente", sKeyFolio);
                com.Parameters.AddWithValue("@Observatorio", Conversion.FormatNull(varDetalle_de_Codigos[i].Observatorio));
            if (varDetalle_de_Codigos[i].Codigo!=null)
            {
                if (varDetalle_de_Codigos[i].Codigo != "")
                    com.Parameters.AddWithValue("@Codigo", Convierte(varDetalle_de_Codigos[i].Codigo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }                com.Parameters.AddWithValue("@Estatus", Conversion.FormatNull(varDetalle_de_Codigos[i].Estatus));
                com.Parameters.AddWithValue("@Expiracion", Conversion.FormatNull(varDetalle_de_Codigos[i].Expiracion));
                com.Parameters.AddWithValue("@Accesos", Conversion.FormatNull(varDetalle_de_Codigos[i].Accesos));

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsDetalle_de_Codigo_Por_Cliente";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdDetalle_de_Codigo_Por_Cliente";
                        com.Parameters.AddWithValue("@Clave", varDetalle_de_Codigos[i].Clave);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varDetalle_de_Codigos[i].Clave);
                    }
                }
            }
            //Borrar los registro que estan de mas
            String FiltroDelete = "";
            foreach (DataRow dr in drs.Rows )
            {
                Boolean existe = false;
                foreach( object arr in arrRegistry)
                if (arr.ToString() == dr[0].ToString())
                {
                    existe = true;
                    break;
                }
            if (!existe)
                FiltroDelete += ", '" + dr[0].ToString() + "'";
            }
            if (FiltroDelete != "")
            {
                FiltroDelete =" Where Clave in (" + FiltroDelete.Substring(2) + ")";
                db.EjecutaDelete(new SqlCommand("Delete from Detalle_de_Codigo_Por_Cliente " + FiltroDelete), UserInformation, DataReference);
            }
        }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Codigos_por_Cliente");
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
            db.BeginTransaction("Codigos_por_Cliente");
            try
            {
                DataReference.Folio = KeyFolio.ToString();
                TTDataLayerCS.BD dbDetalle_de_Codigo_Por_Cliente = new TTDataLayerCS.BD();
                DataSet recordsDetalle_de_Codigo_Por_Cliente = dbDetalle_de_Codigo_Por_Cliente.Consulta(new SqlCommand("Select Count(*) From Detalle_de_Codigo_Por_Cliente Where Cliente = '" + KeyFolio.ToString() + "'"));
                if (recordsDetalle_de_Codigo_Por_Cliente.Tables.Count > 0)
                    if (recordsDetalle_de_Codigo_Por_Cliente.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsDetalle_de_Codigo_Por_Cliente = int.Parse(recordsDetalle_de_Codigo_Por_Cliente.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsDetalle_de_Codigo_Por_Cliente > 0)
                            Error = Error + "- Detalle de Codigo Por Cliente \r\n"; 
                    }
                dbDetalle_de_Codigo_Por_Cliente.Disconnect();

                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelCodigos_por_Cliente";
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
                    db.RollBackTransaction("Codigos_por_Cliente");
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
            Folio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Codigos_por_Cliente_Folio"]);
            Usuario_que_Registra = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Codigos_por_Cliente_Usuario_que_Registra"]);
            Fecha_de_Registro = Conversion.CambiaToDatetime(ds.Tables[0].Rows[0]["Codigos_por_Cliente_Fecha_de_Registro"]);
            Hora_de_Registro = ds.Tables[0].Rows[0]["Codigos_por_Cliente_Hora_de_Registro"].ToString().TrimEnd(' ');
            Cliente = ds.Tables[0].Rows[0]["Codigos_por_Cliente_Cliente"].ToString();
            Contacto = ds.Tables[0].Rows[0]["Codigos_por_Cliente_Contacto"].ToString();
            Correo = ds.Tables[0].Rows[0]["Codigos_por_Cliente_Correo"].ToString();

                {
                    Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente MyDataDetalle_de_Codigos = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
                    Detalle_de_Codigo_Por_ClienteCS.Detalle_de_Codigo_Por_ClienteFilters MyDataFilterDetalle_de_Codigos = new Detalle_de_Codigo_Por_ClienteCS.Detalle_de_Codigo_Por_ClienteFilters();
                    MyDataFilterDetalle_de_Codigos.Cliente.List = new String[1];
                    MyDataFilterDetalle_de_Codigos.Cliente.List[0] = Folio.Value.ToString();
                    MyDataDetalle_de_Codigos.Filters = new Detalle_de_Codigo_Por_ClienteCS.Detalle_de_Codigo_Por_ClienteFilters[1];
                    MyDataDetalle_de_Codigos.Filters[0] = MyDataFilterDetalle_de_Codigos;
                    DataSet dsMulti = MyDataDetalle_de_Codigos.SelAll(true);
                    Detalle_de_Codigos = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Detalle_de_Codigos[i] = new Detalle_de_Codigo_Por_ClienteCS.objectBussinessDetalle_de_Codigo_Por_Cliente();
                    Detalle_de_Codigos[i].Clave = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Codigo_Por_Cliente_Clave"]);
                    Detalle_de_Codigos[i].Cliente = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Codigo_Por_Cliente_Cliente"]);
                    Detalle_de_Codigos[i].Observatorio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Codigo_Por_Cliente_Observatorio"]);
                    Detalle_de_Codigos[i].Codigo = dsMulti.Tables[0].Rows[i]["Detalle_de_Codigo_Por_Cliente_Codigo"].ToString().TrimEnd(' ');
                    Detalle_de_Codigos[i].Estatus = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Codigo_Por_Cliente_Estatus"]);
                    Detalle_de_Codigos[i].Expiracion = Conversion.CambiaToDatetime (dsMulti.Tables[0].Rows[i]["Detalle_de_Codigo_Por_Cliente_Expiracion"]);
                    Detalle_de_Codigos[i].Accesos = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Codigo_Por_Cliente_Accesos"]);

                    }
               }    


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
                com.CommandText="sp_GetComplete_Codigos_por_Cliente";
            else
                com.CommandText="sp_GetCodigos_por_Cliente";
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
            com.CommandText="Select         Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo   from ( Codigos_por_Cliente       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)           Where Codigos_por_Cliente.Folio = '" + Key + "'";
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
            com.CommandText="Select         Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo   from ( Codigos_por_Cliente       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)           Where Codigos_por_Cliente.Usuario_que_Registra = '" + Key + "'";
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
            com.CommandText="Select         Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo   from ( Codigos_por_Cliente       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)           Where Codigos_por_Cliente.Fecha_de_Registro = '" + Key + "'";
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
            com.CommandText="Select         Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo   from ( Codigos_por_Cliente       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)           Where Codigos_por_Cliente.Hora_de_Registro = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyCliente(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo   from ( Codigos_por_Cliente       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)           Where Codigos_por_Cliente.Cliente = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyContacto(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo   from ( Codigos_por_Cliente       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)           Where Codigos_por_Cliente.Contacto = '" + Key + "'";
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
            com.CommandText="Select         Codigos_por_Cliente.Folio As Codigos_por_Cliente_Folio,        Codigos_por_Cliente.Usuario_que_Registra AS Codigos_por_Cliente_Usuario_que_Registra,        TTUsuarios.Nombre AS TTUsuarios_Nombre,        Codigos_por_Cliente.Fecha_de_Registro As Codigos_por_Cliente_Fecha_de_Registro,        Codigos_por_Cliente.Hora_de_Registro As Codigos_por_Cliente_Hora_de_Registro,        Codigos_por_Cliente.Cliente As Codigos_por_Cliente_Cliente,        Codigos_por_Cliente.Contacto As Codigos_por_Cliente_Contacto,        Codigos_por_Cliente.Correo As Codigos_por_Cliente_Correo   from ( Codigos_por_Cliente       LEFT JOIN TTUsuarios ON TTUsuarios.IdUsuario=Codigos_por_Cliente.Usuario_que_Registra)           Where Codigos_por_Cliente.Correo = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyFolio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Codigos_por_Cliente";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (Codigos_por_ClienteCS.Codigos_por_ClienteFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Codigos_por_Cliente", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Codigos_por_Cliente_Folio"]) == KeyFolio)
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
        com.CommandText = "sp_GetCodigos_por_Cliente";
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
                com.CommandText = "sp_selCodigos_por_Cliente_Relacion_TTUsuarios";
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
                com.CommandText = "sp_selCodigos_por_Cliente_Relacion_TTUsuarios";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataUsuario_que_RegistraControl(ctr, dt);
                return dt;
            }
/*            private void FillDataDetalle_de_CodigosControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Clave";
                        ((ComboBox)ctr).ValueMember = "Clave";
                        ((ComboBox)ctr).SelectedItem = null;
                        if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                        {
                            ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                            ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                            AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                            foreach (DataRow dr in ((DataTable)((ComboBox)ctr).DataSource).Rows)
                                ls.Add(dr["Clave"].ToString());
                            ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                        }
                }
                else if (ctr.GetType() == typeof(ListBox))
                {
                        ((ListBox)ctr).DataSource = dt;
                        ((ListBox)ctr).DisplayMember = "Clave";
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Clave";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataDetalle_de_Codigos(Object ctr, String Filtro){
            public DataTable FillDataDetalle_de_Codigos(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selCodigos_por_Cliente_Relacion_Detalle_de_Codigo_Por_Cliente";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataDetalle_de_CodigosControl(ctr, dt);
                return dt;
            }
//            public void FillDataDetalle_de_Codigos(Object ctr){
            public DataTable FillDataDetalle_de_Codigos(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selCodigos_por_Cliente_Relacion_Detalle_de_Codigo_Por_Cliente";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataDetalle_de_CodigosControl(ctr, dt);
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
