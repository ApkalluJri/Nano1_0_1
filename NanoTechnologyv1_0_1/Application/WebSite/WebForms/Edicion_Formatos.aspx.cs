using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Winnovative.WnvHtmlConvert;

namespace WebForms
{
    public partial class Edicion_Formatos : TTBasePage.TTBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                hfID.Value = Page.Request["ID"].ToString();
                hfIDM.Value = Page.Request["IDM"].ToString();
                TTFormatosCS.objectBussinessTTFormatos oFormato = new TTFormatosCS.objectBussinessTTFormatos();
                oFormato.GetByKey(int.Parse(hfID.Value),true);
                hfIdProceso.Value = oFormato.ProcesoId.Value.ToString();
                txtCabecero.Content = oFormato.CabeceroRepleced;
                txtFormato.Content = oFormato.FormatoRepleced;
                txtPie.Content = oFormato.PieRepleced;
                btnPDF.Visible = bool.Parse(Page.Request["Imprimir"]);
                btnGuardar.Visible = bool.Parse(Page.Request["Guardar"]);
                string Query = new TTFormatFunctions().SetQueryDetails(oFormato, hfIDM.Value);
                if (Query.Length > 0)
                {
                    DataSet Datos = Funcion.RegresaDataSet(Query);
                    foreach (DataColumn columna in Datos.Tables[0].Columns)
                    {
                        txtCabecero.Content = txtCabecero.Content.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                        txtFormato.Content = txtFormato.Content.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                        txtPie.Content = txtPie.Content.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                    }
                }
                List<TTFormatosCS.TTFormatsVariables> lk=new List<TTFormatosCS.TTFormatsVariables>();
            }
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            byte[] pdfBytes = TTFormatFunctions.ConvertHTMLStringToPDF(txtFormato.Content, txtCabecero.Content, txtPie.Content);
            // send the PDF document as a response to the browser for download
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "binary/octet-stream");
            response.AddHeader("Content-Disposition",
                "attachment; filename=ConversionRlesult" + Guid.NewGuid().ToString() + ".pdf; size=" + pdfBytes.Length.ToString());
            response.Flush();
            response.BinaryWrite(pdfBytes);
            response.Flush();
            response.End();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TTFormatosCS.objectBussinessTTFormatos oFormato = new TTFormatosCS.objectBussinessTTFormatos();
            oFormato.GetByKey(int.Parse(hfID.Value), true);

            if (oFormato.Columna != null)
            {
                txtCabecero.Content = oFormato.CabeceroRepleced;
                txtFormato.Content = oFormato.FormatoRepleced;
                txtPie.Content = oFormato.PieRepleced;
                string Query = new TTFormatFunctions().SetQueryDetails(oFormato, hfIDM.Value);
                if (Query.Length > 0)
                {
                    DataSet Datos = Funcion.RegresaDataSet(Query);
                    foreach (DataColumn columna in Datos.Tables[0].Columns)
                    {
                        txtCabecero.Content = txtCabecero.Content.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                        txtFormato.Content = txtFormato.Content.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                        txtPie.Content = txtPie.Content.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                    }
                }
                byte[] pdfBytes = TTFormatFunctions.ConvertHTMLStringToPDF(txtFormato.Content, txtCabecero.Content, txtPie.Content);
                TTFormatFunctions.GuardarPDF(oFormato.ProcesoId.Value, pdfBytes, hfIDM.Value, oFormato.Columna.Value,this.MyUserData);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "var l=GetRadWindow().GetWindowManager();var k=l._getStandardPopup('alert','Archivo guardado en campo');k.setSize(330,100);k.show();k.center();", true);
            }
        }


    }
}








