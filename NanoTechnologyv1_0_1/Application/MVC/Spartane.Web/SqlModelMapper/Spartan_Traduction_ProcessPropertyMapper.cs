﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Traduction_Process;

namespace Spartane.Web.SqlModelMapper
{
    public class Spartan_Traduction_ProcessPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "IdTraduction":
                    return "Spartan_Traduction_Process.IdTraduction";
                case "LanguageT[LanguageT]":
                case "LanguageTLanguageT":
                    return "Spartan_Traduction_Language.LanguageT";
                case "Object_Type[Object_Type_Description]":
                case "Object_TypeObject_Type_Description":
                    return "Spartan_Traduction_Object_Type.Object_Type_Description";
                case "ObjectT[Name]":
                case "ObjectTName":
                    return "Spartan_Object.Name";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Spartan_Traduction_Process).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {


            var operatorCondition = GetOperationType(columnName);
            columnName = GetPropertyName(columnName);

            switch (operatorCondition)
            {
                case SqlOperationType.Contains:
                    return string.IsNullOrEmpty(Convert.ToString(value)) ? "" : columnName + " LIKE '%" + value + "%'";
                case SqlOperationType.Equals:
                    return Convert.ToString(value) == "0" || Convert.ToString(value) == "" ? "" : columnName + "='" + value + "'";

            }
            return null;
        }
    }
}

