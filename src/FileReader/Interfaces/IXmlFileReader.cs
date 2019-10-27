namespace FileReader.Interfaces
{
    public interface IXmlFileReader
    {
        string ReadXmlFile();

        string ReadProtectedXmlFile(string role);

        string ReadEncryptedXmlFile();
    }
}