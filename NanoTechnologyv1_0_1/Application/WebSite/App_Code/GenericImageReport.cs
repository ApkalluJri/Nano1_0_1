using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

public class GenericImageReport : Telerik.Reporting.Report
{
    private double reportWidthCm = 16.5;
    public double ReportWidthCm
    {
        get { return reportWidthCm; }
        set
        {
            this.Width = new Telerik.Reporting.Drawing.Unit(value + (0.54000002145767212 * 4), Telerik.Reporting.Drawing.UnitType.Cm);
            reportWidthCm = value;
        }
    }

    private double reportHeightCm = 15;
    public double ReportHeightCm
    {
        get { return reportHeightCm; }
        set
        {
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(value, Telerik.Reporting.Drawing.UnitType.Cm);
            reportHeightCm = value;
        }
    }

    private object imageObject;
    public object ImageObject
    {
        get { return imageObject; }
        set
        {
            imageObject = value;
        }
    }

    public GenericImageReport(object img)
    {
        this.imageObject = img;
        InitializeComponent();
    }

    public GenericImageReport(object img, double height, double width)
    {
        this.imageObject = img;
        this.reportWidthCm = width;
        this.reportHeightCm = height;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericImageReport));
        Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
        Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
        Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
        Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
        this.detail = new Telerik.Reporting.DetailSection();
        this.pictureBox = new Telerik.Reporting.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // detail
        // 
        this.detail.Height = new Telerik.Reporting.Drawing.Unit(reportWidthCm, Telerik.Reporting.Drawing.UnitType.Cm);
        this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox});
        this.detail.Name = "detail";
        // 
        // pictureBox1
        // 
        this.pictureBox.MimeType = "image/png";//"image/jpeg";
        this.pictureBox.Name = "pictureBox";
        this.pictureBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(reportWidthCm, Telerik.Reporting.Drawing.UnitType.Cm), new Telerik.Reporting.Drawing.Unit(reportHeightCm - (0.54000002145767212 * 2), Telerik.Reporting.Drawing.UnitType.Cm));
        this.pictureBox.Value = imageObject; //((object)(resources.GetObject("pictureBox.Value")));
        // 
        // GenericImageReport
        // 
        this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
        this.PageSettings.Landscape = true;
        this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(0.54000002145767212, Telerik.Reporting.Drawing.UnitType.Cm);
        this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(0.54000002145767212, Telerik.Reporting.Drawing.UnitType.Cm);
        this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(0.54000002145767212, Telerik.Reporting.Drawing.UnitType.Cm);
        this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(0.54000002145767212, Telerik.Reporting.Drawing.UnitType.Cm);
        this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
        this.Style.BackgroundColor = System.Drawing.Color.White;
        styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
        styleRule1.Style.Color = System.Drawing.Color.Black;
        styleRule1.Style.Font.Bold = true;
        styleRule1.Style.Font.Italic = false;
        styleRule1.Style.Font.Name = "Tahoma";
        styleRule1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(20, Telerik.Reporting.Drawing.UnitType.Point);
        styleRule1.Style.Font.Strikeout = false;
        styleRule1.Style.Font.Underline = false;
        styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
        styleRule2.Style.Color = System.Drawing.Color.Black;
        styleRule2.Style.Font.Name = "Tahoma";
        styleRule2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
        styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
        styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
        styleRule3.Style.Font.Name = "Tahoma";
        styleRule3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
        styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
        styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
        styleRule4.Style.Font.Name = "Tahoma";
        styleRule4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
        styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
        this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
        this.Width = new Telerik.Reporting.Drawing.Unit(reportWidthCm + (0.54000002145767212 * 4), Telerik.Reporting.Drawing.UnitType.Cm);
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
    }

    private DetailSection detail;
    private Telerik.Reporting.PictureBox pictureBox;
}








