using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_ReportResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_ReportResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_ReportResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Report</summary>
        public static string Spartan_Report
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Spartan_Report", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ReportId</summary>
        public static string ReportId
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("ReportId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Date</summary>
        public static string Registration_Date
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Registration_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Hour</summary>
        public static string Registration_Hour
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Registration_Hour", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_User</summary>
        public static string Registration_User
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Registration_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object</summary>
        public static string Object
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Object", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Report_Name</summary>
        public static string Report_Name
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Report_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presentation_Type</summary>
        public static string Presentation_Type
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Presentation_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presentation_View</summary>
        public static string Presentation_View
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Presentation_View", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Query</summary>
        public static string Query
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Query", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Data</summary>
        public static string Data
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Data", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Filters</summary>
        public static string Filters
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Filters", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Header</summary>
        public static string Header
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Header", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Footer</summary>
        public static string Footer
        {
            get
            {
                return resourceProviderSpartan_Report.GetResource("Footer", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
