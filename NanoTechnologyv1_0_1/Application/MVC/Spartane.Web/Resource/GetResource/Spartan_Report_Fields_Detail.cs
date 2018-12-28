using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_Fields_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Fields_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_Fields_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Fields_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_Fields_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Report_Fields_Detail</summary>
        public static string Spartan_Report_Fields_Detail
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("Spartan_Report_Fields_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>DesignDetailId</summary>
        public static string DesignDetailId
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("DesignDetailId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PathField</summary>
        public static string PathField
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("PathField", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Physical_Name</summary>
        public static string Physical_Name
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("Physical_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Title</summary>
        public static string Title
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("Title", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Function</summary>
        public static string Function
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("Function", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Format</summary>
        public static string Format
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("Format", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Order_Type</summary>
        public static string Order_Type
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("Order_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Field_Type</summary>
        public static string Field_Type
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("Field_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Order_Number</summary>
        public static string Order_Number
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("Order_Number", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>AttributeId</summary>
        public static string AttributeId
        {
            get
            {
                return resourceProviderSpartan_Report_Fields_Detail.GetResource("AttributeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
