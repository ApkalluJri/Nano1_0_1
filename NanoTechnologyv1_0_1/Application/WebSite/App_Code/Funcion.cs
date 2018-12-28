using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Telerik.Reporting.Drawing;
using Telerik.Reporting.Charting;
using Telerik.Web.UI;
using System.Text;
using System.Collections;

/// <summary>
/// Summary description for Funcion
/// </summary>
public class Funcion
{
    public static string BaseSiteUrl
    {
        get
        {
            HttpContext context = HttpContext.Current;
            string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/') + '/';
            return baseUrl;
        }
    }

    public static String RegresaDato(String Query)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand(Query);
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0].ItemArray[0].ToString().Trim();
        }
        else
        {
            return "";
        }
    }

    public static DataSet RegresaDataSet(String Query)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand(Query);
        com.CommandType = CommandType.Text;
        DataSet ds = db.Consulta(com);
        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds;
        }
        else
        {
            return ds;
        }
    }

    public static String AgregaFiltro(String FiltroAnterior, String Tabla, String Campo, String Valor)
    {
        String FiltroNuevo = "";
        if (FiltroAnterior != "")
        {
            FiltroNuevo = FiltroAnterior + " AND " + Tabla + "_" + Campo + "='" + Valor + "'";
        }
        else
        {
            FiltroNuevo = " " + Tabla + "_" + Campo + "='" + Valor + "'";
        }
        return FiltroNuevo;
    }

    public static Int32 CambiaLogico(String Valor)
    {
        Valor = Valor.ToUpper();
        if (Valor == "TRUE")
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public static string Encrypta(string Texto)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(Texto);
        for (int i = 0; i <= byteArray.Length - 1; i++)
        {
            Int32 Suma = Int32.Parse(byteArray[i].ToString()) + 128;
            byteArray[i] = Byte.Parse(Suma.ToString());
        }
        String CadenaTexto = Convert.ToBase64String(byteArray);
        return CadenaTexto;
    }

    public static string DesEncrypta(string Texto)
    {
        byte[] byteArray = Convert.FromBase64String(Texto);
        for (int i = 0; i <= byteArray.Length - 1; i++)
        {
            Int32 Suma = Int32.Parse(byteArray[i].ToString()) - 128;
            byteArray[i] = Byte.Parse(Suma.ToString());
        }
        string CadenaTexto = Encoding.UTF8.GetString(byteArray);
        return CadenaTexto;
    }

    public static void SetSeguridadPorProcesos(string idUsuario, string idProceso, System.Web.UI.Page pagina, GridView grid)
    {
        try
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
            com.Parameters.AddWithValue("@IdUsuario", idUsuario);
            com.Parameters.AddWithValue("@IdProceso", idProceso);
            DataSet ds = db.Consulta(com);

            DisableControls(pagina, grid);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                switch (dr["IdOperacion"].ToString())
                {
                    case "1":
                        //((ImageButton)FindControlRecursive(pagina, "cmdNew2")).Visible = true;
                        //((ImageButton)FindControlRecursive(pagina, "cmdNew")).Visible = true;
                        ((HtmlGenericControl)FindControlRecursive(pagina, "btn_nuevo")).Visible = true;
                        break;
                    case "2":
                        grid.Columns[4].Visible = true; //icono editar
                        break;
                    case "3":
                        grid.Columns[0].Visible = true; //checkbox borrar
                        grid.Columns[1].Visible = true; //icono borrrar
                        break;
                    case "4":
                        //((ImageButton)FindControlRecursive(pagina, "cmdExport2")).Visible = true;
                        ((HtmlGenericControl)FindControlRecursive(pagina, "btn_exportar")).Visible= true;
                        break;
                    case "5":
                        //((ImageButton)FindControlRecursive(pagina, "cmdPrint2")).Visible = true;
                        ((HtmlGenericControl)FindControlRecursive(pagina, "btn_imprimir")).Visible = true;
                        grid.Columns[5].Visible = true; //icono imprimir
                        break;
                    case "6":
                        //((ImageButton)FindControlRecursive(pagina, "cmdConfiguration2")).Visible = true;
                        ((HtmlGenericControl)FindControlRecursive(pagina, "btn_configurar")).Visible = true;
                        break;
                }
            }
        }
        catch
        {
        }
    }

    public static void DisableControls(System.Web.UI.Page pagina, GridView grid)
    {
        /*((ImageButton)FindControlRecursive(pagina, "cmdNew2")).Visible = false;
        ((ImageButton)FindControlRecursive(pagina, "cmdExport2")).Visible = false;
        ((ImageButton)FindControlRecursive(pagina, "cmdPrint2")).Visible = false;
        ((ImageButton)FindControlRecursive(pagina, "cmdConfiguration2")).Visible = false;*/

        ((HtmlGenericControl)FindControlRecursive(pagina, "btn_nuevo")).Visible = false;
        ((HtmlGenericControl)FindControlRecursive(pagina, "btn_exportar")).Visible = false;
        ((HtmlGenericControl)FindControlRecursive(pagina, "btn_imprimir")).Visible = false;
        ((HtmlGenericControl)FindControlRecursive(pagina, "btn_configurar")).Visible = false;

        grid.Columns[0].Visible = false; //checkbox borrar
        grid.Columns[1].Visible = false; //icono borrrar
        grid.Columns[4].Visible = false; //icono editar
        grid.Columns[5].Visible = false; //icono imprimir
    }

    public static void SetSeguridadPorProcesos(string idUsuario, string idProceso, System.Web.UI.Page pagina, RadGrid grid)
    {
        try
        {

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
            com.Parameters.AddWithValue("@IdUsuario", idUsuario);
            com.Parameters.AddWithValue("@IdProceso", idProceso);
            DataSet ds = db.Consulta(com);

            DisableControls(pagina, grid);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                switch (dr["IdOperacion"].ToString())
                {
                    case "1":
                        HtmlGenericControl btn_nuevo = ((HtmlGenericControl)FindControlRecursive(pagina, "btn_nuevo"));
                        if (btn_nuevo != null)
                            btn_nuevo.Visible = true;
                        break;
                    case "2":
                        grid.Columns[4].Visible = true; //icono editar
                        break;
                    case "3":
                        //grid.Columns[0].Visible = true; //checkbox borrar
                        grid.Columns[1].Visible = true; //icono borrrar
                        break;
                    case "4":
                        HtmlGenericControl btn_exportar = ((HtmlGenericControl)FindControlRecursive(pagina, "btn_exportar"));
                        if (btn_exportar != null)
                            btn_exportar.Visible = true;
                        break;
                    case "5":
                        HtmlGenericControl btn_imprimir = ((HtmlGenericControl)FindControlRecursive(pagina, "btn_imprimir"));
                        if (btn_imprimir != null)
                            btn_imprimir.Visible = true;
                        grid.Columns[5].Visible = true; //icono imprimir
                        break;
                    case "6":
                        HtmlGenericControl btn_configurar = ((HtmlGenericControl)FindControlRecursive(pagina, "btn_configurar"));
                        if (btn_configurar != null)
                            btn_configurar.Visible = true;
                        break;
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    public static void DisableControls(System.Web.UI.Page pagina, RadGrid grid)
    {
        HtmlGenericControl btn_nuevo = ((HtmlGenericControl)FindControlRecursive(pagina, "btn_nuevo"));
        HtmlGenericControl btn_exportar = ((HtmlGenericControl)FindControlRecursive(pagina, "btn_exportar"));
        HtmlGenericControl btn_imprimir = ((HtmlGenericControl)FindControlRecursive(pagina, "btn_imprimir"));
        HtmlGenericControl btn_configurar = ((HtmlGenericControl)FindControlRecursive(pagina, "btn_configurar"));

        if (btn_nuevo != null)
            btn_nuevo.Visible = false;
        if (btn_exportar != null)
            btn_exportar.Visible = false;
        if (btn_imprimir != null)
            btn_imprimir.Visible = false;
        if (btn_configurar != null)
            btn_configurar.Visible = false;

        grid.Columns[0].Visible = false; //checkbox borrar
        grid.Columns[1].Visible = false; //icono borrrar
        grid.Columns[4].Visible = false; //icono editar
        grid.Columns[5].Visible = false; //icono imprimir
    }

    public static DataTable GetReportList()
    {
        TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "dbo.sp_GetReportMenu";
        DataTable dt = MyConexion.Consulta(com).Tables[0];
        return dt;
    }

    public static DataSet GetReportListByUserGroup(string userId)
    {
        TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[dbo].[GetReportListByUserGroup]";
        com.Parameters.AddWithValue("@IdGrupoUsuario", userId);
        DataSet ds = MyConexion.Consulta(com);
        return ds;
    }
       
    public static double ConvertPixelsToCms(double pixels)
    {
        double res = 0;

        res = pixels > 0 ? pixels / 37.79528 : res;
        return res;
    }

    public static Telerik.Reporting.TextBox CreateTxtHeader(string FieldName, double pos, int? textLength)
    {
        Telerik.Reporting.Drawing.Unit x = Telerik.Reporting.Drawing.Unit.Inch(0);
        Telerik.Reporting.Drawing.Unit y = Telerik.Reporting.Drawing.Unit.Inch(0);
        x = Telerik.Reporting.Drawing.Unit.Cm(pos);

        Telerik.Reporting.TextBox txtHead = new Telerik.Reporting.TextBox();
        txtHead.Value = FieldName;
        txtHead.StyleName = "Caption";
        txtHead.TextWrap = true;
        txtHead.Location = new Telerik.Reporting.Drawing.PointU(x, y);
        txtHead.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8);
        txtHead.CanShrink = true;
        int length = textLength == null ? FieldName.Length : (int)textLength;
        txtHead.Size = new SizeU(Telerik.Reporting.Drawing.Unit.Cm(length * .10), Telerik.Reporting.Drawing.Unit.Inch(0.1));//new SizeU(Telerik.Reporting.Drawing.Unit.Cm(FieldName.Length * .3), Telerik.Reporting.Drawing.Unit.Inch(0.3));

        return txtHead;
    }

    public static Telerik.Reporting.TextBox CreateTxtDetail(string FieldName, double pos, int? textLength)
    {
        Telerik.Reporting.Drawing.Unit x = Telerik.Reporting.Drawing.Unit.Inch(0);
        Telerik.Reporting.Drawing.Unit y = Telerik.Reporting.Drawing.Unit.Inch(0);
        x = Telerik.Reporting.Drawing.Unit.Cm(pos);

        Telerik.Reporting.TextBox txtData = new Telerik.Reporting.TextBox();
        txtData.Value = "=[" + FieldName + "]";
        txtData.StyleName = "Data";
        txtData.Location = new Telerik.Reporting.Drawing.PointU(x, y);
        txtData.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6);

        //txtData.Size = size;//new SizeU(Telerik.Reporting.Drawing.Unit.Cm(FieldName.Length * .3), Telerik.Reporting.Drawing.Unit.Inch(1));
        return txtData;
    }

    public static int MaxColumnLenght(DataTable dt, string columnName)
    {
        int res = 0;

        res = res > columnName.Length ? res : columnName.Length + 6;

        foreach (DataRow dr in dt.Rows)
            res = res > dr[columnName].ToString().Length ? res : dr[columnName].ToString().Length;

        return res;
    }

    public static DataTable SaveComboBoxItemsToTable(DropDownList dropdown)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Clave");
        dt.Columns.Add("Nombre");
        dt.PrimaryKey = new DataColumn[] { dt.Columns["Clave"] };
        dt.Columns["Clave"].Unique = true;
        foreach (ListItem item in dropdown.Items)
        {
            DataRow newRow = dt.NewRow();
            newRow["Clave"] = item.Value;
            newRow["Nombre"] = item.Text;
            dt.Rows.Add(newRow);
        }
        return dt;
    }

    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 02/Diciembre/2013 */
    /*OBJETIVO: Extender Web User Control TTbuttonCatalogo con las opciones de modificar y borrar. */
    #region IDCODMANUAL:
    public static DataTable SaveListBoxItemsToTable(ListBox listbox)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Clave");
        dt.Columns.Add("Nombre");
        dt.PrimaryKey = new DataColumn[] { dt.Columns["Clave"] };
        dt.Columns["Clave"].Unique = true;
        foreach (ListItem item in listbox.Items)
        {
            DataRow newRow = dt.NewRow();
            newRow["Clave"] = item.Value;
            newRow["Nombre"] = item.Text;
            dt.Rows.Add(newRow);
        }
        return dt;
    }
    #endregion

    public static void GetNewValuesFromDataTables(DataTable dt1, DataTable dt2, string oldValue, DropDownList ddl)
    {
        DataRow existingRow;
        foreach (DataRow row in dt2.Rows)
        {
            existingRow = dt1.Rows.Find(row["Clave"]);
            if (existingRow == null)
            {
                ddl.SelectedValue = row["Clave"].ToString();
                return;
            }
        }
        existingRow = dt2.Rows.Find(oldValue);
        if (existingRow == null)
            try
            {
                ddl.SelectedIndex = 0;
            }
            catch { }
    }

    public static Control FindControlRecursive(Control root, string id)
    {
        if (root.ID == id)
            return root;

        foreach (Control c in GetControlCollection(root))
        {
            Control t = FindControlRecursive(c, id);
            if (t != null)
                return t;
        }
        return null;
    }

    private static ICollection GetControlCollection(Control parent)
    {
        if (parent is Repeater)
        {
            return new Control[0];
        }
        else
        {
            return parent.Controls;
        }
    }
    public static DateTime? FormatDateFromTextTime(string txtTime) 
    {
        DateTime resultado;

        if (DateTime.TryParseExact(DateTime.Now.ToString("yyyy/MM/dd ") + txtTime, "yyyy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out resultado))
            return resultado;
        else if (DateTime.TryParseExact(DateTime.Now.ToString("yyyy/MM/dd ") + txtTime, "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out resultado))
            return resultado;
        else
            return null;
    }

    public static DateTime? FormatDateFromTextDate(string txtDate)
    {
        DateTime resultado;

        string[] Formatos = new string[10];
        Formatos[0] = "MM/dd/yyyy HH:mm:ss";
        Formatos[1] = "MM/dd/yyyy HH:mm";
        Formatos[2] = "MM/dd/yyyy";
        Formatos[3] = "yyyy-dd-MM HH:mm:ss";
        Formatos[4] = "yyyy/dd/MM HH:mm";
        Formatos[5] = "yyyy-MM-dd HH:mm:ss";
        Formatos[6] = "yyyy/MM/dd HH:mm";
        Formatos[7] = "dd/MM/yyyy HH:mm:ss";
        Formatos[8] = "dd/MM/yyyy HH:mm";
        Formatos[9] = "dd/MM/yyyy";

        if (DateTime.TryParseExact(txtDate, Formatos, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out resultado))
            return resultado;
        else
            return null;
    }
    //TODO:OLD_APP_CODE/FUNCION.CS INICIO WORKFLOWS LINEA 409 JZAMORA
    #region FormateaDato(String Dato)
    public static String FormateaDato(String Dato)
    {
        Dato = Dato.Replace("Á", "A");
        Dato = Dato.Replace("É", "E");
        Dato = Dato.Replace("Í", "I");
        Dato = Dato.Replace("Ó", "O");
        Dato = Dato.Replace("Ú", "U");
        Dato = Dato.Replace("á", "a");
        Dato = Dato.Replace("é", "e");
        Dato = Dato.Replace("í", "i");
        Dato = Dato.Replace("ó", "o");
        Dato = Dato.Replace("ú", "u");
        Dato = Dato.Replace(" ", "_");
        Dato = Dato.Replace(".", "_");
        Dato = Dato.Replace(",", "_");
        Dato = Dato.Replace("/", "_");
        String DatoFormateado = Dato;
        return DatoFormateado;
    }
    #endregion

    #region ValidaWorkFlow(Int32 Proceso, String LlaveProceso, Int32 Rol_de_Usuario)
    public static DataSet ValidaWorkFlow(Int32 Proceso, String LlaveProceso, Int32 Rol_de_Usuario)
    {
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("spGetUbicacionTTWorkFlow");
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@idProceso", SqlDbType.Int).Value = Proceso;
        com.Parameters.Add("@LlaveProceso", SqlDbType.NVarChar).Value = LlaveProceso;
        com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Rol_de_Usuario;
        DataSet ds = db.Consulta(com);
        return ds;
    }
    #endregion

    #region ValidaWorkFlow_GetWhere(int idProceso, int Fase, int Rol_de_Usuario)
    public static string ValidaWorkFlow_GetWhere(int idProceso, int Fase, int Rol_de_Usuario)
    {
        return ValidaWorkFlow_GetWhere(idProceso, Fase, Rol_de_Usuario, false);
    }
    #endregion

    #region ValidaWorkFlow_GetWhere(int idProceso, int Fase, int Rol_de_Usuario, bool set_on_session)
    public static string ValidaWorkFlow_GetWhere(int idProceso, int Fase, int Rol_de_Usuario, bool set_on_session)
    {
        string Where = "";

        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("spGetCondicionesEstadoWorkFlow");
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Rol_de_Usuario;
        com.Parameters.Add("@Proceso", SqlDbType.Int).Value = idProceso;
        com.Parameters.Add("@Fase", SqlDbType.Int).Value = Fase;
        DataSet ds = db.Consulta(com);
        //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string operador = ds.Tables[0].Rows[i]["operador"].ToString();
            if (ds.Tables[0].Rows[i]["TipoOperacion"].ToString() == "2") //VARIABLE GLOBAL
            {
                Where = Where + " " + operador + " (" + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Tabla"].ToString()) + "." + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Campo"].ToString()) + " " + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Condicion"].ToString()) + " " + HttpContext.Current.Session[ds.Tables[0].Rows[i]["valor"].ToString()].ToString()  + ") ";
            }
            else
            {
                Where = Where + " " + operador + " (" + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Tabla"].ToString()) + "." + Funcion.FormateaDato(ds.Tables[0].Rows[i]["Campo"].ToString()) + " " + (ds.Tables[0].Rows[i]["valor"] == DBNull.Value ? (Funcion.FormateaDato(ds.Tables[0].Rows[i]["Condicion"].ToString()) == "=" ? "is" : "is not") : Funcion.FormateaDato(ds.Tables[0].Rows[i]["Condicion"].ToString())) + " " + (ds.Tables[0].Rows[i]["valor"] == DBNull.Value ? "null" : ds.Tables[0].Rows[i]["valor"].ToString()) + ") ";
            }        
        }

        string where_tmp = "";
        if (set_on_session)
        {
            if (Where != "")
            {
                if (HttpContext.Current.Session["Where"] != null)
                    where_tmp = HttpContext.Current.Session["Where"].ToString();

                if (where_tmp.ToString().Trim() == "")
                    where_tmp = Where.Substring(5); // quitar el " AND " inicial
                else
                    where_tmp = where_tmp + " And (" + Where.Substring(5) + ") "; // concat el where de la session

                //HttpContext.Current.Session["Where"] = where_tmp;

                return where_tmp;
            }
            else
                return Where;
        }
        else
        {
            if (Where != "")
                Where = Where.Substring(5);
            else
                return "";

            return "    WHERE   " + Where;
        }
    }
    #endregion


    #region ValidaWorkFlow_GetTableName(int idProceso, int Rol_de_Usuario)
    public static string ValidaWorkFlow_GetTableName(int idProceso, int Rol_de_Usuario)
    {
        string Tabla, CampoLlave;
        return ValidaWorkFlow_GetTableName(idProceso, Rol_de_Usuario, out Tabla, out CampoLlave);
    }
    #endregion

    #region ValidaWorkFlow_GetTableName(int idProceso, int Rol_de_Usuario, out string Tabla, out string CampoLlave)
    public static string ValidaWorkFlow_GetTableName(int idProceso, int Rol_de_Usuario, out string Tabla, out string CampoLlave)
    {
        string Where = "";

        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        SqlCommand com = new SqlCommand("spGetTableNameTTWorkFlow");
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("@Rol_de_Usuario", SqlDbType.SmallInt).Value = Rol_de_Usuario;
        com.Parameters.Add("@idProceso", SqlDbType.Int).Value = idProceso;
        DataSet ds = db.Consulta(com);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Tabla = ds.Tables[0].Rows[0]["Tabla"].ToString();
            CampoLlave = ds.Tables[0].Rows[0]["CampoLlave"].ToString();
            return Tabla;
        }
        else
        {
            Tabla = "";
            CampoLlave = "";
            return Tabla;
        }
    }
    #endregion

    #region NombreControl(String Campo, Int32 TipoControl)
    public static String NombreControl(String Campo, Int32 TipoControl)
    {
        String Control = FormateaDato(Campo);
        switch (TipoControl)
        {
            case 1: //TextBox
                Control = "txt" + Control;
                break;
            case 2: //DropDown
                Control = "ddl" + Control;
                break;
            case 3: //List
                Control = "lst" + Control;
                break;
            case 5: //CheckBox
                Control = "Ch" + Control;
                break;
            case 13: //Archivo
                Control = "txt" + Control;
                break;
        }
        return Control;
    }
    #endregion
    //TODO:OLD_APP_CODE/FUNCION.CS INICIO WORKFLOWS LINEA 471 JZAMORA
}








