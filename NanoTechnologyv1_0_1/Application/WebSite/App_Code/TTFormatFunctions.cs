using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Data;
using Winnovative.WnvHtmlConvert;
using System.IO;


using System.Text;

using Winnovative.WnvHtmlConvert.PdfDocument;
using System.Drawing;

public class TTFormatFunctions
{
    private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
    private System.Collections.ArrayList MyDTs;
    private TTMetadata.Metadata myMetadata;
    private TTSecurity.GlobalData MyUserData
    {
        get { return System.Web.HttpContext.Current.Session["UserGlobalInformation"] as TTSecurity.GlobalData; }
    }
    string sJoins, sSelectWithAlias, sFrom, sWhere;

    public TTFormatFunctions()
    {

    }
    public string SetQueryDetails(TTFormatosCS.objectBussinessTTFormatos objFormato, string IdMovimiento)
    {
        sWhere = sSelectWithAlias = sJoins = sFrom = string.Empty;
        //-------------------------------------------------------------
        myMetadata = new TTMetadata.Metadata(MyUserData);
        //---------------------------

        //---------------------------
        List<TTFormatosCS.TTFormatsVariables> listado = new List<TTFormatosCS.TTFormatsVariables>();
        SetSelectFromObjectColumns(objFormato.VariablesCabecero);
        SetSelectFromObjectColumns(objFormato.VariablesFormato);
        SetSelectFromObjectColumns(objFormato.VariablesPie);

        string sQuery = string.Empty;

        if (sSelectWithAlias.Length > 0)
        {
            sSelectWithAlias = sSelectWithAlias.Substring(0, sSelectWithAlias.Length - 1);
            //---------------------------

            //---------------------------
            TTMetadata.MetadataDatosDNT myDNT = myMetadata.GetDNTs(objFormato.ProcesoId.Value);
            sWhere = " Where ";

            string table = myFunctions.GenerateName(myDNT.Nombre);

            TTMetadata.MetadataDatos dato = myMetadata.GetDatosDNT(myDNT.DNTID.Value).Where(x => x.Identificador == true).FirstOrDefault();

            sWhere += table + "." + myFunctions.GenerateName(dato.Nombre) + "=" + IdMovimiento;
            //-----------------------------------------------------------------------        

            //-----------------------------------------------------------------------

            sFrom = " From " + table + " With(NoLock) " + sJoins + " " + sWhere;
            sQuery = "SET LANGUAGE spanish  Select {0} ";
            sQuery = string.Format(sQuery, sSelectWithAlias + sFrom);
        }
        return sQuery;
    }

    private void SetSelectFromObjectColumns(List<TTFormatosCS.TTFormatsVariables> Lista)
    {

        foreach (TTFormatosCS.TTFormatsVariables col in Lista)
        {
            if (!col.ID.Contains("@@"))
            {
                //--------------------------------------------------------------------------
                String sAliasJoin = "";
                String myJoin = "";

                myJoin = DBJoin(col.ID, sJoins);
                sAliasJoin = DBTableAlias(col.ID);

                string TotalJoin, ActualJoin;
                TotalJoin = sJoins.ToLower().Trim();
                ActualJoin = myJoin.ToLower().Trim();

                if (!TotalJoin.Contains(ActualJoin) && ActualJoin.Contains(TotalJoin))
                    sJoins = myJoin;
                else if (!TotalJoin.Contains(ActualJoin))
                    sJoins += myJoin;

                String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
                //----------------------------------------------------------
                sFieldWithoutFunction = DBField(col.ID);
                sTableName = DBTable(col.ID);
                //----------------------------------------------------------
                SetFieldName(sAliasJoin, ref sFieldName, col, sTableName, sFieldWithoutFunction);

                //sSelect += SetFieldFunction(col.Funciones, sFieldName) + ", ";
                //sSelectWithAlias += SetFieldFunction(col.Funciones, sFieldName, col.Text) + ", ";
                sSelectWithAlias += string.Format("{0} as [{1}]", sFieldName, col.ID);
                sSelectWithAlias = sSelectWithAlias + ",";
            }
            else
            {
                String sFieldName = "", sFieldWithoutFunction = String.Empty, sTableName = String.Empty;
                switch (col.ID)
                {
                    case "@@Fecha@@":
                        sFieldName = ExtractFormatToField(col, "GETDATE()");
                        sSelectWithAlias += string.Format("{0} as [{1}]", sFieldName, col.ID);
                        sSelectWithAlias = sSelectWithAlias + ",";
                        break;
                    case "@@Hora@@":
                        sFieldName = ExtractFormatToField(col, "SUBSTRING(CONVERT(NVARCHAR,GETDATE(),108),0,6)");
                        sSelectWithAlias += string.Format("{0} as [{1}]", sFieldName, col.ID);
                        sSelectWithAlias = sSelectWithAlias + ",";
                        break;
                    case "@@Numero_Pagina@@":
                        //sFieldName = ExtractFormatToField(col, "1");
                        //sSelectWithAlias += string.Format("{0} as [{1}]", sFieldName, col.ID);
                        //sSelectWithAlias = sSelectWithAlias + ",";
                        break;
                    case "@@Usuario@@":
                        sFieldName = ExtractFormatToField(col, "'" + ((TTSecurity.GlobalData)HttpContext.Current.Session["UserGlobalInformation"]).UserName + "'");
                        sSelectWithAlias += string.Format("{0} as [{1}]", sFieldName, col.ID);
                        sSelectWithAlias = sSelectWithAlias + ",";
                        break;
                };
            }
        }
    }

