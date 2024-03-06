
namespace AspNetCoreApplicationTest1.CustomFiles.Interfaces 
{ 
    namespace ForControllersAndRepository 
    {
        public interface IGetListCarsModel 
        { 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> AllCars(); 
            void AllCarsToStringJSON(); 
            //        AspNetCoreApplicationTest1.Models.Cars GetCar(Int16 Id); 
        } 

        public interface IGetListCarsCategoriesModel 
        { 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories> AllCategories(); 
        } 
    } 

    namespace ForRazorPagesAndRepository 
    { 
        public interface IControllingRegistrationUsersModel 
        { 
            //System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers> AddRecordNewUser(AspNetCoreApplicationTest1.Pages.RazorPagesForms.RegistrationUserForm Form); 
            System.Boolean AddRecordNewUser(in AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassRegistrationUserForm Form); 
            System.Boolean DeleteRecordUser(System.UInt32 ID_User); 
            System.Boolean CheckAuthorizationUser(in AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers RegistrationUser, in System.String FormPassword); 
            AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers GetRecordUser(System.UInt32 ID_User); 
            AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers GetRecordUser(in System.String E_MailAddressUser); 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers> GetAllRecordsUsers(); 
        }

    }

    namespace ForProtectDataBase 
    {
        public interface ICashingFunctions 
        { 
            System.Threading.Tasks.Task<System.String> CashEncodeText(System.String SystemStringEnterMessage, System.UInt16 TypeEncode); 
        }
    } 

    namespace ForSettingsDataBases 
    { 
        public interface IWorkingInformationDataConnectionDataBase
        { 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> TableCars_GetAllCars(); 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> TableCars_GetAllCarsIncludeCategories(); 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories> TableCategories_GetAllCategories(); 
            
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations> TableRegistrationUsersContactInformations_GetAllContactInformations(); 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers> TableRegistrationUsers_GetAllRegistrationUsers(); 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_GroupRoles> TableRegistrationUsersGroupRoles_GetAllGroupRoles(); 

            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ImagesAndVideosAlbumsGraph> TableRegistrationUsersImagesAndVideosAlbumsGraph_GetAllImagesAndVideosAlbumsGraph(); 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ImagesAlbums> TableRegistrationUsersImagesAlbums_GetAllImagesAlbums(); 
            System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_VideosAlbums> TableRegistrationUsersVideosAlbums_GetAllVideosAlbums(); 



            AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers TableRegistrationUsers_GetRegistrationUser(System.UInt32 ID_User); 
            AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers TableRegistrationUsers_GetRegistrationUser(System.String E_MailAddressUser); 
           
            System.Boolean TableRegistrationUsers_AddRecordNewUser(in AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations RegistrationUsersContactInformationsModel); 
            
            /*System.Boolean SaveChangesInTableCars(in IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase); 
            System.Boolean SaveChangesInTableCarsCategories(in IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase); 
            System.Boolean SaveChangesInTableRegistrationUsers(in IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase); 
            System.Boolean SaveChangesInTableRegistrationUsersContactInformations(in IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase); 
            System.Boolean SaveChangesInTableRegistrationUsersGroupRoles(in IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase); */ 
            System.Boolean SaveChangesInAllTables(in IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase); 
        } 
    } 
} 
