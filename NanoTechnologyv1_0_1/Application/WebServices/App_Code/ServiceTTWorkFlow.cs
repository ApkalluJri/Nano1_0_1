using System;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using AjaxControlToolkit;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]
public class objectBussinessTTWorkFlow : System.Web.Services.WebService
{
    public int iProcess = 15799;
    private TTTraductor.Traductor MyTraductor;
    public TTWorkFlowCS.objectBussinessTTWorkFlow myTTWorkFlow = new TTWorkFlowCS.objectBussinessTTWorkFlow();

    [WebMethod]
    public Int32 SelCount()
    {
        return myTTWorkFlow.SelCount();
    }
    [WebMethod]
    public DataSet SelAll(Boolean ConRelaciones)
    {
        return myTTWorkFlow.SelAll(ConRelaciones);
    }
    [WebMethod]
    public DataSet SelAllwithFilters(Boolean ConRelaciones, TTWorkFlowCS.TTWorkFlowFilters[] myFilters)
    {
        myTTWorkFlow.Filters = myFilters;
        return myTTWorkFlow.SelAll(ConRelaciones);
        myTTWorkFlow.Filters = null;
    }
    [WebMethod]
    public DataSet SelAllpart(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32)
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(myTTWorkFlow.SelAll(ConRelaciones, CurrentRecordInt32, RecordsDisplayedInt32));
        return ds;
    }
    [WebMethod]
    public void Insert(TTSecurity.GlobalData globalInfo, String varNombre, String varDescripcion, String varObjetivo, int? varEstatus, int?[] varFasesNumero_de_Fase, String[] varFasesNombre, int?[] varFasesTipo_de_Fase, int?[] varFasesTipo_de_Distribucion_de_Trabajo, int?[] varFasesTipo_de_Control_de_Flujo, int?[] varFasesEstatus_de_Fase, int?[] varEstadosFase, int?[] varEstadosProceso, int?[] varEstadosCampo, int?[] varEstadosCodigo_Estado, String[] varEstadosNombre, int?[] varEstadosValor, String[] varEstadosTexto, int?[] varMatriz_de_EstadosFase, int?[] varMatriz_de_EstadosEstado, int?[] varMatriz_de_EstadosProceso, int?[] varMatriz_de_EstadosCampo, int?[] varMatriz_de_EstadosVisible, int?[] varMatriz_de_EstadosObligatorio, int?[] varMatriz_de_EstadosSolo_Lectura, String[] varMatriz_de_EstadosEtiqueta, String[] varMatriz_de_EstadosValor_por_Defecto, String[] varMatriz_de_EstadosTexto_de_Ayuda, int?[] varRoles_por_EstadoFase, int?[] varRoles_por_EstadoEstado, int?[] varRoles_por_EstadoRol_de_Usuario, int?[] varRoles_por_EstadoTransicion_de_Fase, int?[] varRoles_por_EstadoPermiso_Consultar, int?[] varRoles_por_EstadoPermiso_Nuevo, int?[] varRoles_por_EstadoPermiso_Modificar, int?[] varRoles_por_EstadoPermiso_Eliminar, int?[] varRoles_por_EstadoPermiso_Exportar, int?[] varRoles_por_EstadoPermiso_Imprimir, int?[] varRoles_por_EstadoPermiso_Configuracion, int?[] varInformacion_por_EstadoFase, int?[] varInformacion_por_EstadoEstado, int?[] varInformacion_por_EstadoProceso, int?[] varInformacion_por_EstadoCarpeta, int?[] varInformacion_por_EstadoVisible, int?[] varInformacion_por_EstadoSolo_Lectura, int?[] varInformacion_por_EstadoObligatorios, String[] varInformacion_por_EstadoEtiqueta, int?[] varCondiciones_por_EstadoFase, int?[] varCondiciones_por_EstadoEstado, int?[] varCondiciones_por_EstadoOperador_de_Condicion, int?[] varCondiciones_por_EstadoProceso, int?[] varCondiciones_por_EstadoCampo, int?[] varCondiciones_por_EstadoCondicion, int?[] varCondiciones_por_EstadoOperador, String[] varCondiciones_por_EstadoValor_Operador, int?[] varCondiciones_por_EstadoPrioridad)
    {
        TTWorkFlowCS.objectBussinessTTWorkFlow  myTTWorkFlow= new TTWorkFlowCS.objectBussinessTTWorkFlow();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow.Nombre = varNombre;
        myTTWorkFlow.Descripcion = varDescripcion;
        myTTWorkFlow.Objetivo = varObjetivo;
        myTTWorkFlow.Estatus = varEstatus;
            if(varFasesNumero_de_Fase != null)
            {
                myTTWorkFlow.Fases = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases[varFasesNumero_de_Fase.Length];
                for (int i = 0; i < varFasesNumero_de_Fase.Length; i++)
                {
                    myTTWorkFlow.Fases[i] = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases();
                myTTWorkFlow.Fases[i].Numero_de_Fase = varFasesNumero_de_Fase[i];
                myTTWorkFlow.Fases[i].Nombre = varFasesNombre[i];
                myTTWorkFlow.Fases[i].Tipo_de_Fase = varFasesTipo_de_Fase[i];
                myTTWorkFlow.Fases[i].Tipo_de_Distribucion_de_Trabajo = varFasesTipo_de_Distribucion_de_Trabajo[i];
                myTTWorkFlow.Fases[i].Tipo_de_Control_de_Flujo = varFasesTipo_de_Control_de_Flujo[i];
                myTTWorkFlow.Fases[i].Estatus_de_Fase = varFasesEstatus_de_Fase[i];

                }
            }
            if(varEstadosFase != null)
            {
                myTTWorkFlow.Estados = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados[varEstadosFase.Length];
                for (int i = 0; i < varEstadosFase.Length; i++)
                {
                    myTTWorkFlow.Estados[i] = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados();
                myTTWorkFlow.Estados[i].Fase = varEstadosFase[i];
                myTTWorkFlow.Estados[i].Proceso = varEstadosProceso[i];
                myTTWorkFlow.Estados[i].Campo = varEstadosCampo[i];
                myTTWorkFlow.Estados[i].Codigo_Estado = varEstadosCodigo_Estado[i];
                myTTWorkFlow.Estados[i].Nombre = varEstadosNombre[i];
                myTTWorkFlow.Estados[i].Valor = varEstadosValor[i];
                myTTWorkFlow.Estados[i].Texto = varEstadosTexto[i];

                }
            }
            if(varMatriz_de_EstadosFase != null)
            {
                myTTWorkFlow.Matriz_de_Estados = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados[varMatriz_de_EstadosFase.Length];
                for (int i = 0; i < varMatriz_de_EstadosFase.Length; i++)
                {
                    myTTWorkFlow.Matriz_de_Estados[i] = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados();
                myTTWorkFlow.Matriz_de_Estados[i].Fase = varMatriz_de_EstadosFase[i];
                myTTWorkFlow.Matriz_de_Estados[i].Estado = varMatriz_de_EstadosEstado[i];
                myTTWorkFlow.Matriz_de_Estados[i].Proceso = varMatriz_de_EstadosProceso[i];
                myTTWorkFlow.Matriz_de_Estados[i].Campo = varMatriz_de_EstadosCampo[i];
                myTTWorkFlow.Matriz_de_Estados[i].Visible = varMatriz_de_EstadosVisible[i];
                myTTWorkFlow.Matriz_de_Estados[i].Obligatorio = varMatriz_de_EstadosObligatorio[i];
                myTTWorkFlow.Matriz_de_Estados[i].Solo_Lectura = varMatriz_de_EstadosSolo_Lectura[i];
                myTTWorkFlow.Matriz_de_Estados[i].Etiqueta = varMatriz_de_EstadosEtiqueta[i];
                myTTWorkFlow.Matriz_de_Estados[i].Valor_por_Defecto = varMatriz_de_EstadosValor_por_Defecto[i];
                myTTWorkFlow.Matriz_de_Estados[i].Texto_de_Ayuda = varMatriz_de_EstadosTexto_de_Ayuda[i];

                }
            }
            if(varRoles_por_EstadoFase != null)
            {
                myTTWorkFlow.Roles_por_Estado = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado[varRoles_por_EstadoFase.Length];
                for (int i = 0; i < varRoles_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Roles_por_Estado[i] = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado();
                myTTWorkFlow.Roles_por_Estado[i].Fase = varRoles_por_EstadoFase[i];
                myTTWorkFlow.Roles_por_Estado[i].Estado = varRoles_por_EstadoEstado[i];
                myTTWorkFlow.Roles_por_Estado[i].Rol_de_Usuario = varRoles_por_EstadoRol_de_Usuario[i];
                myTTWorkFlow.Roles_por_Estado[i].Transicion_de_Fase = varRoles_por_EstadoTransicion_de_Fase[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Consultar = varRoles_por_EstadoPermiso_Consultar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Nuevo = varRoles_por_EstadoPermiso_Nuevo[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Modificar = varRoles_por_EstadoPermiso_Modificar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Eliminar = varRoles_por_EstadoPermiso_Eliminar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Exportar = varRoles_por_EstadoPermiso_Exportar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Imprimir = varRoles_por_EstadoPermiso_Imprimir[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Configuracion = varRoles_por_EstadoPermiso_Configuracion[i];

                }
            }
            if(varInformacion_por_EstadoFase != null)
            {
                myTTWorkFlow.Informacion_por_Estado = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado[varInformacion_por_EstadoFase.Length];
                for (int i = 0; i < varInformacion_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Informacion_por_Estado[i] = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado();
                myTTWorkFlow.Informacion_por_Estado[i].Fase = varInformacion_por_EstadoFase[i];
                myTTWorkFlow.Informacion_por_Estado[i].Estado = varInformacion_por_EstadoEstado[i];
                myTTWorkFlow.Informacion_por_Estado[i].Proceso = varInformacion_por_EstadoProceso[i];
                myTTWorkFlow.Informacion_por_Estado[i].Carpeta = varInformacion_por_EstadoCarpeta[i];
                myTTWorkFlow.Informacion_por_Estado[i].Visible = varInformacion_por_EstadoVisible[i];
                myTTWorkFlow.Informacion_por_Estado[i].Solo_Lectura = varInformacion_por_EstadoSolo_Lectura[i];
                myTTWorkFlow.Informacion_por_Estado[i].Obligatorios = varInformacion_por_EstadoObligatorios[i];
                myTTWorkFlow.Informacion_por_Estado[i].Etiqueta = varInformacion_por_EstadoEtiqueta[i];

                }
            }
            if(varCondiciones_por_EstadoFase != null)
            {
                myTTWorkFlow.Condiciones_por_Estado = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado[varCondiciones_por_EstadoFase.Length];
                for (int i = 0; i < varCondiciones_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Condiciones_por_Estado[i] = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado();
                myTTWorkFlow.Condiciones_por_Estado[i].Fase = varCondiciones_por_EstadoFase[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Estado = varCondiciones_por_EstadoEstado[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Operador_de_Condicion = varCondiciones_por_EstadoOperador_de_Condicion[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Proceso = varCondiciones_por_EstadoProceso[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Campo = varCondiciones_por_EstadoCampo[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Condicion = varCondiciones_por_EstadoCondicion[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Operador = varCondiciones_por_EstadoOperador[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Valor_Operador = varCondiciones_por_EstadoValor_Operador[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Prioridad = varCondiciones_por_EstadoPrioridad[i];

                }
            }

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow, out sMsg))
        {
            throw new Exception(sMsg);
        }
        myTTWorkFlow.Insert(globalInfo, dr);
    }
    [WebMethod]
    public object InsertWithReturnValue(TTSecurity.GlobalData globalInfo, String varNombre, String varDescripcion, String varObjetivo, int? varEstatus, int?[] varFasesNumero_de_Fase, String[] varFasesNombre, int?[] varFasesTipo_de_Fase, int?[] varFasesTipo_de_Distribucion_de_Trabajo, int?[] varFasesTipo_de_Control_de_Flujo, int?[] varFasesEstatus_de_Fase, int?[] varEstadosFase, int?[] varEstadosProceso, int?[] varEstadosCampo, int?[] varEstadosCodigo_Estado, String[] varEstadosNombre, int?[] varEstadosValor, String[] varEstadosTexto, int?[] varMatriz_de_EstadosFase, int?[] varMatriz_de_EstadosEstado, int?[] varMatriz_de_EstadosProceso, int?[] varMatriz_de_EstadosCampo, int?[] varMatriz_de_EstadosVisible, int?[] varMatriz_de_EstadosObligatorio, int?[] varMatriz_de_EstadosSolo_Lectura, String[] varMatriz_de_EstadosEtiqueta, String[] varMatriz_de_EstadosValor_por_Defecto, String[] varMatriz_de_EstadosTexto_de_Ayuda, int?[] varRoles_por_EstadoFase, int?[] varRoles_por_EstadoEstado, int?[] varRoles_por_EstadoRol_de_Usuario, int?[] varRoles_por_EstadoTransicion_de_Fase, int?[] varRoles_por_EstadoPermiso_Consultar, int?[] varRoles_por_EstadoPermiso_Nuevo, int?[] varRoles_por_EstadoPermiso_Modificar, int?[] varRoles_por_EstadoPermiso_Eliminar, int?[] varRoles_por_EstadoPermiso_Exportar, int?[] varRoles_por_EstadoPermiso_Imprimir, int?[] varRoles_por_EstadoPermiso_Configuracion, int?[] varInformacion_por_EstadoFase, int?[] varInformacion_por_EstadoEstado, int?[] varInformacion_por_EstadoProceso, int?[] varInformacion_por_EstadoCarpeta, int?[] varInformacion_por_EstadoVisible, int?[] varInformacion_por_EstadoSolo_Lectura, int?[] varInformacion_por_EstadoObligatorios, String[] varInformacion_por_EstadoEtiqueta, int?[] varCondiciones_por_EstadoFase, int?[] varCondiciones_por_EstadoEstado, int?[] varCondiciones_por_EstadoOperador_de_Condicion, int?[] varCondiciones_por_EstadoProceso, int?[] varCondiciones_por_EstadoCampo, int?[] varCondiciones_por_EstadoCondicion, int?[] varCondiciones_por_EstadoOperador, String[] varCondiciones_por_EstadoValor_Operador, int?[] varCondiciones_por_EstadoPrioridad)
    {
        TTWorkFlowCS.objectBussinessTTWorkFlow  myTTWorkFlow= new TTWorkFlowCS.objectBussinessTTWorkFlow();
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        MyTraductor= new TTTraductor.Traductor(globalInfo.Language.GetHashCode());
        myTTWorkFlow.Nombre = varNombre;
        myTTWorkFlow.Descripcion = varDescripcion;
        myTTWorkFlow.Objetivo = varObjetivo;
        myTTWorkFlow.Estatus = varEstatus;
            if(varFasesNumero_de_Fase != null)
            {
                myTTWorkFlow.Fases = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases[varFasesNumero_de_Fase.Length];
                for (int i = 0; i < varFasesNumero_de_Fase.Length; i++)
                {
                    myTTWorkFlow.Fases[i] = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases();
                myTTWorkFlow.Fases[i].Numero_de_Fase = varFasesNumero_de_Fase[i];
                myTTWorkFlow.Fases[i].Nombre = varFasesNombre[i];
                myTTWorkFlow.Fases[i].Tipo_de_Fase = varFasesTipo_de_Fase[i];
                myTTWorkFlow.Fases[i].Tipo_de_Distribucion_de_Trabajo = varFasesTipo_de_Distribucion_de_Trabajo[i];
                myTTWorkFlow.Fases[i].Tipo_de_Control_de_Flujo = varFasesTipo_de_Control_de_Flujo[i];
                myTTWorkFlow.Fases[i].Estatus_de_Fase = varFasesEstatus_de_Fase[i];

                }
            }
            if(varEstadosFase != null)
            {
                myTTWorkFlow.Estados = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados[varEstadosFase.Length];
                for (int i = 0; i < varEstadosFase.Length; i++)
                {
                    myTTWorkFlow.Estados[i] = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados();
                myTTWorkFlow.Estados[i].Fase = varEstadosFase[i];
                myTTWorkFlow.Estados[i].Proceso = varEstadosProceso[i];
                myTTWorkFlow.Estados[i].Campo = varEstadosCampo[i];
                myTTWorkFlow.Estados[i].Codigo_Estado = varEstadosCodigo_Estado[i];
                myTTWorkFlow.Estados[i].Nombre = varEstadosNombre[i];
                myTTWorkFlow.Estados[i].Valor = varEstadosValor[i];
                myTTWorkFlow.Estados[i].Texto = varEstadosTexto[i];

                }
            }
            if(varMatriz_de_EstadosFase != null)
            {
                myTTWorkFlow.Matriz_de_Estados = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados[varMatriz_de_EstadosFase.Length];
                for (int i = 0; i < varMatriz_de_EstadosFase.Length; i++)
                {
                    myTTWorkFlow.Matriz_de_Estados[i] = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados();
                myTTWorkFlow.Matriz_de_Estados[i].Fase = varMatriz_de_EstadosFase[i];
                myTTWorkFlow.Matriz_de_Estados[i].Estado = varMatriz_de_EstadosEstado[i];
                myTTWorkFlow.Matriz_de_Estados[i].Proceso = varMatriz_de_EstadosProceso[i];
                myTTWorkFlow.Matriz_de_Estados[i].Campo = varMatriz_de_EstadosCampo[i];
                myTTWorkFlow.Matriz_de_Estados[i].Visible = varMatriz_de_EstadosVisible[i];
                myTTWorkFlow.Matriz_de_Estados[i].Obligatorio = varMatriz_de_EstadosObligatorio[i];
                myTTWorkFlow.Matriz_de_Estados[i].Solo_Lectura = varMatriz_de_EstadosSolo_Lectura[i];
                myTTWorkFlow.Matriz_de_Estados[i].Etiqueta = varMatriz_de_EstadosEtiqueta[i];
                myTTWorkFlow.Matriz_de_Estados[i].Valor_por_Defecto = varMatriz_de_EstadosValor_por_Defecto[i];
                myTTWorkFlow.Matriz_de_Estados[i].Texto_de_Ayuda = varMatriz_de_EstadosTexto_de_Ayuda[i];

                }
            }
            if(varRoles_por_EstadoFase != null)
            {
                myTTWorkFlow.Roles_por_Estado = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado[varRoles_por_EstadoFase.Length];
                for (int i = 0; i < varRoles_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Roles_por_Estado[i] = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado();
                myTTWorkFlow.Roles_por_Estado[i].Fase = varRoles_por_EstadoFase[i];
                myTTWorkFlow.Roles_por_Estado[i].Estado = varRoles_por_EstadoEstado[i];
                myTTWorkFlow.Roles_por_Estado[i].Rol_de_Usuario = varRoles_por_EstadoRol_de_Usuario[i];
                myTTWorkFlow.Roles_por_Estado[i].Transicion_de_Fase = varRoles_por_EstadoTransicion_de_Fase[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Consultar = varRoles_por_EstadoPermiso_Consultar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Nuevo = varRoles_por_EstadoPermiso_Nuevo[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Modificar = varRoles_por_EstadoPermiso_Modificar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Eliminar = varRoles_por_EstadoPermiso_Eliminar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Exportar = varRoles_por_EstadoPermiso_Exportar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Imprimir = varRoles_por_EstadoPermiso_Imprimir[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Configuracion = varRoles_por_EstadoPermiso_Configuracion[i];

                }
            }
            if(varInformacion_por_EstadoFase != null)
            {
                myTTWorkFlow.Informacion_por_Estado = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado[varInformacion_por_EstadoFase.Length];
                for (int i = 0; i < varInformacion_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Informacion_por_Estado[i] = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado();
                myTTWorkFlow.Informacion_por_Estado[i].Fase = varInformacion_por_EstadoFase[i];
                myTTWorkFlow.Informacion_por_Estado[i].Estado = varInformacion_por_EstadoEstado[i];
                myTTWorkFlow.Informacion_por_Estado[i].Proceso = varInformacion_por_EstadoProceso[i];
                myTTWorkFlow.Informacion_por_Estado[i].Carpeta = varInformacion_por_EstadoCarpeta[i];
                myTTWorkFlow.Informacion_por_Estado[i].Visible = varInformacion_por_EstadoVisible[i];
                myTTWorkFlow.Informacion_por_Estado[i].Solo_Lectura = varInformacion_por_EstadoSolo_Lectura[i];
                myTTWorkFlow.Informacion_por_Estado[i].Obligatorios = varInformacion_por_EstadoObligatorios[i];
                myTTWorkFlow.Informacion_por_Estado[i].Etiqueta = varInformacion_por_EstadoEtiqueta[i];

                }
            }
            if(varCondiciones_por_EstadoFase != null)
            {
                myTTWorkFlow.Condiciones_por_Estado = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado[varCondiciones_por_EstadoFase.Length];
                for (int i = 0; i < varCondiciones_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Condiciones_por_Estado[i] = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado();
                myTTWorkFlow.Condiciones_por_Estado[i].Fase = varCondiciones_por_EstadoFase[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Estado = varCondiciones_por_EstadoEstado[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Operador_de_Condicion = varCondiciones_por_EstadoOperador_de_Condicion[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Proceso = varCondiciones_por_EstadoProceso[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Campo = varCondiciones_por_EstadoCampo[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Condicion = varCondiciones_por_EstadoCondicion[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Operador = varCondiciones_por_EstadoOperador[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Valor_Operador = varCondiciones_por_EstadoValor_Operador[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Prioridad = varCondiciones_por_EstadoPrioridad[i];

                }
            }

        String sMsg = "";
        if (!ValidaDataToSave(myTTWorkFlow, out sMsg))
        {
            throw new Exception(sMsg);
        }
        if (!ValidaDataDuplication(myTTWorkFlow, out sMsg))
        {
            throw new Exception(sMsg);
        }
        return myTTWorkFlow.InsertWithReturnValue(globalInfo, dr);
    }    
    [WebMethod]
    public void Update(TTSecurity.GlobalData globalInfo, int? varFolio, String varNombre, String varDescripcion, String varObjetivo, int? varEstatus, int?[] varFasesWorkFlow, int?[] varFasesFolio, int?[] varFasesNumero_de_Fase, String[] varFasesNombre, int?[] varFasesTipo_de_Fase, int?[] varFasesTipo_de_Distribucion_de_Trabajo, int?[] varFasesTipo_de_Control_de_Flujo, int?[] varFasesEstatus_de_Fase, int?[] varEstadosTTWorkFlow, int?[] varEstadosFolio, int?[] varEstadosFase, int?[] varEstadosProceso, int?[] varEstadosCampo, int?[] varEstadosCodigo_Estado, String[] varEstadosNombre, int?[] varEstadosValor, String[] varEstadosTexto, int?[] varMatriz_de_EstadosTTWorkFlow, int?[] varMatriz_de_EstadosFolio, int?[] varMatriz_de_EstadosFase, int?[] varMatriz_de_EstadosEstado, int?[] varMatriz_de_EstadosProceso, int?[] varMatriz_de_EstadosCampo, int?[] varMatriz_de_EstadosVisible, int?[] varMatriz_de_EstadosObligatorio, int?[] varMatriz_de_EstadosSolo_Lectura, String[] varMatriz_de_EstadosEtiqueta, String[] varMatriz_de_EstadosValor_por_Defecto, String[] varMatriz_de_EstadosTexto_de_Ayuda, int?[] varRoles_por_EstadoTTWorkFlow, int?[] varRoles_por_EstadoFolio, int?[] varRoles_por_EstadoFase, int?[] varRoles_por_EstadoEstado, int?[] varRoles_por_EstadoRol_de_Usuario, int?[] varRoles_por_EstadoTransicion_de_Fase, int?[] varRoles_por_EstadoPermiso_Consultar, int?[] varRoles_por_EstadoPermiso_Nuevo, int?[] varRoles_por_EstadoPermiso_Modificar, int?[] varRoles_por_EstadoPermiso_Eliminar, int?[] varRoles_por_EstadoPermiso_Exportar, int?[] varRoles_por_EstadoPermiso_Imprimir, int?[] varRoles_por_EstadoPermiso_Configuracion, int?[] varInformacion_por_EstadoTTWorkFlow, int?[] varInformacion_por_EstadoFolio, int?[] varInformacion_por_EstadoFase, int?[] varInformacion_por_EstadoEstado, int?[] varInformacion_por_EstadoProceso, int?[] varInformacion_por_EstadoCarpeta, int?[] varInformacion_por_EstadoVisible, int?[] varInformacion_por_EstadoSolo_Lectura, int?[] varInformacion_por_EstadoObligatorios, String[] varInformacion_por_EstadoEtiqueta, int?[] varCondiciones_por_EstadoTTWorkFlow, int?[] varCondiciones_por_EstadoFolio, int?[] varCondiciones_por_EstadoFase, int?[] varCondiciones_por_EstadoEstado, int?[] varCondiciones_por_EstadoOperador_de_Condicion, int?[] varCondiciones_por_EstadoProceso, int?[] varCondiciones_por_EstadoCampo, int?[] varCondiciones_por_EstadoCondicion, int?[] varCondiciones_por_EstadoOperador, String[] varCondiciones_por_EstadoValor_Operador, int?[] varCondiciones_por_EstadoPrioridad)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
        myTTWorkFlow.Folio = varFolio;
        myTTWorkFlow.Nombre = varNombre;
        myTTWorkFlow.Descripcion = varDescripcion;
        myTTWorkFlow.Objetivo = varObjetivo;
        myTTWorkFlow.Estatus = varEstatus;
            if(varFasesNumero_de_Fase != null)
            {
                myTTWorkFlow.Fases = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases[varFasesNumero_de_Fase.Length];
                for (int i = 0; i < varFasesNumero_de_Fase.Length; i++)
                {
                    myTTWorkFlow.Fases[i] = new TTWorkFlow_FasesCS.objectBussinessTTWorkFlow_Fases();
                myTTWorkFlow.Fases[i].WorkFlow = varFasesWorkFlow[i];
                myTTWorkFlow.Fases[i].Folio = varFasesFolio[i];
                myTTWorkFlow.Fases[i].Numero_de_Fase = varFasesNumero_de_Fase[i];
                myTTWorkFlow.Fases[i].Nombre = varFasesNombre[i];
                myTTWorkFlow.Fases[i].Tipo_de_Fase = varFasesTipo_de_Fase[i];
                myTTWorkFlow.Fases[i].Tipo_de_Distribucion_de_Trabajo = varFasesTipo_de_Distribucion_de_Trabajo[i];
                myTTWorkFlow.Fases[i].Tipo_de_Control_de_Flujo = varFasesTipo_de_Control_de_Flujo[i];
                myTTWorkFlow.Fases[i].Estatus_de_Fase = varFasesEstatus_de_Fase[i];

                }
            }
            if(varEstadosFase != null)
            {
                myTTWorkFlow.Estados = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados[varEstadosFase.Length];
                for (int i = 0; i < varEstadosFase.Length; i++)
                {
                    myTTWorkFlow.Estados[i] = new TTWorkFlow_EstadosCS.objectBussinessTTWorkFlow_Estados();
                myTTWorkFlow.Estados[i].TTWorkFlow = varEstadosTTWorkFlow[i];
                myTTWorkFlow.Estados[i].Folio = varEstadosFolio[i];
                myTTWorkFlow.Estados[i].Fase = varEstadosFase[i];
                myTTWorkFlow.Estados[i].Proceso = varEstadosProceso[i];
                myTTWorkFlow.Estados[i].Campo = varEstadosCampo[i];
                myTTWorkFlow.Estados[i].Codigo_Estado = varEstadosCodigo_Estado[i];
                myTTWorkFlow.Estados[i].Nombre = varEstadosNombre[i];
                myTTWorkFlow.Estados[i].Valor = varEstadosValor[i];
                myTTWorkFlow.Estados[i].Texto = varEstadosTexto[i];

                }
            }
            if(varMatriz_de_EstadosFase != null)
            {
                myTTWorkFlow.Matriz_de_Estados = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados[varMatriz_de_EstadosFase.Length];
                for (int i = 0; i < varMatriz_de_EstadosFase.Length; i++)
                {
                    myTTWorkFlow.Matriz_de_Estados[i] = new TTWorkFlow_Matriz_de_EstadosCS.objectBussinessTTWorkFlow_Matriz_de_Estados();
                myTTWorkFlow.Matriz_de_Estados[i].TTWorkFlow = varMatriz_de_EstadosTTWorkFlow[i];
                myTTWorkFlow.Matriz_de_Estados[i].Folio = varMatriz_de_EstadosFolio[i];
                myTTWorkFlow.Matriz_de_Estados[i].Fase = varMatriz_de_EstadosFase[i];
                myTTWorkFlow.Matriz_de_Estados[i].Estado = varMatriz_de_EstadosEstado[i];
                myTTWorkFlow.Matriz_de_Estados[i].Proceso = varMatriz_de_EstadosProceso[i];
                myTTWorkFlow.Matriz_de_Estados[i].Campo = varMatriz_de_EstadosCampo[i];
                myTTWorkFlow.Matriz_de_Estados[i].Visible = varMatriz_de_EstadosVisible[i];
                myTTWorkFlow.Matriz_de_Estados[i].Obligatorio = varMatriz_de_EstadosObligatorio[i];
                myTTWorkFlow.Matriz_de_Estados[i].Solo_Lectura = varMatriz_de_EstadosSolo_Lectura[i];
                myTTWorkFlow.Matriz_de_Estados[i].Etiqueta = varMatriz_de_EstadosEtiqueta[i];
                myTTWorkFlow.Matriz_de_Estados[i].Valor_por_Defecto = varMatriz_de_EstadosValor_por_Defecto[i];
                myTTWorkFlow.Matriz_de_Estados[i].Texto_de_Ayuda = varMatriz_de_EstadosTexto_de_Ayuda[i];

                }
            }
            if(varRoles_por_EstadoFase != null)
            {
                myTTWorkFlow.Roles_por_Estado = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado[varRoles_por_EstadoFase.Length];
                for (int i = 0; i < varRoles_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Roles_por_Estado[i] = new TTWorkFlow_Roles_por_EstadoCS.objectBussinessTTWorkFlow_Roles_por_Estado();
                myTTWorkFlow.Roles_por_Estado[i].TTWorkFlow = varRoles_por_EstadoTTWorkFlow[i];
                myTTWorkFlow.Roles_por_Estado[i].Folio = varRoles_por_EstadoFolio[i];
                myTTWorkFlow.Roles_por_Estado[i].Fase = varRoles_por_EstadoFase[i];
                myTTWorkFlow.Roles_por_Estado[i].Estado = varRoles_por_EstadoEstado[i];
                myTTWorkFlow.Roles_por_Estado[i].Rol_de_Usuario = varRoles_por_EstadoRol_de_Usuario[i];
                myTTWorkFlow.Roles_por_Estado[i].Transicion_de_Fase = varRoles_por_EstadoTransicion_de_Fase[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Consultar = varRoles_por_EstadoPermiso_Consultar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Nuevo = varRoles_por_EstadoPermiso_Nuevo[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Modificar = varRoles_por_EstadoPermiso_Modificar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Eliminar = varRoles_por_EstadoPermiso_Eliminar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Exportar = varRoles_por_EstadoPermiso_Exportar[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Imprimir = varRoles_por_EstadoPermiso_Imprimir[i];
                myTTWorkFlow.Roles_por_Estado[i].Permiso_Configuracion = varRoles_por_EstadoPermiso_Configuracion[i];

                }
            }
            if(varInformacion_por_EstadoFase != null)
            {
                myTTWorkFlow.Informacion_por_Estado = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado[varInformacion_por_EstadoFase.Length];
                for (int i = 0; i < varInformacion_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Informacion_por_Estado[i] = new TTWorkFlow_Informacion_por_EstadoCS.objectBussinessTTWorkFlow_Informacion_por_Estado();
                myTTWorkFlow.Informacion_por_Estado[i].TTWorkFlow = varInformacion_por_EstadoTTWorkFlow[i];
                myTTWorkFlow.Informacion_por_Estado[i].Folio = varInformacion_por_EstadoFolio[i];
                myTTWorkFlow.Informacion_por_Estado[i].Fase = varInformacion_por_EstadoFase[i];
                myTTWorkFlow.Informacion_por_Estado[i].Estado = varInformacion_por_EstadoEstado[i];
                myTTWorkFlow.Informacion_por_Estado[i].Proceso = varInformacion_por_EstadoProceso[i];
                myTTWorkFlow.Informacion_por_Estado[i].Carpeta = varInformacion_por_EstadoCarpeta[i];
                myTTWorkFlow.Informacion_por_Estado[i].Visible = varInformacion_por_EstadoVisible[i];
                myTTWorkFlow.Informacion_por_Estado[i].Solo_Lectura = varInformacion_por_EstadoSolo_Lectura[i];
                myTTWorkFlow.Informacion_por_Estado[i].Obligatorios = varInformacion_por_EstadoObligatorios[i];
                myTTWorkFlow.Informacion_por_Estado[i].Etiqueta = varInformacion_por_EstadoEtiqueta[i];

                }
            }
            if(varCondiciones_por_EstadoFase != null)
            {
                myTTWorkFlow.Condiciones_por_Estado = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado[varCondiciones_por_EstadoFase.Length];
                for (int i = 0; i < varCondiciones_por_EstadoFase.Length; i++)
                {
                    myTTWorkFlow.Condiciones_por_Estado[i] = new TTWorkFlow_Condiciones_por_EstadoCS.objectBussinessTTWorkFlow_Condiciones_por_Estado();
                myTTWorkFlow.Condiciones_por_Estado[i].TTWorkFlow = varCondiciones_por_EstadoTTWorkFlow[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Folio = varCondiciones_por_EstadoFolio[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Fase = varCondiciones_por_EstadoFase[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Estado = varCondiciones_por_EstadoEstado[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Operador_de_Condicion = varCondiciones_por_EstadoOperador_de_Condicion[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Proceso = varCondiciones_por_EstadoProceso[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Campo = varCondiciones_por_EstadoCampo[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Condicion = varCondiciones_por_EstadoCondicion[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Operador = varCondiciones_por_EstadoOperador[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Valor_Operador = varCondiciones_por_EstadoValor_Operador[i];
                myTTWorkFlow.Condiciones_por_Estado[i].Prioridad = varCondiciones_por_EstadoPrioridad[i];

                }
            }

            String sMsg = "";
            if (!ValidaDataToSave(myTTWorkFlow, out sMsg))
            {
                throw new Exception(sMsg);
            }
            myTTWorkFlow.Update(globalInfo, dr);
    }
    [WebMethod]
    public bool Delete(TTSecurity.GlobalData globalInfo, int? KeyFolio)
    {
        TTDataLayerCS.DataLayerFieldsBitacora dr = new TTDataLayerCS.DataLayerFieldsBitacora("", 0);
         return myTTWorkFlow.Delete(KeyFolio, globalInfo, dr);
    }

    [WebMethod]
    public TTWorkFlowCS.objectBussinessTTWorkFlow GetByKey(int? KeyFolio, Boolean ConRelaciones)
    {
        myTTWorkFlow.GetByKey(KeyFolio, ConRelaciones);;
        return myTTWorkFlow;
    }
    [WebMethod]
    public Int32 CurrentPosicion(int? KeyFolio)
    {
        return myTTWorkFlow.CurrentPosicion(KeyFolio);
    }
    [WebMethod]
    public Boolean ValidaExistencia(int? KeyFolio)
    {
        return myTTWorkFlow.ValidaExistencia(KeyFolio);
    }

    private bool ValidaDataToSave(TTWorkFlowCS.objectBussinessTTWorkFlow MyDataTTWorkFlow, out String sMsg)
    {
        //Validaciones
        sMsg = "";

        if (sMsg != "")
        {
            sMsg = MyTraductor.getMessage(15) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7);
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool ValidaDataDuplication(TTWorkFlowCS.objectBussinessTTWorkFlow MyDataTTWorkFlow, out string sMsg)
    {
        //Validaciones
        sMsg = "";
        if (MyDataTTWorkFlow.Folio == -1)
        {
            if (MyDataTTWorkFlow.ValidaExistencia(MyDataTTWorkFlow.Folio))
            {
                sMsg = sMsg + MyTraductor.getMessage(84)+"\n";
            }
        }
        if (sMsg != "")
        {
            sMsg = MyTraductor.getMessage(6) + "\n" + sMsg + "\n" + MyTraductor.getMessage(7);
            return false;
        }
        else
        {
            return true;
        }
    }
    [WebMethod]
    public DataSet FillDataEstatus(String sFiltro)
    {
        DataSet ds = new DataSet();
        if (sFiltro=="")
            ds.Tables.Add(myTTWorkFlow.FillDataEstatus().Copy());
        else
            ds.Tables.Add(myTTWorkFlow.FillDataEstatus(sFiltro).Copy());
        return ds;
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public CascadingDropDownNameValue[] FillDataEstatusCDD(string knownCategoryValues, string category)
    {
        List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

        try
        {
            DataTable dt = new DataTable();
            dt = myTTWorkFlow.FillDataEstatus();

            foreach (DataRow dRow in dt.Rows)
            {
                values.Add(new CascadingDropDownNameValue(dRow["Descripcion"].ToString(), dRow["Clave"].ToString()));
            }
        }
        catch
        { }
        return values.ToArray();
    }

}