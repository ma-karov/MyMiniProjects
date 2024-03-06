using AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.CollectionsIEnumerable; 
using Microsoft.EntityFrameworkCore; 

namespace AspNetCoreApplicationTest1.CustomFiles.Models 
{ 
    namespace DataBaseSqlServer 
    {
        public class ConnectionDataBase : Microsoft.EntityFrameworkCore.DbContext, AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase 
        { 
            readonly Microsoft.EntityFrameworkCore.DbSet<Cars> DbSetCars; //{ get; set; } 
            readonly Microsoft.EntityFrameworkCore.DbSet<CarsCategories> DbSetCarsCategories; //{ get; set; } 
            
            readonly Microsoft.EntityFrameworkCore.DbSet<RegistrationUsers_ContactInformations> DbSetRegistrationUsers_ContactInformations; 
            readonly Microsoft.EntityFrameworkCore.DbSet<RegistrationUsers> DbSetRegistrationUsers; 
            readonly Microsoft.EntityFrameworkCore.DbSet<RegistrationUsers_GroupRoles> DbSetRegistrationUsers_GroupRoles; 
            
            readonly Microsoft.EntityFrameworkCore.DbSet<RegistrationUsers_ImagesAndVideosAlbumsGraph> DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph; 
            readonly Microsoft.EntityFrameworkCore.DbSet<RegistrationUsers_ImagesAlbums> DbSetRegistrationUsers_ImagesAlbums; 
            readonly Microsoft.EntityFrameworkCore.DbSet<RegistrationUsers_VideosAlbums> DbSetRegistrationUsers_VideosAlbums; 

            readonly ConnectionDataBase_Facade ConnectionDataBaseFacade; 

            protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder EntityFrameworkCoreModelBuilder) 
            { 
                EntityFrameworkCoreModelBuilder.Entity<Cars>().ToTable<Cars>("Cars").HasOne<CarsCategories>(Car => Car.CarCategory).WithMany().HasForeignKey(CarForeign => CarForeign.CarCategory_ID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade); 
                EntityFrameworkCoreModelBuilder.Entity<CarsCategories>().ToTable<CarsCategories>("CarsCategories"); 
                

                EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers_GroupRoles>().ToTable<RegistrationUsers_GroupRoles>("RegistrationUsers_GroupRoles").Property<System.String []>((RegistrationUsers_GroupRoles RegistrationUser_GroupRoles) => RegistrationUser_GroupRoles.ArrayStringPermission).HasConversion(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<System.String [], System.String>( (System.String []SystemStringArray) => Newtonsoft.Json.JsonConvert.SerializeObject(SystemStringArray), (System.String SystemString) => Newtonsoft.Json.JsonConvert.DeserializeObject<System.String []>(SystemString) ) ); 
                EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers_GroupRoles>().ToTable<RegistrationUsers_GroupRoles>("RegistrationUsers_GroupRoles").Property<System.Boolean []>((RegistrationUsers_GroupRoles RegistrationUser_GroupRoles) => RegistrationUser_GroupRoles.ArrayBoolPermission).HasConversion(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<System.Boolean [], System.String>( (System.Boolean []SystemBooleanArray) => Newtonsoft.Json.JsonConvert.SerializeObject(SystemBooleanArray), (System.String SystemString) => Newtonsoft.Json.JsonConvert.DeserializeObject<System.Boolean []>(SystemString) ) ); 

                //EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers>().ToTable<RegistrationUsers>("RegistrationUsers").HasOne<RegistrationUsers_ContactInformations>(RegistrationUser => RegistrationUser.ContactInformation).WithOne().HasForeignKey<RegistrationUsers>(RegistrationUser => RegistrationUser.ContactInformation_ID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade); 
            
                EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers>().ToTable<RegistrationUsers>("RegistrationUsers").HasOne<RegistrationUsers_GroupRoles>(RegistrationUser => RegistrationUser.PermissionGroupRole).WithOne().HasForeignKey<RegistrationUsers>((RegistrationUsers RegistrationUser) => RegistrationUser.PermissionGroupRole_ID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull); 

                EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers_ContactInformations>((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RegistrationUsers_ContactInformations> MetaDataEntityTypeBuilder) =>
                { 
                    MetaDataEntityTypeBuilder.ToTable<RegistrationUsers_ContactInformations>("RegistrationUsers_ContactInformations").HasOne<RegistrationUsers>((RegistrationUsers_ContactInformations RegistrationUser_ContactInformations) => RegistrationUser_ContactInformations.RegistrationUser).WithOne().HasForeignKey<RegistrationUsers_ContactInformations>((RegistrationUsers_ContactInformations RegistrationUser_ContactInformations) => RegistrationUser_ContactInformations.RegistrationUser_ID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade); 

                    MetaDataEntityTypeBuilder.Property<System.DateOnly>((RegistrationUsers_ContactInformations RegistrationUser_ContactInformation) => RegistrationUser_ContactInformation.BirthDay).HasConversion<AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForDataBaseModels.ConvertersFromDbToThis.DateOnlyConverter, AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForDataBaseModels.ConvertersFromDbToThis.DateOnlyComparer>();
 
                    // Time is a TimeOnly property and time on database builder.Property(x => x.Time).HasConversion<TimeOnlyConverter, TimeOnlyComparer>(); 
                    
                } ); 

                
                EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers_ImagesAndVideosAlbumsGraph>().ToTable<RegistrationUsers_ImagesAndVideosAlbumsGraph>("RegistrationUsers_ImagesAndVideosAlbumsGraph").HasOne<RegistrationUsers>((RegistrationUsers_ImagesAndVideosAlbumsGraph RegistrationUser_ImagesAndVideosAlbumsGraph) => RegistrationUser_ImagesAndVideosAlbumsGraph.RegistrationUser).WithOne().HasForeignKey<RegistrationUsers_ImagesAndVideosAlbumsGraph>((RegistrationUsers_ImagesAndVideosAlbumsGraph RegistrationUser_ImagesAndVideosAlbumsGraph) => RegistrationUser_ImagesAndVideosAlbumsGraph.RegistrationUser_ID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull); 

                EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers_ImagesAlbums>().ToTable<RegistrationUsers_ImagesAlbums>("RegistrationUsers_ImagesAlbums").HasOne<RegistrationUsers_ImagesAndVideosAlbumsGraph>((RegistrationUsers_ImagesAlbums RegistrationUser_ImagesAlbums) => RegistrationUser_ImagesAlbums.ImagesAndVideosAlbumsGraph).WithOne().HasForeignKey<RegistrationUsers_ImagesAlbums>((RegistrationUsers_ImagesAlbums RegistrationUser_ImagesAlbums) => RegistrationUser_ImagesAlbums.ImagesAndVideosAlbumsGraph_ID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade); 

                EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers_VideosAlbums>().ToTable<RegistrationUsers_VideosAlbums>("RegistrationUsers_VideosAlbums").HasOne<RegistrationUsers_ImagesAndVideosAlbumsGraph>((RegistrationUsers_VideosAlbums RegistrationUser_VideosAlbums) => RegistrationUser_VideosAlbums.ImagesAndVideosAlbumsGraph).WithOne().HasForeignKey<RegistrationUsers_VideosAlbums>((RegistrationUsers_VideosAlbums RegistrationUser_VideosAlbums) => RegistrationUser_VideosAlbums.ImagesAndVideosAlbumsGraph_ID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade); 

                //EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers>().ToTable("RegistrationUsers").HasMany<RegistrationUsers_GroupRoles>(RegistrationUser => RegistrationUser.PermissionGroupRole).WithOne().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull); 
                //EntityFrameworkCoreModelBuilder.Entity<RegistrationUsers_GroupRoles>().ToTable("RegistrationUsers_GroupRoles").HasOne<RegistrationUsers>((RegistrationUsers_GroupRoles RegistrationUser_GroupRole) => RegistrationUser_GroupRole.RegistrationUser).WithOne().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.SetNull); 


                base.OnModelCreating(EntityFrameworkCoreModelBuilder); 
            } 

        
            protected override void OnConfiguring(DbContextOptionsBuilder ConnectionDataBaseOptionsBuilder)
            { 
                //ConnectionDataBaseOptionsBuilder.UseSqlServer(ConnectionStringToDataBase); 
                base.OnConfiguring(ConnectionDataBaseOptionsBuilder);
            } 

