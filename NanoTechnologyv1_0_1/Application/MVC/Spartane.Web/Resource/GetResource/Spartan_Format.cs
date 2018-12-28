using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_FormatResources
    {
        //private static IResourceProvider resourceProviderSpartan_Format = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_FormatResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Format = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_FormatResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Format</summary>
        public static string Spartan_Format
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Spartan_Format", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>FormatId</summary>
        public static string FormatId
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("FormatId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Date</summary>
        public static string Registration_Date
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Registration_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Hour</summary>
        public static string Registration_Hour
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Registration_Hour", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_User</summary>
        public static string Registration_User
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Registration_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Format_Name</summary>
        public static string Format_Name
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Format_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Format_Type</summary>
        public static string Format_Type
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Format_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Search</summary>
        public static string Search
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Search", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object</summary>
        public static string Object
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Object", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Header</summary>
        public static string Header
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Header", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Body</summary>
        public static string Body
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Body", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Footer</summary>
        public static string Footer
        {
            get
            {
                return resourceProviderSpartan_Format.GetResource("Footer", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
