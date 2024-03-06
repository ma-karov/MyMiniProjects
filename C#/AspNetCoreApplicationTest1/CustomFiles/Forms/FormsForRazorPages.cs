
namespace AspNetCoreApplicationTest1.CustomFiles.Forms
{ 
    public record class RecordClassTest(System.Byte ID); 

    [AspNetCoreApplicationTest1.CustomFiles.Forms.ValidationsForm.RegistrationUserFormValidation()] 
    public record class RecordClassRegistrationUserForm 
    { 
        [property: System.ComponentModel.DataAnnotations.DataType(dataType: System.ComponentModel.DataAnnotations.DataType.Text), System.ComponentModel.DataAnnotations.Display(Name = "Введите ваше имя: ") ] 
        public System.String Name { get; init; } 
        
        [property: System.ComponentModel.DataAnnotations.DataType(dataType: System.ComponentModel.DataAnnotations.DataType.Text), System.ComponentModel.DataAnnotations.Display(Name = "Введите вашу фамилию: ") ] 
        public System.String Surname { get; init; } 
            
        [property: System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Date) ] 
        [property: System.ComponentModel.DataAnnotations.DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}") ] 
        [property: System.ComponentModel.DataAnnotations.Display(Name = "День рождения: ") ] 
        public System.DateTime BirthDay { get; init; } 

        public System.String MaleStringBool { get; init; } 
            
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)] 
        [System.ComponentModel.DataAnnotations.Display(Name = "Введите ваш E-Mail: ")] 
        public System.String E_MailAddress { get; init; } 

        [property: AspNetCoreApplicationTest1.CustomFiles.Forms.ValidationsAttributesForm.RegistrationUserForm_PasswordValidationAttribute()] 
        [property: System.ComponentModel.DataAnnotations.DataType(dataType: System.ComponentModel.DataAnnotations.DataType.Password) ] 
        [System.ComponentModel.DataAnnotations.Display(Name = "Введите пароль: ")] 
        public System.String Password { get; init; } 

        [property: System.ComponentModel.DataAnnotations.DataType(dataType: System.ComponentModel.DataAnnotations.DataType.Password) ] 
        [System.ComponentModel.DataAnnotations.Display(Name = "Повторите пароль: ")] 
        public System.String RepeatPassword { get; init; } 

        public RecordClassRegistrationUserForm() 
        { 
            Name = Surname = E_MailAddress = Password = RepeatPassword = ""; 
            MaleStringBool = "Male"; 
            System.DateTime SystemDateTimeToday = System.DateTime.Today;
            BirthDay = new System.DateTime(SystemDateTimeToday.Year, SystemDateTimeToday.Month, SystemDateTimeToday.Day); 
        } 
    } 

    public record class RecordClassLoginUserForm
    { 
        [property: System.ComponentModel.DataAnnotations.DataType(dataType: System.ComponentModel.DataAnnotations.DataType.EmailAddress), System.ComponentModel.DataAnnotations.Display(Name = "Введите ваш E-Mail: ") ] public System.String E_MailAddress { get; init; } 
        [property: System.ComponentModel.DataAnnotations.DataType(dataType: System.ComponentModel.DataAnnotations.DataType.Password), System.ComponentModel.DataAnnotations.Display(Name = "Введите пароль: ")] public System.String Password { get; init; } 

        public RecordClassLoginUserForm(System.String E_MailAddress, System.String Password) 
        {
            this.E_MailAddress = E_MailAddress;
            this.Password = Password;
        }

        public RecordClassLoginUserForm() : this("", "") {} 
    } 


    public record struct RecordStructViewBag();

    namespace ValidationsForm 
    { 
        public class RegistrationUserFormValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute 
        { 
            public RegistrationUserFormValidationAttribute() {}

            public override bool IsValid(System.Object SystemObject) 
            { 
                AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassRegistrationUserForm ValidationRegistrationUserForm = SystemObject as AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassRegistrationUserForm;
                if (ValidationRegistrationUserForm == null) 
                    return false; 
                return ( ValidationRegistrationUserForm.Password == ValidationRegistrationUserForm.RepeatPassword ); 
            } 

            protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(System.Object SystemObject, System.ComponentModel.DataAnnotations.ValidationContext Validation_Context) 
            { 
                AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassRegistrationUserForm ValidationRegistrationUserForm = SystemObject as AspNetCoreApplicationTest1.CustomFiles.Forms.RecordClassRegistrationUserForm;
                if (ValidationRegistrationUserForm != null && ValidationRegistrationUserForm.Password != ValidationRegistrationUserForm.RepeatPassword) 
                    return new System.ComponentModel.DataAnnotations.ValidationResult("Пароли не совпадают. "); 
                return System.ComponentModel.DataAnnotations.ValidationResult.Success; 
            } 
        }  
    } 

    namespace ValidationsAttributesForm 
    { 
        public class RegistrationUserForm_PasswordValidationAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute 
        { 
            static System.Boolean NotCorrectEnterPassword(System.String SystemString) 
            { 
                SystemString += "\0"; System.Char SystemChar = SystemString[0]; 
                for (System.UInt16 i = 1; SystemChar != '\0'; SystemChar = SystemString[i++]) 
                    if (!AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.ForProtectDataBase.Cashing.CashFunctionGOST3411.FilterCharInjectionCMD(SystemChar)) 
                        return true; 
                return false; 
            }  

            protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(System.Object SystemObject, System.ComponentModel.DataAnnotations.ValidationContext Validation_Context) 
            { 
                System.String ValidationPassword = SystemObject as System.String; 
                if (ValidationPassword == null) 
                    return new System.ComponentModel.DataAnnotations.ValidationResult("Обязательное поле. "); 
                if (NotCorrectEnterPassword(ValidationPassword)) // !(new System.Text.RegularExpressions.Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")).IsMatch(ValidationPassword) 
                    return new System.ComponentModel.DataAnnotations.ValidationResult("Пароли написаны не по стандарту. Следуйте шаблону. "); 
                return System.ComponentModel.DataAnnotations.ValidationResult.Success; 
            } 
        } 
 
    } 
    
}
