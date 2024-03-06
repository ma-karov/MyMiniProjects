
const RegistrationUserAPP = angular.module("RegistrationUserAPP", []);
RegistrationUserAPP.controller("RegistrationUserController", ["$scope", function ($scope)
{ 
    $scope.RegistrationUserController_InputTypePassword_ID_Password = ""; 

    const StaticClassHelper = new StaticClassHwlper_RegistrationUserAPP_RegistrationUserController();    

    $scope.RegistrationUserController_InputTypePassword_EventBlur = function () 
    { 
        StaticClassHelper.InputTypePassword_ChangeIconRulesWritePassword_EventBlur(this.RegistrationUserController_InputTypePassword_ID_Password); 

        /*$.ajax(
        { 
            url: "/RazorPagesForms/RegistrationUser", 
            dataType: 'json',
            headers: { RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val() }, 
            type: "POST", 
            cache: false, 
            async: false, 
            data: { "Test": { "ID": 7 }, "Val": 14 },
            success: function (Data) {
                console.log("output : ", Data);
            },
            error: function (Data) {
                console.log("error : " + Data);
            }
        } ); */

        //console.log(document.styleSheets[5].cssRules); 
//        document.styleSheets[5].insertRule('#ID_DIV_RULES_WRITE_PASSWORD_TO_HTNL_TagHelper ul li:nth-child(2)::marker { color: blue; } ', 4);


//        $("#ID_DIV_RULES_WRITE_PASSWORD_TO_HTNL_TagHelper ul li::marker").css( { "color": "" } );
    } 

} ] ); 


function StaticClassHwlper_RegistrationUserAPP_RegistrationUserController()
{ 
    function ReplaceSlylesPseudoClassSelector(ARGS_ID_Selector, ARGS_PropertyName, ARGS_ProperyValue)
    {
        var Index = 0, NotFindSelectorID_Bool = true;
        for (const CONST_STYLE_RULE of document.styleSheets[5].cssRules)
        {
            if (CONST_STYLE_RULE["selectorText"] == ARGS_ID_Selector)
            {
                document.styleSheets[5].cssRules[Index].style.setProperty(ARGS_PropertyName, ARGS_ProperyValue);
                NotFindSelectorID_Bool = false;
                break;
            }
            Index++;
        }
        if (NotFindSelectorID_Bool) document.styleSheets[5].addRule(ARGS_ID_Selector, `${ARGS_PropertyName}: ${ARGS_ProperyValue}`);
    } 

    function a(ARGS_Password)
    { 
        onmessage = Event =>
        {
            const ARRAY = [ {10: [ 1, 2, 3], "ALL": "dbf ghj"}, 414, {}]
            console.log("Promise");
            postMessage(ARRAY); 
        }
    }

    this.InputTypePassword_ChangeIconRulesWritePassword_EventBlur = function (ARGS_Password)
    {
        var worker = new Worker(URL.createObjectURL(new Blob([`${ReplaceSlylesPseudoClassSelector} (${a})("${ARGS_Password}");`])));
        worker.postMessage(ARGS_Password); 
        worker.onmessage = e =>
        {
            console.log(worker, e.data); worker.terminate();
        } 
        console.log("Function()")


        var PasswordLength = 0; const ARRAY_STYLES_ON_RULES_PASSWORD_BOOL_LENGTH = 4;
        const ARRAY_STYLES_ON_RULES_PASSWORD_BOOL = new Array(ARRAY_STYLES_ON_RULES_PASSWORD_BOOL_LENGTH);

        for (var i = 0; i < ARRAY_STYLES_ON_RULES_PASSWORD_BOOL_LENGTH; i++)
            ARRAY_STYLES_ON_RULES_PASSWORD_BOOL[i] = false;

        for (const CONST_CHAR of ARGS_Password)
        {
            if (CONST_CHAR >= "a" && CONST_CHAR <= "z")
                ARRAY_STYLES_ON_RULES_PASSWORD_BOOL[0] = true;
            else if (CONST_CHAR >= "A" && CONST_CHAR <= "Z")
                ARRAY_STYLES_ON_RULES_PASSWORD_BOOL[1] = true;
            else if (CONST_CHAR >= "0" && CONST_CHAR <= "9")
                ARRAY_STYLES_ON_RULES_PASSWORD_BOOL[2] = true;
            else
                for (const CONST_CHAR_SPECIAL of RegistrationUserMainDataJSON_ARRAY_CHARS_SPECIAL) //["!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "/", ",", ".", "?", "<", ">", "[", "]", "{", "}"])
                    if (CONST_CHAR_SPECIAL == CONST_CHAR)
                    { 
                        ARRAY_STYLES_ON_RULES_PASSWORD_BOOL[3] = true;
                        break;
                    }
            PasswordLength++;
        }

        ReplaceSlylesPseudoClassSelector("#ID_DIV_RULES_WRITE_PASSWORD_TO_HTNL_TagHelper ul li:nth-child(1)::marker", "color", (PasswordLength >= 8 ? "blue" : "red"));
        for (var i = 0; i < ARRAY_STYLES_ON_RULES_PASSWORD_BOOL_LENGTH; i++)
            ReplaceSlylesPseudoClassSelector(`#ID_DIV_RULES_WRITE_PASSWORD_TO_HTNL_TagHelper ul li:nth-child(${i + 2})::marker`, "color", (ARRAY_STYLES_ON_RULES_PASSWORD_BOOL[i] ? "blue" : "red")); 



    } 
} 

/*function workerTask() {
    return Math.random() * Math.random()
}

runInWebWorker(workerTask, console.log);

function runInWebWorker(task, callback) {
    console.log(task); 
    var worker = new Worker(URL.createObjectURL(new Blob( [ `${task};(function(){this.postMessage(${task.name}())})();` ] ) ) );
    worker.onmessage = e => worker.terminate() || callback(e.data);
}*/ 
