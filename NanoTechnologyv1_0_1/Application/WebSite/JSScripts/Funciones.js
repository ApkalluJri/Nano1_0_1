function fireEventFromServer(controlName) {
    var ctl = $('#' + controlName);
    if (ctl.length) {
        ctl.trigger('blur');
    }
}
function disableControls() {
    $('.rcbInput').each(function(index) {
      $(this).attr('disabled','disabled');
  });
  $('img').each(function(index) {
      $(this).attr('disabled', 'disabled');
  });
}

function setSelectedValue(selectObj, valueToSet) {
    for (var i = 0; i < selectObj.options.length; i++) {
        if (selectObj.options[i].value == valueToSet) {
            selectObj.options[i].selected = true;
            return;
        }
    }
}

function pageLoadedFunc(sender, eventArgs) {
    $((sender._textBoxElement ? sender._textBoxElement : sender)).calculator({ showOn: 'button',
        buttonImageOnly: true, buttonImage: '../images/calculator.png'
    });
}

function OnChangeDateInput(obj) {
    var currentTime, hours, minutes, seconds;
    obj.value = obj.value.toUpperCase();
    if (obj.value.indexOf('M') > 0) {
        var indice = obj.value.indexOf('M');
        var valorAgregado = obj.value.substring(0, indice);
        if (IsNumeric(valorAgregado)) {
            currentTime = new Date();
            hours = currentTime.getHours();
            minutes = parseInt(currentTime.getMinutes()) + parseInt(valorAgregado);
            seconds = currentTime.getSeconds();
            minutes = minutes < 10 ? "0" + minutes : minutes;
            seconds = seconds < 10 ? "0" + seconds : seconds;
            obj.value = FormatValidTime(hours, minutes, seconds);
        }
        else
            obj.value = SetDefaultDate();
    }
    else if (obj.value.indexOf('H') > 0) {
        var indice = obj.value.indexOf('H');
        var valorAgregado = obj.value.substring(0, indice);
        if (IsNumeric(valorAgregado)) {
            currentTime = new Date();
            hours = parseInt(currentTime.getHours()) + parseInt(valorAgregado);
            minutes = currentTime.getMinutes();
            seconds = currentTime.getSeconds();
            minutes = minutes < 10 ? "0" + minutes : minutes;
            seconds = seconds < 10 ? "0" + seconds : seconds;
            obj.value = FormatValidTime(hours, minutes, seconds);
        }
        else
            obj.value = SetDefaultDate();
    }
    else if (obj.value.indexOf('S') > 0) {
        var indice = obj.value.indexOf('S');
        var valorAgregado = obj.value.substring(0, indice);
        if (IsNumeric(valorAgregado)) {
            currentTime = new Date();
            hours = currentTime.getHours();
            minutes = currentTime.getMinutes();
            seconds = parseInt(currentTime.getSeconds()) + parseInt(valorAgregado);
            minutes = minutes < 10 ? "0" + minutes : minutes;
            seconds = seconds < 10 ? "0" + seconds : seconds;
            obj.value = FormatValidTime(hours, minutes, seconds);
        }
        else
            obj.value = SetDefaultDate();
    }
}

function SetDefaultDate() {
    currentTime = new Date();
    hours = currentTime.getHours();
    minutes = currentTime.getMinutes();
    seconds = currentTime.getSeconds();
    minutes = minutes < 10 ? "0" + minutes : minutes;
    seconds = seconds < 10 ? "0" + seconds : seconds;
    var result = FormatValidTime(hours, minutes, seconds);
    return result;
}

function FormatValidTime(hour3, min3, sec3) {
    if (sec3 >= 60) { sec3 = -(60 - sec3); min3 = parseInt(min3) + 1; }
    if (min3 >= 60) { min3 = -(60 - min3); hour3 = parseInt(hour3) + 1; }
    if (hour3 >= 24) { hour3 = -(24 - hour3); }
    if (sec3 <= 9) { sec3 = "0" + sec3; }
    if (min3 <= 9) { min3 = "0" + min3; }
    if (hour3 <= 9) { hour3 = "0" + hour3; }
    var result = hour3 + ':' + min3 + ':' + sec3;
    return result;
}

function IsNumeric(sText) {
    var ValidChars = "0123456789.";
    var IsNumber = true;
    var Char;

    for (i = 0; i < sText.length && IsNumber == true; i++) {
        Char = sText.charAt(i);
        if (ValidChars.indexOf(Char) == -1) {
            IsNumber = false;
        }
    }
    return IsNumber;
}

