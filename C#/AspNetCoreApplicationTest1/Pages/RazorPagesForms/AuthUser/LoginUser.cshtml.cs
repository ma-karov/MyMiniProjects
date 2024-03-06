
using AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.CollectionsIEnumerable;
using Microsoft.AspNetCore.Authentication;

namespace AspNetCoreApplicationTest1.Pages.RazorPagesForms.AuthUser
{
    public class AuthUserPage_LoginUser : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    { 
        [Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)] public AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassLoginUserForm Form { get; set; } 

        public System.Boolean RedirectToPageAdministrator_Bool; 

        readonly AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForRazorPagesAndRepository.IControllingRegistrationUsersModel ControllingRegistrationUsersModel; 

        public AuthUserPage_LoginUser(AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForRazorPagesAndRepository.IControllingRegistrationUsersModel ControllingRegistrationUsersModel) 
        { 
            this.ControllingRegistrationUsersModel = ControllingRegistrationUsersModel; 
            Form = new AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassLoginUserForm(); 
            RedirectToPageAdministrator_Bool = false; 
        } 

        public void OnGet()
        { 
            
        } 

        [Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken] 
        public void OnPostCheckInputData() 
        { 
            if (ModelState.IsValid) 
            { 
                AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers RegistrationUser = ControllingRegistrationUsersModel.GetRecordUser(Form.E_MailAddress); 
                if (ControllingRegistrationUsersModel.CheckAuthorizationUser(RegistrationUser: in RegistrationUser, FormPassword: Form.Password)) 
                { 
                    System.Security.Claims.Claim []ArrayClaimsUser = new System.Security.Claims.Claim[2]
                    {
                        new System.Security.Claims.Claim(type: System.Security.Claims.ClaimTypes.Name, value: "Administrator Makarov"), 
                        new System.Security.Claims.Claim(type: System.Security.Claims.ClaimTypes.Email, value: RegistrationUser.E_MailAddress) 
                    }; 

                    if (RegistrationUser.PermissionGroupRole.RegistrationUser_PermissionRoleENUM == AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForDataBaseModels.DataTypes.RegistrationUsers_PermissionRolesENUM.ADMINISTRATOR) 
                    { 
                        ArrayClaimsUser.ExtensionsUser_AddElementLast<System.Security.Claims.Claim>(NewElement: new System.Security.Claims.Claim(type: "Administrator", value: "True"));
                        RedirectToPageAdministrator_Bool = true; 
                    } 
                    
                    HttpContext.SignInAsync(scheme: AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase_FlyWeight.SESSIONS_COOKIES_NAME, principal: new System.Security.Claims.ClaimsPrincipal(identity: new System.Security.Claims.ClaimsIdentity(claims: ArrayClaimsUser, authenticationType: AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase_FlyWeight.SESSIONS_COOKIES_NAME) ) );
                } 
                else 
                { 
                    ModelState["Form.E_MailAddress"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid; 
                    ModelState["Form.E_MailAddress"].Errors.Add("Ваш E-Mail или пароль неверные! Повторите ввод еще раз. "); 
                } 
                
            }
        }
    }
}
