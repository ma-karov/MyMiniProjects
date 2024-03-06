
namespace AspNetCoreApplicationTest1.Pages.RazorPagesForms.AuthUser 
{ 
    public class AuthUserPage_RegistrationUser : Microsoft.AspNetCore.Mvc.RazorPages.PageModel 
    { 
        [Microsoft.AspNetCore.Mvc.BindProperty(SupportsGet = true)] public AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassRegistrationUserForm Form { get; set; } 

        public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers []ArrayUsers; 
        public System.Boolean RedirectToPageLoginUser_Bool; 

        readonly AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForRazorPagesAndRepository.IControllingRegistrationUsersModel ControllingRegistrationUsersModel; 

        public AuthUserPage_RegistrationUser(AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForRazorPagesAndRepository.IControllingRegistrationUsersModel ControllingRegistrationUsersModel) 
        { 
            this.ControllingRegistrationUsersModel = ControllingRegistrationUsersModel; 
            Form = new AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassRegistrationUserForm(); 
            ArrayUsers = System.Array.Empty<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers>(); 
            RedirectToPageLoginUser_Bool = false; 
        } 

        public void OnGet() 
        { //InterSystems.Data.CacheClient.CacheConnection a = new InterSystems.Data.CacheClient.CacheConnection();
            ArrayUsers = ControllingRegistrationUsersModel.GetAllRecordsUsers().ToArray<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers>(); 
        } 

        [Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken] 
        public Microsoft.AspNetCore.Mvc.IActionResult OnPost(AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassTest Test, System.UInt16 Val) 
        { 
            if (ModelState.IsValid) 
                System.Console.WriteLine(Test); 
            return new Microsoft.AspNetCore.Mvc.JsonResult(Test); 
        } 

        [Microsoft.AspNetCore.Mvc.AutoValidateAntiforgeryToken] 
        public void OnPostCheckInputData(System.String Var) 
        { 
            System.Threading.Thread SystemThreadingThread_AddRecordNewUser = new System.Threading.Thread( 
                delegate() 
                { 
                    if (ModelState.IsValid)
                    { 
                        if (!ControllingRegistrationUsersModel.AddRecordNewUser(Form: Form)) 
                            ModelState.AddModelError("E_Mail", "Такой E-Mail уже занят"); 
                        else 
                            RedirectToPageLoginUser_Bool = true; 
                            
                        //ArrayUsers = ControllingRegistrationUsersModel.GetAllRecordsUsers().ToArray<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers>(); 
                    } 
                } ) { Priority = System.Threading.ThreadPriority.Lowest }; 
            SystemThreadingThread_AddRecordNewUser.Start(); 
            SystemThreadingThread_AddRecordNewUser.Join(); 
            
            //return RedirectToAction("");
        } 
    } 


} 

