namespace FileReader.Interfaces
{
    public interface ITextFileReader
    {
        string ReadTextFile();

        string ReadProtectedTextFile(string role);

        string ReadEncryptedTextFile();
    }
}