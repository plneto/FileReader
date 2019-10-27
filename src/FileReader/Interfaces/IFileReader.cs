namespace FileReader.Interfaces
{
    public interface IFileReader
    {
        string ReadFile();

        string ReadProtectedFile(string role);

        string ReadEncryptedFile();
    }
}