    private string DBJoin(string FullPathDT, string sJoin)
    {
        MyDTs = myFunctions.ReturnInArray(FullPathDT, ".");
        string returnValue = string.Empty;
        string previousAlias = string.Empty;
        string currentAlias = string.Empty;
        string currentJoin = string.Empty;
        int? dntid, dntidRel;
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
                            (currentAlias == string.Empty ? item.DBTable : currentAlias) + "_"
                            + item.DBRelTable);
                    //----------------------------------------------------------------
                    previousAlias = (currentAlias == string.Empty ? item.DBTable : currentAlias);

                    if (returnValue == string.Empty)
                        currentAlias = item.DBTableAlias;
                    else
                        currentAlias += ("_" + item.DBRelTable);

                    //currentJoin = (" Left Join " + item.DBRelTable + " as " + currentAlias + " With(NoLock) on "
                    //    + currentAlias + "." + item.DBRelKeyField + " = "
                    //    + previousAlias + "." + item.DBField);

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
        return returnValue;
    }

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

    public void SetFieldName(string aliasJoin, ref string fieldName, TTFormatosCS.TTFormatsVariables format,
       string tableName, string fieldWithoutFunction)
    {
        if (aliasJoin != "")
            fieldName = ExtractFormatToField(format, aliasJoin + "." + fieldWithoutFunction);
        else
            fieldName = ExtractFormatToField(format, tableName + "." + fieldWithoutFunction);
    }

    private string ExtractFormatToField(TTFormatosCS.TTFormatsVariables Format, String Field)
    {
        String result = "";
        if (Format.Fecha != null)
        {
            result = FormatSQLDate(Format.Fecha.Posicion1, Field) + " + '" + Format.Fecha.Separador1 + "' + " + FormatSQLDate(Format.Fecha.Posicion2, Field) + " + '" + Format.Fecha.Separador2 + "' + " + FormatSQLDate(Format.Fecha.Posicion3, Field);
        }
        else if (Format.Hora != null)
        {
            if (Format.Hora.Formato == TTFormatosCS.TTFormatsConfigurationsEnumTimeFormat.AM_PM)
                result = "CONVERT(VARCHAR,CONVERT(TIME," + Field + "),100)";
            else
                result = Field;
        }
        else if (Format.Moneda != null)
        {
            if (Format.Moneda.Limitar == TTFormatosCS.TTFormatsConfigurationsEnumCurrencyLimit.Redondeo)
                result = "'" + Format.Moneda.Simbolo + "' + SUBSTRING(CONVERT(NVARCHAR(50),ROUND(" + Field + "," + Format.Moneda.Decimales.ToString() + ", 0)),0,CHARINDEX('.',CONVERT(NVARCHAR(50),ROUND(" + Field + "," + Format.Moneda.Decimales.ToString() + ", 0)))+1) + SUBSTRING(CONVERT(NVARCHAR(50),ROUND(" + Field + "," + Format.Moneda.Decimales.ToString() + ", 0)),CHARINDEX('.',CONVERT(NVARCHAR(50),ROUND(" + Field + "," + Format.Moneda.Decimales.ToString() + ", 0)))+1,1)";
            else
                result = "'" + Format.Moneda.Simbolo + "' + SUBSTRING(CONVERT(NVARCHAR(50),ROUND(" + Field + "," + Format.Moneda.Decimales.ToString() + ", 1)),0,CHARINDEX('.',CONVERT(NVARCHAR(50),ROUND(" + Field + "," + Format.Moneda.Decimales.ToString() + ", 1)))+1) + SUBSTRING(CONVERT(NVARCHAR(50),ROUND(" + Field + "," + Format.Moneda.Decimales.ToString() + ", 1)),CHARINDEX('.',CONVERT(NVARCHAR(50),ROUND(" + Field + "," + Format.Moneda.Decimales.ToString() + ", 1)))+1,"+Format.Moneda.Decimales.ToString()+")";
        }
        else if (Format.Numero != null)
        {
            if (Format.Numero.Letra)
                result = "dbo.CantidadConLetra(" + Field + ")";
            else
                result = Field;
        }
        else if (Format.Texto != null)
        {
            if (Format.Texto.Caracteres > 0)
                result = "SUBSTRING(" + Field + ",0," + (Format.Texto.Caracteres + 1).ToString() + ")";
            else
                result = Field;
        }
        else
        {
            result = Field;
        }
        return result;
    }

    private string FormatSQLDate(TTFormatosCS.TTFormatsConfigurationsEnumDatePositions Posicion, string Field)
    {
        switch (Posicion)
        {
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.Vacio:
                return "";
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.DD:
                return "REPLACE(STR(DATEPART(dd," + Field + "), 2),SPACE(1),'0')";
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.Dia_Letra:
                return "dbo.CantidadConLetra(DATEPART(dd," + Field + "))";
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.MM:
                return "REPLACE(STR(DATEPART(mm," + Field + "), 2),SPACE(1),'0')";
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.MMM:
                return "SUBSTRING(CONVERT(NVARCHAR," + Field + ",107),0,4)";
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.Mes_Letra:
                return "UPPER(DATENAME(mm," + Field + "))";
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.AA:
                return "SUBSTRING(RTRIM(LTRIM(STR(DATEPART(YEAR," + Field + ")))),3,2)";
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.AAAA:
                return "LTRIM(RTRIM(STR(DATEPART(YEAR," + Field + "))))";
            case TTFormatosCS.TTFormatsConfigurationsEnumDatePositions.Año_Letra:
                return "dbo.CantidadConLetra(DATEPART(YEAR," + Field + "))";
            default:
                return "";
        };
    }

    /// <summary>
    /// Convert the specified HTML string to a PDF document and send the 
    /// document as an attachment to the browser
    /// </summary>
    public static byte[] ConvertHTMLStringToPDF(string formato, string cabecero, string pie)
    {
        string htmlString = "<head></head><body>" + formato.Replace("@@@@Numero_Pagina@@@@", "<label id='npag'>@@@@Numero_Pagina@@@@</label>") + "</body>";
        string baseURL = Funcion.BaseSiteUrl;

        // Create the PDF converter. Optionally you can specify the virtual browser 
        // width as parameter. 1024 pixels is default, 0 means autodetect
        PdfConverter pdfConverter = new PdfConverter();
        // set the license key
        pdfConverter.LicenseKey = "U3hhc2JzYmdhZnNrfWNzYGJ9YmF9ampqag==";
        // set the converter options
        pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.Custom;
        pdfConverter.PdfDocumentOptions.CustomPdfPageSize = new Size(612, 792);
        pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.NoCompression;
        pdfConverter.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;


        // set if header and footer are shown in the PDF - optional - default is false 
        pdfConverter.PdfDocumentOptions.ShowHeader = false;
        pdfConverter.PdfHeaderOptions.DrawHeaderLine = false;
        pdfConverter.PdfDocumentOptions.ShowFooter = false;
        pdfConverter.PdfFooterOptions.DrawFooterLine = false;
        // set to generate a pdf with selectable text or a pdf with embedded image - optional - default is true
        pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;
        // set if the HTML content is resized if necessary to fit the PDF page width - optional - default is true
        pdfConverter.PdfDocumentOptions.FitWidth = true;
        // 
        // set the embedded fonts option - optional - default is false
        pdfConverter.PdfDocumentOptions.EmbedFonts = false;
        // set the live HTTP links option - optional - default is true
        pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = true;

        // set if the JavaScript is enabled during conversion to a PDF with selectable text 
        // - optional - default is false
        pdfConverter.ScriptsEnabled = true;
        // set if the ActiveX controls (like Flash player) are enabled during conversion 
        // to a PDF with selectable text - optional - default is false
        pdfConverter.ActiveXEnabled = true;

        // set if the images in PDF are compressed with JPEG to reduce the PDF document size - optional - default is true
        pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = false;

        // enable auto-generated bookmarks for a specified list of tags (e.g. H1 and H2)
        //if (cbBookmarks.Checked)
        //{
        //    pdfConverter.PdfBookmarkOptions.TagNames = new string[] { "H1", "H2" };
        //}

        // set PDF security options - optional
        //pdfConverter.PdfSecurityOptions.CanPrint = true;
        //pdfConverter.PdfSecurityOptions.CanEditContent = true;
        //pdfConverter.PdfSecurityOptions.UserPassword = "";

        //set PDF document description - optional
        //pdfConverter.PdfDocumentInfo.AuthorName = "Winnovative HTML to PDF Converter";

        // add HTML header
        if (cabecero != "")
        	AddHeader(cabecero, pdfConverter, baseURL);
        // add HTML footer
	if (pie != "")
        	AddFooter(pie, pdfConverter, baseURL);

        //set the PDF document margins
        pdfConverter.PdfDocumentOptions.LeftMargin = 5;
        pdfConverter.PdfDocumentOptions.RightMargin = 5;
        pdfConverter.PdfDocumentOptions.TopMargin = 5;
        pdfConverter.PdfDocumentOptions.BottomMargin = 5;
        //pdfConverter.PdfDocumentOptions.TopMargin = int.Parse(textBoxTopMargin.Text.Trim());
        //pdfConverter.PdfDocumentOptions.BottomMargin = int.Parse(textBoxBottomMargin.Text.Trim());

        // in this sample we want the location of LABEL elements
        pdfConverter.HtmlElementsMappingOptions.HtmlTagNames = new string[] { "LABEL" };

        // Performs the conversion and get the pdf document bytes that you can further 
        // save to a file or send as a browser response
        //
        // The baseURL parameter helps the converter to get the CSS files and images
        // referenced by a relative URL in the HTML string. This option has efect only if the HTML string
        // contains a valid HEAD tag. The converter will automatically inserts a <BASE HREF="baseURL"> tag. 
        byte[] pdfBytes = null;
        if (baseURL.Length > 0)
            pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(htmlString, baseURL);
        else
            pdfBytes = pdfConverter.GetPdfBytesFromHtmlString(htmlString);

        HtmlElementMappingsCollection vars = pdfConverter.HtmlElementsMappingOptions.HtmlElementsMappingResult;

        htmlString = htmlString.Replace("<label id='npag'>@@@@Numero_Pagina@@@@</label>", "&nbsp;&nbsp;");
        Document pdfDocument;

        if (baseURL.Length > 0)
            pdfDocument = pdfConverter.GetPdfDocumentObjectFromHtmlString(htmlString, baseURL);
        else
            pdfDocument = pdfConverter.GetPdfDocumentObjectFromHtmlString(htmlString);

        foreach (HtmlElementMapping elementMapping in vars)
        {
            // because a HTML element can span over many PDF pages the mapping 
            // of the HTML element in PDF document consists in a list of rectangles,
            // one rectangle for each PDF page where this element was rendered
            foreach (HtmlElementPdfRectangle elementLocationInPdf in elementMapping.PdfRectangles)
            {
                if (elementMapping.HtmlElementText == "@@@@Numero_Pagina@@@@")
                {
                    // get the PDF page
                    PdfPage pdfPage = pdfDocument.Pages[elementLocationInPdf.PageIndex];
                    RectangleF pdfRectangleInPage = elementLocationInPdf.Rectangle;

                    TextElement pageNumberText = new TextElement(pdfRectangleInPage.X, pdfRectangleInPage.Y + float.Parse("0.5"), (elementLocationInPdf.PageIndex + 1).ToString(), pdfDocument.AddFont(new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 8, System.Drawing.GraphicsUnit.Point)));
                    pdfPage.AddElement(pageNumberText);
                }
            }
        }
        return pdfDocument.Save();
    }

    private static void AddHeader(string cabecero, PdfConverter pdfConverter, string BaseURL)
    {
        string headerAndFooterHtmlUrl = "<head></head><body>" + cabecero.Replace("@@@@Numero_Pagina@@@@", "<label id='npag'>@@@@Numero_Pagina@@@@</label>") + "</body>";

        PdfConverter convert = new PdfConverter();

        // in this sample we want the location of LABEL elements
        convert.HtmlElementsMappingOptions.HtmlTagNames = new string[] { "LABEL" };

        byte[] pdfBytes;
        if (BaseURL.Length > 0)
            pdfBytes = convert.GetPdfBytesFromHtmlString(headerAndFooterHtmlUrl, BaseURL);
        else
            pdfBytes = convert.GetPdfBytesFromHtmlString(headerAndFooterHtmlUrl);

        HtmlElementMappingsCollection vars = convert.HtmlElementsMappingOptions.HtmlElementsMappingResult;

        headerAndFooterHtmlUrl = headerAndFooterHtmlUrl.Replace("<label id='npag'>@@@@Numero_Pagina@@@@</label>", "&nbsp;&nbsp;");

        //enable header
        pdfConverter.PdfDocumentOptions.ShowHeader = true;
        // set the header height in points
        pdfConverter.PdfHeaderOptions.HeaderHeight = 60;
        // set the header HTML area
        pdfConverter.PdfHeaderOptions.HtmlToPdfArea = new HtmlToPdfArea(0, 0, headerAndFooterHtmlUrl, BaseURL);
        //pdfConverter.PdfHeaderOptions.HtmlToPdfArea.FitHeight = true;
        //pdfConverter.PdfHeaderOptions.HtmlToPdfArea.FitWidth = true;
        pdfConverter.PdfHeaderOptions.HtmlToPdfArea.EmbedFonts = false;


        foreach (HtmlElementMapping elementMapping in vars)
        {
            // because a HTML element can span over many PDF pages the mapping 
            // of the HTML element in PDF document consists in a list of rectangles,
            // one rectangle for each PDF page where this element was rendered
            foreach (HtmlElementPdfRectangle elementLocationInPdf in elementMapping.PdfRectangles)
            {
                if (elementMapping.HtmlElementText == "@@@@Numero_Pagina@@@@")
                {
                    RectangleF pdfRectangleInPage = elementLocationInPdf.Rectangle;

                    TextArea pageNumberText = new TextArea(pdfRectangleInPage.X, pdfRectangleInPage.Y, "&p;", new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 8, System.Drawing.GraphicsUnit.Point));
                    pdfConverter.PdfHeaderOptions.AddTextArea(pageNumberText);
                }
            }
        }

    }

    private static void AddFooter(string pie, PdfConverter pdfConverter, string BaseURL)
    {
        string thisPageURL = HttpContext.Current.Request.Url.AbsoluteUri;
        string headerAndFooterHtmlUrl = "<head></head><body>" + pie.Replace("@@@@Numero_Pagina@@@@", "<label id='npag'>@@@@Numero_Pagina@@@@</label>") + "</body>";

        //enable footer
        pdfConverter.PdfDocumentOptions.ShowFooter = true;
        // set the footer height in points
        pdfConverter.PdfFooterOptions.FooterHeight = 60;
        //write the page number
        //pdfConverter.PdfFooterOptions.TextArea = new TextArea(0, 30, "This is page &p; of &P;  ",
        //    new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 10, System.Drawing.GraphicsUnit.Point));
        //pdfConverter.PdfFooterOptions.TextArea.EmbedTextFont = true;
        //pdfConverter.PdfFooterOptions.TextArea.TextAlign = HorizontalTextAlign.Right;
        // set the footer HTML area
        pdfConverter.PdfFooterOptions.HtmlToPdfArea = new HtmlToPdfArea(0, 0, headerAndFooterHtmlUrl, BaseURL);
        pdfConverter.PdfFooterOptions.HtmlToPdfArea.FitHeight = true;
        pdfConverter.PdfFooterOptions.HtmlToPdfArea.EmbedFonts = false;
    }

    public static void GuardarPDF(int procesoid, byte[] pdfBytes, string idMovimiento, int DTID, TTSecurity.GlobalData MyUserData)
    {
        TTMetadata.Metadata myMeta = new TTMetadata.Metadata(MyUserData);
        string tabla = new TTFunctions.Functions().GenerateName(myMeta.GetAllDNTs(procesoid)[0].Nombre);
        string ruta = System.Web.HttpContext.Current.Server.MapPath(@"~\TempFiles\Formatos\") + tabla + Guid.NewGuid().ToString() + ".pdf";
        System.IO.File.WriteAllBytes(ruta, pdfBytes);

        int? m_id = Convert.ToInt32(idMovimiento);

        //Cargamos el ensamblado
        Assembly m_assembly = Assembly.LoadFrom(System.Web.HttpContext.Current.Server.MapPath(@"~\DLL") + @"\LibraryDLLObjectBusiness.dll");
        //Obtenemos el tipo de la clase

        Type m_type = m_assembly.GetType(tabla + "CS.objectBussiness" + tabla);
        //creamos la instancia
        object m_clase = Activator.CreateInstance(m_type);
        //Cargamos el metodo solicitado
        MethodInfo m = m_clase.GetType().GetMethod("GetByKey");

        object[] m_parametros = { m_id, true };
        //Pasamos los parametros al metodo y lo ejecutamos
        m.Invoke(m_clase, m_parametros);

        PropertyInfo pi = m_clase.GetType().GetProperty(new TTFunctions.Functions().GenerateName(myMeta.GetDatosDT(DTID).Nombre));
        if (pi != null)
        {
            pi.SetValue(m_clase, ruta, null);
            m = m_clase.GetType().GetMethod("Update");
            object[] m_parametros2 = { MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", 0) };
            m.Invoke(m_clase, m_parametros2);
        }
    }
}

//public class SBTextRenderer : IRenderListener 
//{
//    private System.util.RectangleJ textRectangle = null;
//    //private StringBuilder _builder; 
//    public SBTextRenderer()//StringBuilder builder) 
//    { 
//        //_builder = builder; 
//    } 
//    #region IRenderListener Members 

//    public void BeginTextBlock() 
//    { 
//    } 

//    public void EndTextBlock() 
//    { 
//    } 

//    public void RenderImage(ImageRenderInfo renderInfo) 
//    { 
//    } 

//    //public void RenderText(TextRenderInfo renderInfo) 
//    //{ 
//    //    _builder.Append(renderInfo.GetText()); 


//    //}

//    public void RenderText(TextRenderInfo renderInfo)
//    {
//        if (renderInfo.GetText().Contains("Numero_Pagina"))
//        {
//            if (textRectangle == null)
//                textRectangle = renderInfo.GetDescentLine().GetBoundingRectange();
//            else
//                textRectangle.Add(renderInfo.GetDescentLine().GetBoundingRectange());

//            textRectangle.Add(renderInfo.GetAscentLine().GetBoundingRectange());
//        }

//    }

//    /**
// * Getter for the left margin.
// * @return the X position of the left margin
// */
//    public float GetLlx()
//    {
//        if (textRectangle != null)
//            return textRectangle.X;
//        else
//            return 0;
//    }

//    /**
//     * Getter for the bottom margin.
//     * @return the Y position of the bottom margin
//     */
//    public float GetLly()
//    {
//        if (textRectangle != null)
//            return textRectangle.Y;
//        else
//            return 0;
//    }

//    /**
//     * Getter for the right margin.
//     * @return the X position of the right margin
//     */
//    public float GetUrx()
//    {
//        if (textRectangle != null)
//            return textRectangle.X + textRectangle.Width;
//        else
//            return 0;
//    }

//    /**
//     * Getter for the top margin.
//     * @return the Y position of the top margin
//     */
//    public float GetUry()
//    {
//        if (textRectangle != null)
//            return textRectangle.Y + textRectangle.Height;
//        else
//            return 0;
//    }

//    /**
//     * Gets the width of the text block.
//     * @return a width
//     */
//    public float GetWidth()
//    {
//        if (textRectangle != null)
//            return textRectangle.Width;
//        else
//            return 0;
//    }

//    /**
//     * Gets the height of the text block.
//     * @return a height
//     */
//    public float GetHeight()
//    {
//        if (textRectangle != null)
//            return textRectangle.Height;
//        else
//            return 0;
//    }

//    #endregion 
//} 








