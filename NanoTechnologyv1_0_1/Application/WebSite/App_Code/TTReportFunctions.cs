using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TTReportsFunctions
/// </summary>
public class TTReportFunctions
{
    string sPagingTemplate = @"WITH ResultSet AS 
	                            (SELECT {0} {1} 
	                            ROW_NUMBER() OVER ( {2}) as RowNumber,
	                            {3} ) 
                                SELECT * FROM ResultSet 
                                WHERE RowNumber BETWEEN ({4}*{5}+1) AND (({4}+1)*{5})";

    string sPagingTemplateDistict = @"WITH ResultSet AS 
                                        (SELECT Temp.*, ROW_NUMBER() OVER ( {0} ) as RowNumber From 
                                        ( {1} ) as Temp	) 
                                        SELECT * FROM ResultSet 
                                        WHERE RowNumber BETWEEN ({2}*{3}+1) AND (({2}+1)*{3})";

    private string queryCount = string.Empty;
    public string QueryCount
    {
        get { return ClearCampoRelationXstore(queryCount); }
    }

    String[] MonthTraduction;
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
    private TTTraductor.Traductor MyTraductor;

    private int campoRelationXstore;
    public int CampoRelationXstore
    {
        get { return campoRelationXstore; }
        set { campoRelationXstore = value; }
    }

    private TTSecurity.GlobalData MyUserData
    {
        get { return System.Web.HttpContext.Current.Session["UserGlobalInformation"] as TTSecurity.GlobalData; }
    }
    private TTReportes.objectBussinessTTReportes objRep
    {
        get
        {
            return (System.Web.HttpContext.Current.Session["objRep"] != null) ?
                System.Web.HttpContext.Current.Session["objRep"] as TTReportes.objectBussinessTTReportes :
                new TTReportes.objectBussinessTTReportes();
        }
    }

    private int currentPageIndex = 0;
    private int pageSize = 0;
    public int CurrentPageIndex
    {
        get { return currentPageIndex; }
        set { currentPageIndex = value; }
    }
    public int PageSize
    {
        get { return pageSize; }
        set { pageSize = value; }
    }

    private bool isQueryMode = true;
    public bool IsQueryMode
    {
        get { return isQueryMode; }
        set { isQueryMode = value; }
    }

    //-------------Variables para armar la consulta ----------------
    string sSelect = string.Empty;
    string sSelectWithAlias = string.Empty;
    string sJoins = string.Empty;
    string sJoinsFilter = string.Empty;
    string sGroupBy = string.Empty;
    string sWhere = string.Empty;
    string sOrderBy = string.Empty;
    string sOrderByRank = string.Empty;
    string sOrderByPrincipal = string.Empty;
    string sDistinct = string.Empty;
    string sTop = string.Empty;
    string sHaving = string.Empty;
    string sFrom = string.Empty;
    //--------------------------------------------------------------
    public TTReportFunctions()
    {
        if (MyUserData != null)
        {
            MyTraductor = new TTTraductor.Traductor(MyUserData.Language.GetHashCode());
            configurationLanguageScreen();
        }
    }

    private void configurationLanguageScreen()
    {
        MonthTraduction = new String[12];
        MonthTraduction[0] = MyTraductor.getMessage(98);
        MonthTraduction[1] = MyTraductor.getMessage(99);
        MonthTraduction[2] = MyTraductor.getMessage(100);
        MonthTraduction[3] = MyTraductor.getMessage(101);
        MonthTraduction[4] = MyTraductor.getMessage(102);
        MonthTraduction[5] = MyTraductor.getMessage(103);
        MonthTraduction[6] = MyTraductor.getMessage(104);
        MonthTraduction[7] = MyTraductor.getMessage(105);
        MonthTraduction[8] = MyTraductor.getMessage(106);
        MonthTraduction[9] = MyTraductor.getMessage(107);
        MonthTraduction[10] = MyTraductor.getMessage(108);
        MonthTraduction[11] = MyTraductor.getMessage(109);
    }

    private System.Collections.ArrayList MyDTs;
    private TTMetadata.Metadata myMetadata;

