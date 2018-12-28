﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace CategoriaCS
{
    public class CategoriaFilters
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
        private TTClassSpecials.FiltersTypes.String varDescripcion = new TTClassSpecials.FiltersTypes.String();
        public TTClassSpecials.FiltersTypes.String Descripcion
        {
            get { return varDescripcion; }
            set { varDescripcion = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varIcono =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Icono{
            get { return varIcono; }
            set { varIcono = value; }
        }
        private TTClassSpecials.FiltersTypes.Dependientes varColor_Franja =new TTClassSpecials.FiltersTypes.Dependientes();
//        private ColorCS.ColorFilters[] varColor_Franja;
        public TTClassSpecials.FiltersTypes.Dependientes Color_Franja{
            get { return varColor_Franja; }
            set { varColor_Franja = value; }
        }
        private TTClassSpecials.FiltersTypes.Numeric  varImagen =new TTClassSpecials.FiltersTypes.Numeric();
        public TTClassSpecials.FiltersTypes.Numeric Imagen{
            get { return varImagen; }
            set { varImagen = value; }
        }

    }
public class objectBussinessCategoria : IDisposable
{
    public int iProcess = 29983;
    private TTFunctions.Functions Function = new TTFunctions.Functions();
    private TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
    private CategoriaFilters[] filters; 
    private ControlsLibrary.objectBussinessTTFiltro[] myFilters;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumns;
    private ControlsLibrary.objectBussinessTTFiltro[] myFiltersObligatories;
    private ControlsLibrary.objectBussinessTTConfigurationAdvancedColumn[] myConfigurationColumnsObligatories;
    private ControlsLibrary.objectBussinessTTFiltro myFiltersQuick;
	private int? varClave;
	private String varDescripcion;
	private int? varIcono;
	private int? varColor_Franja;
	private int? varImagen;


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

    public CategoriaFilters[] Filters
    {
        get { return filters; }
        set { filters = value; }
    }
    public CategoriaFilters Filter
    {
        ///Cuando es llamada desde las relaciones de algun catalago
        set
        {
            filters = new CategoriaFilters[1];
            filters[0] = value;
        }
    }

    public int? Clave{
        get { return varClave;}
        set { varClave = value;}
    }
    public String Descripcion{
        get { return varDescripcion;}
        set { varDescripcion = value;}
    }
    public int? Icono{
        get { return varIcono;}
        set { varIcono = value;}
    }
    public int? Color_Franja{
        get { return varColor_Franja;}
        set { varColor_Franja = value;}
    }
    public int? Imagen{
        get { return varImagen;}
        set { varImagen = value;}
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
            com.CommandText = "sp_SelAllComplete_Categoria_WithFilter";
        }else 
            com.CommandText = "sp_SelAllComplete_Categoria";

            ds = db.Consulta(com);
            swhere = "";


            if (this.filters !=null)
                foreach (CategoriaCS.CategoriaFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Categoria", fil);
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
                com.CommandText = "sp_SelAllComplete_Categoria_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Categoria";
        else
            com.CommandText="sp_SelAllCategoria";
            ds = db.Consulta(com);

        swhere = "";
            if (this.filters !=null)
                foreach (CategoriaCS.CategoriaFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Categoria", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Categoria", fil);
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
                  string from = " from ((( Categoria WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Categoria.Icono)       LEFT JOIN Color as Color_Franja WITH(NoLock) ON Color_Franja.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Categoria.Imagen)        " + swhere; 

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

                    switch (sortExpression)             {                 case "Categoria_Clave": sortExpression = "Categoria.Clave"; break;  case "Categoria_Descripcion": sortExpression = "Categoria.Descripcion"; break;  case "Categoria_Icono": sortExpression = "Categoria.Icono"; break;  case "Icono_Nombre": sortExpression = "Icono.Nombre"; break;  case "Categoria_Color_Franja": sortExpression = "Categoria.Color_Franja"; break;  case "Color_Franja_Descripcion": sortExpression = "Color_Franja.Descripcion"; break;  case "Categoria_Imagen": sortExpression = "Categoria.Imagen"; break;  case "Imagen_Nombre": sortExpression = "Imagen.Nombre"; break;                               }              sortExpression = (sortExpression == string.Empty || sortExpression == null ? "Categoria.Clave, Categoria.Descripcion, Categoria.Icono, Icono.Nombre, Categoria.Color_Franja, Color_Franja.Descripcion, Categoria.Imagen, Imagen.Nombre" : sortExpression);             if (sortDirection != string.Empty)                 sortDirection = (sortDirection.ToLower() == "ascending" ? "Asc" : "Desc");             string fieldsWithAlias = " Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        Icono.Nombre AS Icono_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color_Franja.Descripcion AS Color_Franja_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        Imagen.Nombre AS Imagen_Nombre ";             string fieldsForExport = " Categoria.Clave As [Clave],        Categoria.Descripcion As [Descripcion],        Categoria.Icono AS [Icono],        Icono.Nombre AS [Icono Nombre],        Categoria.Color_Franja AS [Color Franja],        Color_Franja.Descripcion AS [Color Franja Descripcion],        Categoria.Imagen AS [Imagen],        Imagen.Nombre AS [Imagen Nombre] ";             string from = " from ((( Categoria WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Categoria.Icono)       LEFT JOIN Color as Color_Franja WITH(NoLock) ON Color_Franja.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Categoria.Imagen)        " + swhere; 

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
        	swhere = where; 	string fieldsWithAlias = " Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        Icono.Nombre AS Icono_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color_Franja.Descripcion AS Color_Franja_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        Imagen.Nombre AS Imagen_Nombre ";         Order = (Order == string.Empty || Order == null ? "Categoria.Clave, Categoria.Descripcion, Categoria.Icono, Icono.Nombre, Categoria.Color_Franja, Color_Franja.Descripcion, Categoria.Imagen, Imagen.Nombre" : Order);         string from = " from ((( Categoria WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Categoria.Icono)       LEFT JOIN Color as Color_Franja WITH(NoLock) ON Color_Franja.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Categoria.Imagen)        " + swhere;
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

       	swhere = where; 	string fieldsWithAlias = " Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        Icono.Nombre AS Icono_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color_Franja.Descripcion AS Color_Franja_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        Imagen.Nombre AS Imagen_Nombre ";         Order = (Order == string.Empty || Order == null ? "Categoria.Clave, Categoria.Descripcion, Categoria.Icono, Icono.Nombre, Categoria.Color_Franja, Color_Franja.Descripcion, Categoria.Imagen, Imagen.Nombre" : Order);         string from = " from ((( Categoria WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Categoria.Icono)       LEFT JOIN Color as Color_Franja WITH(NoLock) ON Color_Franja.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Categoria.Imagen)        " + swhere;

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

        	swhere = where; 	string fieldsWithAlias = " Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        Icono.Nombre AS Icono_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color_Franja.Descripcion AS Color_Franja_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        Imagen.Nombre AS Imagen_Nombre ";         Order = (Order == string.Empty || Order == null ? "Categoria.Clave, Categoria.Descripcion, Categoria.Icono, Icono.Nombre, Categoria.Color_Franja, Color_Franja.Descripcion, Categoria.Imagen, Imagen.Nombre" : Order);         string from = " from ((( Categoria WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Categoria.Icono)       LEFT JOIN Color as Color_Franja WITH(NoLock) ON Color_Franja.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Categoria.Imagen)        " + swhere;

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
        	swhere = where; 	string fieldsWithAlias = " Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        Icono.Nombre AS Icono_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color_Franja.Descripcion AS Color_Franja_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        Imagen.Nombre AS Imagen_Nombre ";         Order = (Order == string.Empty || Order == null ? "Categoria.Clave, Categoria.Descripcion, Categoria.Icono, Icono.Nombre, Categoria.Color_Franja, Color_Franja.Descripcion, Categoria.Imagen, Imagen.Nombre" : Order);         string from = " from ((( Categoria WITH(NoLock) LEFT JOIN TTArchivos as Icono WITH(NoLock) ON Icono.Folio=Categoria.Icono)       LEFT JOIN Color as Color_Franja WITH(NoLock) ON Color_Franja.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as Imagen WITH(NoLock) ON Imagen.Folio=Categoria.Imagen)        " + swhere;

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
                com.CommandText = "sp_SelAllComplete_Categoria_WithFilter";
            }else 
                com.CommandText = "sp_SelAllComplete_Categoria";
        else
            com.CommandText="sp_SelAllCategoria";
            ds = db.Consulta(com);

        swhere = "";

            if (this.filters !=null)
                foreach (CategoriaCS.CategoriaFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Categoria", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And "+sWhereT;
                    String sOrderByT = "";
                    sOrderByT = Function.CreateOrderBySelect("Categoria", fil);
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

        db.BeginTransaction("Categoria");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsCategoria";
            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            com.Parameters.AddWithValue("@Icono",Conversion.FormatNull(varIcono));
            com.Parameters.AddWithValue("@Color_Franja",Conversion.FormatNull(varColor_Franja));
            com.Parameters.AddWithValue("@Imagen",Conversion.FormatNull(varImagen));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varClave = sKeyClave;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Categoria");
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

        db.BeginTransaction("Categoria");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_InsCategoria";
            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            com.Parameters.AddWithValue("@Icono",Conversion.FormatNull(varIcono));
            com.Parameters.AddWithValue("@Color_Franja",Conversion.FormatNull(varColor_Franja));
            com.Parameters.AddWithValue("@Imagen",Conversion.FormatNull(varImagen));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaInsert(com, UserInformation, DataReference));
            varClave = sKeyClave;
            


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Categoria");
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

        db.BeginTransaction("Categoria");
        int? sKeyClave = -1;
        try
        {

            SqlCommand com = new SqlCommand();
            com.CommandText="sp_UpdCategoria";
            com.Parameters.AddWithValue("@Clave",Conversion.FormatNull(varClave));
            if (varDescripcion!=null)
            {
                if (varDescripcion != "")
                    com.Parameters.AddWithValue("@Descripcion", Convierte(varDescripcion, ConvierteAMayusculas));
                else
                    com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }
            else
            {
                com.Parameters.AddWithValue("@Descripcion", DBNull.Value);
            }            com.Parameters.AddWithValue("@Icono",Conversion.FormatNull(varIcono));
            com.Parameters.AddWithValue("@Color_Franja",Conversion.FormatNull(varColor_Franja));
            com.Parameters.AddWithValue("@Imagen",Conversion.FormatNull(varImagen));

            com.CommandType =CommandType.StoredProcedure;
            sKeyClave = Function.FormatNumberNull( db.EjecutaUpdate(com, UserInformation, DataReference));
//            varClave = sKeyClave;


            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            try
            {
                db.RollBackTransaction("Categoria");
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
            db.BeginTransaction("Categoria");
            try
            {


                if (Error != "")
                {
                    throw new Exception("No es posible borrar el registro ya que tiene información relacionada con: \r\n" + Error + " \r\nFavor de borrar la información relacionada antes de borrar este registro.");
                }
                SqlCommand com = new SqlCommand();
                com.CommandText="sp_DelCategoria";
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
                    db.RollBackTransaction("Categoria");
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
            Clave = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Categoria_Clave"]);
            Descripcion = ds.Tables[0].Rows[0]["Categoria_Descripcion"].ToString();
            Icono = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Categoria_Icono"]);
            Color_Franja = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Categoria_Color_Franja"]);
            Imagen = Conversion.CambiaToShort(ds.Tables[0].Rows[0]["Categoria_Imagen"]);



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
                com.CommandText="sp_GetComplete_Categoria";
            else
                com.CommandText="sp_GetCategoria";
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
            com.CommandText="Select         Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color.Descripcion AS Color_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        TTArchivos1.Nombre AS TTArchivos1_Nombre   from ((( Categoria       LEFT JOIN TTArchivos ON TTArchivos.Folio=Categoria.Icono)       LEFT JOIN Color ON Color.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Categoria.Imagen)           Where Categoria.Clave = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyDescripcion(String Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color.Descripcion AS Color_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        TTArchivos1.Nombre AS TTArchivos1_Nombre   from ((( Categoria       LEFT JOIN TTArchivos ON TTArchivos.Folio=Categoria.Icono)       LEFT JOIN Color ON Color.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Categoria.Imagen)           Where Categoria.Descripcion = '" + Key + "'";
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
            com.CommandText="Select         Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color.Descripcion AS Color_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        TTArchivos1.Nombre AS TTArchivos1_Nombre   from ((( Categoria       LEFT JOIN TTArchivos ON TTArchivos.Folio=Categoria.Icono)       LEFT JOIN Color ON Color.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Categoria.Imagen)           Where Categoria.Icono = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyColor_Franja(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color.Descripcion AS Color_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        TTArchivos1.Nombre AS TTArchivos1_Nombre   from ((( Categoria       LEFT JOIN TTArchivos ON TTArchivos.Folio=Categoria.Icono)       LEFT JOIN Color ON Color.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Categoria.Imagen)           Where Categoria.Color_Franja = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }
    public DataSet GetByKeyImagen(int? Key){
        DataSet ds;
        if (Key==null){
//            //MessageBox.Show("Para poder obtener los registros debe proporcionar la llave","Obtener Empleado",MessageBoxButtons.OK,MessageBoxIcon.Error);
            return null;
        }
//        else
//        {
            TTDataLayerCS.BD db =new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandText="Select         Categoria.Clave As Categoria_Clave,        Categoria.Descripcion As Categoria_Descripcion,        Categoria.Icono AS Categoria_Icono,        TTArchivos.Nombre AS TTArchivos_Nombre,        Categoria.Color_Franja AS Categoria_Color_Franja,        Color.Descripcion AS Color_Descripcion,        Categoria.Imagen AS Categoria_Imagen,        TTArchivos1.Nombre AS TTArchivos1_Nombre   from ((( Categoria       LEFT JOIN TTArchivos ON TTArchivos.Folio=Categoria.Icono)       LEFT JOIN Color ON Color.Clave=Categoria.Color_Franja)       LEFT JOIN TTArchivos as TTArchivos1 ON TTArchivos1.Folio=Categoria.Imagen)           Where Categoria.Imagen = '" + Key + "'";
            com.CommandType=CommandType.Text;
            ds = db.Consulta(com);
            return GetByKey(ds);
        //}
    }

    public Int32 CurrentPosicion(int? KeyClave)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandText = "sp_SelAllComplete_Categoria";
        com.CommandType = CommandType.StoredProcedure;
        DataTable dt = db.Consulta(com).Tables[0];
            string swhere = "";
            if (this.filters !=null)
                foreach (CategoriaCS.CategoriaFilters fil in this.filters)
                {
                    String sWhereT = "";
                    sWhereT = Function.CreateQuerySelect("Categoria", fil);
                    if (sWhereT != "")
                        swhere = swhere + " And " + sWhereT;
                }
            if (swhere != "")
                swhere = swhere.Substring(4);
            dt = Function.SelectDataTable(dt, swhere, "");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Function.FormatNumberNull(dt.Rows[i]["Categoria_Clave"]) == KeyClave)
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
        com.CommandText = "sp_GetCategoria";
com.Parameters.AddWithValue("@Clave",KeyClave);
        com.CommandType = CommandType.StoredProcedure;
        ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count == 0)
            result = false;
        else
            result = true;
        return result;
    }

/*            private void FillDataColor_FranjaControl(Object ctr, DataTable dt){
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
*///            public DataTable FillDataColor_Franja(Object ctr, String Filtro){
            public DataTable FillDataColor_Franja(String Filtro){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selCategoria_Relacion_Color";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                DataView d = new DataView(dt, Filtro, "", DataViewRowState.CurrentRows);
                dt= d.ToTable();
                //FillDataColor_FranjaControl(ctr, dt);
                return dt;
            }
//            public void FillDataColor_Franja(Object ctr){
            public DataTable FillDataColor_Franja(){
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_selCategoria_Relacion_Color";
                com.CommandType = CommandType.StoredProcedure;
                //ctr.Items.Clear();
                DataTable dt = db.Consulta(com).Tables[0];
                //FillDataColor_FranjaControl(ctr, dt);
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