using System;
using System.ComponentModel;
using System.Drawing;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;
using System.Collections.Generic;
using System.Data;
using TTReportes;
using System.Linq;

/// <summary>
/// Summary description for GenericListReport.
/// </summary>
public class GenericListReport : Report
{
    private Telerik.Reporting.PictureBox pictureBoxRight;
    private Telerik.Reporting.PictureBox pictureBoxLeft;
    private GroupHeaderSection labelsGroupHeader;
    public GroupHeaderSection LabelsGroupHeader
    {
        get { return labelsGroupHeader; }
        set { labelsGroupHeader = value; }
    }
    private Telerik.Reporting.TextBox[] captionTextBoxList;
    private GroupFooterSection labelsGroupFooter;
    private Group labelsGroup;
    private PageHeaderSection pageHeader;
    private Telerik.Reporting.TextBox reportNameTextBox;
    private PageFooterSection pageFooter;
    //private Telerik.Reporting.TextBox pageInfoTextBox;
    //private Telerik.Reporting.TextBox rowsCountTextBox;
    //public Telerik.Reporting.TextBox RowsCountTextBox
    //{
    //    get { return rowsCountTextBox; }
    //    set { rowsCountTextBox = value; }
    //}
    private ReportHeaderSection reportHeader;
    private Telerik.Reporting.TextBox titleTextBox;
    private DetailSection detail;
    public DetailSection Detail
    {
        get { return detail; }
        set { detail = value; }
    }
    private Telerik.Reporting.TextBox[] dataTextBoxList;
    private DataTable reportDataTable;

    public Telerik.Reporting.TextBox[] CaptionTextBoxList
    {
        get { return captionTextBoxList; }
        set { captionTextBoxList = value; }
    }

    public Telerik.Reporting.TextBox[] DataTextBoxList
    {
        get { return dataTextBoxList; }
        set { dataTextBoxList = value; }
    }

    public DataTable ReportDataTable
    {
        get { return reportDataTable; }
        set { reportDataTable = value; }
    }

    private string reportTitle = "";
    public string ReportTitle
    {
        get { return reportTitle; }
        set
        {
            this.titleTextBox.Value = value;
            reportTitle = value;
        }
    }

    private double reportWidthCm = 16.5;
    public double ReportWidthCm
    {
        get { return reportWidthCm; }
        set
        {
            this.Width = new Unit(value, UnitType.Cm);
            reportWidthCm = value;
        }
    }

    public Telerik.Reporting.Panel pnl1 { get; set; }

    private double defaultWidth = 5.0;
    private double DefaultWidth
    {
        get { return this.defaultWidth; }
        set { this.defaultWidth = value; }
    }

    private double defaultHeight = 0.5;
    private double DefaultHeight
    {
        get { return this.defaultHeight; }
        set { this.defaultHeight = value; }
    }

    public string UserName { get; set; }

    public GenericListReport(Telerik.Reporting.TextBox[] myCaptionTextBoxList, Telerik.Reporting.TextBox[] myDataTextBoxList)
    {
        this.Header = new List<TTReportsHeaderFooter>();
        this.Docks = new List<DockStateWithTemplate>();
        this.UserName = "";
        this.Footer = new List<TTReportsHeaderFooter>();
        this.DocksFooter = new List<DockStateWithTemplate>();
        this.captionTextBoxList = myCaptionTextBoxList;
        InitializeComponent();
    }

    public GenericListReport()
    {
        this.Header = new List<TTReportsHeaderFooter>();
        this.Docks = new List<DockStateWithTemplate>();
        this.UserName = "";
        this.Footer = new List<TTReportsHeaderFooter>();
        this.DocksFooter = new List<DockStateWithTemplate>();
        InitializeComponent();
    }

    public GenericListReport(List<TTReportsHeaderFooter> HList, List<DockStateWithTemplate> LDocks,
        List<TTReportsHeaderFooter> FList, List<DockStateWithTemplate> LDocksFooter, string userName)
    {
        this.Header = HList;
        this.Docks = LDocks;
        this.UserName = userName;
        this.Footer = FList;
        this.DocksFooter = LDocksFooter;
        InitializeComponent();
    }

