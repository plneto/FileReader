using FileReader.Interfaces;

namespace FileReader.Security
{
    public class RoleBasedSecurity : IFileSecurity
    {
        public bool CanAccessFile(string role)
        {
            return role.ToLower() == "admin";
        }
    }
}