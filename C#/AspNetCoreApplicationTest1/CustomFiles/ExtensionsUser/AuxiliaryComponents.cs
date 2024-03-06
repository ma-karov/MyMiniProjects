
namespace AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser
{ 
    namespace ForRepositories 
    { 
        public record class RecordClassUndertakeConnectionDataBase_FlyWeight  
        { 
            private readonly AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase Connection_DataBase; 
            private readonly AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase; 

            public RecordClassUndertakeConnectionDataBase_FlyWeight(AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase Connection_DataBase) 
            { 
                this.Connection_DataBase = Connection_DataBase; 
                WorkingInformationDataConnectionDataBase = Connection_DataBase.GetDataInformation(); 
            } 

            public AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase GetDataInformation() => WorkingInformationDataConnectionDataBase; 
            
            public System.Boolean SaveChangesInDataBase() => WorkingInformationDataConnectionDataBase.SaveChangesInAllTables(Connection_DataBase); 

        } 

        namespace PreparationDataToPrintOnPages
        { 
            public class ModelCar_Facade 
            { 
                private AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories ModelCarCategory; private System.String SystemStringModelCar; 

                public ModelCar_Facade SetModelCar(in AspNetCoreApplicationTest1.CustomFiles.Models.Cars ModelCar) 
                { 
                    ModelCarCategory = ModelCar.CarCategory; 
                    SystemStringModelCar = "\t + { " + $"\"ID\": {ModelCar.ID}, \n\t\"Name\": \"{ModelCar.Name}\", \n\t\"Description\": \"{ModelCar.Description}\", \n\t\"Price\": {ModelCar.Price}, \n\t"; 
                    return this; 
                } 

                public System.String ToStringJSON_WithoutForeignObject() => SystemStringModelCar + "\"CarCategoryID\": " + ModelCarCategory.ID + "} "; 
                public System.String ToStringJSON_WithForeignObject() => SystemStringModelCar + $"\"CarCategory\": " + "{ \n\t\t" + $"\"ID\": {ModelCarCategory.ID}, \n\t\t\"Name\": \"{ModelCarCategory.Name}\", \"Description\": \"{ModelCarCategory.Description}\" " + "\n} \n} "; 
            } 
        } 

        namespace PreparationDataToSendInDataBase
        {
            public record struct ModelRegistrationUsers_Builder 
            { 
                readonly AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations ModelRegistrationUsers_ContactInformations; 

                public ModelRegistrationUsers_Builder() => ModelRegistrationUsers_ContactInformations = new AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations(); 
                
                public ModelRegistrationUsers_Builder SetSurname(System.String SystemString) 
                { 
                    ModelRegistrationUsers_ContactInformations.Surname = SystemString; 
                    return this; 
                } 

                public ModelRegistrationUsers_Builder SetName(System.String SystemString) 
                { 
                    ModelRegistrationUsers_ContactInformations.Name = SystemString; 
                    return this; 
                } 

                public ModelRegistrationUsers_Builder SetBirthDay(System.DateTime SystemString) 
                { 
                    ModelRegistrationUsers_ContactInformations.BirthDay = new System.DateOnly(year: SystemString.Year, month: SystemString.Month, day: SystemString.Day); 
                    return this; 
                } 

                public ModelRegistrationUsers_Builder SetGender(System.String SystemString) 
                { 
                    ModelRegistrationUsers_ContactInformations.MaleBool = SystemString == "Male"; 
                    return this; 
                } 

                public ModelRegistrationUsers_Builder SetEmail(System.String SystemString) 
                { 
                    ModelRegistrationUsers_ContactInformations.RegistrationUser.E_MailAddress = SystemString; 
                    return this; 
                } 

                public ModelRegistrationUsers_Builder SetPassword(System.String Password, System.String RepeatPassword) 
                { 
                    AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForProtectDataBase.ICashingFunctions ClassCashFunctions = new AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForProtectDataBase.Cashing.CashFunctionGOST3411(); 
                    ModelRegistrationUsers_ContactInformations.RegistrationUser.HashPassword = ClassCashFunctions.CashEncodeText(Password, AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase_FlyWeight.HASH_PASSWORD_LENGTH).Result; 
                    return this; 
                } 

                public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations Build() => ModelRegistrationUsers_ContactInformations; 
            } 
        } 
    } 