function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow;
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow;
    return oWindow;
}

function CloseWindow() {
    try {
        GetRadWindow().close();
    }
    catch (Error) { }
}

function setDivsVisible(isVisible) {
    try {
        if (isVisible == true) {
            $get('divPageSlider').style.visibility = 'visible';
            $get('rad_menu').style.visibility = 'visible';
        }
        else {
            $get('divPageSlider').style.visibility = 'hidden';
            $get('rad_menu').style.visibility = 'hidden';
        }
    }
    catch (Error) { alert(Error); }
}

//******************************* Multirenglon Async Functions *********************************//
function get_nextsibling(n) {
    x = n.nextSibling;
    while (x.nodeType != "1") {
        x = x.nextSibling;
    }
    return x;
}

function get_firstChild(elm) {
    if (!elm.childNodes.length) {
        return;
    }
    var children = elm.childNodes.length;
    for (var i = 0; i <= children; ++i) {
        if (elm.childNodes[i].nodeType == "1") {
            return elm.childNodes[i];
        }
    }
    return;
}

function ProcessData(textbox, processid, dtid) {
    textbox = get_firstChild(textbox.parentNode);

    var label = get_nextsibling(textbox);
    label = get_nextsibling(label);

    var codeOutput = get_nextsibling(textbox);
    codeOutput = get_nextsibling(codeOutput);
    codeOutput = get_nextsibling(codeOutput);

    processText('ShowList', dtid, processid, textbox.id, textbox.value, label.id, codeOutput.id);
}

function ShowWindow(url) {
    var oWnd = radopen(url, null);
    oWnd.setSize(800, 600);
    oWnd.set_modal(true);
    oWnd.set_visibleStatusbar(false);
    oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Default);
    oWnd.center();
    oWnd.show();
}

function AssignValueFromWindow(controlId, value) {
    var control = $find(controlId);
    control.value = value;
    if (control.type == "text")
        control.onfocusout();
    else if (control.type == "select")
        control.onchange();
    else
        control.set_text(value);
}

function ReturnDataToOpener(controlId, value) {
    try {
        GetRadWindow().close();
        parent.AssignValueFromWindow(controlId, value)
    }
    catch (Error) { }
}

function OnChangeHourInputMulti(sender, e) {
    if (e.get_newValue() != null) {
        OnChangeHour(sender, e.get_newValue(), false);
    }   
}

function OnBussinesRulesChangeHourInputMulti(sender, value) {

    if (value != null) {
        OnChangeHour(sender, value, true);
    }

}

function OnChangeHour(sender, value, isBussines) {
    var currentTime, hours, minutes, seconds, inputValue;
    if (value != null) {
        inputValue = value;
        inputValue = inputValue.toUpperCase();
        if (inputValue.indexOf('M') > 0) {
            var indice = inputValue.indexOf('M');
            var valorAgregado = inputValue.substring(0, indice);
            if (IsNumeric(valorAgregado)) {
                currentTime = new Date();
                hours = currentTime.getHours();
                minutes = parseInt(currentTime.getMinutes()) + parseInt(valorAgregado);
                seconds = currentTime.getSeconds();
                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;
                inputValue = FormatValidTime(hours, minutes, seconds);
            }
            else
                inputValue = SetDefaultDate();
        }
        else if (inputValue.indexOf('H') > 0) {
            var indice = inputValue.indexOf('H');
            var valorAgregado = inputValue.substring(0, indice);
            if (IsNumeric(valorAgregado)) {
                currentTime = new Date();
                hours = parseInt(currentTime.getHours()) + parseInt(valorAgregado);
                minutes = currentTime.getMinutes();
                seconds = currentTime.getSeconds();
                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;
                inputValue = FormatValidTime(hours, minutes, seconds);
            }
            else
                inputValue = SetDefaultDate();
        }
        else if (inputValue.indexOf('S') > 0) {
            var indice = inputValue.indexOf('S');
            var valorAgregado = inputValue.substring(0, indice);
            if (IsNumeric(valorAgregado)) {
                currentTime = new Date();
                hours = currentTime.getHours();
                minutes = currentTime.getMinutes();
                seconds = parseInt(currentTime.getSeconds()) + parseInt(valorAgregado);
                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;
                inputValue = FormatValidTime(hours, minutes, seconds);
            }
            else
                inputValue = SetDefaultDate();
        }
        var attribs = $get(sender.get_id());
        if (!isBussines) {
            //sender.set_value(inputValue);
            callserver(attribs.getAttribute('Operation') + '¬' + attribs.getAttribute('Multirenglon') + '¬' + attribs.getAttribute('ControlId') + '¬' + attribs.getAttribute('Key') + '¬' + inputValue + '¬' + attribs.getAttribute('Field') + '¬' + isBussines);
        }
    }
}
function OnBussinesRulesChangeDateInputMulti(sender, value) {
    OnChangeDate(sender, value, true);
}