    public List<TTReportsHeaderFooter> Header { get; set; }
    public List<DockStateWithTemplate> Docks { get; set; }

    public List<TTReportsHeaderFooter> Footer { get; set; }
    public List<DockStateWithTemplate> DocksFooter { get; set; }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportImage));
        //System.Web.HttpContext.GetGlobalResourceObject resources = new 

        StyleRule styleRule1 = new StyleRule();
        StyleRule styleRule2 = new StyleRule();
        StyleRule styleRule3 = new StyleRule();
        StyleRule styleRule4 = new StyleRule();
        this.labelsGroupHeader = new Telerik.Reporting.GroupHeaderSection();
        this.labelsGroupFooter = new Telerik.Reporting.GroupFooterSection();
        this.labelsGroup = new Telerik.Reporting.Group();
        this.pageHeader = new Telerik.Reporting.PageHeaderSection();
        this.reportNameTextBox = new Telerik.Reporting.TextBox();
        this.pageFooter = new Telerik.Reporting.PageFooterSection();
        //this.pageInfoTextBox = new Telerik.Reporting.TextBox();
        //this.RowsCountTextBox = new Telerik.Reporting.TextBox();
        this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
        this.titleTextBox = new Telerik.Reporting.TextBox();
        this.detail = new Telerik.Reporting.DetailSection();
        this.reportDataTable = new DataTable();
        this.pictureBoxRight = new Telerik.Reporting.PictureBox();
        this.pictureBoxLeft = new Telerik.Reporting.PictureBox();

        ((System.ComponentModel.ISupportInitialize)(this.reportDataTable)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // labelsGroupHeader
        // 
        
        this.labelsGroupHeader.Height = new Unit(/*0.5399999618530273*/0, UnitType.Cm);

        this.labelsGroupHeader.Name = "labelsGroupHeader";
        this.labelsGroupHeader.PrintOnEveryPage = true;

        this.labelsGroupHeader.Style.BorderStyle.Top = BorderType.Solid;
        this.labelsGroupHeader.Style.BorderStyle.Left = BorderType.Solid;
        this.labelsGroupHeader.Style.BorderStyle.Right = BorderType.Solid;

        this.labelsGroupHeader.Style.Padding.Left = new Unit(/*0.05*/0, UnitType.Cm);
        this.labelsGroupHeader.Style.Padding.Right = new Unit(/*0.05*/0, UnitType.Cm);
        this.labelsGroupHeader.Style.Padding.Bottom = new Unit(/*0.05*/0, UnitType.Cm);
        
        // 
        // labelsGroupFooter
        // 

        this.labelsGroupFooter.Height = new Unit(/*0.71437495946884155*/0, UnitType.Cm);
        this.labelsGroupFooter.Name = "labelsGroupFooter";
        this.labelsGroupFooter.Style.Visible = false;

        // 
        // labelsGroup
        // 
        this.labelsGroup.GroupFooter = this.labelsGroupFooter;
        this.labelsGroup.GroupHeader = this.labelsGroupHeader;
        // 
        // 
        // pageHeader
        //

        //this.pictureBoxLeft.Location = new PointU(new Unit(13.237400054931641, UnitType.Cm), new Unit(0.9921220680698752E-05, UnitType.Cm));
        //this.pictureBoxLeft.Visible = true;
        //this.pictureBoxLeft.MimeType = "image/png";
        //this.pictureBoxLeft.Name = "pictureBoxLeft";
        //this.pictureBoxLeft.Size = new SizeU(new Unit(180, UnitType.Pixel), new Unit(82, UnitType.Pixel));
        //this.pictureBoxLeft.Value = System.Web.HttpContext.GetGlobalResourceObject("ReportImage", "logo_NLUnido");  //System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\logo_SP.png"; 

        ////this.pictureBoxRight.Location = new PointU(new Unit(20.237400054931641, UnitType.Cm), new Unit(0.9921220680698752E-05, UnitType.Cm));
        //this.pictureBoxRight.Visible = true;
        //this.pictureBoxRight.MimeType = "image/png";
        //this.pictureBoxRight.Name = "pictureBoxRight";
        //this.pictureBoxRight.Size = new SizeU(new Unit(180, UnitType.Pixel), new Unit(82, UnitType.Pixel));
        //this.pictureBoxRight.Value = System.Web.HttpContext.GetGlobalResourceObject("ReportImage", "logo_SP");  //System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\logo_SP.png"; 

        
    
        this.pageHeader.Height = new Unit(2.71437495946884155, UnitType.Cm);
        this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] { this.reportNameTextBox });
        this.pageHeader.Name = "pageHeader";
        //this.pageHeader.Items.Add(pictureBoxLeft);
        //this.pageHeader.Items.Add(pictureBoxRight);

        double x = 0;
        double y = 0;
        double lasty = 0;
        byte line = 0;

        ReportParameter reportParameter1 = new ReportParameter();
        reportParameter1.Name = "Usuario";
        reportParameter1.Value = this.UserName;
        this.ReportParameters.Add(reportParameter1);

        foreach(TTReportsHeaderFooter itemHeader in this.Header)
        {
            Telerik.Reporting.Panel pnl = new Telerik.Reporting.Panel();
            pnl.Name = itemHeader.Cell;
            if (itemHeader.CmWidth <= 0)
                itemHeader.CmWidth = this.DefaultWidth;

            if (itemHeader.CmHeight <= 0)
                itemHeader.CmHeight = this.defaultHeight;

            if (lasty == 0)
                lasty = itemHeader.CmHeight;

            pnl.Size = new SizeU(new Unit(itemHeader.CmWidth, UnitType.Cm), new Unit(itemHeader.CmHeight, UnitType.Cm));
            pnl.Visible = true;
            //pnl.Style.BackgroundColor = Color.Aqua;          
            pnl.Location = new PointU(new Unit(x, UnitType.Cm), new Unit(y, UnitType.Cm));

            if(itemHeader.RowID != line)
            {
                y = lasty;                
                line = itemHeader.RowID;
                pnl.Location = new PointU(new Unit(0, UnitType.Cm), new Unit(y, UnitType.Cm));
                x = itemHeader.CmWidth;
                lasty += itemHeader.CmHeight;
            }
            else
                x += itemHeader.CmWidth;

             foreach (DockStateWithTemplate dock in Docks.Where(it=> it.DockZoneID == "ctl00_MainContent_" + itemHeader.Zone))
             {
                 if (!dock.WithTemplate) // Variables Fijas
                 {
                     TextBox txt = new TextBox();
                     switch (dock.Title)
                     {
                         case "Fecha":
                             txt.Format = "{0:d}";
                             txt.Name = dock.UniqueName;
                             txt.Size = pnl.Size;
                             txt.Value = "= Now()";                           
                             break;
                         case "Hora":
                             txt.Format = "{0:t}";
                             txt.Name = dock.UniqueName;
                             txt.Size = pnl.Size;
                             txt.Value = "= Now()";
                             break;
                         case "Numero":
                             txt.Format = "{0}";
                             txt.Name = dock.UniqueName;
                             txt.Size = pnl.Size;
                             txt.Value = "= PageNumber";
                             break;
                         case "Usuario":
                             txt.Format = "{0}";
                             txt.Name = dock.UniqueName;
                             txt.Size = pnl.Size;
                             txt.Value = "= Parameters.Usuario";
                             break;
                     };
                     pnl.Items.Add(txt);
                 }
                 else if (dock.esTexto) // Variables Texto
                 {
                     TextBox txt = new TextBox();
                     txt.Format = "{0}";
                     txt.Name = dock.UniqueName;
                     txt.Size = pnl.Size;
                     txt.Value = dock.Title;
                     pnl.Items.Add(txt);
                 }
                 else // Variables imagen
                 {

                     PictureBox image = new PictureBox();
                     image.Visible = true;
                     image.MimeType = "image/png";
                     image.Name = dock.UniqueName;
                     image.Size = pnl.Size;
                     image.Value = System.Web.HttpContext.Current.Server.MapPath("../FormsSystem/TTReportes") + "\\" + dock.Title;
                     pnl.Items.Add(image);
                 }
             }
            
            this.pageHeader.Items.Add(pnl);
        }

        x = 0;
        y = 0;
        lasty = 0;
        line = 0;

        foreach (TTReportsHeaderFooter itemFooter in this.Footer)
        {
            Panel pnl = new Panel();
            pnl.Name = itemFooter.Cell;
            if (itemFooter.CmWidth <= 0)
                itemFooter.CmWidth = this.DefaultWidth;

            if (itemFooter.CmHeight <= 0)
                itemFooter.CmHeight = this.defaultHeight;

            if (lasty == 0)
                lasty = itemFooter.CmHeight;

            pnl.Size = new SizeU(new Unit(itemFooter.CmWidth, UnitType.Cm), new Unit(itemFooter.CmHeight, UnitType.Cm));
            pnl.Visible = true;
            //pnl.Style.BackgroundColor = Color.Aqua;          
            pnl.Location = new PointU(new Unit(x, UnitType.Cm), new Unit(y, UnitType.Cm));

            if (itemFooter.RowID != line)
            {
                y = lasty;
                line = itemFooter.RowID;
                pnl.Location = new PointU(new Unit(0, UnitType.Cm), new Unit(y, UnitType.Cm));
                x = itemFooter.CmWidth;
                lasty += itemFooter.CmHeight;
            }
            else
                x += itemFooter.CmWidth;

            foreach (DockStateWithTemplate dock in DocksFooter.Where(it => it.DockZoneID == "ctl00_MainContent_" + itemFooter.Zone))
            {
                if (!dock.WithTemplate) // Variables Fijas
                {
                    TextBox txt = new TextBox();
                    switch (dock.Title)
                    {
                        case "Fecha":
                            txt.Format = "{0:d}";
                            txt.Name = dock.UniqueName;
                            txt.Size = pnl.Size;
                            txt.Value = "= Now()";
                            break;
                        case "Hora":
                            txt.Format = "{0:t}";
                            txt.Name = dock.UniqueName;
                            txt.Size = pnl.Size;
                            txt.Value = "= Now()";
                            break;
                        case "Numero":
                            txt.Format = "{0}";
                            txt.Name = dock.UniqueName;
                            txt.Size = pnl.Size;
                            txt.Value = "= PageNumber";
                            break;
                        case "Usuario":
                            txt.Format = "{0}";
                            txt.Name = dock.UniqueName;
                            txt.Size = pnl.Size;
                            txt.Value = "= Parameters.Usuario";
                            break;
                    };
                    pnl.Items.Add(txt);
                }
                else if (dock.esTexto) // Variables Texto
                {
                    TextBox txt = new TextBox();
                    txt.Format = "{0}";
                    txt.Name = dock.UniqueName;
                    txt.Size = pnl.Size;
                    txt.Value = dock.Title;
                    pnl.Items.Add(txt);
                }
                else // Variables imagen
                {

                    PictureBox image = new PictureBox();
                    image.Visible = true;
                    image.MimeType = "image/png";
                    image.Name = dock.UniqueName;
                    image.Size = pnl.Size;
                    image.Value = System.Web.HttpContext.Current.Server.MapPath("../FormsSystem/TTReportes") + "\\" + dock.Title;
                    //image.Width = pnl.Location.X;
                    //image.Height = pnl.Location.Y;
                    pnl.Items.Add(image);
                }
            }

            this.pageFooter.Items.Add(pnl);
        }

        // 
        // reportNameTextBox
        // 
        this.reportNameTextBox.Location = new PointU(new Unit(0.052916664630174637, UnitType.Cm), new Unit(0.052916664630174637, UnitType.Cm));
        this.reportNameTextBox.Name = "reportNameTextBox";
        this.reportNameTextBox.Size = new SizeU(new Unit(16.298332214355469, UnitType.Cm), new Unit(0.60000002384185791, UnitType.Cm));
        this.reportNameTextBox.StyleName = "PageInfo";
        // 
        // pictureBoxRight
        // 
        /*this.pictureBoxRight.Location = new PointU(new Unit(10.237400054931641, UnitType.Cm), new Unit(9.9921220680698752E-05, UnitType.Cm));
        this.pictureBoxRight.Visible = true;
        this.pictureBoxRight.MimeType = "image/png";
        this.pictureBoxRight.Name = "pictureBoxRight";
        this.pictureBoxRight.Size = new SizeU(new Unit(180, UnitType.Pixel), new Unit(82, UnitType.Pixel));
        this.pictureBoxRight.Value = System.Web.HttpContext.GetGlobalResourceObject("ReportImage", "logo_NLUnido");  //System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\logo_SP.png"; 
        *///((object)(resources.GetObject("pictureBoxRight.Value")));
        // 
        // pictureBoxLeft
        // 
        /*this.pictureBoxLeft.Location = new PointU(new Unit(50.237400054931641, UnitType.Cm), new Unit(9.9921220680698752E-05, UnitType.Cm));
        this.pictureBoxLeft.MimeType = "image/png";
        this.pictureBoxLeft.Name = "pictureBoxLeft";
        this.pictureBoxLeft.Size = new SizeU(new Unit(180, UnitType.Pixel), new Unit(102, UnitType.Pixel));
        this.pictureBoxLeft.Value = System.Web.HttpContext.GetGlobalResourceObject("ReportImage", "logo_SP");//System.Web.HttpContext.Current.Server.MapPath("") + "\\Images\\logo_NLUnido.png"; 
       */ //((object)(resources.GetObject("pictureBoxLeft.Value")));
        // 
        // 
        // pageFooter
        // 
        this.pageFooter.Height = new Unit(0.71437495946884155, UnitType.Cm);
        //this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
        //    this.pageInfoTextBox});
        //this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
        //    this.RowsCountTextBox});
        this.pageFooter.Name = "pageFooter";
        //// 
        //// pageInfoTextBox
        //// 
        //this.pageInfoTextBox.Location = new PointU(new Unit(10, UnitType.Cm), new Unit(0.052916664630174637, UnitType.Cm));
        //this.pageInfoTextBox.Name = "pageInfoTextBox";
        //this.pageInfoTextBox.Size = new SizeU(new Unit(8.1227083206176758, UnitType.Cm), new Unit(0.60000002384185791, UnitType.Cm));
        //this.pageInfoTextBox.Style.TextAlign = HorizontalAlign.Right;
        //this.pageInfoTextBox.StyleName = "PageInfo";
        //this.pageInfoTextBox.Value = "=pageNumber";
        //// 
        //// RowsCountTextBox
        //// 
        //this.RowsCountTextBox.Location = new PointU(new Unit(2, UnitType.Cm), new Unit(0.052916664630174637, UnitType.Cm));
        //this.RowsCountTextBox.Name = "RowsCountTextBox";
        //this.RowsCountTextBox.Size = new SizeU(new Unit(8.1227083206176758, UnitType.Cm), new Unit(0.60000002384185791, UnitType.Cm));
        //this.RowsCountTextBox.Style.TextAlign = HorizontalAlign.Left;
        //this.RowsCountTextBox.StyleName = "PageInfo";
        //this.RowsCountTextBox.Value = "=Count(RowNumber()) + \' Registros\'";
        
        // 
        // reportHeader
        // 
        this.reportHeader.Height = new Unit(1.0529167652130127, UnitType.Cm);
        this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] { this.titleTextBox });
        this.reportHeader.Name = "reportHeader";
        // 
        // titleTextBox
        // 
        this.titleTextBox.Name = "titleTextBox";
        this.titleTextBox.Size = new SizeU(new Unit(reportWidthCm, UnitType.Cm), new Unit(.5, UnitType.Cm));
        this.titleTextBox.StyleName = "Title";
        this.titleTextBox.Value = reportTitle;
        // 
        // detail
        // 
        this.detail.Height = new Unit(/*0.5399999618530273*/0, UnitType.Cm);
        this.detail.Name = "detail";
        this.detail.Style.BorderStyle.Bottom = BorderType.Solid;
        this.detail.Style.BorderStyle.Left = BorderType.Solid;
        this.detail.Style.BorderStyle.Right = BorderType.Solid;
        this.detail.Style.BorderStyle.Top = BorderType.Solid;

        // 
        // ReportList
        // 
        this.DataSource = this.reportDataTable;
        this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.labelsGroup});
        this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {           
            this.labelsGroupHeader,
            this.labelsGroupFooter,
            this.pageHeader,            
            this.pageFooter,
            this.reportHeader,
            this.detail});
        this.PageSettings.Landscape = false;
        this.PageSettings.Margins.Bottom = new Unit(0.5399999618530273, UnitType.Cm);
        this.PageSettings.Margins.Left = new Unit(0.5399999618530273, UnitType.Cm);
        this.PageSettings.Margins.Right = new Unit(0.5399999618530273, UnitType.Cm);
        this.PageSettings.Margins.Top = new Unit(0.5399999618530273, UnitType.Cm);
        this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
        this.Style.BackgroundColor = System.Drawing.Color.White;

        styleRule1.Selectors.AddRange(new ISelector[] { new StyleSelector("Title") });
        styleRule1.Style.BackgroundColor = System.Drawing.Color.Empty;        
        styleRule1.Style.Font.Name = "Tahoma";
        styleRule1.Style.Font.Size = new Unit(18, UnitType.Point);
        styleRule2.Selectors.AddRange(new ISelector[] { new StyleSelector("Caption") });        
        styleRule2.Style.Color = System.Drawing.Color.White;
        styleRule2.Style.Font.Bold = true;
        styleRule2.Style.Font.Italic = false;
        styleRule2.Style.Font.Name = "Tahoma";
        styleRule2.Style.Font.Size = new Unit(11, UnitType.Point);
        styleRule2.Style.Font.Strikeout = false;
        styleRule2.Style.Font.Underline = false;
        styleRule2.Style.VerticalAlign = VerticalAlign.Middle;
        styleRule3.Selectors.AddRange(new ISelector[] { new StyleSelector("Data") });
        styleRule3.Style.Color = System.Drawing.Color.Black;
        styleRule3.Style.Font.Name = "Tahoma";
        styleRule3.Style.Font.Size = new Unit(10, UnitType.Point);
        styleRule3.Style.VerticalAlign = VerticalAlign.Middle;
        styleRule4.Selectors.AddRange(new ISelector[] { new StyleSelector("PageInfo") });
        styleRule4.Style.Color = System.Drawing.Color.Black;
        styleRule4.Style.Font.Name = "Tahoma";
        styleRule4.Style.Font.Size = new Unit(8, UnitType.Point);
        styleRule4.Style.VerticalAlign = VerticalAlign.Middle;
        this.StyleSheet.AddRange(new StyleRule[] { styleRule1, styleRule2, styleRule3, styleRule4 });

        FormattingRule alternateRowsRule = new FormattingRule();
        // Define the rule to trigger the format
        alternateRowsRule.Filters.Add(new Telerik.Reporting.Data.Filter("= RowNumber()%2", Telerik.Reporting.Data.FilterOperator.Equal, "=1"));

        alternateRowsRule.Style.BackgroundColor = Color.FromArgb(223, 223, 223);
        this.detail.ConditionalFormatting.Add(alternateRowsRule);

        this.Width = new Unit(reportWidthCm, UnitType.Cm);
        ((System.ComponentModel.ISupportInitialize)(this.reportDataTable)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
    }

    #endregion
}