
namespace AspNetCoreApplicationTest1.CustomFiles.Models 
{ 
    public class Cars 
    { 
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Smallint"), System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] 
        public System.UInt16 ID { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(30)] 
        public System.String Name { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(200)] 
        public System.String Description { get; set; } 

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Smallint")] 
        public System.Nullable<System.UInt16> Price { get; set; } 

//        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CarCategory_ID")] 
        public CarsCategories CarCategory { get; set; } 
        public System.UInt16 CarCategory_ID { get; set; } 

//        public override System.String ToString() => $"ID: {ID}, \n\tName: {Name}, \n\tDescription: { ( Description == "" ? "\"\"" : Description ) }, \n\tPrice: {Price}, \n\tCarCategoryID: {CarCategory.Id}"; 
                
    }

    public class CarsCategories 
    { 
        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Smallint"), System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] 
        public System.UInt16 ID { get; set; }  

        [System.ComponentModel.DataAnnotations.MaxLength(30)] 
        public System.String Name { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(200)] 
        public System.String Description { get; set; } 

    } 
    
    public class RegistrationUsers_ContactInformations 
    {
        [System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] 
        public System.UInt32 ID { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(50)] 
        public System.String LinkAccess { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(50)] 
        public System.String Surname { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(30)] 
        public System.String Name { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(15)] 
        public System.String PhoneNumber { get; set; } 

        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date), System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Date")]
        public System.DateOnly BirthDay { get; set; } 

        public System.Boolean MaleBool { get; set; } 

        public RegistrationUsers RegistrationUser { get; set; } 
        public System.Nullable<System.UInt32> RegistrationUser_ID { get; set; } 

        public RegistrationUsers_ContactInformations() 
        { 
            LinkAccess = PhoneNumber = ""; 
            RegistrationUser = new RegistrationUsers(); 
            RegistrationUser_ID = RegistrationUser.ID; 
        } 
    } 

    public class RegistrationUsers 
    {
        [System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] 
        public System.UInt32 ID { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(50)] 
        public System.String E_MailAddress { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(System.UInt16.MaxValue)] 
        public System.String HashPassword { get; set; } 

        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date), System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Date")]
        public System.DateTime DateRegistration { get; set; } 

        //public System.Collections.Generic.ICollection<RegistrationUsers_GroupRoles> PermissionGroupRole { get; set; }         
        public RegistrationUsers_GroupRoles PermissionGroupRole { get; set; } 
        public System.Nullable<System.Byte> PermissionGroupRole_ID { get; set; } 

        public RegistrationUsers() 
        { 
            PermissionGroupRole = new RegistrationUsers_GroupRoles(); 
            PermissionGroupRole_ID = PermissionGroupRole.ID; 
        } 
    } 

    public class RegistrationUsers_GroupRoles 
    {
        [System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] 
        public System.Byte ID { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(System.UInt16.MaxValue)] 
        public System.String []ArrayStringPermission { get; set; } 
        
        [System.ComponentModel.DataAnnotations.MaxLength(System.UInt16.MaxValue)] 
        public System.Boolean []ArrayBoolPermission { get; set; } 

        //public RegistrationUsers RegistrationUser { get; set; } public System.UInt32 RegistrationUser_ID { get; set; } 

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "TinyInt")] 
        public AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForDataBaseModels.DataTypes.RegistrationUsers_PermissionRolesENUM RegistrationUser_PermissionRoleENUM { get; set; } 

        public RegistrationUsers_GroupRoles() 
        { 
            const System.Byte ARRAY_PERMISSION_LENGTH = 8; 
            ArrayStringPermission = new System.String[ARRAY_PERMISSION_LENGTH] { "User Account Control", "Chat Control", "Association Control", "Video Control", "Audio Control", "Image Control", "Send Message", "Send Proposal Amity" };
            ArrayBoolPermission = new System.Boolean[ARRAY_PERMISSION_LENGTH] { true, true, true, true, true, true, true, true }; 
            RegistrationUser_PermissionRoleENUM = AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForDataBaseModels.DataTypes.RegistrationUsers_PermissionRolesENUM.ADMINISTRATOR;  
        }
    } 

    public class RegistrationUsers_ImagesAndVideosAlbumsGraph 
    { 
        [System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] 
        public System.UInt32 ID { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(255)] 
        public System.String Appellation { get; set; } 
        
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date), System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Date")]
        public System.DateTime DateTimeCreation { get; set; } 

        public RegistrationUsers RegistrationUser { get; set; } 
        public System.Nullable<System.UInt32> RegistrationUser_ID { get; set; } 
    } 

    public class RegistrationUsers_ImagesAlbums 
    { 
        [System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] 
        public System.UInt32 ID { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(255)] 
        public System.String Appellation { get; set; } 
        
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date), System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Date")]
        public System.DateTime DateTimeCreation { get; set; } 

        public System.Byte []ArrayByteImage { get; set; } 

        public RegistrationUsers_ImagesAndVideosAlbumsGraph ImagesAndVideosAlbumsGraph { get; set; } 
        public System.UInt32 ImagesAndVideosAlbumsGraph_ID { get; set; } 
    } 

    public class RegistrationUsers_VideosAlbums 
    { 
        [System.ComponentModel.DataAnnotations.Key, System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)] 
        public System.UInt32 ID { get; set; } 

        [System.ComponentModel.DataAnnotations.MaxLength(255)] 
        public System.String Appellation { get; set; } 
        
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date), System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "Date")]
        public System.DateTime DateTimeCreation { get; set; } 

        public System.Byte []ArrayByteVideo { get; set; } 

        public RegistrationUsers_ImagesAndVideosAlbumsGraph ImagesAndVideosAlbumsGraph { get; set; } 
        public System.UInt32 ImagesAndVideosAlbumsGraph_ID { get; set; } 
    } 

} 
