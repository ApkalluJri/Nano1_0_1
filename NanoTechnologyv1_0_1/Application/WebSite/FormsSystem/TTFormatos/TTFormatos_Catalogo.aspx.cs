/**************************************************************************************************
Creador:          TOTALCASE                           
Fecha Creación:   YYYY-MM-DD                   
Descripción:      Pantalla Catalogo TTFormatos
**************************************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Subgurim.Controles;
using System.IO;
using System.Collections.Generic;
using System.Web.Script.Services;
using System.Web.Services;
using App_Code.TTBusinessRules;
using Telerik.Web.UI;
using TTFormatosCS;
using System.Reflection;

namespace WebForms
{
    public partial class TTFormatos_Catalogo : TTBasePage.TTBasePage
    {
        private TTFormatosCS.objectBussinessTTFormatos objFormat = new TTFormatosCS.objectBussinessTTFormatos();
        private WSTTFormatos.GlobalData userData;
        public int iProcess = 17499;
        private String sDNTNombre = "TTFormatos";
        private String sDNTDescripcion = "TTFormatos";
        public int? idFormato;


        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScriptManager cm = Page.ClientScript;
            //String cbRef = cm.GetCallbackEventReference(this, "arg", "ReceiveServerData", "context");
            //String callbackscript = "function callserver(arg,context) {" + cbRef + "}";
            //cm.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackscript, true);



            System.Web.UI.ScriptManager ajaxSM = (System.Web.UI.ScriptManager)this.Page.Master.FindControl("ScriptManager1");
            if (ajaxSM != null)
                ajaxSM.AsyncPostBackTimeout = 3600;



            if (Session["UserGlobalInformation"] == null)
                Response.Redirect("~/FormsSystem/Default.aspx");

            if (Session["idFormato"] != null)
                idFormato = int.Parse(Session["idFormato"].ToString());

            if (!Page.IsPostBack)
            {
                //txtCabecero.DisableFilter(EditorFilters.ConvertToXhtml);
                //txtFormato.DisableFilter(EditorFilters.ConvertToXhtml);
                //txtPie.DisableFilter(EditorFilters.ConvertToXhtml);
                HtmlMeta metatag = new HtmlMeta();
                metatag.Attributes.Add("http-equiv", "X-UA-Compatible");
                metatag.Attributes.Add("content", "IE=8; IE=7; IE=5");
                Page.Header.Controls.AddAt(0, metatag);

                Session["CambiarArchivo"] = 0;
                RevisaLoadArchivo();
                //ConfigWithMetadata();
                fillDataControls();
                if (Session["Tipo_Transaccion"].ToString() == "New")
                {
                    New();
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
                }
                if (Session["Tipo_Transaccion"].ToString() == "Update")
                {
                    Modification(idFormato);
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
                }
                if (Session["Tipo_Transaccion"].ToString() == "Consult")
                {
                    Modification(idFormato);
                    DisableControls();
                    ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.OpenWindows, iProcess);
                }
                SetLanguage();
            }




            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = "Catálogo de " + sDNTNombre.Replace("_", " ");
            lblTitulo.DataBind();
        }

        protected override void OnUnload(EventArgs e)
        {
            //-----------------------------------------------------------------------------------------------------------------------
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
            //ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.AfterClose, iProcess);
            //-----------------------------------------------------------------------------------------------------------------------
        }

        private void SetLanguage()
        {
            try
            {
                string sTitle = string.Format(MyTraductor.getMessage(41, this.Title), MyTraductor.getTextProcess(iProcess, sDNTDescripcion));
                this.Title = sTitle;
                Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
                lblTitulo.Text = sTitle;

                lblGrabar.Text = MyTraductor.getMessage(42, lblGrabar.Text);
                lblGrabaryNuevo.Text = MyTraductor.getMessage(43, lblGrabaryNuevo.Text);
                lblGrabaryCopiar.Text = MyTraductor.getMessage(44, lblGrabaryCopiar.Text);
                lblLimpiar.Text = MyTraductor.getMessage(45, lblLimpiar.Text);
                lblCancelar.Text = MyTraductor.getMessage(46, lblCancelar.Text);

            }
            catch
            { }
        }

        protected void RevisaLoadArchivo()
        {
            if (Session["CambiarArchivo"] != null)
                if (Session["CambiarArchivo"].ToString() == "0")
                {

                    Session["CambiarArchivo"] = 0;
                }
        }

        protected void DisableControls()
        {
            Panel2.Enabled = false;
            cmdClear.Visible = false;
            btn_limpiar_catalog.Visible = false;
            cmdSave.Visible = false;
            btn_grabar_catalog.Visible = false;
            cmdSaveCopy.Visible = false;
            btn_grabar_copiar_catalog.Visible = false;
            cmdSaveNew.Visible = false;
            btn_grabar_nuevo_catalog.Visible = false;
            txtFolio.Enabled = false;
            cbIdModulo.Enabled = false;
            ddlProceso.Enabled = false;
            txtNombre.Enabled = false;
            ddlColumna.Enabled = false;
        }

        override protected void OnInit(EventArgs e)
        {
            LoadSecurityPage();
            //-------------------------------------------------------------------------------------------------------------
            userData = new WSTTFormatos.GlobalData();
            userData.AppToTempFiles = MyUserData.AppToTempFiles;
            userData.ComputerName = MyUserData.ComputerName;
            userData.DatabaseName = MyUserData.DatabaseName;
            userData.Folio = MyUserData.Folio;
            userData.Language = (WSTTFormatos.GlobalDataLanguages)MyUserData.Language;
            userData.ServidorName = MyUserData.ServidorName;
            userData.ServidorNameComputer = MyUserData.ServidorNameComputer;
            userData.UserID = MyUserData.UserID;
            userData.UserName = MyUserData.UserName;
            userData.WindowsVersion = MyUserData.WindowsVersion;
            //-------------------------------------------------------------------------------------------------------------
            ApplyBusinessRules(TTenumBusinessRules_FieldEvent.LostFocus, iProcess);
            //-------------------------------------------------------------------------------------------------------------
            //------------------------------------------------------------------------------------


            //-------------------------------------------------------------------------------------------------------------

            //-------------------------------------------------------------------------------------------------------------
            base.OnInit(e);
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {

        }

        private void fillDataControls()
        {
            cbIdModulo_DataBound();
        }

        protected void cbIdModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)ddlProceso;
            comboBox.ClearSelection();
            comboBox.Text = "";
        }
        protected void cbIdModulo_DataBound()
        {
            DropDownList ddl = (DropDownList)cbIdModulo;
            string sqlQuery = @"select TTModulo.IdModulo as IdModulo,
	        TTModulo.Nombre as Nombre 
	        from TTModulo
	        where TTmodulo.IdModulo in
	        (select TTPermisos_por_modulo.IdModulo as IdModulo
	        from TTPermisos_por_modulo 
	        where IdGrupoUsuario = (select TTUsuarios_Por_Grupo.IdGrupoUsuario from TTUsuarios_Por_Grupo where IdUsuario=" + MyUserData.UserID.ToString() + "))";
            DataSet ds = Funcion.RegresaDataSet(sqlQuery);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ListItem item = new ListItem();
                item.Text = row["Nombre"].ToString();
                item.Value = row["IdModulo"].ToString();
                ddl.Items.Add(item);
                ddl.DataBind();
            }
            ddl.Items.Insert(0, new ListItem("-Seleccionar Módulo-", ""));
        }
        protected void ddlProceso_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            string sqlQuery;
            RadComboBox comboBox;
            if (cbIdModulo.SelectedValue == null || cbIdModulo.SelectedIndex == 0)
            {
                sqlQuery = @"Select Top 50         
                        TTProceso.IdProceso As TTProceso_IdProceso,        
                        TTProceso.Nombre As TTProceso_Nombre,        
                        TTProceso.Pantalla As TTProceso_Pantalla   
                        From  TTProceso          	
                        Where TTProceso.IdProceso in (
                        select TTProceso_del_Modulo.IdProceso from TTProceso_del_Modulo
                        where TTProceso_del_Modulo.IdModulo in(
                        select TTPermisos_por_modulo.IdModulo as IdModulo
                        from TTPermisos_por_modulo 
                        where IdGrupoUsuario = (select TTUsuarios_Por_Grupo.IdGrupoUsuario 
                        from TTUsuarios_Por_Grupo where IdUsuario=" + MyUserData.UserID.ToString() + ")))Order by TTProceso.Nombre";
                comboBox = (RadComboBox)ddlProceso;
            }
            else
            {
                sqlQuery = @"Select Top 50         
                        TTProceso.IdProceso As TTProceso_IdProceso,        
                        TTProceso.Nombre As TTProceso_Nombre,        
                        TTProceso.Pantalla As TTProceso_Pantalla   
                        From  TTProceso          	
                        Where TTProceso.IdProceso in (
                        select TTProceso_del_Modulo.IdProceso from TTProceso_del_Modulo
                        WHERE ( TTProceso.Nombre like '%{0}%'
	                        Or TTProceso.IdProceso like '{0}%' )
                        AND TTProceso_del_Modulo.IdModulo in(
                        select TTPermisos_por_modulo.IdModulo as IdModulo
                        from TTPermisos_por_modulo 
                        where IdGrupoUsuario = (select TTUsuarios_Por_Grupo.IdGrupoUsuario 
                        from TTUsuarios_Por_Grupo where 
                        IdUsuario={1})and IdModulo={2}))Order by TTProceso.Nombre";

                sqlQuery = string.Format(sqlQuery, e.Text.Replace("\'", string.Empty), MyUserData.UserID.ToString(), cbIdModulo.SelectedValue.ToString());

                comboBox = (RadComboBox)ddlProceso;

                DataSet ds = Funcion.RegresaDataSet(sqlQuery);
                comboBox.Items.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    RadComboBoxItem item = new RadComboBoxItem();
                    item.Text = row["TTProceso_IdProceso"].ToString();
                    item.Value = row["TTProceso_IdProceso"].ToString();

                    item.Attributes.Add("TTProceso_Nombre", row["TTProceso_Nombre"].ToString());
                    item.Attributes.Add("TTProceso_IdProceso", row["TTProceso_IdProceso"].ToString());

                    comboBox.Items.Add(item);
                    item.DataBind();
                }
            }
        }

        protected void ddlProceso_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            btnSelProcess_Click();
        }

        protected void btnSelProcess_Click()
        {
            //----------------------------------------------------------------------------------------------------
            WSTTProceso.objectBussinessTTProceso1 dsTemp;
            if (ddlProceso.Text != "")
            {
                WSTTProceso.objectBussinessTTProceso MyDataTTProceso = new WSTTProceso.objectBussinessTTProceso();
                if (MyFunctions.FormatNumberNull(ddlProceso.Text) != null)
                {
                    dsTemp = MyDataTTProceso.GetByKey(MyFunctions.FormatNumberNull(ddlProceso.Text), true);
                    if (dsTemp.Nombre != null)
                    {
                        lblProcesoDesc.Text = dsTemp.Nombre;
                        //solo campos que sean controles de archivo
                        ddlColumna.DataSource = Funcion.RegresaDataSet("select DTID, nombre from ttmetadata where tipo_de_control = 13 and ProcesoId =" + ddlProceso.Text);
                        ddlColumna.DataBind();
                        ddlColumna.Items.Insert(0, new ListItem("", "0"));
                        FillTreeView();
                    }
                    else
                        lblProcesoDesc.Text = "";
                }
                else
                    lblProcesoDesc.Text = "";
            }
            else
                lblProcesoDesc.Text = "";
            //----------------------------------------------------------------------------------------------------
        }

        private void FillTreeView()
        {
            int? idProceso = MyFunctions.FormatNumberNull(ddlProceso.Text);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatosDNT[] myDNTs = myMeta.GetAllDNTs(idProceso.Value);
            RadTreeView1.Nodes.Clear();

            Telerik.Web.UI.RadTreeNode node2 = new Telerik.Web.UI.RadTreeNode("@@Fecha@@", "@@Fecha@@");
            TTFormatsConfigurationsDate Formato = new TTFormatsConfigurationsDate();
            Formato.Posicion1 = TTFormatsConfigurationsEnumDatePositions.DD;
            Formato.Separador1 = "/";
            Formato.Posicion2 = TTFormatsConfigurationsEnumDatePositions.MM;
            Formato.Separador2 = "/";
            Formato.Posicion3 = TTFormatsConfigurationsEnumDatePositions.AAAA;
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            node2.Attributes.Add("formato", oSerializer.Serialize(Formato).Replace("{", "{\"type\":\"TTFormatsConfigurationsDate\","));
            RadTreeView1.Nodes.Add(node2);
            node2 = new Telerik.Web.UI.RadTreeNode("@@Hora@@", "@@Hora@@");
            TTFormatsConfigurationsTime FormatoHora = new TTFormatsConfigurationsTime();
            node2.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoHora).Replace("{", "{\"type\":\"TTFormatsConfigurationsTime\","));
            RadTreeView1.Nodes.Add(node2);
            node2 = new Telerik.Web.UI.RadTreeNode("@@Numero_Pagina@@", "@@Numero_Pagina@@");
            TTFormatsConfigurationsNumbers FormatoNumero = new TTFormatsConfigurationsNumbers();
            node2.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoNumero).Replace("{", "{\"type\":\"TTFormatsConfigurationsNumbers\","));
            //RadTreeView1.Nodes.Add(node2);
            node2 = new Telerik.Web.UI.RadTreeNode("@@Usuario@@", "@@Usuario@@");
            TTFormatsConfigurationsString FormatoTexto = new TTFormatsConfigurationsString();
            node2.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoTexto).Replace("{", "{\"type\":\"TTFormatsConfigurationsString\","));
            RadTreeView1.Nodes.Add(node2);

            foreach (TTMetadata.MetadataDatosDNT dnt in myDNTs)
            {
                Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode(dnt.Descripcion, dnt.DNTID.ToString());
                FillTreeViewChild(ref node, dnt.DNTID.ToString(), dnt.DNTID, null);
                node.AllowDrag = false;
                RadTreeView1.Nodes.Add(node);

            }
            //RadTreeView1.ExpandAllNodes();
        }

        private void FillTreeViewChild(ref Telerik.Web.UI.RadTreeNode treeDNTs, String nodeParent, int? dntid, int? dntFather)
        {
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos[] myDTs = myMeta.GetDatosDNT(dntid.Value);
            foreach (TTMetadata.MetadataDatos dt in myDTs)
            {
                bool DTMultiRenglonLlaveDependiente = false;
                if (dt.Dependiente && dt.Identificador)
                    DTMultiRenglonLlaveDependiente = true;

                if (!DTMultiRenglonLlaveDependiente)
                {
                    Telerik.Web.UI.RadTreeNode childnode = new Telerik.Web.UI.RadTreeNode(dt.Descripcion, nodeParent + "." + dt.DatoID.ToString());
                    switch (dt.TipodeDato)
                    {
                        case TTFunctions.TypeData.Archivo:
                            break;
                        case TTFunctions.TypeData.Color:
                            break;
                        case TTFunctions.TypeData.Decimal:
                            TTFormatsConfigurationsNumbers FormatoNumeroDecimal = new TTFormatsConfigurationsNumbers();
                            childnode.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoNumeroDecimal).Replace("{", "{\"type\":\"TTFormatsConfigurationsNumbers\","));
                            break;
                        case TTFunctions.TypeData.Fecha:
                            TTFormatsConfigurationsDate Formato = new TTFormatsConfigurationsDate();
                            Formato.Posicion1 = TTFormatsConfigurationsEnumDatePositions.DD;
                            Formato.Separador1 = "/";
                            Formato.Posicion2 = TTFormatsConfigurationsEnumDatePositions.MM;
                            Formato.Separador2 = "/";
                            Formato.Posicion3 = TTFormatsConfigurationsEnumDatePositions.AAAA;
                            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                            childnode.Attributes.Add("formato", oSerializer.Serialize(Formato).Replace("{", "{\"type\":\"TTFormatsConfigurationsDate\","));
                            break;
                        case TTFunctions.TypeData.FechaHora:
                            break;
                        case TTFunctions.TypeData.Hora:
                            TTFormatsConfigurationsTime FormatoHora = new TTFormatsConfigurationsTime();
                            childnode.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoHora).Replace("{", "{\"type\":\"TTFormatsConfigurationsTime\","));
                            break;
                        case TTFunctions.TypeData.Logico:
                            TTFormatsConfigurationsString FormatoTextoL = new TTFormatsConfigurationsString();
                            childnode.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoTextoL).Replace("{", "{\"type\":\"TTFormatsConfigurationsString\","));
                            break;
                        case TTFunctions.TypeData.Moneda:
                            TTFormatsConfigurationsCurrency FormatoMoneda = new TTFormatsConfigurationsCurrency();
                            FormatoMoneda.Decimales = 2;
                            FormatoMoneda.Simbolo = "$";
                            childnode.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoMoneda).Replace("{", "{\"type\":\"TTFormatsConfigurationsCurrency\","));
                            break;
                        case TTFunctions.TypeData.Numerico:
                            TTFormatsConfigurationsNumbers FormatoNumero = new TTFormatsConfigurationsNumbers();
                            childnode.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoNumero).Replace("{", "{\"type\":\"TTFormatsConfigurationsNumbers\","));
                            break;
                        case TTFunctions.TypeData.Texto:
                            TTFormatsConfigurationsString FormatoTexto = new TTFormatsConfigurationsString();
                            childnode.Attributes.Add("formato", new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(FormatoTexto).Replace("{", "{\"type\":\"TTFormatsConfigurationsString\","));
                            break;
                    };
                    treeDNTs.Nodes.Add(childnode);
                    bool yaestaba = false;
                    foreach (string valor in nodeParent.Split('.'))
                    {
                        if (valor == dt.DatoID.ToString())
                        {
                            yaestaba = true;
                            break;
                        }
                    }

                    //if (dt.Dependiente && dt.DependienteTabla != dntFather && !yaestaba)//Si es multirenglon evitar el ciclo
                    if (dt.Dependiente && !yaestaba)
                        FillTreeViewChild(ref childnode, nodeParent + "." + dt.DatoID.ToString(), dt.DependienteTabla, dt.DNTID);
                }
            }
        }

        private void New()
        {
        }
        public void Modification(int? Key)
        {
            objFormat = new objectBussinessTTFormatos();
            //objFormat.GlobalInformation = myUserData;
            objFormat.GetByKey(Key, true);

            Session["objFormat"] = objFormat;

            txtFolio.Text = objFormat.idFormato.ToString();
            txtNombre.Text = objFormat.Nombre;
            ddlProceso.Text = objFormat.ProcesoId.ToString();
            if (objFormat.Columna != null)
                ddlColumna.SelectedValue = objFormat.Columna.ToString();

            cbIdModulo.SelectedValue = Funcion.RegresaDato(String.Format("select IdModulo from dbo.TTProceso_del_Modulo where IdProceso = {0}", objFormat.ProcesoId.ToString()));
            txtFormato.Content = objFormat.Formato;
            txtCabecero.Content = objFormat.Cabecero;
            txtPie.Content = objFormat.Pie;

            btnSelProcess_Click();
        }

        //public void ConfigWithMetadata()
        //{
        //    Boolean Foco = false;
        //    WSTTMetadata.objectBussinessTTMetadata myMetadata = new WSTTMetadata.objectBussinessTTMetadata();
        //    WSTTMetadata.TTMetadataFilters[] myFiltro = new WSTTMetadata.TTMetadataFilters[1];
        //    myFiltro[0] = new WSTTMetadata.TTMetadataFilters();
        //    myFiltro[0].ProcesoId = new WSTTMetadata.Dependientes();
        //    myFiltro[0].ProcesoId.List = new string[1];
        //    myFiltro[0].ProcesoId.List[0] = iProcess.ToString();


        //    DataSet ds_controles = new DataSet();
        //    ds_controles = myMetadata.SelAllwithFilters(true, myFiltro);
        //    DataView dv = new DataView(ds_controles.Tables[0]);

        //            dv.RowFilter = "TTMetadata_DTID = " + 46833;
        //    if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //        lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //    else
        //        lblFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //    lblFolio.Text = MyTraductor.getTextDTID(46833, lblFolio.Text);
        //    txtFolio.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //    txtFolio.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //    txtFolio.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        //    if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //        {
        //            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //            {
        //                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //                {
        //                    txtFolio.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //                }
        //                else
        //                {
        //                    txtFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //                }
        //            }
        //            else
        //            {
        //                txtFolio.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            }
        //        }else{
        //            txtFolio.Text = "";
        //        }
        //    //imgOblidFormato.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    //RFVidFormato.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    //tridFormato.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //    if (Foco == false && txtFolio.Enabled == true)
        //    {
        //        GetFocus(txtFolio);
        //        Foco = true;
        //    }        dv.RowFilter = "TTMetadata_DTID = " + 46834;
        //    if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //        lblProceso.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //    else
        //        lblProceso.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //    lblProceso.Text = MyTraductor.getTextDTID(46834, lblProceso.Text);
        //    ddlProceso.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //    ddlProceso.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //    //cddProcesoId.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //    {
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //        {
        //            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //            {
        //                ddlProceso.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //                //cddProcesoId.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //            }
        //            else
        //            {
        //                ddlProceso.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //                //cddProcesoId.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            ddlProceso.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            //cddProcesoId.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //        }
        //    }else{
        //        ddlProceso.ClearSelection();
        //        //cddProcesoId.SelectedValue = "";
        //    }
        //    //trProcesoId.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //    rfvProceso.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    //imgOblProcesoId.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    if (Foco == false && ddlProceso.Enabled == true)
        //    {
        //        GetFocus(ddlProceso);
        //        Foco = true;
        //    }        dv.RowFilter = "TTMetadata_DTID = " + 46835;
        //    if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //        lblColumna.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //    else
        //        lblColumna.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //    lblColumna.Text = MyTraductor.getTextDTID(46835, lblColumna.Text);
        //    ddlColumna.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //    ddlColumna.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //    //cddColumna.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //    if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //    {
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //        {
        //            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //            {
        //                ddlColumna.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //                //cddColumna.SelectedValue = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //            }
        //            else
        //            {
        //                ddlColumna.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //                //cddColumna.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            }
        //        }
        //        else
        //        {
        //            ddlColumna.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            //cddColumna.SelectedValue = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //        }
        //    }else{
        //        ddlColumna.ClearSelection();
        //        //cddColumna.SelectedValue = "";
        //    }
        //    //trColumna.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //    //RFVColumna.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    //imgOblColumna.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    if (Foco == false && ddlColumna.Enabled == true)
        //    {
        //        GetFocus(ddlColumna);
        //        Foco = true;
        //    }        dv.RowFilter = "TTMetadata_DTID = " + 46836;
        //    if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //        lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //    else
        //        lblNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //    lblNombre.Text = MyTraductor.getTextDTID(46836, lblNombre.Text);
        //    txtNombre.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //    txtNombre.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());
        //    txtNombre.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        //    if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //        {
        //            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //            {
        //                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //                {
        //                    txtNombre.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //                }
        //                else
        //                {
        //                    txtNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //                }
        //            }
        //            else
        //            {
        //                txtNombre.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            }
        //        }else{
        //            txtNombre.Text = "";
        //        }
        //    //imgOblNombre.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    RFVNombre.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    //trNombre.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //    if (Foco == false && txtNombre.Enabled == true)
        //    {
        //        GetFocus(txtNombre);
        //        Foco = true;
        //    }        dv.RowFilter = "TTMetadata_DTID = " + 46837;
        //    if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //        lblCabecero.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //    else
        //        lblCabecero.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //    lblCabecero.Text = MyTraductor.getTextDTID(46837, lblCabecero.Text);
        //    txtCabecero.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //    txtCabecero.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        //    txtCabecero.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        //    if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //        {
        //            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //            {
        //                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //                {
        //                    txtCabecero.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //                }
        //                else
        //                {
        //                    txtCabecero.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //                }
        //            }
        //            else
        //            {
        //                txtCabecero.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            }
        //        }else{
        //            txtCabecero.Text = "";
        //        }
        //    imgOblCabecero.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    RFVCabecero.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    trCabecero.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //    if (Foco == false && txtCabecero.Enabled == true)
        //    {
        //        GetFocus(txtCabecero);
        //        Foco = true;
        //    }        dv.RowFilter = "TTMetadata_DTID = " + 46838;
        //    if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //        lblFormato.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //    else
        //        lblFormato.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //    lblFormato.Text = MyTraductor.getTextDTID(46838, lblFormato.Text);
        //    txtFormato.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //    txtFormato.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        //    txtFormato.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        //    if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //        {
        //            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //            {
        //                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //                {
        //                    txtFormato.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //                }
        //                else
        //                {
        //                    txtFormato.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //                }
        //            }
        //            else
        //            {
        //                txtFormato.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            }
        //        }else{
        //            txtFormato.Text = "";
        //        }
        //    imgOblFormato.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    RFVFormato.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    trFormato.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //    if (Foco == false && txtFormato.Enabled == true)
        //    {
        //        GetFocus(txtFormato);
        //        Foco = true;
        //    }        dv.RowFilter = "TTMetadata_DTID = " + 46839;
        //    if (dv.ToTable().Rows[0]["TTMetadata_Descripcion"] is DBNull || dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString() == "")
        //        lblPie.Text = dv.ToTable().Rows[0]["TTMetadata_Nombre"].ToString();
        //    else
        //        lblPie.Text = dv.ToTable().Rows[0]["TTMetadata_Descripcion"].ToString();
        //    lblPie.Text = MyTraductor.getTextDTID(46839, lblPie.Text);
        //    txtPie.ToolTip = dv.ToTable().Rows[0]["TTMetadata_Texto_Ayuda"].ToString();
        //    txtPie.Enabled = !Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Solo_lectura"].ToString());        
        //    txtPie.MaxLength = int.Parse(dv.ToTable().Rows[0]["TTMetadata_Longitud"].ToString());
        //    if (Session["Tipo_Transaccion"].ToString() == "New" || !(dv.ToTable().Rows[0]["TTMetadata_Identificador"].ToString() == "True"))
        //        if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString() != "")
        //        {
        //            if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length >= 7)
        //            {
        //                if (dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(0, 7) == "GLOBAL(")
        //                {
        //                    txtPie.Text = Session[dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Substring(7, dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString().Length - 8)].ToString();
        //                }
        //                else
        //                {
        //                    txtPie.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //                }
        //            }
        //            else
        //            {
        //                txtPie.Text = dv.ToTable().Rows[0]["TTMetadata_Valor_por_defecto"].ToString();
        //            }
        //        }else{
        //            txtPie.Text = "";
        //        }
        //    imgOblPie.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    RFVPie.Enabled = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Obligatorio"].ToString());
        //    trPie.Visible = Boolean.Parse(dv.ToTable().Rows[0]["TTMetadata_Visible"].ToString());
        //    if (Foco == false && txtPie.Enabled == true)
        //    {
        //        GetFocus(txtPie);
        //        Foco = true;
        //    }

        //    UpdatePanel1.Update();
        //}       
        public Boolean Insert_row()
        {


            try
            {

                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                    return false;
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                WSTTFormatos.objectBussinessTTFormatos fformatos = new WSTTFormatos.objectBussinessTTFormatos();
                Session["KeyValueInserted"] = fformatos.InsertWithReturnValue(userData, MyFunctions.FormatNumberNull(ddlProceso.Text), MyFunctions.FormatNumberNull(ddlColumna.SelectedValue), txtNombre.Text, txtCabecero.Content, txtFormato.Content, txtPie.Content);
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.AfterSave, iProcess);
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------           
                return true;
            }
            catch (Exception exception)
            {
                ShowAlert(exception.Message);
                return false;
            }
        }

        public Boolean Update_row()
        {


            try
            {

                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                if (ApplyBusinessRulesWithBreak(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeSave, iProcess))
                    return false;
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                WSTTFormatos.objectBussinessTTFormatos fformatos = new WSTTFormatos.objectBussinessTTFormatos();
                fformatos.Update(userData, MyFunctions.FormatNumberNull(txtFolio.Text), MyFunctions.FormatNumberNull(ddlProceso.Text), MyFunctions.FormatNumberNull(ddlColumna.SelectedValue), txtNombre.Text, txtCabecero.Content, txtFormato.Content, txtPie.Content);
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.AfterSave, iProcess);
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                return true;
            }
            catch (Exception exception)
            {
                ShowAlert(exception.Message);
                return false;
            }
        }



        public void Clear_All()
        {

        }

        protected bool IsValid3PointsRelations()
        {
            string sError = string.Empty;
            bool isValid = true;



            if (!isValid)
                ShowAlert(sError);

            return isValid;
        }

        protected void cmdSaveCopy_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsValid3PointsRelations())
                return;



            Boolean OperationCompleted = false;
            if (Session["Tipo_Transaccion"].ToString() == "New")
            {
                OperationCompleted = Insert_row();
            }
            else if (Session["Tipo_Transaccion"].ToString() == "Update")
            {
                OperationCompleted = Update_row();
            }
            else if (Session["Tipo_Transaccion"].ToString() == "Search")
            {
                //Search_row();
            }
            if (OperationCompleted)
            {
                Session["Tipo_Transaccion"] = "New";
                Session["CambiarArchivo"] = 1;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", "$.jnotify('Información grabada satisfactoriamente');", true);
            }
        }
        protected void cmdSaveNew_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsValid3PointsRelations())
                return;



            Boolean OperationCompleted = false;
            if (Session["Tipo_Transaccion"].ToString() == "New")
            {
                OperationCompleted = Insert_row();
            }
            else if (Session["Tipo_Transaccion"].ToString() == "Update")
            {
                OperationCompleted = Update_row();
            }
            else if (Session["Tipo_Transaccion"].ToString() == "Search")
            {
                //Search_row();
            }
            if (OperationCompleted)
            {
                Clear_All();
                //ConfigWithMetadata();
                Session["Tipo_Transaccion"] = "New";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "mensaje", "$.jnotify('Información grabada satisfactoriamente');", true);
            }
            Session["CambiarArchivo"] = 0;
        }
        protected void cmdSave_Click(object sender, ImageClickEventArgs e)
        {
            if (!IsValid3PointsRelations())
                return;



            Boolean OperationCompleted = false;
            if (Session["Tipo_Transaccion"].ToString() == "New")
            {
                OperationCompleted = Insert_row();
            }
            else if (Session["Tipo_Transaccion"].ToString() == "Update")
            {
                OperationCompleted = Update_row();
            }
            else if (Session["Tipo_Transaccion"].ToString() == "Search")
            {
                //Search_row();
            }
            if (OperationCompleted)
            {
                Session["Tipo_Transaccion"] = "Update";
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
                ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                Response.Redirect("TTFormatos_Lista.aspx");
            }
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult Cancel(bool MenuVisible)
        {
            try
            {
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                //ApplyBusinessRules(TTenumBusinessRules_Operacion.New, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
                //ApplyBusinessRules(TTenumBusinessRules_Operacion.Modification, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
                //ApplyBusinessRules(TTenumBusinessRules_Operacion.Consult, TTenumBusinessRules_ProcessEvent.BeforeClose, iProcess);
                //--------------------------------------------------------------------------------------------------------------------------------------------------------------------
                if (MenuVisible)
                    return new JsonResult("TTFormatos_Lista.aspx?MenuVisible=false", true, null);
                else
                    return new JsonResult("TTFormatos_Lista.aspx", true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public static JsonResult Clear(bool MenuVisible)
        {
            try
            {
                HttpContext.Current.Session["Tipo_Transaccion"] = "New";
                if (MenuVisible)
                    return new JsonResult("TTFormatos_Catalogo.aspx?MenuVisible=false", true, null);
                else
                    return new JsonResult("TTFormatos_Catalogo.aspx", true, null);
            }
            catch (Exception ex)
            {
                return new JsonResult(null, false, ex.Message.ToString());
            }
        }

        protected void cmdHelp_Click(object sender, ImageClickEventArgs e)
        {

        }

        //public void ddlProcesoId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddlColumna.Items.Clear();
        //    if (ddlProcesoId.SelectedValue != "")
        //    {
        //        MyFunctions.FillDataControl(ddlColumna, myTTFormatos.FillDataColumnawithParent(MyFunctions.FormatNumberNull(ddlProcesoId.SelectedValue).Value));
        //    }
        // }
        /*public void ddlColumna_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlColumna.Items.Clear();
            if (ddlColumna.SelectedValue != "")
            {
                MyFunctions.FillDataControl(ddlColumna, myTTFormatos.FillDataColumnawithParent(MyFunctions.FormatNumberNull(ddlColumna.SelectedValue).Value));
            }
         }*/









    }
}









