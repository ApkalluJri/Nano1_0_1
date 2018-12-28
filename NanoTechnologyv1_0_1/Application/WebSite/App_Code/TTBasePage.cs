using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.UI;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using App_Code.TTBusinessRules;

/// <summary>
/// Pàgina Base
/// </summary>
namespace TTBasePage
{
    public class TTBasePage : System.Web.UI.Page
    {
        protected TTFunctions.Functions MyFunctions = new TTFunctions.Functions();
        protected TTSecurity.GlobalData myUserData;
        protected TTTraductor.Traductor MyTraductor;
        protected ControlsLibrary.objectBussinessTTFiltro myFilter;
        //------------------------------------ Business Rule Object -----------------------------------------
        private BusinessOperations myBusinessRule;
        //---------------------------------------------------------------------------------------------------   
        private Random randomControlId = new Random(DateTime.Now.Millisecond);
        public string sPrerenderMessageBox = string.Empty;

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        public TTSecurity.GlobalData MyUserData
        {
            get { return Session["UserGlobalInformation"] as TTSecurity.GlobalData; }
        }

        public int Language
        {
            get
            {
                return
                    Session["Language"] == null ? 1 :
                    MyFunctions.FormatNumberNull(Session["Language"].ToString()).Value;
            }
        }

        public TTBasePage()
        {
            //LoadSecurityPage();        
        }

        protected void LoadSecurityPage()
        {
            if (Session["UserGlobalInformation"] == null)
                Response.Redirect("~/FormsSystem/Default.aspx");
            myUserData = new TTSecurity.GlobalData();
            myUserData = (TTSecurity.GlobalData)Session["UserGlobalInformation"];

            if (HttpContext.Current.Session == null)
            {
                Response.Write(@"<script>alert('El usuario ya esta loggeado en el sistema')</script>");
                Response.Redirect("~/FormsSystem/Login.aspx");
            }
            MyTraductor = new TTTraductor.Traductor(Language);
        }

