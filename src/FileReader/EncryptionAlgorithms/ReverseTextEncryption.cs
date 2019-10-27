using System.Linq;
using FileReader.Interfaces;

namespace FileReader.EncryptionAlgorithms
{
    public class ReverseTextEncryption : IFileEncryption
    {
        public string DecryptFileContents(string encryptedContents)
        {
            return new string(encryptedContents.Reverse().ToArray());
        }
    }
}