    public String Query(int idReport)
    {
        String returnQuery = String.Empty;

        configurationLanguageScreen();

        if (objRep.StoreProcedure != "" && objRep.StoreProcedure != null && isQueryMode)
        {
            returnQuery = "exec " + objRep.StoreProcedure + "\n";
        }

        switch ((TTReportes.TTReportsConfigurationsEnumSubPresentation)objRep.SubtipoPresentacion)
        {
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Detalle:
                {
                    returnQuery += ExtractQueryDetails(objRep) + "\n";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Cruzado:
                {
                    returnQuery += ExtractQueryCross_Row(objRep) + "\n" + ExtractQueryCross_Col(objRep) + "\n" + ExtractQueryCross_Fields(objRep) + "\n";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.PieChart:
                {
                    returnQuery += ExtractQueryCross_Fields(objRep) + "\n";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Lines:
            case TTReportes.TTReportsConfigurationsEnumSubPresentation.Barras:
                {
                    returnQuery += ExtractQueryCross_Fields(objRep) + "\n";
                    break;
                }
            default:
                break;
        }

        if (objRep.StoreProcedure != "" && objRep.StoreProcedure != null && isQueryMode)
        {
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(objRep.StoreRelationDT.Value);
            returnQuery += "Delete From " + myFunctions.GenerateName(myData.NombreTabla) + " Where " + myFunctions.GenerateName(myData.Nombre) + " = " + campoRelationXstore.ToString();
        }
        else if (objRep.StoreProcedure != "" && objRep.StoreProcedure != null && !isQueryMode)
        {
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(objRep.StoreRelationDT.Value);
            returnQuery += "Delete From " + myFunctions.GenerateName(myData.NombreTabla) + " Where " + myFunctions.GenerateName(myData.Nombre) + " = @@CampoRelationXstore@@";
        }
        sWhere = ClearCampoRelationXstore(sWhere);
        returnQuery = ClearCampoRelationXstore(returnQuery);
        return returnQuery;
    }

    #region Crea Query y Refresca control para Reporte-Cruzado
    private String ClearCampoRelationXstore(String query)
    {
        if (System.Web.HttpContext.Current.Session["CampoRelationXstore"] != null)
            return query.Replace("@@CampoRelationXstore@@", System.Web.HttpContext.Current.Session["CampoRelationXstore"].ToString());

        return query;
    }

    public DataTable CreateReportCross(TTReportes.objectBussinessTTReportes objRep, DataTable dtCol, DataTable dtRow, DataTable dtField)
    {
        DataTable dtGrid = new DataTable();
        DataColumn dtColumn;
        DataRow[] drResult;
        string whereString = string.Empty;
        string searchString = string.Empty;
        bool removeGarbageColumn = false;

        //----------------------------------- Crea las columnas con las filas de la matriz -------------------------
        foreach (TTReportes.objectBussinessTTReportes_Filas fila in objRep.FilasId)
        {
            dtColumn = new DataColumn(fila.Text);
            dtGrid.Columns.Add(dtColumn);
        }
        //----------------------------------- Agrega Columnas correspondientes ... ---------------------------------
        foreach (DataRow drCol in dtCol.Rows)
        {
            dtColumn = new DataColumn(drCol[0].ToString());
            dtColumn.DataType = typeof(double);
            dtGrid.Columns.Add(dtColumn);
        }
        //----------------------------------- LLena la matriz con los datos de dtField -----------------------------
        foreach (DataRow drRow in dtRow.Rows)
        {
            DataRow gridRow = dtGrid.NewRow();
            try { gridRow.Table.Columns.Remove("Column1"); removeGarbageColumn = true; }
            catch { }
            whereString = string.Empty;
            searchString = string.Empty;
            //--------------------- Asigna los valores de las filas ------------------------------------------------
            foreach (TTReportes.objectBussinessTTReportes_Filas fila in objRep.FilasId)
            {
                gridRow[fila.Text] = drRow[fila.Text];
                if (drRow[fila.Text].GetType() == typeof(System.DBNull))
                    whereString += (whereString == string.Empty ? string.Empty : " and ") + string.Format("[{0}] is null ", fila.Text//dtField.Columns[0].ColumnName
                        );
                else
                    whereString += (whereString == string.Empty ? string.Empty : " and ") + string.Format("[{0}] = '{1}' ", fila.Text//dtField.Columns[0].ColumnName
                       , drRow[fila.Text].ToString().Replace("'", "''"));

                foreach (DataColumn drCol in dtCol.Columns)
                    foreach (DataRow dcRow in dtCol.Rows)
                    {
                        if (dcRow[drCol].GetType() == typeof(System.DBNull))
                            searchString = whereString + " and " + string.Format("[{0}] is null ", drCol.ColumnName // dtField.Columns[1].ColumnName
                                , dcRow[drCol]);
                        else
                            searchString = whereString + " and " + string.Format("[{0}] = '{1}' ", drCol.ColumnName //dtField.Columns[1].ColumnName
                                , dcRow[drCol].ToString().Replace("'", "''"));

                        try
                        {
                            drResult = dtField.Select(searchString);
                        }
                        catch
                        {
                            continue;
                        }
                        if (dcRow[drCol].ToString() == "" || dcRow[drCol].ToString() == String.Empty)
                            continue;
                        gridRow[dcRow[drCol].ToString()] = 0.0;
                        foreach (DataRow dr in drResult)
                        {
                            //gridRow[objRep.FuncionesId[0].Text] = 1.0;
                            gridRow[dcRow[drCol].ToString()] = dr[objRep.FuncionesId[0].Text];
                        }
                    }
            }
            //------------------------------------------------------------------------------------------------------

            dtGrid.Rows.Add(gridRow);
        }
        //if (removeGarbageColumn)
        //    dtGrid.Rows[0].Delete();
        return dtGrid;
    }

    /****************************************************************************************************/
    /* Este método se utiliza para obtener el dataset de una Gráficas, no necesita paginación */
    /****************************************************************************************************/

    private void SetWhereFromFilter()
    {
        objRep.FiltroId.WhereJoin = string.Empty;
        string tmpWhere = objRep.FiltroId.GenerateWhereWithLeftJoin(null, string.Empty);
        if (tmpWhere != string.Empty && sWhere != string.Empty)
            sWhere += ("and " + tmpWhere);
        else
            sWhere += tmpWhere;
        sJoins = objRep.FiltroId.WhereJoin;
    }

    private void SetWhereFromFilterDetails()
    {
        objRep.FiltroId.WhereJoin = string.Empty;
        string tmpWhere = objRep.FiltroId.GenerateWhereWithLeftJoin(null, string.Empty);
        if (tmpWhere != string.Empty && sWhere != string.Empty)
            sWhere += ("and " + tmpWhere);
        else
            sWhere += tmpWhere;
        sJoinsFilter = objRep.FiltroId.WhereJoin;
    }

    public void SetFieldName(string aliasJoin, ref string fieldName, TTReportes.TTReportsConfigurationsEnumFormatDate format,
        string tableName, string fieldWithoutFunction)
    {
        if (aliasJoin != "")
            fieldName = ExtractFormatToField(format, aliasJoin + "." + fieldWithoutFunction);
        else
            fieldName = ExtractFormatToField(format, tableName + "." + fieldWithoutFunction);
    }

    public String ExtractQueryCross_Fields(TTReportes.objectBussinessTTReportes objRep)
    {
        sSelect = sSelectWithAlias = sJoins = sGroupBy = sWhere = sOrderBy = sOrderByRank = sOrderByPrincipal = sDistinct = sTop = sHaving = sFrom = sJoinsFilter = string.Empty;

        SetWhereFromStoredProcedure();
        SetWhereFromFilter();

        myMetadata = new TTMetadata.Metadata(MyUserData);
        //------------------------------------------------------
        SetSelectFromObjectFilas();
        //------------------------------------------------------
        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;

            String sFunction = "";
            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

            sGroupBy += sFieldName + ", ";
            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    //sOrderBy += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    sOrderBy += SetOrderByRank(col.OrderBy, col.Funciones, sFieldName, col.Text, sAliasJoin, sTableName, col.Format);
                    break;
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    //sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funciones, sFieldName, col.Text, sAliasJoin, sTableName, col.Format);
                    break;
            }

            sSelect += SetFieldFunction(col.Funciones, sFieldName) + ", ";
            sSelectWithAlias += SetFieldFunction(col.Funciones, sFieldName, col.Text) + ", ";

            if (!col.Mostrar_Vacios)
                sHaving += SetFieldFunction(col.Funciones, sFieldName) + " > 0, ";
        }

        foreach (TTReportes.objectBussinessTTReportes_Funciones col in objRep.FuncionesId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;

            String sFunction = "";
            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------            
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            sSelect += SetFieldFunction(col.Funcion, sFieldName) + ", ";
            sSelectWithAlias += SetFieldFunction(col.Funcion, sFieldName, col.Text) + ", ";

            if (!col.Mostrar_Vacios)
                sHaving += SetFieldFunction(col.Funcion, sFieldName) + " > 0, ";

            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    sOrderBy += SetOrderByRank(col.OrderBy, col.Funcion, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funcion, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
            }

        }
        if (sSelect != "")
        {
            sSelect = sSelect.Substring(0, sSelect.Length - 2);
            sSelectWithAlias = sSelectWithAlias.Substring(0, sSelectWithAlias.Length - 2);
        }

        Boolean containFunction = false;
        foreach (TTReportes.objectBussinessTTReportes_Funciones col in objRep.FuncionesId)
            if (col.Funcion != TTReportes.TTReportsConfigurationsEnumfunctions.None)
            {
                containFunction = true;
                break;
            }
        foreach (TTReportes.objectBussinessTTReportes_Funciones col in objRep.FuncionesId)
        {
            if ((containFunction) && col.Funcion == TTReportes.TTReportsConfigurationsEnumfunctions.None)
            {
                String sAliasJoin = "";
                String myJoin = "";

                myJoin = DBJoin(col.FullPathDT, sJoins);
                sAliasJoin = DBTableAlias(col.FullPathDT);

                string TotalJoin, ActualJoin;
                TotalJoin = sJoins.ToLower().Trim();
                ActualJoin = myJoin.ToLower().Trim();

                if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                    sJoins = myJoin;
                else if (!TotalJoin.Contains(ActualJoin))
                    sJoins += myJoin;

                col.IsGroup = true;
                String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
                //----------------------------------------------------------
                sFieldWithoutFunction = DBField(col.FullPathDT);
                sTableName = DBTable(col.FullPathDT);
                //----------------------------------------------------------                
                SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

                sGroupBy += sFieldName + ", ";
                switch (col.OrderBy)
                {
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                        sOrderBy += SetOrderByRank(col.OrderBy, col.Funcion, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        break;
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                        sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funcion, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        break;
                }
                if (!col.Mostrar_Vacios)
                    sHaving += sFieldName + " > 0, ";

            }
        }
        if (sGroupBy != "")
            sGroupBy = " Group By " + sGroupBy.Substring(0, sGroupBy.Length - 2);
        //if (sOrderBy != "")
        //    sOrderBy = " Order By " + sOrderByPrincipal + sOrderBy.Substring(0, sOrderBy.Length - 2);
        //else
        if (sOrderByPrincipal != "")
            sOrderBy = " Order By " + sOrderByPrincipal.Substring(0, sOrderByPrincipal.Length - 2);
        else if (sOrderBy != string.Empty)
            sOrderBy = " Order By " + sOrderBy.Substring(0, sOrderBy.Length - 2);

        if (sHaving != "")
            sHaving = " Having " + sHaving.Substring(0, sHaving.Length - 2);
        if (sWhere != "")
            sWhere = " Where " + sWhere;
        sDistinct = " Distinct ";
        if (objRep.TopList.HasValue)
            if (objRep.TopList.Value != 0)
                sTop = " Top " + objRep.TopList.ToString() + " ";

        TTMetadata.MetadataDatosDNT myDNT = myMetadata.GetDNTs(objRep.ProcesoId.Value);
        String sQuery = "Select " + sDistinct + sTop + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " " + sJoins + " " + sWhere + " " + sGroupBy + " " + sHaving + " " + sOrderBy;
        sQuery = ClearCampoRelationXstore(sQuery);
        return sQuery;
    }

    public String SetQueryCross_Fields(TTReportes.objectBussinessTTReportes objRep)
    {
        sSelect = sSelectWithAlias = sJoins = sGroupBy = sWhere = sOrderBy = sOrderByRank = sOrderByPrincipal = sDistinct = sTop = sHaving = sFrom = sJoinsFilter = string.Empty;

        SetWhereFromStoredProcedure();
        SetWhereFromFilter();

        myMetadata = new TTMetadata.Metadata(MyUserData);
        //------------------------------------------------------
        SetSelectFromObjectFilas();
        //------------------------------------------------------
        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;

            String sFunction = "";
            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

            sGroupBy += sFieldName + ", ";

            sSelect += SetFieldFunction(col.Funciones, sFieldName) + ", ";
            sSelectWithAlias += SetFieldFunction(col.Funciones, sFieldName, col.Text) + ", ";

            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    sOrderBy += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
            }

            if (!col.Mostrar_Vacios)
                sHaving += SetFieldFunction(col.Funciones, sFieldName) + " > 0, ";
        }
        foreach (TTReportes.objectBussinessTTReportes_Funciones col in objRep.FuncionesId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;

            String sFunction = "";
            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            sSelect += SetFieldFunction(col.Funcion, sFieldName) + ", ";
            sSelectWithAlias += SetFieldFunction(col.Funcion, sFieldName, col.Text) + ", ";

            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    sOrderBy += SetOrderByRank(col.OrderBy, col.Funcion, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funcion, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
            }

            if (!col.Mostrar_Vacios)
                sHaving += SetFieldFunction(col.Funcion, sFieldName) + " > 0, ";
        }

        if (sSelect != "")
        {
            sSelect = sSelect.Substring(0, sSelect.Length - 2);
            sSelectWithAlias = sSelectWithAlias.Substring(0, sSelectWithAlias.Length - 2);
        }

        Boolean containFunction = false;
        foreach (TTReportes.objectBussinessTTReportes_Funciones col in objRep.FuncionesId)
            if (col.Funcion != TTReportes.TTReportsConfigurationsEnumfunctions.None)
            {
                containFunction = true;
                break;
            }
        foreach (TTReportes.objectBussinessTTReportes_Funciones col in objRep.FuncionesId)
        {
            if ((containFunction) && col.Funcion == TTReportes.TTReportsConfigurationsEnumfunctions.None)
            {
                String sAliasJoin = "";
                String myJoin = "";

                myJoin = DBJoin(col.FullPathDT, sJoins);
                sAliasJoin = DBTableAlias(col.FullPathDT);

                string TotalJoin, ActualJoin;
                TotalJoin = sJoins.ToLower().Trim();
                ActualJoin = myJoin.ToLower().Trim();

                if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                    sJoins = myJoin;
                else if (!TotalJoin.Contains(ActualJoin))
                    sJoins += myJoin;

                col.IsGroup = true;
                String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
                //----------------------------------------------------------
                sFieldWithoutFunction = DBField(col.FullPathDT);
                sTableName = DBTable(col.FullPathDT);
                //----------------------------------------------------------
                SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

                sGroupBy += sFieldName + ", ";
                switch (col.OrderBy)
                {
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                        sOrderBy += SetOrderByRank(col.OrderBy, col.Funcion, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        break;
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                        sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funcion, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        break;
                }
                if (!col.Mostrar_Vacios)
                    sHaving += sFieldName + " > 0, ";

            }
        }

        if (sOrderByPrincipal != "")
            sOrderBy = " Order By " + sOrderByPrincipal.Substring(0, sOrderByPrincipal.Length - 2);
        else if (sOrderBy != string.Empty)
            sOrderBy = " Order By " + sOrderBy.Substring(0, sOrderBy.Length - 2);

        if (sHaving != "")
            sHaving = " Having " + sHaving.Substring(0, sHaving.Length - 2);
        if (sWhere != "")
            sWhere = " Where " + sWhere;
        sDistinct = " Distinct ";
        if (objRep.TopList.HasValue)
            if (objRep.TopList.Value != 0)
                sTop = " Top " + objRep.TopList.ToString() + " ";

        TTMetadata.MetadataDatosDNT myDNT = myMetadata.GetDNTs(objRep.ProcesoId.Value);
        sFrom = " From " + myFunctions.GenerateName(myDNT.Nombre) + " With(NoLock) " + sJoins + " " + sWhere + " " + sGroupBy;
        //-----------------------------------------------------------------------
        sOrderByRank = sOrderBy;
        if (sOrderByRank == string.Empty)
        {
            string[] fields = sSelect.Split(',');
            if (fields.Length > 0)
                sOrderByRank = " ORDER BY " + fields[0];
            else
                sOrderByRank = " ORDER BY " + sSelect;
        }

        queryCount = "Select " + sDistinct + sTop + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " " + sJoins + " " + sWhere + " " + sGroupBy + " " + sHaving;
        queryCount = string.Format("SELECT COUNT(*) FROM ( {0} ) AS TABLE1", queryCount);

        string sQuery = string.Format(sPagingTemplate, sDistinct, sTop, sOrderByRank, sSelectWithAlias + sFrom, currentPageIndex, pageSize);
        sQuery = ClearCampoRelationXstore(sQuery);
        return sQuery;

    }
    /****************************************************************************************************/
    /* Este método se usa para Reportes Cross Field de Matriz                                           */
    /****************************************************************************************************/
    public String ExtractQueryCross_Row(TTReportes.objectBussinessTTReportes objRep)
    {
        sSelect = sSelectWithAlias = sJoins = sGroupBy = sWhere = sOrderBy = sOrderByRank = sOrderByPrincipal = sDistinct = sTop = sHaving = sFrom = sJoinsFilter = string.Empty;

        SetWhereFromStoredProcedure();
        SetWhereFromFilter();

        TTMetadata.Metadata myMetadata = new TTMetadata.Metadata(MyUserData);
        System.Collections.ArrayList MyDTs;
        foreach (TTReportes.objectBussinessTTReportes_Filas col in objRep.FilasId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;

            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

            sGroupBy += sFieldName + ", ";
            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None: { sOrderBy += sFieldName + ", "; break; }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente: { sOrderByPrincipal += sFieldName + " Asc, "; break; }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente: { sOrderByPrincipal += sFieldName + " Desc, "; break; }
            }

            sSelect += sFieldName + ", ";
            sSelectWithAlias += sFieldName + " as [" + col.Text + "], ";
        }

        if (sSelect != "")
        {
            sSelect = sSelect.Substring(0, sSelect.Length - 2);
            sSelectWithAlias = sSelectWithAlias.Substring(0, sSelectWithAlias.Length - 2);
        }

        if (sGroupBy != "")
            sGroupBy = " Group By " + sGroupBy.Substring(0, sGroupBy.Length - 2);

        if (sOrderByPrincipal != "")
            sOrderBy = " Order By " + sOrderByPrincipal.Substring(0, sOrderByPrincipal.Length - 2);
        else if (sOrderBy != string.Empty)
            sOrderBy = " Order By " + sOrderBy.Substring(0, sOrderBy.Length - 2);

        if (sWhere != "")
            sWhere = " Where " + sWhere;
        sDistinct = " Distinct ";

        TTMetadata.MetadataDatosDNT myDNT = myMetadata.GetDNTs(objRep.ProcesoId.Value);
        String sQuery = "Select " + sDistinct + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " " + sJoins + " " + sWhere + " " + sGroupBy + " " + sOrderBy;
        sQuery = ClearCampoRelationXstore(sQuery);
        return sQuery;
    }

