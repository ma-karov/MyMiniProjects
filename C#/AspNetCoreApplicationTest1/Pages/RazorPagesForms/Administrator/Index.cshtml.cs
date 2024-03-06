
namespace AspNetCoreApplicationTest1.Pages.RazorPagesForms.Administrator
{ 
    [Microsoft.AspNetCore.Authorization.Authorize(Policy = "RequireAdmininistratorOnly")] 
    public class AdministratorPage_Index : Microsoft.AspNetCore.Mvc.RazorPages.PageModel 
    { 
        public System.String []ArrayDataBaseTableAppelation;

        public AdministratorPage_Index() => ArrayDataBaseTableAppelation = new System.String[] { "Cars", "CarsCategories", "RegistrationUsers_ContactInformations", "RegistrationUsers", "RegistrationUsers_GroupRoles", "RegistrationUsers_ImagesAndVideosAlbumsGraph", "RegistrationUsers_ImagesAlbums", "RegistrationUsers_VideosAlbums" };

        public void OnGet()
        {
        }
    }
}