            void ClearDataBaseALL() 
            { 
                DbSetCarsCategories.RemoveRange(DbSetCarsCategories); DbSetCars.RemoveRange(DbSetCars); DbSetRegistrationUsers.RemoveRange(DbSetRegistrationUsers); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"CarsCategories\", RESEED, 0); DBCC CheckIdent(\"Cars\", RESEED, 0); DBCC CheckIdent(\"RegistrationUsers\", RESEED, 0); "); 

                DbSetRegistrationUsers_ContactInformations.RemoveRange(DbSetRegistrationUsers_ContactInformations); 
                DbSetRegistrationUsers_GroupRoles.RemoveRange(DbSetRegistrationUsers_GroupRoles); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_ContactInformations\", RESEED, 0); DBCC CheckIdent(\"RegistrationUsers_GroupRoles\", RESEED, 0); "); 

                DbSetRegistrationUsers_ImagesAlbums.RemoveRange(DbSetRegistrationUsers_ImagesAlbums); 
                DbSetRegistrationUsers_VideosAlbums.RemoveRange(DbSetRegistrationUsers_VideosAlbums); 
                DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph.RemoveRange(DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_ImagesAlbums\", RESEED, 0); DBCC CheckIdent(\"RegistrationUsers_VideosAlbums\", RESEED, 0); DBCC CheckIdent(\"RegistrationUsers_ImagesAndVideosAlbumsGraph\", RESEED, 0); "); 
                
