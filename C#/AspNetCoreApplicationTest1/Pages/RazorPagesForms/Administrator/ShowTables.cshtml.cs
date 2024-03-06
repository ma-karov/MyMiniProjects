
namespace AspNetCoreApplicationTest1.Pages.RazorPagesForms.Administrator
{ 
    [Microsoft.AspNetCore.Authorization.Authorize(Policy = "RequireAdminOnly")]
    public class AdministratorPage_ShowTables : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
    { 
        public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers []ArrayUsers; 

        public void OnGet()
        {
        } 

        public void OnGetSelectTable(System.Byte Switch) 
        { 
            switch (Switch) 
            { 
                case 1: 
                { 

                    break; 
                }

            } 
        } 
    }
}
