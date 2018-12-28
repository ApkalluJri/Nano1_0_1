using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Web.UI;


public class GridGenericSorter
{
    List<GridSortExpression> _expression = null;
    StringBuilder swhere = null;

    public GridGenericSorter(List<GridSortExpression> expression)
    {
        _expression = expression;
    }

    public string GetOrder()
    {
        swhere = new StringBuilder();
        foreach (GridSortExpression Order in _expression)
        {
            swhere.Append(Order.FieldName);
            swhere.Append(Order.SortOrder == GridSortOrder.Ascending ? " ASC," : " DESC,");
        }

        string sswhere = swhere.ToString();

        if (sswhere.Length >= 1)
            if (sswhere.Substring(sswhere.Length - 1) == ",")
                sswhere = sswhere.Substring(0, sswhere.Length - 1);
        return sswhere;
    }
}

public class GridGenericFilterer
{
    List<GridFilterExpression> _expressions = null;
    StringBuilder swhere = null;

    public GridGenericFilterer(List<GridFilterExpression> expression)
    {
        _expressions = expression;
    }

    public string GetWhere()
    {
        swhere = new StringBuilder();
        foreach (GridFilterExpression fil in _expressions)
        {
            Type T = Type.GetType(fil.DataTypeName);
            GridKnownFunction Function = (GridKnownFunction)Enum.Parse(typeof(GridKnownFunction), fil.FilterFunction);
            if (T == typeof(String))
            {
                if (Function == GridKnownFunction.Contains)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" LIKE '%");
                    swhere.Append(fil.FieldValue);
                    swhere.Append("%' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.DoesNotContain)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" NOT LIKE '%");
                    swhere.Append(fil.FieldValue);
                    swhere.Append("%' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.StartsWith)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" LIKE '");
                    swhere.Append(fil.FieldValue);
                    swhere.Append("%' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.EndsWith)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" LIKE '%");
                    swhere.Append(fil.FieldValue);
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.EqualTo)
                {
                    swhere.Append("LOWER(");
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(") = '");
                    swhere.Append(fil.FieldValue.ToLower());
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.NotEqualTo)
                {
                    swhere.Append("LOWER(");
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(") <> '");
                    swhere.Append(fil.FieldValue.ToLower());
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.IsEmpty)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" IS NULL ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.NotIsEmpty)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" IS NOT NULL ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.GreaterThan)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" > '");
                    swhere.Append(fil.FieldValue);
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.GreaterThanOrEqualTo)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" >= '");
                    swhere.Append(fil.FieldValue);
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.LessThan)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" < '");
                    swhere.Append(fil.FieldValue);
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.LessThanOrEqualTo)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" <= '");
                    swhere.Append(fil.FieldValue);
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
            }
            else if (T == typeof(Boolean))
            {
                if (Function == GridKnownFunction.EqualTo)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" = ");
                    swhere.Append(Convert.ToInt16(bool.Parse(fil.FieldValue)).ToString());
                    swhere.Append(" ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.NotEqualTo)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" <> ");
                    swhere.Append(Convert.ToInt16(bool.Parse(fil.FieldValue)).ToString());
                    swhere.Append(" ");
                    swhere.Append("AND ");
                }
            }
            else if (T == typeof(DateTime))
            {
                if (Function == GridKnownFunction.EqualTo)
                {
                    swhere.Append("CONVERT(NVARCHAR,");
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(",112) = '");
                    DateTime date = DateTime.Parse(fil.FieldValue);
                    swhere.Append(date.Year.ToString());
                    swhere.Append(date.Month.ToString().PadLeft(2, '0'));
                    swhere.Append(date.Day.ToString().PadLeft(2, '0'));
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.NotEqualTo)
                {
                    swhere.Append("CONVERT(NVARCHAR,");
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(",112) <> '");
                    DateTime date = DateTime.Parse(fil.FieldValue);
                    swhere.Append(date.Year.ToString());
                    swhere.Append(date.Month.ToString().PadLeft(2, '0'));
                    swhere.Append(date.Day.ToString().PadLeft(2, '0'));
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.GreaterThan)
                {
                    swhere.Append("CONVERT(NVARCHAR,");
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(",112) > '");
                    DateTime date = DateTime.Parse(fil.FieldValue);
                    swhere.Append(date.Year.ToString());
                    swhere.Append(date.Month.ToString().PadLeft(2, '0'));
                    swhere.Append(date.Day.ToString().PadLeft(2, '0'));
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.GreaterThanOrEqualTo)
                {
                    swhere.Append("CONVERT(NVARCHAR,");
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(",112) >= '");
                    DateTime date = DateTime.Parse(fil.FieldValue);
                    swhere.Append(date.Year.ToString());
                    swhere.Append(date.Month.ToString().PadLeft(2, '0'));
                    swhere.Append(date.Day.ToString().PadLeft(2, '0'));
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.LessThan)
                {
                    swhere.Append("CONVERT(NVARCHAR,");
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(",112) < '");
                    DateTime date = DateTime.Parse(fil.FieldValue);
                    swhere.Append(date.Year.ToString());
                    swhere.Append(date.Month.ToString().PadLeft(2, '0'));
                    swhere.Append(date.Day.ToString().PadLeft(2, '0'));
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.LessThanOrEqualTo)
                {
                    swhere.Append("CONVERT(NVARCHAR,");
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(",112) <= '");
                    DateTime date = DateTime.Parse(fil.FieldValue);
                    swhere.Append(date.Year.ToString());
                    swhere.Append(date.Month.ToString().PadLeft(2, '0'));
                    swhere.Append(date.Day.ToString().PadLeft(2, '0'));
                    swhere.Append("' ");
                    swhere.Append("AND ");
                }
            }
            else if (IsNumeric(T))
            {
                if (Function == GridKnownFunction.EqualTo)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" = ");
                    swhere.Append(fil.FieldValue);
                    swhere.Append(" ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.NotEqualTo)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" <> ");
                    swhere.Append(fil.FieldValue);
                    swhere.Append(" ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.GreaterThan)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" > ");
                    swhere.Append(fil.FieldValue);
                    swhere.Append(" ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.GreaterThanOrEqualTo)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" >= ");
                    swhere.Append(fil.FieldValue);
                    swhere.Append(" ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.LessThan)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" < ");
                    swhere.Append(fil.FieldValue);
                    swhere.Append(" ");
                    swhere.Append("AND ");
                }
                else if (Function == GridKnownFunction.LessThanOrEqualTo)
                {
                    swhere.Append(fil.ColumnUniqueName);
                    swhere.Append(" <= ");
                    swhere.Append(fil.FieldValue);
                    swhere.Append(" ");
                    swhere.Append("AND ");
                }
            }

            if (Function == GridKnownFunction.IsNull)
            {
                swhere.Append(fil.ColumnUniqueName);
                swhere.Append(" IS NULL ");
                swhere.Append("AND ");
            }
            else if (Function == GridKnownFunction.NotIsNull)
            {
                swhere.Append(fil.ColumnUniqueName);
                swhere.Append(" IS NOT NULL ");
                swhere.Append("AND ");
            }
        }
        string sswhere = swhere.ToString();

        if (sswhere.Length >= 4)
            if (sswhere.Substring(sswhere.Length - 4) == "AND ")
                sswhere = sswhere.Substring(0, sswhere.Length - 4);

        if (sswhere != string.Empty)
            sswhere = (!sswhere.ToLower().Trim().StartsWith("where") ? " WHERE " + sswhere : sswhere);

        return sswhere;
    }


    static bool IsNumeric(Type type)
    {
        if (!type.IsEnum)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Char:
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return true;
            }
        }
        return false;
    }
}


