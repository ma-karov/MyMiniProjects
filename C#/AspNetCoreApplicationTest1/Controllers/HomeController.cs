
namespace AspNetCoreApplicationTest1.Controllers 
{ 
    [Microsoft.AspNetCore.Mvc.Route("")]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller 
    { 
        private readonly ILogger<HomeController> Logger; 
        private readonly AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsModel GetListCarsModel; 
        private readonly AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsCategoriesModel GetListCarsCategoriesModel; 

        public HomeController(ILogger<HomeController> Logger, AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsModel GetListCarsModel, AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsCategoriesModel GetListCarsCategoriesModel) 
        { 
            this.Logger = Logger; this.GetListCarsModel = GetListCarsModel; this.GetListCarsCategoriesModel = GetListCarsCategoriesModel; 
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("")] 
        public Microsoft.AspNetCore.Mvc.IActionResult Index() 
        {
            //AspNetCoreApplicationTest1.CustomFiles.WorkWithFiles.FileJson NewFileJson = new CustomFiles.WorkWithFiles.FileJson("MainData2.json"); 
            //            GetListCarsModel.AllCarsToStringJSON(); 
            //InterSystems.Data.CacheClient.CacheConnection NewCacheConnection = new InterSystems.Data.CacheClient.CacheConnection("Server = 192.168.0.18; " + "Port = 15000; " + "Password = SYS; " + "User ID = _SYSTEM" ); 
            //NewCacheConnection.Open(); NewCacheConnection.Close();
            

            
            return View("Index", GetListCarsModel.AllCars()); 
        } 

        [Microsoft.AspNetCore.Mvc.HttpGet("Privacy")] 
        public Microsoft.AspNetCore.Mvc.IActionResult Privacy() => View("Privacy"); 

        [Microsoft.AspNetCore.Mvc.ResponseCache(Duration = 0, Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.None, NoStore = true)]
        public Microsoft.AspNetCore.Mvc.IActionResult Error() => View(new AspNetCoreApplicationTest1.CustomFiles.Models.ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
    
    } 
} 
