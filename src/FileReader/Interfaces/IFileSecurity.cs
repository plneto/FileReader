namespace FileReader.Interfaces
{
    public interface IFileSecurity
    {
        bool CanAccessFile(string role);
    }
}