                SaveChanges(); 
            } 

            void AddOnesDataInDataBase() 
            { 
                ClearDataBaseALL(); 
                if (!DbSetCars.Any()) DbSetCars.AddRange( (new MocksController.MockGetListCarsModel()).AllCars() ); 
                //if (!DbSetCarsCategories.Any()) DbSetCarsCategories.AddRange( (new MocksController.MockGetListCarsCategoriesModel()).AllCategories() ); 
                SaveChanges(); 
            } 

            void Overwrite_DbSetCars(System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> ArrayCars) 
            { 
                DbSetCars.RemoveRange(DbSetCars); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"Cars\", RESEED, 0); "); 
                DbSetCars.AddRange(ArrayCars); 
            } 

            void Overwrite_DbSetCategoriesCars(System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories> ArrayCarsCategories) 
            { 
                DbSetCarsCategories.RemoveRange(DbSetCarsCategories); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"CarsCategories\", RESEED, 0); "); 
                DbSetCarsCategories.AddRange(ArrayCarsCategories); 
            } 

            void Overwrite_DbSetRegistrationUsers_ContactInformations(System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations> ArrayRegistrationUsers_ContactInformations) 
            { 
                DbSetRegistrationUsers_ContactInformations.RemoveRange(); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_ContactInformations\", RESEED, 0); "); 
                DbSetRegistrationUsers_ContactInformations.AddRange(ArrayRegistrationUsers_ContactInformations); 
            } 

            void Overwrite_DbSetRegistrationUsers(System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers> ArrayRegistrationUsers) 
            { 
                DbSetRegistrationUsers.RemoveRange(); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers\", RESEED, 0); "); 
                DbSetRegistrationUsers.AddRange(ArrayRegistrationUsers); 
            } 

            void Overwrite_DbSetRegistrationUsers_GroupRoles(System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_GroupRoles> ArrayRegistrationUsers_GroupRoles) 
            { 
                DbSetRegistrationUsers_GroupRoles.RemoveRange(); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_GroupRoles\", RESEED, 0); "); 
                DbSetRegistrationUsers_GroupRoles.AddRange(ArrayRegistrationUsers_GroupRoles); 
            } 

            void Overwrite_DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph(System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ImagesAndVideosAlbumsGraph> ArrayRegistrationUsers_ImagesAndVideosAlbumsGraph) 
            { 
                DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph.RemoveRange(DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_ImagesAndVideosAlbumsGraph\", RESEED, 0); "); 
                DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph.AddRange(ArrayRegistrationUsers_ImagesAndVideosAlbumsGraph); 
            } 

            void Overwrite_DbSetRegistrationUsers_ImagesAlbums(System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ImagesAlbums> ArrayRegistrationUsers_ImagesAlbums) 
            { 
                DbSetRegistrationUsers_ImagesAlbums.RemoveRange(DbSetRegistrationUsers_ImagesAlbums); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_ImagesAlbums\", RESEED, 0); "); 
                DbSetRegistrationUsers_ImagesAlbums.AddRange(ArrayRegistrationUsers_ImagesAlbums); 
            } 

            void Overwrite_DbSetRegistrationUsers_VideosAlbums(System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_VideosAlbums> ArrayRegistrationUsers_VideosAlbums) 
            { 
                DbSetRegistrationUsers_VideosAlbums.RemoveRange(DbSetRegistrationUsers_VideosAlbums); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_VideosAlbums\", RESEED, 0); "); 
                DbSetRegistrationUsers_VideosAlbums.AddRange(ArrayRegistrationUsers_VideosAlbums); 
            } 

            public ConnectionDataBase(Microsoft.EntityFrameworkCore.DbContextOptions<ConnectionDataBase> ConnectionDataBaseOptions) : base(ConnectionDataBaseOptions) 
            { 
                DbSetCars = Set<Cars>(); 
                DbSetCarsCategories = Set<CarsCategories>(); 
                DbSetRegistrationUsers = Set<RegistrationUsers>(); 
                DbSetRegistrationUsers_ContactInformations = Set<RegistrationUsers_ContactInformations>(); 
                DbSetRegistrationUsers_GroupRoles = Set<RegistrationUsers_GroupRoles>(); 
                
                DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph = Set<RegistrationUsers_ImagesAndVideosAlbumsGraph>(); 
                DbSetRegistrationUsers_ImagesAlbums = Set<RegistrationUsers_ImagesAlbums>(); 
                DbSetRegistrationUsers_VideosAlbums = Set<RegistrationUsers_VideosAlbums>(); 
            
                DbSetCars.Load<Cars>(); DbSetCarsCategories.Load<CarsCategories>(); DbSetRegistrationUsers.Load<RegistrationUsers>(); 
                DbSetRegistrationUsers_ContactInformations.Load<RegistrationUsers_ContactInformations>(); 
                DbSetRegistrationUsers_GroupRoles.Load<RegistrationUsers_GroupRoles>(); 

                DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph.Load<RegistrationUsers_ImagesAndVideosAlbumsGraph>(); 
                DbSetRegistrationUsers_ImagesAlbums.Load<RegistrationUsers_ImagesAlbums>(); 
                DbSetRegistrationUsers_VideosAlbums.Load<RegistrationUsers_VideosAlbums>(); 

                //AddOnesDataInDataBase(); 

                /*DbSetRegistrationUsers_ContactInformations.RemoveRange(DbSetRegistrationUsers_ConutactInformations); 
                DbSetRegistrationUsers.RemoveRange(DbSetRegistrationUsers); 
                DbSetRegistrationUsers_GroupRoles.RemoveRange(DbSetRegistrationUsers_GroupRoles); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_ContactInformations\", RESEED, 0); "); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers\", RESEED, 0); "); 
                Database.ExecuteSqlRaw("DBCC CheckIdent(\"RegistrationUsers_GroupRoles\", RESEED, 0); "); 
                SaveChanges(); */
                
                ConnectionDataBaseFacade = new ConnectionDataBase_Facade(); 
            } 

            //public ConnectionDataBase(System.String ConnectionStringToDataBase) { this.ConnectionStringToDataBase = ConnectionStringToDataBase; Cars = Set<Cars>(); CarsCategories = Set<CarsCategories>(); AddOnesDataInDataBase(); } 

            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> TableCars_GetAllCars() => System.Array.Empty<Cars>(); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> TableCars_GetAllCarsIncludeCategories() => System.Array.Empty<Cars>(); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories> TableCategories_GetAllCategories() => System.Array.Empty<CarsCategories>(); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations> TableRegistrationUsersContactInformations_GetAllContactInformations() => System.Array.Empty<RegistrationUsers_ContactInformations>(); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers> TableRegistrationUsers_GetAllRegistrationUsers() => System.Array.Empty<RegistrationUsers>(); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_GroupRoles> TableRegistrationUsersGroupRoles_GetAllGroupRoles() => System.Array.Empty<RegistrationUsers_GroupRoles>(); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ImagesAndVideosAlbumsGraph> TableRegistrationUsersImagesAndVideosAlbumsGraph_GetAllImagesAndVideosAlbumsGraph() => System.Array.Empty<RegistrationUsers_ImagesAndVideosAlbumsGraph>(); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ImagesAlbums> TableRegistrationUsersImagesAlbums_GetAllImagesAlbums() => System.Array.Empty<RegistrationUsers_ImagesAlbums>(); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_VideosAlbums> TableRegistrationUsersVideosAlbums_GetAllVideosAlbums() => System.Array.Empty<RegistrationUsers_VideosAlbums>(); 

            public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers TableRegistrationUsers_GetRegistrationUser(System.UInt32 ID_User) => new RegistrationUsers(); 
            public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers TableRegistrationUsers_GetRegistrationUser(System.String E_MailAddressUser) => new RegistrationUsers(); 
            public System.Boolean TableRegistrationUsers_AddRecordNewUser(in AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations RegistrationUsersContactInformationsModel) => false; 

            public AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase GetDataInformation() => 
                ConnectionDataBaseFacade.SendDataInformationDataBase( new System.Object[8][] 
                { 
                    DbSetCars.ToArray<Cars>(), 
                    DbSetCarsCategories.ToArray<CarsCategories>(), 
                    
                    DbSetRegistrationUsers_ContactInformations.ToArray<RegistrationUsers_ContactInformations>(), 
                    DbSetRegistrationUsers.ToArray<RegistrationUsers>(), 
                    DbSetRegistrationUsers_GroupRoles.ToArray<RegistrationUsers_GroupRoles>(), 

                    DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph.ToArray<RegistrationUsers_ImagesAndVideosAlbumsGraph>(), 
                    DbSetRegistrationUsers_ImagesAlbums.ToArray<RegistrationUsers_ImagesAlbums>(), 
                    DbSetRegistrationUsers_VideosAlbums.ToArray<RegistrationUsers_VideosAlbums>() 
                } ); 

            
            public System.Boolean SaveChangesInAllTables(in AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase) 
            { 
                System.Boolean SaveRecordsALL_Bool = true; 
                Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction ContextTransactionDB = Database.BeginTransaction(); 
                try
                { 
                    System.Byte IndexSwitch = 1; 
                    foreach (System.Boolean ChangeStateSaveToDataBase_Bool in (WorkingInformationDataConnectionDataBase as AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase_Proxy).ArrayChangeStateSaveToDataBase_Bool) 
                    { 
                        if (ChangeStateSaveToDataBase_Bool) 
                            switch (IndexSwitch)
                            { 
                                case 1: 
                                { 
                                    Overwrite_DbSetCars(WorkingInformationDataConnectionDataBase.TableCars_GetAllCars());  
                                    break; 
                                } 
                                case 2: 
                                { 
                                    Overwrite_DbSetCategoriesCars(WorkingInformationDataConnectionDataBase.TableCategories_GetAllCategories()); 
                                    break; 
                                } 
                                case 3: 
                                { 
                                    Overwrite_DbSetRegistrationUsers_ContactInformations(WorkingInformationDataConnectionDataBase.TableRegistrationUsersContactInformations_GetAllContactInformations()); 
                                    break; 
                                } 
                                case 4: 
                                { 
                                    Overwrite_DbSetRegistrationUsers(WorkingInformationDataConnectionDataBase.TableRegistrationUsers_GetAllRegistrationUsers()); 
                                    break; 
                                } 
                                case 5: 
                                { 
                                    Overwrite_DbSetRegistrationUsers_GroupRoles(WorkingInformationDataConnectionDataBase.TableRegistrationUsersGroupRoles_GetAllGroupRoles()); 
                                    break; 
                                } 
                                case 6: 
                                { 
                                    Overwrite_DbSetRegistrationUsers_ImagesAndVideosAlbumsGraph(WorkingInformationDataConnectionDataBase.TableRegistrationUsersImagesAndVideosAlbumsGraph_GetAllImagesAndVideosAlbumsGraph()); 
                                    break; 
                                } 
                                case 7: 
                                { 
                                    Overwrite_DbSetRegistrationUsers_ImagesAlbums(WorkingInformationDataConnectionDataBase.TableRegistrationUsersImagesAlbums_GetAllImagesAlbums()); 
                                    break; 
                                } 
                                case 8: 
                                { 
                                    Overwrite_DbSetRegistrationUsers_VideosAlbums(WorkingInformationDataConnectionDataBase.TableRegistrationUsersVideosAlbums_GetAllVideosAlbums());  
                                    break; 
                                } 
                            } 
                        IndexSwitch++; 
                    } 

                    SaveChanges(); ContextTransactionDB.Commit(); 
                } 
                catch (System.Exception SystemException) 
                { 
                    ContextTransactionDB.Rollback(); 
                    SaveRecordsALL_Bool = false; 
                } 
                finally 
                { 
                    ContextTransactionDB.Dispose(); 
                } 
                return SaveRecordsALL_Bool; 
            } 
        } 

        public class ConnectionDataBase_Facade 
        { 
            readonly ConnectionDataBase_FlyWeight ConnectionDataBaseFlyWeight; 

            public ConnectionDataBase_Facade() 
            { 
                ConnectionDataBaseFlyWeight = new ConnectionDataBase_FlyWeight( new AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase[1] { new ConnectionDataBase_Proxy() } );
            } 

            public AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase SendDataInformationDataBase(System.Object [][]ArraySystemObjects) => ConnectionDataBaseFlyWeight.GetReferanceObject(ArraySystemObjects, 1); 

        } 

        public class ConnectionDataBase_FlyWeight 
        {
            readonly AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase []ArrayInterfacesConnectionDataBase; 

            public const System.UInt16 HASH_PASSWORD_LENGTH = 32; 
            public const System.String SESSIONS_COOKIES_NAME = "AspNetCoreApplicationTest1_SessionsCookies"; 

            public ConnectionDataBase_FlyWeight(AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase []ArrayInterfacesConnectionDataBase) 
            {
                this.ArrayInterfacesConnectionDataBase = new AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase[ArrayInterfacesConnectionDataBase.Length]; 
                System.Byte i = 0; 
                foreach (AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase Element in ArrayInterfacesConnectionDataBase) 
                    this.ArrayInterfacesConnectionDataBase[i++] = Element; 
            } 

            public AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase GetReferanceObject(System.Object [][]ArraySystemObjects, System.Byte Switch) 
            { 
                AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase Element = ArrayInterfacesConnectionDataBase[Switch - 1]; 
                switch (Switch)
                {
                    case 1:
                    { 
                        ConnectionDataBase_Proxy Proxy = Element as ConnectionDataBase_Proxy; 
                        if (Proxy != null)
                        {
                            Proxy.SetData(ArraySystemObjects); 
                            ArrayInterfacesConnectionDataBase[0] = Proxy; 
                        } 
                        break; 
                    } 
                }

                return Element; 
            } 
        } 

        public class ConnectionDataBase_Proxy : AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase 
        { 
            Cars []ArrayCars; 
            CarsCategories []ArrayCarsCategories; 
            
            RegistrationUsers_ContactInformations []ArrayRegistrationUsers_ContactInformations; 
            RegistrationUsers []ArrayRegistrationUsers; 
            RegistrationUsers_GroupRoles []ArrayRegistrationUsers_GroupRoles; 

            RegistrationUsers_ImagesAndVideosAlbumsGraph []ArrayRegistrationUsers_ImagesAndVideosAlbumsGraph; 
            RegistrationUsers_ImagesAlbums []ArrayRegistrationUsers_ImagesAlbums;
            RegistrationUsers_VideosAlbums []ArrayRegistrationUsers_VideosAlbums; 

            public System.Boolean []ArrayChangeStateSaveToDataBase_Bool;

            static void CopyArray(System.Object []FromArray, System.Object []ToArray) 
            { 
                //ToArray = new System.Object[FromArray.Length]; 
                System.UInt16 i = 0; 
                foreach (System.Object SystemObject in FromArray) 
                    ToArray[i++] = SystemObject; 
            } 

            static RegistrationUsers GetFirstRecordInArray(RegistrationUsers []ArrayRegistrationUsers) => ( ArrayRegistrationUsers.Length == 0 ? null : ArrayRegistrationUsers[0] ); 

            public ConnectionDataBase_Proxy() => ArrayChangeStateSaveToDataBase_Bool = new System.Boolean[8] { false, false, false, false, false, false, false, false }; 

            public void SetData(System.Object [][]ArraySystemObjects) 
            { 
                ArrayCars = new Cars[ArraySystemObjects[0].Length]; 
                CopyArray(ArraySystemObjects[0], ArrayCars); 

                ArrayCarsCategories = new CarsCategories[ArraySystemObjects[1].Length]; 
                CopyArray(ArraySystemObjects[1], ArrayCarsCategories); 


                ArrayRegistrationUsers_ContactInformations = new RegistrationUsers_ContactInformations[ArraySystemObjects[2].Length]; 
                CopyArray(ArraySystemObjects[2], ArrayRegistrationUsers_ContactInformations); 

                ArrayRegistrationUsers = new RegistrationUsers[ArraySystemObjects[3].Length]; 
                CopyArray(ArraySystemObjects[3], ArrayRegistrationUsers); 

                ArrayRegistrationUsers_GroupRoles = new RegistrationUsers_GroupRoles[ArraySystemObjects[4].Length]; 
                CopyArray(ArraySystemObjects[4], ArrayRegistrationUsers_GroupRoles); 


                ArrayRegistrationUsers_ImagesAndVideosAlbumsGraph = new RegistrationUsers_ImagesAndVideosAlbumsGraph[ArraySystemObjects[5].Length]; 
                CopyArray(ArraySystemObjects[5], ArrayRegistrationUsers_ImagesAndVideosAlbumsGraph); 

                ArrayRegistrationUsers_ImagesAlbums = new RegistrationUsers_ImagesAlbums[ArraySystemObjects[6].Length]; 
                CopyArray(ArraySystemObjects[6], ArrayRegistrationUsers_GroupRoles); 

                ArrayRegistrationUsers_VideosAlbums = new RegistrationUsers_VideosAlbums[ArraySystemObjects[7].Length]; 
                CopyArray(ArraySystemObjects[7], ArrayRegistrationUsers_VideosAlbums); 
            } 

            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> TableCars_GetAllCars() => ArrayCars; 

            //public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> TableCars_GetAllCarsIncludeCategories() => ArrayCars.Where<Cars>(Car => ArrayCarsCategories.Where<CarsCategories>(CarCategory => CarCategory.ID == Car.CarCategory_ID).Select<CarsCategories, System.UInt16>(CarCategoryAs => CarCategoryAs.ID).Contains<System.UInt16>(Car.CarCategory_ID)); 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.Cars> TableCars_GetAllCarsIncludeCategories() => 
                ( from Cars Car in ArrayCars 
                  where ( from CarsCategories CarCategory in ArrayCarsCategories where CarCategory.ID == Car.CarCategory_ID select true ).First<System.Boolean>() 
                  select Car ).ToArray<Cars>(); 
            
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.CarsCategories> TableCategories_GetAllCategories() => ArrayCarsCategories; 

            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations> TableRegistrationUsersContactInformations_GetAllContactInformations() => ArrayRegistrationUsers_ContactInformations; 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers> TableRegistrationUsers_GetAllRegistrationUsers() => ArrayRegistrationUsers; 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_GroupRoles> TableRegistrationUsersGroupRoles_GetAllGroupRoles() => ArrayRegistrationUsers_GroupRoles; 

            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ImagesAndVideosAlbumsGraph> TableRegistrationUsersImagesAndVideosAlbumsGraph_GetAllImagesAndVideosAlbumsGraph() => ArrayRegistrationUsers_ImagesAndVideosAlbumsGraph; 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ImagesAlbums> TableRegistrationUsersImagesAlbums_GetAllImagesAlbums() => ArrayRegistrationUsers_ImagesAlbums; 
            public System.Collections.Generic.IEnumerable<AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_VideosAlbums> TableRegistrationUsersVideosAlbums_GetAllVideosAlbums() => ArrayRegistrationUsers_VideosAlbums; 

            public System.Boolean TableRegistrationUsers_AddRecordNewUser(in AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers_ContactInformations RegistrationUsersContactInformationsModel) 
            { 
                System.String RegistrationUsersContactInformationsModel_E_Mail = RegistrationUsersContactInformationsModel.RegistrationUser.E_MailAddress;
                if ( ( from RegistrationUsers RegistrationUser in ArrayRegistrationUsers where RegistrationUser.E_MailAddress == RegistrationUsersContactInformationsModel_E_Mail select true ).ToArray<System.Boolean>() != System.Array.Empty<System.Boolean>() ) 
                    return false; 

                RegistrationUsersContactInformationsModel.RegistrationUser.DateRegistration = System.DateTime.Now; 

                ArrayRegistrationUsers = ArrayRegistrationUsers.ExtensionsUser_AddElementLast<RegistrationUsers>(RegistrationUsersContactInformationsModel.RegistrationUser); 
                ArrayRegistrationUsers_ContactInformations = ArrayRegistrationUsers_ContactInformations.ExtensionsUser_AddElementLast<RegistrationUsers_ContactInformations>(RegistrationUsersContactInformationsModel);  
                ArrayRegistrationUsers_GroupRoles = ArrayRegistrationUsers_GroupRoles.ExtensionsUser_AddElementLast<RegistrationUsers_GroupRoles>(RegistrationUsersContactInformationsModel.RegistrationUser.PermissionGroupRole);  
                ArrayChangeStateSaveToDataBase_Bool[2] = ArrayChangeStateSaveToDataBase_Bool[3] = ArrayChangeStateSaveToDataBase_Bool[4] = true; 
                return true; 
            } 

            public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers TableRegistrationUsers_GetRegistrationUser(System.UInt32 ID_User) => GetFirstRecordInArray(ArrayRegistrationUsers.Where<RegistrationUsers>((RegistrationUsers RegistrationUser) => RegistrationUser.ID == ID_User).ToArray<RegistrationUsers>()); 
            public AspNetCoreApplicationTest1.CustomFiles.Models.RegistrationUsers TableRegistrationUsers_GetRegistrationUser(System.String E_MailAddressUser) => GetFirstRecordInArray(ArrayRegistrationUsers.Where<RegistrationUsers>((RegistrationUsers RegistrationUser) => RegistrationUser.E_MailAddress == E_MailAddressUser).ToArray<RegistrationUsers>()); 

            /*public System.Boolean SaveChangesInTableCars(in AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase) => WorkingInformationDataConnectionDataBase.SaveChangesInTableCars(this); 
            public System.Boolean SaveChangesInTableCarsCategories(in AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase) => WorkingInformationDataConnectionDataBase.SaveChangesInTableCarsCategories(this); 
            public System.Boolean SaveChangesInTableRegistrationUsers(in AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase) => WorkingInformationDataConnectionDataBase.SaveChangesInTableRegistrationUsers(this); 
            
            public System.Boolean SaveChangesInTableRegistrationUsersContactInformations(in AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase) => WorkingInformationDataConnectionDataBase.SaveChangesInTableRegistrationUsersContactInformations(this); 
            public System.Boolean SaveChangesInTableRegistrationUsersGroupRoles(in AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase) => WorkingInformationDataConnectionDataBase.SaveChangesInTableRegistrationUsersGroupRoles(this); */

            public System.Boolean SaveChangesInAllTables(in AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForSettingsDataBases.IWorkingInformationDataConnectionDataBase WorkingInformationDataConnectionDataBase)  
            {  
                System.Boolean SaveChangesInAllTables_Bool = WorkingInformationDataConnectionDataBase.SaveChangesInAllTables(this); 
                System.Byte Index = new System.Byte(); Index = 0; 
                foreach (System.Boolean ChangeStateSaveToDataBase_Bool in ArrayChangeStateSaveToDataBase_Bool) 
                    ArrayChangeStateSaveToDataBase_Bool[Index++] = false; 
                return SaveChangesInAllTables_Bool; 
            } 
            
        } 
    } 
}