using System.Collections.Generic;
using FileReader.Constants;
using FileReader.Models;

namespace FileReader.Files
{
    internal static class AvailableFiles
    {
        internal static IEnumerable<File> Files()
        {
            yield return new File(
                FilePaths.TextFilePath,
                FileTypes.Text,
                false,
                false);

            yield return new File(
                FilePaths.EncryptedTextFilePath,
                FileTypes.Text,
                false,
                true);

            yield return new File(
                FilePaths.ProtectedTextFilePath,
                FileTypes.Text,
                true,
                false);

            yield return new File(
                FilePaths.XmlFilePath,
                FileTypes.Xml,
                false,
                false);

            yield return new File(
                FilePaths.EncryptedXmlFilePath,
                FileTypes.Xml,
                false,
                true);

            yield return new File(
                FilePaths.ProtectedXmlFilePath,
                FileTypes.Xml,
                true,
                false);

            yield return new File(
                FilePaths.JsonFilePath,
                FileTypes.Json,
                false,
                false);

            yield return new File(
                FilePaths.EncryptedJsonFilePath,
                FileTypes.Json,
                false,
                true);
        }
    }
}