function OnChangeDateInputMulti(sender, e) {
    OnChangeDate(sender, e.get_newValue(), false);
}

function OnChangeDate(sender, value, isBussines) {
    var currentTime, hours, minutes, seconds, inputValue;
    if (value != null) {
        inputValue = value;

        var attribs = $get(sender.get_id());
        if (isBussines) {
            //sender.set_selectedDate(inputValue);
            callserver(attribs.getAttribute('Operation') + '¬' + attribs.getAttribute('Multirenglon') + '¬' + attribs.getAttribute('ControlId') + '¬' + attribs.getAttribute('Key') + '¬' + inputValue + '¬' + attribs.getAttribute('Field') + '¬' + isBussines);
        }
        else {
            //sender.set_value(inputValue);
            callserver(attribs.getAttribute('Operation') + '¬' + attribs.getAttribute('Multirenglon') + '¬' + attribs.getAttribute('ControlId') + '¬' + attribs.getAttribute('Key') + '¬' + inputValue + '¬' + attribs.getAttribute('Field') + '¬' + isBussines);
        }

    }
}

function FormatNumbers(obj) {
    inputValue = obj.value;

    re = /\$|,|\_/g;
    inputValue = inputValue.replace(re, '');
    callserver(obj.getAttribute('Operation') + '¬' + obj.getAttribute('Multirenglon') + '¬' + obj.getAttribute('ControlId') + '¬' + obj.getAttribute('Key') + '¬' + inputValue + '¬' + obj.getAttribute('Field'));
}

function RadComboSelectedIndexChanged(sender, e) {
    var attribs = $get(sender.get_id());
    var item = e.get_item();
    if (item != null) {

        sender.set_text(item.get_value() + ' -  ' + item.get_text());
        callserver(attribs.getAttribute('Operation') + '¬' + attribs.getAttribute('Multirenglon') + '¬' + attribs.getAttribute('ControlId') + '¬' + attribs.getAttribute('Key') + '¬' + item.get_value() + '¬' + attribs.getAttribute('Field'));
    }
}

function OnChangeNumericTextBox(sender, e) {
    var attribs = $get(sender.get_id());
    inputValue = e.get_newValue();
    callserver(attribs.getAttribute('Operation') + '¬' + attribs.getAttribute('Multirenglon') + '¬' + attribs.getAttribute('ControlId') + '¬' + attribs.getAttribute('Key') + '¬' + inputValue + '¬' + attribs.getAttribute('Field'));
}

//********************************* Catalogos Functions *****************************************//
function InStr(n, s1, s2) {
    var numargs = InStr.arguments.length;

    if (numargs < 3)
        return n.indexOf(s1) + 1;
    else
        return s1.indexOf(s2, n) + 1;
}

function processText() {
    args = '';

    for (i = 0; i < arguments.length; i++)
        args += (args == '' ? arguments[i] : '¬' + arguments[i]);

    callserver(args);
}

function ReceiveErrorData(arg, context) {

}

function ReceiveServerData(arg, context) {
    var content = arg.split('<#>');

    if (content.length > 0) {

        eval(content[2]);
 
    }
}

function OpenImage(img) {
    var largo = 260;
    var altura = 200;
    var top = (screen.height - altura) / 2;
    var izquierda = (screen.width - largo) / 2;

    foto1 = new Image();
    foto1.src = (img);
    ancho = foto1.width + 20;
    alto = foto1.height + 20;
    cadena = "width = " + ancho + ",height=" + alto + ",top = " + top + ",left = " + izquierda;
    ventana = window.open(img, "null", cadena);
}

//********************************* Listas Functions *****************************************//
//  keeps track of the delete button for the row
//  that is going to be removed
//  rad_menu esta en el master page
//  setDivsVisible esta en Funcion.js

var _source;
// keep track of the popup div
var _popup;

