﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using App_Code.TTBusinessRules;
namespace FormsSystem
{
    public partial class FormsSystem_TTExporta : TTBasePage.TTBasePage
    {
        protected string businessRuleOperation = string.Empty;
        protected int process = 0;

        protected override void OnUnload(EventArgs e)
        {
            switch (businessRuleOperation)
            {
                case "Print":
                    //---------------------------------------------------------------------------------------------------------------
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.BeforeClose, process);
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.AfterClose, process);
                    //---------------------------------------------------------------------------------------------------------------
                    break;
                case "Export":
                    //---------------------------------------------------------------------------------------------------------------
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.Export, TTenumBusinessRules_ProcessEvent.BeforeClose, process);
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.Export, TTenumBusinessRules_ProcessEvent.AfterClose, process);
                    //---------------------------------------------------------------------------------------------------------------
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSecurityPage();

            if (Request["brOperation"] != null)
                businessRuleOperation = Request["brOperation"].ToString();
            if (Request["process"] != null)
                process = int.Parse(Request["process"].ToString());

            switch (businessRuleOperation)
            {
                case "Print":
                    //---------------------------------------------------------------------------------------------------------------
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.OpenWindows, process);
                    //---------------------------------------------------------------------------------------------------------------
                    break;
                case "Export":
                    //---------------------------------------------------------------------------------------------------------------
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.Export, TTenumBusinessRules_ProcessEvent.OpenWindows, process);
                    //---------------------------------------------------------------------------------------------------------------
                    break;
            }

            this.Header.Title = MyTraductor.getMessage(23, "Página de Impresión");

            try
            {
                if (Session["dsGrid"] != null)
                {
                    DataTable dt = (DataTable)Session["dsGrid"];
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName.Contains("_") == true)
                        {
                            column.ColumnName = column.ColumnName.Replace("_", " ");
                        }
                    }
                    Session.Remove("dsGrid");
                    GenerateReportViewer(dt);
                }
            }
            catch (Exception ex)
            {
                Response.Write(@ex.Message.ToString());
            }

            if (Request["PrintDialog"] != null)
                Page.ClientScript.RegisterStartupScript(typeof(Page), "OpenPrintDialog", "<script language='javascript'>" + trvwReport.ClientID + ".PrintReport();</script>");
        }

        protected void GenerateReportViewer(DataTable dataSource)
        {
            double locationHeader = 0;
            int maxWidth;
            GenericListReport report = new GenericListReport();
            int count = dataSource.Columns.Count;

            report.DataSource = dataSource;
            //report.ReportTitle = "Lista de " + Funcion.RegresaDato("select nombre from ttproceso where idproceso=" + process.ToString());

            try
            {
                TTProcesoCS.objectBussinessTTProceso myProceso = new TTProcesoCS.objectBussinessTTProceso();
                DataSet ds = myProceso.GetByKeyIdProceso(process);
                string sProcessName = ds.Tables[0].Rows[0]["TTProceso_Nombre"].ToString();
                string title = string.Format(MyTraductor.getMessage(4, this.Title), MyTraductor.getTextProcess(process, MyFunctions.GenerateName(sProcessName)));
                report.ReportTitle = title.Replace("_", " ");
            }
            catch { }

            DataTable dt = report.ReportDataTable;
            Telerik.Reporting.ReportItemBase[] headColumnList = new Telerik.Reporting.ReportItem[count];
            Telerik.Reporting.ReportItemBase[] detailColumnList = new Telerik.Reporting.ReportItem[count];

            for (int column = 0; column < count; column++)
            {
                string columnName = dataSource.Columns[column].ColumnName;
                maxWidth = Funcion.MaxColumnLenght(dataSource, columnName);
                Telerik.Reporting.TextBox header = Funcion.CreateTxtHeader(columnName, locationHeader, maxWidth);
                headColumnList[column] = header;
                Telerik.Reporting.TextBox textBox = Funcion.CreateTxtDetail(columnName, locationHeader, maxWidth);
                textBox.Size = header.Size;
                if (dataSource.Columns[column].DataType == typeof(decimal))
                    textBox.Format = "{0:c}";
                detailColumnList[column] = textBox;
                locationHeader += header.Width.Value;
            }

            report.LabelsGroupHeader.Items.AddRange(headColumnList);
            report.LabelsGroupHeader.Style.BackgroundColor = System.Drawing.Color.SteelBlue;
            report.Detail.Items.AddRange(detailColumnList);
            //----------------------- Binding report -------------------------
            trvwReport.Report = report;
            trvwReport.RefreshReport();

            report.DataSource = dataSource;
            trvwReport.DataBind();
        }


        private static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }

                if (current.HasControls())
                {
                    PrepareControlForExport(current);
                }
            }
        }

        protected void GetControlString(Control control, ref string str)
        {
            if (control is DataControlFieldCell && control.Controls.Count == 0)
                str = (control as DataControlFieldCell).Text;
            else
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    Control current = control.Controls[i];
                    if (current is LinkButton)
                        str = (current as LinkButton).Text;
                    else if (current is ImageButton)
                        str = (current as ImageButton).AlternateText;
                    else if (current is HyperLink)
                        str = (current as HyperLink).Text;
                    else if (current is DropDownList)
                        str = (current as DropDownList).SelectedItem.Text;
                    else if (current is CheckBox)
                        str = (current as CheckBox).Checked ? "True" : "False";

                    if (current.HasControls())
                    {
                        GetControlString(current, ref str);
                    }

                }
        }
    }
}







