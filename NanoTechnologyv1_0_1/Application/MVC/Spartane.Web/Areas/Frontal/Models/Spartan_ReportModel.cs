using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_ReportModel
    {
        [Required]
        public int ReportId { get; set; }
        public string Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        [Range(0, 9999999999)]
        public int? Registration_User { get; set; }
        [Range(0, 9999999999)]
        public int? Object { get; set; }
        public string Report_Name { get; set; }
        public int? Presentation_Type { get; set; }
        public string Presentation_TypeDescription { get; set; }
        public int? Presentation_View { get; set; }
        public string Presentation_ViewDescription { get; set; }
        public short? Status { get; set; }
        public string StatusDescription { get; set; }
        public string Query { get; set; }
        public string Filters { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }

    }
}