public static class JsonMethods {
    public static List<Dictionary<string, object>>
        RowsToDictionary(DataTable table)
    {
        List<Dictionary<string, object>> objs =
            new List<Dictionary<string, object>>();
        foreach (DataRow dr in table.Rows)
        {
            Dictionary<string, object> drow = new Dictionary<string, object>();
            drow.Add("__type", typeof(System.Data.DataRow).ToString());
            for (int i = 0; i < table.Columns.Count; i++)
            {
                drow.Add(table.Columns[i].ColumnName, dr[i]);
            }
            objs.Add(drow);
        }

        return objs;
    }

}

public class JsonResult
{
    public object data { get; set; }
    public bool success { get; set; }
    public string errorMessage { get; set; }

    public JsonResult(object pdata, bool psuccess, string perrorMessage)
    {
        this.data = pdata;
        this.success = psuccess;
        this.errorMessage = perrorMessage;
    }
}


public class GridState
{
    public int startRowIndex {get;private set;}
    public int maximumRows{get;private set;} 
    public List<GridSortExpression> sortExpression {get;private set;}
    public List<GridFilterExpression> filterExpression { get; private set; }
    public int idProceso { get; private set; }
    public int CurrentPage { get { return this.startRowIndex / this.maximumRows; } }
    public string fase { get; private set; }

    public GridState(int pstartRowIndex, int pmaximumRows,
        List<GridSortExpression> psortExpression, List<GridFilterExpression> pfilterExpression, int pidProceso, string pfase)
    {
        this.startRowIndex = pstartRowIndex;
        this.maximumRows = pmaximumRows;
        this.sortExpression = psortExpression;
        this.filterExpression = pfilterExpression;
        this.idProceso = pidProceso;
        this.fase = pfase;
    }
}







