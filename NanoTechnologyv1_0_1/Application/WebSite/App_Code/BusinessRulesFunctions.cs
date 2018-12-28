using System;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using AjaxControlToolkit;
using Telerik.Web.UI;
using System.Web.Script.Serialization;

namespace TTBusinessRules
{
    public class BusinessRulesFunctions
    {
        private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
        private TTSecurity.GlobalData myUserData;
        private TTBasePage.TTBasePage frmActive;
        //Documentar SGS
        public struct globalVariable
        {
            public Control control;
            public bool forBussinesRule;
        }

        private int fieldIndex;
        public int FieldIndex
        {
            get { return fieldIndex; }
            set { fieldIndex = value; }
        }

        private GridViewRow gridRow;
        public GridViewRow GridRow 
        {
            get { return gridRow; }
            set { gridRow = value; }
        }		
        public BusinessRulesFunctions()
        {
        }

        public BusinessRulesFunctions(TTBasePage.TTBasePage parameterPage, TTSecurity.GlobalData MyUserData)
        {
            frmActive = parameterPage;
            myUserData = MyUserData;
			GridRow = null;
        }

        public string DecodingValueControlFromDTs(string text)
        {
            Control ctl = (Control)RootControlFromDT(text);
            try
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    return (ctl as TextBox).Text;
                }
                else if (ctl.GetType() == typeof(CheckBox))
                {
                    return ((CheckBox)ctl).Checked.ToString().ToLower();
                }
                else if (ctl.GetType() == typeof(DropDownList))
                {
                    if (((DropDownList)ctl).SelectedValue != null)
                    {
                        if ((ctl as DropDownList).SelectedValue.GetType() == typeof(DataRowView))
                            return (((ctl as DropDownList).SelectedValue))[0].ToString();
                        else
                            return ((ctl as DropDownList).SelectedValue.ToString());
                    }
                }
                else if (ctl.GetType() == typeof(CascadingDropDown))
                {
                    if ((ctl as CascadingDropDown).SelectedValue != null)
                    {
                        if (((CascadingDropDown)ctl).SelectedValue.IndexOf(":") != -1)
                            return ((CascadingDropDown)ctl).SelectedValue.Substring(0, (ctl as CascadingDropDown).SelectedValue.IndexOf(":"));
                        else
                            return ((CascadingDropDown)ctl).SelectedValue.ToString();

                    }
                }
                else if (ctl.GetType() == typeof(RadComboBox))
                {
                    return ((ctl as RadComboBox).SelectedValue.ToString());
                }
                else if (ctl.GetType() == typeof(RadTimePicker))
                {
                    return ((ctl as RadTimePicker).SelectedDate.ToString());
                }
                else if (ctl.GetType() == typeof(RadDatePicker))
                {
                    return ((ctl as RadDatePicker).SelectedDate.ToString());
                }
                else if (ctl.GetType() == typeof(RadDateTimePicker))
                {
                    return ((ctl as RadDateTimePicker).SelectedDate.ToString());
                }
                else if (ctl.GetType() == typeof(RadNumericTextBox))
                {
                    return ((ctl as RadNumericTextBox).Value.ToString());
                }
                return "";
            }
            catch
            {
                throw new Exception("Las Reglas de negocio que tienen un alcance de Proceso con Condiciones que usan un campo Field no Aplican en una operacion tipo Delete, Export o Print");
            }
        }

        public Object RootControlFromDT(String DtRoot)
        {
            //El root viene Tabla.Dato hay que quitar la tabla 
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf(".") - 1);
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            String nameControl = "";
            if (myData.ImMultiRenglon() != TTMetadata.TTMetadataTypeData.MultiRenglon)
            {
                if (!myData.ImInMultiRenglon())
                {
                    switch (myData.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.TextBox:
                            {
                                switch (myData.TipodeDato)
                                {
                                    case TTFunctions.TypeData.Texto:
                                    case TTFunctions.TypeData.Numerico:
                                    case TTFunctions.TypeData.Decimal:
                                    case TTFunctions.TypeData.Moneda:
                                    case TTFunctions.TypeData.Hora:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                    case TTFunctions.TypeData.FechaHora:
                                    case TTFunctions.TypeData.Fecha:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                    case TTFunctions.TypeData.Logico:
                                        nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                }
                                break;
                            }
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            nameControl = myFunctions.GenerateName(myData.Nombre);
                            Control oControl;
                            if (myData.ImInMultiRenglon())
                            {
                                oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "txt" + nameControl);
                                    if (oControl != null)
                                        nameControl = "txt" + nameControl;
                                }
                                else
                                {
                                    nameControl = "ddl" + nameControl;
                                }
                            }
                            else
                            {
                                oControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                    nameControl = "ddl" + nameControl;
                                }
                                else
                                {
                                    nameControl = "cdd" + nameControl;
                                }
                            }
                            break;
                        case TTMetadata.TTMetadataTypeControl.ListBox:
                            nameControl = "lst" + myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.CheckBox:
                            nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                            break;
                    }
                    return FindControlRecursive(frmActive, nameControl);
                }
                else
                {
                    String nameRel = myData.ImInMultiRenglonDtRelationPrincipal().Nombre;
                    nameControl = "grvcol" + myFunctions.GenerateName(nameRel) + myFunctions.GenerateName(myData.Nombre);
                    String nameGrid = "grv" + myFunctions.GenerateName(nameRel);
                    GridView dg = (GridView)FindControlRecursive(frmActive, nameGrid);
                    return dg.Columns[0];
                }
            }
            else
            {
                String nameRel = myData.Nombre;
                String nameGrid = "grv" + myFunctions.GenerateName(nameRel);
                GridView dg = (GridView)FindControlRecursive(frmActive, nameGrid);
                return dg;
            }
        }

        public bool isMultiRow(String DTID)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("SELECT DISTINCT Identificador, Secuencial, Dependiente FROM TTMetadata WHERE DNTID = (SELECT DependienteTabla FROM TTMetadata WHERE DTID = " + DTID + ") AND Identificador=1 AND Secuencial = 0 AND Dependiente = 1" +
                                            " UNION " +
                                            "SELECT DISTINCT Identificador, Secuencial, Dependiente FROM TTMetadata WHERE DNTID = (SELECT DependienteTabla FROM TTMetadata WHERE DTID = " + DTID + ") AND Identificador=1 AND Secuencial = 1 AND Dependiente = 0");
            DataTable dt = db.Consulta(com).Tables[0];

            if (dt.Rows.Count == 2) return true;
            
            else return false;
        }

        public String ControlNameFromDT(String DtRoot)
        {
            //El root viene Tabla.Dato hay que quitar la tabla 
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf("."));
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            String nameControl = "";
            Object resultControl;

                    switch (myData.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.TextBox:
                            {
                                switch (myData.TipodeDato)
                                {
                                    case TTFunctions.TypeData.Texto:
                                    case TTFunctions.TypeData.Numerico:
                                    case TTFunctions.TypeData.Decimal:
                                    case TTFunctions.TypeData.Moneda:
                                    case TTFunctions.TypeData.Hora:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        break;

                                    case TTFunctions.TypeData.FechaHora:
                                    case TTFunctions.TypeData.Fecha:
                                        //nameControl = "dt" + myFunctions.GenerateName(myData.Nombre);
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                    case TTFunctions.TypeData.Logico:
                                        nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                }
                                break;
                            }
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            nameControl = myFunctions.GenerateName(myData.Nombre);
                            Control oControl;
                            if (myData.ImInMultiRenglon())
                            {
                                oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "txt" + nameControl);
                                    if (oControl != null)
                                        nameControl = "txt" + nameControl;
                                }
                                else
                                {
                                    nameControl = "ddl" + nameControl;
                                }
                            }
                            else
                            {
                                oControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                    nameControl = "ddl" + nameControl;
                                }
                                else
                                {
                                    nameControl = "cdd" + nameControl;
                                }
                            }
                            break;
                        case TTMetadata.TTMetadataTypeControl.ListBox:
                            nameControl = "lst" + myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.CheckBox:
                            nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.Archivo:
                            nameControl = "lkbVer" + myFunctions.GenerateName(myData.Nombre);
                            break;
                    }

                    return nameControl;
                    
        }

        public Object ControlFromDT(String DtRoot)
        {
            //El root viene Tabla.Dato hay que quitar la tabla 
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf("."));
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            String nameControl = "";
            Object resultControl;

            //if (!isMultiRow(DtRoot)) /* Si el campo no es multirenglón. */
            if (myData.ImMultiRenglon() != TTMetadata.TTMetadataTypeData.MultiRenglon)
            {
                if (!myData.ImInMultiRenglon()) /* Si el campo no está en un multirenglón. */
                {
                    switch (myData.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.TextBox:
                            {
                                switch (myData.TipodeDato)
                                {
                                    case TTFunctions.TypeData.Texto:
                                    case TTFunctions.TypeData.Numerico:
                                    case TTFunctions.TypeData.Decimal:
                                    case TTFunctions.TypeData.Moneda:
                                    case TTFunctions.TypeData.Hora:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        break;

                                    case TTFunctions.TypeData.FechaHora:
                                    case TTFunctions.TypeData.Fecha:
                                        //nameControl = "dt" + myFunctions.GenerateName(myData.Nombre);
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                    case TTFunctions.TypeData.Logico:
                                        nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                }
                                break;
                            }
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            nameControl = myFunctions.GenerateName(myData.Nombre);
                            Control oControl;
                            if (myData.ImInMultiRenglon())
                            {
                                oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "txt" + nameControl);
                                    if (oControl != null)
                                        nameControl = "txt" + nameControl;
                                }
                                else
                                {
                                    nameControl = "ddl" + nameControl;
                                }
                            }
                            else
                            {
                                oControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                    nameControl = "ddl" + nameControl;
                                }
                                else
                                {
                                    nameControl = "cdd" + nameControl;
                                }
                            }
                            break;
                        case TTMetadata.TTMetadataTypeControl.ListBox:
                            nameControl = "lst" + myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.CheckBox:
                            nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.Archivo:
                            nameControl = "lkbVer" + myFunctions.GenerateName(myData.Nombre);
                            break;
                    }
                    return FindControlRecursive(frmActive, nameControl);
                }
                else /* Si el campo está en un multirenglón. */
                {
                    
                    String nameRel = myData.ImInMultiRenglonDtRelationPrincipal().Nombre;
                    nameControl = "grvcol" + myFunctions.GenerateName(nameRel) + myFunctions.GenerateName(myData.Nombre);
                    String nameGrid = "grdMulti" + myFunctions.GenerateName(nameRel);

                    switch (myData.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.TextBox:
                            {
                                switch (myData.TipodeDato)
                                {
                                    case TTFunctions.TypeData.Texto:
                                    case TTFunctions.TypeData.Numerico:
                                    case TTFunctions.TypeData.Decimal:
                                    case TTFunctions.TypeData.Moneda:
                                    case TTFunctions.TypeData.Hora:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                    case TTFunctions.TypeData.FechaHora:
                                    case TTFunctions.TypeData.Fecha:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                    case TTFunctions.TypeData.Logico:
                                        nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                                        break;
                                }
                                break;
                            }
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            nameControl = myFunctions.GenerateName(myData.Nombre);
                            Control oControl;
                            if (myData.ImInMultiRenglon())
                            {
                                oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "txt" + nameControl);
                                    if (oControl != null)
                                        nameControl = "txt" + nameControl;
                                }
                                else
                                {
                                    nameControl = "ddl" + nameControl;
                                }
                            }
                            else
                            {
                                oControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                    nameControl = "ddl" + nameControl;
                                }
                                else
                                {
                                    nameControl = "cdd" + nameControl;
                                }
                            }
                            break;
                        case TTMetadata.TTMetadataTypeControl.ListBox:
                            nameControl = "lst" + myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.CheckBox:
                            nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.Archivo:
                            nameControl = "lnk" + myFunctions.GenerateName(myData.Nombre) + nameGrid;
                            break;
                    }

                    if (GridRow == null)
                    {
                        object pageControl = Funcion.FindControlRecursive(frmActive, nameGrid);
                        GridView multiRowControl = (GridView)pageControl;
                        resultControl = multiRowControl.Rows[fieldIndex].FindControl(nameControl);
                    }
                    else
                    {
                        resultControl = GridRow.FindControl(nameControl);
                    }
                    return resultControl;
                }
            } /* Si el campo es multirenglón. */
            else
            {
                nameControl = "panMulti" + myFunctions.GenerateName(myData.Nombre); 
                resultControl = FindControlRecursive(frmActive, nameControl);

                if (resultControl == null)
                {
                    switch (myData.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            nameControl = myFunctions.GenerateName(myData.Nombre);
                            Control oControl;
                            if (myData.ImInMultiRenglon())
                            {
                                oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "txt" + nameControl);
                                    if (oControl != null)
                                        nameControl = "txt" + nameControl;
                                }
                                else
                                {
                                    nameControl = "ddl" + nameControl;
                                }
                            }
                            else
                            {
                                oControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                    nameControl = "ddl" + nameControl;
                                }
                                else
                                {
                                    nameControl = "cdd" + nameControl;
                                }
                            }
                            resultControl = oControl;
                            break;
                        default:

                            break;

                    }
               }

            return resultControl;
                
            }
            //ControlFromNameString(nameControl);
        }

        public Object IDControlFromDT(String DtRoot)
        {
            //El root viene Tabla.Dato hay que quitar la tabla 
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf(".") - 1);
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            String nameControl = "";
            if (myData.ImMultiRenglon() != TTMetadata.TTMetadataTypeData.MultiRenglon)
            {
                if (!myData.ImInMultiRenglon())
                {
                    nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                }
                else
                {
                    String nameRel = myData.ImInMultiRenglonDtRelationPrincipal().Nombre;
                    nameControl = "grvcol" + myFunctions.GenerateName(nameRel) + myFunctions.GenerateName(myData.Nombre);
                }
            }
            else
            {
                nameControl = "grv" + myFunctions.GenerateName(myData.Nombre);
            }
            return nameControl;
        }
        
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Noviembre/2013*/
        /*OBJETIVO: Encontrar Control Label/Panel A Partir Del Dato Terminal Raíz (e.g. "14497.64263")*/
        #region
        public Object ControlFromDTSGS(String DtRoot)
        {
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            
            String nameControl = "lbl" + myFunctions.GenerateName(myData.Nombre); 
          
            Object control = FindControlRecursive(frmActive, nameControl);

            if (control == null)
            {
                nameControl = "panMulti" + myFunctions.GenerateName(myData.Nombre);

                control = FindControlRecursive(frmActive, nameControl);
            }

            return control;
        }
        #endregion

        public Object ControlFromDT(String DtRoot, out GridView grid)
        {
            //El root biene Tabla.Dato hay que quitar la tabla 
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf(".") - 1);
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            String nameControl = "";
            if (!myData.ImInMultiRenglon())
            {
                switch (myData.Tipo_de_Control)
                {
                    case TTMetadata.TTMetadataTypeControl.TextBox:
                        {
                            switch (myData.TipodeDato)
                            {
                                case TTFunctions.TypeData.Texto:
                                case TTFunctions.TypeData.Numerico:
                                case TTFunctions.TypeData.Decimal:
                                case TTFunctions.TypeData.Moneda:
                                case TTFunctions.TypeData.Hora:
                                    nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                    break;
                                case TTFunctions.TypeData.FechaHora:
                                case TTFunctions.TypeData.Fecha:
                                    //nameControl = "dt" + myFunctions.GenerateName(myData.Nombre);
                                    nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                    break;
                                case TTFunctions.TypeData.Logico:
                                    nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                                    break;
                            }
                            break;
                        }
                    case TTMetadata.TTMetadataTypeControl.ComboBox:
                        nameControl = myFunctions.GenerateName(myData.Nombre);
                        Control oControl;
                        if (myData.ImInMultiRenglon())
                        {
                            oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                            if (oControl == null)
                            {
                                oControl = FindControlRecursive(frmActive, "txt" + nameControl);
                                if (oControl != null)
                                    nameControl = "txt" + nameControl;
                            }
                            else
                            {
                                nameControl = "ddl" + nameControl;
                            }
                        }
                        else
                        {
                            oControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                            if (oControl == null)
                            {
                                oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                nameControl = "ddl" + nameControl;
                            }
                            else
                            {
                                nameControl = "cdd" + nameControl;
                            }
                        }
                        break;
                    case TTMetadata.TTMetadataTypeControl.ListBox:
                        nameControl = "lst" + myFunctions.GenerateName(myData.Nombre);
                        break;
                    case TTMetadata.TTMetadataTypeControl.CheckBox:
                        nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                        break;
                }
                grid = null;
                return FindControlRecursive(frmActive, nameControl);
            }
            else
            {
                String nameRel = myData.ImInMultiRenglonDtRelationPrincipal().Nombre;
                String nameGrid = "grdMulti" + myFunctions.GenerateName(nameRel);
                grid = (GridView)Funcion.FindControlRecursive(frmActive, nameGrid);

                switch (myData.Tipo_de_Control)
                {
                    case TTMetadata.TTMetadataTypeControl.TextBox:
                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                        break;
                    case TTMetadata.TTMetadataTypeControl.ComboBox:
                        nameControl = myFunctions.GenerateName(myData.Nombre);
                        Control oControl;
                        if (myData.ImInMultiRenglon())
                        {
                            oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                            if (oControl == null)
                            {
                                oControl = FindControlRecursive(frmActive, "txt" + nameControl);
                                if (oControl != null)
                                    nameControl = "txt" + nameControl;
                            }
                            else
                            {
                                nameControl = "ddl" + nameControl;
                            }
                        }
                        else
                        {
                            oControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                            if (oControl == null)
                            {
                                oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                nameControl = "ddl" + nameControl;
                            }
                            else
                            {
                                nameControl = "cdd" + nameControl;
                            }
                        }
                        break;
                    case TTMetadata.TTMetadataTypeControl.CheckBox:
                        nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                        break;
                }
                Control pageControl;
                if (GridRow == null)
                {
                    pageControl = (grid as GridView).Rows[fieldIndex].FindControl(nameControl);
                }
                else
                {
                    pageControl = GridRow.FindControl(nameControl);
                }
                return pageControl;
            }
            //ControlFromNameString(nameControl);
        }

        //public string DecodingValueFromGlobalVariables(TTenumBusinessRules_VariablesGlobal GlobalID)
        public string DecodingValueFromGlobalVariables(string GlobalID)
        {
            if (frmActive.Session != null)
            {
                //for (int i = 0; i < frmActive.Session.Keys.Count; i++)
                //{
                object ElementoSession = frmActive.Session[GlobalID];
                
                if (ElementoSession != null)
                {
                    if (ElementoSession.GetType() == typeof(globalVariable))
                    {
                        globalVariable sessionVar = (globalVariable)ElementoSession;

                        string finalQuery = "";

                        switch (GetTypeControl((sessionVar.control)))
                        {
                            case 1:
                                finalQuery = (sessionVar.control as Label).Text;
                                break;
                            case 2:
                                finalQuery = (sessionVar.control as TextBox).Text;
                                break;
                            case 3:
                                finalQuery = (sessionVar.control as DropDownList).SelectedValue;
                                break;
                            case 4:
                                break;
                            case 5:
                                finalQuery = (sessionVar.control as RadComboBox).SelectedValue;
                                break;
                        }
                        return finalQuery;
                    }
                    else 
                    {
                        return ElementoSession.ToString();
                    }



                    
                }
                //    if (frmActive.Session.Keys[i].ToString() == GlobalID)
                //        return frmActive.Session[GlobalID].ToString();
                //}
                else
                    return "0";
            }
            else
                return "0";
            //switch (GlobalID)
            //{
            //    case TTenumBusinessRules_VariablesGlobal.Grupo_de_Usuario:
            //          String Result = "";
            //            TTSecurity.UserGroupsSystem[] groups = myUserData.UserGroups();
            //            foreach (TTSecurity.UserGroupsSystem group in groups)
            //                Result += group.GetHashCode().ToString() + "[;SEP]";

            //            return Result;
            //         case TTenumBusinessRules_VariablesGlobal.Usuario:
            //            return myUserData.UserID.ToString();                    
            //}
            //return "0";

            
        }


        public string DecodingValueFromCommandTexts(string text)
        {
            String textResult = text;
            while (textResult.IndexOf("FLD[") > -1)
            {
                int xStart = textResult.IndexOf("FLD[");
                int xEnd = textResult.IndexOf("]", xStart);
                String textDT = textResult.Substring(xStart + 4, xEnd - xStart - 4);
                String textDNT = textDT.Substring(0, textDT.IndexOf("."));
                textDT = textDT.Substring(textDT.IndexOf(".") + 1);
                TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
                TTMetadata.MetadataDatos myDatos = myMeta.GetDatosDT(textDNT, textDT);

                String Value = "";
                if (myDatos.ImInMultiRenglon())
                {
                    String nameRel = myDatos.ImInMultiRenglonDtRelationPrincipal().Nombre;
                    String nameGrid = "grdMulti" + myFunctions.GenerateName(nameRel);
                    String nameControl;
                    Control pageControl = Funcion.FindControlRecursive(frmActive, nameGrid);
                    /*************************************************************************************************/
                    switch (myDatos.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.TextBox:
                            {
                                switch (myDatos.TipodeDato)
                                {
                                    case TTFunctions.TypeData.Hora:
                                        nameControl = "txt" + myFunctions.GenerateName(myDatos.Nombre);
                                        if (GridRow == null)
                                        {
                                            pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                                        }
                                        else
                                        {
                                            pageControl = GridRow.FindControl(nameControl);
                                        }
                                        Value = (pageControl as RadTimePicker).SelectedDate.ToString();
                                        break;
                                    case TTFunctions.TypeData.FechaHora:
                                    case TTFunctions.TypeData.Fecha:
                                        nameControl = "txt" + myFunctions.GenerateName(myDatos.Nombre);
                                        if (GridRow == null)
                                        {
                                            pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                                        }
                                        else
                                        {
                                            pageControl = GridRow.FindControl(nameControl);
                                        }
                                        if (pageControl.GetType() == typeof(RadDateTimePicker))
                                            Value = (pageControl as RadDateTimePicker).SelectedDate.ToString();
                                        else if (pageControl.GetType() == typeof(RadDatePicker))
                                            Value = (pageControl as RadDatePicker).SelectedDate.ToString();
                                        break;
                                    case TTFunctions.TypeData.Texto:
                                    case TTFunctions.TypeData.Numerico:
                                    case TTFunctions.TypeData.Decimal:
                                    case TTFunctions.TypeData.Moneda:
                                        nameControl = "txt" + myFunctions.GenerateName(myDatos.Nombre);
                                        if (GridRow == null)
                                        {
                                            pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                                        }
                                        else
                                        {
                                            pageControl = GridRow.FindControl(nameControl);
                                        }
                                        if (pageControl.GetType() == typeof(TextBox))
                                            Value = (pageControl as TextBox).Text;
                                        else if (pageControl.GetType() == typeof(RadComboBox))
                                            Value = (pageControl as RadComboBox).Attributes["CurrentValue"].ToString();
                                        else if (pageControl.GetType() == typeof(RadNumericTextBox))
                                            Value = (pageControl as RadNumericTextBox).Value.ToString();
                                        break;
                                    case TTFunctions.TypeData.Logico:
                                        nameControl = "Ch" + myFunctions.GenerateName(myDatos.Nombre);
                                        if (GridRow == null)
                                        {
                                            pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                                        }
                                        else
                                        {
                                            pageControl = GridRow.FindControl(nameControl);
                                        }
                                        Value = (pageControl as CheckBox).Checked.ToString();
                                        break;
                                }
                                break;
                            }
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            //nameControl = "ddl" + myFunctions.GenerateName(myDatos.Nombre);
                            //if (GridRow == null)
                            //{
                            //    pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                            //    if (pageControl == null)
                            //    {
                            //        nameControl = "txt" + myFunctions.GenerateName(myDatos.Nombre);
                            //        pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                            //    }
                            //    if (pageControl == null)
                            //    {
                            //        nameControl = "cdd" + myFunctions.GenerateName(myDatos.Nombre);
                            //        pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                            //    }
                            //}
                            //else
                            //{
                            //    pageControl = GridRow.FindControl(nameControl);
                            //    if (pageControl == null)
                            //    {
                            //        nameControl = "txt" + myFunctions.GenerateName(myDatos.Nombre);
                            //        pageControl = GridRow.FindControl(nameControl);
                            //    }
                            //    if (pageControl == null)
                            //    {
                            //        nameControl = "ddl" + myFunctions.GenerateName(myDatos.Nombre);
                            //        pageControl = GridRow.FindControl(nameControl);
                            //    }
                            //}
                            //if (pageControl.GetType() == typeof(DropDownList))
                            //    Value = (pageControl as DropDownList).SelectedValue;
                            //else if (pageControl.GetType() == typeof(AjaxControlToolkit.CascadingDropDown))
                            //    Value = (pageControl as AjaxControlToolkit.CascadingDropDown).SelectedValue;

                            nameControl = myFunctions.GenerateName(myDatos.Nombre);

                            if (GridRow == null)
                            {
                                if (myDatos.ImInMultiRenglon())
                                {
                                    pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl("ddl" + nameControl);
                                    if (pageControl == null)
                                    {
                                        nameControl = "txt" + nameControl;
                                        pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl("txt" + nameControl);
                                        Value = ((RadComboBox)pageControl).SelectedValue;
                                    }
                                    else
                                    {
                                        nameControl = "ddl" + nameControl;
                                        if (((CascadingDropDown)pageControl).SelectedValue.IndexOf(":") != -1)
                                            Value = ((CascadingDropDown)pageControl).SelectedValue.Substring(0, (pageControl as CascadingDropDown).SelectedValue.IndexOf(":"));
                                        else
                                            Value = ((CascadingDropDown)pageControl).SelectedValue.ToString();
                                    }
                                }
                                else
                                {
                                    pageControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                                    if (pageControl == null)
                                    {
                                        nameControl = "ddl" + nameControl;
                                        pageControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                        Value = ((DropDownList)pageControl).SelectedValue;
                                    }
                                    else
                                    {
                                        nameControl = "cdd" + nameControl;
                                        if (((CascadingDropDown)pageControl).SelectedValue.IndexOf(":") != -1)
                                            Value = ((CascadingDropDown)pageControl).SelectedValue.Substring(0, (pageControl as CascadingDropDown).SelectedValue.IndexOf(":"));
                                        else
                                            Value = ((CascadingDropDown)pageControl).SelectedValue.ToString();
                                    }
                                }
                            }
                            else
                            {
                                if (myDatos.ImInMultiRenglon())
                                {
                                    pageControl = GridRow.FindControl("ddl" + nameControl);
                                    if (pageControl == null)
                                    {
                                        nameControl = "txt" + nameControl;
                                        pageControl = GridRow.FindControl("txt" + nameControl);
                                        Value = ((RadComboBox)pageControl).SelectedValue;
                                    }
                                    else
                                    {
                                        nameControl = "ddl" + nameControl;
                                        if (((CascadingDropDown)pageControl).SelectedValue.IndexOf(":") != -1)
                                            Value = ((CascadingDropDown)pageControl).SelectedValue.Substring(0, (pageControl as CascadingDropDown).SelectedValue.IndexOf(":"));
                                        else
                                            Value = ((CascadingDropDown)pageControl).SelectedValue.ToString();
                                    }
                                }
                                else
                                {
                                    pageControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                                    if (pageControl == null)
                                    {
                                        nameControl = "ddl" + nameControl;
                                        pageControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                        Value = ((DropDownList)pageControl).SelectedValue;
                                    }
                                    else
                                    {
                                        nameControl = "cdd" + nameControl;
                                        if (((CascadingDropDown)pageControl).SelectedValue.IndexOf(":") != -1)
                                            Value = ((CascadingDropDown)pageControl).SelectedValue.Substring(0, (pageControl as CascadingDropDown).SelectedValue.IndexOf(":"));
                                        else
                                            Value = ((CascadingDropDown)pageControl).SelectedValue.ToString();
                                    }
                                }
                            }
                            break;
                        case TTMetadata.TTMetadataTypeControl.ListBox:
                            nameControl = "lst" + myFunctions.GenerateName(myDatos.Nombre);
                            if (GridRow == null)
                            {
                                pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                            }
                            else
                            {
                                pageControl = GridRow.FindControl(nameControl);
                            }

                            foreach (ListItem item in ((ListBox)FindControlRecursive(frmActive, nameControl)).Items)
                            {
                                if (item.Selected == true)
                                {
                                    Value += item.Value;
                                }
                            }
                            //Value = (pageControl as ListBox).SelectedValue;
                            break;
                        case TTMetadata.TTMetadataTypeControl.CheckBox:
                            nameControl = "Ch" + myFunctions.GenerateName(myDatos.Nombre);
                            if (GridRow == null)
                            {
                                pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                            }
                            else
                            {
                                pageControl = GridRow.FindControl(nameControl);
                            }
                            Value = (pageControl as CheckBox).Checked.ToString();
                            break;
                    }
                    /*************************************************************************************************/
                }
                else
                    switch (myDatos.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.TextBox:
                            {
                                switch (myDatos.TipodeDato)
                                {
                                    case TTFunctions.TypeData.Fecha:
                                        Value = ((RadDatePicker)FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre))).SelectedDate.ToString();
                                        break;
                                    case TTFunctions.TypeData.FechaHora:
                                        Value = ((RadDateTimePicker)FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre))).SelectedDate.ToString();
                                        break;
                                    case TTFunctions.TypeData.Hora:
                                        Value = ((RadTimePicker)FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre))).SelectedDate.ToString();
                                        break;
                                    case TTFunctions.TypeData.Numerico:
                                    case TTFunctions.TypeData.Decimal:
                                    case TTFunctions.TypeData.Moneda:
                                    //Value = ((TextBox)FindControlRecursive(frmActive, "dt" + myFunctions.GenerateName(myDatos.Nombre))).Text; 
                                    //break;
                                    default:
                                        Control theControl = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                        if (theControl.GetType() == typeof(TextBox))
                                            Value = (theControl as TextBox).Text;
                                        else if (theControl.GetType() == typeof(RadComboBox))
                                            Value = (theControl as RadComboBox).Text;
                                        else if (theControl.GetType() == typeof(RadNumericTextBox))
                                            Value = (theControl as RadNumericTextBox).Value.ToString();
                                        break;
                                }
                                break;
                            }
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            //Value = frmActive.Controls.Find("cb" + myFunctions.GenerateName(myDatos.Nombre), true)[0].Text;
                            //Control combo = FindControlRecursive(frmActive, "cdd" + myFunctions.GenerateName(myDatos.Nombre));
                            //if (combo != null && combo.Parent.GetType() == typeof(DataControlFieldCell))  
                            //{
                            //    combo = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                            //    Value = ((CascadingDropDown)combo).SelectedValue;
                            //}
                            //else
                            //{
                            //    combo = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                            //    if (combo != null)
                            //    {
                            //        Value = ((RadComboBox)combo).SelectedValue;
                            //    }
                            //    else
                            //    {
                            //        combo = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                            //        Value = ((DropDownList)combo).SelectedValue;
                            //    }
                            //}
                            //Value = ((DropDownList)FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre))).SelectedValue; //frmActive.Controls.Find("dt" + myFunctions.GenerateName(myDatos.Nombre), true)[0]).Value.ToLongDateString();

                            Control combo;
                            if (myDatos.ImInMultiRenglon())
                            {
                                combo = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                                if (combo == null)
                                {
                                    combo = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                    Value = ((RadComboBox)combo).SelectedValue;
                                }
                                else
                                {
                                    if (((CascadingDropDown)combo).SelectedValue.IndexOf(":") != -1)
                                        Value = ((CascadingDropDown)combo).SelectedValue.Substring(0, (combo as CascadingDropDown).SelectedValue.IndexOf(":"));
                                    else
                                        Value = ((CascadingDropDown)combo).SelectedValue.ToString();
                                }
                            }
                            else
                            {
                                combo = FindControlRecursive(frmActive, "cdd" + myFunctions.GenerateName(myDatos.Nombre));
                                if (combo == null)
                                {
                                    combo = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                                    if (combo == null)
                                    {
                                        combo = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                        Value = ((TextBox)combo).Text;
                                    }
                                    else
                                    {
                                        Value = ((DropDownList)combo).SelectedValue;
                                    }
                                }
                                else
                                {
                                    if (((CascadingDropDown)combo).SelectedValue.IndexOf(":") != -1)
                                        Value = ((CascadingDropDown)combo).SelectedValue.Substring(0, (combo as CascadingDropDown).SelectedValue.IndexOf(":"));
                                    else
                                        Value = ((CascadingDropDown)combo).SelectedValue.ToString();
                                }
                            }
                            break;
                        case TTMetadata.TTMetadataTypeControl.ListBox:
                            foreach (ListItem item in ((ListBox)FindControlRecursive(frmActive, "lst" + myFunctions.GenerateName(myDatos.Nombre))).Items)
                            {
                                if (item.Selected == true)
                                {
                                    Value += Value == "" ? item.Value : "," + item.Value;
                                }
                            }
                            break;
                        case TTMetadata.TTMetadataTypeControl.CheckBox:
                            {
                                Value = ((CheckBox)FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre))).Checked.ToString(); //frmActive.Controls.Find("chk" + myFunctions.GenerateName(myDatos.Nombre), true)[0]).Checked.ToString();
                                break;
                            }
                    }
                textResult = textResult.Replace("FLD[" + textDNT + "." + textDT + "]", Value);
            }

            while (textResult.IndexOf("FLDD[") > -1)
            {
                int xStart2 = textResult.IndexOf("FLDD[");
                int xEnd2 = textResult.IndexOf("]", xStart2);
                String textDT2 = textResult.Substring(xStart2 + 5, xEnd2 - xStart2 - 5);
                String textDNT2 = textDT2.Substring(0, textDT2.IndexOf("."));
                textDT2 = textDT2.Substring(textDT2.IndexOf(".") + 1);
                TTMetadata.Metadata myMeta2 = new TTMetadata.Metadata(myUserData);
                TTMetadata.MetadataDatos myDatos2 = myMeta2.GetDatosDT(textDNT2, textDT2);

                String Value = "";
                switch (myDatos2.Tipo_de_Control)
                {
                    case TTMetadata.TTMetadataTypeControl.ComboBox:
                        //Value = frmActive.Controls.Find("cb" + myFunctions.GenerateName(myDatos.Nombre), true)[0].Text;


                        //Control combo = FindControlRecursive(frmActive, "cdd" + myFunctions.GenerateName(myDatos2.Nombre));
                        //if (combo != null && combo.Parent.GetType() == typeof(DataControlFieldCell))
                        //{
                        //    combo = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos2.Nombre));
                        //    Value = ((CascadingDropDown)combo).SelectedValue;
                        //}
                        //else
                        //{
                        //    combo = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos2.Nombre));
                        //    if (combo != null)
                        //    {
                        //        Value = ((RadComboBox)combo).SelectedValue;
                        //    }
                        //    else
                        //    {
                        //        combo = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos2.Nombre));
                        //        Value = ((DropDownList)combo).SelectedValue;
                        //    }
                        //}
                        //if (((DropDownList)FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos2.Nombre))).SelectedValue != "")
                        //    Value = ((DropDownList)FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos2.Nombre))).SelectedItem.Text;
                        Control combo;
                        if (myDatos2.ImInMultiRenglon())
                        {
                            combo = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos2.Nombre));
                            if (combo == null)
                            {
                                combo = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos2.Nombre));
                                Value = ((RadComboBox)combo).SelectedItem.Text;                            
							}
                            else
                            {
                                if (((CascadingDropDown)combo).SelectedValue.IndexOf(":") != -1)
                                    Value = ((CascadingDropDown)combo).SelectedValue.Substring(0, (combo as CascadingDropDown).SelectedValue.IndexOf(":"));
                                else
                                    Value = ((CascadingDropDown)combo).SelectedValue.ToString();
                            }
                        }
                        else
                        {
                            combo = FindControlRecursive(frmActive, "cdd" + myFunctions.GenerateName(myDatos2.Nombre));
                            if (combo == null)
                            {
                                combo = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos2.Nombre));
                                Value = ((DropDownList)combo).SelectedItem.Text;
                            }
                            else
                            {
                                if (((CascadingDropDown)combo).SelectedValue.IndexOf(":") != -1)
                                    Value = ((CascadingDropDown)combo).SelectedValue.Substring((combo as CascadingDropDown).SelectedValue.LastIndexOf(":") + 1);
                                else
                                    Value = ((CascadingDropDown)combo).SelectedValue.ToString();
                                
                            }
                        }


                        break;
                    case TTMetadata.TTMetadataTypeControl.ListBox:
                        
                        ListBox listboxControl;
                        
                        listboxControl = (ListBox)FindControlRecursive(frmActive, "lst" + myFunctions.GenerateName(myDatos2.Nombre));

                        Value = "";
                        
                        foreach (ListItem item in listboxControl.Items)
                        {
                            if (item.Selected)
                            {
                                Value += (Value == "") ? item.Text : "," + item.Text;
                            }
                        }
                        
                        
                        break;
                }
                textResult = textResult.Replace("FLDD[" + textDNT2 + "." + textDT2 + "]", Value);
            }

            while (textResult.IndexOf("GLOBAL[") > -1)
            {
                String Value = "";
                int xStart2 = textResult.IndexOf("GLOBAL[");
                int xEnd2 = textResult.IndexOf("]", xStart2);
                String textGlobal = textResult.Substring(xStart2 + 7, xEnd2 - xStart2 - 7);
                Value = DecodingValueFromGlobalVariables(textGlobal);
                textResult = textResult.Replace("GLOBAL[" + textGlobal + "]", Value);
            }

            while (textResult.IndexOf("FLDGC[") > -1)
            {
                String Value = "";
                int xStart = textResult.IndexOf("FLDGC[");
                int xEnd = textResult.IndexOf("]", xStart);
                String textDT = textResult.Substring(xStart + 6, xEnd - xStart - 6);
                String textDNT = textDT.Substring(0, textDT.IndexOf("."));
                textDT = textDT.Substring(textDT.IndexOf(".") + 1);
                TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
                TTMetadata.MetadataDatos myDatos = myMeta.GetDatosDT(textDNT, textDT);

                Value = getValuesFromColumn(textDNT, textDT);

                textResult = textResult.Replace("FLDGC[" + textDNT + "." + textDT + "]", Value);

            }
            return textResult;
        }

        public List<Control> GetControlsFromFLDs(string text)
        {
            List<Control> controlList = new List<Control>();
            String textResult = text;

            while (textResult.IndexOf("FLD[") > -1)
            {
                int xStart = textResult.IndexOf("FLD[");
                int xEnd = textResult.IndexOf("]", xStart);
                String textDT = textResult.Substring(xStart + 4, xEnd - xStart - 4);
                String textDNT = textDT.Substring(0, textDT.IndexOf("."));
                textDT = textDT.Substring(textDT.IndexOf(".") + 1);
                TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
                TTMetadata.MetadataDatos myDatos = myMeta.GetDatosDT(textDNT, textDT);

                Control singleControl = new Control();
                String nameControl = "";
                try
                {
                    if (myDatos.ImInMultiRenglon())
                    {
                        switch (myDatos.Tipo_de_Control)
                        {
                            case TTMetadata.TTMetadataTypeControl.TextBox:
                                {
                                    switch (myDatos.TipodeDato)
                                    {
                                        case TTFunctions.TypeData.Texto:
                                        case TTFunctions.TypeData.Numerico:
                                        case TTFunctions.TypeData.Decimal:
                                        case TTFunctions.TypeData.Moneda:
                                        case TTFunctions.TypeData.Hora:
                                            nameControl = "txt" + myFunctions.GenerateName(myDatos.Nombre);
                                            break;
                                        case TTFunctions.TypeData.FechaHora:
                                        case TTFunctions.TypeData.Fecha:
                                            nameControl = "txt" + myFunctions.GenerateName(myDatos.Nombre);
                                            break;
                                        case TTFunctions.TypeData.Logico:
                                            nameControl = "Ch" + myFunctions.GenerateName(myDatos.Nombre);
                                            break;
                                    }
                                    break;
                                }
                            case TTMetadata.TTMetadataTypeControl.ComboBox:
                                nameControl = myFunctions.GenerateName(myDatos.Nombre);
                                Control oControl;

                                if (myDatos.ImInMultiRenglon())
                                {
                                    oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                    if (oControl == null)
                                    {
                                        oControl = FindControlRecursive(frmActive, "txt" + nameControl);
                                        if (oControl != null)
                                            nameControl = "txt" + nameControl;
                                    }
                                    else
                                    {
                                        nameControl = "ddl" + nameControl;
                                    }
                                }
                                else
                                {
                                    oControl = FindControlRecursive(frmActive, "cdd" + nameControl);
                                    if (oControl == null)
                                    {
                                        oControl = FindControlRecursive(frmActive, "ddl" + nameControl);
                                        nameControl = "ddl" + nameControl;
                                    }
                                    else
                                    {
                                        nameControl = "cdd" + nameControl;
                                    }
                                }
                                break;
                            case TTMetadata.TTMetadataTypeControl.ListBox:

                                nameControl = "lst" + myFunctions.GenerateName(myDatos.Nombre);
                                break;
                            case TTMetadata.TTMetadataTypeControl.CheckBox:
                                nameControl = "Ch" + myFunctions.GenerateName(myDatos.Nombre);
                                break;
                        }

                        TTMetadata.MetadataDatos myDatosMulti = myDatos.ImInMultiRenglonDtRelationPrincipal();
                        String sGridName = "grdMulti" + myFunctions.GenerateName(myDatosMulti.Nombre);
                        GridView dg = (GridView)FindControlRecursive(frmActive, sGridName);

                        singleControl = dg.Rows[FieldIndex].FindControl(nameControl);
                        AddControlToList(controlList, singleControl);

                    }
                    else
                        switch (myDatos.Tipo_de_Control)
                        {
                            case TTMetadata.TTMetadataTypeControl.TextBox:
                                {
                                    switch (myDatos.TipodeDato)
                                    {
                                        case TTFunctions.TypeData.Fecha:
                                        case TTFunctions.TypeData.FechaHora:
                                            singleControl = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                            AddControlToList(controlList, singleControl);
                                            break;
                                        case TTFunctions.TypeData.Decimal:
                                        case TTFunctions.TypeData.Moneda:
                                        case TTFunctions.TypeData.Numerico:
                                        //singleControl = FindControlRecursive(frmActive, "dt" + myFunctions.GenerateName(myDatos.Nombre));
                                        //AddControlToList(controlList, singleControl);
                                        //break;
                                        default:
                                            singleControl = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                            AddControlToList(controlList, singleControl);
                                            break;
                                    }
                                    break;
                                }
                            case TTMetadata.TTMetadataTypeControl.ComboBox:
                                //singleControl = ((DropDownList)FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre)));
                                //singleControl = FindControlRecursive(frmActive, "cdd" + myFunctions.GenerateName(myDatos.Nombre));
                                //if (singleControl == null) singleControl = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                //if (singleControl == null) singleControl = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));

                                if (myDatos.ImInMultiRenglon())
                                {
                                    singleControl = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                                    if (singleControl == null)
                                        singleControl = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                }
                                else
                                {
                                    singleControl = FindControlRecursive(frmActive, "cdd" + myFunctions.GenerateName(myDatos.Nombre));
                                    if (singleControl == null)
                                        singleControl = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                                    if (singleControl == null)
                                        singleControl = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));


                                }

                                AddControlToList(controlList, singleControl);
                                break;
                            case TTMetadata.TTMetadataTypeControl.CheckBox:
                                singleControl = ((CheckBox)FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre)));
                                AddControlToList(controlList, singleControl);
                                break;
                        }
                }
                catch { }
                textResult = textResult.Replace("FLD[" + textDNT + "." + textDT + "]", string.Empty);
            }

            while (textResult.IndexOf("FLDGC[") > -1)
            {
                String Value = "";
                int xStart = textResult.IndexOf("FLDGC[");
                int xEnd = textResult.IndexOf("]", xStart);
                String textDT = textResult.Substring(xStart + 6, xEnd - xStart - 6);
                String textDNT = textDT.Substring(0, textDT.IndexOf("."));
                textDT = textDT.Substring(textDT.IndexOf(".") + 1);
                TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
                TTMetadata.MetadataDatos myDatos = myMeta.GetDatosDT(textDNT, textDT);

                Value = getValuesFromColumn(textDNT, textDT);
               
                TextBox ctlFLDGC = new TextBox();
                
                ctlFLDGC.Text = Value;
                
                Control singleControl = ctlFLDGC;
                
                AddControlToList(controlList, singleControl);

                textResult = textResult.Replace("FLDGC[" + textDNT + "." + textDT + "]", Value);

            }
            return controlList;
        }

        private void AddControlToList(List<Control> controlList, Control singleControl)
        {
            if (!controlList.Exists((Control control) => control == singleControl))
                controlList.Add(singleControl);
        }

        private static Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
                return root;

            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                    return t;
            }
            return null;
        }

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
        /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
        #region IDCODMANUAL: 
        public Object getMultirowControl(String DtRoot, int ProcesoId)
        {
            //El root viene Tabla.Dato hay que quitar la tabla 
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf("."));
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            String nameControl = "";

            if (myData.ImMultiRenglon() == TTMetadata.TTMetadataTypeData.MultiRenglon)
            {
                nameControl = "grdMulti" + myFunctions.GenerateName(myData.Nombre);
                GridView dg = (GridView)FindControlRecursive(frmActive, nameControl);
                dg.DataSource = this.frmActive.Session["myMulti" + myFunctions.GenerateName(myData.Nombre)];
                dg.DataBind();
                return dg;
                
            }
            else
            {
                if (myData.ImInMultiRenglon())
                {
                    String nameRel = myData.ImInMultiRenglonDtRelationPrincipal().Nombre;
                    nameControl = "grdMulti" + myFunctions.GenerateName(nameRel);
                    GridView dg = (GridView)FindControlRecursive(frmActive, nameControl);
                    dg.DataSource = this.frmActive.Session["myMulti"+ myFunctions.GenerateName(nameRel)];
                    dg.DataBind();
                    return dg;

                }
                else
                {
					string SqlQuery = "SELECT * FROM TTMetadata WHERE DependienteTabla = " + DNTRoot + " AND ProcesoId = " + ProcesoId;
                    TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                    SqlCommand cmd = new SqlCommand(SqlQuery);
                    cmd.CommandType = CommandType.Text;
                    DataSet ds = db.Consulta(cmd);
                    DtRoot= ds.Tables[0].Rows[0][0].ToString();
                    myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
                    
                    if (isMultiRow(DtRoot))
                    {
                        nameControl = "grdMulti" + myFunctions.GenerateName(myData.Nombre);
                        GridView dg = (GridView)FindControlRecursive(frmActive, nameControl);
                        dg.DataSource = this.frmActive.Session["myMulti" + myFunctions.GenerateName(myData.Nombre)];
                        dg.DataBind();
                        return dg;

                    }
                    else
                    {
                        return null;
                    }
                }
                
            }
        }

        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
        /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
        #region IDCODMANUAL: 
        public string GenerateQueryToFilterMultirowControl(Control originControl, string originQuery, string sessionVariableName)
        {
            string finalQuery = "";

            switch (GetTypeControl(originControl))
            {
                case 1:
                    finalQuery = originQuery.Replace("GLOBAL[" + sessionVariableName + "]", (originControl as Label).Text);
                    break;
                case 2:
                    finalQuery = originQuery.Replace("GLOBAL[" + sessionVariableName + "]", (originControl as TextBox).Text);
                    break;
                case 3:
                    finalQuery = originQuery.Replace("GLOBAL[" + sessionVariableName + "]", (originControl as DropDownList).SelectedValue);
                    break;
                case 4:
                    break;
                case 5:
                    finalQuery = originQuery.Replace("GLOBAL[" + sessionVariableName + "]", (originControl as RadComboBox).SelectedValue);
                    break;
            }

            return finalQuery;
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
        /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
        #region IDCODMANUAL: 
        public int GetTypeControl(Control control)
        {
            int identifier;

            if (control.GetType() == typeof(Label)) identifier = 1;
            else if (control.GetType() == typeof(TextBox)) identifier = 2;
            else if (control.GetType() == typeof(DropDownList)) identifier = 3;
            else if (control.GetType() == typeof(ListBox)) identifier = 4;
            else if (control.GetType() == typeof(RadComboBox)) identifier = 5;
            else if (control.GetType() == typeof(CascadingDropDown)) identifier = 6;
            else if (control.GetType() == typeof(RadDatePicker)) identifier = 7;
            else if (control.GetType() == typeof(RadNumericTextBox)) identifier = 8;
            else if (control.GetType() == typeof(CheckBox)) identifier = 9;
            else if (control.GetType() == typeof(RadTimePicker)) identifier = 10;
            else if (control.GetType() == typeof(LinkButton)) identifier = 11;
            else identifier = 0;

            return identifier;
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
        /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
        #region IDCODMANUAL:
        public Control GetControlFromFLD(string text)
        {
            try
            {
                Control control = null;
                String textResult = text;

                if (textResult.IndexOf("FLD[") > -1)
                {
                    int xStart = textResult.IndexOf("FLD[");
                    int xEnd = textResult.IndexOf("]", xStart);
                    String textDT = textResult.Substring(xStart + 4, xEnd - xStart - 4);
                    String textDNT = textDT.Substring(0, textDT.IndexOf("."));
                    textDT = textDT.Substring(textDT.IndexOf(".") + 1);
                    TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
                    TTMetadata.MetadataDatos myDatos = myMeta.GetDatosDT(textDNT, textDT);

                    //String Value = "";
                    if (myDatos.ImInMultiRenglon())
                    {
                        //TTMetadata.MetadataDatos myDatosMulti = myDatos.ImInMultiRenglonDtRelationPrincipal();
                        //String sGridName = "grdMulti" + myFunctions.GenerateName(myDatosMulti.Nombre);
                        //String sColName = "grvcol" + myFunctions.GenerateName(myDatosMulti.Nombre) + myFunctions.GenerateName(myDatos.Nombre);
                        //GridView dg = (GridView)FindControlRecursive(frmActive, sGridName);
                        //AddControlToList(controlList, dg);
                        ////controlList.Add(dg);
                        //Value = "1";
                    }
                    else
                        switch (myDatos.Tipo_de_Control)
                        {
                            case TTMetadata.TTMetadataTypeControl.TextBox:
                                {
                                    switch (myDatos.TipodeDato)
                                    {
                                        case TTFunctions.TypeData.Fecha:
                                        case TTFunctions.TypeData.FechaHora:
                                        case TTFunctions.TypeData.Decimal:
                                        case TTFunctions.TypeData.Moneda:
                                        case TTFunctions.TypeData.Numerico:
                                            control = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                            break;
                                    }
                                    break;
                                }
                            case TTMetadata.TTMetadataTypeControl.ComboBox:
                                //control = FindControlRecursive(frmActive, "cdd" + myFunctions.GenerateName(myDatos.Nombre));
                                //if (control == null) control = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                //if (control == null) control = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));

                                if (myDatos.ImInMultiRenglon())
                                {
                                    control = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                                    if (control == null)
                                        control = FindControlRecursive(frmActive, "txt" + myFunctions.GenerateName(myDatos.Nombre));
                                }
                                else
                                {
                                    control = FindControlRecursive(frmActive, "cdd" + myFunctions.GenerateName(myDatos.Nombre));
                                    if (control==null)
                                        control = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                                }
                                //else
                                //{
                                //    control = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                                //    if (control != null) nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                //    else control = FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre));
                                //}
                                //control = ((DropDownList)FindControlRecursive(frmActive, "ddl" + myFunctions.GenerateName(myDatos.Nombre)));
                                break;
                            case TTMetadata.TTMetadataTypeControl.CheckBox:
                                control = ((CheckBox)FindControlRecursive(frmActive, "Ch" + myFunctions.GenerateName(myDatos.Nombre)));
                                break;
                        }
                }
                else
                {
                    control = null;
                }

                return control;
            }
            catch (Exception ex)
            {
                this.frmActive.ShowAlert("GetControlFromCommandText: " + ex);
                return null;
            }

        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
        /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
        #region IDCODMANUAL:
        public String GetSessionVariableFromGLOBAL(string text)
        {
            try
            {
                String variable;
                String textResult = text;

                if (textResult.IndexOf("GLOBAL[") > -1)
                {
                    int xStart2 = textResult.IndexOf("GLOBAL[");
                    int xEnd2 = textResult.IndexOf("]", xStart2);
                    String textGlobal = textResult.Substring(xStart2 + 7, xEnd2 - xStart2 - 7);
					if (this.frmActive.Session[textGlobal] != null)
                        variable = textGlobal;
                    else
                        variable = null;
                }
                else
                {
                    variable = null;
                }

                return variable;
            }
            catch (Exception ex)
            {
                this.frmActive.ShowAlert("GetSessionVariableFromGLOBAL: " + ex);
                return null;
            }

        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
        /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
        #region IDCODMANUAL:
        public Object ExecuteFunction(Control column, GridView grid, int function)
        {
            switch (function)
            {
                case 0:
                    /*Function Sum (Sumatoria)*/
                    try
                    {
                        int countRows = grid.Rows.Count;
                        Double sumatoria = 0;
                        for (int i = 0; i < countRows; i++)
                        {
                            try
                            {
                                Telerik.Web.UI.RadNumericTextBox txt = (Telerik.Web.UI.RadNumericTextBox)grid.Rows[i].FindControl(column.ID);
                                sumatoria = sumatoria + double.Parse(txt.Text);
                            }
                            catch
                            {
                                try
                                {
                                    TextBox txt = (TextBox)grid.Rows[i].FindControl(column.ID);
                                    sumatoria = sumatoria + double.Parse(txt.Text);

                                }
                                catch
                                {
                                    sumatoria = sumatoria + 0;
                                }
                            }
                        }
                        return sumatoria;
                   }
                    catch (Exception ex)
                    {
                        this.frmActive.ShowAlert("ExecuteFunction: " + ex);
                        return null;
                    }
                case 1:
                    /*Function Avg (Promedio)*/
                    return null;;
                case 2:
                    /*Function Max (Mayor)*/
                    try
                    {
                        int countRows = grid.Rows.Count;
                        Double mayor = -999999;
                        for (int i = 0; i < countRows; i++)
                        {
                            try
                            {
                                Telerik.Web.UI.RadNumericTextBox txt = (Telerik.Web.UI.RadNumericTextBox)grid.Rows[i].FindControl(column.ID);
                                Double aux = double.Parse(txt.Text);
                                if (aux > mayor)
                                    mayor = aux;
                            }
                            catch
                            {
                                try
                                {
                                    TextBox txt = (TextBox)grid.Rows[i].FindControl(column.ID);
                                    Double aux = double.Parse(txt.Text);
                                    if (aux > mayor)
                                        mayor = aux;

                                }
                                catch
                                {
                                    
                                }
                            }
                        }
                        return mayor;
                    }
                    catch (Exception ex)
                    {
                        this.frmActive.ShowAlert("ExecuteFunction: " + ex);
                        return null;
                    }
                case 3:
                    /*Function Min (Menor)*/
                    try
                    {
                        int countRows = grid.Rows.Count;
                        Double menor = 999999;
                        for (int i = 0; i < countRows; i++)
                        {
                            try
                            {
                                Telerik.Web.UI.RadNumericTextBox txt = (Telerik.Web.UI.RadNumericTextBox)grid.Rows[i].FindControl(column.ID);
                                Double aux = double.Parse(txt.Text);
                                if (aux < menor)
                                    menor = aux;
                            }
                            catch
                            {
                                try
                                {
                                    TextBox txt = (TextBox)grid.Rows[i].FindControl(column.ID);
                                    Double aux = double.Parse(txt.Text);
                                    if (aux < menor)
                                        menor = aux;

                                }
                                catch
                                {

                                }
                            }
                        }
                        return menor;
                    }
                    catch (Exception ex)
                    {
                        this.frmActive.ShowAlert("ExecuteFunction: " + ex);
                        return null;
                    }
                default:
            return null;
        }

        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 11/Septiembre/2014*/
        /*OBJETIVO: Obtener un control Multirenglón (GridView) apartir de un DTID.*/
        #region IDCODMANUAL:
        public Control getMultiRowControl(String DtRoot)
        {
            //El root viene Tabla.Dato hay que quitar la tabla 
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf("."));
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            String nameControl = "";
            Control result = null;

            if (isMultiRow(DtRoot))
            {
                nameControl = "grdMulti" + myFunctions.GenerateName(myData.Nombre);
                GridView dg = (GridView)FindControlRecursive(frmActive, nameControl);
                result = dg;

            }
            else
            {
                if (myData.ImInMultiRenglon())
                {
                    String nameRel = myData.ImInMultiRenglonDtRelationPrincipal().Nombre;
                    nameControl = "grdMulti" + myFunctions.GenerateName(nameRel);
                    GridView dg = (GridView)FindControlRecursive(frmActive, nameControl);
                    result = dg;

                }
               

            }

            return result;
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 31/Octubre/2014*/
        /*OBJETIVO: Serializar arreglo de objetos para obtener los valores de una columna en específico. */
        #region IDCODMANUAL:
        public String getValuesFromColumn(String textDNT, String textDT)
        {
            String result = "";
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(textDNT, textDT);
            

            if (myData.ImInMultiRenglon())
            {
                TTMetadata.MetadataDatos myDataPrincipal = myData.ImInMultiRenglonDtRelationPrincipal();
                String nameArray = myFunctions.GenerateName(myDataPrincipal.Nombre);
                String nameField = myFunctions.GenerateName(myData.Nombre);
                object myArrayData = (object)frmActive.Session["myMulti" + nameArray];
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(myArrayData);
                object[] dict =(object[]) new JavaScriptSerializer().DeserializeObject(json);
                
                for (int i = 0; i < dict.Length; i++)
                {
                    object val = ((Dictionary<string,object>)dict[i])[nameField];
                    result += val == null ? "" : (result == "") ? val.ToString() : "," + val.ToString();
                }
                
            }
            
            return result;
        }

        public String getValueFromCell(int datoId, int fieldIndex)
        {
            String result = "";
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(datoId);


            if (myData.ImInMultiRenglon())
            {
                TTMetadata.MetadataDatos myDataPrincipal = myData.ImInMultiRenglonDtRelationPrincipal();
                String nameArray = myFunctions.GenerateName(myDataPrincipal.Nombre);
                String nameField = myFunctions.GenerateName(myData.Nombre);
                object myArrayData = (object)frmActive.Session["myMulti" + nameArray];
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(myArrayData);
                object[] dict = (object[])new JavaScriptSerializer().DeserializeObject(json);

                object val = ((Dictionary<string, object>)dict[fieldIndex])[nameField];
                result = val == null ? "" : val.ToString() ;

            }

            return result;
        }
        #endregion

        public Type getTypeFromDT(TTFunctions.TypeData value)
        {
            Type result = null;

            switch (value)
            {
                case TTFunctions.TypeData.Texto:
                    result = typeof(string);
                    break;
                default:
                    break;
            }

            return result;
        }

        public String getFilterFunction(Type value)
        {
            String result = "";

            switch (Type.GetTypeCode(value))
            {
                case TypeCode.Int32:
                    result = "EqualTo";
                    break;

                case TypeCode.String:
                    result = "Contains";
                    break;
            }

            return result;
        }

    }
    public class BusinessControl
    {
        private TTSecurity.GlobalData myUserData = new TTSecurity.GlobalData();
        private TTFunctions.Functions myFunctions = new TTFunctions.Functions();

        private string sDT;
        public string DT
        {
            get { return sDT; }
        }

        private Type controlType;
        public Type ControlType
        {
            get { return controlType; }
        }

        private Control pageControl;
        public Control PageControl
        {
            get { return pageControl; }
            set { pageControl = value; }
        }

        private int fieldIndex;
        public int FieldIndex
        {
            get { return fieldIndex; }
            set { fieldIndex = value; }
        }

		private GridViewRow gridRow;
        public GridViewRow GridRow
        {
            get { return gridRow; }
            set { gridRow = value; }
        }
		
        public BusinessControl(Page frmActive, String DtRoot, int fieldIndex)
        {
            this.fieldIndex = fieldIndex;
            FillBusinessControl(frmActive, DtRoot);
        }

        public BusinessControl(Page frmActive, String DtRoot, GridViewRow gridRow)
        {
            this.gridRow = gridRow;
            FillBusinessControl(frmActive, DtRoot);
        }
        public BusinessControl(Page frmActive, String DtRoot)
        {
            FillBusinessControl(frmActive, DtRoot);
        }
        protected void FillBusinessControl(Page frmActive, String DtRoot)
        {
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf(".") - 1);
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);
            String nameControl = "";

            /*Cuando el Dato Terminal es un ListBox la función myData.ImMultiRenglon() devuelve True, valor érroneo ya que un ListBox no es un multirenglon */
            /*Solución: Se agrega la siguiente condicional If para interceptar el control y no dejar que ejecute la función myData.ImMultiRenglon()*/
            if (myData.Tipo_de_Control == TTMetadata.TTMetadataTypeControl.ListBox)
            {
                nameControl = "lst" + myFunctions.GenerateName(myData.Nombre);
                sDT = myFunctions.GenerateName(myData.Nombre);
                pageControl = Funcion.FindControlRecursive(frmActive, nameControl);
            }
            else if (myData.ImMultiRenglon() != TTMetadata.TTMetadataTypeData.MultiRenglon)
            {
                if (!myData.ImInMultiRenglon())
                {
                    switch (myData.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.TextBox:
                            {
                                switch (myData.TipodeDato)
                                {
                                    case TTFunctions.TypeData.Texto:
                                    case TTFunctions.TypeData.Numerico:
                                    case TTFunctions.TypeData.Decimal:
                                    case TTFunctions.TypeData.Moneda:
                                    case TTFunctions.TypeData.Hora:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        sDT = myFunctions.GenerateName(myData.Nombre);
                                        pageControl = Funcion.FindControlRecursive(frmActive, nameControl);
                                        break;
                                    case TTFunctions.TypeData.FechaHora:
                                    case TTFunctions.TypeData.Fecha:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        sDT = myFunctions.GenerateName(myData.Nombre);
                                        pageControl = Funcion.FindControlRecursive(frmActive, nameControl);
                                        break;
                                    case TTFunctions.TypeData.Logico:
                                        nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                                        sDT = myFunctions.GenerateName(myData.Nombre);
                                        pageControl = Funcion.FindControlRecursive(frmActive, nameControl);
                                        break;
                                }
                                break;
                            }
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            //nameControl = myFunctions.GenerateName(myData.Nombre);
                            //Control oControl = Funcion.FindControlRecursive(frmActive, "cdd" + nameControl);
                            //if (oControl != null) nameControl = "cdd" + nameControl;
                            //else
                            //{
                            //    oControl = Funcion.FindControlRecursive(frmActive, "txt" + nameControl);
                            //    if (oControl != null) nameControl = "txt" + nameControl;
                            //    else nameControl = "ddl" + nameControl;
                            //}
                            //nameControl = "ddl" + myFunctions.GenerateName(myData.Nombre);

                            nameControl = myFunctions.GenerateName(myData.Nombre);
                            Control oControl;
                            if (myData.ImInMultiRenglon())
                            {
                                oControl = Funcion.FindControlRecursive(frmActive, "ddl" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = Funcion.FindControlRecursive(frmActive, "txt" + nameControl);
                                    if (oControl != null)
                                        nameControl = "txt" + nameControl;
                                }
                                else
                                {
                                    nameControl = "ddl" + nameControl;

                                }
                            }
                            else
                            {
                                oControl = Funcion.FindControlRecursive(frmActive, "cdd" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = Funcion.FindControlRecursive(frmActive, "ddl" + nameControl);

                                    if (oControl == null)
                                    {
                                        oControl = Funcion.FindControlRecursive(frmActive, "txt" + nameControl);
                                        nameControl = "txt" + nameControl;
                                    }
                                    else
                                    {
                                        nameControl = "ddl" + nameControl;
                                    }
                                }
                                else
                                {
                                    nameControl = "cdd" + nameControl;
                                }
                            }
                            sDT = myFunctions.GenerateName(myData.Nombre);
                            pageControl = Funcion.FindControlRecursive(frmActive, nameControl);
                            break;
                        case TTMetadata.TTMetadataTypeControl.ListBox:
                            nameControl = "lst" + myFunctions.GenerateName(myData.Nombre);
                            sDT = myFunctions.GenerateName(myData.Nombre);
                            pageControl = Funcion.FindControlRecursive(frmActive, nameControl);
                            break;
                        case TTMetadata.TTMetadataTypeControl.CheckBox:
                            nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                            sDT = myFunctions.GenerateName(myData.Nombre);
                            pageControl = Funcion.FindControlRecursive(frmActive, nameControl);
                            break;
                    }
                }
                else
                {
                    String nameRel = myData.ImInMultiRenglonDtRelationPrincipal().Nombre;
                    //nameControl = "grvcol" + myFunctions.GenerateName(nameRel) + myFunctions.GenerateName(myData.Nombre);
                    String nameGrid = "grdMulti" + myFunctions.GenerateName(nameRel);
                    /*************************************************************************************************/
                    switch (myData.Tipo_de_Control)
                    {
                        case TTMetadata.TTMetadataTypeControl.TextBox:
                            {
                                switch (myData.TipodeDato)
                                {
                                    case TTFunctions.TypeData.Texto:
                                    case TTFunctions.TypeData.Numerico:
                                    case TTFunctions.TypeData.Decimal:
                                    case TTFunctions.TypeData.Moneda:
                                    case TTFunctions.TypeData.Hora:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        sDT = myFunctions.GenerateName(myData.Nombre);
                                        break;
                                    case TTFunctions.TypeData.FechaHora:
                                    case TTFunctions.TypeData.Fecha:
                                        nameControl = "txt" + myFunctions.GenerateName(myData.Nombre);
                                        sDT = myFunctions.GenerateName(myData.Nombre);
                                        break;
                                    case TTFunctions.TypeData.Logico:
                                        nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                                        sDT = myFunctions.GenerateName(myData.Nombre);
                                        break;
                                }
                                break;
                            }
                        case TTMetadata.TTMetadataTypeControl.ComboBox:
                            //nameControl = myFunctions.GenerateName(myData.Nombre);
                            //Control oControl = Funcion.FindControlRecursive(frmActive, "ddl" + nameControl);
                            //if (oControl != null) nameControl = "ddl" + nameControl;
                            //else
                            //{
                            //    oControl = Funcion.FindControlRecursive(frmActive, "txt" + nameControl);
                            //    if (oControl != null) nameControl = "txt" + nameControl;
                            //    else nameControl = "cdd" + nameControl;
                            //}
                            nameControl = myFunctions.GenerateName(myData.Nombre);
                            Control oControl;
                            if (myData.ImInMultiRenglon())
                            {
                                oControl = Funcion.FindControlRecursive(frmActive, "ddl" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = Funcion.FindControlRecursive(frmActive, "txt" + nameControl);
                                    if (oControl != null)
                                        nameControl = "txt" + nameControl;
                                }
                                else
                                {
                                    nameControl = "ddl" + nameControl;
                                }
                            }
                            else
                            {
                                oControl = Funcion.FindControlRecursive(frmActive, "cdd" + nameControl);
                                if (oControl == null)
                                {
                                    oControl = Funcion.FindControlRecursive(frmActive, "ddl" + nameControl);
                                    nameControl = "ddl" + nameControl;
                                }
                                else
                                {
                                    nameControl = "cdd" + nameControl;
                                }
                            }
                            sDT = myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.ListBox:
                            nameControl = "lst" + myFunctions.GenerateName(myData.Nombre);
                            sDT = myFunctions.GenerateName(myData.Nombre);
                            break;
                        case TTMetadata.TTMetadataTypeControl.CheckBox:
                            nameControl = "Ch" + myFunctions.GenerateName(myData.Nombre);
                            sDT = myFunctions.GenerateName(myData.Nombre);
                            break;
                    }
                    /*************************************************************************************************/
                    sDT = myFunctions.GenerateName(myData.Nombre);
                    pageControl = Funcion.FindControlRecursive(frmActive, nameGrid);

					if (GridRow == null)
                    {
                        pageControl = (pageControl as GridView).Rows[fieldIndex].FindControl(nameControl);
                    }
                    else
                    {
                        pageControl = GridRow.FindControl(nameControl);
                    }
                }
            }
            else
            {
                String nameRel = myData.Nombre;
                String nameGrid = "grv" + myFunctions.GenerateName(nameRel);
                sDT = myFunctions.GenerateName(myData.Nombre);
                pageControl = Funcion.FindControlRecursive(frmActive, nameGrid);
            }
            if (pageControl != null)
                controlType = pageControl.GetType();
        }

        public BusinessControl(Control control)
        {
            pageControl = control;
            //sDT = myFunctions.GenerateName(myData.Nombre);
            controlType = control.GetType();
        }

        //DecodingValueControlFromDTs()
        public string DecodingValueFromControl()
        {
            string returnValue = string.Empty;
            try
            {
                if (controlType == typeof(TextBox))
                {
                    returnValue = (pageControl as TextBox).Text;
                }
                else if (controlType == typeof(CheckBox))
                {
                    returnValue = (pageControl as CheckBox).Checked.ToString().ToLower();
                }
                else if (controlType == typeof(DropDownList))
                {
                    if ((pageControl as DropDownList).SelectedValue != null)
                    {
                        if ((pageControl as DropDownList).SelectedValue.GetType() == typeof(DataRowView))
                            return (((pageControl as DropDownList).SelectedValue))[0].ToString();
                        else
                            return ((pageControl as DropDownList).SelectedValue.ToString());
                    }
                }
                else if (controlType == typeof(AjaxControlToolkit.CascadingDropDown))
                {
                    if ((pageControl as AjaxControlToolkit.CascadingDropDown).SelectedValue != null)
                    {
                        if ((pageControl as AjaxControlToolkit.CascadingDropDown).SelectedValue.IndexOf(":") != -1)
                            returnValue = (pageControl as AjaxControlToolkit.CascadingDropDown).SelectedValue.Substring(0, (pageControl as AjaxControlToolkit.CascadingDropDown).SelectedValue.IndexOf(":"));
                        else 
                            returnValue = ((pageControl as AjaxControlToolkit.CascadingDropDown).SelectedValue.ToString());
                    }
                }
                else if (controlType == (typeof(RadTimePicker)))
                {
                    return (pageControl as RadTimePicker).SelectedDate.ToString();
                }
                else if (controlType == (typeof(RadComboBox)))
                {
                    if (pageControl.ID.StartsWith("txt"))

                        if ((pageControl as RadComboBox).Attributes["CurrentValue"] ==null)
                            return (pageControl as RadComboBox).SelectedValue.ToString();
                        else
                            return (pageControl as RadComboBox).Attributes["CurrentValue"].ToString();
                    else
                        return (pageControl as RadComboBox).SelectedValue.ToString();
                }
                else if (pageControl.GetType() == typeof(RadDatePicker))
                {
                    return ((pageControl as RadDatePicker).SelectedDate.ToString());
                }
                else if (pageControl.GetType() == typeof(RadDateTimePicker))
                {
                    return ((pageControl as RadDateTimePicker).SelectedDate.ToString());
                }
                else if (pageControl.GetType() == typeof(RadNumericTextBox))
                {
                    return ((pageControl as RadNumericTextBox).Value.ToString());
                }
                else if (pageControl.GetType() == typeof(ListBox))
                {
                    ListBox listboxControl = (ListBox)pageControl;

                    string Value = "";

                    foreach (ListItem item in listboxControl.Items)
                    {
                        if (item.Selected)
                        {
                            Value += (Value == "") ? item.Text : "," + item.Text;
                        }
                    }
                    return Value;
                }
                return returnValue;
            }
            catch
            {
                throw new Exception("Las Reglas de negocio que tienen un alcance de Proceso con Condiciones que usan un campo Field no Aplican en una operacion tipo Delete, Export o Print");
            }
        }

        public Control setValueFromArrayToControl(Control ctl, String value)
        {
            if (ctl.GetType() == typeof(RadComboBox))
            {
                (ctl as RadComboBox).SelectedValue = value;
                (ctl as RadComboBox).Attributes["CurrentValue"] = value;
            }
            return ctl;
        }
    }

}









