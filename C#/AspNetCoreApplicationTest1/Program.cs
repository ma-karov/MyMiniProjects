
using Microsoft.EntityFrameworkCore;

Microsoft.AspNetCore.Builder.WebApplicationBuilder NewWebApplicationBuilder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args); 
NewWebApplicationBuilder.Services.AddControllersWithViews(); 

NewWebApplicationBuilder.Services.AddDbContext<AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase>(optionsAction: delegate(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder ConnectionDataBaseOptionsBuilder) { ConnectionDataBaseOptionsBuilder.UseSqlServer(NewWebApplicationBuilder.Configuration.GetConnectionString("StringConnection_SqlServerDataBase_MainProject")); }, contextLifetime: Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton ); 

//NewWebApplicationBuilder.Services.

//NewWebApplicationBuilder.Services.AddTransient<AspNetCoreApplicationTest1.Interfaces.IGetListCarsModel, AspNetCoreApplicationTest1.Mocks.MockGetListCarsModel>(); 
//NewWebApplicationBuilder.Services.AddTransient<AspNetCoreApplicationTest1.Interfaces.IGetListCarsCategoriesModel, AspNetCoreApplicationTest1.Mocks.MockGetListCarsCategoriesModel>(); 

// Controllers - Interface
NewWebApplicationBuilder.Services.AddTransient<AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsModel, AspNetCoreApplicationTest1.CustomFiles.RepositoriesControllers.RepositoryGetListCarsModel>().AddTransient<AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForControllersAndRepository.IGetListCarsCategoriesModel, AspNetCoreApplicationTest1.CustomFiles.RepositoriesControllers.RepositoryGetListCarsCategoriesModel>(); 

// RazorPages - Interface
NewWebApplicationBuilder.Services.AddTransient<AspNetCoreApplicationTest1.CustomFiles.Interfaces.ForRazorPagesAndRepository.IControllingRegistrationUsersModel, AspNetCoreApplicationTest1.CustomFiles.RepositoriesRazorPages.RepositoryControllingRegistrationUsersModel>(); 

// Sessions 
NewWebApplicationBuilder.Services.AddDistributedMemoryCache().AddSession( 
    configure: delegate(Microsoft.AspNetCore.Builder.SessionOptions SessionOption) 
    { 
        SessionOption.IdleTimeout = System.TimeSpan.FromSeconds(10); 
        SessionOption.Cookie.IsEssential = true; 
        SessionOption.Cookie.Name = AspNetCoreApplicationTest1.CustomFiles.Models.DataBaseSqlServer.ConnectionDataBase_FlyWeight.SESSIONS_COOKIES_NAME; 
    } ).AddAuthentication(
    configureOptions: delegate(Microsoft.AspNetCore.Authentication.AuthenticationOptions AuthenticationOption)
    {
        AuthenticationOption.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme; 

    } )// (defaultScheme: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
    .Services.AddAuthorization( 
    configure: delegate(Microsoft.AspNetCore.Authorization.AuthorizationOptions AspNetCoreAuthorizationOptions) 
    { 
        AspNetCoreAuthorizationOptions.AddPolicy(name: "RequireAdmininistratorOnly", 
            configurePolicy: delegate(Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder AuthorizationPolicy_Builder)
            { 
                //AuthorizationPolicy_Builder.RequireRole(roles: "");
                AuthorizationPolicy_Builder.RequireClaim(claimType: "Administrator", allowedValues: "True"); 
            } ); 
        //AspNetCoreAuthorizationOptions.AddPolicy("RequireAdminOnly", new Microsoft.AspNetCore.Authorization.AuthorizationPolicy(requirements: new Microsoft.AspNetCore.Authorization.IAuthorizationRequirement[] { new System.Security.Claims.Claim(null) }, authenticationSchemes: new System.String[] { } ) ); 
    } ); 

NewWebApplicationBuilder.Services.AddMvc().Services.AddRazorPages(); 
Microsoft.AspNetCore.Builder.WebApplication NewWebApplication = NewWebApplicationBuilder.Build(); 

if (!NewWebApplication.Environment.IsDevelopment()) 
    NewWebApplication.UseExceptionHandler("/Home/Error").UseHsts(); 

NewWebApplication.UseHttpsRedirection().UseStaticFiles().UseRouting().UseSession().UseAuthentication().UseAuthorization().UseEndpoints(endpoints => endpoints.MapRazorPages()) ;

NewWebApplication.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"); NewWebApplication.Run();

