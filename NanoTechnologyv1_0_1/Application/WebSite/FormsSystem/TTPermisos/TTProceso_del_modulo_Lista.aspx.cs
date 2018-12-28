using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class FormsSystem_TTPermisos_TTProceso_del_modulo_Lista : TTBasePage.TTBasePage
{
    private TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo MyDataTTProceso_del_Modulo = new TTProceso_del_ModuloCS.objectBussinessTTProceso_del_Modulo();
    private TTModuloCS.objectBussinessTTModulo MyDataTTModulo = new TTModuloCS.objectBussinessTTModulo();
    private TTProcesoCS.objectBussinessTTProceso MyDataTTProceso = new TTProcesoCS.objectBussinessTTProceso();
    private TTFunctions.FillGridFunctions MyFillGridFunctions = new TTFunctions.FillGridFunctions();
    public int iProcess = 6328;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSecurityPage();
        MyTraductor = new TTTraductor.Traductor(myUserData.GetHashCode());

        if (!IsPostBack) 
        {
            Label lblTitulo = (Label)this.Page.Master.FindControl("lblTitulo");
            lblTitulo.Text = "Procesos del Módulo";
            lblTitulo.DataBind();
            this.Title = lblTitulo.Text;
        }
    }

    protected void cbIdModulo_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("-Seleccionar Módulo-", ""));
    }

    protected void cbIdModulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetupGrid();
    }

    private void SetupGrid()
    {
        if (MyFunctions.FormatNumberNull(cbIdModulo.SelectedValue) != null)
        {
            TTFunctions.FillGridFunctions.GridCrossField Column = new TTFunctions.FillGridFunctions.GridCrossField();
            SqlCommand sc = new SqlCommand("sp_SelAllTTProceso");
            sc.CommandType = CommandType.StoredProcedure;
            Column.Command = sc;
            Column.ColumnDisplay = "Proceso";
            Column.ColumnValue = "IdProceso";
            TTFunctions.FillGridFunctions.GridCrossField Row = new TTFunctions.FillGridFunctions.GridCrossField();
            Row.Command = new SqlCommand("sp_selAllTTModulo");
            Row.ColumnDisplay = "Descripcion";
            Row.ColumnValue = "IdModulo";
            FillGridCross(Column, Row);

        }
        grvProcesos.DataBind();
    }

    private void Open()
    {
        DataSet ds;
        TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters filter = new TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters();
        MyDataTTProceso_del_Modulo.Filters = new TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters[1];
        MyDataTTProceso_del_Modulo.Filters[0] = filter;
        ds = MyDataTTProceso_del_Modulo.SelAll(true);

        grvProcesos.DataSource = ds.Tables[0];
        grvProcesos.DataBind();

    }

    private string Save()
    {
        try
        {
            LoadSecurityPage();
            TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
            MyConexion.EjecutaDelete(new SqlCommand("Delete From TTProceso_del_Modulo Where IdModulo = " + MyFunctions.FormatNumberNull(cbIdModulo.SelectedValue)), myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));
            CheckBox checkBox;
            string idModulo, idProceso;
            idModulo = cbIdModulo.SelectedValue;
            foreach (Telerik.Web.UI.GridDataItem gvrow in grvProcesos.Items)
            {
                idProceso = ((Label)gvrow.FindControl("lblProceso")).Text;
                //------------------------------------------------------
                checkBox = (CheckBox)gvrow.FindControl("checkBoxDisponible");
                if (checkBox.Checked)
                    SaveRowDataPermisos(idModulo, idProceso);


            }

            return "¡Datos guardados satisfactoriamente!";
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    private void SaveRowDataPermisos(string idModulo, string idProceso)
    {
        MyDataTTProceso_del_Modulo.IdModulo = MyFunctions.FormatNumberNull(idModulo);
        MyDataTTProceso_del_Modulo.IdProceso = MyFunctions.FormatNumberNull(idProceso);
        MyDataTTProceso_del_Modulo.Insert(myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));

    }


    private void FillGridCross(TTFunctions.FillGridFunctions.GridCrossField Column, TTFunctions.FillGridFunctions.GridCrossField Row)
    {
        DataSet dsgrvProcesos, dsProceso, dsOperaciones;
        DataTable dtGrid = new DataTable();
        DataColumn dtColumn;
        DataRow dtRow;



        TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters filter = new TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters();
        filter.IdModulo = new TTClassSpecials.FiltersTypes.Dependientes();
        filter.IdModulo.List = new string[1];
        filter.IdModulo.List[0] = cbIdModulo.SelectedValue;
        MyDataTTProceso_del_Modulo.Filters = new TTProceso_del_ModuloCS.TTProceso_del_ModuloFilters[1];
        MyDataTTProceso_del_Modulo.Filters[0] = filter;
        dsProceso = MyDataTTProceso_del_Modulo.SelAll(true);  //dsCols

        TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
        dsgrvProcesos = MyConexion.Consulta(Column.Command); //dsRows
        dsOperaciones = MyConexion.Consulta(Row.Command);

        //------------Crea las columnas...----------------------

        dtColumn = new DataColumn(dsgrvProcesos.Tables[0].Columns[0].ColumnName);
        dtGrid.Columns.Add(dtColumn);
        dtColumn = new DataColumn(dsgrvProcesos.Tables[0].Columns[1].ColumnName);
        dtGrid.Columns.Add(dtColumn);
        dtColumn = new DataColumn("Disponible");
        dtGrid.Columns.Add(dtColumn);


        //------------------------------------------------------

        foreach (DataRow dr in dsgrvProcesos.Tables[0].Rows)
        {
            dtRow = dtGrid.NewRow();
            dtRow[dsgrvProcesos.Tables[0].Columns[0].ColumnName] = dr[dsgrvProcesos.Tables[0].Columns[0].ColumnName];
            dtRow[dsgrvProcesos.Tables[0].Columns[1].ColumnName] = dr[dsgrvProcesos.Tables[0].Columns[1].ColumnName];
            dtRow["Disponible"] = false;
            foreach (DataRow drPermisos in dsProceso.Tables[0].Rows)
                if (drPermisos["TTProceso_del_Modulo_IdProceso"].ToString().TrimEnd(' ') == dr["IdProceso"].ToString().TrimEnd(' '))
                    dtRow["Disponible"] = true;
            dtGrid.Rows.Add(dtRow);
        }

        dtGrid.AcceptChanges();
        grvProcesos.DataSource = dtGrid;
    }

    protected void grvProcesos_PreRender(object sender, EventArgs e)
    {
        foreach (Telerik.Web.UI.GridDataItem item in grvProcesos.Items)
        {
            item.Edit = true;
            grvProcesos.Rebind();
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







