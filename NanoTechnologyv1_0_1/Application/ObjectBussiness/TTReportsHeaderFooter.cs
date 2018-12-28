using System;
using System.Collections.Generic;
using System.Text;

namespace TTReportes
{
    public class TTReportsHeaderFooter
    {
        public string Row { get; set; }
        public string Cell { get; set; }
        public byte Colspan { get; set; }
        public byte RowSpan { get; set; }
        public string Zone { get; set; }
        public double CmHeight { get; set; }
        public double CmWidth { get; set; }
        public byte RowID { get; set; }

        public TTReportsHeaderFooter(string prRow, string prCell, byte prColspan, byte prRowSpan, string prZone, double prCmHeight, double prCmWidth, byte prRowID)
        {
            this.Row = prRow;
            this.Cell = prCell;
            this.Colspan = prColspan;
            this.RowSpan = prRowSpan;
            this.Zone = prZone;
            this.CmHeight = prCmHeight;
            this.CmWidth = prCmWidth;
            this.RowID = prRowID;
        }
    }
}
