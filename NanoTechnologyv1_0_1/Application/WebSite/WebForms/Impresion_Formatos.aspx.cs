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
    public partial class Impresion_Formatos : TTBasePage.TTBasePage
    {

        private DataTable DTFormatos
        {
            set
            {
                ViewState["DTFormatos"] = value;
            }
            get
            {
                return (DataTable)ViewState["DTFormatos"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hfIdProceso.Value = Page.Request["idProceso"].ToString();
                hfIDM.Value = Page.Request["IDM"].ToString();
                DTFormatos = TTFormatosCS.objectBussinessTTFormatos.getFormatos(int.Parse(Session["globalTipoUsuario"].ToString()), int.Parse(hfIdProceso.Value));
                rbListFormatos.DataSource = DTFormatos;
                rbListFormatos.DataBind();
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            if (rbListFormatos.SelectedValue != "0")
            {
                int iInicio = 0;
                string busqueda = "";
                string busquedaAnterior = "";
                int iInicioMultiRenglon = 0;
                int iFinMultiRenglon = 0;
                string TextoMultiRenglon = "";
                TTFormatosCS.objectBussinessTTFormatos oFormato = new TTFormatosCS.objectBussinessTTFormatos();
                oFormato.GetByKey(int.Parse(rbListFormatos.SelectedValue), true);
                string Cabecero = oFormato.CabeceroRepleced;
                string Formato = oFormato.FormatoRepleced;
                string Pie = oFormato.PieRepleced;
                string Query = new TTFormatFunctions().SetQueryDetails(oFormato, hfIDM.Value);
                if (Query.Length > 0)
                {
                    DataSet Datos = Funcion.RegresaDataSet(Query);
                    foreach (DataColumn columna in Datos.Tables[0].Columns)
                    {
                        string valor = Datos.Tables[0].Rows[0][columna].ToString();
                        if (valor == "True")
                            valor = "Sí";
                        if (valor == "False")
                            valor = "No";
                        Cabecero = Cabecero.Replace("@@" + columna.ColumnName + "@@", valor);



                        //Revisar si el campo es multirenglón, si es así deberá copiar todo el <TR> donde se encuentra el multirenglón por cada registro del dataset
                        iInicio = columna.ColumnName.IndexOf(".");
                        if (columna.ColumnName.IndexOf(".", iInicio + 1) != -1)
                        {
                            busqueda = columna.ColumnName.Substring(iInicio + 1, columna.ColumnName.IndexOf(".", iInicio + 1) - iInicio - 1);
                            if (busqueda != "")
                            {
                                if (busqueda != busquedaAnterior)
                                {
                                    if (Funcion.RegresaDato("select isnull(count(*),0) from ttmetadata t inner join ttmetadata t2 on t.dependientetabla = t2.DNTID where t.DTID=" + busqueda + " and t2.Identificador=1") == "2")
                                    {
                                        //ciclo por cada registro del dataset
                                        for (int i = 0; i <= Datos.Tables[0].Rows.Count - 1; i++)
                                        {
                                            //obtener todo el texto del TR
                                            for (int iTR = Formato.IndexOf(columna.ColumnName); iTR > 0; iTR--)
                                            {
                                                if (Formato.Substring(iTR, 3).ToUpper() == "<TR")
                                                {
                                                    iInicioMultiRenglon = iTR;
                                                    iTR = 0;
                                                }
                                            }

                                            for (int iTR = Formato.IndexOf(columna.ColumnName); iTR <= Formato.Length - 1; iTR++)
                                            {
                                                if (Formato.Substring(iTR, 5).ToUpper() == "</TR>")
                                                {
                                                    iFinMultiRenglon = iTR;
                                                    iTR = Formato.Length;
                                                }
                                            }
                                            if (i < Datos.Tables[0].Rows.Count - 1)
                                                TextoMultiRenglon = Formato.Substring(iInicioMultiRenglon, iFinMultiRenglon - iInicioMultiRenglon + 5);

                                            //reemplazar todos los valores
                                            foreach (DataColumn columnaMulti in Datos.Tables[0].Columns)
                                            {
                                                Formato = Formato.Replace("@@" + columnaMulti.ColumnName + "@@", Datos.Tables[0].Rows[i][columnaMulti].ToString());
                                            }

                                            //volver a obtener el fin del renglón, después de llenar los datos debido a que cambió la longitud
                                            for (int iTR = iInicioMultiRenglon; iTR <= Formato.Length - 1; iTR++)
                                            {
                                                if (Formato.Substring(iTR, 5).ToUpper() == "</TR>")
                                                {
                                                    iFinMultiRenglon = iTR;
                                                    iTR = Formato.Length;
                                                }
                                            }
                                            //Copiarlo despues del último tr
                                            if (i < Datos.Tables[0].Rows.Count - 1)
                                                Formato = Formato.Substring(0, iFinMultiRenglon + 5) + TextoMultiRenglon + Formato.Substring(iFinMultiRenglon + 5);
                                        }


                                    }
                                    busquedaAnterior = busqueda;
                                }
                            }
                        }
                        Formato = Formato.Replace("@@" + columna.ColumnName + "@@", valor);
                        Pie = Pie.Replace("@@" + columna.ColumnName + "@@", valor);
                    }
                }
                byte[] pdfBytes = TTFormatFunctions.ConvertHTMLStringToPDF(Formato, Cabecero, Pie);
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
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "impresiones", "var wii = GetRadWindow().GetWindowManager().open('Reporte_por_Renglon.aspx?idProceso=" + hfIdProceso.Value + "',null); wii.SetSize(850, 530);  wii.Center();", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rbListFormatos.SelectedValue != "0")
            {
                TTFormatosCS.objectBussinessTTFormatos oFormato = new TTFormatosCS.objectBussinessTTFormatos();
                oFormato.GetByKey(int.Parse(rbListFormatos.SelectedValue), true);

                if (oFormato.Columna != null)
                {
                    string Cabecero = oFormato.CabeceroRepleced;
                    string Formato = oFormato.FormatoRepleced;
                    string Pie = oFormato.PieRepleced;

                    string Query = new TTFormatFunctions().SetQueryDetails(oFormato, hfIDM.Value);
                    if (Query.Length > 0)
                    {
                        DataSet Datos = Funcion.RegresaDataSet(Query);
                        foreach (DataColumn columna in Datos.Tables[0].Columns)
                        {
                            Cabecero = Cabecero.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                            Formato = Formato.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                            Pie = Pie.Replace("@@" + columna.ColumnName + "@@", Datos.Tables[0].Rows[0][columna].ToString());
                        }
                    }
                    byte[] pdfBytes = TTFormatFunctions.ConvertHTMLStringToPDF(Formato, Cabecero, Pie);
                    TTFormatFunctions.GuardarPDF(oFormato.ProcesoId.Value, pdfBytes, hfIDM.Value, oFormato.Columna.Value, this.MyUserData);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", "var l=GetRadWindow().GetWindowManager();var k=l._getStandardPopup('alert','Archivo guardado en campo');k.setSize(330,100);k.show();k.center();", true);
                }
            }

        }

        protected void rbListFormatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbListFormatos.SelectedValue == "0")
            {
                btnEditar.Visible = false;
                btnGuardar.Visible = false;
                btnImprimir.Visible = true;
            }
            else
            {
                TTFormatosCS.objectBussinessTTFormatos oFormato = new TTFormatosCS.objectBussinessTTFormatos();
                oFormato.GetByKey(int.Parse(hfIDM.Value), true);

                DataRow Renglon = DTFormatos.Select("idFormato = " + rbListFormatos.SelectedValue).FirstOrDefault();
                btnEditar.Visible = Convert.ToBoolean(Renglon["Editar"]);
                btnGuardar.Visible = Convert.ToBoolean(Renglon["Guardar"]) && oFormato.Columna != null;
                btnImprimir.Visible = Convert.ToBoolean(Renglon["Imprimir"]);
                hfPermisoImprimir.Value = btnImprimir.Visible.ToString();
                hfPermisoGuardar.Value = btnGuardar.Visible.ToString();
            }
        }


    }
}







