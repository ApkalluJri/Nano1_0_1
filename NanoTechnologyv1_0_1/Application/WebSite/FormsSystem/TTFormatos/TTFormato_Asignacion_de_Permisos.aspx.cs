using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace FormsSystem.TTFormatos
{
    public partial class TTFormato_Asignacion_de_Permisos : TTBasePage.TTBasePage
    {
        private TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario MyDataTTGrupo_de_Usuario = new TTGrupo_de_UsuarioCS.objectBussinessTTGrupo_de_Usuario();
        private TTFormatosCS.objectBussinessTTFormatos MyDataTTFormato = new TTFormatosCS.objectBussinessTTFormatos();
        private TTFunctions.FillGridFunctions MyFillGridFunctions = new TTFunctions.FillGridFunctions();
        public int iProcess = 6332;

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
                SqlCommand sc = new SqlCommand("sp_SelAllTTFormatos");
                sc.CommandType = CommandType.StoredProcedure;
                Column.Command = sc;
                Column.ColumnDisplay = "Formato";
                Column.ColumnValue = "idFormato";
                TTFunctions.FillGridFunctions.GridCrossField Row = new TTFunctions.FillGridFunctions.GridCrossField();
                Row.Command = new SqlCommand("sp_SelAllTTGrupo_de_Usuario");
                Row.ColumnDisplay = "Descripcion";
                Row.ColumnValue = "IdGrupoUsuario";
                FillGridCross(Column, Row);

            }
            grvFormatos.DataBind();
        }

        protected void grvFormatos_PreRender(object sender, EventArgs e)
        {
            foreach (Telerik.Web.UI.GridDataItem item in grvFormatos.Items)
            {
                item.Edit = true;
                grvFormatos.Rebind();
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

        private string Save()
        {
            try
            {
                LoadSecurityPage();
                TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
                MyConexion.EjecutaDelete(new SqlCommand("Delete From TTFormatos_por_Grupo_de_Usuario Where idGrupoUsuario = " + MyFunctions.FormatNumberNull(cbIdGrupodeUsuarios.SelectedValue)), myUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));
                CheckBox checkBoxImprimir, checkBoxGuardar, checkBoxEditar;
                string idUsuario, idFormato;
                idUsuario = cbIdGrupodeUsuarios.SelectedValue;
                foreach (Telerik.Web.UI.GridDataItem gvrow in grvFormatos.Items)
                {
                    idFormato = ((Label)gvrow.FindControl("lblFormato")).Text;
                    //------------------------------------------------------
                    checkBoxImprimir = (CheckBox)gvrow.FindControl("checkBoxImprimir");
                    checkBoxGuardar = (CheckBox)gvrow.FindControl("checkBoxGuardar");
                    checkBoxEditar = (CheckBox)gvrow.FindControl("checkBoxEditar");
                    if (checkBoxImprimir.Checked || checkBoxGuardar.Checked || checkBoxEditar.Checked)
                        SaveRowDataPermisos(idUsuario, idFormato, checkBoxImprimir.Checked, checkBoxGuardar.Checked , checkBoxEditar.Checked);


                }
                return "¡Datos guardados satisfactoriamente!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        private void SaveRowDataPermisos(string idUsuario, string idFormato,bool imprimir , bool guardar , bool editar)
        {
            TTFunctions.Conversiones Conversion = new TTFunctions.Conversiones();
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            db.BeginTransaction("TTFormatos_por_Grupo_de_Usuario");
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandText = "sp_InsTTFormatos_por_Grupo_de_Usuario";
                com.Parameters.AddWithValue("@IdGrupoUsuario", Conversion.FormatNull(idUsuario));
                com.Parameters.AddWithValue("@idFormato", Conversion.FormatNull(idFormato));
                com.Parameters.AddWithValue("@Imprimir", imprimir);
                com.Parameters.AddWithValue("@Guardar", guardar);
                com.Parameters.AddWithValue("@Editar", editar);
                com.CommandType = CommandType.StoredProcedure;
                db.EjecutaInsert(com, MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", iProcess));
                db.CommitTransaction();
            }
            catch (Exception ex)
            {
                db.RollBackTransaction("TTFormatos_por_Grupo_de_Usuario");
                throw ex;
            }
            //return sKey;

        }

        private void FillGridCross(TTFunctions.FillGridFunctions.GridCrossField Column, TTFunctions.FillGridFunctions.GridCrossField Row)
        {
            DataSet dsgrvFormatos, dsFormato, dsOperaciones;
            DataTable dtGrid = new DataTable();
            DataColumn dtColumn;
            DataRow dtRow;

            TTDataLayerCS.BD MyConexion = new TTDataLayerCS.BD();
            dsgrvFormatos = MyConexion.Consulta(Column.Command); //dsRows
            dsOperaciones = MyConexion.Consulta(Row.Command);
            SqlCommand com = new SqlCommand();
            com.CommandText = "spTTFormatos_por_Grupo_de_Usuario_x_Grupo_de_Usuario";
            com.Parameters.AddWithValue("@idGrupoUsuario", cbIdGrupodeUsuarios.SelectedValue);
            com.CommandType = CommandType.StoredProcedure;
            dsFormato = MyConexion.Consulta(com);//dsCols

            //------------Crea las columnas...----------------------

            dtColumn = new DataColumn(dsgrvFormatos.Tables[0].Columns[0].ColumnName);
            dtGrid.Columns.Add(dtColumn);
            dtColumn = new DataColumn(dsgrvFormatos.Tables[0].Columns[3].ColumnName);
            dtGrid.Columns.Add(dtColumn);
            dtColumn = new DataColumn("Imprimir");
            dtGrid.Columns.Add(dtColumn);
            dtColumn = new DataColumn("Guardar");
            dtGrid.Columns.Add(dtColumn);
            dtColumn = new DataColumn("Editar");
            dtGrid.Columns.Add(dtColumn);



            //------------------------------------------------------

            foreach (DataRow dr in dsgrvFormatos.Tables[0].Rows)
            {
                dtRow = dtGrid.NewRow();
                dtRow[dsgrvFormatos.Tables[0].Columns[0].ColumnName] = dr[dsgrvFormatos.Tables[0].Columns[0].ColumnName];
                dtRow[dsgrvFormatos.Tables[0].Columns[3].ColumnName] = dr[dsgrvFormatos.Tables[0].Columns[3].ColumnName];
                dtRow["Imprimir"] = false;
                dtRow["Editar"] = false;
                dtRow["Guardar"] = false;
                foreach (DataRow drFormatos in dsFormato.Tables[0].Rows)
                    if (drFormatos["idFormato"].ToString().TrimEnd(' ') == dr["idFormato"].ToString().TrimEnd(' '))
                    {
                        dtRow["Imprimir"] = drFormatos["Imprimir"];
                        dtRow["Guardar"] = drFormatos["Guardar"];
                        dtRow["Editar"] = drFormatos["Editar"];
                    }
                        
                dtGrid.Rows.Add(dtRow);
            }

            dtGrid.AcceptChanges();
            grvFormatos.DataSource = dtGrid;
        }
    }
}









