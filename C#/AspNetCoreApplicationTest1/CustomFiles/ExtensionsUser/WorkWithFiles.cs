
namespace AspNetCoreApplicationTest1.CustomFiles.ExtensionsUser.WorkWithFiles
{ 
    public class FileJson 
    { 
        readonly private string SystemStringFilePath; private string SystemStringStringifyObject = "";

        public FileJson(in string SystemStringFilePath) { this.SystemStringFilePath = SystemStringFilePath + ".json"; }

        public void WriteStringifyObject(in string SystemStringNameConst, in string SystemStringStringifyObject) => this.SystemStringStringifyObject += "const " + SystemStringNameConst + " = " + SystemStringStringifyObject + "; \n";

        public void CreateConstArray(in string SystemStringNameConstArray) => SystemStringStringifyObject += "const " + SystemStringNameConstArray + " = [ \n";
        public void AppendInConstArray(in string SystemStringStringifyObject) => this.SystemStringStringifyObject += SystemStringStringifyObject + ", \n";
        public void CloseConstArray() => SystemStringStringifyObject += "]; \n";

        public bool Save()
        {
            FileStream SystemIOFileStream = new FileStream(SystemStringFilePath, FileMode.Create); if (SystemIOFileStream == null) return false;
            StreamWriter SystemIOStreamWriter = new StreamWriter(SystemIOFileStream);
            SystemIOStreamWriter.WriteLine(SystemStringStringifyObject); SystemIOStreamWriter.Close(); SystemIOFileStream.Close(); return true;
        }

    }
}
