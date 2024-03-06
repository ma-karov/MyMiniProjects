
namespace AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.TagHelpersHTML.TagHelpers
{ 
    [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement("ExtensionsUserRulesWritePasswordToHTML-DivTagHelper", TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
    public class RulesWritePassword_TagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper 
    { 
        //[Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName("Content-Block")] public System.String ContentBlock { get; set; } 
        public override void Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext TagHelper_Context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput TagHelper_Output) 
        { 
            const System.String HTML_CONTENT = @" 
            <div id = ""ID_DIV_RULES_WRITE_PASSWORD_TO_HTNL_TagHelper"" > 
                Пароль должен содержать: 
                <ul> 
                    <li> Минимум 8 символов; </li> 
                    <li> Минимум 1 символ строчной буквы; </li> 
                    <li> Минимум 1 символ заглавной буквы; </li> 
                    <li> Минимум 1 символ цифры; </li> 
                    <li> Минимум 1 специальный символ; </li> 
                </ul> 
            </div> "; 
            TagHelper_Output.TagName = ""; 
            TagHelper_Output.PreElement.SetHtmlContent(encoded: HTML_CONTENT); 

        }
    } 
}
