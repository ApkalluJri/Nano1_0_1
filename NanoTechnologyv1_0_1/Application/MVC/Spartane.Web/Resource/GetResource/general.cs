using System.Security.Cryptography;
using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.IO;

namespace Resources
{
    public partial class Resources
    {

        public static string ErrorContactingServer
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("ErrorContactingServer", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Home</summary>
        public static string Home
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Home", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PrintText</summary>
        public static string PrintText
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("PrintText", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>ErrorSave</summary>
        public static string ErrorSave
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("ErrorSave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Configure</summary>
        public static string Configure
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Configure", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Edit</summary>
        public static string Edit
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Edit", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Delete</summary>
        public static string Delete
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Delete", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Consult</summary>
        public static string Consult
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Consult", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Index</summary>
        public static string Index
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Index", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>RecordsPerPage</summary>
        public static string RecordsPerPage
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("RecordsPerPage", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Display</summary>
        public static string Display
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Display", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>NothingFound</summary>
        public static string NothingFound
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("NothingFound", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ShowingPages</summary>
        public static string ShowingPages
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("ShowingPages", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>of</summary>
        public static string of
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("of", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>NoRecords</summary>
        public static string NoRecords
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("NoRecords", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>FilteredFrom</summary>
        public static string FilteredFrom
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("FilteredFrom", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>TotalRecords</summary>
        public static string TotalRecords
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("TotalRecords", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Copy</summary>
        public static string Copy
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Copy", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CSV</summary>
        public static string CSV
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("CSV", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Excel</summary>
        public static string Excel
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Excel", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PDF</summary>
        public static string PDF
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("PDF", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Print</summary>
        public static string Print
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Print", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Previous</summary>
        public static string Previous
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Previous", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Next</summary>
        public static string Next
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Next", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Create</summary>
        public static string Create
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Create", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Search</summary>
        public static string Search
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Search", CultureInfo.CurrentUICulture.Name) as String;
            }
        }



        public static string AdvanceSearch
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("AdvanceSearch", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string ClearFilter
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("ClearFilter", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>OrSelect</summary>
        public static string OrSelect
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("OrSelect", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Upload</summary>
        public static string Upload
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Upload", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actions</summary>
        public static string Actions
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Actions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Guardar</summary>
        public static string Guardar
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Guardar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>GuardarNuevo</summary>
        public static string GuardarNuevo
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("GuardarNuevo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        //new
        public static string From
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("From", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string To
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("To", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string Filter
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Filter", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string Yes
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Yes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string NoApply
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("NoApply", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string No
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("No", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string BeginWith
        {
            get
            {
                SetPath(); 
                return resourceProvider.GetResource("BeginWith", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string EndWith
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("EndWith", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string Exact
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Exact", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string Contains
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Contains", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        public static string HasAttachment
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("HasAttachment", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>GuardarCopia</summary>
        public static string GuardarCopia
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("GuardarCopia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cancelar</summary>
        public static string Cancelar
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Cancelar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>DeleteConfirm</summary>
        public static string DeleteConfirm
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("DeleteConfirm", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Id</summary>
        public static string Id
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Years</summary>
        public static string Years
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Years", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Salary</summary>
        public static string Salary
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Salary", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Height</summary>
        public static string Height
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Height", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>State</summary>
        public static string State
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>City</summary>
        public static string City
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("City", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>All</summary>
        public static string All
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("All", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>textMessagge1</summary>
        public static string textMessagge1
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("textMessagge1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>SaveSuccess</summary>
        public static string SaveSuccess
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("SaveSuccess", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>GreaterThanZero</summary>
        public static string GreaterThanZero
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("GreaterThanZero", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>GreaterThanFrom</summary>
        public static string GreaterThanFrom
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("GreaterThanFrom", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>InvalidDate</summary>
        public static string InvalidDate
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("InvalidDate", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>AddNewRow</summary>
        public static string AddNewRow
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("AddNewRow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        /// <summary>BusinessRuleToBegin</summary>
        public static string BusinessRuleToBegin
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("BusinessRuleToBegin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>BusinessRuleToBegin</summary>
        public static string BusinessRuleBeforeSave
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("BusinessRuleBeforeSave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>BusinessRuleToBegin</summary>
        public static string BusinessRuleToCreateGrid
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("BusinessRuleToCreateGrid", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>BusinessRuleToBegin</summary>
        public static string BusinessRuleFor
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("BusinessRuleFor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string Description
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string Save
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Save", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string Close
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Close", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string Name
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string NoPermission
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("NoPermission", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string AdvanceFilter
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("AdvanceFilter", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string DeleteRecord
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("DeleteRecord", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string DeleteSuccess
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("DeleteSuccess", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string DeleteError
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("DeleteError", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string ClaveDefault
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("ClaveDefault", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string PendingRow
        {
            get
            {
                SetPath();
                return resourceProvider.GetResource("PendingRow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }

}