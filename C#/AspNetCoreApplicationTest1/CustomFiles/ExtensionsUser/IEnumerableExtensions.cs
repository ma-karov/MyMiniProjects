
namespace AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.CollectionsIEnumerable
{
    public class IEnumerableExtensions {} 

    public static class SystemArrayExtensions 
    { 
        public static TemplateDataType []ExtensionsUser_AddElement<TemplateDataType>(this TemplateDataType []SystemArray, TemplateDataType NewElement, System.UInt32 IndexPosition) 
        { 
            System.UInt32 SystemArrayLength = System.UInt32.Parse(SystemArray.Length + ""); 
            TemplateDataType []NewSystemArray = new TemplateDataType[SystemArrayLength + 1]; 

            for (System.UInt32 i = 0; i < IndexPosition; i++) 
                NewSystemArray[i] = SystemArray[i]; 
            for (System.UInt32 i = IndexPosition; i < SystemArrayLength; i++) 
                NewSystemArray[i + 1] = SystemArray[i]; 
            NewSystemArray[IndexPosition] = NewElement; 
            return NewSystemArray; 
        } 

        public static TemplateDataType []ExtensionsUser_AddElementFirst<TemplateDataType>(this TemplateDataType []SystemArray, TemplateDataType NewElement) => SystemArray.ExtensionsUser_AddElement<TemplateDataType>(NewElement, 0); 
        public static TemplateDataType []ExtensionsUser_AddElementLast<TemplateDataType>(this TemplateDataType []SystemArray, TemplateDataType NewElement) => SystemArray.ExtensionsUser_AddElement<TemplateDataType>(NewElement, System.UInt32.Parse(SystemArray.Length + "")); 
    }
}