//function OpenImage(img) {
//    var largo = 260;
//    var altura = 200;
//    var top = (screen.height - altura) / 2;
//    var izquierda = (screen.width - largo) / 2;

//    foto1 = new Image();
//    foto1.src = (img);
//    ancho = foto1.width + 20;
//    alto = foto1.height + 20;
//    cadena = "width=" + ancho + ",height=" + alto + ",top=" + top + ",left=" + izquierda;
//    ventana = window.open("MuestraArchivos.aspx?archivo=" + img, "null", cadena);
//}

function showConfirm(source) {
    this._source = source;
    this._popup = $find('mdlPopup');

    //  find the confirm ModalPopup and show it    
    this._popup.show();
    setDivsVisible(false);
}

function okClick() {
    //  find the confirm ModalPopup and hide it    
    this._popup.hide();
    //  use the cached button as the postback source
    __doPostBack(this._source.name, '');
    setDivsVisible(true);
}

function cancelClick() {
    //  find the confirm ModalPopup and hide it 
    this._popup.hide();
    //  clear the event source
    this._source = null;
    this._popup = null;
    setDivsVisible(true);
}

function toggleItem(panelBarId) {
    var panelBar = $find(panelBarId);
    var item = panelBar.findItemByValue("Filtros");

    if (item) {
        if (!item.get_expanded()) {
            item.expand();
        }
        else {
            item.collapse();
        }
    }
    else {
        alert("Item with text Filtros not found.");
    }
}

function getQuerystring(key, default_) {
    if (default_ == null) default_ = "";
    key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
    var qs = regex.exec(window.location.href);
    if (qs == null)
        return default_;
    else
        return qs[1];
}

var down = [];
function rad_keydown(sender, e) {
    var contains = false;
    for (var i = 0; i < down.length; i++)
        if (down[i] == e.keyCode) {
        contains = true;
        break;
    }
    if (!contains) {
        down.push(e.keyCode)
    }
}