        public static bool SetSecurityAccess(string idUsuario,int idProceso)
        {
            bool returnValue = false;
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
                com.Parameters.AddWithValue("@IdUsuario", idUsuario);
                com.Parameters.AddWithValue("@IdProceso", idProceso);

                DataSet ds = db.Consulta(com);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    switch (dr["IdOperacion"].ToString())
                    {
                        case "1": //-----Tiene permisos para agregar en el Catálogo
                            returnValue = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            { }
            return returnValue;
        }

        protected void ApplyBusinessRules(TTenumBusinessRules_Operacion enumOperation, TTenumBusinessRules_ProcessEvent enumEvento, int iProcess)
        {
            //----------------------------- Apply Business Rules -----------------------------------------------
            try
            {
                myBusinessRule = new BusinessOperations(this, myUserData, iProcess);
                TTenumBusinessRules_ActionResultType[] mybusResult;
                mybusResult = myBusinessRule.Comparation(MyUserData, iProcess, enumOperation, enumEvento);
                if (mybusResult != null)
                    foreach (TTenumBusinessRules_ActionResultType myRes in mybusResult)
                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                            return;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
            //--------------------------------------------------------------------------------------------------
        }

        protected bool ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion enumOperation, TTenumBusinessRules_ProcessEvent enumEvento, int iProcess)
        {
            bool breakExecution = false;
            //----------------------------- Apply Business Rules -----------------------------------------------
            try
            {
                myBusinessRule = new BusinessOperations(this, myUserData, iProcess);
                TTenumBusinessRules_ActionResultType[] mybusResult;
                mybusResult = myBusinessRule.Comparation(MyUserData, iProcess, enumOperation, enumEvento);
                if (mybusResult != null)
                    foreach (TTenumBusinessRules_ActionResultType myRes in mybusResult)
                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                            breakExecution = true;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
            return breakExecution;
            //--------------------------------------------------------------------------------------------------
        }

        protected void ApplyBusinessRules(TTenumBusinessRules_FieldEvent enumFieldEvent, int iProcess)
        {
            //----------------------------- Apply Business Rules -----------------------------------------------
            try
            {
                myBusinessRule = new BusinessOperations(this, myUserData, iProcess);
                myBusinessRule.Comparation(MyUserData, iProcess, TTenumBusinessRules_Alcance.Field, enumFieldEvent);
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
        }

        protected void ApplyBusinessRules(TTenumBusinessRules_FieldEvent enumFieldEvent, int iProcess,Boolean OnlyFunctionInMultiRow)
        {
            //----------------------------- Apply Business Rules -----------------------------------------------
            try
            {
                myBusinessRule = new BusinessOperations(this, myUserData, iProcess);
                if (OnlyFunctionInMultiRow)
                    myBusinessRule.Comparation(MyUserData, iProcess, TTenumBusinessRules_Alcance.Field, enumFieldEvent,true);
                else
                    myBusinessRule.Comparation(MyUserData, iProcess, TTenumBusinessRules_Alcance.Field, enumFieldEvent);
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
        }

        protected void ApplyBusinessRulesMulti(TTenumBusinessRules_FieldEvent enumFieldEvent, int iProcess, int fieldIndex, Control eventControl)
        {
            //----------------------------- Apply Business Rules -----------------------------------------------
            try
            {
                myBusinessRule = new BusinessOperations(this, myUserData, iProcess);
                myBusinessRule.FieldIndex = fieldIndex;
                string result = myBusinessRule.ComparationMulti(MyUserData, iProcess, TTenumBusinessRules_Alcance.Field, enumFieldEvent, eventControl);
                sPrerenderMessageBox += result;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
        }

        protected void ApplyBusinessRulesMulti(TTenumBusinessRules_Operacion enumOperation, TTenumBusinessRules_ProcessEvent enumEvento, int iProcess, GridViewRow gridRow)
        {
            //----------------------------- Apply Business Rules -----------------------------------------------
            try
            {
                myBusinessRule = new BusinessOperations(this, myUserData, iProcess);
                myBusinessRule.GridRow = gridRow;
                string result = myBusinessRule.ComparationMulti(MyUserData, iProcess, enumOperation, enumEvento);
                sPrerenderMessageBox += result;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
        }

        public void ShowAlert(string message)
        {
            MsgBox msgBox = new MsgBox(this);
            msgBox.ID = "Fn" + randomControlId.Next();//DateTime.Now.ToString().GetHashCode().ToString("x"); //DateTime.Now.Ticks.ToString();
            msgBox.ShowAlert(FormatMessage(@message), null, null, "Mensaje");
            sPrerenderMessageBox += string.Format("radalert('{0}', {1}, {2}, '{3}');", msgBox.ReplaceSpecialChars(message), 300, 100, "Mensaje");
        }

        public void ShowAlert(string message,int Ancho)
        {
            MsgBox msgBox = new MsgBox(this);
            msgBox.ID = "Fn" + randomControlId.Next();//DateTime.Now.ToString().GetHashCode().ToString("x"); //DateTime.Now.Ticks.ToString();
            msgBox.ShowAlert(FormatMessage(@message), Ancho, null, "Mensaje");
            sPrerenderMessageBox += string.Format("radalert('{0}', {1}, {2}, '{3}');", msgBox.ReplaceSpecialChars(message), 300, 100, "Mensaje");
        }

        public void Confirm(string confirmText, bool isPostbackOnYes, bool isPostBackOnNo)
        {
            MsgBox msgBox = new MsgBox(this);
            msgBox.ID = "Fn" + randomControlId.Next(); //DateTime.Now.ToString().GetHashCode().ToString("x"); //DateTime.Now.Ticks.ToString();
            msgBox.ShowConfirmation(@confirmText, "1", isPostbackOnYes, isPostBackOnNo, null, null, "");
        }

        public void Prompt(string message)
        {
            MsgBox msgBox = new MsgBox(this);
            msgBox.ID = "Fn" + randomControlId.Next(); //DateTime.Now.ToString().GetHashCode().ToString("x"); //DateTime.Now.Ticks.ToString();
            msgBox.ShowPrompt(@message, "1", null, null, "", "0");
        }
        private string FormatMessage(string message)
        {
            string formatedMessage = string.Empty;

            //si el mensaje viene de alguna excepcion
            if (message.ToLower().Contains("system.") && message.ToLower().Contains("exception"))
            {
                message = message.Replace("`", string.Empty).Replace("'", string.Empty).Replace("\\", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);

                Regex exp;
                Match match;
                MatchCollection matches;

                //Limpia el tipo de Excepcion y deja solo el mensaje
                exp = new Regex(@"System\.[(a-zA-Z\.)]*: [(a-zA-Z_0-9\. )]*---> [(a-zA-Z\.)]*: ", RegexOptions.IgnoreCase);
                match = exp.Match(message);
                message = Regex.Replace(message, match.Value, string.Empty, RegexOptions.IgnoreCase);

                //limpia los inner exception
                exp = new Regex(@"at [(a-zA-Z_0-9\.\(\),: )]*", RegexOptions.IgnoreCase);
                matches = exp.Matches(message);
                foreach (Match singleMatch in matches)
                    message = Regex.Replace(message, singleMatch.Value, string.Empty, RegexOptions.IgnoreCase);

                //Limpia el stack trace end
                exp = new Regex(@"---[(a-zA-Z_0-9\. )]*---", RegexOptions.IgnoreCase);
                match = exp.Match(message);
                message = Regex.Replace(message, match.Value, string.Empty, RegexOptions.IgnoreCase);

                formatedMessage = message;
            }
            else
                formatedMessage = message;

            return formatedMessage;
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Request["MenuVisible"] != null)
            {
                //DirectoryInfo dInfo = new DirectoryInfo(
                //System.Web.HttpContext.Current.Server.MapPath("").Replace("\\FormsSystem", "").Replace("\\WebForms", "") + "\\App_Themes\\Catalogos");
                //Page.Theme = "Catalogos";// dInfo.Name;
            }
        }

        //--------------------------------------------------- Funciones para Exportación -----------------------------------------
        protected void ExportWithConsoleApp(string sQuery, string sPath, string sFileName, FileExportFormat format)
        {
            bool StoredProcedureCreated = false;
            bool CatalogoSimple = false;
            if (sQuery.Contains("from  ") == true)
            {
                CatalogoSimple = true;
                sQuery = sQuery.Replace("from  ", "from (");
            }
            try
            {
                var stringSeparators = new string[] { " AS ", " As ", ",", "from " };

                var spl = sQuery.Split(stringSeparators, StringSplitOptions.None);

                for (int i = 1; i <= spl.Length - 1; i++)
                {
                    if (spl[i][0] == '(')
                    {
                        break;
                    }
                    if (spl[i][0] != ' ')
                    {
                        spl[i] = spl[i].Replace('_', ' ');
                        spl[i] = "[" + spl[i] + "]";
                    }
                }
                sQuery = spl[0];
                for (int i = 1; i <= spl.Length - 1; i++)
                {
                    switch (spl[i][0])
                    {

                        case '(':
                            sQuery += " from " + spl[i];
                            if (CatalogoSimple)
                            {
                                sQuery = sQuery.Replace("from (", "from  ");
                            }
                            break;
                        case '[':
                            sQuery += " AS " + spl[i];
                            break;
                        case ' ':
                            sQuery += "," + spl[i];
                            break;
                        default:
                            sQuery += spl[i];
                            break;

                    }
                }
                sQuery = sQuery.Replace("|||", ",");
                sQuery = sQuery.Replace("||", "");
                sQuery = sQuery.Replace("        ", " ");
                sQuery = sQuery.Replace("       ", " ");
                sQuery = sQuery.Replace(", ", ",");
                string command = HttpContext.Current.Server.MapPath(@"~\\DLL") + "\\ExportToExcel.exe";
                string arguments = @"""{0}"" ""{1}"" ""{2}"" ""{3}"" ";
                StoredProcedureCreated = CreateStoredProcedure(sFileName, sQuery);
                if (StoredProcedureCreated)
                    arguments = String.Format(arguments, sPath, sFileName, format, "EXEC " + "sp_" + sFileName);
                else
                    arguments = String.Format(arguments, sPath, sFileName, format, sQuery);

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;

                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                if (StoredProcedureCreated) DropStoredProcedure(sFileName);
                ShowAlert(ex.Message.ToString());
            }
            finally
            {
                if (StoredProcedureCreated) DropStoredProcedure(sFileName);
                GC.Collect();
            }
        }
        private bool CreateStoredProcedure(string FileName, String SqlQuery)
        {
            try
            {

                String FinalSqlQuery = "CREATE PROCEDURE sp_" + FileName + " AS " + SqlQuery;
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand(FinalSqlQuery);

                return db.EjecutaQuery(com, myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("",0));;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool DropStoredProcedure(string FileName)
        {
            try
            {

                String FinalSqlQuery = "DROP PROCEDURE sp_" + FileName;
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand(FinalSqlQuery);

                return db.EjecutaQuery(com, myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", 0)); ;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void ExportWithConsoleApp(FileExportFormat format, string sQuery, string sPath, string sFileName)
        {
            try
            {
                var stringSeparators = new string[] { " AS ", " As ", ",", "from " };

                var spl = sQuery.Split(stringSeparators, StringSplitOptions.None);

                for (int i = 1; i <= spl.Length - 1; i++)
                {
                    if (spl[i][0] == '(')
                    {
                        break;
                    }
                    if (spl[i][0] != ' ')
                    {
                        spl[i] = spl[i].Replace('_', ' ');
                        spl[i] = "[" + spl[i] + "]";
                    }
                }
                sQuery = spl[0];
                for (int i = 1; i <= spl.Length - 1; i++)
                {
                    switch (spl[i][0])
                    {

                        case '(':
                            sQuery += " from " + spl[i];
                            break;
                        case '[':
                            sQuery += " AS " + spl[i];
                            break;
                        case ' ':
                            sQuery += "," + spl[i];
                            break;
                        default:
                            sQuery += spl[i];
                            break;

                    }
                }
                sQuery = sQuery.Replace("|||", ",");
                sQuery = sQuery.Replace("||", "");
                string command = HttpContext.Current.Server.MapPath(@"~\\DLL") + "\\ExportToExcel.exe";
                string arguments = @"""{0}"" ""{1}"" ""{2}"" ""{3}"" ";
                arguments = String.Format(arguments, sPath, sFileName, format, sQuery);

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;

                process.StartInfo.FileName = command;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        protected void DownloadFile(string filepath, string filename)
        {
            System.IO.Stream iStream = null;

            // Buffer to read 10K bytes in chunk:
            byte[] buffer = new Byte[10000];

            // Length of the file:
            int length;

            // Total bytes to read:
            long dataToRead;

            // Identify the file to download including its path.
            //filepath = Server.MapPath(filepath);
            // Identify the file name.
            //string filename = System.IO.Path.GetFileName(filepath);

            try
            {
                // Open the file.
                iStream = new System.IO.FileStream(filepath, System.IO.FileMode.Open,
                            System.IO.FileAccess.Read, System.IO.FileShare.Read);


                // Total bytes to read:
                dataToRead = iStream.Length;

                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 10000);

                        // Write the data to the current output stream.
                        Response.OutputStream.Write(buffer, 0, length);

                        // Flush the data to the HTML output.
                        Response.Flush();

                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
            finally
            {
                if (iStream != null)
                {
                    //Close the file.
                    iStream.Close();
                }
				Response.End();
            }
        }
        //---------------------------------------------------------------------------------------------------
        //----------------------------- Funciones para Catalogos --------------------------------------------
        public void AgregaCeldaTextBox(System.Web.UI.HtmlControls.HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, String sCarpeta, String MultiRenglon, Boolean Multilinea)
        {
            System.Web.UI.HtmlControls.HtmlTableCell td = new System.Web.UI.HtmlControls.HtmlTableCell();
            TextBox txt = new TextBox();
            if (Multilinea == true)
            {
                txt.TextMode = TextBoxMode.MultiLine;
                txt.Columns = 40;
                txt.Rows = 5;
            }
            else
            {
                txt.Width = 100;
            }
            txt.ID = sID + iRenglon;
            txt.Text = sTexto;
            txt.Attributes.Add("runat", "Server");
            txt.Attributes.Add("OnFocusOut", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
            txt.EnableViewState = false;

            td.Controls.Add(txt);
            trRenglon.Cells.Add(td);
        }

        public void AgregaCeldaComboBox(System.Web.UI.HtmlControls.HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, DataSet dsFill, String sCarpeta, String MultiRenglon)
        {
            System.Web.UI.HtmlControls.HtmlTableCell td = new System.Web.UI.HtmlControls.HtmlTableCell();
            DropDownList ddl = new DropDownList();
            ddl.ID = sID + iRenglon;
            MyFunctions.FillDataControl(ddl, dsFill);
            if (sTexto != "")
                ddl.SelectedValue = sTexto;

            ddl.Attributes.Add("runat", "Server");
            ddl.Attributes.Add("OnFocusOut", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
            ddl.EnableViewState = false;
            ddl.Width = 150;
            td.Controls.Add(ddl);
            trRenglon.Cells.Add(td);
        }

        public void AgregaCeldaComboBox(System.Web.UI.HtmlControls.HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, DataTable dtFill, String sCarpeta, String MultiRenglon)
        {
            System.Web.UI.HtmlControls.HtmlTableCell td = new System.Web.UI.HtmlControls.HtmlTableCell();
            DropDownList ddl = new DropDownList();
            ddl.ID = sID + iRenglon;
            //MyFunctions.FillDataControl(ddl, dtFill);
            if (sTexto != "")
                ddl.SelectedValue = sTexto;

            ddl.Attributes.Add("runat", "Server");
            ddl.Attributes.Add("OnFocusOut", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
            ddl.EnableViewState = false;
            ddl.Width = 150;
            td.Controls.Add(ddl);
            trRenglon.Cells.Add(td);
        }

        public void AgregaCeldaAjaxCalendar(System.Web.UI.HtmlControls.HtmlTableRow trRenglon, String sID, String sTexto, Int32 iRenglon, String sCarpeta, String MultiRenglon)
        {
            //Agregamos el TexBox
            System.Web.UI.HtmlControls.HtmlTableCell td = new System.Web.UI.HtmlControls.HtmlTableCell();
            TextBox txt = new TextBox();
            txt.ID = sID + iRenglon;
            if (sTexto != "")
            {
                DateTime fecha = DateTime.Parse(sTexto);
                txt.Text = String.Format("{0:MM/dd/yyyy}", fecha);
            }
            else
            {
                txt.Text = sTexto;
            }
            txt.Enabled = true;
            txt.Attributes.Add("runat", "Server");
            txt.Attributes.Add("onchange", "processText('" + MultiRenglon + "','ctl00_MainContent_TabControls_tabPag" + sCarpeta + "_" + sID + "','" + iRenglon + "')");
            txt.EnableViewState = false;
            txt.Width = 100;

            //Agregamos la imagen del calendario
            Image ImgCalendar = new Image();
            ImgCalendar.ID = "ImgCalendar" + sID + iRenglon;
            ImgCalendar.ImageUrl = "~/Images/greyscale_38.gif";
            ImgCalendar.Height = 20;
            ImgCalendar.Width = 22;
            ImgCalendar.Visible = true;
            ImgCalendar.Attributes.Add("runat", "Server");

            //Agregamos el objeto Calendar Ajax
            AjaxControlToolkit.CalendarExtender calendario = new AjaxControlToolkit.CalendarExtender();
            calendario.ID = "Calendario" + sID + iRenglon;
            calendario.Animated = true;
            //calendario.BehaviorID = "crl14_CalendarExtender" + sID + iRenglon;
            calendario.Enabled = true;
            calendario.EnabledOnClient = true;
            calendario.EnableViewState = true;
            calendario.Format = System.Configuration.ConfigurationSettings.AppSettings["FormatoFecha"].ToString();
            calendario.PopupButtonID = "ImgCalendar" + sID + iRenglon;
            calendario.TargetControlID = sID + iRenglon; //nombe del txt

            //Agregamos los controles a la celda
            td.Controls.Add(txt);
            td.Controls.Add(ImgCalendar);
            td.Controls.Add(calendario);

            //agregamos la celda  al renglon
            trRenglon.Cells.Add(td);
        }
        //--------------------------------------------------------------------------------------------------
        //------------------------------------ Item Request para Botones de Lista --------------------------
        public void ddlLista_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (sender as RadComboBox);
            Control ctl = (Control)sender;
            GridViewRow rowFocus = (GridViewRow)ctl.NamingContainer;
            
            comboBox.Items.Clear();
            string text = e.Text;
            int DTId = MyFunctions.FormatNumberNull(comboBox.Attributes["DTId"].ToString()).Value;

            TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
            TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(DTId));
            TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
            TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);

            string Clave = MyFunctions.GenerateName(datoClave.Nombre);
            int longitud, decimales;
            string Descripcion = MyFunctions.GenerateName(datoDescripcion.Nombre);
            bool executeQuery = false;

            try
            {
                
                TTFunctions.TypeData dataType = datoClave.TipodeDato;
                switch (dataType)
                {
                    case TTFunctions.TypeData.Decimal:
                    case TTFunctions.TypeData.Moneda:
                        //-------------------------------------------------
                        longitud = datoClave.Longitud.Value;
                        decimales = datoClave.Decimales.Value;
                        if (text.Length > longitud + decimales)
                            text = text.Substring(0, longitud + decimales);
                        decimal outValue;
                        executeQuery = decimal.TryParse(text, out outValue);
                        if (!executeQuery)
                        {
                            text = string.Empty;
                            executeQuery = true;
                        }
                        break;
                    //-------------------------------------------------
                    case TTFunctions.TypeData.Numerico:
                        //-------------------------------------------------
                        longitud = datoClave.Longitud.Value;
                        double sLength = Math.Truncate(Math.Pow(2, longitud * 8) / 2);
                        double outValued;
                        executeQuery = double.TryParse(text, out outValued);
                        if (outValued > sLength)
                            text = (sLength - 1).ToString();
                        break;
                    //-------------------------------------------------
                    default:
                        executeQuery = true;
                        break;
                }


                string NombreTabla = MyFunctions.GenerateName(datoDescripcion.NombreTabla);
                string sqlQuery = string.Empty;
                if (executeQuery)
                    sqlQuery = @"Select top 50 {0},{1} from {2} Where ( {0} like '%{3}%' )";
                else
                    sqlQuery = @"Select top 50 {0},{1} from {2} Where ( {1} like '%{3}%' )";
                text = text.Trim();
                Clave = MyFunctions.GenerateName(Clave);
                Descripcion = MyFunctions.GenerateName(Descripcion);

                sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, text.Replace("\'", string.Empty));
                DataSet ds = Funcion.RegresaDataSet(sqlQuery);

                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            RadComboBoxItem item = new RadComboBoxItem();
                            item.Text = row[Descripcion].ToString().Trim();
                            item.Value = row[Clave].ToString().Trim();
                            item.Attributes.Add("Clave", item.Value);
                            item.Attributes.Add("Descripcion", item.Text);
                            comboBox.Items.Add(item);
                            item.DataBind();
                        }
                    }
                String textLike = text.Replace("\'", string.Empty);
                WebControl x = (WebControl)sender;
                x.Attributes.Add("executeQuery", executeQuery.ToString());
                x.Attributes.Add("textLike", textLike);
                ApplyBusinessRulesMultiAutoCompleteNew(TTenumBusinessRules_FieldEvent.LostFocusAutoComplete, int.Parse(comboBox.Attributes["Proceso"]), rowFocus.RowIndex ,(Control)x);

                ApplyBusinessRulesMulti(TTenumBusinessRules_FieldEvent.LostFocus, int.Parse(comboBox.Attributes["Proceso"]), rowFocus.RowIndex ,(Control)x);
            }
            catch (Exception ex)
            {

                this.ShowAlert("ddlLista_ItemsRequested: " + ex);
            }
        }


        protected void ApplyBusinessRulesMultiAutoCompleteNew(TTenumBusinessRules_FieldEvent enumFieldEvent, int iProcess, int fieldIndex, Control eventControl)
        {
            //----------------------------- Apply Business Rules -----------------------------------------------
            try
            {
                myBusinessRule = new BusinessOperations(this, myUserData, iProcess);
                myBusinessRule.FieldIndex = fieldIndex;
                string result = myBusinessRule.ComparationMultiAutoComplete(MyUserData, iProcess, TTenumBusinessRules_Alcance.Field, enumFieldEvent, eventControl);
                sPrerenderMessageBox += result;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message.ToString());
            }
        } 

        public string getDTDescriptionFromDB(string text, int DTId)
        {
            string sReturn = string.Empty;
            TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
            TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(DTId));
            TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
            TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);

            string Clave = MyFunctions.GenerateName(datoClave.Nombre);
            int longitud, decimales;
            string Descripcion = MyFunctions.GenerateName(datoDescripcion.Nombre);
            bool executeQuery = false;

            try
            {
                TTFunctions.TypeData dataType = datoClave.TipodeDato;
                switch (dataType)
                {
                    case TTFunctions.TypeData.Decimal:
                    case TTFunctions.TypeData.Moneda:
                        //-------------------------------------------------
                        longitud = datoClave.Longitud.Value;
                        decimales = datoClave.Decimales.Value;
                        if (text.Length > longitud + decimales)
                            text = text.Substring(0, longitud + decimales);
                        decimal outValue;
                        executeQuery = decimal.TryParse(text, out outValue);
                        if (!executeQuery)
                        {
                            text = string.Empty;
                            executeQuery = true;
                        }
                        break;
                    //-------------------------------------------------
                    case TTFunctions.TypeData.Numerico:
                        //-------------------------------------------------
                        longitud = datoClave.Longitud.Value;
                        double sLength = Math.Truncate(Math.Pow(2, longitud * 8) / 2);
                        double outValued;
                        executeQuery = double.TryParse(text, out outValued);
                        if (outValued > sLength)
                            text = (sLength - 1).ToString();
                        break;
                    //-------------------------------------------------
                    default:
                        executeQuery = true;
                        break;
                }


                string NombreTabla = MyFunctions.GenerateName(datoDescripcion.NombreTabla);
                string sqlQuery = string.Empty;
                if (executeQuery)
                    sqlQuery = @"Select top 50 {0},{1} from {2} Where ( {0} = {3} )";
                else
                    sqlQuery = @"Select top 50 {0},{1} from {2} Where ( {1} ='{3}' )";
                text = text.Trim();
                Clave = MyFunctions.GenerateName(Clave);
                Descripcion = MyFunctions.GenerateName(Descripcion);

                sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, text.Replace("\'", string.Empty));
                DataSet ds = Funcion.RegresaDataSet(sqlQuery);

                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            sReturn = row[Descripcion].ToString().Trim();
                        }
                    }
            }
            catch
            {

            }
            return sReturn;
        }

        protected void GridViewRadCombo_OnDataBound(object sender, EventArgs e)
        {
            Telerik.Web.UI.RadComboBox combo = (Telerik.Web.UI.RadComboBox)sender;
            string text = combo.Attributes["CurrentValue"].ToString();
            if (text != string.Empty)
            {
                string description = getDTDescriptionFromDB(text, MyFunctions.FormatNumberNull(combo.Attributes["DTid"]).Value);
                combo.Text = string.Format("{0} - {1}", text, description);
            }
        }

        //------------------------------------------------------------------------------------------------------------
        public static void GetFocus(Control control)
        {
        }

        protected byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        public string GetURLByProcess(int idProceso, string controlId)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            string url = string.Empty;
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[dbo].[GetPermisosPorProcesoUsuario]";
                com.Parameters.AddWithValue("@IdUsuario", Session["globalUsuarioClave"].ToString());
                com.Parameters.AddWithValue("@IdProceso", idProceso);

                DataSet ds = db.Consulta(com);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    url = MyFunctions.GenerateName(dr["Nombre_Proceso"].ToString()) + "_Lista.aspx?MenuVisible=false&ControlId=" + controlId;
                    return url;
                }
            }
            catch
            { }
            return url;
        }

        public bool DisplayWindow(ref string sText, ref string sDescripcion, int DTId)
        {
            TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
            TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(DTId));

            TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
            TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);

            string Clave = MyFunctions.GenerateName(datoClave.Nombre);
            int longitud, decimales;
            string Descripcion = MyFunctions.GenerateName(datoDescripcion.Nombre);
            bool executeQuery = false;

            try
            {
                TTFunctions.TypeData dataType = datoClave.TipodeDato;
                switch (dataType)
                {
                    case TTFunctions.TypeData.Decimal:
                    case TTFunctions.TypeData.Moneda:
                        //-------------------------------------------------
                        longitud = datoClave.Longitud.Value;
                        decimales = datoClave.Decimales.Value;
                        if (sText.Length > longitud + decimales)
                            sText = sText.Substring(0, longitud + decimales);
                        decimal outValue;
                        executeQuery = decimal.TryParse(sText, out outValue);
                        break;
                    //-------------------------------------------------
                    case TTFunctions.TypeData.Numerico:
                        //-------------------------------------------------
                        longitud = datoClave.Longitud.Value;
                        double sLength = Math.Truncate(Math.Pow(2, longitud * 8) / 2);
                        double outValued;
                        executeQuery = double.TryParse(sText, out outValued);
                        if (outValued > sLength)
                            sText = (sLength - 1).ToString();
                        break;
                    //-------------------------------------------------
                    default:
                        executeQuery = true;
                        break;
                }

                if (executeQuery)
                {
                    string NombreTabla = MyFunctions.GenerateName(datoDescripcion.NombreTabla);
                    string sqlQuery = @"Select {0},{1} from {2} Where ( {0} = '{3}' )";
                    sText = sText.Trim();
                    Clave = MyFunctions.GenerateName(Clave);
                    Descripcion = MyFunctions.GenerateName(Descripcion);

                    sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, sText.Replace("\'", string.Empty));
                    DataSet ds = Funcion.RegresaDataSet(sqlQuery);

                    if (ds.Tables.Count > 0)
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            sText = ds.Tables[0].Rows[0][Clave].ToString();
                            sText = sText.Trim();
                            sDescripcion = ds.Tables[0].Rows[0][Descripcion].ToString();
                            sDescripcion = sDescripcion.Trim();
                            return false;
                        }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }

    public class MsgBox : System.Web.UI.WebControls.WebControl, System.Web.UI.IPostBackEventHandler
    {
        protected List<string> FunctionOutputArray = new List<string>();

        enum MsgType
        {
            AlertMsg = 1,
            ConfirmMsg = 2,
            PromptMsg = 3
        }

        private string _Key;
        private bool _PostBackOnYes;
        private bool _PostBackOnNo;
        private bool _PostBackOnPrompt;
        private MsgType _MsgType;
        private Page pageContainer;

        public EventHandler YesSelected(object sender, string Key) { return null; }
        public EventHandler NoSelected(object sender, string Key) { return null; }
        public EventHandler PromptResponse(object sender, string Key, string Value) { return null; }

        private string stScriptFinal = string.Empty;
        public string stScript = string.Empty;
        public MsgBox(Page _pageContainer)
        {
            pageContainer = _pageContainer;
        }

        public string ReplaceSpecialChars(string str)
        {
            return str.Replace("'", "").Replace("\\", "\\\\").Replace("\"", string.Empty).Replace("\n", "</br>").Replace("\r", string.Empty);
        }
        public void SetConfirmation(string stConfirmationMessage, string stTargetControlID, string Key, bool PostBackOnYes, bool PostBackOnNo, int? Width, int? Height, string stTitle)
        {
            Width = Width == null ? 300 : Width;
            Height = Height == null ? 100 : Height;
            stTitle = stTitle == string.Empty ? "<strong>Confirm</strong>" : stTitle;

            _MsgType = MsgType.ConfirmMsg;

            if (stConfirmationMessage == string.Empty || stTargetControlID == string.Empty || Key == string.Empty)
                return;

            System.Web.UI.WebControls.WebControl WebServerControl = FindControlR(this.NamingContainer, stTargetControlID) as WebControl;
            if (WebServerControl == null)
                return;

            WebServerControl.Attributes.Add("onclick", "radconfirm('" + stConfirmationMessage.Replace("'", "") + "', RadMsgBoxconfirmCallBackFn_" + GetUniqueValue + Key + ", " + Width + ", " + Height + ", null, '" + stTitle + "'); return false;");

            _Key = Key;
            _PostBackOnYes = PostBackOnYes;
            _PostBackOnNo = PostBackOnNo;
            _PostBackOnPrompt = false;

            FunctionOutputArray.Add(GenerateJavaScript());
        }

        public void SetPrompt(string stPromptMessage, string stTargetControlID, string Key, int? Width, int? Height,
                string stTitle, string stDefaultValue)
        {
            Width = Width == null ? 300 : Width;
            Height = Height == null ? 100 : Height;
            stTitle = stTitle == string.Empty ? "<strong>Prompt</strong>" : stTitle;

            _MsgType = MsgType.PromptMsg;

            if (stPromptMessage == string.Empty || stTargetControlID == string.Empty || Key == string.Empty)
                return;

            System.Web.UI.WebControls.WebControl WebServerControl = FindControlR(this.NamingContainer, stTargetControlID) as WebControl;
            if (WebServerControl == null)
                return;

            WebServerControl.Attributes.Add("onclick", "radprompt('" + ReplaceSpecialChars(stPromptMessage) + "', RadMsgBoxpromptCallBackFn_" + GetUniqueValue + Key + ", " + Width + ", " + Height + ", null, '" + stTitle + "', '" + ReplaceSpecialChars(stDefaultValue) + "'); return false;");

            _Key = Key;
            _PostBackOnYes = false;
            _PostBackOnNo = false;
            _PostBackOnPrompt = true;

            FunctionOutputArray.Add(GenerateJavaScript());
            return;
        }


        public void SetAlert(string stAlertMessage, string stTargetControlID, int? Width, int? Height, string stTitle)
        {
            Width = Width == null ? 300 : Width;
            Height = Height == null ? 100 : Height;
            stTitle = stTitle == string.Empty ? "<strong>Alert</strong>" : stTitle;

            _MsgType = MsgType.AlertMsg;
            if (stAlertMessage == string.Empty || stTargetControlID == string.Empty)
                return;

            System.Web.UI.WebControls.WebControl WebServerControl = FindControlR(this.NamingContainer, stTargetControlID) as WebControl;
            if (WebServerControl == null)
                return;

            WebServerControl.Attributes.Add("onclick", "radalert('" + ReplaceSpecialChars(stAlertMessage) + "', " + Width + ", " + Height + ", '" + stTitle + "'); return false;");

            _Key = string.Empty;
            _PostBackOnYes = false;
            _PostBackOnNo = false;
            _PostBackOnPrompt = false;

            return;
        }

        public void ShowAlert(string stAlertMessage, int? Width, int? Height, string stTitle)
        {
            Width = Width == null ? 300 : Width;
            Height = Height == null ? 100 : Height;
            stTitle = stTitle == string.Empty ? "<strong>Alert</strong>" : stTitle;

            _MsgType = MsgType.AlertMsg;
            if (stAlertMessage == string.Empty)
                return;

            stScript =
                @"<script type=""text/javascript"">
                //<![CDATA[

                Sys.Application.add_init({0}AppInit);
                window.document.documentElement.focus();

                function {0}AppInit() {{ 
                    Sys.Application.add_load({0}RunOnce);
                }}
                function {0}RunOnce() {{ 
                // This will only happen once per GET request to the page. 
                    {0}ShowAlert(); 
                    Sys.Application.remove_load({0}RunOnce); 
                }} 
                function {0}ShowAlert() {{ 
                    radalert('{1}', {2}, {3}, '{4}');
                }} 
                //]]> 
            </script>

            ";

            stScript = string.Format(stScript, GetUniqueValue, ReplaceSpecialChars(stAlertMessage), Width, Height, stTitle);

            System.Web.UI.ScriptManager manager = System.Web.UI.ScriptManager.GetCurrent(pageContainer);

            if (manager != null && manager.IsInAsyncPostBack)
                RadScriptManager.RegisterClientScriptBlock(pageContainer, pageContainer.GetType(), "_RadMsgBox_radalert" + GetUniqueValue, stScript, false);
            else if (!pageContainer.ClientScript.IsStartupScriptRegistered("_RadMsgBox_radalert" + GetUniqueValue))
                pageContainer.ClientScript.RegisterStartupScript(pageContainer.GetType(), "_RadMsgBox_radalert" + GetUniqueValue, stScript);

            return;
        }

        public void ShowConfirmation(string stConfirmationMessage, string Key, bool PostBackOnYes, bool PostBackOnNo, int? Width, int? Height, string stTitle)
        {
            Width = Width == null ? 300 : Width;
            Height = Height == null ? 100 : Height;
            stTitle = stTitle == string.Empty ? "<strong>Confirm</strong>" : stTitle;

            _MsgType = MsgType.ConfirmMsg;

            if (stConfirmationMessage == string.Empty || Key == string.Empty)
                return;

            stScript =
            @"<script type=""text/javascript"">
            //<![CDATA[
            Sys.Application.add_init({0}AppInit);
            window.document.documentElement.focus();
            function {0}AppInit() {{ 
                Sys.Application.add_load({0}RunOnce);
            }}
            function {0}RunOnce() {{ 
                // This will only happen once per GET request to the page.
                {0}ShowConfirmation();
                Sys.Application.remove_load({0}RunOnce);
            }}
            function {0}ShowConfirmation() {{ 
                radconfirm('{1}', RadMsgBoxconfirmCallBackFn_{0}{2}, {3}, {4}, null, '{5}');
            }}
            //]]>
        </script>";

            stScript = string.Format(stScript, GetUniqueValue, ReplaceSpecialChars(stConfirmationMessage), Key, Width, Height, stTitle);

            _Key = Key;
            _PostBackOnYes = PostBackOnYes;
            _PostBackOnNo = PostBackOnNo;
            _PostBackOnPrompt = false;

            System.Web.UI.ScriptManager manager = System.Web.UI.ScriptManager.GetCurrent(pageContainer);
            if (manager != null && manager.IsInAsyncPostBack)
                RadScriptManager.RegisterClientScriptBlock(pageContainer, pageContainer.GetType(), "_RadMsgBox_radconfirm", stScript + GenerateJavaScript(), false);
            else if (!pageContainer.ClientScript.IsStartupScriptRegistered("_RadMsgBox_radconfirm"))
                pageContainer.ClientScript.RegisterStartupScript(pageContainer.GetType(), "_RadMsgBox_radconfirm", stScript + GenerateJavaScript());

            FunctionOutputArray.Add(GenerateJavaScript());

            return;
        }



        public void ShowPrompt(string stPromptMessage, string Key, int? Width, int? Height, string stTitle, string stDefaultValue)
        {
            Width = Width == null ? 300 : Width;
            Height = Height == null ? 100 : Height;
            stTitle = stTitle == string.Empty ? "<strong>Prompt</strong>" : stTitle;

            _MsgType = MsgType.PromptMsg;

            if (stPromptMessage == string.Empty || Key == string.Empty)
                return;

            stScript =
            @"<script type=""text/javascript"">
        //<![CDATA[
        Sys.Application.add_init({0}AppInit);
        window.document.documentElement.focus();
        function {0}AppInit() {{ 
            Sys.Application.add_load({0}RunOnce);
        }}
        function {0}RunOnce() {{ 
            // This will only happen once per GET request to the page.
            {0}ShowPrompt();
            Sys.Application.remove_load({0}RunOnce);
        }} 
        function {0}ShowPrompt() {{ 
            radprompt('{1}', RadMsgBoxpromptCallBackFn_{0}{2}, {3}, {4}, null, '{5}', '{6}');
        }} 
        //]]>
        </script>";

            stScript = string.Format(stScript, GetUniqueValue, ReplaceSpecialChars(stPromptMessage), Key, Width, Height, stTitle, stDefaultValue.Replace("'", ""));

            _Key = Key;
            _PostBackOnYes = false;
            _PostBackOnNo = false;
            _PostBackOnPrompt = true;

            System.Web.UI.ScriptManager manager = System.Web.UI.ScriptManager.GetCurrent(pageContainer);
            if (manager != null && manager.IsInAsyncPostBack)
                RadScriptManager.RegisterClientScriptBlock(pageContainer, pageContainer.GetType(), "_RadMsgBox_radconfirm", stScript + GenerateJavaScript(), false);
            else if (!pageContainer.ClientScript.IsStartupScriptRegistered("_RadMsgBox_radconfirm"))
                pageContainer.ClientScript.RegisterStartupScript(pageContainer.GetType(), "_RadMsgBox_radconfirm", stScript + GenerateJavaScript());

            FunctionOutputArray.Add(GenerateJavaScript());

            return;
        }

        public string GetUniqueValue
        {
            get { return this.ID; }
            //get { return "TTMsgBoxId"; }//this.ID; }
            //get { return this.ID == null ? DateTime.Now.Ticks.ToString("x") : this.ID; }
        }


        protected override void OnPreRender(EventArgs e)
        {

            foreach (string stScript in FunctionOutputArray)
                stScriptFinal += stScript;

            if (stScriptFinal != string.Empty)
            {
                System.Web.UI.ScriptManager manager = System.Web.UI.ScriptManager.GetCurrent(pageContainer);
                if (manager != null && manager.IsInAsyncPostBack)
                    RadScriptManager.RegisterStartupScript(pageContainer, pageContainer.GetType(), "_RadMsgBox", stScriptFinal, false);
                else if (!pageContainer.ClientScript.IsStartupScriptRegistered("_RadMsgBox"))
                    pageContainer.ClientScript.RegisterStartupScript(pageContainer.GetType(), "_RadMsgBox", stScriptFinal);

                FunctionOutputArray.Clear();
            }

            base.OnPreRender(e);

            return;
        }


        private string GenerateJavaScript()
        {
            string miPostBackOnYes = string.Empty;
            string miPostBackOnNo = string.Empty;
            string miPostBackOnPrompt = string.Empty;

            if (_PostBackOnYes)
                miPostBackOnYes = pageContainer.ClientScript.GetPostBackEventReference(this, "Yes" + _Key);
            if (_PostBackOnNo)
                miPostBackOnNo = pageContainer.ClientScript.GetPostBackEventReference(this, "No_" + _Key);
            if (_PostBackOnPrompt)
                miPostBackOnPrompt = pageContainer.ClientScript.GetPostBackEventReference(this, "PRM" + _Key);

            stScript = string.Empty;

            switch (_MsgType)
            {
                case MsgType.ConfirmMsg:
                    stScript = @"<script type=""text/javascript"">
                //<![CDATA[
                function RadMsgBoxconfirmCallBackFn_{0}{1}(arg) {{ 
                  if (arg) {{ 
                    {2}
                  }} else {{ 
                    {2}
                  }} 
                }} 
                //]]>
                </script>";

                    stScript = string.Format(stScript, GetUniqueValue, _Key, miPostBackOnYes);

                    break;
                case MsgType.PromptMsg:
                    string stCustomPostBackOnPrompt = miPostBackOnPrompt.Replace("'PRM" + _Key + "'", "'" + _Key + "' + '|' + arg");
                    stScript = @"<script type=""text/javascript""> 
                //<![CDATA[
                function RadMsgBoxpromptCallBackFn_{0}{1}(arg) {{ 
                    {2}
                }} 
                //]]>
                </script>";

                    stScript = string.Format(stScript, GetUniqueValue, _Key, stCustomPostBackOnPrompt);
                    break;
            }

            return stScript;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            if (IsInDesignMode(this))
                writer.Write(this.ID);

            base.Render(writer);
        }

        private bool IsInDesignMode(System.Web.UI.WebControls.WebControl QueControl)
        {
            bool DesignMode = false;
            try
            {
                DesignMode = QueControl.Site.DesignMode;
            }
            catch { }
            return DesignMode;
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            switch (eventArgument.Substring(0, 3))
            {
                case "Yes":
                    YesSelected(this, eventArgument.Substring(3));
                    break;
                case "No_":
                    NoSelected(this, eventArgument.Substring(3));
                    break;
                default:
                    int delim = eventArgument.IndexOf("|");
                    string key = eventArgument.Substring(0, delim);
                    string value = eventArgument.Substring(delim + 1, eventArgument.Length - (delim + 1));
                    PromptResponse(this, key, value);
                    break;
            }

            return;

        }

        private Control FindControlR(Control root, string id)
        {
            Control controlFound;
            if (root != null)
            {
                controlFound = root.FindControl(id);
                if (controlFound != null)
                    return controlFound;

                foreach (Control c in root.Controls)
                {
                    controlFound = FindControlR(c, id);
                    if (controlFound != null)
                        return controlFound;
                }
            }
            return null;
        }
    }

    public enum FileExportFormat
    {
        xlsx = 1,
        xls = 2,
        csv = 3,
        doc = 4,
        docx = 5,
        sxml = 6,
        html = 7,
        xml = 8,
        pdf = 9,

    }

    public class GenericImageButton
    {
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Campo { get; set; }
        public string Valor { get; set; }
        public string Click { get; set; }
        public string ClickJavaScript { get; set; }

        public GenericImageButton(string prNombre, string prImagen, string prCampo, string prValor, string prClick, string prClickJavaScript)
        {
            this.Nombre = prNombre;
            this.Imagen = prImagen;
            this.Campo = prCampo;
            this.Valor = prValor;
            this.Click = prClick;
            this.ClickJavaScript = prClickJavaScript;
        }
    }
}











