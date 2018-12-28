using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace ObservatorioCS
{
    public class ObservatorioFilters
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
        private TTClassSpecials.FiltersTypes.String varNombre = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Nombre
        {
            get { return varNombre; }
            set { varNombre = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varIcono =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Icono{
            get { return varIcono; }
            set { varIcono = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varColor =new TTClassSpecials.FiltersTypes.Dependientes();
//        private ColorCS.ColorFilters[] varColor;
        public TTClassSpecials.FiltersTypes.Dependientes Color{
            get { return varColor; }
            set { varColor = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varTipo_de_Observatorio =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Tipo_de_ObservatorioCS.Tipo_de_ObservatorioFilters[] varTipo_de_Observatorio;
        public TTClassSpecials.FiltersTypes.Dependientes Tipo_de_Observatorio{
            get { return varTipo_de_Observatorio; }
            set { varTipo_de_Observatorio = value; }
        }
        private Detalle_de_Observatorio_PrivadoCS.Detalle_de_Observatorio_PrivadoFilters varCodigos =new Detalle_de_Observatorio_PrivadoCS.Detalle_de_Observatorio_PrivadoFilters();
        public Detalle_de_Observatorio_PrivadoCS.Detalle_de_Observatorio_PrivadoFilters Codigos{
            get { return varCodigos; }
            set { varCodigos = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varAdministrador =new TTClassSpecials.FiltersTypes.Dependientes();
//        private Registro_de_RolesCS.Registro_de_RolesFilters[] varAdministrador;
        public TTClassSpecials.FiltersTypes.Dependientes Administrador{
            get { return varAdministrador; }
            set { varAdministrador = value; }
        }
        private Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters varEquipo_de_Trabajo =new Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters();
        public Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters Equipo_de_Trabajo{
            get { return varEquipo_de_Trabajo; }
            set { varEquipo_de_Trabajo = value; }
        }

    }
public class objectBussinessObservatorio : IDisposable
{
    public int iProcess = 29984;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private ObservatorioFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varClave;
	private String varNombre;
	private int? varIcono;
	private int? varColor;
	private int? varTipo_de_Observatorio;
    private Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado[] varCodigos;
	private int? varAdministrador;
    private Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio[] varEquipo_de_Trabajo;


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

    public ObservatorioFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public ObservatorioFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new ObservatorioFilters[1];
            filters[0] = value;
        }
    }

    public int? Clave{
        get { return varClave;}
        set { varClave = value;}
    }
    public String Nombre{
        get { return varNombre;}
        set { varNombre = value;}
    }
    public int? Icono{
        get { return varIcono;}
        set { varIcono = value;}
    }
    public int? Color{
        get { return varColor;}
        set { varColor = value;}
    }
    public int? Tipo_de_Observatorio{
        get { return varTipo_de_Observatorio;}
        set { varTipo_de_Observatorio = value;}
    }
    public Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado[] Codigos{
        get { return varCodigos;}
        set { varCodigos = value;}
    }
    public int? Administrador{
        get { return varAdministrador;}
        set { varAdministrador = value;}
    }
    public Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio[] Equipo_de_Trabajo{
        get { return varEquipo_de_Trabajo;}
        set { varEquipo_de_Trabajo = value;}
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
            com.CommandText = "sp_SelAllComplete_Observatorio_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Observatorio";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (ObservatorioCS.ObservatorioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Observatorio", fil);
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
                com.CommandText = "sp_SelAllComplete_Observatorio_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Observatorio";
        else
            com.CommandText="sp_SelAllObservatorio";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (ObservatorioCS.ObservatorioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Observatorio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Observatorio", fil);
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
                  string from = " from (((( Observatorio WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Observatorio.Icono)       LEFT JOIN Color as Color WITH(NoLock) ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio as Tipo_de_Observatorio WITH(NoLock) ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles as Administrador WITH(NoLock) ON Administrador.Folio=Observatorio.Administrador)        " + swhere; 

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

                    switch (sortExpression)             {                 case "Observatorio_Clave": sortExpression = "Observatorio.Clave"; break;  case "Observatorio_Nombre": sortExpression = "Observatorio.Nombre"; break;  case "Observatorio_Icono": sortExpression = "Observatorio.Icono"; break;  case "Icono_Nombre": sortExpression = "Icono.Nombre"; break;  case "Observatorio_Color": sortExpression = "Observatorio.Color"; break;  case "Color_Descripcion": sortExpression = "Color.Descripcion"; break;  case "Observatorio_Tipo_de_Observatorio": sortExpression = "Observatorio.Tipo_de_Observatorio"; break;  case "Tipo_de_Observatorio_Descripcion": sortExpression = "Tipo_de_Observatorio.Descripcion"; break;  case "Observatorio_Administrador": sortExpression = "Observatorio.Administrador"; break;  case "Administrador_Nombre": sortExpression = "Administrador.Nombre"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Observatorio.Clave, Observatorio.Nombre, Observatorio.Icono, Icono.Nombre, Observatorio.Color, Color.Descripcion, Observatorio.Tipo_de_Observatorio, Tipo_de_Observatorio.Descripcion, Observatorio.Administrador, Administrador.Nombre" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        Icono.Nombre AS Icono_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Administrador.Nombre AS Administrador_Nombre ";             string fieldsForExport = " Observatorio.Clave As [Clave],        Observatorio.Nombre As [Nombre],        Observatorio.Icono AS [Icono],        Icono.Nombre AS [Icono Nombre],        Observatorio.Color AS [Color],        Color.Descripcion AS [Color Descripcion],        Observatorio.Tipo_de_Observatorio AS [Tipo de Observatorio],        Tipo_de_Observatorio.Descripcion AS [Tipo de Observatorio Descripcion],        Observatorio.Administrador AS [Administrador],        Administrador.Nombre AS [Administrador Nombre] ";             string from = " from (((( Observatorio WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Observatorio.Icono)       LEFT JOIN Color as Color WITH(NoLock) ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio as Tipo_de_Observatorio WITH(NoLock) ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles as Administrador WITH(NoLock) ON Administrador.Folio=Observatorio.Administrador)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        Icono.Nombre AS Icono_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Administrador.Nombre AS Administrador_Nombre ";         Order = (Order == string.Empty || Order == null ? "Observatorio.Clave, Observatorio.Nombre, Observatorio.Icono, Icono.Nombre, Observatorio.Color, Color.Descripcion, Observatorio.Tipo_de_Observatorio, Tipo_de_Observatorio.Descripcion, Observatorio.Administrador, Administrador.Nombre" : Order);         string from = " from (((( Observatorio WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Observatorio.Icono)       LEFT JOIN Color as Color WITH(NoLock) ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio as Tipo_de_Observatorio WITH(NoLock) ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles as Administrador WITH(NoLock) ON Administrador.Folio=Observatorio.Administrador)        " + swhere;
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

       	swhere = where; 	string fieldsWithAlias = " Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        Icono.Nombre AS Icono_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Administrador.Nombre AS Administrador_Nombre ";         Order = (Order == string.Empty || Order == null ? "Observatorio.Clave, Observatorio.Nombre, Observatorio.Icono, Icono.Nombre, Observatorio.Color, Color.Descripcion, Observatorio.Tipo_de_Observatorio, Tipo_de_Observatorio.Descripcion, Observatorio.Administrador, Administrador.Nombre" : Order);         string from = " from (((( Observatorio WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Observatorio.Icono)       LEFT JOIN Color as Color WITH(NoLock) ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio as Tipo_de_Observatorio WITH(NoLock) ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles as Administrador WITH(NoLock) ON Administrador.Folio=Observatorio.Administrador)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        Icono.Nombre AS Icono_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Administrador.Nombre AS Administrador_Nombre ";         Order = (Order == string.Empty || Order == null ? "Observatorio.Clave, Observatorio.Nombre, Observatorio.Icono, Icono.Nombre, Observatorio.Color, Color.Descripcion, Observatorio.Tipo_de_Observatorio, Tipo_de_Observatorio.Descripcion, Observatorio.Administrador, Administrador.Nombre" : Order);         string from = " from (((( Observatorio WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Observatorio.Icono)       LEFT JOIN Color as Color WITH(NoLock) ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio as Tipo_de_Observatorio WITH(NoLock) ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles as Administrador WITH(NoLock) ON Administrador.Folio=Observatorio.Administrador)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        Icono.Nombre AS Icono_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Administrador.Nombre AS Administrador_Nombre ";         Order = (Order == string.Empty || Order == null ? "Observatorio.Clave, Observatorio.Nombre, Observatorio.Icono, Icono.Nombre, Observatorio.Color, Color.Descripcion, Observatorio.Tipo_de_Observatorio, Tipo_de_Observatorio.Descripcion, Observatorio.Administrador, Administrador.Nombre" : Order);         string from = " from (((( Observatorio WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Observatorio.Icono)       LEFT JOIN Color as Color WITH(NoLock) ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio as Tipo_de_Observatorio WITH(NoLock) ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles as Administrador WITH(NoLock) ON Administrador.Folio=Observatorio.Administrador)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_Observatorio_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Observatorio";
        else
            com.CommandText="sp_SelAllObservatorio";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (ObservatorioCS.ObservatorioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Observatorio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Observatorio", fil);
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

        db.BeginTransaction("Observatorio");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsObservatorio";
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
            }            com.Parameters.AddWithValue("@Icono",Conversion.FormatNull(varIcono));
            com.Parameters.AddWithValue("@Color",Conversion.FormatNull(varColor));
            com.Parameters.AddWithValue("@Tipo_de_Observatorio",Conversion.FormatNull(varTipo_de_Observatorio));
            com.Parameters.AddWithValue("@Administrador",Conversion.FormatNull(varAdministrador));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varClave = sKeyClave;
            
            if(varCodigos != null)
            {
                for (int i = 0;i< varCodigos.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Observatorio_Privado";
                    com.Parameters.AddWithValue("@Observatorio", sKeyClave);
            if (varCodigos[i].Codigo!=null)
            {
                if (varCodigos[i].Codigo != "")
                    com.Parameters.AddWithValue("@Codigo", Convierte(varCodigos[i].Codigo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }                com.Parameters.AddWithValue("@Estatus", Conversion.FormatNull(varCodigos[i].Estatus));
                com.Parameters.AddWithValue("@Expiracion", Conversion.FormatNull(varCodigos[i].Expiracion));
                com.Parameters.AddWithValue("@Accesos", Conversion.FormatNull(varCodigos[i].Accesos));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varEquipo_de_Trabajo != null)
            {
                for (int i = 0;i< varEquipo_de_Trabajo.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Asistentes_de_Observatorio";
                    com.Parameters.AddWithValue("@Observatorio", sKeyClave);
                com.Parameters.AddWithValue("@Nombre", Conversion.FormatNull(varEquipo_de_Trabajo[i].Nombre));
                com.Parameters.AddWithValue("@Rol", Conversion.FormatNull(varEquipo_de_Trabajo[i].Rol));

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
                db.RollBackTransaction("Observatorio");
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

        db.BeginTransaction("Observatorio");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsObservatorio";
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
            }            com.Parameters.AddWithValue("@Icono",Conversion.FormatNull(varIcono));
            com.Parameters.AddWithValue("@Color",Conversion.FormatNull(varColor));
            com.Parameters.AddWithValue("@Tipo_de_Observatorio",Conversion.FormatNull(varTipo_de_Observatorio));
            com.Parameters.AddWithValue("@Administrador",Conversion.FormatNull(varAdministrador));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varClave = sKeyClave;
            
            if(varCodigos != null)
            {
                for (int i = 0;i< varCodigos.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Observatorio_Privado";
                    com.Parameters.AddWithValue("@Observatorio", sKeyClave);
            if (varCodigos[i].Codigo!=null)
            {
                if (varCodigos[i].Codigo != "")
                    com.Parameters.AddWithValue("@Codigo", Convierte(varCodigos[i].Codigo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }                com.Parameters.AddWithValue("@Estatus", Conversion.FormatNull(varCodigos[i].Estatus));
                com.Parameters.AddWithValue("@Expiracion", Conversion.FormatNull(varCodigos[i].Expiracion));
                com.Parameters.AddWithValue("@Accesos", Conversion.FormatNull(varCodigos[i].Accesos));

                    com.CommandType = CommandType.StoredProcedure;
                    db.EjecutaInsert(com, UserInformation, DataReference);
                }
            }
            if(varEquipo_de_Trabajo != null)
            {
                for (int i = 0;i< varEquipo_de_Trabajo.Length; i++)
                {
                    com = new SqlCommand();
                    com.CommandText = "sp_InsDetalle_de_Asistentes_de_Observatorio";
                    com.Parameters.AddWithValue("@Observatorio", sKeyClave);
                com.Parameters.AddWithValue("@Nombre", Conversion.FormatNull(varEquipo_de_Trabajo[i].Nombre));
                com.Parameters.AddWithValue("@Rol", Conversion.FormatNull(varEquipo_de_Trabajo[i].Rol));

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
                db.RollBackTransaction("Observatorio");
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

        db.BeginTransaction("Observatorio");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdObservatorio";
            com.Parameters.AddWithValue("@Clave",Conversion.FormatNull(varClave));
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
            }            com.Parameters.AddWithValue("@Icono",Conversion.FormatNull(varIcono));
            com.Parameters.AddWithValue("@Color",Conversion.FormatNull(varColor));
            com.Parameters.AddWithValue("@Tipo_de_Observatorio",Conversion.FormatNull(varTipo_de_Observatorio));
            com.Parameters.AddWithValue("@Administrador",Conversion.FormatNull(varAdministrador));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varClave = sKeyClave;
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyClave.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Clave from Detalle_de_Observatorio_Privado Where Observatorio = '" + sKeyClave.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varCodigos != null)
            {
                for (int i = 0;i< varCodigos.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varCodigos[i].Clave.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@Observatorio", sKeyClave);
            if (varCodigos[i].Codigo!=null)
            {
                if (varCodigos[i].Codigo != "")
                    com.Parameters.AddWithValue("@Codigo", Convierte(varCodigos[i].Codigo, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Codigo", DBNull.Value);
            }                com.Parameters.AddWithValue("@Estatus", Conversion.FormatNull(varCodigos[i].Estatus));
                com.Parameters.AddWithValue("@Expiracion", Conversion.FormatNull(varCodigos[i].Expiracion));
                com.Parameters.AddWithValue("@Accesos", Conversion.FormatNull(varCodigos[i].Accesos));

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsDetalle_de_Observatorio_Privado";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdDetalle_de_Observatorio_Privado";
                        com.Parameters.AddWithValue("@Clave", varCodigos[i].Clave);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varCodigos[i].Clave);
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
                db.EjecutaDelete(new SqlCommand("Delete from Detalle_de_Observatorio_Privado " + FiltroDelete), UserInformation, DataReference);
            }
        }
        //TODO Falta Saber como borrar los campos
        {
            DataReference.Folio = sKeyClave.ToString();
            TTDataLayerCS.BD dbMulti = new TTDataLayerCS.BD();
            DataTable drs = dbMulti.Consulta(new SqlCommand("Select Clave from Detalle_de_Asistentes_de_Observatorio Where Observatorio = '" + sKeyClave.ToString() + "'")).Tables[0];
            System.Collections.ArrayList arrRegistry = new System.Collections.ArrayList();
            if(varEquipo_de_Trabajo != null)
            {
                for (int i = 0;i< varEquipo_de_Trabajo.Length; i++)
                {
                    Boolean existe = false;
                    foreach(DataRow dr in drs.Rows)
                    {
                        if (varEquipo_de_Trabajo[i].Clave.ToString() == dr[0].ToString())
                        {
                            existe = true;
                            break;
                        }
                    }
                    com = new SqlCommand();
                    com.Parameters.AddWithValue("@Observatorio", sKeyClave);
                com.Parameters.AddWithValue("@Nombre", Conversion.FormatNull(varEquipo_de_Trabajo[i].Nombre));
                com.Parameters.AddWithValue("@Rol", Conversion.FormatNull(varEquipo_de_Trabajo[i].Rol));

                    com.CommandType = CommandType.StoredProcedure;
                    if (!existe) //Insert 
                    {
                        com.CommandText = "sp_InsDetalle_de_Asistentes_de_Observatorio";
                        arrRegistry.Add(db.EjecutaInsert(com, UserInformation, DataReference));
                    }
                    else
                    {
                        com.CommandText = "sp_UpdDetalle_de_Asistentes_de_Observatorio";
                        com.Parameters.AddWithValue("@Clave", varEquipo_de_Trabajo[i].Clave);
                        db.EjecutaInsert(com, UserInformation, DataReference);
                        arrRegistry.Add(varEquipo_de_Trabajo[i].Clave);
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
                db.EjecutaDelete(new SqlCommand("Delete from Detalle_de_Asistentes_de_Observatorio " + FiltroDelete), UserInformation, DataReference);
            }
        }


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Observatorio");
            }
            catch{}
            throw ex; 
        }
    }

    public bool Delete(int? KeyClave, TTSecurity.GlobalData UserInformation, TTDataLayerCS.DataLayerFieldsBitacora DataReference){
            Boolean result;
            string Error = "";
            DataReference.Folio =  KeyClave.ToString();
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            db.BeginTransaction("Observatorio");
            try
            {
                DataReference.Folio = KeyClave.ToString();
                TTDataLayerCS.BD dbDetalle_de_Observatorio_Privado = new TTDataLayerCS.BD();
                DataSet recordsDetalle_de_Observatorio_Privado = dbDetalle_de_Observatorio_Privado.Consulta(new SqlCommand("Select Count(*) From Detalle_de_Observatorio_Privado Where Observatorio = '" + KeyClave.ToString() + "'"));
                if (recordsDetalle_de_Observatorio_Privado.Tables.Count > 0)
                    if (recordsDetalle_de_Observatorio_Privado.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsDetalle_de_Observatorio_Privado = int.Parse(recordsDetalle_de_Observatorio_Privado.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsDetalle_de_Observatorio_Privado > 0)
                            Error = Error + "- Detalle de Observatorio Privado \r\n"; 
                    }
                dbDetalle_de_Observatorio_Privado.Disconnect();                DataReference.Folio = KeyClave.ToString();
                TTDataLayerCS.BD dbDetalle_de_Asistentes_de_Observatorio = new TTDataLayerCS.BD();
                DataSet recordsDetalle_de_Asistentes_de_Observatorio = dbDetalle_de_Asistentes_de_Observatorio.Consulta(new SqlCommand("Select Count(*) From Detalle_de_Asistentes_de_Observatorio Where Observatorio = '" + KeyClave.ToString() + "'"));
                if (recordsDetalle_de_Asistentes_de_Observatorio.Tables.Count > 0)
                    if (recordsDetalle_de_Asistentes_de_Observatorio.Tables[0].Rows.Count > 0)
                    {
                        int totalrecordsDetalle_de_Asistentes_de_Observatorio = int.Parse(recordsDetalle_de_Asistentes_de_Observatorio.Tables[0].Rows[0][0].ToString());
                        if (totalrecordsDetalle_de_Asistentes_de_Observatorio > 0)
                            Error = Error + "- Detalle de Asistentes de Observatorio \r\n"; 
                    }
                dbDetalle_de_Asistentes_de_Observatorio.Disconnect();

                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelObservatorio";
com.Parameters.AddWithValue("@Clave",KeyClave);
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
                    db.RollBackTransaction("Observatorio");
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
            Clave = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Observatorio_Clave"]);
            Nombre = ds.Tables[0].Rows[0]["Observatorio_Nombre"].ToString();
            Icono = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Observatorio_Icono"]);
            Color = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Observatorio_Color"]);
            Tipo_de_Observatorio = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Observatorio_Tipo_de_Observatorio"]);
            Administrador = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Observatorio_Administrador"]);

                {
                    Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado MyDataCodigos = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
                    Detalle_de_Observatorio_PrivadoCS.Detalle_de_Observatorio_PrivadoFilters MyDataFilterCodigos = new Detalle_de_Observatorio_PrivadoCS.Detalle_de_Observatorio_PrivadoFilters();
                    MyDataFilterCodigos.Observatorio.List = new String[1];
                    MyDataFilterCodigos.Observatorio.List[0] = Clave.Value.ToString();
                    MyDataCodigos.Filters = new Detalle_de_Observatorio_PrivadoCS.Detalle_de_Observatorio_PrivadoFilters[1];
                    MyDataCodigos.Filters[0] = MyDataFilterCodigos;
                    DataSet dsMulti = MyDataCodigos.SelAll(true);
                    Codigos = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Codigos[i] = new Detalle_de_Observatorio_PrivadoCS.objectBussinessDetalle_de_Observatorio_Privado();
                    Codigos[i].Clave = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Observatorio_Privado_Clave"]);
                    Codigos[i].Observatorio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Observatorio_Privado_Observatorio"]);
                    Codigos[i].Codigo = dsMulti.Tables[0].Rows[i]["Detalle_de_Observatorio_Privado_Codigo"].ToString().TrimEnd(' ');
                    Codigos[i].Estatus = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Observatorio_Privado_Estatus"]);
                    Codigos[i].Expiracion = Conversion.CambiaToDatetime (dsMulti.Tables[0].Rows[i]["Detalle_de_Observatorio_Privado_Expiracion"]);
                    Codigos[i].Accesos = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Observatorio_Privado_Accesos"]);

                    }
               }    
                {
                    Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio MyDataEquipo_de_Trabajo = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
                    Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters MyDataFilterEquipo_de_Trabajo = new Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters();
                    MyDataFilterEquipo_de_Trabajo.Observatorio.List = new String[1];
                    MyDataFilterEquipo_de_Trabajo.Observatorio.List[0] = Clave.Value.ToString();
                    MyDataEquipo_de_Trabajo.Filters = new Detalle_de_Asistentes_de_ObservatorioCS.Detalle_de_Asistentes_de_ObservatorioFilters[1];
                    MyDataEquipo_de_Trabajo.Filters[0] = MyDataFilterEquipo_de_Trabajo;
                    DataSet dsMulti = MyDataEquipo_de_Trabajo.SelAll(true);
                    Equipo_de_Trabajo = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio[dsMulti.Tables[0].Rows.Count];
                    for (int i =0;i<dsMulti.Tables[0].Rows.Count;i++)
                    {
                        Equipo_de_Trabajo[i] = new Detalle_de_Asistentes_de_ObservatorioCS.objectBussinessDetalle_de_Asistentes_de_Observatorio();
                    Equipo_de_Trabajo[i].Clave = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Asistentes_de_Observatorio_Clave"]);
                    Equipo_de_Trabajo[i].Observatorio = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Asistentes_de_Observatorio_Observatorio"]);
                    Equipo_de_Trabajo[i].Nombre = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Asistentes_de_Observatorio_Nombre"]);
                    Equipo_de_Trabajo[i].Rol = Conversion.CambiaToShort(dsMulti.Tables[0].Rows[i]["Detalle_de_Asistentes_de_Observatorio_Rol"]);

                    }
               }    


            }
        return ds;
    }
    public DataSet GetByKey(int? KeyClave, Boolean ConRelaciones){
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
                com.CommandText="sp_GetComplete_Observatorio";
            else
                com.CommandText="sp_GetObservatorio";
com.Parameters.AddWithValue("@Clave",KeyClave);

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
            com.CommandText="Select         Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre   from (((( Observatorio       LEFT JOIN TTArchivos ON TTArchivos.Folio=Observatorio.Icono)       LEFT JOIN Color ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Observatorio.Administrador)           Where Observatorio.Clave = '" + Key + "'";
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
            com.CommandText="Select         Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre   from (((( Observatorio       LEFT JOIN TTArchivos ON TTArchivos.Folio=Observatorio.Icono)       LEFT JOIN Color ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Observatorio.Administrador)           Where Observatorio.Nombre = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyIcono(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre   from (((( Observatorio       LEFT JOIN TTArchivos ON TTArchivos.Folio=Observatorio.Icono)       LEFT JOIN Color ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Observatorio.Administrador)           Where Observatorio.Icono = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyColor(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre   from (((( Observatorio       LEFT JOIN TTArchivos ON TTArchivos.Folio=Observatorio.Icono)       LEFT JOIN Color ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Observatorio.Administrador)           Where Observatorio.Color = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyTipo_de_Observatorio(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre   from (((( Observatorio       LEFT JOIN TTArchivos ON TTArchivos.Folio=Observatorio.Icono)       LEFT JOIN Color ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Observatorio.Administrador)           Where Observatorio.Tipo_de_Observatorio = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyAdministrador(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Observatorio.Clave As Observatorio_Clave,        Observatorio.Nombre As Observatorio_Nombre,        Observatorio.Icono AS Observatorio_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Observatorio.Color AS Observatorio_Color,        Color.Descripcion AS Color_Descripcion,        Observatorio.Tipo_de_Observatorio AS Observatorio_Tipo_de_Observatorio,        Tipo_de_Observatorio.Descripcion AS Tipo_de_Observatorio_Descripcion,        Observatorio.Administrador AS Observatorio_Administrador,        Registro_de_Roles.Nombre AS Registro_de_Roles_Nombre   from (((( Observatorio       LEFT JOIN TTArchivos ON TTArchivos.Folio=Observatorio.Icono)       LEFT JOIN Color ON Color.Clave=Observatorio.Color)       LEFT JOIN Tipo_de_Observatorio ON Tipo_de_Observatorio.Clave=Observatorio.Tipo_de_Observatorio)       LEFT JOIN Registro_de_Roles ON Registro_de_Roles.Folio=Observatorio.Administrador)           Where Observatorio.Administrador = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyClave)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Observatorio";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (ObservatorioCS.ObservatorioFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Observatorio", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Observatorio_Clave"]) == KeyClave)
                return i;
        }
        return -1;
    }
    public Boolean ValidaExistencia(int? KeyClave){
        Boolean result;
        DataSet ds;
//        if (Key == null ){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
//            return false;
//        }
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_GetObservatorio";
com.Parameters.AddWithValue("@Clave",KeyClave);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataColorControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataColor(Object ctr, String Filtro){
            public DataTable FillDataColor(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Color";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataColorControl(ctr, dt);
                return dt;
            }
//            public void FillDataColor(Object ctr){
            public DataTable FillDataColor(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Color";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataColorControl(ctr, dt);
                return dt;
            }
/*            private void FillDataTipo_de_ObservatorioControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataTipo_de_Observatorio(Object ctr, String Filtro){
            public DataTable FillDataTipo_de_Observatorio(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Tipo_de_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataTipo_de_ObservatorioControl(ctr, dt);
                return dt;
            }
//            public void FillDataTipo_de_Observatorio(Object ctr){
            public DataTable FillDataTipo_de_Observatorio(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Tipo_de_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataTipo_de_ObservatorioControl(ctr, dt);
                return dt;
            }
/*            private void FillDataCodigosControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataCodigos(Object ctr, String Filtro){
            public DataTable FillDataCodigos(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Detalle_de_Observatorio_Privado";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataCodigosControl(ctr, dt);
                return dt;
            }
//            public void FillDataCodigos(Object ctr){
            public DataTable FillDataCodigos(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Detalle_de_Observatorio_Privado";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataCodigosControl(ctr, dt);
                return dt;
            }
/*            private void FillDataAdministradorControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataAdministrador(Object ctr, String Filtro){
            public DataTable FillDataAdministrador(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Registro_de_Roles";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataAdministradorControl(ctr, dt);
                return dt;
            }
//            public void FillDataAdministrador(Object ctr){
            public DataTable FillDataAdministrador(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Registro_de_Roles";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataAdministradorControl(ctr, dt);
                return dt;
            }
/*            private void FillDataEquipo_de_TrabajoControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataEquipo_de_Trabajo(Object ctr, String Filtro){
            public DataTable FillDataEquipo_de_Trabajo(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Detalle_de_Asistentes_de_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataEquipo_de_TrabajoControl(ctr, dt);
                return dt;
            }
//            public void FillDataEquipo_de_Trabajo(Object ctr){
            public DataTable FillDataEquipo_de_Trabajo(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selObservatorio_Relacion_Detalle_de_Asistentes_de_Observatorio";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataEquipo_de_TrabajoControl(ctr, dt);
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