    namespace ForDataBaseModels 
    { 
        namespace DataTypes 
        { 
            [System.Flags]
            public enum RegistrationUsers_PermissionRolesENUM : System.Byte 
            { 
                None, 
                ADMINISTRATOR, 
                SIMPLE_USER, 
                USER_CREATE_CHAT = 4, 
                USER_CREATE_VIDEOMEETING = 8, 
                USER_CREATE_SOCIETY = 16 
            } 
        } 

        namespace ConvertersFromDbToThis 
        { 
            public class DateOnlyConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<System.DateOnly, System.DateTime>
            {
                public DateOnlyConverter() : base(dateOnly => dateOnly.ToDateTime(System.TimeOnly.MinValue), dateTime => System.DateOnly.FromDateTime(dateTime)) {}
            }

            public class DateOnlyComparer : Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<System.DateOnly>
            {
                public DateOnlyComparer() : base((d1, d2) => d1.DayNumber == d2.DayNumber, d => d.GetHashCode()) {} 
            }
            
            public class TimeOnlyConverter : Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<System.TimeOnly, System.TimeSpan>
            {
                public TimeOnlyConverter() : base(timeOnly => timeOnly.ToTimeSpan(), timeSpan => System.TimeOnly.FromTimeSpan(timeSpan)) {}
            }

            public class TimeOnlyComparer : Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<System.TimeOnly>
            {
                public TimeOnlyComparer() : base((t1, t2) => t1.Ticks == t2.Ticks, t => t.GetHashCode()) {} 
            }
        }
    } 

    namespace ForProtectDataBase.Cashing
    { 
        public class CashFunctionGOST3411 : AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForProtectDataBase.ICashingFunctions 
        { 
            public static System.Char []ARRAY_SYSTEM_CHARS_SPECIAL = new System.Char[] { '!', '@', '\'', '№', '#', '$', '%', '^', '*', '(', ')', '[', ']', '{', '}', ':', ',', '.', '?', '-', '_', '+' }; 

            static System.String GetExeFile(System.String SystemStringPathEXE) => @$"CustomFiles/ExtensionsUser/Files/Exe/{SystemStringPathEXE}.exe";
        
            static System.Boolean BetweenBool(System.Char SystemChar1, System.Char SystemChar2, System.Char SystemChar3) => SystemChar1 >= SystemChar2 && SystemChar1 <= SystemChar3; 

            static System.String CorrectEnterMessageToExeFileParameter(System.String SystemString) 
            { 
                SystemString += "\0"; System.String NewSystemString = System.String.Empty; System.Char SystemChar = SystemString[0]; 
                for (System.UInt16 i = 1; SystemChar != '\0'; SystemChar = SystemString[i++]) if (FilterCharInjectionCMD(SystemChar)) NewSystemString += SystemChar; 
                return NewSystemString; 
            }  

            public static System.Boolean FilterCharInjectionCMD(System.Char SystemChar) 
            { 
                if (BetweenBool(SystemChar, 'A', 'Z') || BetweenBool(SystemChar, 'a', 'z') || BetweenBool(SystemChar, '0', '9') || BetweenBool(SystemChar, 'А', 'Я') || BetweenBool(SystemChar, 'а', 'я')) 
                    return true; 
                
                foreach (System.Char SystemCharForeach in ARRAY_SYSTEM_CHARS_SPECIAL) 
                    if (SystemChar == SystemCharForeach) 
                        return true; 
                return false; 
            } 

            public async System.Threading.Tasks.Task<System.String> CashEncodeText(System.String SystemStringEnterMessage, System.UInt16 TypeEncode) 
            { 
                System.String SystemString = new System.String(""); 
                await System.Threading.Tasks.Task.Run( delegate ()  
                { 
                    System.Diagnostics.Process CommandString = new System.Diagnostics.Process() 
                    { 
                        StartInfo = new System.Diagnostics.ProcessStartInfo() 
                        { 
                            FileName = GetExeFile("C++/NewCashFunctions 2"), 
                            Arguments = CorrectEnterMessageToExeFileParameter(SystemStringEnterMessage) + " " + TypeEncode, 
                            RedirectStandardOutput = true, RedirectStandardError = true 
                        } 
                    }; 
                    CommandString.Start(); System.IO.StreamReader CommandStringStandardOutput = CommandString.StandardOutput; CommandString.Dispose(); //System.Console.Out.WriteLine("Async2() " + CommandStringStandardOutput.ReadToEnd()); 
                    do SystemString += CommandStringStandardOutput.ReadLine(); while(!CommandStringStandardOutput.EndOfStream); 
                } ); 
                return SystemString; 
            }        
        }
    } 

}
