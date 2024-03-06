
namespace AspNetCoreApplicationTest1.CustomFiles.RepositoriesControllers
{
    public class RepositoriesForModels { } 

    public class RepositoryGetListCarsModel : AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsModel 
    { 
        private const System.String ConstPrivateSystemStringPathOfStaticFilesJsons = "wwwroot/Home/Files/Jsons/";
        private readonly AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.RecordClassUndertakeConnectionDataBase_FlyWeight RecordClassUndertakeConnectionDataBaseFlyWeight; 

        public RepositoryGetListCarsModel(AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase Connection_DataBase) => RecordClassUndertakeConnectionDataBaseFlyWeight = new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.RecordClassUndertakeConnectionDataBase_FlyWeight(Connection_DataBase); 

        public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> AllCars() => RecordClassUndertakeConnectionDataBaseFlyWeight.GetDataInformation().TableCars_GetAllCars(); 

        public void AllCarsToStringJSON() 
        { 
            AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.PreparationDataToPrintOnPages.ModelCar_Facade PreparationPrintModelCarFacade = new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.PreparationDataToPrintOnPages.ModelCar_Facade(); 
            AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.WorkWithFiles.FileJson NewFileJson = new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.WorkWithFiles.FileJson(ConstPrivateSystemStringPathOfStaticFilesJsons + "IndexMainData1"); 
            NewFileJson.CreateConstArray("IndexMainData1JSON_ArrayData"); 
            foreach (AspNetCoreApplicationTest1.CustomFiles.Models.Cars ModelCar in AllCars().ToArray()) 
                NewFileJson.AppendInConstArray(PreparationPrintModelCarFacade.SetModelCar(ModelCar).ToStringJSON_WithoutForeignObject()); 
            NewFileJson.CloseConstArray(); NewFileJson.Save(); 
        }
    } 

    public class RepositoryGetListCarsCategoriesModel : AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsCategoriesModel 
    {
        private readonly AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.RecordClassUndertakeConnectionDataBase_FlyWeight RecordClassUndertakeConnectionDataBaseFlyWeight; 

        public RepositoryGetListCarsCategoriesModel(AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase Connection_DataBase) => RecordClassUndertakeConnectionDataBaseFlyWeight = new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.RecordClassUndertakeConnectionDataBase_FlyWeight(Connection_DataBase); 

        public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories> AllCategories() => RecordClassUndertakeConnectionDataBaseFlyWeight.GetDataInformation().TableCategories_GetAllCategories(); 

    } 
} 

namespace AspNetCoreApplicationTest1.CustomFiles.RepositoriesRazorPages
{
    public class RepositoryControllingRegistrationUsersModel : AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForRazorPagesAndRepository.IControllingRegistrationUsersModel 
    { 
        private const System.String ConstPrivateSystemStringPathOfStaticFilesJsons = "wwwroot/RazorPagesForms/AuthUser/Files/Jsons/"; 
        private readonly AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.RecordClassUndertakeConnectionDataBase_FlyWeight RecordClassUndertakeConnectionDataBaseFlyWeight; 

        void ArraySystemCharsSpecialToStringJSON() 
        { 
            AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.WorkWithFiles.FileJson NewFileJson = new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.WorkWithFiles.FileJson(ConstPrivateSystemStringPathOfStaticFilesJsons + "RegistrationUserMainData"); 
            NewFileJson.CreateConstArray("RegistrationUserMainDataJSON_ARRAY_CHARS_SPECIAL"); 
            foreach (System.Char Char in AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForProtectDataBase.Cashing.CashFunctionGOST3411.ARRAY_SYSTEM_CHARS_SPECIAL) 
                NewFileJson.AppendInConstArray("\t`" + Char + "`"); 
            NewFileJson.CloseConstArray(); NewFileJson.Save(); 
        } 

        public RepositoryControllingRegistrationUsersModel(AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase Connection_DataBase) 
        { 
            RecordClassUndertakeConnectionDataBaseFlyWeight = new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.RecordClassUndertakeConnectionDataBase_FlyWeight(Connection_DataBase); 
            ArraySystemCharsSpecialToStringJSON(); 
        } 

        public System.Boolean AddRecordNewUser(in AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassRegistrationUserForm Form) => 
            RecordClassUndertakeConnectionDataBaseFlyWeight.GetDataInformation().TableRegistrationUsers_AddRecordNewUser(
                (new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForRepositories.PreparationDataToSendInDataBase.ModelRegistrationUsers_Builder())
                .SetName(Form.Name).SetSurname(Form.Surname).SetBirthDay(Form.BirthDay).SetGender(Form.MaleStringBool)
                .SetEmail(Form.E_MailAddress).SetPassword(Form.Password, Form.RepeatPassword).Build()) ? RecordClassUndertakeConnectionDataBaseFlyWeight.SaveChangesInDataBase() : false; 

            //System.Console.WriteLine("Repository " + System.GC.GetGeneration(RecordClassUndertakeConnectionDataBaseFlyWeight)); System.GC.Collect(System.GC.GetGeneration(RecordClassUndertakeConnectionDataBaseFlyWeight)); }

        public System.Boolean DeleteRecordUser(System.UInt32 ID_User) 
        { 
            throw new NotImplementedException();
        }

        public System.Boolean CheckAuthorizationUser(in AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers RegistrationUser, in System.String FormPassword) => 
            ( RegistrationUser != null && RegistrationUser.HashPassword == ( new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForProtectDataBase.Cashing.CashFunctionGOST3411() ).CashEncodeText(FormPassword, AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase_FlyWeight.HASH_PASSWORD_LENGTH).Result ); 

        public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers> GetAllRecordsUsers() => RecordClassUndertakeConnectionDataBaseFlyWeight.GetDataInformation().TableRegistrationUsers_GetAllRegistrationUsers(); 

        public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers GetRecordUser(System.UInt32 ID_User) => RecordClassUndertakeConnectionDataBaseFlyWeight.GetDataInformation().TableRegistrationUsers_GetRegistrationUser(ID_User: ID_User); 
        public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers GetRecordUser(in System.String E_MailAddressUser) => RecordClassUndertakeConnectionDataBaseFlyWeight.GetDataInformation().TableRegistrationUsers_GetRegistrationUser(E_MailAddressUser: E_MailAddressUser); 

    }
} 
