using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Actions_False_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Actions_False_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Actions_False_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Actions_False_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Actions_False_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Actions_False_Detail</summary>
        public static string Spartan_BR_Actions_False_Detail
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Spartan_BR_Actions_False_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ActionsFalseDetailId</summary>
        public static string ActionsFalseDetailId
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("ActionsFalseDetailId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Action_Classification</summary>
        public static string Action_Classification
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Action_Classification", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Action</summary>
        public static string Action
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Action", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Action_Result</summary>
        public static string Action_Result
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Action_Result", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parameter_1</summary>
        public static string Parameter_1
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Parameter_1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parameter_2</summary>
        public static string Parameter_2
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Parameter_2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parameter_3</summary>
        public static string Parameter_3
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Parameter_3", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parameter_4</summary>
        public static string Parameter_4
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Parameter_4", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parameter_5</summary>
        public static string Parameter_5
        {
            get
            {
                return resourceProviderSpartan_BR_Actions_False_Detail.GetResource("Parameter_5", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
