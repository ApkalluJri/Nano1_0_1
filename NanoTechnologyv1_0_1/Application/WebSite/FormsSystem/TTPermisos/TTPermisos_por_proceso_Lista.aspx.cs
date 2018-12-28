using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class FormsSystem_TTPermisos_TTPermisos_por_proceso_Lista : TTBasePage.TTBasePage
{
    private TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso MyDataTTPermisos_Por_Proceso = new TTPermisos_por_procesoCS.objectBussinessTTPermisos_por_proceso();
    private TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario MyDataTTGrupo_de_Usuario = new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();
    private TTFunctions.FillGridFunctions MyFillGridFunctions = new TTFunctions.FillGridFunctions();
    public int iProcess = 6327;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSecurityPage();

        if (!IsPostBack)
        {
            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = "Permisos por Proceso";
            lblTitulo.DataBind();
            this.Title = lblTitulo.Text;
        }
    }

    protected void cbIdGrupoUsuario_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("-Seleccionar Grupo de Usuario-", ""));
    }

    protected void cbIdGrupoUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetupGrid();
    }

    private void SetupGrid()
    {
        if (MyFunctions.FormatNumberNull(cbIdGrupoUsuario.SelectedValue) != null)
        {
            TTFunctions.FillGridFunctions.GridCrossField Column = new TTFunctions.FillGridFunctions.GridCrossField();
            SqlCommand sc = new SqlCommand("sp_TTSecurityPermisosPorProceso");
            sc.Parameters.AddWithValue("@UserGroupID", MyFunctions.FormatNumberNull(cbIdGrupoUsuario.SelectedValue));
            sc.CommandType = CommandType.StoredProcedure;
            Column.Command = sc;
            Column.ColumnDisplay = "Modulo";
            Column.ColumnDisplay2 = "Proceso";
            Column.ColumnValue = "IdProceso";
            Column.ColumnValue2 = "IdModulo";
            TTFunctions.FillGridFunctions.GridCrossField Row = new TTFunctions.FillGridFunctions.GridCrossField();
            Row.Command = new SqlCommand("sp_selAllTTOperacion");
            Row.ColumnDisplay = "Descripcion";
            Row.ColumnValue = "IdOperacion";
            FillGridCross(Column, Row);

        }
        grvPermisos.DataBind();
    }

    private void Open()
    {
        DataSet ds;
        TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters filter = new TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters();
        MyDataTTPermisos_Por_Proceso.Filters = new TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters[1];
        MyDataTTPermisos_Por_Proceso.Filters[0] = filter;
        ds = MyDataTTPermisos_Por_Proceso.SelAll(true);

        grvPermisos.DataSource = ds.Tables[0];
        grvPermisos.DataBind();

    }

    private string Save()
    {
        try
        {
            LoadSecurityPage();
            TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
            MyConexion.EjecutaDelete(new SqlCommand("Delete From TTPermisos_por_Proceso Where IdGrupoUsuario = " + MyFunctions.FormatNumberNull(cbIdGrupoUsuario.SelectedValue)), myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));
            CheckBox checkBox;
            string idGrupoUsuario, idProceso, idModulo, IdOperacion;
            idGrupoUsuario = cbIdGrupoUsuario.SelectedValue;
            foreach (Telerik.Web.UI.GridDataItem gvrow in grvPermisos.Items)
            {
                idProceso = ((Label)gvrow.FindControl("lblIdProceso")).Text;
                idModulo = ((Label)gvrow.FindControl("lblIdModulo")).Text;
                //------------------------------------------------------
                IdOperacion = ((Label)gvrow.FindControl("lblIdNuevo")).Text;
                checkBox = (CheckBox)gvrow.FindControl("checkBoxNuevo");
                if (checkBox.Checked)
                    SaveRowDataPermisos(idGrupoUsuario, idProceso, idModulo, IdOperacion);
                IdOperacion = ((Label)gvrow.FindControl("lblIdModificar")).Text;
                checkBox = (CheckBox)gvrow.FindControl("checkBoxModificar");
                if (checkBox.Checked)
                    SaveRowDataPermisos(idGrupoUsuario, idProceso, idModulo, IdOperacion);
                IdOperacion = ((Label)gvrow.FindControl("lblIdEliminar")).Text;
                checkBox = (CheckBox)gvrow.FindControl("checkBoxEliminar");
                if (checkBox.Checked)
                    SaveRowDataPermisos(idGrupoUsuario, idProceso, idModulo, IdOperacion);
                IdOperacion = ((Label)gvrow.FindControl("lblIdExportar")).Text;
                checkBox = (CheckBox)gvrow.FindControl("checkBoxExportar");
                if (checkBox.Checked)
                    SaveRowDataPermisos(idGrupoUsuario, idProceso, idModulo, IdOperacion);
                IdOperacion = ((Label)gvrow.FindControl("lblIdImprimir")).Text;
                checkBox = (CheckBox)gvrow.FindControl("checkBoxImprimir");
                if (checkBox.Checked)
                    SaveRowDataPermisos(idGrupoUsuario, idProceso, idModulo, IdOperacion);
                IdOperacion = ((Label)gvrow.FindControl("lblIdConfiguracion")).Text;
                checkBox = (CheckBox)gvrow.FindControl("checkBoxConfiguracion");
                if (checkBox.Checked)
                    SaveRowDataPermisos(idGrupoUsuario, idProceso, idModulo, IdOperacion);
            }

            return "¡Datos guardados satisfactoriamente!";
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    private void SaveRowDataPermisos(string idGrupoUsuario, string idProceso, string idModulo, string IdOperacion)
    {
        MyDataTTPermisos_Por_Proceso.IdGrupoUsuario = MyFunctions.FormatNumberNull(idGrupoUsuario);
        MyDataTTPermisos_Por_Proceso.IdProceso = MyFunctions.FormatNumberNull(idProceso);
        MyDataTTPermisos_Por_Proceso.idModulo = MyFunctions.FormatNumberNull(idModulo);
        MyDataTTPermisos_Por_Proceso.IdOperacion = MyFunctions.FormatNumberNull(IdOperacion);
        MyDataTTPermisos_Por_Proceso.Insert(myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));

    }


    private void FillGridCross(TTFunctions.FillGridFunctions.GridCrossField Column, TTFunctions.FillGridFunctions.GridCrossField Row)
    {
        DataSet dsPermisosPorProceso, dsPermisosUsuario, dsOperaciones;
        DataTable dtGrid = new DataTable();
        DataColumn dtColumn;
        DataRow dtRow;

        TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters filter = new TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters();
        filter.IdGrupoUsuario = new TTClassSpecials.FiltersTypes.Dependientes();
        filter.IdGrupoUsuario.List = new string[1];
        filter.IdGrupoUsuario.List[0] = cbIdGrupoUsuario.SelectedValue;
        MyDataTTPermisos_Por_Proceso.Filters = new TTPermisos_por_procesoCS.TTPermisos_por_procesoFilters[1];
        MyDataTTPermisos_Por_Proceso.Filters[0] = filter;
        dsPermisosUsuario = MyDataTTPermisos_Por_Proceso.SelAll(true);  //dsCols

        TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
        dsPermisosPorProceso = MyConexion.Consulta(Column.Command); //dsRows
        dsOperaciones = MyConexion.Consulta(Row.Command);

        //------------Crea las columnas...----------------------
        foreach (DataColumn dc in dsPermisosPorProceso.Tables[0].Columns)
        {
            dtColumn = new DataColumn(dc.ColumnName);
            dtGrid.Columns.Add(dtColumn);
        }

        foreach (DataRow dr in dsOperaciones.Tables[0].Rows)
        {
            dtColumn = new DataColumn(dr["Descripcion"].ToString());
            dtGrid.Columns.Add(dtColumn);
            dtColumn = new DataColumn("Id" + dr["Descripcion"].ToString());
            dtGrid.Columns.Add(dtColumn);
        }
        //------------------------------------------------------
        foreach (DataRow dr in dsPermisosPorProceso.Tables[0].Rows)
        {
            dtRow = dtGrid.NewRow();

            foreach (DataColumn dc in dsPermisosPorProceso.Tables[0].Columns)
                dtRow[dc.ColumnName] = dr[dc.ColumnName];

            foreach (DataRow drc in dsOperaciones.Tables[0].Rows)
            {
                string IdRow = "Id" + drc["Descripcion"].ToString();
                dtRow[IdRow] = drc["IdOperacion"].ToString();
                dtRow[drc["Descripcion"].ToString()] = false;
                foreach (DataRow drPermisos in dsPermisosUsuario.Tables[0].Rows)
                    if (drPermisos["TTPermisos_por_proceso_IdOperacion"].ToString().TrimEnd(' ') == drc["IdOperacion"].ToString().TrimEnd(' ') &&
                        drPermisos["TTPermisos_por_proceso_IdProceso"].ToString().TrimEnd(' ') == dr["IdProceso"].ToString().TrimEnd(' ') &&
                        drPermisos["TTPermisos_por_proceso_IdModulo"].ToString().TrimEnd(' ') == dr["IdModulo"].ToString().TrimEnd(' '))
                        dtRow[drc["Descripcion"].ToString()] = true;
            }
            dtGrid.Rows.Add(dtRow);
        }
        dtGrid.AcceptChanges();
        grvPermisos.DataSource = dtGrid;
    }

    protected void grvPermisos_PreRender(object sender, EventArgs e)
    {
        foreach (Telerik.Web.UI.GridDataItem item in grvPermisos.Items)
        {
            item.Edit = true;
            grvPermisos.Rebind();
        }
    }

    protected void cmdAcept_Click(object sender, EventArgs e)
    {
        string result = Save();
        if (result != "")
            ShowAlert(result);
        else
            Response.Redirect("~/FormsSystem/DefaultAdministracion.aspx");
    }
    protected void cmdCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FormsSystem/DefaultAdministracion.aspx");
    }
}









