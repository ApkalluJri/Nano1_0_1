using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using App_Code.TTBusinessRules;

namespace FormsSystem.TTReportes
{
public partial class WebForms_Reporte_por_Renglon : TTBasePage.TTBasePage
{
    private string[] arrayNombreTabs;
    private string[] arrayNombreColumnasMulti;
    private string[] arrayNombreColumnasMultiDesc;
    private string[] arrayTipoDatoColumnasMulti;
    protected int process = 0;

    protected override void OnUnload(EventArgs e)
    {
        //---------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.BeforeClose, process);
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.AfterClose, process);
        //---------------------------------------------------------------------------------------------------------------        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Alias"] = null;
        if (Request["idProceso"] != null)
            process = int.Parse(Request["idProceso"].ToString());
        //---------------------------------------------------------------------------------------------------------------
        ApplyBusinessRules(TTenumBusinessRules_Operacion.Print, TTenumBusinessRules_ProcessEvent.OpenWindows, process);
        //---------------------------------------------------------------------------------------------------------------
        //Session["Llave"] contiene la clave del renglon seleccionado a imprimir		
        bool Multiren = false;
        if (Session["Llave"] != null)
        {
            if (!Page.IsPostBack)
            {

                //Recibir Clave de Proceso para trabajar
                Session["idProceso"] = Page.Request["idProceso"].ToString();

                TTDataLayerCS.BD db2 = new TTDataLayerCS.BD();
                SqlCommand com2 = new SqlCommand("spGetTabDescripcion");
                com2.Parameters.Add("@idProceso", SqlDbType.Int).Value = Int32.Parse(Session["idProceso"].ToString());
                com2.CommandType = CommandType.StoredProcedure;
                DataSet ds2 = db2.Consulta(com2);

                int contTab = 0;
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    arrayNombreTabs = new string[ds2.Tables[0].Rows.Count];
                    contTab = ds2.Tables[0].Rows.Count;
                    for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                    {
                        arrayNombreTabs[j] = ds2.Tables[0].Rows[j].ItemArray[0].ToString();

                        Table tabla = new Table();
                        TableRow rowHeader = new TableRow();
                        TableCell celdaTab = new TableCell();
                        Label labelTab = new Label();
                        celdaTab.CssClass = "td_input_header";

                        labelTab.ID = "lbl" + ds2.Tables[0].Rows[j].ItemArray[0].ToString();
                        labelTab.Text = ds2.Tables[0].Rows[j].ItemArray[0].ToString();
                        labelTab.Font.Bold = true;
                        celdaTab.Controls.Add(labelTab);
                        rowHeader.Cells.Add(celdaTab);
                        tabla.Rows.Add(rowHeader);
                        tabla.ID = string.Concat(ds2.Tables[0].Rows[j].ItemArray[0].ToString().Trim());
                        Panel1.Controls.Add(tabla);
                    }
                }

                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand com = new SqlCommand("spGetDatosBusquedattMetadata2");
                com.Parameters.Add("@idProceso", SqlDbType.Int).Value = Int32.Parse(Session["idProceso"].ToString());
                com.CommandType = CommandType.StoredProcedure;
                DataSet ds = db.Consulta(com);
                DataTable dtb = ds.Tables[0];

                string sSql = "";//campos del select				
                string from = "";
                string Where = "";

                string sSqlMultiRen = "";//campos del select del multirenglon
                //string sSqlMultiList = "";//campos del select del multi List
                string fromMulriRen = "";//from del multirenglon
                bool generarAliasTabla = false;
                string aliasTabla = "";

                if (dtb.Rows.Count > 0)
                {
                    string[] arrayNombreColumnas;
                    string[] arrayTipoDatoColumnas;
                    string[] arrayDTIDColumnas;
                    string[] arrayMultirenglon;
                    string[] arrayListMultiSeleccion;
                    string[] arraySelectTablaCampo;//comparar que no se repita el mismo select

                    arrayNombreColumnas = new string[dtb.Rows.Count];
                    arrayTipoDatoColumnas = new string[dtb.Rows.Count];
                    arrayDTIDColumnas = new string[dtb.Rows.Count];
                    arrayMultirenglon = new string[dtb.Rows.Count];
                    arrayListMultiSeleccion = new string[dtb.Rows.Count];
                    arraySelectTablaCampo = new string[dtb.Rows.Count];

                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        //si es dependiente
                        if (dtb.Rows[i].ItemArray[8].ToString() == "True")
                        {
                            //Validar si es multirenglon
                            //select count(DTID),secuencial,dependiente from ttmetadata where dntid=9462 and Identificador=1 group by secuencial,dependiente

                            TTDataLayerCS.BD db6 = new TTDataLayerCS.BD();
                            SqlCommand com6 = new SqlCommand("spobtentipodt");
                            com6.Parameters.Add("@DNTId", SqlDbType.Int).Value = int.Parse(dtb.Rows[i].ItemArray[1].ToString());
                            com6.Parameters.Add("@DTId", SqlDbType.Int).Value = int.Parse(dtb.Rows[i].ItemArray[0].ToString());
                            com6.CommandType = CommandType.StoredProcedure;
                            //SqlCommand com6 = new SqlCommand(string.Concat("select ttmetadata.secuencial,ttmetadata.dependiente,ttmetadata.DependienteTabla,ttmetadata.dtid from ttmetadata where ttmetadata.dntid='", dtb.Rows[i].ItemArray[12].ToString(), "' and ttmetadata.Identificador=1"));
                            //com6.CommandType = CommandType.Text;

                            DataSet ds6 = db6.Consulta(com6);
                            //string Folio = "";
                            if (ds6.Tables[0].Rows.Count > 0)
                            {

                                if (ds6.Tables[0].Rows[0].ItemArray[0].ToString().ToUpper() == "MULTIRENGLON")
                                {

                                    //ES MULTIRENGLON												    
                                    Multiren = true;
                                    sSql = sSql + ",'Multirenglon'";
                                    arraySelectTablaCampo[i] = "Multirenglon" + i.ToString();

                                }
                                if (ds6.Tables[0].Rows[0].ItemArray[0].ToString().ToUpper() == "MULTISELECCION")
                                {
                                    //ES LIST												    
                                    sSql = sSql + ",'LIST'";
                                    Multiren = true;
                                    arraySelectTablaCampo[i] = "LIST" + i.ToString();
                                }
                                if (Multiren)
                                {
                                    Multiren = false;
                                    //Llamar al sp para metadata de multirenglon
                                    TTDataLayerCS.BD db5 = new TTDataLayerCS.BD();
                                    SqlCommand com5 = new SqlCommand("spGetDatosBusquedattMetadata3");
                                    com5.Parameters.Add("@Tabla", SqlDbType.NVarChar, 8).Value = GeneraNombre(dtb.Rows[i].ItemArray[12].ToString());
                                    com5.CommandType = CommandType.StoredProcedure;
                                    DataSet ds5 = db5.Consulta(com5);
                                    if (ds5.Tables[0].Rows.Count > 0)
                                    {
                                        arrayTipoDatoColumnasMulti = new string[ds5.Tables[0].Rows.Count];
                                        arrayNombreColumnasMulti = new string[ds5.Tables[0].Rows.Count];
                                        arrayNombreColumnasMultiDesc = new string[ds5.Tables[0].Rows.Count];

                                        for (int contColMulti = 0; contColMulti < ds5.Tables[0].Rows.Count; contColMulti++)
                                        {
                                            //si es dependiente
                                            if (ds5.Tables[0].Rows[contColMulti].ItemArray[3].ToString() == "True")
                                            {
                                                arrayNombreColumnasMulti[contColMulti] = GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());
                                                arrayNombreColumnasMultiDesc[contColMulti] = GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());
                                                arrayTipoDatoColumnasMulti[contColMulti] = "3";//texto//ds5.Tables[0].Rows[contColMulti].ItemArray[7].ToString();

                                                if (GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) == "Alumno" && GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()) == "Nombre")
                                                {
                                                    //Es una dependencia simple(ComboBox)
                                                    if (sSqlMultiRen != "")
                                                        sSqlMultiRen = sSqlMultiRen + ", ltrim(rtrim(M" + contColMulti + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()) + "))+' '+ltrim(rtrim(M" + contColMulti + ".Apellido_Paterno))+' '+ltrim(rtrim(M" + contColMulti + ".Apellido_Materno)) AS " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());
                                                    else
                                                        sSqlMultiRen = "Select ltrim(rtrim(M" + contColMulti + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()) + "))+' '+ltrim(rtrim(M" + contColMulti + ".Apellido_Paterno))+' '+ltrim(rtrim(M" + contColMulti + ".Apellido_Materno)) AS " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());

                                                    if (fromMulriRen != "")
                                                        fromMulriRen = fromMulriRen + " LEFT JOIN " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + " AS M" + contColMulti + " ON M" + contColMulti + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[5].ToString()) + "=" + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());
                                                    else
                                                        fromMulriRen = " FROM " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + " LEFT JOIN " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + " AS M" + contColMulti + " ON M" + contColMulti + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[5].ToString()) + "=" + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());
                                                }
                                                else
                                                {
                                                    if (GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) == "Instructor" && GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()) == "Nombre")
                                                    {
                                                        //Es una dependencia simple(ComboBox)
                                                        if (sSqlMultiRen != "")
                                                            sSqlMultiRen = sSqlMultiRen + ", ltrim(rtrim(M" + contColMulti + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()) + "))+' '+ltrim(rtrim(M" + contColMulti + ".Apellido_Paterno))+' '+ltrim(rtrim(M" + contColMulti + ".Apellido_Materno)) AS " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());
                                                        else
                                                            sSqlMultiRen = "Select ltrim(rtrim(M" + contColMulti + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()) + "))+' '+ltrim(rtrim(M" + contColMulti + ".Apellido_Paterno))+' '+ltrim(rtrim(M" + contColMulti + ".Apellido_Materno)) AS " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());

                                                        if (fromMulriRen != "")
                                                            fromMulriRen = fromMulriRen + " LEFT JOIN " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + " AS M" + contColMulti + " ON M" + contColMulti + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[5].ToString()) + "=" + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());
                                                        else
                                                            fromMulriRen = " FROM " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + " LEFT JOIN " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + " AS M" + contColMulti + " ON M" + contColMulti + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[5].ToString()) + "=" + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());
                                                    }
                                                    else
                                                    {
                                                        string Alias = GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + "_" + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[5].ToString()) + "_" + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString());
                                                        if (Session["Alias"] == null)
                                                            Session["Alias"] = Alias;
                                                        else
                                                            Alias = (string)Session["Alias"];
                                                        //Es una dependencia simple(ComboBox)
                                                        if (sSqlMultiRen != "")
                                                            //sSqlMultiRen = sSqlMultiRen + "," + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()) + " AS '" + ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()+"'";
                                                            //sSqlMultiRen = sSqlMultiRen + "," + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());
                                                            sSqlMultiRen = sSqlMultiRen + "," + Alias + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());
                                                        else
                                                            //sSqlMultiRen = "Select " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString()) + " AS '" + ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString() + "'";
                                                            //sSqlMultiRen = "Select " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());
                                                            sSqlMultiRen = "Select " + Alias + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[6].ToString());


                                                        if (fromMulriRen != "")
                                                            fromMulriRen = fromMulriRen + " LEFT JOIN " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + " ON " + Alias + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[5].ToString()) + "=" + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());
                                                        else
                                                            fromMulriRen = " FROM " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + " LEFT JOIN " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[4].ToString()) + " AS " + Alias + " ON " + Alias + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[5].ToString()) + "=" + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());

                                                    }
                                                }
                                            }
                                            else
                                            {
                                                arrayNombreColumnasMulti[contColMulti] = GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());
                                                arrayNombreColumnasMultiDesc[contColMulti] = ds5.Tables[0].Rows[contColMulti].ItemArray[1].ToString();
                                                arrayTipoDatoColumnasMulti[contColMulti] = ds5.Tables[0].Rows[contColMulti].ItemArray[7].ToString();

                                                if (sSqlMultiRen != "")
                                                    sSqlMultiRen = sSqlMultiRen + "," + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());
                                                else
                                                    sSqlMultiRen = "Select " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString()) + "." + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[0].ToString());

                                                if (fromMulriRen == "")
                                                    fromMulriRen = " FROM " + GeneraNombre(ds5.Tables[0].Rows[contColMulti].ItemArray[2].ToString());

                                            }

                                        }
                                        DataSet dsWheremulti = Funcion.RegresaDataSet("select dnt.Nombre_Tabla,t.Nombre,t.tipo_de_dato from ttmetadata t inner join TTDNT dnt on t.DNTID = dnt.DNTID inner join ttproceso p on t.procesoid = p.idproceso where t.dntid = " + dtb.Rows[i].ItemArray[12].ToString() + " and t.Identificador=1 and t.Dependiente=1");
                                        String sWhereMulti = "";
                                        if (dsWheremulti.Tables[0].Rows.Count != 0)
                                        {
                                            if (dsWheremulti.Tables[0].Rows[0]["Tipo_de_Dato"].ToString() == "3")
                                            {
                                                sWhereMulti = " Where " + GeneraNombre(dsWheremulti.Tables[0].Rows[0]["Nombre_Tabla"].ToString()) + "." + GeneraNombre(dsWheremulti.Tables[0].Rows[0]["Nombre"].ToString()) + " = '" + Session["Llave"].ToString().Trim() + "' ";
                                            }
                                            else
                                            {
                                                sWhereMulti = " Where " + GeneraNombre(dsWheremulti.Tables[0].Rows[0]["Nombre_Tabla"].ToString()) + "." + GeneraNombre(dsWheremulti.Tables[0].Rows[0]["Nombre"].ToString()) + " = " + Session["Llave"].ToString().Trim();
                                            }
                                        }
                                        arrayMultirenglon[i] = string.Concat(sSqlMultiRen, fromMulriRen, sWhereMulti);
                                    }
                                }
                                else
                                {

                                    //Es una dependencia simple(ComboBox)

                                    if (sSql != "")
                                    {
                                        for (int a = 0; a < i; a++)
                                        {
                                            if (arraySelectTablaCampo[a].ToString().Trim() == string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()), ".", GeneraNombre(dtb.Rows[i].ItemArray[11].ToString())))
                                            {
                                                // ya existe este select generar alias a la tabla
                                                aliasTabla = string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()), i.ToString());
                                                generarAliasTabla = true;
                                                a = i;
                                            }
                                        }

                                        if (generarAliasTabla)
                                        {
                                            if (GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) == "Instructor" && GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) == "Nombre")
                                            {
                                                sSql = sSql + ", ltrim(rtrim(" + aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + "))+' '+ltrim(rtrim(" + aliasTabla + ".Apellido_Paterno))+' '+ltrim(rtrim(" + aliasTabla + ".Apellido_Materno)) AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                arraySelectTablaCampo[i] = aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                            }
                                            else
                                            {
                                                if (GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) == "Alumno" && GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) == "Nombre")
                                                {
                                                    sSql = sSql + ", ltrim(rtrim(" + aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + "))+' '+ltrim(rtrim(" + aliasTabla + ".Apellido_Paterno))+' '+ltrim(rtrim(" + aliasTabla + ".Apellido_Materno)) AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                    arraySelectTablaCampo[i] = aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                                }
                                                else
                                                {
                                                    sSql = sSql + "," + aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + " AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                    arraySelectTablaCampo[i] = aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) == "Instructor" && GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) == "Nombre")
                                            {
                                                sSql = sSql + ", ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + "))+' '+ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + ".Apellido_Paterno))+' '+ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + ".Apellido_Materno)) AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                arraySelectTablaCampo[i] = string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()));
                                            }
                                            else
                                            {
                                                if (GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) == "Alumno" && GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) == "Nombre")
                                                {
                                                    sSql = sSql + ", ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + "))+' '+ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + ".Apellido_Paterno))+' '+ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + ".Apellido_Materno)) AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                    arraySelectTablaCampo[i] = string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()));
                                                }
                                                else
                                                {
                                                    sSql = sSql + "," + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + " AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                    arraySelectTablaCampo[i] = string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()));
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        sSql = "Select " + dtb.Rows[i].ItemArray[9].ToString() + "." + dtb.Rows[i].ItemArray[11].ToString() + " AS " + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                        arraySelectTablaCampo[i] = dtb.Rows[i].ItemArray[9].ToString() + "." + dtb.Rows[i].ItemArray[11].ToString() + " AS " + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                    }
                                    if (from != "")
                                    {
                                        if (generarAliasTabla)
                                        {
                                            generarAliasTabla = false;
                                            //from = from + " LEFT JOIN " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + " " + aliasTabla + " ON " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[10].ToString()) + "=" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());
                                            from = from + " LEFT JOIN " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + " " + aliasTabla + " ON " + aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[10].ToString()) + "=" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());
                                        }
                                        else
                                            from = from + " LEFT JOIN " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + " ON " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[10].ToString()) + "=" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());
                                    }
                                    else
                                        from = " " + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + " LEFT JOIN " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + " ON " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[10].ToString()) + "=" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());
                                }

                            }
                            else
                            {

                                //Es una dependencia simple(ComboBox)

                                if (sSql != "")
                                {
                                    for (int a = 0; a < i; a++)
                                    {
                                        if (arraySelectTablaCampo[a].ToString().Trim() == string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()), ".", GeneraNombre(dtb.Rows[i].ItemArray[11].ToString())))
                                        {
                                            // ya existe este select generar alias a la tabla
                                            aliasTabla = string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()), i.ToString());
                                            generarAliasTabla = true;
                                            a = i;
                                        }
                                    }

                                    if (generarAliasTabla)
                                    {
                                        if (GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) == "Instructor" && GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) == "Nombre")
                                        {
                                            sSql = sSql + ", ltrim(rtrim(" + aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + "))+' '+ltrim(rtrim(" + aliasTabla + ".Apellido_Paterno))+' '+ltrim(rtrim(" + aliasTabla + ".Apellido_Materno)) AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                            arraySelectTablaCampo[i] = aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                        }
                                        else
                                        {
                                            if (GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) == "Alumno" && GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) == "Nombre")
                                            {
                                                sSql = sSql + ", ltrim(rtrim(" + aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + "))+' '+ltrim(rtrim(" + aliasTabla + ".Apellido_Paterno))+' '+ltrim(rtrim(" + aliasTabla + ".Apellido_Materno)) AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                arraySelectTablaCampo[i] = aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                            }
                                            else
                                            {
                                                sSql = sSql + "," + aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + " AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                arraySelectTablaCampo[i] = aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) == "Instructor" && GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) == "Nombre")
                                        {
                                            sSql = sSql + ", ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + "))+' '+ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + ".Apellido_Paterno))+' '+ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + ".Apellido_Materno)) AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                            arraySelectTablaCampo[i] = string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()));
                                        }
                                        else
                                        {
                                            if (GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) == "Alumno" && GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) == "Nombre")
                                            {
                                                sSql = sSql + ", ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + "))+' '+ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + ".Apellido_Paterno))+' '+ltrim(rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + ".Apellido_Materno)) AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                arraySelectTablaCampo[i] = string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()));
                                            }
                                            else
                                            {
                                                sSql = sSql + "," + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()) + " AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";
                                                arraySelectTablaCampo[i] = string.Concat(GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString()));
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    sSql = "Select " + dtb.Rows[i].ItemArray[9].ToString() + "." + dtb.Rows[i].ItemArray[11].ToString() + " AS " + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                    arraySelectTablaCampo[i] = dtb.Rows[i].ItemArray[9].ToString() + "." + dtb.Rows[i].ItemArray[11].ToString() + " AS " + GeneraNombre(dtb.Rows[i].ItemArray[11].ToString());
                                }
                                if (from != "")
                                {
                                    if (generarAliasTabla)
                                    {
                                        generarAliasTabla = false;
                                        //from = from + " LEFT JOIN " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + " " + aliasTabla + " ON " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[10].ToString()) + "=" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());
                                        from = from + " LEFT JOIN " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + " " + aliasTabla + " ON " + aliasTabla + "." + GeneraNombre(dtb.Rows[i].ItemArray[10].ToString()) + "=" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());
                                    }
                                    else
                                        from = from + " LEFT JOIN " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + " ON " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[10].ToString()) + "=" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());
                                }
                                else
                                    from = " " + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + " LEFT JOIN " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + " ON " + GeneraNombre(dtb.Rows[i].ItemArray[9].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[10].ToString()) + "=" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());
                            }
                        }
                        else
                        {
                            if (sSql != "")
                                sSql = sSql + "," + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString()) + " AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";

                            else
                                sSql = "Select top 1 " + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString()) + " AS '" + dtb.Rows[i].ItemArray[5].ToString() + "'";

                            arraySelectTablaCampo[i] = GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString());

                            if (from == "")
                                from = " FROM " + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString());

                            if (Where == "")
                                Where = " Where rtrim(" + GeneraNombre(dtb.Rows[i].ItemArray[6].ToString()) + "." + GeneraNombre(dtb.Rows[i].ItemArray[3].ToString()) + ")='" + Session["Llave"].ToString().Trim() + "'";
                        }
                        arrayTipoDatoColumnas[i] = dtb.Rows[i].ItemArray[7].ToString();
                        arrayNombreColumnas[i] = dtb.Rows[i].ItemArray[5].ToString();
                        Label1.Text = string.Concat("Impresión de ", dtb.Rows[i].ItemArray[6].ToString().Replace("TT", " "));
                        arrayDTIDColumnas[i] = dtb.Rows[i].ItemArray[0].ToString();
                    }
                    string Query = "";
                    Query = string.Concat(sSql, from, Where);

                    //ejecutando la Consulta dinamica
                    TTDataLayerCS.BD db3 = new TTDataLayerCS.BD();
                    SqlCommand com3 = new SqlCommand(Query.ToString());
                    com3.CommandType = CommandType.Text;
                    DataSet ds3 = db3.Consulta(com3);

                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    HtmlTableCell tdM = new HtmlTableCell();

                    //TableCell tdM = new TableCell();					
                    TableCell tdContenido = new TableCell();
                    Label lbl = new Label();
                    //Boolean multirenglon = false;
                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                        {

                            for (int k = 0; k < ds3.Tables[0].Columns.Count; k++)
                            {
                                td = new TableCell();
                                tdContenido = new TableCell();

                                //Validando si es multirrenglon O List de multideleccion al momento de imprimir en pantalla
                                if (ds3.Tables[0].Rows[j].ItemArray[k].ToString() == "Multirenglon" || ds3.Tables[0].Rows[j].ItemArray[k].ToString() == "LIST")
                                {
                                    //multirenglon = true;
                                    //es un multirenglon, agregar grid a la columna
                                    GridView grdMultirenglon = new GridView();
                                    grdMultirenglon.ID = string.Concat("grd", j.ToString(), k.ToString());
                                    TTDataLayerCS.BD db7 = new TTDataLayerCS.BD();
                                    SqlCommand com7 = new SqlCommand(arrayMultirenglon[k].ToString());
                                    com7.CommandType = CommandType.Text;
                                    try
                                    {
                                        DataSet ds7 = db7.Consulta(com7);
                                        if (ds7.Tables[0].Rows.Count > 0)
                                        {
                                            tr = new TableRow();
                                            grdMultirenglon.AutoGenerateColumns = false;
                                            grdMultirenglon.DataSource = ds7;

                                            if (ds3.Tables[0].Rows[j].ItemArray[k].ToString() == "Multirenglon")
                                            {
                                                for (int z = 2; z < arrayNombreColumnasMulti.Length; z++)
                                                    AgregaColumna(grdMultirenglon, arrayNombreColumnasMulti[z].ToString(), arrayNombreColumnasMultiDesc[z].ToString(), int.Parse(arrayTipoDatoColumnasMulti[z].ToString()));
                                            }
                                            else
                                            {
                                                for (int z = 0; z < arrayNombreColumnasMulti.Length; z++)
                                                    AgregaColumna(grdMultirenglon, arrayNombreColumnasMulti[z].ToString(), arrayNombreColumnasMultiDesc[z].ToString(), int.Parse(arrayTipoDatoColumnasMulti[z].ToString()));
                                            }
                                            grdMultirenglon.DataBind();
                                        }

                                        grdMultirenglon.HeaderRow.CssClass = "grd_header";

                                        Label label = new Label();
                                        label.Text = "";
                                        label.Width = 220;
                                        label.ID = "l" + j.ToString() + k.ToString();
                                        tdContenido.Controls.Add(label);
                                        td.Controls.Add(grdMultirenglon);
                                    }
                                    catch { }

                                }
                                else
                                {
                                    Label Etiqueta = new Label();
                                    Label EtiquetaContenido = new Label();
                                    Etiqueta.ID = "lbl_" + k.ToString() + j.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                                    EtiquetaContenido.ID = "lblC_" + k.ToString() + j.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                                    Etiqueta.Text = string.Concat("<b>", arrayNombreColumnas[k].ToString(), "</b>", ": ");

                                    EtiquetaContenido.Text = ds3.Tables[0].Rows[j].ItemArray[k].ToString();
                                    if (arrayTipoDatoColumnas[k].ToString() == "7") //es fecha
                                    {
                                        if (ds3.Tables[0].Rows[j].ItemArray[k].ToString() != "")
                                        {
                                            EtiquetaContenido.Text = string.Format("{0:dd/MMM/yyyy}", DateTime.Parse(ds3.Tables[0].Rows[j].ItemArray[k].ToString()));
                                        }
                                    }
                                    else
                                        if (arrayTipoDatoColumnas[k].ToString() == "5") //es Moneda
                                        {
                                            if (ds3.Tables[0].Rows[j].ItemArray[k].ToString() != string.Empty)
                                                EtiquetaContenido.Text = string.Format("{0:c}", Decimal.Parse(ds3.Tables[0].Rows[j].ItemArray[k].ToString()));
                                        }

                                    Etiqueta.Width = 220;
                                    EtiquetaContenido.Width = 320;
                                    td.Controls.Add(Etiqueta);

                                    tdContenido.Controls.Add(EtiquetaContenido);
                                    td.CssClass = "td_input_body";
                                    tdContenido.CssClass = "td_input_body_Data";
                                }


                                TTDataLayerCS.BD db4 = new TTDataLayerCS.BD();
                                SqlCommand com4 = new SqlCommand(string.Concat("select distinct(ttdominio.Descripcion) from ttdominio where RelacionDT in(select DTID from ttmetadata where ProcesoID=", Session["idProceso"].ToString(), " and DTID=", arrayDTIDColumnas[k], ")"));
                                com4.CommandType = CommandType.Text;
                                DataSet ds4 = db4.Consulta(com4);
                                if (ds4.Tables[0].Rows.Count > 0)
                                {
                                    for (int l = 0; l < contTab; l++)
                                    {
                                        TableRow ren = new TableRow();
                                        //HtmlTableRow renMulti = new HtmlTableRow();
                                        ren.ID = "ren" + k.ToString() + j.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();//string.Concat("renglon", j.ToString(), k.ToString(), l.ToString());// l.ToString())//, k.ToString(), j.ToString(), DateTime.Today.Hour.ToString(), DateTime.Today.Minute.ToString(), DateTime.Today.Second.ToString(), DateTime.Today.Millisecond.ToString());
                                        if (arrayNombreTabs[l].ToString().Trim() == ds4.Tables[0].Rows[0].ItemArray[0].ToString().Trim())
                                        {
                                            ren.Cells.Add(td);
                                            ren.Cells.Add(tdContenido);
                                            ((Table)FindControl(ds4.Tables[0].Rows[0].ItemArray[0].ToString().Trim())).Rows.Add(ren);
                                            l = contTab;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Imprimir", "imprimir();", true);
        }
        //else Sesion Clave no Existe

    }

    private String GeneraNombre(String sCampo)
    {
        sCampo = sCampo.Trim();
        sCampo = sCampo.Replace(" ", "_");
        sCampo = sCampo.Replace(",", "_");
        sCampo = sCampo.Replace(".", "_");
        sCampo = sCampo.Replace(":", "_");
        sCampo = sCampo.Replace(";", "_");
        sCampo = sCampo.Replace("á", "a");
        sCampo = sCampo.Replace("é", "e");
        sCampo = sCampo.Replace("í", "i");
        sCampo = sCampo.Replace("ó", "o");
        sCampo = sCampo.Replace("ú", "u");
        sCampo = sCampo.Replace("ñ", "n");
        sCampo = sCampo.Replace("Á", "A");
        sCampo = sCampo.Replace("É", "E");
        sCampo = sCampo.Replace("Í", "I");
        sCampo = sCampo.Replace("Ó", "O");
        sCampo = sCampo.Replace("Ú", "U");
        sCampo = sCampo.Replace("Ñ", "N");
        return sCampo;
    }
    protected void AgregaColumna(GridView grid, String Campo, String Descripcion, Int32 Tipo)
    {
        BoundField colNueva = new BoundField();
        colNueva.HeaderText = Descripcion.Replace("Funcion", "Funciones");
        colNueva.DataField = Campo.Replace("Funcion", "Funciones");
        colNueva.HtmlEncode = false;

        if (Tipo == 7)
        {
            colNueva.DataFormatString = "{0:dd/MMM/yyyy}";
            colNueva.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        if (Tipo == 5)
        {
            colNueva.DataFormatString = "{0:d}";
            colNueva.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        }
        colNueva.SortExpression = Campo.Replace("Funcion", "Funciones");
        grid.Columns.Add(colNueva);
    }

}

}







