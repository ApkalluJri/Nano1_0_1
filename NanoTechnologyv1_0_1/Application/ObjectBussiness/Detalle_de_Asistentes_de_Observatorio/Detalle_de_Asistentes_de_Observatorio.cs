using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Detalle_de_Asistentes_de_ObservatorioCS
{
    public class Detalle_de_Asistentes_de_ObservatorioFilters
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
        private TTClassSpecials.FiltersTypes.Numeric  varClave =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Clave{
            get { return varClave; }
            set { varClave = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varObservatorio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private ObservatorioCS.ObservatorioFilters[] varObservatorio;
        public TTClassSpecials.FiltersTypes.Dependientes Observatorio{
            get { return varObservatorio; }
            set { varObservatorio = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varNombre =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Registro_de_RolesCS.Registro_de_RolesFilters[] varNombre;
        public TTClassSpecials.FiltersTypes.Dependientes Nombre{
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varRol =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Rol_de_UsuarioCS.Rol_de_UsuarioFilters[] varRol;
        public TTClassSpecials.FiltersTypes.Dependientes Rol{
            get { return varRol; }
            set { varRol = value; }
        }

    }
public class objectBussinessDetalle_de_Asistentes_de_Observatorio : IDisposable
{
    public int iProcess = 30353;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private Detalle_de_Asistentes_de_ObservatorioFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varClave;
	private int? varObservatorio;
	private int? varNombre;
	private int? varRol;


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

    public Detalle_de_Asistentes_de_ObservatorioFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public Detalle_de_Asistentes_de_ObservatorioFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new Detalle_de_Asistentes_de_ObservatorioFilters[1];
            filters[0] = value;
        }
    }

    public int? Clave{
        get { return varClave;}
        set { varClave = value;}
    }
    public int? Observatorio{
        get { return varObservatorio;}
        set { varObservatorio = value;}
    }
    public int? Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public int? Rol{
        get { return varRol;}
        set { varRol = value;}
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
            com.CommandText = "sp_SelAllComplete_Detalle_de_Asistentes_de_Observatorio_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Detalle_de_Asistentes_de_Observatorio";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Detalle_de_Asistentes_de_Observatorio", fil);
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
                com.CommandText = "sp_SelAllComplete_Detalle_de_Asistentes_de_Observatorio_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Detalle_de_Asistentes_de_Observatorio";
        else
            com.CommandText="sp_SelAllDetalle_de_Asistentes_de_Observatorio";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Detalle_de_Asistentes_de_Observatorio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Detalle_de_Asistentes_de_Observatorio", fil);
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
                  string from = " from ((( Detalle_de_Asistentes_de_Observatorio WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles as Nombre WITH(NoLock) ON Nombre.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)        " + swhere; 

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

                    switch (sortExpression)             {                 case "Detalle_de_Asistentes_de_Observatorio_Clave": sortExpression = "Detalle_de_Asistentes_de_Observatorio.Clave"; break;  case "Detalle_de_Asistentes_de_Observatorio_Observatorio": sortExpression = "Detalle_de_Asistentes_de_Observatorio.Observatorio"; break;  case "Observatorio_Clave": sortExpression = "Observatorio.Clave"; break;  case "Detalle_de_Asistentes_de_Observatorio_Nombre": sortExpression = "Detalle_de_Asistentes_de_Observatorio.Nombre"; break;  case "Nombre_Nombre": sortExpression = "Nombre.Nombre"; break;  case "Detalle_de_Asistentes_de_Observatorio_Rol": sortExpression = "Detalle_de_Asistentes_de_Observatorio.Rol"; break;  case "Rol_Descripcion": sortExpression = "Rol.Descripcion"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Detalle_de_Asistentes_de_Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Observatorio, Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Nombre, Nombre.Nombre, Detalle_de_Asistentes_de_Observatorio.Rol, Rol.Descripcion" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Nombre.Nombre AS Nombre_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol.Descripcion AS Rol_Descripcion ";             string fieldsForExport = " Detalle_de_Asistentes_de_Observatorio.Clave As [Clave],        Detalle_de_Asistentes_de_Observatorio.Observatorio AS [Observatorio],        Observatorio.Clave AS [Observatorio Clave],        Detalle_de_Asistentes_de_Observatorio.Nombre AS [Nombre],        Nombre.Nombre AS [Nombre Nombre],        Detalle_de_Asistentes_de_Observatorio.Rol AS [Rol],        Rol.Descripcion AS [Rol Descripcion] ";             string from = " from ((( Detalle_de_Asistentes_de_Observatorio WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles as Nombre WITH(NoLock) ON Nombre.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Nombre.Nombre AS Nombre_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol.Descripcion AS Rol_Descripcion ";         Order = (Order == string.Empty || Order == null ? "Detalle_de_Asistentes_de_Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Observatorio, Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Nombre, Nombre.Nombre, Detalle_de_Asistentes_de_Observatorio.Rol, Rol.Descripcion" : Order);         string from = " from ((( Detalle_de_Asistentes_de_Observatorio WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles as Nombre WITH(NoLock) ON Nombre.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)        " + swhere;
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

       	swhere = where; 	string fieldsWithAlias = " Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Nombre.Nombre AS Nombre_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol.Descripcion AS Rol_Descripcion ";         Order = (Order == string.Empty || Order == null ? "Detalle_de_Asistentes_de_Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Observatorio, Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Nombre, Nombre.Nombre, Detalle_de_Asistentes_de_Observatorio.Rol, Rol.Descripcion" : Order);         string from = " from ((( Detalle_de_Asistentes_de_Observatorio WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles as Nombre WITH(NoLock) ON Nombre.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Nombre.Nombre AS Nombre_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol.Descripcion AS Rol_Descripcion ";         Order = (Order == string.Empty || Order == null ? "Detalle_de_Asistentes_de_Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Observatorio, Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Nombre, Nombre.Nombre, Detalle_de_Asistentes_de_Observatorio.Rol, Rol.Descripcion" : Order);         string from = " from ((( Detalle_de_Asistentes_de_Observatorio WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles as Nombre WITH(NoLock) ON Nombre.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Nombre.Nombre AS Nombre_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol.Descripcion AS Rol_Descripcion ";         Order = (Order == string.Empty || Order == null ? "Detalle_de_Asistentes_de_Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Observatorio, Observatorio.Clave, Detalle_de_Asistentes_de_Observatorio.Nombre, Nombre.Nombre, Detalle_de_Asistentes_de_Observatorio.Rol, Rol.Descripcion" : Order);         string from = " from ((( Detalle_de_Asistentes_de_Observatorio WITH(NoLock) LEFT JOIN Observatorio as Observatorio WITH(NoLock) ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles as Nombre WITH(NoLock) ON Nombre.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario as Rol WITH(NoLock) ON Rol.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_Detalle_de_Asistentes_de_Observatorio_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Detalle_de_Asistentes_de_Observatorio";
        else
            com.CommandText="sp_SelAllDetalle_de_Asistentes_de_Observatorio";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Detalle_de_Asistentes_de_Observatorio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Detalle_de_Asistentes_de_Observatorio", fil);
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

        db.BeginTransaction("Detalle_de_Asistentes_de_Observatorio");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsDetalle_de_Asistentes_de_Observatorio";
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));
            com.Parameters.AddWithValue("@Nombre",Conversion.FormatNull(varNombre));
            com.Parameters.AddWithValue("@Rol",Conversion.FormatNull(varRol));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varClave = sKeyClave;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Detalle_de_Asistentes_de_Observatorio");
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

        db.BeginTransaction("Detalle_de_Asistentes_de_Observatorio");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsDetalle_de_Asistentes_de_Observatorio";
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));
            com.Parameters.AddWithValue("@Nombre",Conversion.FormatNull(varNombre));
            com.Parameters.AddWithValue("@Rol",Conversion.FormatNull(varRol));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varClave = sKeyClave;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Detalle_de_Asistentes_de_Observatorio");
            }
            catch{}
            throw ex; 
        }
        return sKeyClave;
    }
    
    public void Update(TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
        TTDataLayerCS.BD db =new TTDataLayerCS.BD();

        SqlCommand coma = new SqlCommand("Select Conversion_a_Mayusculas from ttConfiguracionProyecto");
        coma.CommandType = CommandType.Text;
        DataSet dsa = db.Consulta(coma);
        Int32 ConvierteAMayusculas = Int32.Parse(dsa.Tables[0].Rows[0].ItemArray[0].ToString());

        db.BeginTransaction("Detalle_de_Asistentes_de_Observatorio");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdDetalle_de_Asistentes_de_Observatorio";
            com.Parameters.AddWithValue("@Clave",Conversion.FormatNull(varClave));
            com.Parameters.AddWithValue("@Observatorio",Conversion.FormatNull(varObservatorio));
            com.Parameters.AddWithValue("@Nombre",Conversion.FormatNull(varNombre));
            com.Parameters.AddWithValue("@Rol",Conversion.FormatNull(varRol));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varClave = sKeyClave;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Detalle_de_Asistentes_de_Observatorio");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyClave, int? KeyObservatorio, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
            Boolean result;
            string Error = "";
            DataReference.Folio =  KeyClave.ToString()+ ","+ KeyObservatorio.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("Detalle_de_Asistentes_de_Observatorio");
            try
            {


                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelDetalle_de_Asistentes_de_Observatorio";
com.Parameters.AddWithValue("@Clave",KeyClave);com.Parameters.AddWithValue("@Observatorio",KeyObservatorio);
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
                    db.RollBackTransaction("Detalle_de_Asistentes_de_Observatorio");
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
            Clave = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Detalle_de_Asistentes_de_Observatorio_Clave"]);
            Observatorio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Detalle_de_Asistentes_de_Observatorio_Observatorio"]);
            Nombre = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Detalle_de_Asistentes_de_Observatorio_Nombre"]);
            Rol = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Detalle_de_Asistentes_de_Observatorio_Rol"]);



            }
        return ds;
    }
    public DataSet GetByKey(int? KeyClave, int? KeyObservatorio, Boolean ConRelaciones){
        DataSet ds;
        if (KeyClave == null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            if (ConRelaciones==true)
                com.CommandText="sp_GetComplete_Detalle_de_Asistentes_de_Observatorio";
            else
                com.CommandText="sp_GetDetalle_de_Asistentes_de_Observatorio";
com.Parameters.AddWithValue("@Clave",KeyClave);com.Parameters.AddWithValue("@Observatorio",KeyObservatorio);

            com.CommandType=CommandType.StoredProcedure;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyClave(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion   from ((( Detalle_de_Asistentes_de_Observatorio       LEFT JOIN Observatorio ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)           Where Detalle_de_Asistentes_de_Observatorio.Clave = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyObservatorio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion   from ((( Detalle_de_Asistentes_de_Observatorio       LEFT JOIN Observatorio ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)           Where Detalle_de_Asistentes_de_Observatorio.Observatorio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyNombre(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion   from ((( Detalle_de_Asistentes_de_Observatorio       LEFT JOIN Observatorio ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)           Where Detalle_de_Asistentes_de_Observatorio.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyRol(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Detalle_de_Asistentes_de_Observatorio.Clave As Detalle_de_Asistentes_de_Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Observatorio AS Detalle_de_Asistentes_de_Observatorio_Observatorio,        Observatorio.Clave AS Observatorio_Clave,        Detalle_de_Asistentes_de_Observatorio.Nombre AS Detalle_de_Asistentes_de_Observatorio_Nombre,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre,        Detalle_de_Asistentes_de_Observatorio.Rol AS Detalle_de_Asistentes_de_Observatorio_Rol,        Rol_de_Usuario.Descripcion AS Rol_de_Usuario_Descripcion   from ((( Detalle_de_Asistentes_de_Observatorio       LEFT JOIN Observatorio ON Observatorio.Clave=Detalle_de_Asistentes_de_Observatorio.Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Detalle_de_Asistentes_de_Observatorio.Nombre)       LEFT JOIN Rol_de_Usuario ON Rol_de_Usuario.Clave=Detalle_de_Asistentes_de_Observatorio.Rol)           Where Detalle_de_Asistentes_de_Observatorio.Rol = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyClave, int? KeyObservatorio)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Detalle_de_Asistentes_de_Observatorio";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Detalle_de_Asistentes_de_Observatorio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Detalle_de_Asistentes_de_Observatorio_Clave"]) == KeyClave&& Function.FormatNumberNull(dt.Rows[i]["Detalle_de_Asistentes_de_Observatorio_Observatorio"]) == KeyObservatorio)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyClave, int? KeyObservatorio){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetDetalle_de_Asistentes_de_Observatorio";
com.Parameters.AddWithValue("@Clave",KeyClave);com.Parameters.AddWithValue("@Observatorio",KeyObservatorio);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataObservatorioControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataObservatorio(Object ctr, String Filtro){
            public DataTable FillDataObservatorio(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selDetalle_de_Asistentes_de_Observatorio_Relacion_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataObservatorioControl(ctr, dt);
                return dt;
            }
//            public void FillDataObservatorio(Object ctr){
            public DataTable FillDataObservatorio(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selDetalle_de_Asistentes_de_Observatorio_Relacion_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataObservatorioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataNombreControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Nombre";
                        ((ComboBox)ctr).ValueMember = "Folio";
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
                        ((ListBox)ctr).ValueMember = "Folio";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Folio";
                }
            }
*///            public DataTable FillDataNombre(Object ctr, String Filtro){
            public DataTable FillDataNombre(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selDetalle_de_Asistentes_de_Observatorio_Relacion_Registro_de_Roles";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataNombreControl(ctr, dt);
                return dt;
            }
//            public void FillDataNombre(Object ctr){
            public DataTable FillDataNombre(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selDetalle_de_Asistentes_de_Observatorio_Relacion_Registro_de_Roles";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataNombreControl(ctr, dt);
                return dt;
            }
/*            private void FillDataRolControl(Object ctr, DataTable dt){
                if (ctr.GetType() == typeof(ComboBox))
                {
                        ((ComboBox)ctr).DataSource = dt;
                        ((ComboBox)ctr).DisplayMember = "Descripcion";
                        ((ComboBox)ctr).ValueMember = "Clave";
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
                        ((ListBox)ctr).ValueMember = "Clave";
                        ((ListBox)ctr).ClearSelected();
                }
                else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
                {
                        ((DataGridViewComboBoxColumn)ctr).DataSource = dt;
                        ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                        ((DataGridViewComboBoxColumn)ctr).ValueMember = "Clave";
                }
            }
*///            public DataTable FillDataRol(Object ctr, String Filtro){
            public DataTable FillDataRol(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selDetalle_de_Asistentes_de_Observatorio_Relacion_Rol_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataRolControl(ctr, dt);
                return dt;
            }
//            public void FillDataRol(Object ctr){
            public DataTable FillDataRol(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selDetalle_de_Asistentes_de_Observatorio_Relacion_Rol_de_Usuario";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataRolControl(ctr, dt);
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
