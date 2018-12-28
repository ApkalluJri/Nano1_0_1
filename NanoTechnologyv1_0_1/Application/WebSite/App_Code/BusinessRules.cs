using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using AjaxControlToolkit;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar;
using TTBusinessRules;
using TTPagers;

namespace App_Code.TTBusinessRules
{
    public class BusinessRules
    {
        private String varNameRule;
        private TTenumBusinessRules_Alcance varAlcanceRule;
        private TTenumBusinessRules_Operacion[] varOperacionRule;
        private TTenumBusinessRules_ProcessEvent[] varProcessRule;
        private TTenumBusinessRules_FieldEvent[] varFieldRule;
        private BusinessRules_Coditions[] varConditions;
        private BusinessRules_Actions[] varActionstrue;
        private BusinessRules_Actions[] varActionsfalse;
        public String NameRule
        {
            get { return varNameRule; }
            set { varNameRule = value; }
        }
        public TTenumBusinessRules_Alcance AlcanceRule
        {
            get { return varAlcanceRule; }
            set { varAlcanceRule = value; }
        }
        public TTenumBusinessRules_Operacion[] OperacionRule
        {
            get { return varOperacionRule; }
            set { varOperacionRule = value; }
        }
        public TTenumBusinessRules_ProcessEvent[] ProcessRule
        {
            get { return varProcessRule; }
            set { varProcessRule = value; }
        }
        public TTenumBusinessRules_FieldEvent[] FieldRule
        {
            get { return varFieldRule; }
            set { varFieldRule = value; }
        }
        public BusinessRules_Coditions[] Conditions
        {
            get { return varConditions; }
            set { varConditions = value; }
        }
        public BusinessRules_Actions[] ActionsTrue
        {
            get { return varActionstrue; }
            set { varActionstrue = value; }
        }
        public BusinessRules_Actions[] ActionsFalse
        {
            get { return varActionsfalse; }
            set { varActionsfalse = value; }
        }

        public BusinessRules()
        {
        }

        public BusinessRules ShallowCopy()
        {
            return (BusinessRules)this.MemberwiseClone();
        }

        public BusinessRules DeepCopy()
        {
            BusinessRules other =  (BusinessRules)this.MemberwiseClone();
            other.Conditions = new BusinessRules_Coditions[Conditions.Length];
            for (int i = 0; i < Conditions.Length; i++)
            {
                other.Conditions[i] = new BusinessRules_Coditions(Conditions[i].OperatorCondition, Conditions[i].OperatorCondition1, Conditions[i].OperatorConditionValue1, Conditions[i].ConditionCondition, Conditions[i].OperatorCondition2, Conditions[i].OperatorConditionValue2);
            }
            other.ActionsTrue = new BusinessRules_Actions[ActionsTrue.Length];
            for (int i = 0; i < ActionsTrue.Length; i++)
            {
                other.ActionsTrue[i] = new BusinessRules_Actions(ActionsTrue[i].ActionType, ActionsTrue[i].Parameters, ActionsTrue[i].ActionResultType);
            }
            return other;
        }
    }//End class BusinessRules

    public class BusinessRules_Actions
    {
        private TTenumBusinessRules_ActionType varActionType;
        private BusinessRules_Actions_Parameters[] varParameters;
        private TTenumBusinessRules_ActionResultType varActionResultType;

        public TTenumBusinessRules_ActionType ActionType
        {
            get { return varActionType; }
            set { varActionType = value; }
        }
        public BusinessRules_Actions_Parameters[] Parameters
        {
            get { return varParameters; }
            set { varParameters = value; }
        }
        public TTenumBusinessRules_ActionResultType ActionResultType
        {
            get { return varActionResultType; }
            set { varActionResultType = value; }
        }

		public BusinessRules_Actions()
        {
        }

        public BusinessRules_Actions(TTenumBusinessRules_ActionType ActionType, BusinessRules_Actions_Parameters[] Parameters, TTenumBusinessRules_ActionResultType ActionResultType)
        {
            this.ActionType = ActionType;
            this.Parameters = new BusinessRules_Actions_Parameters[Parameters.Length];
            
            for (int i = 0; i < Parameters.Length; i++)
            {
                this.Parameters[i] = new BusinessRules_Actions_Parameters(Parameters[i].ParameterType, Parameters[i].ParameterValue);
            }

            this.ActionResultType = ActionResultType;
        }
    }
    //End class BusinessRules_Actions

    public class BusinessRules_Actions_Parameters
    {
        private TTenumBusinessRules_ActionParameterType varParameterType;
        private String varParameterValue;

        public TTenumBusinessRules_ActionParameterType ParameterType
        {
            get { return varParameterType; }
            set { varParameterType = value; }
        }
        public String ParameterValue
        {
            get { return varParameterValue; }
            set { varParameterValue = value; }
        }

        public BusinessRules_Actions_Parameters()
        {
        }

        public BusinessRules_Actions_Parameters(TTenumBusinessRules_ActionParameterType ParameterType, String ParameterValue)
        {
            this.ParameterType = ParameterType;
            this.ParameterValue = ParameterValue;
        }
	}//End class BusinessRules_Actions_Parameters

    public class BusinessRules_Coditions
    {
        private TTenumBusinessRules_ConditionOperator varOperatorCondition;
        private TTenumBusinessRules_ConditionTypeOperator1 varOperatorCondition1;
        private String varOperatorConditionValue1;
        private TTenumBusinessRules_ConditionCondition varConditionCondition;
        private TTenumBusinessRules_ConditionTypeOperator2 varOperatorCondition2;
        private String varOperatorConditionValue2;
        public TTenumBusinessRules_ConditionOperator OperatorCondition
        {
            get { return varOperatorCondition; }
            set { varOperatorCondition = value; }
        }
        public TTenumBusinessRules_ConditionTypeOperator1 OperatorCondition1
        {
            get { return varOperatorCondition1; }
            set { varOperatorCondition1 = value; }
        }
        public String OperatorConditionValue1
        {
            get { return varOperatorConditionValue1; }
            set { varOperatorConditionValue1 = value; }
        }
        public TTenumBusinessRules_ConditionCondition ConditionCondition
        {
            get { return varConditionCondition; }
            set { varConditionCondition = value; }
        }
        public TTenumBusinessRules_ConditionTypeOperator2 OperatorCondition2
        {
            get { return varOperatorCondition2; }
            set { varOperatorCondition2 = value; }
        }
        public String OperatorConditionValue2
        {
            get { return varOperatorConditionValue2; }
            set { varOperatorConditionValue2 = value; }
        }

        public BusinessRules_Coditions()
        { }

        public BusinessRules_Coditions(TTenumBusinessRules_ConditionOperator OperatorCondition, TTenumBusinessRules_ConditionTypeOperator1 OperatorCondition1, String OperatorConditionValue1, TTenumBusinessRules_ConditionCondition ConditionCondition, TTenumBusinessRules_ConditionTypeOperator2 OperatorCondition2, String OperatorConditionValue2)
        {
            this.OperatorCondition = OperatorCondition;
            this.OperatorCondition1 = OperatorCondition1;
            this.OperatorConditionValue1 = OperatorConditionValue1;
            this.ConditionCondition = ConditionCondition;
            this.OperatorCondition2 = OperatorCondition2;
            this.OperatorConditionValue2 = OperatorConditionValue2;

        }
    }//End class BusinessRules_Conditions

    public class BusinessOperations
    {
        //private Form frmActive;
        // Referencia a la página que llama la regla de negocio
        protected TTBasePage.TTBasePage frmActive;
        //-----------------------------------------------------
        private int giProcess;
        private TTSecurity.GlobalData myUserData;
        private TTFunctions.Functions myFunctions = new TTFunctions.Functions();
        private BusinessRulesFunctions myBusinessFunctions;
        private int fieldIndex;
        private GridViewRow gridRow;

        public GridViewRow GridRow
        {
            get { return gridRow; }
            set { gridRow = value; }
        }
     
        public int FieldIndex
        {
            get { return fieldIndex; }
            set { fieldIndex = value; }
        }

        public string sJavaScript = string.Empty;

        private Control eventControl;
        public Control EventControl
        {
            get { return eventControl; }
            set { eventControl = value; }
        }