    public String SetQueryCross_Row(TTReportes.objectBussinessTTReportes objRep)
    {
        sSelect = sSelectWithAlias = sJoins = sGroupBy = sWhere = sOrderBy = sOrderByRank = sOrderByPrincipal = sDistinct = sTop = sHaving = sFrom = string.Empty;

        SetWhereFromStoredProcedure();
        SetWhereFromFilter();

        TTMetadata.Metadata myMetadata = new TTMetadata.Metadata(MyUserData);
        foreach (TTReportes.objectBussinessTTReportes_Filas col in objRep.FilasId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;
            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------            
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

            sGroupBy += sFieldName + ", convert(nvarchar," + (sAliasJoin != "" ? sAliasJoin : sTableName) + "." + sFieldWithoutFunction + ",112), ";
            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None: { sOrderBy += sFieldName + ", "; break; }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente: { sOrderByPrincipal += "convert(nvarchar," + (sAliasJoin != "" ? sAliasJoin : sTableName) + "." + sFieldWithoutFunction + ",112) Asc, "; break; }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente: { sOrderByPrincipal += "convert(nvarchar," + (sAliasJoin != "" ? sAliasJoin : sTableName) + "." + sFieldWithoutFunction + ",112) Desc, "; break; }
            }
            sSelect += sFieldName + ", ";
            sSelectWithAlias += sFieldName + " as [" + col.Text + "], convert(nvarchar," + (sAliasJoin != "" ? sAliasJoin : sTableName) + "." + sFieldWithoutFunction + ",112) as [" + col.Text + "_" + "Quitar], ";

            //--------------------- Alias para paginacion y distinct ---------------
            sOrderByRank += ("Temp.[" + col.Text + "], ");
            //----------------------------------------------------------------------
        }
        //sOrderBy = (sOrderByPrincipal == string.Empty ? sOrderBy : sOrderByPrincipal);
        sOrderByRank = (sOrderByRank == string.Empty ? sOrderBy : sOrderByRank);
        if (sSelect != "")
        {
            sSelect = sSelect.Substring(0, sSelect.Length - 2);
            sSelectWithAlias = sSelectWithAlias.Substring(0, sSelectWithAlias.Length - 2);
            sOrderByRank = sOrderByRank.Substring(0, sOrderByRank.Length - 2);
        }

        if (sGroupBy != "")
            sGroupBy = " Group By " + sGroupBy.Substring(0, sGroupBy.Length - 2);
        if (sOrderBy != "")
            sOrderBy = " Order By " + sOrderByPrincipal + sOrderBy.Substring(0, sOrderBy.Length - 2);
        else
            if (sOrderByPrincipal != "")
                sOrderBy = " Order By " + sOrderByPrincipal.Substring(0, sOrderByPrincipal.Length - 2);
        if (sWhere != "")
            sWhere = " Where " + sWhere;
        sDistinct = " Distinct ";
        if (objRep.TopList.HasValue)
            if (objRep.TopList.Value != 0)
                sTop = " Top " + objRep.TopList.ToString() + " ";

        TTMetadata.MetadataDatosDNT myDNT = myMetadata.GetDNTs(objRep.ProcesoId.Value);
        //String sQuery = "Select " + sDistinct + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " " + sJoins + " " + sWhere + " " + sGroupBy + " " + sOrderBy;
        //return sQuery;

        sFrom = " From " + myFunctions.GenerateName(myDNT.Nombre) + " With(NoLock) " + sJoins + " " + sWhere + " " + sGroupBy;
        //-----------------------------------------------------------------------
        //sOrderByRank = sOrderBy;
        //-----------------------------------------------------------------------        
        //if (sOrderBy.ToLower().Contains("asc"))
        //    sOrderByRank = string.Format("ORDER BY {0} ASC", sOrderByRank);
        //else if (sOrderBy.ToLower().Contains("desc"))
        //    sOrderByRank = string.Format("ORDER BY {0} DESC", sOrderByRank);
        //else
        sOrderByRank = string.Format("ORDER BY {0}", sOrderByRank);
        //-----------------------------------------------------------------------

