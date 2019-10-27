namespace FileReader.Interfaces
{
    public interface IFileEncryption
    {
        string DecryptFileContents(string encryptedContents);
    }
}