        private BusinessRules[] fillBusinessRules(DataTable dt, bool isFillValuesFromControls)
        {
            BusinessRules[] Result;
            Result = new BusinessRules[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand comDet;
                DataSet ds;
                DataTable dtDet;
                Result[i] = new BusinessRules();
                Result[i].NameRule = dt.Rows[i]["Nombre"].ToString().TrimEnd(' ');
                Result[i].AlcanceRule = (TTenumBusinessRules_Alcance)myFunctions.FormatNumberNull(dt.Rows[i]["Alcance"]).Value;

                comDet = new SqlCommand("spGetTTBusinessRulesExecution");
                comDet.Parameters.AddWithValue("@idBusinessRules", dt.Rows[i]["idBusinessRule"].ToString());
                comDet.CommandType = CommandType.StoredProcedure;
                ds = db.Consulta(comDet);

                //Operacion
                dtDet = ds.Tables[0];
                Result[i].OperacionRule = new TTenumBusinessRules_Operacion[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                    Result[i].OperacionRule[o] = (TTenumBusinessRules_Operacion)myFunctions.FormatNumberNull(dtDet.Rows[o]["idOperacion"]);

                //FieldEvent
                dtDet = ds.Tables[1];
                Result[i].FieldRule = new TTenumBusinessRules_FieldEvent[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                    Result[i].FieldRule[o] = (TTenumBusinessRules_FieldEvent)myFunctions.FormatNumberNull(dtDet.Rows[o]["idEvent"]);

                //ProcessEvent
                dtDet = ds.Tables[2];
                Result[i].ProcessRule = new TTenumBusinessRules_ProcessEvent[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                    Result[i].ProcessRule[o] = (TTenumBusinessRules_ProcessEvent)myFunctions.FormatNumberNull(dtDet.Rows[o]["idEvent"]);

                //Condiciones
                dtDet = ds.Tables[3];
                Result[i].Conditions = new BusinessRules_Coditions[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                {
                    Result[i].Conditions[o] = new BusinessRules_Coditions();
                    Result[i].Conditions[o].OperatorCondition = (TTenumBusinessRules_ConditionOperator)myFunctions.FormatNumberNull(dtDet.Rows[o]["CondicionOperador"]);
                    Result[i].Conditions[o].OperatorCondition1 = (TTenumBusinessRules_ConditionTypeOperator1)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Operador1"]);
                    Result[i].Conditions[o].OperatorConditionValue1 = dtDet.Rows[o]["Valor_Operador1"].ToString().Trim(' ');
                    Result[i].Conditions[o].ConditionCondition = (TTenumBusinessRules_ConditionCondition)myFunctions.FormatNumberNull(dtDet.Rows[o]["Condicion"]);
                    Result[i].Conditions[o].OperatorCondition2 = (TTenumBusinessRules_ConditionTypeOperator2)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Operador2"]);
                    Result[i].Conditions[o].OperatorConditionValue2 = dtDet.Rows[o]["Valor_Operador2"].ToString().Trim(' ');
                }

                //AccionesTrue
                dtDet = ds.Tables[4];
                DataView dvTrue = new DataView(ds.Tables[7]);
                Result[i].ActionsTrue = new BusinessRules_Actions[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                {
                    Result[i].ActionsTrue[o] = new BusinessRules_Actions();
                    Result[i].ActionsTrue[o].ActionType = (TTenumBusinessRules_ActionType)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion"]);
                    if (myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion_Resultado"]) != null)
                        Result[i].ActionsTrue[o].ActionResultType = (TTenumBusinessRules_ActionResultType)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion_Resultado"]);
                    else
                        Result[i].ActionsTrue[o].ActionResultType = TTenumBusinessRules_ActionResultType.None;

                    //Verificar que tipo de parametros lleva esa accion
                    dvTrue.RowFilter = "Tipo_Accion = " + dtDet.Rows[o]["Tipo_Accion"].ToString();
                    Result[i].ActionsTrue[o].Parameters = new BusinessRules_Actions_Parameters[int.Parse(dtDet.Rows[o]["Parametros"].ToString())];
                    for (int n = 0; n < int.Parse(dtDet.Rows[o]["Parametros"].ToString()); n++)
                    {
                        Result[i].ActionsTrue[o].Parameters[n] = new BusinessRules_Actions_Parameters();
                        Result[i].ActionsTrue[o].Parameters[n].ParameterType = (TTenumBusinessRules_ActionParameterType)myFunctions.FormatNumberNull(dvTrue.ToTable().Rows[n]["Tipo_Parametro"]);
                        Result[i].ActionsTrue[o].Parameters[n].ParameterValue = dtDet.Rows[o]["Parametro" + (n + 1).ToString().Trim(' ')].ToString().TrimEnd(' ');
                    }
                }
                dvTrue.Dispose();

                //AccionesFalse
                dtDet = ds.Tables[5];
                DataView dvFalse = new DataView(ds.Tables[8]);
                Result[i].ActionsFalse = new BusinessRules_Actions[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                {
                    Result[i].ActionsFalse[o] = new BusinessRules_Actions();
                    Result[i].ActionsFalse[o].ActionType = (TTenumBusinessRules_ActionType)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion"]);
                    if (myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion_Resultado"]) != null)
                        Result[i].ActionsFalse[o].ActionResultType = (TTenumBusinessRules_ActionResultType)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion_Resultado"]);
                    else
                        Result[i].ActionsFalse[o].ActionResultType = TTenumBusinessRules_ActionResultType.None;

                    //Verificar que tipo de parametros lleva esa accion
                    dvTrue.RowFilter = "Tipo_Accion = " + dtDet.Rows[o]["Tipo_Accion"].ToString();
                    Result[i].ActionsFalse[o].Parameters = new BusinessRules_Actions_Parameters[int.Parse(dtDet.Rows[o]["Parametros"].ToString())];
                    for (int n = 0; n < int.Parse(dtDet.Rows[o]["Parametros"].ToString()); n++)
                    {
                        Result[i].ActionsFalse[o].Parameters[n] = new BusinessRules_Actions_Parameters();
                        Result[i].ActionsFalse[o].Parameters[n].ParameterType = (TTenumBusinessRules_ActionParameterType)myFunctions.FormatNumberNull(dvFalse.ToTable().Rows[n]["Tipo_Parametro"]);
                        Result[i].ActionsFalse[o].Parameters[n].ParameterValue = dtDet.Rows[o]["Parametro" + (n + 1).ToString().Trim(' ')].ToString().TrimEnd(' ');
                    }
                }
                dvFalse.Dispose();
                comDet.Dispose();
                dtDet.Dispose();
                db.Dispose();
                ds.Dispose();
            }
            if (isFillValuesFromControls)
                FillValuesFromControls(ref Result);
            return Result;
        }

        public BusinessOperations()
        {
        }

        public BusinessOperations(TTBasePage.TTBasePage parameterPage, TTSecurity.GlobalData parameterUserData, int iProcess)
        {
            frmActive = parameterPage;
            myUserData = parameterUserData;
            giProcess = iProcess;
            myBusinessFunctions = new BusinessRulesFunctions(parameterPage, parameterUserData);
            GridRow = null;
        }

        private void FillValuesFromControls(ref BusinessRules[] Result)
        {
            foreach (BusinessRules objBus in Result)
            {
                //Reemplazamos valores a las condiciones
                foreach (BusinessRules_Coditions objCondi in objBus.Conditions)
                {
                    switch (objCondi.OperatorCondition1)
                    {
                        case TTenumBusinessRules_ConditionTypeOperator1.Field:
                            //objCondi.OperatorConditionValue1 = myBusinessFunctions.DecodingValueControlFromDTs(objCondi.OperatorConditionValue1);
                             BusinessControl brControl;
                            if (GridRow == null)
                            {
                                brControl = new BusinessControl(frmActive, objCondi.OperatorConditionValue1, this.FieldIndex);
                            }
                            else
                            {
                                brControl = new BusinessControl(frmActive, objCondi.OperatorConditionValue1, this.GridRow);
                            } 
                            objCondi.OperatorConditionValue1 = brControl.DecodingValueFromControl();
                            break;
                        case TTenumBusinessRules_ConditionTypeOperator1.Global:
                            objCondi.OperatorConditionValue1 = myBusinessFunctions.DecodingValueFromGlobalVariables(objCondi.OperatorConditionValue1);
                            break;
                        case TTenumBusinessRules_ConditionTypeOperator1.QuerySQL:
                            {
                                string QueryOriginal = objCondi.OperatorConditionValue1;
                                string text = objCondi.OperatorConditionValue1;
                                string textResult = string.Empty;

                                if ((text.ToLower().Contains("update") || text.ToLower().Contains("delete")) && !text.ToLower().Contains("where"))
                                    throw new Exception("Error: la operación Update o Delete no contiene la sentencia where");
                                text = myBusinessFunctions.DecodingValueFromCommandTexts(text);
                                try
                                {
                                    TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                                    SqlCommand com = new SqlCommand(text);
                                    com.CommandType = CommandType.Text;
                                    DataSet ds = db.Consulta(com);
                                    if (ds.Tables[0].Rows.Count > 0)
                                        textResult = db.Consulta(com).Tables[0].Rows[0][0].ToString();
                                    else
                                        textResult = string.Empty;
                                    objCondi.OperatorConditionValue1 = textResult;
                                }
                                catch (Exception ex)
                                {
                                    string Error = "Error al llenar un query en la Regla:" + objBus.NameRule + " \r\n \r\n Query Inicial:" + QueryOriginal + " \r\n \r\n Query después de cambiar FLD's :" + text + " \r\n \r\nError:" + ex.Message;
                                    throw new Exception(Error);
                                }
                            }
                            break;
                    }
                    switch (objCondi.OperatorCondition2)
                    {
                        case TTenumBusinessRules_ConditionTypeOperator2.Field:
                            //objCondi.OperatorConditionValue2 = myBusinessFunctions.DecodingValueControlFromDTs(objCondi.OperatorConditionValue2);
                            BusinessControl brControl = new BusinessControl(frmActive, objCondi.OperatorConditionValue2, this.FieldIndex);
                            objCondi.OperatorConditionValue2 = brControl.DecodingValueFromControl();
                            break;
                        case TTenumBusinessRules_ConditionTypeOperator2.Global:
                            objCondi.OperatorConditionValue2 = myBusinessFunctions.DecodingValueFromGlobalVariables(objCondi.OperatorConditionValue2);
                            break;
                        case TTenumBusinessRules_ConditionTypeOperator2.QuerySQL:
                            {
                                string QueryOriginal = objCondi.OperatorConditionValue2;
                                string text = objCondi.OperatorConditionValue2;
                                string textResult = string.Empty;

                                if ((text.ToLower().Contains("update") || text.ToLower().Contains("delete")) && !text.ToLower().Contains("where"))
                                    throw new Exception("Error: la operación Update o Delete no contiene la sentencia where");
                                text = myBusinessFunctions.DecodingValueFromCommandTexts(text);
                                try
                                {
                                    TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                                    SqlCommand com = new SqlCommand(text);
                                    com.CommandType = CommandType.Text;
                                    DataSet ds = db.Consulta(com);
                                    if (ds.Tables[0].Rows.Count > 0)
                                        textResult = db.Consulta(com).Tables[0].Rows[0][0].ToString();
                                    else
                                        textResult = string.Empty;
                                    objCondi.OperatorConditionValue2 = textResult;
                                }
                                catch (Exception ex)
                                {
                                    string Error = "Error al llenar un query en la Regla:" + objBus.NameRule + " \r\n \r\n Query Inicial:" + QueryOriginal + " \r\n \r\n Query después de cambiar FLD's :" + text + " \r\n \r\n Error:" + ex.Message;
                                    throw new Exception(Error);
                                }
                            }
                            break;
                        case TTenumBusinessRules_ConditionTypeOperator2.JavaScript:
                        case TTenumBusinessRules_ConditionTypeOperator2.Method:
                        case TTenumBusinessRules_ConditionTypeOperator2.Value:
                            break;
                    }
                }
                foreach (BusinessRules_Actions objAction in objBus.ActionsTrue)
                    foreach (BusinessRules_Actions_Parameters objPar in objAction.Parameters)
                    {
                        switch (objPar.ParameterType)
                        {
                            case TTenumBusinessRules_ActionParameterType.DatoID:
                            case TTenumBusinessRules_ActionParameterType.Carpeta:
                            case TTenumBusinessRules_ActionParameterType.Grupo:
                            case TTenumBusinessRules_ActionParameterType.SQLQuery:
                            case TTenumBusinessRules_ActionParameterType.SQLStore:
                            case TTenumBusinessRules_ActionParameterType.Texto:
                                objPar.ParameterValue = myBusinessFunctions.DecodingValueFromCommandTexts(objPar.ParameterValue);
                                break;
                            case TTenumBusinessRules_ActionParameterType.TextNoDecoding:
                                break;
                        }
                    }
                foreach (BusinessRules_Actions objAction in objBus.ActionsFalse)
                    foreach (BusinessRules_Actions_Parameters objPar in objAction.Parameters)
                    {
                        switch (objPar.ParameterType)
                        {
                            case TTenumBusinessRules_ActionParameterType.DatoID:
                            case TTenumBusinessRules_ActionParameterType.Carpeta:
                            case TTenumBusinessRules_ActionParameterType.Grupo:
                            case TTenumBusinessRules_ActionParameterType.SQLQuery:
                            case TTenumBusinessRules_ActionParameterType.SQLStore:
                            case TTenumBusinessRules_ActionParameterType.Texto:
                                objPar.ParameterValue = myBusinessFunctions.DecodingValueFromCommandTexts(objPar.ParameterValue);
                                break;
                            case TTenumBusinessRules_ActionParameterType.TextNoDecoding:
                                break;
                        }
                    }
            }
        }

        private void FillValuesFromControls(BusinessRules objBus)
        {
            //Reemplazamos valores a las condiciones
            foreach (BusinessRules_Coditions objCondi in objBus.Conditions)
            {
                switch (objCondi.OperatorCondition1)
                {
                    case TTenumBusinessRules_ConditionTypeOperator1.Field:
                        //objCondi.OperatorConditionValue1 = myBusinessFunctions.DecodingValueControlFromDTs(objCondi.OperatorConditionValue1);
                        //BusinessControl brControl = new BusinessControl(frmActive, objCondi.OperatorConditionValue1, this.FieldIndex);
                        BusinessControl brControl;
                        if (GridRow == null)
                        {
                            brControl = new BusinessControl(frmActive, objCondi.OperatorConditionValue1, this.FieldIndex);
                        }
                        else
                        {
                            brControl = new BusinessControl(frmActive, objCondi.OperatorConditionValue1, this.GridRow);
                        }
                        objCondi.OperatorConditionValue1 = brControl.DecodingValueFromControl();
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator1.Global:
                        objCondi.OperatorConditionValue1 = myBusinessFunctions.DecodingValueFromGlobalVariables(objCondi.OperatorConditionValue1);
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator1.QuerySQL:
                        {
                            string QueryOriginal=objCondi.OperatorConditionValue1;
                            objCondi.OperatorConditionValue1 = myBusinessFunctions.DecodingValueFromCommandTexts(objCondi.OperatorConditionValue1);
                            /*********************************** Si la condicion aun no ha sido evaluada******************************/
                            if (objCondi.OperatorConditionValue1.ToLower().Contains("select"))
                            {
                                TTDataLayerCS.BD datalayer = new TTDataLayerCS.BD();
                                DataSet ds = new DataSet();
                                try
                                {
                                    string sSQLQuery = objCondi.OperatorConditionValue1;
                                    ds = datalayer.Consulta(new SqlCommand(sSQLQuery));
                                    if (ds.Tables[0].Rows.Count > 0)
                                        objCondi.OperatorConditionValue1 = ds.Tables[0].Rows[0][0].ToString();
                                    else
                                        objCondi.OperatorConditionValue1 = string.Empty;
                                }
                                catch (Exception ex)
                                {
                                    string Error = "Error al llenar un query en la Regla:" + objBus.NameRule + "<br /><br />Query Inicial:" + QueryOriginal + "<br /><br />Query después de cambiar FLD's :" + objCondi.OperatorConditionValue1 + "<br /><br />Error:" + ex.Message;
                                    this.frmActive.ShowAlert(Error);
                                }
                            }
                            break;
                        }
                }
                switch (objCondi.OperatorCondition2)
                {
                    case TTenumBusinessRules_ConditionTypeOperator2.Field:
                        //objCondi.OperatorConditionValue2 = myBusinessFunctions.DecodingValueControlFromDTs(objCondi.OperatorConditionValue2);
                        BusinessControl brControl = new BusinessControl(frmActive, objCondi.OperatorConditionValue2, this.FieldIndex);
                        objCondi.OperatorConditionValue2 = brControl.DecodingValueFromControl();
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator2.Global:
                        objCondi.OperatorConditionValue2 = myBusinessFunctions.DecodingValueFromGlobalVariables(objCondi.OperatorConditionValue2);
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator2.JavaScript:
                    case TTenumBusinessRules_ConditionTypeOperator2.Method:
                    case TTenumBusinessRules_ConditionTypeOperator2.Value:
                        objCondi.OperatorConditionValue2 = myBusinessFunctions.DecodingValueFromCommandTexts(objCondi.OperatorConditionValue2);
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator2.QuerySQL:
                        {
                            /*********************************** Si la condicion aun no ha sido evaluada******************************/
                            string QueryOriginal=objCondi.OperatorConditionValue2;
                            objCondi.OperatorConditionValue2 = myBusinessFunctions.DecodingValueFromCommandTexts(objCondi.OperatorConditionValue2);
                            if (objCondi.OperatorConditionValue2.ToLower().Contains("select"))
                            {
                                TTDataLayerCS.BD datalayer = new TTDataLayerCS.BD();
                                DataSet ds = new DataSet();
                                try
                                {
                                    string sSQLQuery = objCondi.OperatorConditionValue2;
                                    ds = datalayer.Consulta(new SqlCommand(sSQLQuery));
                                    if (ds.Tables[0].Rows.Count > 0)
                                        objCondi.OperatorConditionValue2 = ds.Tables[0].Rows[0][0].ToString();
                                    else
                                        objCondi.OperatorConditionValue2 = string.Empty;
                                }
                                catch (Exception ex)
                                {
                                    string Error = "Error al llenar un query en la Regla:" + objBus.NameRule + "<br /><br />Query Inicial:" + QueryOriginal + "<br /><br />Query después de cambiar FLD's :" + objCondi.OperatorConditionValue2 + "<br /><br />Error:" + ex.Message;
                                    this.frmActive.ShowAlert(Error);
                                }
                            }
                            break;
                        }
                }
            }
            foreach (BusinessRules_Actions objAction in objBus.ActionsTrue)
                foreach (BusinessRules_Actions_Parameters objPar in objAction.Parameters)
                {
                    switch (objPar.ParameterType)
                    {
                        case TTenumBusinessRules_ActionParameterType.DatoID:
                        case TTenumBusinessRules_ActionParameterType.Carpeta:
                        case TTenumBusinessRules_ActionParameterType.Grupo:
                        case TTenumBusinessRules_ActionParameterType.SQLQuery:
                        case TTenumBusinessRules_ActionParameterType.SQLStore:
                        case TTenumBusinessRules_ActionParameterType.Texto:
                            /********* Si la accion no es mostrar mensaje, decodifica los controles para obtener los valores*****/
                            if (objAction.ActionType != TTenumBusinessRules_ActionType.ShowMsj)
                                objPar.ParameterValue = myBusinessFunctions.DecodingValueFromCommandTexts(objPar.ParameterValue);
                            break;
                        case TTenumBusinessRules_ActionParameterType.TextNoDecoding:
                            break;
                    }
                }
            foreach (BusinessRules_Actions objAction in objBus.ActionsFalse)
                foreach (BusinessRules_Actions_Parameters objPar in objAction.Parameters)
                {
                    switch (objPar.ParameterType)
                    {
                        case TTenumBusinessRules_ActionParameterType.DatoID:
                        case TTenumBusinessRules_ActionParameterType.Carpeta:
                        case TTenumBusinessRules_ActionParameterType.Grupo:
                        case TTenumBusinessRules_ActionParameterType.SQLQuery:
                        case TTenumBusinessRules_ActionParameterType.SQLStore:
                        case TTenumBusinessRules_ActionParameterType.Texto:
                            /********* Si la accion no es mostrar mensaje, decodifica los controles para obtener los valores*****/
                            if (objAction.ActionType != TTenumBusinessRules_ActionType.ShowMsj)
                                objPar.ParameterValue = myBusinessFunctions.DecodingValueFromCommandTexts(objPar.ParameterValue);
                            break;
                        case TTenumBusinessRules_ActionParameterType.TextNoDecoding:
                            break;
                    }
                }
        }

        private string DecodingValueFieldKey()
        {
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.FieldIdent(myMeta.GetAllDNTs(giProcess)[0].DNTID.Value);
            return myBusinessFunctions.DecodingValueControlFromDTs(myData.DNTID + "." + myData.DatoID);
        }

        private BusinessRules[] fillBusinessRules(int iProcess, TTenumBusinessRules_Alcance objAlcance, TTenumBusinessRules_FieldEvent objFieldEvent, bool isFillControlWithData)
        {
            ///Carga Las reglas de negocio que cumplan con el proceso 
            ///y el motodo de donde se mando llamar
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("spTTBusinessRules_FieldEvent");
            com.Parameters.AddWithValue("@idProcess", iProcess);
            com.Parameters.AddWithValue("@idAlcance", objAlcance.GetHashCode());
            com.Parameters.AddWithValue("@idEvent", objFieldEvent.GetHashCode());
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            return fillBusinessRules(dt, isFillControlWithData);
        }

        private BusinessRules[] fillBusinessRules(int iProcess, TTenumBusinessRules_Alcance objAlcance, TTenumBusinessRules_FieldEvent objFieldEvent, bool isFillControlWithData,bool OnlyFunctionInMultiRow)
        {
            ///Carga Las reglas de negocio que cumplan con el proceso 
            ///y el motodo de donde se mando llamar
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("spTTBusinessRules_FieldEvent");
            com.Parameters.AddWithValue("@idProcess", iProcess);
            com.Parameters.AddWithValue("@idAlcance", objAlcance.GetHashCode());
            com.Parameters.AddWithValue("@idEvent", objFieldEvent.GetHashCode());
            if (OnlyFunctionInMultiRow)
                com.Parameters.AddWithValue("@OnlyFunctionInMultiRow", true);
            
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            return fillBusinessRules(dt, isFillControlWithData);
        }

        private BusinessRules[] fillBusinessRules(int iProcess, TTenumBusinessRules_Operacion objOper, TTenumBusinessRules_ProcessEvent objProcessEvent)
        {
            ///Carga Las reglas de negocio que cumplan con el proceso 
            ///y el motodo de donde se mando llamar
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand("spTTBusinessRules_ProcessEvent");
            com.Parameters.AddWithValue("@idProcess", iProcess);
            com.Parameters.AddWithValue("@idAlcance", TTenumBusinessRules_Alcance.Process.GetHashCode());
            com.Parameters.AddWithValue("@idEvent", objProcessEvent.GetHashCode());
            com.Parameters.AddWithValue("@idOperacion", objOper.GetHashCode());
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = db.Consulta(com).Tables[0];
            return fillBusinessRules(dt, true);
        }

        private BusinessRules fillBusinessRule(int idBusinessRule, bool isFillValuesFromControls)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            BusinessRules Result;
            SqlCommand comDet;
            DataTable dtDet;
            DataSet ds;
            Result = new BusinessRules();

            //Get Business Rule.
            comDet = new SqlCommand("spGetTTBusinessRulesExecution");
            comDet.Parameters.AddWithValue("@idBusinessrules", idBusinessRule);
            comDet.CommandType = CommandType.StoredProcedure;
            ds = db.Consulta(comDet);

                dtDet=ds.Tables[6];
                Result = new BusinessRules();
                Result.NameRule = dtDet.Rows[0]["Nombre"].ToString().TrimEnd(' ');
                Result.AlcanceRule = (TTenumBusinessRules_Alcance)myFunctions.FormatNumberNull(dtDet.Rows[0]["Alcance"]).Value;

                //Operacion
                dtDet = ds.Tables[0];
                Result.OperacionRule = new TTenumBusinessRules_Operacion[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                    Result.OperacionRule[o] = (TTenumBusinessRules_Operacion)myFunctions.FormatNumberNull(dtDet.Rows[o]["idOperacion"]);

                //FieldEvent
                dtDet = ds.Tables[1];
                Result.FieldRule = new TTenumBusinessRules_FieldEvent[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                    Result.FieldRule[o] = (TTenumBusinessRules_FieldEvent)myFunctions.FormatNumberNull(dtDet.Rows[o]["idEvent"]);

                //ProcessEvent
                dtDet = ds.Tables[2];
                Result.ProcessRule = new TTenumBusinessRules_ProcessEvent[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                    Result.ProcessRule[o] = (TTenumBusinessRules_ProcessEvent)myFunctions.FormatNumberNull(dtDet.Rows[o]["idEvent"]);

                //Condiciones
                dtDet = ds.Tables[3];
                Result.Conditions = new BusinessRules_Coditions[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                {
                    Result.Conditions[o] = new BusinessRules_Coditions();
                    Result.Conditions[o].OperatorCondition = (TTenumBusinessRules_ConditionOperator)myFunctions.FormatNumberNull(dtDet.Rows[o]["CondicionOperador"]);
                    Result.Conditions[o].OperatorCondition1 = (TTenumBusinessRules_ConditionTypeOperator1)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Operador1"]);
                    Result.Conditions[o].OperatorConditionValue1 = dtDet.Rows[o]["Valor_Operador1"].ToString().Trim(' ');
                    Result.Conditions[o].ConditionCondition = (TTenumBusinessRules_ConditionCondition)myFunctions.FormatNumberNull(dtDet.Rows[o]["Condicion"]);
                    Result.Conditions[o].OperatorCondition2 = (TTenumBusinessRules_ConditionTypeOperator2)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Operador2"]);
                    Result.Conditions[o].OperatorConditionValue2 = dtDet.Rows[o]["Valor_Operador2"].ToString().Trim(' ');
                }
                //AccionesTrue
                dtDet = ds.Tables[4];
                DataView dvTrue = new DataView(ds.Tables[7]);
                Result.ActionsTrue = new BusinessRules_Actions[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                {
                    Result.ActionsTrue[o] = new BusinessRules_Actions();
                    Result.ActionsTrue[o].ActionType = (TTenumBusinessRules_ActionType)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion"]);
                    if (myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion_Resultado"]) != null)
                        Result.ActionsTrue[o].ActionResultType = (TTenumBusinessRules_ActionResultType)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion_Resultado"]);
                    else
                        Result.ActionsTrue[o].ActionResultType = TTenumBusinessRules_ActionResultType.None;

                    //Verificar que tipo de parametros lleva esa accion
                    dvTrue.RowFilter = "Tipo_Accion = " + dtDet.Rows[o]["Tipo_Accion"].ToString();
                    Result.ActionsTrue[o].Parameters = new BusinessRules_Actions_Parameters[int.Parse(dtDet.Rows[o]["Parametros"].ToString())];
                    for (int n = 0; n < int.Parse(dtDet.Rows[o]["Parametros"].ToString()); n++)
                    {
                        Result.ActionsTrue[o].Parameters[n] = new BusinessRules_Actions_Parameters();
                        Result.ActionsTrue[o].Parameters[n].ParameterType = (TTenumBusinessRules_ActionParameterType)myFunctions.FormatNumberNull(dvTrue.ToTable().Rows[n]["Tipo_Parametro"]);
                        Result.ActionsTrue[o].Parameters[n].ParameterValue = dtDet.Rows[o]["Parametro" + (n + 1).ToString().Trim(' ')].ToString().TrimEnd(' ');
                    }
                }
                dvTrue.Dispose();

                //AccionesFalse
                DataView dvFalse = new DataView(ds.Tables[8]);
                dtDet = ds.Tables[5];
                Result.ActionsFalse = new BusinessRules_Actions[dtDet.Rows.Count];
                for (int o = 0; o < dtDet.Rows.Count; o++)
                {
                    Result.ActionsFalse[o] = new BusinessRules_Actions();
                    Result.ActionsFalse[o].ActionType = (TTenumBusinessRules_ActionType)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion"]);
                    if (myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion_Resultado"]) != null)
                        Result.ActionsFalse[o].ActionResultType = (TTenumBusinessRules_ActionResultType)myFunctions.FormatNumberNull(dtDet.Rows[o]["Tipo_Accion_Resultado"]);
                    else
                        Result.ActionsFalse[o].ActionResultType = TTenumBusinessRules_ActionResultType.None;

                    //Verificar que tipo de parametros lleva esa accion
                    dvFalse.RowFilter = "Tipo_Accion = " + dtDet.Rows[o]["Tipo_Accion"].ToString();
                    Result.ActionsFalse[o].Parameters = new BusinessRules_Actions_Parameters[int.Parse(dtDet.Rows[o]["Parametros"].ToString())];
                    for (int n = 0; n < int.Parse(dtDet.Rows[o]["Parametros"].ToString()); n++)
                    {
                        Result.ActionsFalse[o].Parameters[n] = new BusinessRules_Actions_Parameters();
                        Result.ActionsFalse[o].Parameters[n].ParameterType = (TTenumBusinessRules_ActionParameterType)myFunctions.FormatNumberNull(dvFalse.ToTable().Rows[n]["Tipo_Parametro"]);
                        Result.ActionsFalse[o].Parameters[n].ParameterValue = dtDet.Rows[o]["Parametro" + (n + 1).ToString().Trim(' ')].ToString().TrimEnd(' ');
                    }
                }
                dvFalse.Dispose();
                db.Dispose();
                comDet.Dispose();
                dtDet.Dispose();
                ds.Dispose();

            if (isFillValuesFromControls)
                FillValuesFromControls(Result);
            return Result;
        }
        //public TTenumBusinessRules_ActionResultType[] Comparation(TTSecurity.GlobalData myUserData, int iProcess, TTenumBusinessRules_Alcance objAlcance, TTenumBusinessRules_FieldEvent objFieldEvent)
        public void Comparation(TTSecurity.GlobalData myUserData, int iProcess, TTenumBusinessRules_Alcance objAlcance, TTenumBusinessRules_FieldEvent objFieldEvent)
        {

            ///Realiza toda la operacion de una regla de negocio
            ///Mandada llamar desde el evento de un control
            this.giProcess = iProcess;
            myBusinessFunctions = new BusinessRulesFunctions(frmActive, myUserData);

            ArrayList arr = new ArrayList();
            BusinessRules[] objBusiness = fillBusinessRules(iProcess, objAlcance, objFieldEvent, false);
            //List<Control> fieldsInConditions = new List<Control>();
            List<ControlBusiness> fieldsInConditions = new List<ControlBusiness>();
            foreach (BusinessRules objBus in objBusiness)
                ControlsInConditions(ref fieldsInConditions, objBus);

            foreach (ControlBusiness fieldControl in fieldsInConditions)
            {
                if (fieldControl.Field.PageControl.GetType() == typeof(DropDownList))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as DropDownList).SelectedIndexChanged +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                                return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as DropDownList).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(TextBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as TextBox).TextChanged +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as TextBox).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(ListBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as ListBox).SelectedIndexChanged +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as ListBox).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(CheckBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as CheckBox).CheckedChanged +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as CheckBox).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(Button))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as Button).Click +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(LinkButton))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as LinkButton).Click +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadTimePicker))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadTimePicker).SelectedDateChanged +=
                        delegate(object sender, SelectedDateChangedEventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as RadTimePicker).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadComboBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadComboBox).SelectedIndexChanged +=
                        delegate(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                   (fieldControl.Field.PageControl as RadComboBox).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadDatePicker))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadDatePicker).SelectedDateChanged +=
                        delegate(object sender, SelectedDateChangedEventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as RadDatePicker).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadDateTimePicker))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadDateTimePicker).SelectedDateChanged +=
                        delegate(object sender, SelectedDateChangedEventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as RadDateTimePicker).AutoPostBack = true;
                    (fieldControl.Field.PageControl as RadDateTimePicker).AutoPostBackControl = AutoPostBackControl.Both;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadNumericTextBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    BusinessRules controlBusinesRulesBackUp = (BusinessRules)controlBusinesRules.DeepCopy();
                    (fieldControl.Field.PageControl as RadNumericTextBox).TextChanged +=
                        delegate(object sender, EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                controlBusinesRules = controlBusinesRulesBackUp;
                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as RadNumericTextBox).AutoPostBack = true;
                }
               else if (fieldControl.Field.PageControl.GetType() == typeof(CascadingDropDown))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    CascadingDropDown controlCDD = (CascadingDropDown)fieldControl.Field.PageControl;
                    DropDownList targetId = (DropDownList)controlCDD.Parent.FindControl(controlCDD.TargetControlID);
                    targetId.SelectedIndexChanged +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                                return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    targetId.AutoPostBack = true;
                }
            }


            //TTenumBusinessRules_ActionResultType[] Result = new TTenumBusinessRules_ActionResultType[arr.Count];
            //for (int i = 0; i < arr.Count; i++)
            //    Result[i] = (TTenumBusinessRules_ActionResultType)arr[i];
            //return Result;
        }

        public void Comparation(TTSecurity.GlobalData myUserData, int iProcess, TTenumBusinessRules_Alcance objAlcance, TTenumBusinessRules_FieldEvent objFieldEvent,bool OnlyFunctionInMultiRow)
        {

            ///Realiza toda la operacion de una regla de negocio
            ///Mandada llamar desde el evento de un control
            this.giProcess = iProcess;
            myBusinessFunctions = new BusinessRulesFunctions(frmActive, myUserData);
            BusinessRules[] objBusiness;
            ArrayList arr = new ArrayList();
            if (OnlyFunctionInMultiRow)
                objBusiness = fillBusinessRules(iProcess, objAlcance, objFieldEvent, false,true);
            else
                objBusiness = fillBusinessRules(iProcess, objAlcance, objFieldEvent, false);
            //List<Control> fieldsInConditions = new List<Control>();
            List<ControlBusiness> fieldsInConditions = new List<ControlBusiness>();
            foreach (BusinessRules objBus in objBusiness)
                ControlsInConditions(ref fieldsInConditions, objBus);

            foreach (ControlBusiness fieldControl in fieldsInConditions)
            {
                if (fieldControl.Field.PageControl.GetType() == typeof(DropDownList))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    if (OnlyFunctionInMultiRow)
                    {
                        FillValuesFromControls(controlBusinesRules);
                        try
                        {
                            if (ValidateBusiness(controlBusinesRules.Conditions))
                                arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                            else
                                arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                            if (arr != null)
                                foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                    if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                        return;
                            return;
                        }
                        catch (Exception ex)
                        {
                            frmActive.ShowAlert(ex.Message);
                        }
                    }
                    else
                    {
                        (fieldControl.Field.PageControl as DropDownList).SelectedIndexChanged +=
                            delegate(object sender, System.EventArgs e)
                            {
                                FillValuesFromControls(controlBusinesRules);
                                frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                                try
                                {
                                    if (ValidateBusiness(controlBusinesRules.Conditions))
                                        arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                    else
                                        arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                    if (arr != null)
                                        foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                            if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                                return;
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    frmActive.ShowAlert(ex.Message);
                                }
                            };
                        (fieldControl.Field.PageControl as DropDownList).AutoPostBack = true;
                    }
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(TextBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as TextBox).TextChanged +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as TextBox).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(ListBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as ListBox).SelectedIndexChanged +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as ListBox).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(CheckBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as CheckBox).CheckedChanged +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as CheckBox).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(Button))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as Button).Click +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(LinkButton))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as LinkButton).Click +=
                        delegate(object sender, System.EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadTimePicker))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadTimePicker).SelectedDateChanged +=
                        delegate(object sender, SelectedDateChangedEventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                   (fieldControl.Field.PageControl as RadTimePicker).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadComboBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadComboBox).SelectedIndexChanged +=
                        delegate(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
					(fieldControl.Field.PageControl as RadComboBox).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadDatePicker))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadDatePicker).SelectedDateChanged +=
                        delegate(object sender, SelectedDateChangedEventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as RadDatePicker).AutoPostBack = true;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadDateTimePicker))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadDateTimePicker).SelectedDateChanged +=
                        delegate(object sender, SelectedDateChangedEventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as RadDateTimePicker).AutoPostBack = true;
                    (fieldControl.Field.PageControl as RadDateTimePicker).AutoPostBackControl = AutoPostBackControl.Both;
                }
                else if (fieldControl.Field.PageControl.GetType() == typeof(RadNumericTextBox))
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    (fieldControl.Field.PageControl as RadNumericTextBox).TextChanged +=
                        delegate(object sender, EventArgs e)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            frmActive = ((sender as Control).Page as TTBasePage.TTBasePage);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        };
                    (fieldControl.Field.PageControl as RadNumericTextBox).AutoPostBack = true;
                }
            }


            //TTenumBusinessRules_ActionResultType[] Result = new TTenumBusinessRules_ActionResultType[arr.Count];
            //for (int i = 0; i < arr.Count; i++)
            //    Result[i] = (TTenumBusinessRules_ActionResultType)arr[i];
            //return Result;
        }

        public TTenumBusinessRules_ActionResultType[] Comparation(TTSecurity.GlobalData myUserData, int iProcess, TTenumBusinessRules_Operacion objOper, TTenumBusinessRules_ProcessEvent objProcessEvent)
        {
            ///Realiza toda la operacion de una regla de negocio
            ///Mandada llamar desde el evento de un proceso
            //this.frmActive = FrmActive;
            this.giProcess = iProcess;
            //Object theObj = new Object(); //frmActive.Tag;
            //MethodInfo MethodVari = theObj.GetType().GetMethod("get_GlobalInformation");
            //myUserData = (TTSecurity.GlobalData)MethodVari.Invoke(theObj, null);
            myBusinessFunctions = new BusinessRulesFunctions(frmActive, myUserData);

            ArrayList arr = new ArrayList();
            BusinessRules[] objBusiness = fillBusinessRules(iProcess, objOper, objProcessEvent);
            foreach (BusinessRules objBus in objBusiness)
            {
                if (ValidateBusiness(objBus.Conditions))
                    arr.AddRange(DoAction(objBus.ActionsTrue, objBus));
                else
                    arr.AddRange(DoAction(objBus.ActionsFalse, objBus));
            }
            TTenumBusinessRules_ActionResultType[] Result = new TTenumBusinessRules_ActionResultType[arr.Count];
            for (int i = 0; i < arr.Count; i++)
                Result[i] = (TTenumBusinessRules_ActionResultType)arr[i];
            return Result;
        }

        public string ComparationMulti(TTSecurity.GlobalData myUserData, int iProcess, TTenumBusinessRules_Alcance objAlcance, TTenumBusinessRules_FieldEvent objFieldEvent, Control eventControl)
        {
            ///Realiza toda la operacion de una regla de negocio
            ///Mandada llamar desde el evento de un control

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[GetDatosAgregarMultirenglonPopup]";
            com.Parameters.AddWithValue("@IdProceso", iProcess);
            DataSet ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count != 0)
            {
                return "";
            }

            this.giProcess = iProcess;
            myBusinessFunctions = new BusinessRulesFunctions(frmActive, myUserData);
            myBusinessFunctions.FieldIndex = this.fieldIndex;
            this.eventControl = eventControl;
            ArrayList arr = new ArrayList();
            BusinessRules[] objBusiness = fillBusinessRules(iProcess, objAlcance, objFieldEvent, false);

            foreach (BusinessRules objBus in objBusiness)
            {
                List<ControlBusiness> fieldsInConditions = new List<ControlBusiness>();


                ControlsInConditions(ref fieldsInConditions, objBus);

                if (fieldsInConditions.Count > 0)
                {
                    foreach (ControlBusiness fieldControl in fieldsInConditions)
                    {
                        BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                        if (fieldControl.Field.PageControl == eventControl)
                        {
                            FillValuesFromControls(controlBusinesRules);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return sJavaScript;
                                //return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        }
                        //return;
                    }
                }
                else
                {
                    //foreach (BusinessRules objBus in objBusiness)
                    //{
                        if (ValidateBusiness(objBus.Conditions))
                            arr.AddRange(DoAction(objBus.ActionsTrue, objBus));
                        else
                            arr.AddRange(DoAction(objBus.ActionsFalse, objBus));
                    //}
                }
            }
            return sJavaScript;
        } 

        public string ComparationMultiANTERIOR(TTSecurity.GlobalData myUserData, int iProcess, TTenumBusinessRules_Alcance objAlcance, TTenumBusinessRules_FieldEvent objFieldEvent, Control eventControl)
        {
            ///Realiza toda la operacion de una regla de negocio
            ///Mandada llamar desde el evento de un control

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[GetDatosAgregarMultirenglonPopup]";
            com.Parameters.AddWithValue("@IdProceso", iProcess);
            DataSet ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count != 0)
            {
                return "";
            }

            this.giProcess = iProcess;
            myBusinessFunctions = new BusinessRulesFunctions(frmActive, myUserData);
            myBusinessFunctions.FieldIndex = this.fieldIndex;
            this.eventControl = eventControl;
            ArrayList arr = new ArrayList();
            BusinessRules[] objBusiness = fillBusinessRules(iProcess, objAlcance, objFieldEvent, false);
            List<ControlBusiness> fieldsInConditions = new List<ControlBusiness>();
            foreach (BusinessRules objBus in objBusiness)
                ControlsInConditions(ref fieldsInConditions, objBus);

            if (fieldsInConditions.Count > 0)
            {
                foreach (ControlBusiness fieldControl in fieldsInConditions)
                {
                    BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    if (fieldControl.Field.PageControl == eventControl)
                    {
                        FillValuesFromControls(controlBusinesRules);
                        try
                        {
                            if (ValidateBusiness(controlBusinesRules.Conditions))
                                arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                            else
                                arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                            if (arr != null)
                                foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                    if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                        return sJavaScript;
                            //return;
                        }
                        catch (Exception ex)
                        {
                            frmActive.ShowAlert(ex.Message);
                        }
                    }
                    //return;
                }
            }
            else
            {
                foreach (BusinessRules objBus in objBusiness)
                {
                    if (ValidateBusiness(objBus.Conditions))
                        arr.AddRange(DoAction(objBus.ActionsTrue, objBus));
                    else
                        arr.AddRange(DoAction(objBus.ActionsFalse, objBus));
                }
            }
		return sJavaScript;
        }

        public string ComparationMulti(TTSecurity.GlobalData myUserData, int iProcess, TTenumBusinessRules_Operacion objOperation, TTenumBusinessRules_ProcessEvent objProcessEvent)
        {
            ///Realiza toda la operacion de una regla de negocio
            ///Mandada llamar desde el evento de un control

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[GetDatosAgregarMultirenglonPopup]";
            com.Parameters.AddWithValue("@IdProceso", iProcess);
            DataSet ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count != 0)
            {
                return "";
            }

            this.giProcess = iProcess;
            myBusinessFunctions = new BusinessRulesFunctions(frmActive, myUserData);
            myBusinessFunctions.GridRow = this.GridRow;
            //this.eventControl = eventControl;
            ArrayList arr = new ArrayList();
            BusinessRules[] objBusiness = fillBusinessRules(iProcess, objOperation, objProcessEvent);
            //List<ControlBusiness> fieldsInConditions = new List<ControlBusiness>();
            //foreach (BusinessRules objBus in objBusiness)
            //    ControlsInConditions(ref fieldsInConditions, objBus);

            //if (fieldsInConditions.Count > 0)
            //{
            //    foreach (ControlBusiness fieldControl in fieldsInConditions)
            //    {
            //        BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                    //if (fieldControl.Field.PageControl == eventControl)
                    //{
            //            FillValuesFromControls(controlBusinesRules);
            //            try
            //            {
            //                if (ValidateBusiness(controlBusinesRules.Conditions))
            //                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
            //                else
            //                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

            //                if (arr != null)
            //                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
            //                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
            //                            return sJavaScript;
            //                return sJavaScript;
            //            }
            //            catch (Exception ex)
            //            {
            //                frmActive.ShowAlert("ComparationMulti: " + ex.Message);
            //            }
            //        //}
            //        //return;
            //    }
            //}
            //else
            //{
                foreach (BusinessRules objBus in objBusiness)
                {
                    if (ValidateBusiness(objBus.Conditions))
                        arr.AddRange(DoAction(objBus.ActionsTrue, objBus));
                    else
                        arr.AddRange(DoAction(objBus.ActionsFalse, objBus));
                }
            //}
		return sJavaScript;
        }

        public string ComparationMultiAutoComplete(TTSecurity.GlobalData myUserData, int iProcess, TTenumBusinessRules_Alcance objAlcance, TTenumBusinessRules_FieldEvent objFieldEvent, Control eventControl)
        {
            ///Realiza toda la operacion de una regla de negocio
            ///Mandada llamar desde el evento de un control

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[dbo].[GetDatosAgregarMultirenglonPopup]";
            com.Parameters.AddWithValue("@IdProceso", iProcess);
            DataSet ds = db.Consulta(com);
            if (ds.Tables[0].Rows.Count != 0)
            {
                return "";
            }

            this.giProcess = iProcess;
            myBusinessFunctions = new BusinessRulesFunctions(frmActive, myUserData);
            myBusinessFunctions.FieldIndex = this.fieldIndex;
            this.eventControl = eventControl;
            ArrayList arr = new ArrayList();
            BusinessRules[] objBusiness = fillBusinessRules(iProcess, objAlcance, objFieldEvent, false);

            foreach (BusinessRules objBus in objBusiness)
            {
                List<ControlBusiness> fieldsInConditions = new List<ControlBusiness>();

                ControlsInConditions(ref fieldsInConditions, objBus);

                if (fieldsInConditions.Count > 0)
                {
                    foreach (ControlBusiness fieldControl in fieldsInConditions)
                    {
                        BusinessRules controlBusinesRules = fieldControl.BusinessRule;
                        //if (fieldControl.Field.PageControl == eventControl)
                        //{
                            FillValuesFromControls(controlBusinesRules);
                            try
                            {
                                if (ValidateBusiness(controlBusinesRules.Conditions))
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsTrue, controlBusinesRules));
                                else
                                    arr.AddRange(DoAction(controlBusinesRules.ActionsFalse, controlBusinesRules));

                                if (arr != null)
                                    foreach (TTenumBusinessRules_ActionResultType myRes in arr)
                                        if (myRes == TTenumBusinessRules_ActionResultType.Break)
                                            return sJavaScript;
                                //return;
                            }
                            catch (Exception ex)
                            {
                                frmActive.ShowAlert(ex.Message);
                            }
                        //}
                        //return;
                    }
                }
                else
                {
                    //foreach (BusinessRules objBus in objBusiness)
                    //{
                    if (ValidateBusiness(objBus.Conditions))
                        arr.AddRange(DoAction(objBus.ActionsTrue, objBus));
                    else
                        arr.AddRange(DoAction(objBus.ActionsFalse, objBus));
                    //}
                }
            }
            return sJavaScript;
        } 

        public bool ComparationIndividual(TTSecurity.GlobalData myUserData, int idBusinessRule)
        {
            try
            {
                ///Realiza toda la operacion de una regla de negocio
                ///Mandada llamar desde el evento de un proceso
                //this.frmActive = FrmActive;
                //this.giProcess = iProcess;
                //Object theObj = new Object(); //frmActive.Tag;
                //MethodInfo MethodVari = theObj.GetType().GetMethod("get_GlobalInformation");
                //myUserData = (TTSecurity.GlobalData)MethodVari.Invoke(theObj, null);
                myBusinessFunctions = new BusinessRulesFunctions(frmActive, myUserData);

                ArrayList arr = new ArrayList();
                BusinessRules objBusiness = fillBusinessRule(idBusinessRule, true);
                //foreach (BusinessRules objBus in objBusiness)
                {
                    if (ValidateBusiness(objBusiness.Conditions))
                        arr.AddRange(DoAction(objBusiness.ActionsTrue, objBusiness));
                    else
                        arr.AddRange(DoAction(objBusiness.ActionsFalse, objBusiness));
                }

                return true;
            }
            catch
            {
                return false;
            }
            //TTenumBusinessRules_ActionResultType[] Result = new TTenumBusinessRules_ActionResultType[arr.Count];
            //for (int i = 0; i < arr.Count; i++)
            //    Result[i] = (TTenumBusinessRules_ActionResultType)arr[i];
            //return Result;
        }

        public bool ExistsControlInCondition(List<ControlBusiness> controlBusiness, Control ctrl)
        {
            bool returnValue = false;

            foreach (ControlBusiness ctrlBusiness in controlBusiness)
                if (ctrlBusiness.Field.PageControl == ctrl)
                    return true;

            return returnValue;
        }

        public bool ExistsControlInCondition(List<ControlBusiness> controlBusiness, Control ctrl, BusinessRules businessRule)
        {
            bool returnValue = false;

            returnValue = controlBusiness.Exists(p => p.BusinessRule == businessRule && p.Field.PageControl == ctrl);

            return returnValue;
        }

        public void ControlsInConditions(ref List<ControlBusiness> result, BusinessRules objBusiness)
        {
            foreach (BusinessRules_Coditions objBus in objBusiness.Conditions)
            {
                switch (objBus.OperatorCondition1)
                {
                    case TTenumBusinessRules_ConditionTypeOperator1.Field:
                        if (objBus.OperatorConditionValue1 != string.Empty)
                        {
                            ControlBusiness ctrlBus = new ControlBusiness();
                            BusinessControl ctrl = new BusinessControl(frmActive, objBus.OperatorConditionValue1, this.FieldIndex);
                            ctrlBus.BusinessRule = objBusiness;
                            ctrlBus.Field = ctrl;
                            if (!ExistsControlInCondition(result, ctrl.PageControl, objBusiness))
                                result.Add(ctrlBus);
                        }
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator1.Global:
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator1.QuerySQL:
                        if (objBus.OperatorConditionValue1 != string.Empty)
                        {
                            /******************** Verifica si en la consulta existe algun campo*******************************/
                            List<Control> controlList = myBusinessFunctions.GetControlsFromFLDs(objBus.OperatorConditionValue1);
                            /******************** Si existe, agrega el control a las condiciones ****************************/
                            if (controlList.Count > 0)
                            {
                                foreach (Control control in controlList)
                                {
                                    ControlBusiness ctrlBus = new ControlBusiness();
                                    ctrlBus.BusinessRule = objBusiness;
                                    ctrlBus.Field = new BusinessControl(control);
                                    ctrlBus.Field.FieldIndex = this.FieldIndex;
                                    if (!ExistsControlInCondition(result, control, objBusiness))
                                        result.Add(ctrlBus);
                                }
                            }
                            /******************** Si no, obtiene el valor de la consulta ***********************************/
                            else if (controlList.Count == 0)
                            {
                                TTDataLayerCS.BD datalayer = new TTDataLayerCS.BD();
                                DataSet ds = new DataSet();
                                try
                                {
                                    string sSQLQuery = objBus.OperatorConditionValue1;
                                    ds = datalayer.Consulta(new SqlCommand(sSQLQuery));
                                    objBus.OperatorConditionValue1 = ds.Tables[0].Rows[0][0].ToString();
                                }
                                catch
                                { }
                            }
                        }
                        break;
                }
                switch (objBus.OperatorCondition2)
                {
                    case TTenumBusinessRules_ConditionTypeOperator2.Field:
                        if (objBus.OperatorConditionValue2 != string.Empty)
                        {
                            ControlBusiness ctrlBus = new ControlBusiness();
                            BusinessControl ctrl = new BusinessControl(frmActive, objBus.OperatorConditionValue2, this.FieldIndex);
                            ctrlBus.BusinessRule = objBusiness;
                            ctrlBus.Field = ctrl;
                            if (!ExistsControlInCondition(result, ctrl.PageControl, objBusiness))
                                result.Add(ctrlBus);
                        }
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator2.Global:
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator2.JavaScript:
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator2.Method:
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator2.QuerySQL:
                        if (objBus.OperatorConditionValue2 != string.Empty)
                        {
                            /******************** Verifica si en la consulta existe algun campo*******************************/
                            List<Control> controlList = myBusinessFunctions.GetControlsFromFLDs(objBus.OperatorConditionValue2);
                            /******************** Si existe, agrega el control a las condiciones ****************************/
                            if (controlList.Count > 0)
                            {
                                foreach (Control control in controlList)
                                {
                                    ControlBusiness ctrlBus = new ControlBusiness();
                                    ctrlBus.BusinessRule = objBusiness;
                                    ctrlBus.Field = new BusinessControl(control);
                                    ctrlBus.Field.FieldIndex = this.FieldIndex;
                                    if (!ExistsControlInCondition(result, control, objBusiness))
                                        result.Add(ctrlBus);
                                }
                            }
                            /******************** Si no, obtiene el valor de la consulta ***********************************/
                            else if (controlList.Count == 0)
                            {
                                TTDataLayerCS.BD datalayer = new TTDataLayerCS.BD();
                                DataSet ds = new DataSet();
                                try
                                {
                                    string sSQLQuery = objBus.OperatorConditionValue2;
                                    ds = datalayer.Consulta(new SqlCommand(sSQLQuery));
                                    objBus.OperatorConditionValue2 = ds.Tables[0].Rows[0][0].ToString();
                                }
                                catch
                                {
                                }
                            }
                        }
                        break;
                    case TTenumBusinessRules_ConditionTypeOperator2.Value:
                        break;
                }
            }
        }

        private Boolean ValidateBusiness(BusinessRules_Coditions[] objBusinessConditions)
        {
            ///Valida la regla de negocio y regresa si se cumplio o no
            Boolean Result = true, previousResult = true;
            foreach (BusinessRules_Coditions objBus in objBusinessConditions)
            {
                switch (objBus.ConditionCondition)
                {
                    case TTenumBusinessRules_ConditionCondition.Igual:
                        {
                            Boolean Cumplio1 = false;
                            int xStart1 = 0;
                            int xStart2 = 0;
                            if (objBus.OperatorConditionValue1.IndexOf("[;SEP]", xStart1) > -1)
                            {
                                //Condicion 1
                                while (objBus.OperatorConditionValue1.IndexOf("[;SEP]", xStart1) > -1)
                                {
                                    String Con1 = objBus.OperatorConditionValue1.Substring(xStart1, objBus.OperatorConditionValue1.IndexOf("[;SEP]", xStart1) - xStart1);
                                    xStart1 = objBus.OperatorConditionValue1.IndexOf("[;SEP]", xStart1) + 6;
                                    xStart2 = 0;
                                    if (objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) > -1)
                                    {
                                        while (objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) > -1)
                                        {
                                            String Con2 = objBus.OperatorConditionValue2.Substring(xStart2, objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) - xStart2);
                                            xStart2 = objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) + 6;
                                            if (Con1 == Con2)
                                                Cumplio1 = true;
                                        }
                                    }
                                    else
                                    {
                                        if (Con1 == objBus.OperatorConditionValue2.TrimEnd(' '))
                                            Cumplio1 = true;
                                    }
                                }
                            }
                            else
                            {
                                if (objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) > -1)
                                {
                                    while (objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) > -1)
                                    {
                                        String Con2 = objBus.OperatorConditionValue2.Substring(xStart2, objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) - xStart2);
                                        xStart2 = objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) + 6;
                                        if (objBus.OperatorConditionValue1.TrimEnd(' ') == Con2)
                                            Cumplio1 = true;
                                    }
                                }
                                else
                                {
                                    if (objBus.OperatorConditionValue1.TrimEnd(' ').ToLower() == objBus.OperatorConditionValue2.TrimEnd(' ').ToLower())
                                        Cumplio1 = true;
                                }
                            }
                            //if (!Cumplio1)
                            //    Result = false;
                            Result = Cumplio1;
                            break;
                        }
                    case TTenumBusinessRules_ConditionCondition.Diferente:
                        {
                            Boolean Cumplio1 = true;
                            int xStart1 = 0;
                            int xStart2 = 0;
                            if (objBus.OperatorConditionValue1.IndexOf("[;SEP]", xStart1) > -1)
                            {
                                //Condicion 1
                                while (objBus.OperatorConditionValue1.IndexOf("[;SEP]", xStart1) > -1)
                                {
                                    String Con1 = objBus.OperatorConditionValue1.Substring(xStart1, objBus.OperatorConditionValue1.IndexOf("[;SEP]", xStart1) - xStart1);
                                    xStart1 = objBus.OperatorConditionValue1.IndexOf("[;SEP]", xStart1) + 6;
                                    xStart2 = 0;
                                    if (objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) > -1)
                                    {
                                        while (objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) > -1)
                                        {
                                            String Con2 = objBus.OperatorConditionValue2.Substring(xStart2, objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) - xStart2);
                                            xStart2 = objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) + 6;
                                            if (Con1 == Con2)
                                                Cumplio1 = false;
                                        }
                                    }
                                    else
                                    {
                                        if (Con1 == objBus.OperatorConditionValue2.TrimEnd(' '))
                                            Cumplio1 = false;
                                    }
                                }
                            }
                            else
                            {
                                if (objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) > -1)
                                {
                                    while (objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) > -1)
                                    {
                                        String Con2 = objBus.OperatorConditionValue2.Substring(xStart2, objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) - xStart2);
                                        xStart2 = objBus.OperatorConditionValue2.IndexOf("[;SEP]", xStart2) + 6;
                                        if (objBus.OperatorConditionValue1.TrimEnd(' ') == Con2)
                                            Cumplio1 = false;
                                    }
                                }
                                else
                                {
                                    if (objBus.OperatorConditionValue1.TrimEnd(' ').ToLower() == objBus.OperatorConditionValue2.TrimEnd(' ').ToLower())
                                        Cumplio1 = false;
                                }
                            }
                            //if (!Cumplio1)
                            //    Result = false;
                            Result = Cumplio1;
                            break;
                        }
                    case TTenumBusinessRules_ConditionCondition.Mayor:
                        {
                            Result = true;
                            if (!(myFunctions.FormatMoneyNull(objBus.OperatorConditionValue1.TrimEnd(' ')) > myFunctions.FormatMoneyNull(objBus.OperatorConditionValue2.TrimEnd(' '))))
                                Result = false;
                            break;
                        }
                    case TTenumBusinessRules_ConditionCondition.MayorIgual:
                        {
                            Result = true;
                            if (!(myFunctions.FormatMoneyNull(objBus.OperatorConditionValue1.TrimEnd(' ')) >= myFunctions.FormatMoneyNull(objBus.OperatorConditionValue2.TrimEnd(' '))))
                                Result = false;
                            break;
                        }
                    case TTenumBusinessRules_ConditionCondition.Menor:
                        {
                            Result = true;
                            if (!(myFunctions.FormatMoneyNull(objBus.OperatorConditionValue1.TrimEnd(' ')) < myFunctions.FormatMoneyNull(objBus.OperatorConditionValue2.TrimEnd(' '))))
                                Result = false;
                            break;
                        }
                    case TTenumBusinessRules_ConditionCondition.MenorIgual:
                        {
                            Result = true;
                            if (!(myFunctions.FormatMoneyNull(objBus.OperatorConditionValue1.TrimEnd(' ')) <= myFunctions.FormatMoneyNull(objBus.OperatorConditionValue2.TrimEnd(' '))))
                                Result = false;
                            break;
                        }
                }
                //-------------------------------------------------------------------------------------//
                switch (objBus.OperatorCondition)
                {
                    case TTenumBusinessRules_ConditionOperator.And:
                        Result = Result && previousResult;
                        break;
                    case TTenumBusinessRules_ConditionOperator.Or:
                        Result = Result || previousResult;
                        break;
                }

                previousResult = Result;
                //if (!Result)
                //    break;
            }
            return Result;
        }

        private TTenumBusinessRules_ActionResultType[] DoAction(BusinessRules_Actions[] businessRules_Actions, BusinessRules obj)
        {
            //Hacemos las Acciones y regresamos el resultado por cada una de ellas
            ArrayList arr = new ArrayList();
            foreach (BusinessRules_Actions objBus in businessRules_Actions)
            {
                switch (objBus.ActionType)
                {
                    case TTenumBusinessRules_ActionType.Enabled:
                    case TTenumBusinessRules_ActionType.EnabledCarpet:
                        {
                            DoActionPropertyToDT(true, TTBusinessRules_TipoPropiedad.Enabled, objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.Disabled:
                    case TTenumBusinessRules_ActionType.DisabledCarpet:
                        {
                            DoActionPropertyToDT(false, TTBusinessRules_TipoPropiedad.Enabled, objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.Invisible:
                        {
                            DoActionPropertyToDT(false, TTBusinessRules_TipoPropiedad.Visible, objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.Visible:
                        {
                            DoActionPropertyToDT(true, TTBusinessRules_TipoPropiedad.Visible, objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.NotObligatory:
                        {
                            //DoActionPropertyToConfigFT(false, objBus);
                            DoActionPropertyToConfigFT(myUserData, false, objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.Obligatory:
                        {
                            //DoActionPropertyToConfigFT(true, objBus);
                            DoActionPropertyToConfigFT(myUserData, true, objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoAccount:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.Cuenta, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoField:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.Campo, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoGroup:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.Grupo, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoAccountWithTemplate:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.CuentaWithTemplate, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoFieldWithTemplate:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.CampoWithTemplate, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoGroupWithTemplate:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.GrupoWithTemplate, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoList:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.List, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoListWithTemplate:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.ListWithTemplate, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoQueryList:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.QueryList, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SendMailtoQueryListWithTemplate:
                        {
                            DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount.QueryListWithTemplate, objBus, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.ShowMsj:
                        {
                            //MessageBox.Show(objBus.Parameters[0].ParameterValue, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            string sMessage = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[0].ParameterValue);
                            frmActive.ShowAlert(sMessage);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.FiltrarCombo:
                        {
                            DoActionFilterCombo(objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.AsignarValor:
                        {
                            DoActionPropertyToDT(null, TTBusinessRules_TipoPropiedad.Text, objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SetValueFromQuery:
                        {
                            DoActionPropertyToDTFromQuery(objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.EjecutaQuery:
                        {
                            DoActionDBExecute(TTBusinessRules_TipoExecuteDB.Query, objBus);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.SetValueFromGlobalVariable:
                        {
                            Control ctl = (Control)myBusinessFunctions.ControlFromDT(objBus.Parameters[0].ParameterValue);
                            SetValue(ctl, frmActive.Session[objBus.Parameters[1].ParameterValue].ToString());
                            break;
                        }
                    /*TODO: IDCODEMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Noviembre/2013*/
                    /*OBJETIVO: Cambiar Etiqueta Por Valor Desde Un Query*/
                    #region
                    case TTenumBusinessRules_ActionType.SwitchLabel:
                        {
                            DoActionSwitchLabel(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODEMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
                    /*OBJETIVO: Concatenar Un Valor En Una Etiqueta A Partir De Una Posición*/
                    #region
                    case TTenumBusinessRules_ActionType.ConcatenateValueOnLabel:
                        {
                            DoActionConcatenateValueOnLabel(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Diciembre/2013*/
                    /*OBJETIVO: Crear una variable de sesión y asignarle valor desde un campo control.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.CreateAndSetValueFromFieldToGlobalVariable:
                        {
                            DoActionCreateAndSetValueFromFieldToGlobalVariable(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
                    /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.FilterComboInMultiRow:
                        {
                            DoActionFilterComboInMultiRow(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 23/Enero/2014*/
                    /*OBJETIVO: Llenar filas de multirenglón desde un query.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.FillMultiRowFromQuery:
                        {
                            DoActionFillMultiRowFromQuery(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
                    /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.FunctionInMultiRowColumn:
                        {
                            DoActionFunctionInMultiRowColumn(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Enero/2014*/
                    /*OBJETIVO: Crear variable de sesión y asignarle valor desde un SQLQuery ó valor fijo.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.CreateAndSetValueToGlobalVariable:
                        {
                            DoActionCreateAndSetValueToGlobalVariable(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
                    /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.FilterListFromQuery:
                        {
                            DoActionFilterListFromQuery(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
                    /*OBJETIVO: Ocultar una columna de un multirenglón.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.HideColumnInMultiRow:
                        {
                            DoActionHideShowColumnInMultiRow(objBus, false);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
                    /*OBJETIVO: Mostrar una columna de un multirenglón.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.ShowColumnInMultiRow:
                        {
                            DoActionHideShowColumnInMultiRow(objBus, true);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
                    /*OBJETIVO: Hacer ReadOnly un Control.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.ToMakeReadOnly:
                        {
                            DoActionToMakeReadOnly_ToMakeWritable(objBus, true);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
                    /*OBJETIVO: Hacer Writable un Control.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.ToMakeWritable:
                        {
                            DoActionToMakeReadOnly_ToMakeWritable(objBus, false);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
                    /*OBJETIVO: Hacer Invisible una Pestaña.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.ToMakeInvisibleFolder:
                        {
                            DoActionToMakeInvisibleFolder_ToMakeVisibleFolder(objBus, false);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
                    /*OBJETIVO: Hacer Visible una Pestaña.*/
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.ToMakeVisibleFolder:
                        {
                            DoActionToMakeInvisibleFolder_ToMakeVisibleFolder(objBus, true);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Junio/2014*/
                    /*OBJETIVO: Set Value To Cell from Query: Asignar un valor a determinada celda en determinado multirenglon. */
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.SetValueToCellFromQuery:
                        {
                            DoActionSetValueToCellFromQuery(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 11/Agostro/2014*/
                    /*OBJETIVO: Hide Column On List: Oculta una determinada columna en la pantalla de lista. */
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.HideColumnOnList:
                        {
                            DoActionHideShowColumnOnList(objBus, false);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 11/Agostro/2014*/
                    /*OBJETIVO: Show Column On List: Muestra una determinada columna en la pantalla de lista. */
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.ShowColumnOnList:
                        {
                            DoActionHideShowColumnOnList(objBus, true);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 09/Septiembre/2014*/
                    /*OBJETIVO: Apply Style To Multirow: Aplica determinado estilo (style/cssClass) a un Multirenglón (Fila, Columna o Celda) */
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.ApplyStyleToMultiRow:
                        {
                            DoActionApplyStyleToMultiRow(objBus);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 06/Octubre/2014*/
                    /*OBJETIVO: Cycle From Query: Ejecuta Acciones de Reglas de Negocio según el las filas arrojadas por un SQL Query, utilizando los valores de la misma. */
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.CycleFromQueryBegin:
                        {
                            DoActionCycleFromQueryBegin(objBus, businessRules_Actions, obj);
                            break;
                        }
                    case TTenumBusinessRules_ActionType.CycleFromQueryEnd:
                        {
                            DoActionCycleFromQueryEnd(objBus, businessRules_Actions, obj);
                            break;
                        }
                    #endregion
                    /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 09/Octubre/2014*/
                    /*OBJETIVO: Set TextMode To Password: Agregar el valor Password al atributo TextMode en un TextBox */
                    #region IDCODMANUAL:
                    case TTenumBusinessRules_ActionType.SetTextModeToPassword:
                        {
                            DoActionSetTextModeToPassword(objBus);
                            break;
                        }
                    #endregion
                } //End Switch Sentence.
                
                arr.Add(objBus.ActionResultType);

            } //End foreach Sentence.

            TTenumBusinessRules_ActionResultType[] Result = new TTenumBusinessRules_ActionResultType[arr.Count];
            for (int i = 0; i < arr.Count; i++)
                Result[i] = (TTenumBusinessRules_ActionResultType)arr[i];
            return Result;

        }//End method DoAction()

        public void SetValue(Control y, string value)
        {
            switch (myBusinessFunctions.GetTypeControl(y))
            {
                case 1:
                    Label controlLBL = (Label)y;
                    controlLBL.Text = value;
                    sJavaScript += string.Format("$get('{0}').value = {1};", controlLBL.ClientID, value);
                    break;
                case 2:
                    TextBox controlTXT = (TextBox)y;
                    controlTXT.Text = value;
                    sJavaScript += string.Format("$get('{0}').value = {1};", controlTXT.ClientID, value);
                    break;
                case 3:
                    DropDownList controlDDL = (DropDownList)y;
                    controlDDL.SelectedValue = value;
                    sJavaScript += string.Format("$get('{0}').selectedIndex={1};", controlDDL.ClientID, value);
                    break;
                case 4:
                    ListBox controlLST = (ListBox)y;
                    controlLST.SelectedValue = value;
                    sJavaScript += string.Format("$get('{0}').selectedIndex={1};", controlLST.ClientID, value);
                    break;
                case 5:
                    RadComboBox controlRCB = (RadComboBox)y;
                    controlRCB.SelectedValue = value;
                    sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlRCB.ClientID, value);
                    break;
                case 6:
                    CascadingDropDown controlCDD = (CascadingDropDown)y;
                    DropDownList targetId = (DropDownList)controlCDD.Parent.FindControl(controlCDD.TargetControlID);
                    targetId.SelectedValue = value;
                    controlCDD.SelectedValue = value;
                    //sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, value);
                    //sJavaScript += string.Format("$get('{0}').selectedIndex={1};", targetId.ClientID, value);
                    if (EventControl != null)
                        if (y == EventControl)
                        {
                            sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, value);
                            sJavaScript += string.Format("$get('{0}').value = {1};", targetId.ClientID, value);
                            //sJavaScript += string.Format("$get('{0}').value = {1};", controlCDD.ClientID, objBus.Parameters[1].ParameterValue);
                        }
                        else
                        {
                            sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, value);
                            sJavaScript += string.Format("$get('{0}').value = {1};$get('{0}').onchange();", targetId.ClientID, value);
                            //sJavaScript += string.Format("$get('{0}').value = {1};$get('{2}').onchange();", controlCDD.ClientID, value, targetId.ClientID);
                        }
                    break;
                case 7:
                    RadDatePicker controlRDP = (RadDatePicker)y;
					controlRDP.SelectedDate = Funcion.FormatDateFromTextDate(value);
                    sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", controlRDP.ClientID, value);
                    break;
                case 8:
                    RadNumericTextBox controlRNT = (RadNumericTextBox)y;
                    controlRNT.Text = value;
                    //value = controlRNT.DisplayText;
                    //sJavaScript += string.Format("$('#{0}').val('{1}');", controlRNT.ClientID, controlRNT.DisplayText);
                    sJavaScript += string.Format("$find('{0}').set_value('{1}');", controlRNT.ClientID, value);
                    break;
                case 9:
                    CheckBox controlCHK = (CheckBox)y;
                    controlCHK.Checked = Boolean.Parse(value);
                    sJavaScript += string.Format("$get('{0}').checked = {1};", controlCHK.ClientID, value.ToLower());
                    break;
                case 10:
                    RadTimePicker controlRTP = (RadTimePicker)y;
                    DateTime convertedDate = Convert.ToDateTime(value);
                    controlRTP.SelectedTime = new TimeSpan(convertedDate.Hour, convertedDate.Minute, convertedDate.Second);

                    if (EventControl != null)
                        if (y == EventControl)
                            sJavaScript += string.Format("$find('{0}').get_timeView().setTime({1},{2},{3},null);", controlRTP.ClientID, convertedDate.Hour, convertedDate.Minute, convertedDate.Second);
                        else
                            sJavaScript += string.Format("$find('{0}').get_timeView().setTime({1},{2},{3},null);OnBussinesRulesChangeHourInputMulti($find('{0}'),'{4}');", controlRTP.ClientID, convertedDate.Hour, convertedDate.Minute, convertedDate.Second, value);
                    break;
			}
            



            //try
            //
			//{
            //    (y as IPostBackDataHandler).RaisePostDataChangedEvent();
            //
			//}
            //catch (Exception ex)
            //
			//{
			
            //}
			
        }

        private DataTable GetDataTableFromQuery(String SqlQuery)
        {
            try
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();

                SqlCommand com = new SqlCommand(SqlQuery);

                DataTable dt = db.Consulta(com).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                frmActive.ShowAlert("GetDataTableFromQuery" + ex);

                return null;
            }
        }

        private void DoActionDBExecute(TTBusinessRules_TipoExecuteDB Mode, BusinessRules_Actions objBus)
        {

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand(objBus.Parameters[0].ParameterValue);
            switch (Mode)
            {
                case TTBusinessRules_TipoExecuteDB.Query:
                    {
                        com.CommandType = CommandType.Text;
                        break;
                    }
                case TTBusinessRules_TipoExecuteDB.StoreProcedure:
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        break;
                    }
            }
            db.EjecutaQuery(com, frmActive.MyUserData, new TTDataLayerCS.DataLayerFieldsBitacora("", -1));
        }

        private void DoActionSendMail(TTBusinessRules_DoActionSendMailToAccount mode, BusinessRules_Actions objBus, BusinessRules obj)
        {
            //Global Information
            //Param0 = idConfiguracionServer
            //Detectar configuracion de Servidor de SMTP
            TTConfigurationServersCS.objectBussinessTTConfigurationServers objConfig = new TTConfigurationServersCS.objectBussinessTTConfigurationServers();
            objConfig.GetByKey(myFunctions.FormatNumberNull(objBus.Parameters[0].ParameterValue), true);
            //ChatbertCreations.EasyMail eMail = new ChatbertCreations.EasyMail();
            TTSendSMTPMail eMail = new TTSendSMTPMail(objConfig.Servidor, objConfig.Puerto.Value, objConfig.Usuario, objConfig.Contrasena);
            switch (mode)
            {
                case TTBusinessRules_DoActionSendMailToAccount.Campo:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = CorreoPara
                        //Param3 = Subject
                        //Param4 = Body
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        //eMail.MailTo = "sgarcia@totaltech.com.mx";
                        eMail.MailTo = myBusinessFunctions.DecodingValueControlFromDTs(objBus.Parameters[2].ParameterValue);
                        eMail.MailSubject = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[4].ParameterValue);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.CampoWithTemplate:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = CorreoPara
                        //Param3 = Subject
                        //Param4 = Body
                        //eMail.MailSubject = objBus.Parameters[0].ParameterValue;
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailTo = myBusinessFunctions.DecodingValueControlFromDTs(objBus.Parameters[2].ParameterValue);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.Grupo:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = IdGrupoFuncional
                        //Param3 = Subject
                        //Param4 = Body
                        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                        SqlCommand com = new SqlCommand("spTTBusinessRules_SendMailToGroup");
                        com.Parameters.AddWithValue("@idGrupoFuncional", objBus.Parameters[2].ParameterValue);
                        com.CommandType = CommandType.StoredProcedure;
                        DataTable dt = db.Consulta(com).Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            eMail.MailTo += dt.Rows[i]["Email"].ToString().TrimEnd(' ');
                            eMail.MailTo += (i + 1 < dt.Rows.Count ? ", " : string.Empty);
                        }
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailSubject = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[4].ParameterValue);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.GrupoWithTemplate:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = IdGrupoFuncional
                        //Param3 = Subject
                        //Param4 = idTemplate
                        //Param5 = Body
                        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                        SqlCommand com = new SqlCommand("spTTBusinessRules_SendMailToGroup");
                        com.Parameters.AddWithValue("@idGrupoFuncional", objBus.Parameters[2].ParameterValue);
                        com.CommandType = CommandType.StoredProcedure;
                        DataTable dt = db.Consulta(com).Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            eMail.MailTo += dt.Rows[i]["Email"].ToString().TrimEnd(' ');
                            eMail.MailTo += (i + 1 < dt.Rows.Count ? ", " : string.Empty);
                        }
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailSubject = myBusinessFunctions.DecodingValueFromCommandTexts(obj.NameRule);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[4].ParameterValue);
                        //Adjuntar Archivo
                        //ControlsLibrary.TTVisorDocumentsControl ttTemplate = new ControlsLibrary.TTVisorDocumentsControl();
                        //String Path = ttTemplate.SaveToDisk(myFunctions.FormatNumberNull(objBus.Parameters[3].ParameterValue).Value, DecodingValueFieldKey(), myUserData);
                        //if (Path != "")
                        //    eMail.MailAttach = new System.Net.Mail.Attachment(Path);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.Cuenta:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = CorreoPara
                        //Param3 = Subject
                        //Param4 = Body
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailTo = objBus.Parameters[2].ParameterValue;
                        eMail.MailSubject = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[4].ParameterValue);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.CuentaWithTemplate:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = CorreoPara
                        //Param3 = Subject
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailTo = objBus.Parameters[2].ParameterValue;
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.List:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = Lista de Correos
                        //Param3 = Subject 
                        //Param4 = Body    
                        ArrayList mailto = new ArrayList();
                        String sMailTo = objBus.Parameters[2].ParameterValue;
                        while (sMailTo.IndexOf("\n") > -1)
                        {
                            mailto.Add(sMailTo.Substring(0, sMailTo.IndexOf("\n") - 1).Trim(' '));
                            sMailTo = sMailTo.Substring(sMailTo.IndexOf("\n") + 1).Trim(' ');
                        }
                        if (sMailTo != "")
                            mailto.Add(sMailTo.Trim(' '));
                        for (int i = 0; i < mailto.Count; i++)
                        {
                            eMail.MailTo += mailto[i].ToString();
                            eMail.MailTo += (i + 1 < mailto.Count ? ", " : string.Empty);
                        }
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailSubject = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[4].ParameterValue);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.ListWithTemplate:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = Lista de Correos
                        //Param3 = Subject 
                        //Param4 = Body    
                        ArrayList mailto = new ArrayList();
                        String sMailTo = objBus.Parameters[2].ParameterValue;
                        while (sMailTo.IndexOf("\n") > -1)
                        {
                            mailto.Add(sMailTo.Substring(0, sMailTo.IndexOf("\n") - 1).Trim(' '));
                            sMailTo = sMailTo.Substring(sMailTo.IndexOf("\n") + 1).Trim(' ');
                        }
                        if (sMailTo != "")
                            mailto.Add(sMailTo.Trim(' '));
                        for (int i = 0; i < mailto.Count; i++)
                        {
                            eMail.MailTo += mailto[i].ToString();
                            eMail.MailTo += (i + 1 < mailto.Count ? ", " : string.Empty);
                        }
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailSubject = myBusinessFunctions.DecodingValueFromCommandTexts(obj.NameRule);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        //Adjuntar Archivo
                        //ControlsLibrary.TTVisorDocumentsControl ttTemplate = new ControlsLibrary.TTVisorDocumentsControl();
                        //String Path = ttTemplate.SaveToDisk(myFunctions.FormatNumberNull(objBus.Parameters[4].ParameterValue).Value, DecodingValueFieldKey(), myUserData);
                        //if (Path != "")
                        //    eMail.MailAttach = new System.Net.Mail.Attachment(Path);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.QueryList:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = Query 
                        //Param3 = Subject
                        //Param4 = Body
                        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                        SqlCommand com = new SqlCommand(objBus.Parameters[2].ParameterValue);
                        com.CommandType = CommandType.Text;
                        DataTable dt = db.Consulta(com).Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            eMail.MailTo += dt.Rows[i]["Email"].ToString().TrimEnd(' ');
                            eMail.MailTo += (i + 1 < dt.Rows.Count ? ", " : string.Empty);
                        }
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailSubject = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[4].ParameterValue);
                        break;
                    }
                case TTBusinessRules_DoActionSendMailToAccount.QueryListWithTemplate:
                    {
                        //Param1 = CorreoDesde
                        //Param2 = Query
                        //Param3 = Body
                        //Param4 = Template
                        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                        SqlCommand com = new SqlCommand(objBus.Parameters[2].ParameterValue);
                        com.CommandType = CommandType.Text;
                        DataTable dt = db.Consulta(com).Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            eMail.MailTo += dt.Rows[i]["Email"].ToString().TrimEnd(' ');
                            eMail.MailTo += (i + 1 < dt.Rows.Count ? ", " : string.Empty);
                        }
                        eMail.MailFrom = objBus.Parameters[1].ParameterValue;
                        eMail.MailSubject = myBusinessFunctions.DecodingValueFromCommandTexts(obj.NameRule);
                        eMail.MailBody = myBusinessFunctions.DecodingValueFromCommandTexts(objBus.Parameters[3].ParameterValue);
                        //Adjuntar Archivo
                        //ControlsLibrary.TTVisorDocumentsControl ttTemplate = new ControlsLibrary.TTVisorDocumentsControl();
                        //String Path = ttTemplate.SaveToDisk(myFunctions.FormatNumberNull(objBus.Parameters[4].ParameterValue).Value, DecodingValueFieldKey(), myUserData);
                        //if (Path != "")
                        //    eMail.MailAttach = new System.Net.Mail.Attachment(Path);
                        break;
                    }
            }
            //eMail.MailAttach = new System.Net.Mail.Attachment("C:\\TempFiles\\Attach1.html");
            try
            {
                eMail.Send();
            }
            catch
            { }
        }


        private void DoActionPropertyToComboBox(TTBusinessRules_DoActionPropertyToComboBox mode, BusinessRules_Actions objBus, DataTable source)
        {
            switch (mode)
            {
                case TTBusinessRules_DoActionPropertyToComboBox.Filtrar:
                    {
                        int dtid = myFunctions.FormatNumberNull(objBus.Parameters[0].ParameterValue.Substring(objBus.Parameters[0].ParameterValue.LastIndexOf(".") + 1)).Value;
                        TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
                        TTMetadata.MetadataDatos MyDatos = myMeta.GetDatosDT(dtid);
                        switch (MyDatos.Tipo_de_Control)
                        {
                            case TTMetadata.TTMetadataTypeControl.ComboBox:
                                //ComboBox cb = ((ComboBox)frmActive.Controls.Find("cb" + myFunctions.GenerateName(MyDatos.Nombre), true)[0]);
                                //object selVal = cb.SelectedItem;
                                DataTable dt = (DataTable)source;
                                DataView dv = new DataView(dt, objBus.Parameters[1].ParameterValue, "", DataViewRowState.CurrentRows);
                                dv.ToTable();
                                //cb.DataSource = dv.ToTable();
                                //cb.SelectedItem = selVal;
                                break;
                            case TTMetadata.TTMetadataTypeControl.ListBox:
                                //ListBox lst = ((ListBox)frmActive.Controls.Find("lst" + myFunctions.GenerateName(MyDatos.Nombre), true)[0]);
                                //object selVal = lst.SelectedItem;
                                DataTable dt1 = (DataTable)source;
                                DataView dv1 = new DataView(dt1, objBus.Parameters[1].ParameterValue, "", DataViewRowState.CurrentRows);
                                dv1.ToTable();
                                //lst.DataSource = dv.ToTable();
                                //lst.SelectedItem = selVal;
                                break;
                        }
                        break;
                    }
            }
        }

        private void DoActionPropertyToConfigFT(TTSecurity.GlobalData myUserData, Boolean Value, BusinessRules_Actions objBus)
        {
            //MethodInfo MethodSet = frmActive.GetType().GetMethod("get_MyConfiguration");
            TTMetadata.MetadataConfigurationProcess myConfiguration = new TTMetadata.MetadataConfigurationProcess(myUserData); //(TTMetadata.MetadataConfigurationProcess)MethodSet.Invoke(frmActive, null);
            myConfiguration.FillConfiguration(giProcess);

            int dtid = myFunctions.FormatNumberNull(objBus.Parameters[0].ParameterValue.Substring(objBus.Parameters[0].ParameterValue.LastIndexOf(".") + 1)).Value;
            TTMetadata.MetadataDatos MyDatos = myConfiguration.RowGet(dtid);
            MyDatos.Obligatorio = Value;
            myConfiguration.RowSet(dtid, MyDatos);
            ((RequiredFieldValidator)FindControlRecursive(frmActive, "RFV" + myFunctions.GenerateName(MyDatos.Nombre))).Enabled = Value;
            ((Image)FindControlRecursive(frmActive, "imgObl" + myFunctions.GenerateName(MyDatos.Nombre))).Attributes["style"] = "display: none;";
            //if (Value)
            //    ((Label)FindControlRecursive(frmActive, "lbl" + myFunctions.GenerateName(MyDatos.Nombre))).Text = MyDatos.Descripcion + "ª";  //frmActive.Controls.Find("lbl" + myFunctions.GenerateName(MyDatos.Nombre), true)[0]).Text = MyDatos.Descripcion + "ª";
            //else
            ((Label)FindControlRecursive(frmActive, "lbl" + myFunctions.GenerateName(MyDatos.Nombre))).Text = MyDatos.Descripcion; //frmActive.Controls.Find("lbl" + myFunctions.GenerateName(MyDatos.Nombre), true)[0]).Text = MyDatos.Descripcion;
        }

        private void DoActionPropertyToDTFromQuery(BusinessRules_Actions objBus)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand(objBus.Parameters[1].ParameterValue);
            DataTable dt = db.Consulta(com).Tables[0];
            String sValue = "";
            if (dt.Rows.Count > 0)
                sValue = dt.Rows[0][0].ToString();
            ///Busca el control en la Pantalla y asigane el valor de la propiedad
            GridView dg;
            Object ctlT = myBusinessFunctions.ControlFromDT(objBus.Parameters[0].ParameterValue, out dg);
            if (ctlT.GetType().BaseType != typeof(GridView))   ///(GridViewColumn))
            {
                Control ctl = (Control)ctlT;
                if (ctl.GetType() == typeof(DropDownList))
                {
                    ((DropDownList)ctl).SelectedValue = sValue;
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$get('{0}').value = {1};", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$get('{0}').value = {1};$get('{0}').onchange();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(TextBox))
                {
                    (ctl as TextBox).Text = sValue;
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$get('{0}').value = '{1}';", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$get('{0}').value = '{1}';$get('{0}').onblur();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(CascadingDropDown))
                {
                    CascadingDropDown controlCDD = (CascadingDropDown)ctl;
                    DropDownList targetId = (DropDownList)controlCDD.Parent.FindControl(controlCDD.TargetControlID);
                    try
                    {
                        targetId.SelectedValue = sValue;
                        controlCDD.SelectedValue = sValue;
                    }
                    catch (Exception)
                    {
                        controlCDD.ContextKey = sValue;
                    }
                    //sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, objBus.Parameters[1].ParameterValue);
                    //sJavaScript += string.Format("$get('{0}').selectedIndex={1};", targetId.ClientID, objBus.Parameters[1].ParameterValue);
                    if (EventControl != null)
                        if (ctl == EventControl)
                        {
                            sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, sValue);
                            sJavaScript += string.Format(" var objSelect = $get('{0}'); setSelectedValue(objSelect, '{1}');", targetId.ClientID, sValue);
                        }
                        else
                        {
                            sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, sValue);
                            sJavaScript += string.Format(" var objSelect = $get('{0}'); setSelectedValue(objSelect, '{1}'); objSelect.onchange(); ", targetId.ClientID, sValue);
                        }
                }
                else if (ctl.GetType() == typeof(RadTimePicker))
                {
                    DateTime convertedDate = Convert.ToDateTime(sValue);

                    (ctl as RadTimePicker).SelectedTime = new TimeSpan(convertedDate.Hour, convertedDate.Minute, convertedDate.Second);
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').get_timeView().setTime({1},{2},{3},null);", ctl.ClientID, convertedDate.Hour, convertedDate.Minute, convertedDate.Second);
                        else
                            sJavaScript += string.Format("$find('{0}').get_timeView().setTime({1},{2},{3},null);OnBussinesRulesChangeHourInputMulti($find('{0}'),'{4}');", ctl.ClientID, convertedDate.Hour, convertedDate.Minute, convertedDate.Second, sValue);
                  //sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(RadDatePicker))
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("es-MX", true);
                    DateTime dtValue = DateTime.Parse(sValue, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    (ctl as RadDatePicker).SelectedDate = Funcion.FormatDateFromTextDate(dtValue.ToString("MM/dd/yyyy"));
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", ctl.ClientID, dtValue.ToString("MM/dd/yyyy"));
                        else
                            sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');OnBussinesRulesChangeDateInputMulti($find('{0}'),'{1}');", ctl.ClientID, dtValue.ToString("MM/dd/yyyy"));
                }
                else if (ctl.GetType() == typeof(RadDatePicker))
                {
                    (ctl as RadDatePicker).SelectedDate = Funcion.FormatDateFromTextDate(sValue);
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').OnChangeDateInputMulti();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(RadDateTimePicker))
                {
                    (ctl as RadDateTimePicker).SelectedDate = Funcion.FormatDateFromTextDate(sValue);
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').OnChangeDateInputMulti();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(RadNumericTextBox))
                {
                    (ctl as RadNumericTextBox).Text = sValue;
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(CheckBox))
                {
                    (ctl as CheckBox).Checked = Boolean.Parse(sValue);
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$get('{0}').checked = {1};", ctl.ClientID, sValue.ToLower());
                        else
                            sJavaScript += string.Format("$get('{0}').checked = {1};$get('{0}').click();", ctl.ClientID, sValue.ToLower());
                }
                else if (ctl.GetType() == typeof(ListBox))
                {
                    db = new TTDataLayerCS.BD();
                    com = new SqlCommand(objBus.Parameters[1].ParameterValue);
                    DataSet ds = db.Consulta(com);
                    for (int i = 0; i <= ds.Tables[0].Rows.Count-1; i++)
                    {
                        foreach (ListItem itm in (ctl as ListBox).Items)
                            if (ds.Tables[0].Rows[i][0].ToString().ToUpper() == itm.Value.ToUpper())
                                itm.Selected = true;                        
                    }
                }
                else if (ctl.GetType() == typeof(RadComboBox))
                {
                    WebControl ctlWebControl = (WebControl)ctl;
                    string dtidRadComboBox = ctlWebControl.Attributes["DTid"];
                    string procesoRadComboBox = ctlWebControl.Attributes["Proceso"];

                    TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
                    TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(dtidRadComboBox));
                    TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
                    TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);

                    string Clave = myFunctions.GenerateName(datoClave.Nombre);
                    string Descripcion = myFunctions.GenerateName(datoDescripcion.Nombre);
                    string NombreTabla = myFunctions.GenerateName(datoDescripcion.NombreTabla);

                    string sqlQuery =  @"SELECT {0},{1} FROM {2} WHERE ( {0} = {3} )";
                    sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, sValue);
                    DataSet ds = Funcion.RegresaDataSet(sqlQuery);

                    string value = ds.Tables[0].Rows[0][Clave].ToString();
                    string text = ds.Tables[0].Rows[0][Descripcion].ToString();

                    (ctl as RadComboBox).Text = text;
                    
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').set_text('{2}');", ctl.ClientID, value, text);
                        else
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').set_text('{2}');", ctl.ClientID, value, text);
                }
                try
                {
                    (ctl as IPostBackDataHandler).RaisePostDataChangedEvent();
                }
                catch (Exception ex) 
                {
                    //this.frmActive.ShowAlert("DoActionPropertyToDTFromQuery: " + ex);
                }
            }
            else
            {
                //if (dg.CurrentRow != null)
                //    dg.CurrentRow.Cells[((DataGridViewColumn)ctlT).Name].Value = sValue;
            }
        }

        private void DoActionPropertyToDTFromQueryClean(String command, Object ctlT)
        {
            TTDataLayerCS.BD db = new TTDataLayerCS.BD();
            SqlCommand com = new SqlCommand(command);
            DataTable dt = db.Consulta(com).Tables[0];
            String sValue = "";
            if (dt.Rows.Count > 0)
                sValue = dt.Rows[0][0].ToString();
            ///Busca el control en la Pantalla y asigane el valor de la propiedad
            GridView dg;
            //Object ctlT = myBusinessFunctions.ControlFromDT(objBus.Parameters[0].ParameterValue, out dg);
            if (ctlT.GetType().BaseType != typeof(GridView))   ///(GridViewColumn))
            {
                Control ctl = (Control)ctlT;
                if (ctl.GetType() == typeof(DropDownList))
                {
                    ((DropDownList)ctl).SelectedValue = sValue;
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$get('{0}').value = {1};", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$get('{0}').value = {1};$get('{0}').onchange();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(TextBox))
                {
                    (ctl as TextBox).Text = sValue;
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$get('{0}').value = '{1}';", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$get('{0}').value = '{1}';$get('{0}').onblur();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(CascadingDropDown))
                {
                    CascadingDropDown controlCDD = (CascadingDropDown)ctl;
                    DropDownList targetId = (DropDownList)controlCDD.Parent.FindControl(controlCDD.TargetControlID);
                    try
                    {
                        targetId.SelectedValue = sValue;
                        controlCDD.SelectedValue = sValue;
                    }
                    catch (Exception)
                    {
                        controlCDD.ContextKey = sValue;
                    }
                    //sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, objBus.Parameters[1].ParameterValue);
                    //sJavaScript += string.Format("$get('{0}').selectedIndex={1};", targetId.ClientID, objBus.Parameters[1].ParameterValue);
                    if (EventControl != null)
                        if (ctl == EventControl)
                        {
                            sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, sValue);
                            sJavaScript += string.Format(" var objSelect = $get('{0}'); setSelectedValue(objSelect, '{1}');", targetId.ClientID, sValue);
                        }
                        else
                        {
                            sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, sValue);
                            sJavaScript += string.Format(" var objSelect = $get('{0}'); setSelectedValue(objSelect, '{1}'); objSelect.onchange(); ", targetId.ClientID, sValue);
                        }
                }
                else if (ctl.GetType() == typeof(RadTimePicker))
                {
                    DateTime convertedDate = Convert.ToDateTime(sValue);

                    (ctl as RadTimePicker).SelectedTime = new TimeSpan(convertedDate.Hour, convertedDate.Minute, convertedDate.Second);
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').get_timeView().setTime({1},{2},{3},null);", ctl.ClientID, convertedDate.Hour, convertedDate.Minute, convertedDate.Second);
                        else
                            sJavaScript += string.Format("$find('{0}').get_timeView().setTime({1},{2},{3},null);OnBussinesRulesChangeHourInputMulti($find('{0}'),'{4}');", ctl.ClientID, convertedDate.Hour, convertedDate.Minute, convertedDate.Second, sValue);
                    //sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(RadDatePicker))
                {
                    IFormatProvider culture = new System.Globalization.CultureInfo("es-MX", true);
                    DateTime dtValue = DateTime.Parse(sValue, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    (ctl as RadDatePicker).SelectedDate = Funcion.FormatDateFromTextDate(dtValue.ToString("MM/dd/yyyy"));
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", ctl.ClientID, dtValue.ToString("MM/dd/yyyy"));
                        else
                            sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');OnBussinesRulesChangeDateInputMulti($find('{0}'),'{1}');", ctl.ClientID, dtValue.ToString("MM/dd/yyyy"));
                }
                else if (ctl.GetType() == typeof(RadDatePicker))
                {
                    (ctl as RadDatePicker).SelectedDate = Funcion.FormatDateFromTextDate(sValue);
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').OnChangeDateInputMulti();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(RadDateTimePicker))
                {
                    (ctl as RadDateTimePicker).SelectedDate = Funcion.FormatDateFromTextDate(sValue);
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').OnChangeDateInputMulti();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(RadNumericTextBox))
                {
                    (ctl as RadNumericTextBox).Text = sValue;
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(CheckBox))
                {
                    (ctl as CheckBox).Checked = Boolean.Parse(sValue);
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$get('{0}').checked = {1};", ctl.ClientID, sValue.ToLower());
                        else
                            sJavaScript += string.Format("$get('{0}').checked = {1};$get('{0}').click();", ctl.ClientID, sValue.ToLower());
                }
                else if (ctl.GetType() == typeof(ListBox))
                {
                    db = new TTDataLayerCS.BD();
                    com = new SqlCommand(command);
                    DataSet ds = db.Consulta(com);
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        foreach (ListItem itm in (ctl as ListBox).Items)
                            if (ds.Tables[0].Rows[i][0].ToString().ToUpper() == itm.Value.ToUpper())
                                itm.Selected = true;
                    }
                }
                else if (ctl.GetType() == typeof(RadComboBox))
                {
                    WebControl ctlWebControl = (WebControl)ctl;
                    string dtidRadComboBox = ctlWebControl.Attributes["DTid"];
                    string procesoRadComboBox = ctlWebControl.Attributes["Proceso"];

                    TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
                    TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(dtidRadComboBox));
                    TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
                    TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);

                    string Clave = myFunctions.GenerateName(datoClave.Nombre);
                    string Descripcion = myFunctions.GenerateName(datoDescripcion.Nombre);
                    string NombreTabla = myFunctions.GenerateName(datoDescripcion.NombreTabla);

                    string sqlQuery = @"SELECT {0},{1} FROM {2} WHERE ( {0} = {3} )";
                    sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, sValue);
                    DataSet ds = Funcion.RegresaDataSet(sqlQuery);

                    string value = ds.Tables[0].Rows[0][Clave].ToString();
                    string text = ds.Tables[0].Rows[0][Descripcion].ToString();

                    (ctl as RadComboBox).Text = text;

                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').set_text('{2}');", ctl.ClientID, value, text);
                        else
                            sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').set_text('{2}');", ctl.ClientID, value, text);
                }
                try
                {
                    (ctl as IPostBackDataHandler).RaisePostDataChangedEvent();
                }
                catch (Exception ex)
                {
                    //this.frmActive.ShowAlert("DoActionPropertyToDTFromQuery: " + ex);
                }
            }
            else
            {
                //if (dg.CurrentRow != null)
                //    dg.CurrentRow.Cells[((DataGridViewColumn)ctlT).Name].Value = sValue;
            }
        }

        private void DoActionPropertyToDT(object Value, TTBusinessRules_TipoPropiedad Property, BusinessRules_Actions objBus)
        {
            ///Busca el control en la Pantalla y asigane el valor de la propiedad
            switch (objBus.Parameters[0].ParameterType)
            {
                case TTenumBusinessRules_ActionParameterType.Carpeta:
                    {
                        Control TabControls = (Control)FindControlRecursive(frmActive, "TabControls");
                        if (TabControls.GetType() == typeof(RadTabStrip))
                        {
                            string tabName = "tabPag" + myFunctions.GenerateName(objBus.Parameters[0].ParameterValue);
                            RadTab radTab = (RadTab)(TabControls as RadTabStrip).Tabs.FindTabByValue(tabName);
                            RadMultiPage RadMultiPage1 = (RadMultiPage)FindControlRecursive(frmActive, "RadMultiPage1");
                            RadPageView pageView = (RadPageView)RadMultiPage1.FindControl(tabName);

                            switch (Property)
                            {
                                case TTBusinessRules_TipoPropiedad.Enabled:
                                    System.Web.UI.HtmlControls.HtmlTable ctt = (System.Web.UI.HtmlControls.HtmlTable)FindControlRecursive(frmActive, "tb" + myFunctions.GenerateName(objBus.Parameters[0].ParameterValue));
                                    ctt.Disabled = !(Boolean)Value;
                                    sJavaScript += string.Format("$get('{0}').disabled = {1};", ctt.ClientID, (!(Boolean)Value).ToString().ToLower());
                                    if ((Boolean)Value)
                                        EnableControlRecursive(ctt, ref sJavaScript);
                                    else
                                        DisableControlRecursive(ctt, ref sJavaScript);
                                    break;
                                case TTBusinessRules_TipoPropiedad.Visible:

                                    if ((Boolean)Value)
                                    {
                                        radTab.Attributes["style"] = "display: auto;";
                                        pageView.Attributes["style"] = "display: auto;";
                                    }else{
                                        radTab.Attributes["style"] = "display: none;";
                                        pageView.Attributes["style"] = "display: none;";
                                    }
                                    sJavaScript += string.Format("$get('{0}').disabled = {1};", radTab.ClientID, (!(Boolean)Value).ToString().ToLower());
                                    sJavaScript += string.Format("$get('{0}').disabled = {1};", pageView.ClientID, (!(Boolean)Value).ToString().ToLower());
                                    break;
                            }

                        }
                        else
                        {
							//TabPage ctl = (TabPage)frmActive.Controls.Find("tabPag" + myFunctions.GenerateName(objBus.Parameters[0].ParameterValue), true)[0];
							TabPanel ctl = (TabPanel)FindControlRecursive(frmActive, "tabPag" + myFunctions.GenerateName(objBus.Parameters[0].ParameterValue));
							switch (Property)
							{
								case TTBusinessRules_TipoPropiedad.Enabled:
									System.Web.UI.HtmlControls.HtmlTable ctt = (System.Web.UI.HtmlControls.HtmlTable)FindControlRecursive(frmActive, "tb" + myFunctions.GenerateName(objBus.Parameters[0].ParameterValue));
									ctt.Disabled = !(Boolean)Value;
									sJavaScript += string.Format("$get('{0}').disabled = {1};", ctt.ClientID, (!(Boolean)Value).ToString().ToLower());
									if ((Boolean)Value)
										EnableControlRecursive(ctt, ref sJavaScript);
									else
										DisableControlRecursive(ctt, ref sJavaScript);
									break;
								case TTBusinessRules_TipoPropiedad.Visible:
									(ctl as TabPanel).Enabled = (Boolean)Value;
									sJavaScript += string.Format("$get('{0}').disabled = {1};", ctl.ClientID, (!(Boolean)Value).ToString().ToLower());
									break;
							}
                        }
                        break;
                    }
                case TTenumBusinessRules_ActionParameterType.Texto:
                case TTenumBusinessRules_ActionParameterType.DatoID:
                    {
                        string nombreCampo = "";
                        Control ev = eventControl;
                        Object ctlT = myBusinessFunctions.ControlFromDT(objBus.Parameters[0].ParameterValue);
                        
                        if (ctlT.GetType() != typeof(Panel))  /* Si el control no es un campo multirenglón. */
                        {
                            Control y = (Control)ctlT;
                            switch (Property)
                            {
                                case TTBusinessRules_TipoPropiedad.Enabled:
                                    switch (myBusinessFunctions.GetTypeControl(y))
                                    {
                                        case 1:
                                            Label controlLBL = (Label)y;
                                            controlLBL.Enabled = (Boolean)Value;
                                            nombreCampo = y.ID.Replace("lbl", "");
                                            break;
                                        case 2:
                                            TextBox controlTXT = (TextBox)y;
                                            controlTXT.ReadOnly = !(Boolean)Value;
                                            nombreCampo = y.ID.Replace("txt", "");
                                            break;
                                        case 3:
                                            DropDownList controlDDL = (DropDownList)y;
                                            controlDDL.Enabled = (Boolean)Value;
                                            nombreCampo = y.ID.Replace("ddl", "");
                                            break;
                                        case 4:
                                            ListBox controlLST = (ListBox)y;
                                            controlLST.Enabled = (Boolean)Value;
                                            nombreCampo = y.ID.Replace("lst", "");
                                            break;
                                        case 5:
                                            RadComboBox controlRCB = (RadComboBox)y;
                                            controlRCB.Enabled = (Boolean)Value;
                                            nombreCampo = y.ID.Replace("ddl", "");
                                            break;
                                        case 6:
                                            CascadingDropDown controlCDD = (CascadingDropDown)y;
                                            DropDownList targetId = (DropDownList)controlCDD.Parent.FindControl(controlCDD.TargetControlID);
                                            targetId.Enabled = (Boolean)Value;
                                            controlCDD.Enabled = (Boolean)Value;
                                            //HiddenField hdnBRHelper = (HiddenField)FindControlRecursive(frmActive,"BRHelper");
                                            //hdnBRHelper.Value = controlCDD.BehaviorID;
                                            nombreCampo = y.ID.Replace("cdd", "");
                                            if (!(Boolean)Value)
                                            {
                                                 sJavaScript += string.Format("$('#{0}').attr('disabled','{1}');", targetId.ClientID, (!(Boolean)Value).ToString().ToLower());
                                                //sJavaScript += string.Format("$find('{0}').add_populated(onPopulatingCDDdisabled);", controlCDD.ClientID, (!(Boolean)Value).ToString().ToLower());
                                            }
                                            else
                                            {
                                                sJavaScript += string.Format("$('#{0}').removeAttr('disabled');", targetId.ClientID);
                                                //sJavaScript += string.Format("$find('{0}').add_populated(onPopulatingCDDenabled);", controlCDD.ClientID, (!(Boolean)Value).ToString().ToLower());
                                            }
                                            break;
                                        case 7:
                                            RadDatePicker controlRDP = (RadDatePicker)y;
                                            controlRDP.Enabled = (Boolean)Value;
                                            nombreCampo = y.ID.Replace("txt", "");
                                            break;
                                        case 8:
                                            RadNumericTextBox controlRNT = (RadNumericTextBox)y;
                                            controlRNT.ReadOnly = !(Boolean)Value;
                                            nombreCampo = y.ID.Replace("txt", "");
                                            break;
                                        case 9:
                                            CheckBox controlCHK = (CheckBox)y;
                                            controlCHK.Enabled = (Boolean)Value;
                                            nombreCampo = y.ID.Replace("Ch", "");
                                            break;
                                        case 10:
                                            RadTimePicker controlRTP = (RadTimePicker)y;
                                            controlRTP.Enabled = (Boolean)Value;
                                            nombreCampo = y.ID.Replace("txt", "");
                                            break;
                                        case 11:
                                            LinkButton controlLNK = (LinkButton)y;
                                            controlLNK.Enabled = (Boolean)Value;
                                            nombreCampo = y.ID.Replace("lnk", "");
                                            break;
                                    }
                                    if (nombreCampo != "")
                                    {
                                        switch (myBusinessFunctions.GetTypeControl(y))
                                        {
                                            case 2:
                                                sJavaScript += string.Format("$get('{0}').readonly = {1};", y.ClientID, (!(Boolean)Value).ToString().ToLower());
                                                break;
                                            case 8:
                                                //sJavaScript += string.Format("$get('{0}').readonly = {1};", y.ClientID, (!(Boolean)Value).ToString().ToLower());
                                                if (!(Boolean)Value)
                                                    sJavaScript += string.Format("$('#{0}').attr('readonly','{1}');", y.ClientID, (!(Boolean)Value).ToString().ToLower());
                                                else
                                                    sJavaScript += string.Format("$('#{0}').removeAttr('readonly');", y.ClientID);
                                                break;
                                            case 6:
                                                
                                                break;
                                            default:
                                                sJavaScript += string.Format("$get('{0}').disabled = {1};", y.ClientID, (!(Boolean)Value).ToString().ToLower());
                                                break;
                                        }
                                        
                                        RequiredFieldValidator Validador = ((RequiredFieldValidator)FindControlRecursive(frmActive, "RFV" + myFunctions.GenerateName(nombreCampo)));
                                        if (Validador != null)
                                        {
                                            Validador.Enabled = false;
                                        }
                                        Image Imagen = ((Image)FindControlRecursive(frmActive, "imgObl" + myFunctions.GenerateName(nombreCampo)));
                                        if (Imagen != null)
                                        {
                                            Imagen.Attributes["style"] = "display: none;";
                                        }
                                    }
                                    break;
                                case TTBusinessRules_TipoPropiedad.Visible:
                                    Control Padre = y.Parent;
                                    if (Padre.GetType() == typeof(System.Web.UI.HtmlControls.HtmlTableCell))
                                    {
                                        while (Padre != null && !(Padre.GetType() == typeof(System.Web.UI.HtmlControls.HtmlTableRow)))
                                        {
                                            Padre = Padre.Parent;
                                        }
                                        System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)Padre;
                                        if ((Boolean)Value)
                                            tr.Attributes["style"] = "display: auto;";
                                        else
                                            tr.Attributes["style"] = "display: none;";
                                    }
									else if (Padre.GetType() == typeof(Panel))
                                    {
                                        Padre = Padre.Parent; // get asp:Placeholder
                                        Padre = Padre.Parent; // get HtmlTableCell
                                        if (Padre.GetType() == typeof(System.Web.UI.HtmlControls.HtmlTableCell))
                                        {
                                            while (Padre != null && !(Padre.GetType() == typeof(System.Web.UI.HtmlControls.HtmlTableRow)))
                                            {
                                                Padre = Padre.Parent;
                                            }
                                        System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)Padre;
                                        if ((Boolean)Value)
                                            tr.Attributes["style"] = "display: auto;";
                                        else
                                            tr.Attributes["style"] = "display: none;";
                                        }
                                    }
                                    else
                                    {
                                        switch (myBusinessFunctions.GetTypeControl(y))
                                        {
                                            case 1:
                                                Label controlLBL = (Label)y;
                                                controlLBL.Visible = (Boolean)Value;
                                                break;
                                            case 2:
                                                TextBox controlTXT = (TextBox)y;
                                                controlTXT.Visible = (Boolean)Value;
                                                break;
                                            case 3:
                                                DropDownList controlDDL = (DropDownList)y;
                                                controlDDL.Visible = (Boolean)Value;
                                                break;
                                            case 4:
                                                ListBox controlLST = (ListBox)y;
                                                controlLST.Visible = (Boolean)Value;
                                                break;
                                            case 5:
                                                RadComboBox controlRCB = (RadComboBox)y;
                                                controlRCB.Visible = (Boolean)Value;
                                                break;
                                            case 6:
                                                CascadingDropDown controlCDD = (CascadingDropDown)y;
                                                DropDownList targetId = (DropDownList)controlCDD.Parent.FindControl(controlCDD.TargetControlID);
                                                targetId.Visible = (Boolean)Value;
                                                controlCDD.Visible = (Boolean)Value;
                                                break;
                                            case 7:
                                                RadDatePicker controlRDP = (RadDatePicker)y;
                                                controlRDP.Visible = (Boolean)Value;
                                                break;
                                            case 8:
                                                RadNumericTextBox controlRNT = (RadNumericTextBox)y;
                                                controlRNT.Visible = (Boolean)Value;
                                                break;
                                            case 9:
                                                CheckBox controlCHK = (CheckBox)y;
                                                if (controlCHK.Parent.GetType() == typeof(Panel))
                                                {
                                                    Padre = controlCHK.Parent; // get asp:Panel
                                                    Padre = Padre.Parent; // get asp:Placeholder
                                                    Padre = Padre.Parent; // get HtmlTableCell
                                                    if (Padre.GetType() == typeof(System.Web.UI.HtmlControls.HtmlTableCell))
                                                    {
                                                        while (Padre != null && !(Padre.GetType() == typeof(System.Web.UI.HtmlControls.HtmlTableRow)))
                                                        {
                                                            Padre = Padre.Parent;
                                                        }
                                        System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)Padre;
                                        if ((Boolean)Value)
                                            tr.Attributes["style"] = "display: auto;";
                                        else
                                            tr.Attributes["style"] = "display: none;";
                                                    }
                                                }
                                                else
                                                {
                                                    controlCHK.Visible = (Boolean)Value;
                                                }
                                                break;
                                            case 10:
                                                RadTimePicker controlRTP = (RadTimePicker)y;
                                                controlRTP.Visible = (Boolean)Value;
                                                break;
                                            case 11:
                                                LinkButton controlLNK = (LinkButton)y;
                                                controlLNK.Visible = (Boolean)Value;
                                                break;
                                        }
                                    }
                                    sJavaScript += string.Format("$get('{0}').style.visibility = 'hidden'", y.ClientID);
                                    break;
                                case TTBusinessRules_TipoPropiedad.Text:
                                    switch (myBusinessFunctions.GetTypeControl(y))
                                    {
                                        case 1:
                                            Label controlLBL = (Label)y;
                                            controlLBL.Text = objBus.Parameters[1].ParameterValue;
                                            sJavaScript += string.Format("$get('{0}').value = '{1}';", controlLBL.ClientID, objBus.Parameters[1].ParameterValue);
                                            break;
                                        case 2:
                                            TextBox controlTXT = (TextBox)y;
                                            controlTXT.Text = objBus.Parameters[1].ParameterValue;
                                            sJavaScript += string.Format("$get('{0}').value = '{1}';", controlTXT.ClientID, objBus.Parameters[1].ParameterValue);
                                            break;
                                        case 3:
                                            DropDownList controlDDL = (DropDownList)y;
                                            controlDDL.SelectedValue = objBus.Parameters[1].ParameterValue;
                                            sJavaScript += string.Format("$get('{0}').value = '{1}';", controlDDL.ClientID, objBus.Parameters[1].ParameterValue);
                                            break;
                                        case 4:
                                            ListBox controlLST = (ListBox)y;
                                            controlLST.SelectedValue = objBus.Parameters[1].ParameterValue;
                                            sJavaScript += string.Format("$get('{0}').value = '{1}';", controlLST.ClientID, objBus.Parameters[1].ParameterValue);
                                            break;
                                        case 5:
                                            //RadComboBox controlRCB = (RadComboBox)y;
                                            //controlRCB.SelectedValue = objBus.Parameters[1].ParameterValue;
                                            //sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlRCB.ClientID, objBus.Parameters[1].ParameterValue);

                                            WebControl ctlWebControl = (WebControl)y;
                                            string dtidRadComboBox = ctlWebControl.Attributes["DTid"];
                                            string procesoRadComboBox = ctlWebControl.Attributes["Proceso"];

                                            TTMetadata.Metadata meta = new TTMetadata.Metadata(new TTSecurity.GlobalData());
                                            TTMetadata.MetadataDatos dato = meta.GetDatosDT(Convert.ToInt32(dtidRadComboBox));
                                            TTMetadata.MetadataDatos datoClave = meta.GetDatosDT(dato.DependienteClave.Value);
                                            TTMetadata.MetadataDatos datoDescripcion = meta.GetDatosDT(dato.DependienteDescripcion.Value);

                                            string Clave = myFunctions.GenerateName(datoClave.Nombre);
                                            string Descripcion = myFunctions.GenerateName(datoDescripcion.Nombre);
                                            string NombreTabla = myFunctions.GenerateName(datoDescripcion.NombreTabla);

                                            string sqlQuery = @"SELECT {0},{1} FROM {2} WHERE ( {0} = {3} )";
                                            sqlQuery = string.Format(sqlQuery, Clave, Descripcion, NombreTabla, objBus.Parameters[1].ParameterValue);
                                            DataSet ds = Funcion.RegresaDataSet(sqlQuery);

                                            string value = ds.Tables[0].Rows[0][Clave].ToString();
                                            string text = ds.Tables[0].Rows[0][Descripcion].ToString();

                                            (y as RadComboBox).Text = text;

                                            if (EventControl != null)
                                                if (y == EventControl)
                                                    sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').set_text('{2}');", y.ClientID, value, text);
                                                else
                                                    sJavaScript += string.Format("$find('{0}').set_value('{1}');$find('{0}').set_text('{2}');", y.ClientID, value, text);
                                            break;
                                        case 6:
                                            CascadingDropDown controlCDD = (CascadingDropDown)y;
                                            DropDownList targetId = (DropDownList)controlCDD.Parent.FindControl(controlCDD.TargetControlID);
                                            //targetId.SelectedValue = objBus.Parameters[1].ParameterValue;
                                            controlCDD.SelectedValue = objBus.Parameters[1].ParameterValue;
                                            //sJavaScript += string.Format("$find('{0}').set_SelectedValue('{1}');", controlCDD.ClientID, objBus.Parameters[1].ParameterValue);
                                            //sJavaScript += string.Format("$get('{0}').selectedIndex={1};", targetId.ClientID, objBus.Parameters[1].ParameterValue);
                                            if (EventControl != null)
                                                if (y == EventControl)
                                                {
                                                    sJavaScript += string.Format("$get('{0}').value = '{1}';", targetId.ClientID, objBus.Parameters[1].ParameterValue);
                                                }
                                                else
                                                {
                                                    sJavaScript += string.Format("$get('{0}').value = '{1}';$get('{0}').onchange();", targetId.ClientID, objBus.Parameters[1].ParameterValue);
                                                }
                                            break;
                                        case 7:                                        
                                            String sValue = "";
                                            sValue = objBus.Parameters[1].ParameterValue;
                                            RadDatePicker controlRDP = (RadDatePicker)y;
                                            if (sValue != "")
                                            {
                                                controlRDP.SelectedDate = Funcion.FormatDateFromTextDate(sValue);
                                                sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", controlRDP.ClientID, objBus.Parameters[1].ParameterValue);
                                            }
                                            else
                                            {
                                                controlRDP.Clear();
                                                sJavaScript += string.Format("$find('{0}').clear();", controlRDP.ClientID);
                                            }
                                            break;
                                        case 8:
                                            RadNumericTextBox controlRNT = (RadNumericTextBox)y;
                                            controlRNT.Text = objBus.Parameters[1].ParameterValue;
                                            sJavaScript += string.Format("$find('{0}').set_value('{1}');", controlRNT.ClientID, objBus.Parameters[1].ParameterValue);
                                            break;
                                        case 9:
                                            CheckBox controlCHK = (CheckBox)y;
                                            controlCHK.Checked = Boolean.Parse(objBus.Parameters[1].ParameterValue);
                                            sJavaScript += string.Format("$get('{0}').checked = {1};", controlCHK.ClientID, objBus.Parameters[1].ParameterValue.ToLower());
                                            break;
                                        case 10:
                                            RadTimePicker controlRTP = (RadTimePicker)y;
                                            string[] timeSpan = objBus.Parameters[1].ParameterValue.Split(':'); 
                                            try
                                            {
                                                if (timeSpan.Length == 3)
                                                {
                                                    int hour = int.Parse(timeSpan[0]);
                                                    int minute = int.Parse(timeSpan[1]);
                                                    int second = int.Parse(timeSpan[2]);

                                                    controlRTP.SelectedTime = new TimeSpan(hour, minute, second);
                                                    sJavaScript += string.Format("$find('{0}').get_timeView().setTime('{1}','{2}','{3}');", controlRTP.ClientID, hour, minute, second);
                                                }
                                                else
                                                {
                                                    controlRTP.Clear();
                                                    sJavaScript += string.Format("$find('{0}').clear();", controlRTP.ClientID);
                                                }

                                            }
                                            catch (Exception ex)
                                            {
                                                controlRTP.Clear();
                                                sJavaScript += string.Format("$find('{0}').clear();", controlRTP.ClientID);
                                            }

                                            break;
                                    }
                                    break;
                                    //if (ctl.GetType() == typeof(DropDownList))
                                    //{
                                    //    ((DropDownList)ctl).SelectedValue = objBus.Parameters[1].ParameterValue;
                                    //    sJavaScript += string.Format("$get('{0}').value = {1};", ctl.ClientID, objBus.Parameters[1].ParameterValue);
                                    //}
                                    //else if (ctl.GetType() == typeof(TextBox))
                                    //{
                                    //    (ctl as TextBox).Text = objBus.Parameters[1].ParameterValue;
                                    //    sJavaScript += string.Format("$get('{0}').value = '{1}';", ctl.ClientID, objBus.Parameters[1].ParameterValue);
                                    //}
                                    //else if (ctl.GetType() == typeof(CascadingDropDown))
                                    //{
                                    //    (ctl as CascadingDropDown).SelectedValue = objBus.Parameters[1].ParameterValue;
                                    //    sJavaScript += string.Format("$get('{0}').value = {1};", ctl.ClientID, objBus.Parameters[1].ParameterValue);
                                    //}
                                    //else if (ctl.GetType() == typeof(RadTimePicker))
                                    //{
                                    //    (ctl as RadTimePicker).SelectedDate = Funcion.FormatDateFromTextTime(objBus.Parameters[1].ParameterValue);
                                    //    sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", ctl.ClientID, objBus.Parameters[1].ParameterValue);
                                    //}
                                    //else if (ctl.GetType() == typeof(RadDatePicker))
                                    //{
                                    //    TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                                    //    SqlCommand com = new SqlCommand(objBus.Parameters[1].ParameterValue);
                                    //    DataTable dt = db.Consulta(com).Tables[0];
                                    //    String sValue = "";
                                    //    if (dt.Rows.Count > 0)
                                    //        sValue = dt.Rows[0][0].ToString();
                                    //    (ctl as RadDatePicker).SelectedDate = Funcion.FormatDateFromTextDate(sValue);
                                    //    //sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", ctl.ClientID, objBus.Parameters[1].ParameterValue);
                                    //}
                                    //else if (ctl.GetType() == typeof(RadDateTimePicker))
                                    //{
                                    //    (ctl as RadDateTimePicker).SelectedDate = Funcion.FormatDateFromTextTime(objBus.Parameters[1].ParameterValue);
                                    //    sJavaScript += string.Format("$find('{0}').get_dateInput().set_value('{1}');", ctl.ClientID, objBus.Parameters[1].ParameterValue);
                                    //}
                                    //else if (ctl.GetType() == typeof(RadNumericTextBox))
                                    //{
                                    //    (ctl as RadNumericTextBox).Text = objBus.Parameters[1].ParameterValue;
                                    //    sJavaScript += string.Format("$find('{0}').set_value('{1}');", ctl.ClientID, objBus.Parameters[1].ParameterValue);
                                    //}
                                    //else if (ctl.GetType() == typeof(CheckBox))
                                    //{
                                    //    (ctl as CheckBox).Checked = Boolean.Parse(objBus.Parameters[1].ParameterValue);
                                    //    sJavaScript += string.Format("$get('{0}').checked = {1};", ctl.ClientID, objBus.Parameters[1].ParameterValue.ToLower());
                                    //}
                                    //break;
                            }

                            //try
                            //{
                            //    (y as IPostBackDataHandler).RaisePostDataChangedEvent();
                            //}
                            //catch (Exception ex)
                            //{
                            //}

						}
                        else /* Si el control es un campo multirenglón. */
                        {
                            Panel ctl = (Panel)ctlT;
                            switch (Property)
                            {
                                case TTBusinessRules_TipoPropiedad.Enabled:
                                    ctl.Enabled = (Boolean)Value;
                                    break;
                                case TTBusinessRules_TipoPropiedad.Visible:
                       Control Padre = ctl.Parent;
                                    if (Padre.GetType() == typeof(System.Web.UI.HtmlControls.HtmlTableCell))
                                    {
                                        while (Padre != null && !(Padre.GetType() == typeof(System.Web.UI.HtmlControls.HtmlTableRow)))
                                        {
                                            Padre = Padre.Parent;
                                        }
                                        //Padre.Visible = (Boolean)Value;
                                        System.Web.UI.HtmlControls.HtmlTableRow tr = (System.Web.UI.HtmlControls.HtmlTableRow)Padre;
                                        if ((Boolean)Value)
                                            tr.Attributes["style"] = "display: auto;";
                                        else
                                            tr.Attributes["style"] = "display: none;";
                                    }
                                    break;
                                case TTBusinessRules_TipoPropiedad.Text:
                                    //ctl.DefaultCellStyle.
                                    break;
                            }
                        }
                        break;
                    }
            }
            
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

        public static void DisableControlRecursive(Control root, ref string sJavaScript)
        {
            bool entro;

            foreach (Control c in root.Controls)
            {
                entro = false;
                if (c.GetType() == typeof(DropDownList))
                {
                    ((DropDownList)c).Enabled = false;
                    entro = true;
                }
                else if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Enabled = false;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadDatePicker))
                {
                    (c as RadDatePicker).Enabled = false;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadNumericTextBox))
                {
                    (c as RadNumericTextBox).Enabled = false;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadDateTimePicker))
                {
                    (c as RadDateTimePicker).Enabled = false;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadTimePicker))
                {
                    (c as RadTimePicker).Enabled = false;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadComboBox))
                {
                    (c as RadComboBox).Enabled = false;
                    entro = true;
                }
                else if (c.GetType() == typeof(ImageButton))
                {
                    (c as ImageButton).Enabled = false;
                    entro = true;
                }
                else if (c.GetType() == typeof(GridView))
                {
                    GridView ctl = (c as GridView);
                    ctl.Attributes.Add("WFStatus", "WorkflowStatusReadOnly");
                    entro = true;
                }
                else if (c.GetType() == typeof(PageNumbersPager))
                {
                    (c as PageNumbersPager).Enabled = false;
                    entro = true;
                }
				else if (c.GetType() == typeof(Button))
                {
                    (c as Button).Enabled = false;
                    entro = true;
                }
				else if (c.GetType() == typeof(LinkButton))
                {

                    LinkButton ctl = (LinkButton)c;
                    
                    if (!ctl.ID.Contains("lkbVer"))
                    {
                        (c as LinkButton).Enabled = false;
                        entro = true;
                    }

                }
				

                if (entro)
                {
                    sJavaScript += string.Format("$get('{0}').disabled = {1};", c.ClientID, "true");

                }
                DisableControlRecursive(c, ref sJavaScript);
            }
        }

        public static void EnableControlRecursive(Control root, ref string sJavaScript)
        {
            bool entro;

            foreach (Control c in root.Controls)
            {
                entro = false;
                if (c.GetType() == typeof(DropDownList))
                {
                    ((DropDownList)c).Enabled = true;
                    entro = true;
                }
                else if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Enabled = true;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadDatePicker))
                {
                    (c as RadDatePicker).Enabled = true;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadNumericTextBox))
                {
                    (c as RadNumericTextBox).Enabled = true;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadDateTimePicker))
                {
                    (c as RadDateTimePicker).Enabled = true;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadTimePicker))
                {
                    (c as RadTimePicker).Enabled = true;
                    entro = true;
                }
                else if (c.GetType() == typeof(RadComboBox))
                {
                    (c as RadComboBox).Enabled = true;
                    entro = true;
                }
                else if (c.GetType() == typeof(ImageButton))
                {
                    (c as ImageButton).Enabled = true;
                    entro = true;
                }
                else if (c.GetType() == typeof(GridView))
                {
                    GridView ctl = (c as GridView);
                    ctl.Attributes.Remove("WFStatus");
                    entro = true;
                }
				                else if (c.GetType() == typeof(PageNumbersPager))
                {
                    (c as PageNumbersPager).Enabled = true;

                    entro = true;
                }
				else if (c.GetType() == typeof(Button))
                {
                    (c as Button).Enabled = true;
                    entro = true;
                }
				else if (c.GetType() == typeof(LinkButton))
                {

                    LinkButton ctl = (LinkButton)c;
                    
                    if (!ctl.ID.Contains("lkbVer"))
                    {
                        (c as LinkButton).Enabled = true;
                        entro = true;
                    }

                }

                if (entro)
                {
                    sJavaScript += string.Format("$get('{0}').disabled = {1};", c.ClientID, "false");

                }
                EnableControlRecursive(c, ref sJavaScript);
            }
        }
        private void DoActionFilterCombo(BusinessRules_Actions objBus)
        {
            try
            {
                String P1Field = objBus.Parameters[0].ParameterValue;
                String P2Command = objBus.Parameters[1].ParameterValue;

                Control ctl1 = (Control)myBusinessFunctions.ControlFromDT(P1Field);

                if (ctl1.GetType() == typeof(DropDownList))
                {
                    DataTable dt = GetDataTableFromQuery(P2Command);
                    DropDownList control = (DropDownList)ctl1;
                    control.Attributes.Add("Tag", P2Command);
                    control.Items.Clear();
                    control.Items.Add("");
                    foreach (DataRow rowItem in dt.Rows)
                    {
                        control.Items.Add(new ListItem(rowItem[1].ToString(), rowItem[0].ToString()));
                    }

                }
                else if (ctl1.GetType() == typeof(ListBox))
                {
                    DataTable dt = GetDataTableFromQuery(P2Command);
                    ListBox control = (ListBox)ctl1;
                    control.Attributes.Add("Tag", P2Command);
                    control.Items.Clear();
                    control.Items.Add("");
                    foreach (DataRow rowItem in dt.Rows)
                    {
                        control.Items.Add(new ListItem(rowItem[1].ToString(), rowItem[0].ToString()));
                    }
                }
                else if (ctl1.GetType() == typeof(CascadingDropDown))
                {

                }
                else if (ctl1.GetType() == typeof(RadComboBox))
                {

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionFilterCombo: " + error);
            }
        }

        /*TODO: IDCODEMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Noviembre/2013*/
        /*OBJETIVO: Cambiar etiqueta por valor desde un query*/
        #region IDCODMANUAL:
        private void DoActionSwitchLabel(BusinessRules_Actions objBus)
        {
            try
            {
                TTDataLayerCS.BD db = new TTDataLayerCS.BD();

                SqlCommand com = new SqlCommand(objBus.Parameters[1].ParameterValue);

                DataTable dt = db.Consulta(com).Tables[0];

                String sValue = "";

                if (dt.Rows.Count > 0) sValue = dt.Rows[0][0].ToString();

                Object ctlT = myBusinessFunctions.ControlFromDTSGS(objBus.Parameters[0].ParameterValue);

                Control ctl = (Control)ctlT;

                if (ctl.GetType() == typeof(Label))
                {
                    ((Label)ctl).Text = sValue;
                    if (EventControl != null)
                        if (ctl == EventControl)
                            sJavaScript += string.Format("$get('{0}').value = {1};", ctl.ClientID, sValue);
                        else
                            sJavaScript += string.Format("$get('{0}').value = {1};$get('{0}').onchange();", ctl.ClientID, sValue);
                }
                else if (ctl.GetType() == typeof(Panel))
                {
                    ((Panel)ctl).GroupingText = sValue;

                }

                //try
                //{
                //    (ctl as IPostBackDataHandler).RaisePostDataChangedEvent();
                //}
                //catch { }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionSwitchLabel: " + error);
            }

        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
        /*OBJETIVO: Concatenar un valor en una etiqueta a partir de una posición*/
        #region IDCODMANUAL:
        private void DoActionConcatenateValueOnLabel(BusinessRules_Actions objBus)
        {
            try
            {

                Object P1Field = myBusinessFunctions.ControlFromDTSGS(objBus.Parameters[0].ParameterValue);

                String P2Command = objBus.Parameters[1].ParameterValue;

                int P3Position = int.Parse(objBus.Parameters[2].ParameterValue);

                TTDataLayerCS.BD db = new TTDataLayerCS.BD();

                SqlCommand com = new SqlCommand(P2Command);

                DataTable dt = db.Consulta(com).Tables[0];

                String sValue = "";

                if (dt.Rows.Count > 0) sValue = dt.Rows[0][0].ToString();

                Control ctl = (Control)P1Field;

                ResetLabel(objBus.Parameters[0].ParameterValue, ctl);

                if (ctl.GetType() == typeof(Label))
                {
                    Label label = (Label)ctl;

                    if (P3Position >= 0 && P3Position <= label.Text.Length)
                    {
                        label.Text = label.Text.Insert(P3Position, sValue);
                    }
                    else
                    {
                        if (P3Position < 0) label.Text = label.Text.Insert(0, sValue);
                        else label.Text = label.Text.Insert(label.Text.Length, sValue);

                    }

                }
                else if (ctl.GetType() == typeof(Panel))
                {
                    Panel panel = (Panel)ctl;

                    if (P3Position >= 0 && P3Position <= panel.GroupingText.Length)
                    {
                        panel.GroupingText = panel.GroupingText.Insert(P3Position, sValue);
                    }
                    else
                    {
                        if (P3Position < 0) panel.GroupingText = panel.GroupingText.Insert(0, sValue);
                        else panel.GroupingText = panel.GroupingText.Insert(panel.GroupingText.Length, sValue);

                    }

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionConcatenateValueOnLabel: " + error);
            }

        }

        private void ResetLabel(String DtRoot, Control ctl)
        {
            String DNTID = DtRoot.Substring(0, DtRoot.LastIndexOf(".") - 1);

            String DTID = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);

            TTDataLayerCS.BD db = new TTDataLayerCS.BD();

            SqlCommand com = new SqlCommand("SELECT Nombre, Descripcion FROM TTMetadata WHERE DTID = " + DTID);

            DataTable dt = db.Consulta(com).Tables[0];

            switch (myBusinessFunctions.GetTypeControl(ctl))
            {
                case 1:
                    if (dt.Rows[0]["Descripcion"].ToString() != "")
                    {
                        (ctl as Label).Text = dt.Rows[0]["Descripcion"].ToString();
                    }
                    else
                    {
                        (ctl as Label).Text = dt.Rows[0]["Nombre"].ToString();
                    }
                    break;
                case 6:
                    if (dt.Rows[0]["Descripcion"].ToString() != "")
                    {
                        (ctl as Panel).GroupingText = dt.Rows[0]["Descripcion"].ToString();
                    }
                    else
                    {
                        (ctl as Panel).GroupingText = dt.Rows[0]["Nombre"].ToString();
                    }
                    break;
            }
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Diciembre/2013*/
        /*OBJETIVO: Crear una variable de sesión y asignarle valor desde un campo control.*/
        #region IDCODMANUAL:
        
        private void DoActionCreateAndSetValueFromFieldToGlobalVariable(BusinessRules_Actions objBus)
        {
            try
            {
                string variableName = objBus.Parameters[1].ParameterValue;

                BusinessRulesFunctions.globalVariable variableValue;

                Object ctlT = myBusinessFunctions.ControlFromDT(objBus.Parameters[0].ParameterValue);
                
                Control ctl = (Control)ctlT;

                variableValue.control = ctl;

                variableValue.forBussinesRule = true;

                if (!GlobalVaribleExists(variableName))
                {
                    frmActive.Session.Add(variableName, variableValue);
                }
                else
                {
                    if (frmActive.Session[variableName].GetType() == typeof(BusinessRulesFunctions.globalVariable))
                    {
                        BusinessRulesFunctions.globalVariable aux = (BusinessRulesFunctions.globalVariable)frmActive.Session[variableName];
                        
                        aux = variableValue;
                        
                        frmActive.Session[variableName] = aux;
                        
                   }
                }
                
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionCreateAndSetValueFromFieldToGlobalVariable: " + error);
            }
            
        }
        
        private bool GlobalVaribleExists(string name)
        {
            foreach ( string key in frmActive.Session.Keys)
            {
                if (key == name) return true;
            }

            return false;
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
        /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
        #region

        public struct controlFiltered
        {
            public bool toFilter;
            public Control originControl;
            public string query;
            public int DTID;
        }

        private void DoActionFilterComboInMultiRow(BusinessRules_Actions objBus)
        {
            try
            {
                Control P1Control = (Control)(myBusinessFunctions.ControlFromDT(objBus.Parameters[0].ParameterValue));

                if (eventControl == P1Control)
                {
                    RadComboBox comboBox = (RadComboBox)eventControl;
                    WebControl comboBoxWebControl = (WebControl)eventControl;

                    string sqlQuery = string.Empty;
                    sqlQuery = objBus.Parameters[1].ParameterValue;

                    if (sqlQuery.IndexOf("FLD[") > -1 || sqlQuery.IndexOf("FLDD[") > -1 || sqlQuery.IndexOf("GLOBAL[") > -1 || sqlQuery.IndexOf("FLDGC[") > -1)
                    {
                        sqlQuery = myBusinessFunctions.DecodingValueFromCommandTexts(sqlQuery);
                    }
                    DataSet ds = Funcion.RegresaDataSet(sqlQuery);
                    DataRow[] resultsFiltered = null;

                    DataTable dtCloned = ds.Tables[0].Clone();
                    dtCloned.Columns[0].DataType = typeof(String);
                    dtCloned.Columns[1].DataType = typeof(String);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dtCloned.ImportRow(row);
                    }

                    if (ds != null)
                    {
                        string claveColumnName = ds.Tables[0].Columns[0].ColumnName;
                        string descripcionColumnName = ds.Tables[0].Columns[1].ColumnName;

                        string strExpr = "";
                        if (comboBoxWebControl.Attributes["executeQuery"] == "True")
                        {
                            strExpr = string.Format("{0} like '%{1}%'", claveColumnName, comboBoxWebControl.Attributes["textLike"]);
                        }
                        else
                        {
                            strExpr = string.Format("{0} like '%{1}%'", descripcionColumnName, comboBoxWebControl.Attributes["textLike"]);
                        }

                        resultsFiltered = dtCloned.Select(strExpr);
                    }
                    comboBox.Items.Clear();

                    if (ds.Tables.Count > 0)
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow row in resultsFiltered)
                            {
                                RadComboBoxItem item = new RadComboBoxItem();
                                item.Text = row[1].ToString().Trim();
                                item.Value = row[0].ToString().Trim();
                                item.Attributes.Add("Clave", item.Value);
                                item.Attributes.Add("Descripcion", item.Text);
                                comboBox.Items.Add(item);
                                item.DataBind();
                            }
                        }
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionFilterComboInMultiRowByGlobalVariable: " + error);
            }

        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 23/Enero/2014*/
        /*OBJETIVO: Llenar filas de multirenglón desde un query.*/
        #region
        private void DoActionFillMultiRowFromQuery(BusinessRules_Actions objBus)
        {
            try
            {
                GridView P1 = (GridView)(myBusinessFunctions.getMultirowControl(objBus.Parameters[0].ParameterValue, giProcess));
                String P2 = objBus.Parameters[1].ParameterValue;
                String P3 = objBus.Parameters[2].ParameterValue;
                String P4 = objBus.Parameters[3].ParameterValue;
                String querySQL = P2 + P3 + P4;
                String DTID = objBus.Parameters[0].ParameterValue.Substring(objBus.Parameters[0].ParameterValue.LastIndexOf(".") + 1);
                String multirowFields = "SELECT A.Nombre Field, case when RTRIM(LTRIM(B.Descripcion))='Numerico' and a.decimal >0 then 'Decimal' else RTRIM(LTRIM(B.Descripcion)) end DataType FROM TTMetadata A INNER JOIN TTTipo_de_Dato B ON A.Tipo_de_Dato = B.IdTipoDato WHERE DNTID=(SELECT DependienteTabla FROM TTMetadata WHERE DTID = " + DTID + ") ORDER BY Orden";

                string[,] x = getMultiRowFieldsFromMetadata(multirowFields);

                object[] parameters = new object[2];
                parameters[0] = x;
                parameters[1] = querySQL;
                frmActive.Session["RNmyMulti" + getMultiRowName(DTID)] = parameters;
                
            }
            catch (Exception ex)
            {
                String DTID = objBus.Parameters[0].ParameterValue.Substring(objBus.Parameters[0].ParameterValue.LastIndexOf(".") + 1);
                string error = ex.Message;
                frmActive.ShowAlert("DoActionFillMultiRowFromQuery: " + error);
                frmActive.Session["RNmyMulti" + getMultiRowName(DTID)] = null;
            }
        }

        private string getMultiRowName(string DTID)
        {
            string name = "";
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DTID).Value);
            name = myFunctions.GenerateName(myData.Nombre);
            return name;
        }

        private string[,] getMultiRowFieldsFromMetadata(string query)
        {
            DataTable dt = GetDataTableFromQuery(query);
            
            string[,] multiRow = new string[dt.Rows.Count, 2];

            for (int i = 0; i<multiRow.GetLength(0); i++)
            {
                for (int j = 0; j < multiRow.GetLength(1); j++)
                {
                    if (j == 1)
                    {
                        multiRow[i, j] = getSQLDataType(dt.Rows[i][j].ToString());
                    }
                    else
                    {
                        multiRow[i, j] = myFunctions.GenerateName(dt.Rows[i][j].ToString());
                    }
                }
            }

            return multiRow;
        }

        private string getSQLDataType(string val)
        {
            string dataType = "";

            switch (val)
            {
                case "Decimal":
                    dataType = "decimal";
                    break;
                case "Numerico":
                    dataType = "int";
                    break;
                case "Texto":
                    dataType = "string";
                    break;
                case "Moneda":
                    dataType = "decimal";
                    break;
                case "Logico":
                    dataType = "bool";
                    break;
                case "Fecha":
                    dataType = "datetime";
                    break;
                case "Hora":
                    dataType = "string";
                    break;
            }

            return dataType;
        }

        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
        /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
        #region
        private void DoActionFunctionInMultiRowColumn(BusinessRules_Actions objBus)
        {
            try
            {
                GridView GridContainer = (GridView)(myBusinessFunctions.getMultirowControl(objBus.Parameters[0].ParameterValue, giProcess));
                Control P1 = (Control)(myBusinessFunctions.ControlFromDT(objBus.Parameters[0].ParameterValue));
                Control P2Fld = myBusinessFunctions.GetControlFromFLD(objBus.Parameters[1].ParameterValue);
                String P2Global = null;
                int Destination = 0;
                if (P2Fld == null)
                {
                    P2Global = myBusinessFunctions.GetSessionVariableFromGLOBAL(objBus.Parameters[1].ParameterValue);
                    if (P2Global == null)
                    {
                        Destination = 0;
                    }
                    else
                    {
                        Destination = 2;
                    }
                }
                else
                {
                    Destination = 1;
                }

                int P3 = int.Parse(objBus.Parameters[2].ParameterValue);

                double Result = (double)myBusinessFunctions.ExecuteFunction(P1, GridContainer, P3);

                switch (Destination)
                {
                    case 0 :
                        this.frmActive.ShowAlert("Destination field does not found.");
                        break;
                    case 1:
                        SetValue(P2Fld, Result.ToString());
                        break;
                    case 2:
                        this.frmActive.Session[P2Global] = Result;
                        break;
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                //frmActive.ShowAlert("DoActionFunctionInMultiRowColumn:" + error);
            }

        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Enero/2014*/
        /*OBJETIVO: Crear variable de sesión y asignarle valor desde un SQLQuery ó valor fijo.*/
        #region
        private void DoActionCreateAndSetValueToGlobalVariable(BusinessRules_Actions objBus)
        {
            try
            {
                String P1VariableName = objBus.Parameters[0].ParameterValue;
                String P2Source = objBus.Parameters[1].ParameterValue;
                String P3Command = objBus.Parameters[2].ParameterValue;
                String Result = "";
                switch (int.Parse(P2Source))
                {
                    case 0:
                        TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                        SqlCommand cmd = new SqlCommand(P3Command);
                        cmd.CommandType = CommandType.Text;
                        DataSet ds = db.Consulta(cmd);
                        Result = ds.Tables[0].Rows[0][0].ToString();
                        break;
                    case 1:
                        Result = P3Command;
                        break;
                    default:
                        break;
                }

                if (!GlobalVaribleExists(P1VariableName))
                {
                    frmActive.Session.Add(P1VariableName, Result);
                }
                else
                {
                    frmActive.Session[P1VariableName] = Result;

                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionCreateAndSetValueToGlobalVariable: " + error);
            }

        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
        /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 31/Octubre/2014*/
        /*OBJETIVO: Aplicar determinado Orden en una pantalla de tipo Lista.*/
        #region
        private void DoActionFilterListFromQuery(BusinessRules_Actions objBus)
        {
            try
            {
                String P1_Where = (objBus.Parameters.Length >= 1) ? objBus.Parameters[0].ParameterValue.Trim() : string.Empty;
                String P2_Order = (objBus.Parameters.Length >= 2) ? objBus.Parameters[1].ParameterValue.Trim() : string.Empty;

                if (frmActive.Session["hasFilterList"] != null)
                {
                    frmActive.Session["WhereFromBRRadMenu"] = P1_Where;
                }
                else
                {
                    if (P1_Where != "")
                        frmActive.Session["WhereFromBR"] = P1_Where;

                    if (P2_Order != "")
                        frmActive.Session["OrderFromBR"] = getSortExpression(P2_Order);
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionFilterListFromQuery: " + error);
            }

        }

        private List<GridSortExpression> getSortExpression(String parameter)
        {
            List<GridSortExpression> result = new List<GridSortExpression>();

            parameter = System.Text.RegularExpressions.Regex.Replace(parameter, @"\s+", " ");

            string[] parameterList = parameter.Split(',');

            for (int i = 0; i < parameterList.Length; i++)
            {
                parameterList[i] = parameterList[i].Trim();

                string[] partialSplit = parameterList[i].Split(' ');

                GridSortExpression item = new GridSortExpression();

                if (partialSplit.Length > 1)
                {
                    item.FieldName = partialSplit[0];
                    partialSplit[1] = partialSplit[1].Trim();
                    switch (partialSplit[1])
                    {
                        case "DESC":
                            item.SortOrder = GridSortOrder.Descending;
                            break;
                        default:
                            item.SortOrder = GridSortOrder.Ascending;
                            break;
                    }

                }
                else
                {
                    item.FieldName = partialSplit[0];
                    item.SortOrder = GridSortOrder.Ascending;
                }


                result.Add(item);
            }

            return result;
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
        /*OBJETIVO: Ocultar/Mostrar una columna de un multirenglón.*/
        #region
        private void DoActionHideShowColumnInMultiRow(BusinessRules_Actions objBus, bool option)
        {
            try
            {
                String P1Column = objBus.Parameters[0].ParameterValue;
                GridView GridContainer = (GridView)(myBusinessFunctions.getMultirowControl(P1Column, giProcess));
                String ColumnName = GetHeaderTextFromDT(P1Column);
                foreach (DataControlField item in GridContainer.Columns)
                {
                    if (item.HeaderText == ColumnName)
                    {
                        //item.Visible = option;
                        if (!option)
                        {
                            item.ItemStyle.CssClass = "hiddencol";
                            item.HeaderStyle.CssClass = "hiddencol";
                        }
                        else
                        {
                            item.ItemStyle.CssClass = "";
                            item.HeaderStyle.CssClass = "";
                        }
                            
                    }
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionHideShowColumnInMultiRow: " + error);
            }

        }

        private string GetHeaderTextFromDT(string DtRoot)
        {
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf("."));
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);

            if (myData.Descripcion != "" && myData.Descripcion != null)
                return myData.Descripcion;
            else
                return myData.Nombre;
        }

        private string GetUniqueNameFromDT(string DtRoot)
        {
            String DNTRoot = DtRoot.Substring(0, DtRoot.LastIndexOf("."));
            DtRoot = DtRoot.Substring(DtRoot.LastIndexOf(".") + 1);
            TTMetadata.Metadata myMeta = new TTMetadata.Metadata(myUserData);
            TTMetadata.MetadataDatos myData = myMeta.GetDatosDT(myFunctions.FormatNumberNull(DtRoot).Value);

            string uniqueName = "";

            //if (myData.Tipo_de_Control != TTMetadata.TTMetadataTypeControl.ComboBox)
            if (!myData.Dependiente || myData.Tipo_de_Control == TTMetadata.TTMetadataTypeControl.ListBox)
            {
                uniqueName = myFunctions.GenerateName(myData.NombreTabla) + "." + myFunctions.GenerateName(myData.Nombre);
            }
            else
            {

                TTMetadata.MetadataDatos myDataDependiente = myMeta.GetDatosDT((int)myData.DependienteDescripcion);
                uniqueName = myFunctions.GenerateName(myData.Nombre) + "." + myFunctions.GenerateName(myDataDependiente.Nombre);

            }

            return uniqueName;
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
        /*OBJETIVO: Hacer ReadOnly un Control. Hacer Writable un Control.*/
        #region
        private void DoActionToMakeReadOnly_ToMakeWritable(BusinessRules_Actions objBus, bool p)
        {
            
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
        /*OBJETIVO: Hacer Invisible una Pestaña. Hacer Visible una Pestaña.*/
        #region
        private void DoActionToMakeInvisibleFolder_ToMakeVisibleFolder(BusinessRules_Actions objBus, bool p)
        {
            try
            {
                String P1 = objBus.Parameters[0].ParameterValue;
                SetInvisibleFolder(P1, p);
                

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionToMakeInvisibleFolder_ToMakeVisibleFolder: " + error);
            }
        }

        public void SetInvisibleFolder(String tab, bool val)
        {
            string tabName = "tabPag" + Funcion.FormateaDato(tab);

            Control TabControlsAux = Funcion.FindControlRecursive(this.frmActive, "TabControls");

            /* Si las pestañas utilizan RadTabStrip de Telerik*/
            if (TabControlsAux.GetType() == typeof(RadTabStrip))
            {
                RadTab radTab = (RadTab)(TabControlsAux as RadTabStrip).Tabs.FindTabByValue(tabName);
                RadMultiPage RadMultiPage1 = (RadMultiPage)Funcion.FindControlRecursive(this.frmActive, "RadMultiPage1");
                RadPageView pageView = (RadPageView)RadMultiPage1.FindControl(tabName);
                if (val)
                {
                    radTab.Attributes["style"] = "display: auto;";
                    pageView.Attributes["style"] = "display: auto;";
                }else{
                    radTab.Attributes["style"] = "display: none;";
                    pageView.Attributes["style"] = "display: none;";
                }
            }
            /* Si las pestañas utiliza TabPanel de AjaxControlToolkit */
            else
            {

                AjaxControlToolkit.TabContainer tabCont = (AjaxControlToolkit.TabContainer)TabControlsAux;
                AjaxControlToolkit.TabPanel tabPanel = (AjaxControlToolkit.TabPanel)tabCont.FindControl(tabName);

                tabPanel.Visible = val;
                tabPanel.HeaderText = (val == false) ? "" : tab;

            }
        }
        #endregion

		        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
        /*OBJETIVO: Hacer Invisible una Pestaña. Hacer Visible una Pestaña.*/
        #region
        private void DoActionSetValueToCellFromQuery(BusinessRules_Actions objBus)
        {
            try
            {
                string value;
                string valueData;

                String P1 = objBus.Parameters[0].ParameterValue;
                String P2 = objBus.Parameters[1].ParameterValue;
                String P3 = objBus.Parameters[2].ParameterValue;
                String P4 = objBus.Parameters[3].ParameterValue;

                GridView GridContainer = (GridView)(myBusinessFunctions.getMultirowControl(objBus.Parameters[0].ParameterValue, giProcess));

                string nameControl = myBusinessFunctions.ControlNameFromDT(P2);

                int index = -1;

                if (P3.Contains("GLOBAL[SetValueToCell]"))
                {
                    if (this.frmActive.Session["SetValueToCell"] != null)
                    {
                        value = (string)this.frmActive.Session["SetValueToCell"];
                        index = int.Parse(value.Substring(0, value.IndexOf("¬")));

                    }
                    else
                    {
                        index = -1;
                    }
                }
                else
                {
                    index = int.Parse(P3);
                }


                Control ctrl = GridContainer.Rows[index].FindControl(nameControl);

                if (P4.Contains("GLOBAL[SetValueToCell]"))
                {
                    if (this.frmActive.Session["SetValueToCell"] != null)
                    {
                        value = (string)this.frmActive.Session["SetValueToCell"];
                        valueData = value.Substring(value.IndexOf("¬") + 1);

                    }
                    else
                    {
                        index = -1;
                        valueData = "";
                    }

                    P4 = P4.Replace("GLOBAL[SetValueToCell]", valueData);
                }

                P4 = myBusinessFunctions.DecodingValueFromCommandTexts(P4);


                DoActionPropertyToDTFromQueryClean(P4, ctrl);



            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionSetValueToCellFromQuery: " + error);

            }
        }
       #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 11/Agostro/2014*/
        /*OBJETIVO: Hide Column On List: Oculta una determinada columna en la pantalla de lista. */
        /*OBJETIVO: Show Column On List: Muestra una determinada columna en la pantalla de lista. */        
        #region
        private void DoActionHideShowColumnOnList(BusinessRules_Actions objBus, bool value)
        {
            try
            {
                String P1 = objBus.Parameters[0].ParameterValue;

                RadGrid grdRadMov = (RadGrid)FindControlRecursive(frmActive, "grdRadMov");

                String ColumnName = GetUniqueNameFromDT(P1);
                
                foreach (GridColumn item in grdRadMov.Columns)
                {
                    if (item.UniqueName == ColumnName)
                    {
                        if (item.HeaderStyle.CssClass != "Hide" && item.ItemStyle.CssClass != "Hide") //No tomar en cuenta las columna que siempre van ocultas e.g. La descripción de un campo tipo combo.
                        {
                            item.Visible = value;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionHideShowColumnOnList: " + error);
            }
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 09/Septiembre/2014*/
        /*OBJETIVO: Apply Style To Multirow: Aplica determinado estilo (style/cssClass) a un Multirenglón (Fila, Columna o Celda) */
        #region
        private void DoActionApplyStyleToMultiRow(BusinessRules_Actions objBus)
        {
            try
            {

                string P1_Target = objBus.Parameters[0].ParameterValue;
                string P2_Index = objBus.Parameters[1].ParameterValue;
                string P3_Style = objBus.Parameters[2].ParameterValue;

                GridView GridContainer = (GridView)(myBusinessFunctions.getMultiRowControl(objBus.Parameters[1].ParameterValue));

                //sJavaScript += string.Format("var grid = $('#{0}'); grid.hilight({{ style: {1}, rowIndex : {2} }});", GridContainer.ClientID, objBus.Parameters[2].ParameterValue, fieldIndex);
                sJavaScript += string.Format(" applyStyleToMultiRow('#{0}', {1}, {2});", GridContainer.ClientID, objBus.Parameters[2].ParameterValue, (GridRow == null ? (fieldIndex + 1) : (GridRow.RowIndex + 1)));
                

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionApplyStyleToMultiRow: " + error);
            }
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 06/Octubre/2014*/
        /*OBJETIVO: Cycle From Query: Ejecuta Acciones de Reglas de Negocio según el las filas arrojadas por un SQL Query, utilizando los valores de la misma. */
        #region
        private void DoActionCycleFromQueryBegin(BusinessRules_Actions objBus, BusinessRules_Actions[] businessRules_Actions,BusinessRules obj)
        {
            try
            {

                string P1_Cycle_Name = objBus.Parameters[0].ParameterValue;
                string P2_SQL_Query = objBus.Parameters[1].ParameterValue;

                TTDataLayerCS.BD db = new TTDataLayerCS.BD();
                SqlCommand cmd = new SqlCommand(P2_SQL_Query);
                cmd.CommandType = CommandType.Text;
                DataSet ds = db.Consulta(cmd);

                List<BusinessRules_Actions> businessRules_ActionsCycled = new List<BusinessRules_Actions>();
                bool encontrado = false;

                for (int i = 0; i < businessRules_Actions.Length; i++)
                {
                    if (businessRules_Actions[i].ActionType == TTenumBusinessRules_ActionType.CycleFromQueryEnd)
                    {
                        encontrado = false;
                        businessRules_Actions[i].ActionType = TTenumBusinessRules_ActionType.None;
                    }

                    if (encontrado)
                    {
                        BusinessRules_Actions action = new BusinessRules_Actions(businessRules_Actions[i].ActionType, businessRules_Actions[i].Parameters, businessRules_Actions[i].ActionResultType);
                        businessRules_ActionsCycled.Add(action);
                        businessRules_Actions[i].ActionType = TTenumBusinessRules_ActionType.None;

                    }

                    if (businessRules_Actions[i] == objBus)
                    {
                        encontrado = true;
                        businessRules_Actions[i].ActionType = TTenumBusinessRules_ActionType.None;
                    }
                    
                }

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    foreach (var action in businessRules_ActionsCycled)
                    {

                        BusinessRules_Actions bak = new BusinessRules_Actions(action.ActionType, action.Parameters, action.ActionResultType);
                        
                        foreach (var parameter in bak.Parameters)
                        {
                            parameter.ParameterValue = DecodingValueFromSQLQuery(parameter.ParameterValue, P1_Cycle_Name, item); 
                        }

                        DoAction(new BusinessRules_Actions[] {bak}, obj);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionCycleFromQueryBegin: " + error);
            }
        }

        private void DoActionCycleFromQueryEnd(BusinessRules_Actions objBus, BusinessRules_Actions[] businessRules_Actions, BusinessRules obj)
        {
            try
            {

                string P1_Cycle_Name = objBus.Parameters[0].ParameterValue;

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionCycleFromQueryEnd: " + error);
            }
        }

        public string DecodingValueFromSQLQuery(string text, string key, DataRow row)
        {
            String textResult = text;
            while (textResult.IndexOf(key+"[") > -1)
            {
                int xStart = textResult.IndexOf(key+"[");
                int xEnd = textResult.IndexOf("]", xStart);
                String column = textResult.Substring(xStart + (key.Length + 1), xEnd - xStart - (key.Length + 1));

                String Value = row[int.Parse(column)].ToString();

                textResult = textResult.Replace(key+"[" + column + "]", Value);
            }

            return textResult;
        }
        #endregion

        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 09/Octubre/2014*/
        /*OBJETIVO: Set TextMode To Password: Agregar el valor Password al atributo TextMode en un TextBox */
        #region
        private void DoActionSetTextModeToPassword(BusinessRules_Actions objBus)
        {
            try
            {

                string P1_TextBox_Field = objBus.Parameters[0].ParameterValue;
                
                Object ctlT = myBusinessFunctions.ControlFromDT(P1_TextBox_Field);

                if (ctlT.GetType() == typeof(TextBox))
                {
                    (ctlT as TextBox).TextMode = TextBoxMode.Password;
                    sJavaScript += string.Format("$get('{0}').type = {1};", (ctlT as TextBox).ClientID, "password");
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                frmActive.ShowAlert("DoActionSetTextModeToPassword: " + error);
            }
        }
       #endregion

	   }//End class BusinessOperations

    public class ControlBusiness
    {
        private BusinessControl field;
        private BusinessRules businessRule;

        public BusinessControl Field
        {
            get { return field; }
            set { field = value; }
        }
        public BusinessRules BusinessRule
        {
            get { return businessRule; }
            set { businessRule = value; }
        }
    }//End class ControlBusiness

    public enum TTBusinessRules_TipoPropiedad
    {
        Enabled = 1,
        Visible = 2,
        Text = 3
    }

    public enum TTBusinessRules_DoActionPropertyToComboBox
    {
        Filtrar = 1
    }

    public enum TTBusinessRules_DoActionSendMailToAccount
    {
        Cuenta = 1, //Envia a cuenta especifica
        Grupo = 2,   //Envia a Grupo de cuentas
        Campo = 3,    //Envia a correo en algun campo
        CuentaWithTemplate = 4, //Envia a cuenta especifica con un template
        GrupoWithTemplate = 5,   //Envia a Grupo de cuentas con un template
        CampoWithTemplate = 6,   //Envia a correo en algun campo con un template
        List = 7,    //Envia a lista de correos 
        ListWithTemplate = 8,//Envia a lista de correos con un template
        QueryList = 9,    //Envia a lista de correos de un query 
        QueryListWithTemplate = 10 //Envia a lista de correos con un template

    }

    public enum TTBusinessRules_TipoExecuteDB
    {
        Query = 1,
        StoreProcedure = 2
    }

    public enum TTenumBusinessRules_Alcance
    {
        None = 0,
        Process = 1,
        Field = 2
    }
    public enum TTenumBusinessRules_Operacion
    {
        None = 0,
        New = 1,
        Modification = 2,
        Consult = 3,
        Delete = 4,
        Print = 5,
        Export = 6,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
        /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
        List = 7
    }
    public enum TTenumBusinessRules_ProcessEvent
    {
        None = 0,
        BeforeSave = 1,
        AfterSave = 2,
        BeforeClose = 3,
        AfterClose = 4,
        OpenWindows = 5
    }
    public enum TTenumBusinessRules_FieldEvent
    {
        None = 0,
        LostFocus = 1,
        LostFocusAutoComplete = 2

    }
    public enum TTenumBusinessRules_ConditionOperator
    {
        None = 0,
        New = 1,
        And = 2,
        Or = 3
    }
    public enum TTenumBusinessRules_ConditionCondition
    {
        None = 0,
        Mayor = 1,
        Menor = 2,
        MayorIgual = 3,
        MenorIgual = 4,
        Igual = 5,
        Diferente = 6
    }
    public enum TTenumBusinessRules_ConditionTypeOperator1
    {
        None = 0,
        Field = 1,
        Global = 2,
        Temporal = 3,
        QuerySQL = 4
    }
    public enum TTenumBusinessRules_ConditionTypeOperator2
    {
        None = 0,
        Field = 1,
        Global = 2,
        Temporal = 3,
        Value = 4,
        QuerySQL = 5,
        Method = 6,
        JavaScript = 7,
        Vacio = 8
    }
    public enum TTenumBusinessRules_ActionType
    {
        None = 0,
	ExecuteWebService=100,
	SetValueFromWebService=101,
	FillMultiRowFromWebService=102,
	FillComboFromWebservice=103,
        Enabled = 1,
        Disabled = 2,
        Visible = 3,
        Invisible = 4,
        Obligatory = 5,
        NotObligatory = 6,
        ShowMsj = 7,
        SendMailtoAccount = 8,
        EnabledCarpet = 9,
        DisabledCarpet = 10,
        FiltrarCombo = 11,
        AsignarValor = 12,
        SendMailtoField = 13,
        SendMailtoGroup = 14,
        SendMailtoAccountWithTemplate = 15,
        SendMailtoFieldWithTemplate = 16,
        SendMailtoGroupWithTemplate = 17,
        EjecutaQuery = 18,
        SendMailtoQueryList = 19,
        SendMailtoQueryListWithTemplate = 20,
        SendMailtoList = 21,
        SendMailtoListWithTemplate = 22,
        SetValueFromQuery = 23,
        SetValueFromGlobalVariable = 24,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Noviembre/2013*/
        /*OBJETIVO: Cambiar Etiqueta Por Valor Desde Un Query.*/
        SwitchLabel = 25,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 04/Diciembre/2013*/
        /*OBJETIVO: Concatenar un Valor en una Etiqueta.*/
        ConcatenateValueOnLabel = 26, 
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Diciembre/2013*/
        /*OBJETIVO: Crear una variable de sesión y asignarle valor desde un campo control.*/
        CreateAndSetValueFromFieldToGlobalVariable = 27,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 27/Diciembre/2013*/
        /*OBJETIVO: Filtrar control comboBox en un campo multirenglón por medio de una variable de sesión.*/
        FilterComboInMultiRow = 28,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 23/Enero/2014*/
        /*OBJETIVO: Llenar filas de multirenglón desde un query.*/
        FillMultiRowFromQuery = 29,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 24/Enero/2014*/
        /*OBJETIVO: Realizar función en determinada columna de multirenglón.*/
        FunctionInMultiRowColumn = 30,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 25/Enero/2014*/
        /*OBJETIVO: Crear variable de sesión y asignarle valor desde un SQLQuery ó valor fijo.*/
        CreateAndSetValueToGlobalVariable = 31,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Marzo/2014*/
        /*OBJETIVO: Aplicar determinado filtro en una pantalla de tipo Lista.*/
        FilterListFromQuery = 32,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
        /*OBJETIVO: Ocultar una columna de un multirenglón.*/
        HideColumnInMultiRow = 33,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 14/Abril/2014*/
        /*OBJETIVO: Mostrar una columna de un multirenglón.*/
        ShowColumnInMultiRow = 34,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
        /*OBJETIVO: Hacer ReadOnly un Control.*/
        ToMakeReadOnly = 35,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
        /*OBJETIVO: Hacer Writable un Control.*/
        ToMakeWritable = 36,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
        /*OBJETIVO: Hacer Invisible una Pestaña.*/
        ToMakeInvisibleFolder = 37,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 22/Junio/2014*/
        /*OBJETIVO: Hacer Visible una Pestaña.*/
        ToMakeVisibleFolder = 38,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 26/Junio/2014*/
        /*OBJETIVO: Set Value To Cell from Query: Asignar un valor a determinada celda en determinado multirenglon. */
        SetValueToCellFromQuery = 39,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 11/Agostro/2014*/
        /*OBJETIVO: Hide Column On List: Oculta una determinada columna en la pantalla de lista. */
        HideColumnOnList = 40,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 11/Agostro/2014*/
        /*OBJETIVO: Show Column On List: Muestra una determinada columna en la pantalla de lista. */
        ShowColumnOnList = 41,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 09/Septiembre/2014*/
        /*OBJETIVO: Apply Style To Multirow: Aplica determinado estilo (style/cssClass) a un Multirenglón (Fila, Columna o Celda) */
        ApplyStyleToMultiRow = 42,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 06/Octubre/2014*/
        /*OBJETIVO: Cycle From Query: Ejecuta Acciones de Reglas de Negocio según el las filas arrojadas por un SQL Query, utilizando los valores de la misma. */
        CycleFromQueryBegin = 43,
        CycleFromQueryEnd = 44,
        /*TODO: IDCODMANUAL: RESPONSABLE: Salvador García Serrano FECHA: 09/Octubre/2014*/
        /*OBJETIVO: Set TextMode To Password: Agregar el valor Password al atributo TextMode en un TextBox */
        SetTextModeToPassword = 45
    }
    public enum TTenumBusinessRules_ActionResultType
    {
        None = 0,
        Follow = 1,
        Break = 2
    }
    public enum TTenumBusinessRules_ActionParameterType
    {
        None = 0,
        DatoID = 1,
        Grupo = 2,
        Carpeta = 3,
        SQLQuery = 4,
        SQLStore = 5,
        Texto = 6,
        GrupoFuncional = 7,
        TextNoDecoding = 8

    }

    public class TTSendSMTPMail
    {
        private string sMTPServer;
        private int sMTPPort;
        private string sMTPUsername;
        private string sMTPPassword;
        private string mailFrom;
        private string mailTo;
        private string mailToCC = string.Empty;
        private string mailSubject;
        private string mailBody;

        public string SMTPServer
        {
            get { return sMTPServer; }
            set { string sMTPServer = value; }
        }

        public int SMTPPort
        {
            get { return sMTPPort; }
            set { sMTPPort = value; }
        }
        public string SMTPUsername
        {
            get { return sMTPUsername; }
            set { sMTPUsername = value; }
        }
        public string SMTPPassword
        {
            get { return sMTPPassword; }
            set { sMTPPassword = value; }
        }
        public string MailFrom
        {
            get { return mailFrom; }
            set { mailFrom = value; }
        }
        public string MailTo
        {
            get { return mailTo; }
            set { mailTo = value; }
        }
        public string MailToCC
        {
            get { return mailToCC; }
            set { mailToCC = value; }
        }
        public string MailSubject
        {
            get { return mailSubject; }
            set { mailSubject = value; }
        }
        public string MailBody
        {
            get { return mailBody; }
            set { mailBody = value; }
        }

        public TTSendSMTPMail()
        {
        }

        public TTSendSMTPMail(string _sMTPServer, int _sMTPPort, string _sMTPUsername, string _sMTPPassword)
        {
            sMTPServer = _sMTPServer;
            sMTPPort = _sMTPPort;
            sMTPUsername = _sMTPUsername;
            sMTPPassword = _sMTPPassword;
        }

        public void Send()
        {
            try
            {


                mailBody = mailBody.Replace("á", "&aacute;");
                mailBody = mailBody.Replace("é", "&eacute;");
                mailBody = mailBody.Replace("í", "&iacute;");
                mailBody = mailBody.Replace("ó", "&oacute;");
                mailBody = mailBody.Replace("ú", "&uacute;");
                mailBody = mailBody.Replace("ñ", "&ntilde;");
                mailBody = mailBody.Replace("Á", "&Aacute;");
                mailBody = mailBody.Replace("É", "&Eacute;");
                mailBody = mailBody.Replace("Í", "&Iacute;");
                mailBody = mailBody.Replace("Ó", "&Oacute;");
                mailBody = mailBody.Replace("Ú", "&Uacute;");
                mailBody = mailBody.Replace("Ñ", "&Ntilde;");

                MailMessage message = new MailMessage();
                message.From = new MailAddress(MailFrom);
                message.To.Add(mailTo);
                if (mailToCC != string.Empty)
                    message.CC.Add(mailToCC);
                message.Subject = mailSubject;
                message.Body = mailBody;
                message.BodyEncoding = System.Text.Encoding.ASCII;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient(sMTPServer, sMTPPort);
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                NetworkCredential MyCredentials = new NetworkCredential(sMTPUsername, sMTPPassword);
                smtp.Credentials = MyCredentials;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                //GuardaIntentoCorreo(Asunto, CuerpoMensaje, Destinatario, ConCopia, ex.Message.ToString(), 1);
            }
        }

        public void SendLocal()
        {
            try
            {
                mailBody = mailBody.Replace("á", "&aacute");
                mailBody = mailBody.Replace("é", "&eacute");
                mailBody = mailBody.Replace("í", "&iacute");
                mailBody = mailBody.Replace("ó", "&oacute");
                mailBody = mailBody.Replace("ú", "&uacute");
                mailBody = mailBody.Replace("ñ", "&ntilde");
                mailBody = mailBody.Replace("Á", "&Aacute");
                mailBody = mailBody.Replace("É", "&Eacute");
                mailBody = mailBody.Replace("Í", "&Iacute");
                mailBody = mailBody.Replace("Ó", "&Oacute");
                mailBody = mailBody.Replace("Ú", "&Uacute");
                mailBody = mailBody.Replace("Ñ", "&Ntilde");

                MailMessage message = new MailMessage();
                message.From = new MailAddress(MailFrom);
                message.To.Add(mailTo);
                if (mailTo != string.Empty)
                    message.CC.Add(mailTo);
                message.Subject = mailSubject;
                message.Body = mailBody;
                message.BodyEncoding = System.Text.Encoding.ASCII;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient("localhost");
                smtp.Send(message);
            }
            catch
            {
            }
        }
    }//End class TTSendSMTPMail

}//End namespace App_Code.TTBusinessRules



























