using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class FormsSystem_TTReportes_TTRerpote_Asignacion_de_Permisos : TTBasePage.TTBasePage
{
   // private TTReporte_del_ModuloCS.objectBussinessTTReporte_del_Modulo MyDataTTReporte_del_Modulo = new TTReporte_del_ModuloCS.objectBussinessTTReporte_del_Modulo();
    private TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario MyDataTTGrupo_de_Usuario = new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();
    private TTReportes.objectBussinessTTReportes MyDataTTReporte = new TTReportes.objectBussinessTTReportes();
    private TTFunctions.FillGridFunctions MyFillGridFunctions = new TTFunctions.FillGridFunctions();
    public int iProcess = 6331;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSecurityPage();
        MyTraductor = new TTTraductor.Traductor(myUserData.GetHashCode());
    }

    protected void cbIdGrupodeUsuarios_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("-Seleccionar Grupo de Usuario-", ""));
    }

    protected void cbIdGrupodeUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetupGrid();
    }

    private void SetupGrid()
    {
        if (MyFunctions.FormatNumberNull(cbIdGrupodeUsuarios.SelectedValue) != null)
        {
            TTFunctions.FillGridFunctions.GridCrossField Column = new TTFunctions.FillGridFunctions.GridCrossField();
            SqlCommand sc = new SqlCommand("sp_SelAllTTReportes");
            sc.CommandType = CommandType.StoredProcedure;
            Column.Command = sc;
            Column.ColumnDisplay = "Reporte";
            Column.ColumnValue = "idReporte";
            TTFunctions.FillGridFunctions.GridCrossField Row = new TTFunctions.FillGridFunctions.GridCrossField();
            Row.Command = new SqlCommand("sp_SelAllTTGrupo_de_Usuario");
            Row.ColumnDisplay = "Descripcion";
            Row.ColumnValue = "IdGrupoUsuario";
            FillGridCross(Column, Row);

        }
        grvReportes.DataBind();
    }

    private void Open()
    {
        DataSet ds;
       // TTReporte_del_ModuloCS.TTReporte_del_ModuloFilters filter = new TTReporte_del_ModuloCS.TTReporte_del_ModuloFilters();
      //  MyDataTTReporte_del_Modulo.Filters = new TTReporte_del_ModuloCS.TTReporte_del_ModuloFilters[1];
      //  MyDataTTReporte_del_Modulo.Filters[0] = filter;
      //  ds = MyDataTTReporte_del_Modulo.SelAll(true);
        //SqlCommand com = new SqlCommand();
        //com.CommandText = "spTTReportes_por_Grupo_de_Usuario_x_Grupo_de_Usuario";
        //com.Parameters.AddWithValue("@idGrupoUsuario", cbIdGrupodeUsuarios.SelectedValue);
        //com.CommandType = CommandType.StoredProcedure;
        //ds= MyConexion.Consulta(com);

     //   grvReportes.DataSource = ds.Tables[0];
      //  grvReportes.DataBind();

    }

    private string Save()
    {
        try
        {
            LoadSecurityPage();
            TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
            MyConexion.EjecutaDelete(new SqlCommand("Delete From TTReportes_por_Grupo_de_Usuario Where idUsuario = " + MyFunctions.FormatNumberNull(cbIdGrupodeUsuarios.SelectedValue)), myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));
            CheckBox checkBoxDisponible;
            CheckBox checkBoxInicio;
            string idUsuario, idReporte;
            idUsuario = cbIdGrupodeUsuarios.SelectedValue;
            foreach (Telerik.Web.UI.GridDataItem gvrow in grvReportes.Items)
            {
                idReporte = ((Label)gvrow.FindControl("lblReporte")).Text;
                //------------------------------------------------------
                checkBoxDisponible = (CheckBox)gvrow.FindControl("checkBoxDisponible");
                checkBoxInicio = (CheckBox)gvrow.FindControl("checkBoxInicio");
                if (checkBoxDisponible.Checked)
                    SaveRowDataPermisos(idUsuario, idReporte, checkBoxInicio.Checked);


            }

            return "¡Datos guardados satisfactoriamente!";
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    private void SaveRowDataPermisos(string idUsuario, string idReporte,bool inicio)
    {
        //MyDataTTReporte_del_Modulo.IdModulo = MyFunctions.FormatNumberNull(idModulo);
        //MyDataTTReporte_del_Modulo.IdReporte = MyFunctions.FormatNumberNull(idReporte);
        //MyDataTTReporte_del_Modulo.Insert(myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));
        TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
        db.BeginTransaction("TTReportes_por_Grupo_de_Usuario");
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandText = "sp_InsTTReportes_por_Grupo_de_Usuario";
            com.Parameters.AddWithValue("@IdGrupoUsuario", Conversion.FormatNull(idUsuario));
            com.Parameters.AddWithValue("@IdReporte", Conversion.FormatNull(idReporte));
            com.Parameters.AddWithValue("@Inicio", inicio);
            com.CommandType = CommandType.StoredProcedure;
            db.EjecutaInsert(com, MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));
            db.CommitTransaction();
        }
        catch (Exception ex)
        {
            db.RollBackTransaction("TTReportes_por_Grupo_de_Usuario");
            throw ex;
        }
        //return sKey;

    }


    private void FillGridCross(TTFunctions.FillGridFunctions.GridCrossField Column, TTFunctions.FillGridFunctions.GridCrossField Row)
    {
        DataSet dsgrvReportes, dsReporte, dsOperaciones;
        DataTable dtGrid = new DataTable();
        DataColumn dtColumn;
        DataRow dtRow;

        TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
        dsgrvReportes = MyConexion.Consulta(Column.Command); //dsRows
        dsOperaciones = MyConexion.Consulta(Row.Command);       
        SqlCommand com = new SqlCommand();
        com.CommandText = "spTTReportes_por_Grupo_de_Usuario_x_Grupo_de_Usuario";
        com.Parameters.AddWithValue("@idGrupoUsuario", cbIdGrupodeUsuarios.SelectedValue);
        com.CommandType = CommandType.StoredProcedure;
        dsReporte = MyConexion.Consulta(com);//dsCols

        //------------Crea las columnas...----------------------

        dtColumn = new DataColumn(dsgrvReportes.Tables[0].Columns[0].ColumnName);
        dtGrid.Columns.Add(dtColumn);
        dtColumn = new DataColumn(dsgrvReportes.Tables[0].Columns[1].ColumnName);
        dtGrid.Columns.Add(dtColumn);
        dtColumn = new DataColumn("Disponible");
        dtGrid.Columns.Add(dtColumn);
        dtColumn = new DataColumn("Inicio");
        dtGrid.Columns.Add(dtColumn);


        //------------------------------------------------------

        foreach (DataRow dr in dsgrvReportes.Tables[0].Rows)
        {
            dtRow = dtGrid.NewRow();
            dtRow[dsgrvReportes.Tables[0].Columns[0].ColumnName] = dr[dsgrvReportes.Tables[0].Columns[0].ColumnName];
            dtRow[dsgrvReportes.Tables[0].Columns[1].ColumnName] = dr[dsgrvReportes.Tables[0].Columns[1].ColumnName];
            dtRow["Disponible"] = false;
            dtRow["Inicio"] = false;
            foreach (DataRow drReportes in dsReporte.Tables[0].Rows)
            {
                if (drReportes["idReporte"].ToString().TrimEnd(' ') == dr["idReporte"].ToString().TrimEnd(' '))
                    dtRow["Disponible"] = true;
                if (drReportes["idReporte"].ToString().TrimEnd(' ') == dr["idReporte"].ToString().TrimEnd(' ') && bool.Parse(drReportes["Inicio"].ToString()))
                    dtRow["Inicio"] = true;
            }
            dtGrid.Rows.Add(dtRow);
        }

        dtGrid.AcceptChanges();
        grvReportes.DataSource = dtGrid;
    }

    protected void grvReportes_PreRender(object sender, EventArgs e)
    {
        foreach (Telerik.Web.UI.GridDataItem item in grvReportes.Items)
        {
            item.Edit = true;
            grvReportes.Rebind();
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