function rad_keyup(sender, e) {

    if (!down.indexOf) {
        down.indexOf = function(obj) {
            for (var i = 0; i < this.length; i++) {
                if (this[i] == obj) {
                    return i;
                }
            }
            return -1;
        }
    }

    if ($.inArray(e.keyCode, down) != -1) {
        var control = $('#' + sender.id.replace("wrapper", "dateInput"));

        var x;
        var yyyy;
        var mm;
        var dd;

        //h O H
        if (($(down).length == 1 && down[0] == 72) || ($(down).length == 2 && down[0] == 16 && down[1] == 72)) {
            x = new Date();

            dd = x.getDate().toString();
            mm = (x.getMonth() + 1).toString();
            yyyy = x.getFullYear().toString();

            x = (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy;
            doPostBackAsync('RadDate$' + control[0].name.replace("$dateInput", ""), x);
        }
        // M O m
        if (($(down).length == 1 && down[0] == 77) || ($(down).length == 2 && down[0] == 16 && down[1] == 77)) {
            x = new Date(new Date().getTime() + 24 * 60 * 60 * 1000);

            dd = x.getDate().toString();
            mm = (x.getMonth() + 1).toString();
            yyyy = x.getFullYear().toString();

            x = (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy;
            doPostBackAsync('RadDate$' + control[0].name.replace("$dateInput", ""), x);
        }
        // d o D
        if (down[0] == 68 && $(down).length > 1) {
            x = new Date();
            var dayNumber = bin2String(down).toLowerCase().replace("d", "");

            x.setTime(x.getTime() + (dayNumber * 24 * 60 * 60 * 1000));

            dd = x.getDate().toString();
            mm = (x.getMonth() + 1).toString();
            yyyy = x.getFullYear().toString();

            x = (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy;
            doPostBackAsync('RadDate$' + control[0].name.replace("$dateInput", ""), x);
        }
        // s o S
        if (down[0] == 83) {
            x = new Date();
            var dayNumber = bin2String(down).toLowerCase().replace("s", "") * 7;

            x.setTime(x.getTime() + (dayNumber * 24 * 60 * 60 * 1000));

            dd = x.getDate().toString();
            mm = (x.getMonth() + 1).toString();
            yyyy = x.getFullYear().toString();

            x = (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy;
            doPostBackAsync('RadDate$' + control[0].name.replace("$dateInput", ""), x);
        }
        // a o A
        if (down[0] == 65) {
            x = new Date();
            var yearNumber = parseInt(bin2String(down).toLowerCase().replace("a", ""));

            dd = x.getDate().toString();
            mm = (x.getMonth() + 1).toString();
            yyyy = (x.getFullYear() + yearNumber).toString();

            x = (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy;
            doPostBackAsync('RadDate$' + control[0].name.replace("$dateInput", ""), x);
        }
        // Altgr + M o Altgr + m
        if ($(down).length >= 3) {
            if (down[0] == 17 && down[1] == 18 && down[2] == 77) {
                x = new Date();
                var monthNumber = parseInt(bin2String(down).toLowerCase().replace("m", ""));

                x.setMonth(x.getMonth() + monthNumber);

                dd = x.getDate().toString();
                mm = (x.getMonth() + 1).toString();
                yyyy = (x.getFullYear()).toString();

                x = (dd[1] ? dd : "0" + dd[0]) + '/' + (mm[1] ? mm : "0" + mm[0]) + '/' + yyyy;
                doPostBackAsync('RadDate$' + control[0].name.replace("$dateInput", ""), x);
            }
        }
    }

    down = [];
}



function bin2String(array) {
    var result = "";
    for (var i = 0; i < array.length; i++) {
        result += String.fromCharCode(isNumPad(array[i]));
    }
    return result;
}

function isNumPad(num) {
    var result = num;
    switch (num) {
        case 96:
            result = 48;
            break;
        case 97:
            result = 49;
            break;
        case 98:
            result = 50;
            break;
        case 99:
            result = 51;
            break;
        case 100:
            result = 52;
            break;
        case 101:
            result = 53;
            break;
        case 102:
            result = 54;
            break;
        case 103:
            result = 55;
            break;
        case 104:
            result = 56;
            break;
        case 105:
            result = 57;
            break;

    }
    return result;
}

function RadDate_Load(sender, args) {
//$("#" + sender.get_id()).tooltip();
}
function maximo_largo(sender) {
    var texto;
    var lenght = $(sender).attr('maxlength');
    texto = sender.value;
    if (texto.length > lenght) {
        sender.value = texto.substring(0, lenght);
    }
}

function keypress(e, sender) {
    var lenght = $(sender).attr('maxlength');
    var recentChar = String.fromCharCode(e.which);
    var texto;
    texto = sender.value;

    texto = texto + recentChar;

    if (!checkSpecialKeys(e)) {
        if (texto.length > lenght) {
            if (!e.preventDefault) {//IE8 7               
                e.returnValue = false;
            }
            else {//Firefox                 
                e.preventDefault();
            }
        }
    }
}
function checkSpecialKeys(e) {
    if (e.keyCode != 8 && e.keyCode != 46 && e.keyCode != 37 && e.keyCode != 38 && e.keyCode != 39 && e.keyCode != 40) {
        return false;
    }
    else {
        return true;
    }
}

function doPostBackAsync(eventName, eventArgs) {
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    if (!Array.contains(prm._asyncPostBackControlIDs, eventName)) {
        prm._asyncPostBackControlIDs.push(eventName);
    }

    if (!Array.contains(prm._asyncPostBackControlClientIDs, eventName)) {
        prm._asyncPostBackControlClientIDs.push(eventName);
    }

    __doPostBack(eventName, eventArgs);
} 

/*Asigna el top correcto al content cuando los tabs saltan de línea.*/
function setHeightTabs()
{
    var a = $('.rad_tab_strip_tabs_controls');
    if (a != null)
    {
        a.css('top', ( $('.tt-tabs-controls').height() + 100) + 'px');
    }
    
} 

function BeginRequestHandlerRAD(sender, args) 
{
if ($get('ctl00_MainContent_RadMultiPage1' ) != null) {
    try {
        xPos = $get('ctl00_MainContent_RadMultiPage1' ).scrollLeft;
        yPos = $get('ctl00_MainContent_RadMultiPage1' ).scrollTop;
        hdnFocus = args.get_postBackElement().id;
        }
        catch (Error) {
        }
    }
}


function EndRequestHandlerRAD(sender, args) 
{
if ($get('ctl00_MainContent_RadMultiPage1' ) != null) {
    try {
        $get('ctl00_MainContent_RadMultiPage1' ).scrollLeft = xPos;
        $get('ctl00_MainContent_RadMultiPage1' ).scrollTop = yPos;
        $get(hdnFocus).focus()
        }
        catch (Error) {
        }
    }
}