        string sQuery = string.Empty;

        if (sOrderByRank == string.Empty)
        {
            string[] fields = sSelect.Split(',');
            if (fields.Length > 0)
                sOrderByRank = " ORDER BY " + fields[0];
            else
                sOrderByRank = " ORDER BY " + sSelect;
        }

        //queryCount = "Select " + sDistinct + sTop + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " " + sJoins + " " + sWhere + " " + sGroupBy + " " + sHaving;
        //queryCount = string.Format("SELECT COUNT(*) FROM ( {0} ) AS TABLE1", queryCount);

        //string sQuery = string.Format(sPagingTemplate, sDistinct, sTop, sOrderByRank, sSelectWithAlias + sFrom, currentPageIndex, pageSize);

        //-----------------------------------------------------------------------
        //----Si la consulta tiene un top....--------
        if (objRep.TopList != null && objRep.TopList != 0)
        {
            sQuery = "Select {0} {1} {2} {3} ";
            sQuery = string.Format(sQuery, sDistinct, sTop, sSelectWithAlias + sFrom, sOrderBy);

            queryCount = "Select count(*) from (Select {0} {1} {2} ) as TableCount";
            queryCount = string.Format(queryCount, sDistinct, sTop, sSelectWithAlias + sFrom);
        }
        //----Sino aplicar paginacion ---------------
        else
        {
            sQuery = "Select {0} {1} {2} {3} ";
            sQuery = string.Format(sQuery, sDistinct, sTop, sSelectWithAlias + sFrom, sOrderBy);

            queryCount = "Select count(*) from (Select {0} {1} {2} ) as TableCount";
            queryCount = string.Format(queryCount, sDistinct, sTop, sSelectWithAlias + sFrom);
            //sQuery = string.Format(sPagingTemplateDistict, sOrderByRank, sQuery, currentPageIndex, pageSize);
        }
        sQuery = this.ClearCampoRelationXstore(sQuery);
        queryCount = this.ClearCampoRelationXstore(queryCount);
        return sQuery;
    }

    /****************************************************************************************************/
    /* Este método se usa para Reportes Cross Field de Matriz                                           */
    /****************************************************************************************************/
    public String ExtractQueryCross_Col(TTReportes.objectBussinessTTReportes objRep)
    {
        sSelect = sSelectWithAlias = sJoins = sGroupBy = sWhere = sOrderBy = sOrderByRank = sOrderByPrincipal = sDistinct = sTop = sHaving = sFrom = sJoinsFilter = string.Empty;

        SetWhereFromStoredProcedure();
        SetWhereFromFilter();

        TTMetadata.Metadata myMetadata = new TTMetadata.Metadata(MyUserData);
        System.Collections.ArrayList MyDTs;
        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;

            String sFunction = "";
            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

            sGroupBy += sFieldName + ", ";
            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    sOrderBy += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
            }

            sSelect += SetFieldFunction(col.Funciones, sFieldName) + ", ";
            sSelectWithAlias += SetFieldFunction(col.Funciones, sFieldName, col.Text) + ", ";
        }
        if (sSelect != "")
        {
            sSelect = sSelect.Substring(0, sSelect.Length - 2);
            sSelectWithAlias = sSelectWithAlias.Substring(0, sSelectWithAlias.Length - 2);
        }

        if (sGroupBy != "")
            sGroupBy = " Group By " + sGroupBy.Substring(0, sGroupBy.Length - 2);

        if (sOrderByPrincipal != "")
            sOrderBy = " Order By " + sOrderByPrincipal.Substring(0, sOrderByPrincipal.Length - 2);
        else if (sOrderBy != string.Empty)
            sOrderBy = " Order By " + sOrderBy.Substring(0, sOrderBy.Length - 2);

        if (sWhere != "")
            sWhere = " Where " + sWhere;
        sDistinct = " Distinct ";

        sWhere = this.ClearCampoRelationXstore(sWhere);
        TTMetadata.MetadataDatosDNT myDNT = myMetadata.GetDNTs(objRep.ProcesoId.Value);
        String sQuery = "Select " + sDistinct + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " " + sJoins + " " + sWhere + " " + sGroupBy + " " + sOrderBy;
        sQuery = ClearCampoRelationXstore(sQuery);
        return sQuery;
    }

    private string ExtractFormatToField(TTReportes.TTReportsConfigurationsEnumFormatDate Format, String Field)
    {
        String result = "";
        switch (Format)
        {
            case TTReportes.TTReportsConfigurationsEnumFormatDate.None:
                {
                    result = Field;
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumFormatDate.Dia:
                {
                    result = "cast(datePart(day," + Field + ") as varchar(2))";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumFormatDate.Mes:
                {
                    result = "case cast(datePart(month," + Field + ") as varchar(2)) when 1 then '" + MonthTraduction[0] + "'when 2 then '" + MonthTraduction[1] + "'when 3 then '" + MonthTraduction[2] + "'when 4 then '" + MonthTraduction[3] + "'when 5 then '" + MonthTraduction[4] + "'when 6 then '" + MonthTraduction[5] + "'when 7 then '" + MonthTraduction[6] + "'when 8 then '" + MonthTraduction[7] + "'when 9 then '" + MonthTraduction[8] + "'when 10 then '" + MonthTraduction[9] + "'when 11 then '" + MonthTraduction[10] + "'when 12 then '" + MonthTraduction[11] + "'end ";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumFormatDate.Semana:
                {
                    result = "cast(datePart(wk," + Field + ") as varchar(2))";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumFormatDate.Año:
                {
                    result = "cast(datePart(year," + Field + ") as varchar(4))";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumFormatDate.AñoMes:
                {
                    result = "cast(datePart(year," + Field + ") as varchar(4)) + '-' +" +
                        "case cast(datePart(month," + Field + ") as varchar(2)) when 1 then '" + MonthTraduction[0] + "'when 2 then '" + MonthTraduction[1] + "'when 3 then '" + MonthTraduction[2] + "'when 4 then '" + MonthTraduction[3] + "'when 5 then '" + MonthTraduction[4] + "'when 6 then '" + MonthTraduction[5] + "'when 7 then '" + MonthTraduction[6] + "'when 8 then '" + MonthTraduction[7] + "'when 9 then '" + MonthTraduction[8] + "'when 10 then '" + MonthTraduction[9] + "'when 11 then '" + MonthTraduction[10] + "'when 12 then '" + MonthTraduction[11] + "'end";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumFormatDate.AñoMesDia:
                {
                    result = "cast(datePart(day," + Field + ") as varchar(2)) + " +
                        " '-' + case cast(datePart(month," + Field + ") as varchar(2)) when 1 then '" + MonthTraduction[0].Substring(0, 3) + "'when 2 then '" + MonthTraduction[1].Substring(0, 3) + "'when 3 then '" + MonthTraduction[2].Substring(0, 3) + "'when 4 then '" + MonthTraduction[3].Substring(0, 3) + "'when 5 then '" + MonthTraduction[4].Substring(0, 3) + "'when 6 then '" + MonthTraduction[5].Substring(0, 3) + "'when 7 then '" + MonthTraduction[6].Substring(0, 3) + "'when 8 then '" + MonthTraduction[7].Substring(0, 3) + "'when 9 then '" + MonthTraduction[8].Substring(0, 3) + "'when 10 then '" + MonthTraduction[9].Substring(0, 3) + "'when 11 then '" + MonthTraduction[10].Substring(0, 3) + "'when 12 then '" + MonthTraduction[11].Substring(0, 3) + "'end + " +
                        " '-' + cast(datePart(year," + Field + ") as varchar(4))";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumFormatDate.MesDia:
                {
                    result = "cast(datePart(day," + Field + ") as varchar(2))+ '-'+ " +
                        "case cast(datePart(month," + Field + ") as varchar(2)) when 1 then '" + MonthTraduction[0] + "'when 2 then '" + MonthTraduction[1] + "'when 3 then '" + MonthTraduction[2] + "'when 4 then '" + MonthTraduction[3] + "'when 5 then '" + MonthTraduction[4] + "'when 6 then '" + MonthTraduction[5] + "'when 7 then '" + MonthTraduction[6] + "'when 8 then '" + MonthTraduction[7] + "'when 9 then '" + MonthTraduction[8] + "'when 10 then '" + MonthTraduction[9] + "'when 11 then '" + MonthTraduction[10] + "'when 12 then '" + MonthTraduction[11] + "'end ";
                    break;
                }
            case TTReportes.TTReportsConfigurationsEnumFormatDate.DiasContraHoy:
                {
                    result = "datediff(d," + Field + ",getdate())";
                    break;
                }
        }
        return result;
    }
    #endregion
    #region Crea Query y refresca control para Reporte-Detalle
    public void CreateReportDetail(TTReportes.objectBussinessTTReportes objRep, DataTable dt)
    {
    }

    private string ExtractQueryDetails(TTReportes.objectBussinessTTReportes objRep)
    {
        sSelect = sSelectWithAlias = sJoins = sGroupBy = sWhere = sOrderBy = sOrderByRank = sOrderByPrincipal = sDistinct = sTop = sHaving = sFrom = sJoinsFilter = string.Empty;

        SetWhereFromStoredProcedure();
        SetWhereFromFilter();

        TTMetadata.Metadata myMetadata = new TTMetadata.Metadata(MyUserData);

        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;

            String sFunction = "";
            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

            sSelect += SetFieldFunction(col.Funciones, sFieldName) + ", ";
            sSelectWithAlias += SetFieldFunction(col.Funciones, sFieldName, col.Text) + ", ";

            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    sOrderBy += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
            }
        }
        if (sSelect != "")
        {
            sSelect = sSelect.Substring(0, sSelect.Length - 2);
            sSelectWithAlias = sSelectWithAlias.Substring(0, sSelectWithAlias.Length - 2);
        }

        ////Create GroupBys
        //Checamos que exista por lo menos alguna funcion
        //o un subtotal para Crear los groupby
        Boolean containFunction = false;
        //Checamos si existe alguna columna con Funcion
        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
            if (col.Funciones != TTReportes.TTReportsConfigurationsEnumfunctions.None)
            {
                containFunction = true;
                break;
            }
        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
        {
            if ((containFunction || col.Subtotal) && col.Funciones == TTReportes.TTReportsConfigurationsEnumfunctions.None)
            {
                String sAliasJoin = "";
                String myJoin = "";

                myJoin = DBJoin(col.FullPathDT, sJoins);
                sAliasJoin = DBTableAlias(col.FullPathDT);

                string TotalJoin, ActualJoin;
                TotalJoin = sJoins.ToLower().Trim();
                ActualJoin = myJoin.ToLower().Trim();

                if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                    sJoins = myJoin;
                else if (!TotalJoin.Contains(ActualJoin))
                    sJoins += myJoin;

                col.IsGroup = true;
                String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
                //----------------------------------------------------------
                sFieldWithoutFunction = DBField(col.FullPathDT);
                sTableName = DBTable(col.FullPathDT);
                //----------------------------------------------------------
                SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

                SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

                sGroupBy += sFieldName + ", ";
                switch (col.OrderBy)
                {
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                        string sTmpOrder = SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        if (!sOrderBy.Contains(sTmpOrder))
                            sOrderBy += sTmpOrder; //SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        break;
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                        string sTmpOrder1 = SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        if (!sOrderByPrincipal.Contains(sTmpOrder1))
                            sOrderByPrincipal += sTmpOrder1; //SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        break;
                }
                //sSelect += sFieldName + ", ";
            }
        }
        if (sGroupBy != "")
            sGroupBy = " Group By " + sGroupBy.Substring(0, sGroupBy.Length - 2);

        if (sOrderByPrincipal != "")
            sOrderBy = " Order By " + sOrderByPrincipal.Substring(0, sOrderByPrincipal.Length - 2);
        else if (sOrderBy != string.Empty)
            sOrderBy = " Order By " + sOrderBy.Substring(0, sOrderBy.Length - 2);

        if (sWhere != "")
            sWhere = " Where " + sWhere;
        if (objRep.Distinct)
            sDistinct = " Distinct ";
        if (objRep.TopList.HasValue)
            if (objRep.TopList.Value != 0)
                sTop = " Top " + objRep.TopList.ToString() + " ";

        sOrderBy = (sOrderBy == string.Empty ? " Order By " + sSelect : sOrderBy);

        TTMetadata.MetadataDatosDNT myDNT = myMetadata.GetDNTs(objRep.ProcesoId.Value);

        String sQuery;

        if (!isQueryMode)
            sQuery = "Select " + sDistinct + sTop + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " With(NoLock) " + sJoins + " " + sWhere + " " + sGroupBy;
        else
            sQuery = "Select " + sDistinct + sTop + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " With(NoLock) " + sJoins + " " + sWhere + " " + sGroupBy + " " + sOrderBy;

        sQuery = ClearCampoRelationXstore(sQuery);
        return sQuery;
    }

    private void SetWhereFromStoredProcedure()
    {
        if (objRep.StoreProcedure != "" && isQueryMode)
        {
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(objRep.GlobalInformation);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(objRep.StoreRelationDT.Value);
            if (sWhere != "")
                sWhere += " And ";
            sWhere += (myFunctions.GenerateName(myData.NombreTabla) + "." + myFunctions.GenerateName(myData.Nombre) + " = " + CampoRelationXstore);
        }
        else if (objRep.StoreProcedure != "" && !isQueryMode)
        {
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(objRep.GlobalInformation);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(objRep.StoreRelationDT.Value);
            if (sWhere != "")
                sWhere += " And ";
            sWhere += (myFunctions.GenerateName(myData.NombreTabla) + "." + myFunctions.GenerateName(myData.Nombre) + " = @@CampoRelationXstore@@ ");
        }
    }

    private void SetSelectFromObjectFilas()
    {
        foreach (TTReportes.objectBussinessTTReportes_Filas col in objRep.FilasId)
        {
            String sAliasJoin = "";
            String myJoin = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);

            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                sJoins = myJoin;
            else if (!TotalJoin.Contains(ActualJoin))
                sJoins += myJoin;

            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT);
            sTableName = DBTable(col.FullPathDT);
            //----------------------------------------------------------
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

            sGroupBy += sFieldName + ", ";
            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None: { sOrderBy += sFieldName + ", "; break; }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente: { sOrderByPrincipal += sFieldName + " Asc, "; break; }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente: { sOrderByPrincipal += sFieldName + " Desc, "; break; }
            }
            sSelect += sFieldName + ", ";
            sSelectWithAlias += sFieldName + " as [" + col.Text + "], ";
        }
    }

    private void SetSelectFromObjectColumns()
    {
        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
        {
            //--------------------------------------------------------------------------
            String sAliasJoin = "";
            String myJoin = "";
            String sFunction = "";

            myJoin = DBJoin(col.FullPathDT, sJoins);
            sAliasJoin = DBTableAlias(col.FullPathDT);
            if (sAliasJoin != string.Empty && sJoins != string.Empty)
            {
                int contador = ContainsCount(" " + sAliasJoin.ToLower() + " ", sJoins.ToLower());
                //contador = contador / 2 + 1;
                if (contador > 0)
                    sAliasJoin += contador.ToString();
            }
            string TotalJoin, ActualJoin;
            TotalJoin = sJoins.ToLower().Trim();
            ActualJoin = myJoin.ToLower().Trim();

            if (myJoin != "" && !sJoinsFilter.Contains(myJoin))
            {
                if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                    sJoins = myJoin;
                else if (!TotalJoin.Contains(ActualJoin))
                    sJoins += myJoin;
            }

            String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
            //----------------------------------------------------------
            sFieldWithoutFunction = DBField(col.FullPathDT); //myFunctions.GenerateName(Dt.Nombre);
            sTableName = DBTable(col.FullPathDT); // myFunctions.GenerateName(Dt.NombreTabla);
            //----------------------------------------------------------
            SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

            SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);

            sSelect += SetFieldFunction(col.Funciones, sFieldName) + ", ";
            sSelectWithAlias += SetFieldFunction(col.Funciones, sFieldName, col.Text) + ", ";

            switch (col.OrderBy)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    sOrderBy += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    break;
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                    sSelectWithAlias += " convert(nvarchar," + (sAliasJoin != "" ? sAliasJoin : sTableName) + "." + sFieldWithoutFunction + ",112) as [" + col.Text + "_" + "Quitar], ";
                    break;
            }
            if (col.Format == TTReportes.TTReportsConfigurationsEnumFormatDate.None || col.Format == TTReportes.TTReportsConfigurationsEnumFormatDate.DiasContraHoy)
                sOrderByRank += SetFieldFunctionWithOrder(col.Funciones, col.OrderBy, sFieldName);
            else
                sOrderByRank += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction + ",112)", col.Text, (sAliasJoin != string.Empty ? "Convert(nvarchar," + sAliasJoin : sAliasJoin), "Convert(nvarchar," + sTableName);
        }
        //--------------------------------------------------------------------------------
        sOrderBy = (sOrderByPrincipal == string.Empty ? sOrderBy : sOrderByPrincipal);
        sOrderByRank = (sOrderByRank == string.Empty ? sOrderBy : sOrderByRank);
        if (sSelect != "")
        {
            sSelect = sSelect.Substring(0, sSelect.Length - 2);
            sSelectWithAlias = sSelectWithAlias.Substring(0, sSelectWithAlias.Length - 2);
            sOrderByRank = sOrderByRank.Substring(0, sOrderByRank.Length - 2);
        }
        //--------------------------------------------------------------------------------
    }

    private string SetFieldFunction(TTReportes.TTReportsConfigurationsEnumfunctions function, string field)
    {
        switch (function)
        {
            case TTReportes.TTReportsConfigurationsEnumfunctions.Min:
                { return string.Format("Min({0})", field); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Max:
                { return string.Format("Max({0})", field); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Conteo:
                { return string.Format("Count({0})", field); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.ConteoDistinto:
                { return string.Format("Count(Distinct {0})", field); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Suma:
                { return string.Format("Sum({0})", field); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Promedio:
                { return string.Format("Avg({0})", field); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.None:
                { return string.Format("{0}", field); }
        }
        return field;
    }

    private string SetFieldFunction(TTReportes.TTReportsConfigurationsEnumfunctions function, string field, string alias)
    {
        switch (function)
        {
            case TTReportes.TTReportsConfigurationsEnumfunctions.Min:
                { return string.Format("Min({0}) as [{1}]", field, alias); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Max:
                { return string.Format("Max({0}) as [{1}]", field, alias); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Conteo:
                { return string.Format("Count({0}) as [{1}]", field, alias); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.ConteoDistinto:
                { return string.Format("Count(Distinct {0}) as [{1}]", field, alias); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Suma:
                { return string.Format("Sum({0}) as [{1}]", field, alias); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Promedio:
                { return string.Format("Avg({0}) as [{1}]", field, alias); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.None:
                { return string.Format("{0} as [{1}]", field, alias); }
        }
        return field;
    }

    private string SetFieldFunctionWithOrder(TTReportes.TTReportsConfigurationsEnumfunctions function, TTReportes.TTReportsConfigurationsEnumOrderBy order, string field)
    {
        string strOrder = string.Empty;

        switch (order)
        {
            case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                return string.Empty;
                //strOrder = " , ";
                break;
            case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                strOrder = " Asc, ";
                break;
            case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                strOrder = " Desc, ";
                break;
        }

        switch (function)
        {
            case TTReportes.TTReportsConfigurationsEnumfunctions.Min:
                { return string.Format("Min({0}){1}", field, strOrder); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Max:
                { return string.Format("Max({0}){1}", field, strOrder); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Conteo:
                { return string.Format("Count({0}){1}", field, strOrder); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.ConteoDistinto:
                { return string.Format("Count(Distinct {0}){1}", field, strOrder); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Suma:
                { return string.Format("Sum({0}){1}", field, strOrder); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.Promedio:
                { return string.Format("Avg({0}){1}", field, strOrder); }
            case TTReportes.TTReportsConfigurationsEnumfunctions.None:
                { { return string.Format("{0}{1}", field, strOrder); }; }
        }
        return field;
    }

    string SetOrderByRank(TTReportes.TTReportsConfigurationsEnumOrderBy order, TTReportes.TTReportsConfigurationsEnumfunctions funcion,
        string fieldWithoutFunction, string fieldAlias, string aliasJoin, string tableName)
    {

        if (objRep.Distinct)
        {
            switch (order)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    {
                        return ("Temp.[" + fieldAlias + "], ");
                    }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                    {
                        return ("Temp.[" + fieldAlias + "] Asc, ");
                    }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    {
                        return ("Temp.[" + fieldAlias + "] Desc, ");
                    }
            }
        }
        else
        {
            if (aliasJoin != "")
            {
                switch (order)
                {
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                        {
                            return SetFieldFunction(funcion, aliasJoin + "." + fieldWithoutFunction) + ", ";
                        }
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                        {
                            return SetFieldFunction(funcion, aliasJoin + "." + fieldWithoutFunction) + " Asc, ";
                        }
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                        {
                            return SetFieldFunction(funcion, aliasJoin + "." + fieldWithoutFunction) + " Desc, ";
                        }
                }
            }
            else
            {
                switch (order)
                {
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                        {
                            return SetFieldFunction(funcion, tableName + "." + fieldWithoutFunction) + ", ";
                        }
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                        {
                            return SetFieldFunction(funcion, tableName + "." + fieldWithoutFunction) + " Asc, ";
                        }
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                        {
                            return SetFieldFunction(funcion, tableName + "." + fieldWithoutFunction) + " Desc, ";
                        }
                }
            }
        }
        return string.Empty;
        //----------------------------------------------------------------------                 
    }

    string SetOrderByRank(TTReportes.TTReportsConfigurationsEnumOrderBy order, TTReportes.TTReportsConfigurationsEnumfunctions funcion,
        string fieldWithoutFunction, string fieldAlias, string aliasJoin, string tableName, TTReportes.TTReportsConfigurationsEnumFormatDate dateFormat)
    {
        if (objRep.Distinct)
        {
            switch (order)
            {
                case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                    {
                        return ("Temp.[" + fieldAlias + "], ");
                    }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                    {
                        return ("Temp.[" + fieldAlias + "] Asc, ");
                    }
                case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                    {
                        return ("Temp.[" + fieldAlias + "] Desc, ");
                    }
            }
        }
        else
        {
            if (dateFormat != TTReportes.TTReportsConfigurationsEnumFormatDate.None || dateFormat != null)
            {
                switch (order)
                {
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                        {
                            return SetFieldFunction(funcion, fieldWithoutFunction) + ", ";
                        }
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                        {
                            return SetFieldFunction(funcion, fieldWithoutFunction) + " Asc, ";
                        }
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                        {
                            return SetFieldFunction(funcion, fieldWithoutFunction) + " Desc, ";
                        }
                }
            }
            else
            {
                if (aliasJoin != "")
                {
                    switch (order)
                    {
                        case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                            {
                                return SetFieldFunction(funcion, aliasJoin + "." + fieldWithoutFunction) + ", ";
                            }
                        case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                            {
                                return SetFieldFunction(funcion, aliasJoin + "." + fieldWithoutFunction) + " Asc, ";
                            }
                        case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                            {
                                return SetFieldFunction(funcion, aliasJoin + "." + fieldWithoutFunction) + " Desc, ";
                            }
                    }
                }
                else
                {
                    switch (order)
                    {
                        case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                            {
                                return SetFieldFunction(funcion, tableName + "." + fieldWithoutFunction) + ", ";
                            }
                        case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                            {
                                return SetFieldFunction(funcion, tableName + "." + fieldWithoutFunction) + " Asc, ";
                            }
                        case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                            {
                                return SetFieldFunction(funcion, tableName + "." + fieldWithoutFunction) + " Desc, ";
                            }
                    }
                }
            }
        }
        return string.Empty;
        //----------------------------------------------------------------------                 
    }

    private void SetColRange(int? rango, string fieldWithoutFunction, ref string joins, ref string fieldName)
    {
        if (rango != null)
        {
            String innerToRange = " Left Join TTRango_de_Presentacion as TTRango_de_Presentacion" + fieldWithoutFunction + " on TTRango_de_Presentacion" + fieldWithoutFunction + ".Folio = " + rango.ToString() +
                           "Left join TTRango_de_Presentacion_Detalle as TTRango_de_Presentacion_Detalle" + fieldWithoutFunction + " on " +
                           "TTRango_de_Presentacion_Detalle" + fieldWithoutFunction + ".FolioRango = TTRango_de_Presentacion" + fieldWithoutFunction + ".Folio and " + fieldName + " between " +
                           "TTRango_de_Presentacion_Detalle" + fieldWithoutFunction + ".Valor_Inicial and TTRango_de_Presentacion_Detalle" + fieldWithoutFunction + ".Valor_Final ";
            joins += innerToRange;
            fieldName = "TTRango_de_Presentacion_Detalle" + fieldWithoutFunction + ".Descripcion";
        }
    }

    private void SetGroupBy()
    {
        // Create GroupBys
        // Checamos que exista por lo menos alguna funcion
        // o un subtotal para Crear los groupby
        Boolean containFunction = false;
        //Checamos si existe alguna columna con Funcion
        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
            if (col.Funciones != TTReportes.TTReportsConfigurationsEnumfunctions.None)
            {
                containFunction = true;
                break;
            }
        foreach (TTReportes.objectBussinessTTReportes_Columnas col in objRep.ColumnasId)
        {
            if ((containFunction || col.Subtotal) && col.Funciones == TTReportes.TTReportsConfigurationsEnumfunctions.None)
            {
                String sAliasJoin = "";
                String myJoin = "";

                myJoin = DBJoin(col.FullPathDT, sJoins);
                sAliasJoin = DBTableAlias(col.FullPathDT);

                string TotalJoin, ActualJoin;
                TotalJoin = sJoins.ToLower().Trim();
                ActualJoin = myJoin.ToLower().Trim();

                if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                    sJoins = myJoin;
                else if (!TotalJoin.Contains(ActualJoin))
                    sJoins += myJoin;

                col.IsGroup = true;
                String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
                //----------------------------------------------------------
                sFieldWithoutFunction = DBField(col.FullPathDT); //myFunctions.GenerateName(Dt.Nombre);
                sTableName = DBTable(col.FullPathDT); // myFunctions.GenerateName(Dt.NombreTabla);
                //----------------------------------------------------------
                SetFieldName(sAliasJoin, ref sFieldName, col.Format, sTableName, sFieldWithoutFunction);

                SetColRange(col.Rango, sFieldWithoutFunction, ref sJoins, ref sFieldName);


                //if (sGroupBy != string.Empty && sFieldName != string.Empty)
                //{
                //    int contador = ContainsCount(sGroupBy.ToLower(), sFieldName.ToLower());
                //    contador = contador / 2 + 1;
                //    if (contador > 1)
                //        sFieldName += contador.ToString();
                //}
                sGroupBy += sFieldName + ", ";
                switch (col.OrderBy)
                {
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.None:
                        sOrderBy += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        break;
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.Ascendente:
                    case TTReportes.TTReportsConfigurationsEnumOrderBy.descendente:
                        sOrderByPrincipal += SetOrderByRank(col.OrderBy, col.Funciones, sFieldWithoutFunction, col.Text, sAliasJoin, sTableName);
                        sGroupBy += " convert(nvarchar," + (sAliasJoin != "" ? sAliasJoin : sTableName) + "." + sFieldWithoutFunction + ",112), ";
                        break;
                }
                //sSelect += sFieldName + ", ";
            }
        }
        if (sGroupBy != "")
            sGroupBy = " Group By " + sGroupBy.Substring(0, sGroupBy.Length - 2);

        if (sOrderByPrincipal != "")
            sOrderBy = " Order By " + sOrderByPrincipal.Substring(0, sOrderByPrincipal.Length - 2);
        else if (sOrderBy != string.Empty)
            sOrderBy = " Order By " + sOrderBy.Substring(0, sOrderBy.Length - 2);

        if (sWhere != "")
            sWhere = " Where " + sWhere;
        if (objRep.Distinct)
            sDistinct = " Distinct ";
        if (objRep.TopList.HasValue)
            if (objRep.TopList.Value != 0)
                sTop = " Top " + objRep.TopList.ToString() + " ";
    }

    public string SetQueryDetails(TTReportes.objectBussinessTTReportes objRep)
    {
        sSelect = sSelectWithAlias = sJoins = sGroupBy = sWhere = sOrderBy = sOrderByRank = sOrderByPrincipal = sDistinct = sTop = sHaving = sFrom = sJoinsFilter = string.Empty;
        //-------------------------------------------------------------
        myMetadata = new TTMetadata.Metadata(objRep.GlobalInformation);
        //---------------------------
        SetWhereFromStoredProcedure();
        SetWhereFromFilterDetails();
        //---------------------------
        SetSelectFromObjectColumns();
        //---------------------------
        if (!sJoins.Contains(sJoinsFilter))
            sJoins += sJoinsFilter;
        SetGroupBy();
        //---------------------------
        TTMetadata.MetadataDatosDNT myDNT = myMetadata.GetDNTs(objRep.ProcesoId.Value);
        //-----------------------------------------------------------------------        
        //if (sOrderBy.ToLower().Contains("asc"))
        //    sOrderByRank = string.Format("ORDER BY {0} ASC", sOrderByRank);
        //else if (sOrderBy.ToLower().Contains("desc"))
        //    sOrderByRank = string.Format("ORDER BY {0} DESC", sOrderByRank);
        //else
        sOrderByRank = string.Format("ORDER BY {0}", sOrderByRank);
        //-----------------------------------------------------------------------
        string sQuery = string.Empty;

        //----Si la consulta tiene un top....--------
        if (objRep.TopList != null && objRep.TopList != 0)
        {
            sFrom = " From " + myFunctions.GenerateName(myDNT.Nombre) + " With(NoLock) " + sJoins + " " + sWhere + " " + sGroupBy + " " + sOrderBy;
            sQuery = "Select {0} {1} {2} ";
            sQuery = string.Format(sQuery, sDistinct, sTop, sSelectWithAlias + sFrom);

            queryCount = "Select count(*) from ({0}) as TableCount";
            queryCount = string.Format(queryCount, sQuery);
        }
        //----Sino aplicar paginacion ---------------
        else
        {
            sFrom = " From " + myFunctions.GenerateName(myDNT.Nombre) + " With(NoLock) " + sJoins + " " + sWhere + " " + sGroupBy;

            queryCount = "Select count(*) from ({0}) as TableCount";
            queryCount = string.Format(queryCount, "Select " + sDistinct + sTop + sSelectWithAlias + " From " + myFunctions.GenerateName(myDNT.Nombre) + " With(NoLock) " + sJoins + " " + sWhere + " " + sGroupBy);

            if (objRep.Distinct)
            {
                sQuery = "Select {0} {1} {2} ";
                sQuery = string.Format(sQuery, sDistinct, sTop, sSelectWithAlias + sFrom);
                sQuery = string.Format(sPagingTemplateDistict, sOrderByRank, sQuery, currentPageIndex, pageSize);
            }
            else
            {
                //queryCount = "Select " + sDistinct + sTop + " Count(*) From " + myFunctions.GenerateName(myDNT.Nombre) + " With(NoLock) " + sJoins + " " + sWhere + " " + sGroupBy;
                //sQuery = string.Format(sPagingTemplate, sDistinct, sTop, sOrderByRank, sSelectWithAlias + sFrom, currentPageIndex, pageSize);
                sQuery = string.Format("Select " + sSelectWithAlias + sFrom + " " + (sOrderByPrincipal != string.Empty ? sOrderByRank : ""));
            }
        }
        sQuery = ClearCampoRelationXstore(sQuery);
        return sQuery;
    }

    #endregion
    #region LeftJoins

    private String Leftjoin(int DTIDOrigen, int DTIDDestiny, int? DTIDOrigenRelation, out String sAlias)
    {
        //DTIDOrigenRelation  si se uso un Alias en el LEFT anterior
        TTMetadata.Metadata myMetadata = new TTMetadata.Metadata(MyUserData);
        TTMetadata.MetadataDatos myDataOrig = myMetadata.GetDatosDT(DTIDOrigen);
        TTMetadata.MetadataDatos myDataDest = myMetadata.GetDatosDT(DTIDDestiny);

        //si destino pertenece a  multirenglon
        String nameTableOrigen;
        String FieldIdentyOrigen;
        String Fieldalias;
        if (myMetadata.GetTypeDT(myDataOrig.DatoID.Value) == TTMetadata.TTMetadataTypeData.MultiRenglon)
        {
            //Multi
            nameTableOrigen = myFunctions.GenerateName(myDataOrig.NombreTabla);
            FieldIdentyOrigen = myFunctions.GenerateName(myMetadata.FieldIdent(myDataOrig.DNTID.Value).Nombre);
            Fieldalias = myFunctions.GenerateName(myDataOrig.Nombre);
        }
        else
        {
            //Depe
            nameTableOrigen = myFunctions.GenerateName(myDataOrig.NombreTabla);
            FieldIdentyOrigen = myFunctions.GenerateName(myDataOrig.Nombre);
            Fieldalias = myFunctions.GenerateName(myDataOrig.Nombre);
        }

        String nameTableDestiny = myFunctions.GenerateName(myDataDest.NombreTabla);
        String FieldIdentyDestiny = myFunctions.GenerateName(myMetadata.FieldIdent(myDataDest.DNTID.Value).Nombre);
        sAlias = nameTableDestiny + "_" + Fieldalias;// +"_";
        //sAlias = nameTableOrigen + "_" + Fieldalias;// +"_";
        if (DTIDOrigenRelation.HasValue)
        {
            TTMetadata.MetadataDatos myDataOrigRel = myMetadata.GetDatosDT(DTIDOrigenRelation.Value);
            TTMetadata.MetadataDatos myDataOrigRelT = myMetadata.GetDatosDT(myDataOrigRel.DependienteClave.Value);
            return " Left Join " + nameTableDestiny + " as " + sAlias + " With(NoLock) on " + sAlias + "." + FieldIdentyDestiny + " = " + myFunctions.GenerateName(myDataOrigRelT.NombreTabla) + "_" + myFunctions.GenerateName(myDataOrigRel.Nombre) + "." + FieldIdentyOrigen;
        }
        else
            return " Left Join " + nameTableDestiny + " as " + sAlias + " With(NoLock) on " + sAlias + "." + FieldIdentyDestiny + " = " + nameTableOrigen + "." + FieldIdentyOrigen;
    }
    #endregion

    #region Fields&Alias

    //---------------------------------------------------------------------------
    private string DBField(string FullPathDT)
    {
        MyDTs = myFunctions.ReturnInArray(FullPathDT, ".");
        string returnValue = string.Empty;
        int? dntid;
        ReportItemDBInfo item;
        //Si contiene al menos un valor ...
        if (MyDTs.Count > 0)
        {
            if (MyDTs.Count > 1)
            {
                //----------------------------------------------------------------
                dntid = myFunctions.FormatNumberNull(MyDTs[MyDTs.Count - 1].ToString());
                item = new ReportItemDBInfo(dntid);
                //----------------------------------------------------------------
                returnValue = item.DBField;
            }
            else
            {
                //----------------------------------------------------------------
                dntid = myFunctions.FormatNumberNull(MyDTs[0].ToString());
                item = new ReportItemDBInfo(dntid);
                //----------------------------------------------------------------
                returnValue = item.DBField;
            }
        }
        return returnValue;
    }

    private string DBTable(string FullPathDT)
    {
        MyDTs = myFunctions.ReturnInArray(FullPathDT, ".");
        string returnValue = string.Empty;
        int? dntid;
        ReportItemDBInfo item;
        //Si contiene al menos un valor ...
        if (MyDTs.Count > 0)
        {
            if (MyDTs.Count > 1)
            {
                //----------------------------------------------------------------
                dntid = myFunctions.FormatNumberNull(MyDTs[MyDTs.Count - 1].ToString());
                item = new ReportItemDBInfo(dntid);
                //----------------------------------------------------------------
                returnValue = item.DBTable;
            }
            else
            {
                //----------------------------------------------------------------
                dntid = myFunctions.FormatNumberNull(MyDTs[0].ToString());
                item = new ReportItemDBInfo(dntid);
                //----------------------------------------------------------------
                returnValue = item.DBField;
            }
        }
        return returnValue;
    }

    private string DBTableAlias(string FullPathDT)
    {
        MyDTs = myFunctions.ReturnInArray(FullPathDT, ".");
        string returnValue = string.Empty;
        int? dntid;
        ReportItemDBInfo item = new ReportItemDBInfo();
        //Si contiene al menos un valor ...
        if (MyDTs.Count > 0)
        {
            if (MyDTs.Count > 1)
                for (int i = 1; i < MyDTs.Count - 1; i++)
                {
                    //----------------------------------------------------------------
                    dntid = myFunctions.FormatNumberNull(MyDTs[i].ToString());
                    item = new ReportItemDBInfo(dntid);
                    item.DBTableAlias += (
                            item.DBTable + "_"
                            + item.DBRelTable);
                    //----------------------------------------------------------------
                    if (returnValue == string.Empty)
                        returnValue = item.DBTableAlias;
                    else
                        returnValue += ("_" + item.DBRelTable);
                }
        }
        //if (returnValue != string.Empty && sJoins != string.Empty)
        //{
        //    int contador = ContainsCount(returnValue.ToLower(), sJoins.ToLower());
        //    contador = contador / 2 + 1;
        //    if (contador > 1)
        //        returnValue += contador.ToString();
        //}
        return returnValue;
    }
    private string DBJoin(string FullPathDT, string sJoin)
    {
        MyDTs = myFunctions.ReturnInArray(FullPathDT, ".");
        string returnValue = string.Empty;
        string previousAlias = string.Empty;
        string currentAlias = string.Empty;
        string currentJoin = string.Empty;
        int? dntid, dntidRel;
        int contador = 0;
        string CampoRel = "";
        ReportItemDBInfo item = new ReportItemDBInfo();
        //Si contiene al menos un valor ...
        if (MyDTs.Count > 0)
        {
            if (MyDTs.Count > 1)
                for (int i = 1; i < MyDTs.Count - 1; i++)
                {
                    CampoRel = "";
                    dntid = myFunctions.FormatNumberNull(MyDTs[i].ToString());
                    dntidRel = myFunctions.FormatNumberNull(MyDTs[i + 1].ToString());
                    //------------------------------------------------------------------
                    myMetadata = new TTMetadata.Metadata(MyUserData);
                    TTMetadata.MetadataDatos dt = myMetadata.GetDatosDT(int.Parse(dntid.Value.ToString()));
                    if (dt != null)
                        if (dt.Dependiente)//Si es multirenglon evitar el ciclo
                            dntidRel = myFunctions.FormatNumberNull(dt.DependienteClave.ToString());
                    //------------------------------------------------------------------
                    TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
                    TTMetadata.MetadataDatos myMetaDatos = myMeta.GetDatosDT(dntid.Value);
                    item = new ReportItemDBInfo(dntid, dntidRel);

                    if (myMeta.GetTypeDT(myMetaDatos.DatoID.Value) == TTMetadata.TTMetadataTypeData.MultiRenglon)
                    {
                        TTMetadata.MetadataDatos[] datos = myMeta.GetDatosDNT(int.Parse(dt.DependienteTabla.ToString()));

                        for (int j = 0; j <= datos.Length - 1; j++)
                        {
                            if (datos[j].Identificador && datos[j].Dependiente)
                                CampoRel = myFunctions.GenerateName(datos[j].Nombre);
                        }
                    }
                    item.DBTableAlias += (
                        (currentAlias == string.Empty ? item.DBTable : (contador > 0 ? currentAlias.Substring(0, currentAlias.Length - contador.ToString().Length) : currentAlias)) + "_"
                            + item.DBRelTable);
                    //----------------------------------------------------------------
                    previousAlias = (currentAlias == string.Empty ? item.DBTable : currentAlias);

                    currentAlias = (contador > 0 ? currentAlias.Substring(0, currentAlias.Length - contador.ToString().Length) : currentAlias);
                    if (returnValue == string.Empty)
                        currentAlias = item.DBTableAlias;
                    else
                        currentAlias += ("_" + item.DBRelTable);

                    contador = ContainsCount(" " + currentAlias.ToLower() + " ", sJoin.ToLower());
                    //contador = contador / 2 + 1;
                    if (contador > 0)
                        currentAlias += contador.ToString();

                    if (CampoRel == "")
                    {
                        currentJoin = (" Left Join " + item.DBRelTable + " as " + currentAlias + " With(NoLock) on "
                            + currentAlias + "." + item.DBRelKeyField + " = "
                            + previousAlias + "." + item.DBField);
                    }
                    else
                    {
                        currentJoin = (" Left Join " + item.DBRelTable + " as " + currentAlias + " With(NoLock) on "
                            + currentAlias + "." + CampoRel + " = "
                            + previousAlias + "." + item.DBField);
                    }

                    if (!sJoin.ToLower().Trim().Contains(currentJoin.ToLower().Trim()))
                        returnValue += currentJoin;
                    //----------------------------------------------------------------
                }
        }
        return returnValue;
    }

    //---------------------------------------------------------------------------
    #endregion

    public Int32 ContainsCount(String SearchPhrase, String SearchText)
    {
        String Remains = SearchText;
        Int32 NewIndex = 0;
        Int16 Count = 0;
        while (Remains.Length >= SearchPhrase.Length)
        {
            NewIndex = Remains.IndexOf(SearchPhrase);

            if (NewIndex >= 0)
            {
                Count++;
                Remains = Remains.Substring(NewIndex + SearchPhrase.Length);
            }
            else
            {
                return Count;
            }
        }
        return Count;
    }

}
//------------------------------------------------------------------------------
public class ReportItemDBInfo
{
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
    private TTSecurity.GlobalData MyUserData
    {
        get { return System.Web.HttpContext.Current.Session["UserGlobalInformation"] as TTSecurity.GlobalData; }
    }
    //--------------------------------------------------------------------------
    private string dbField = string.Empty;
    private string dbTable = string.Empty;
    private string dbTableAlias = string.Empty;

    private string dbRelKeyField = string.Empty;
    private string dbRelTable = string.Empty;

    private int? dntid;
    //--------------------------------------------------------------------------
    public string DBField
    {
        get { return dbField; }
        set { dbField = value; }
    }

    public string DBTable
    {
        get { return dbTable; }
        set { dbTable = value; }
    }

    public string DBTableAlias
    {
        get { return dbTableAlias; }
        set { dbTableAlias = value; }
    }
    public string DBRelKeyField
    {
        get { return dbRelKeyField; }
        set { dbRelKeyField = value; }
    }
    public string DBRelTable
    {
        get { return dbRelTable; }
        set { dbRelTable = value; }
    }
    //--------------------------------------------------------------------------
    public ReportItemDBInfo()
    { }

    public ReportItemDBInfo(int? dntid)
    {
        this.dntid = dntid;

        TTMetadata.Metadata myMetadata = new TTMetadata.Metadata(MyUserData);
        TTMetadata.MetadataDatos dt = myMetadata.GetDatosDT(int.Parse(dntid.Value.ToString()));
        if (dt != null)
        {
            dbTable = myFunctions.GenerateName(dt.NombreTabla);
            dbField = myFunctions.GenerateName(dt.Nombre);

            if (dt.Dependiente)//Si es multirenglon evitar el ciclo
            {
                dt = myMetadata.GetDatosDT(int.Parse(dt.DependienteClave.Value.ToString()));
                dbRelKeyField = myFunctions.GenerateName(dt.Nombre);
                dbRelTable = myFunctions.GenerateName(dt.NombreTabla);
            }
        }
    }

    public ReportItemDBInfo(int dtid)
    {
        TTMetadata.Metadata myMetadata = new TTMetadata.Metadata(MyUserData);
        TTMetadata.MetadataDatosDNT dnt = myMetadata.GetDNT(dtid);
        if (dnt != null)
        {
            dbTable = myFunctions.GenerateName(dnt.Nombre);
        }
    }

    public ReportItemDBInfo(int? dntIdOrigen, int? dntIdDestino)
    {
        this.dntid = dntIdDestino;

        TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
        TTMetadata.MetadataDatos myMetaDatos = myMeta.GetDatosDT(dntIdOrigen.Value);
        //---------------- Obtiene la llave del dependiente antes de entrar al detalle... ----------------
        TTMetadata.MetadataDatos myDataDestino = myMeta.GetDatosDT(dntIdDestino.Value);

        dbRelTable = myFunctions.GenerateName(myDataDestino.NombreTabla);
        dbTable = myFunctions.GenerateName(myMetaDatos.NombreTabla);

        //Multirenglon
        if (myMeta.GetTypeDT(myMetaDatos.DatoID.Value) == TTMetadata.TTMetadataTypeData.MultiRenglon)
            dbField = myFunctions.GenerateName(myMeta.FieldIdent(myMetaDatos.DNTID.Value).Nombre);
        //Dependiente
        else
            dbField = myFunctions.GenerateName(myMetaDatos.Nombre); //Function.GenerateName(myDataDestino.Nombre)

        //------------------------------------------------------------------------------------------------
        if (myDataDestino.Identificador)
        {
            dbRelKeyField = myFunctions.GenerateName(myDataDestino.Nombre);
        }
        else
        {
            dbRelKeyField = myFunctions.GenerateName(myMeta.FieldIdent(myDataDestino.DNTID.Value).Nombre);
        }
        //------------------------------------------------------------------------------------------------
    }

}







