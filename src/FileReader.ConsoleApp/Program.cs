using System;
using FileReader.Factory;
using FileReader.Models;

namespace FileReader.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome to File Reader!");

            while (true)
            {
                var fileType = GetFileType();
                var useEncryption = GetEncryptionInput();

                var useAuthorization = false;
                if (!useEncryption)
                {
                    useAuthorization = GetAuthorizationInput();
                }

                var role = string.Empty;
                if (useAuthorization)
                {
                    role = GetRoleInput();
                }

                var fileReader = FileReaderFactory.FromFileType(fileType);

                Console.WriteLine("\n---------------------------------------------------------------------");

                if (useEncryption)
                {
                    Console.WriteLine(fileReader.ReadEncryptedFile());
                }
                else if (useAuthorization)
                {
                    Console.WriteLine(fileReader.ReadProtectedFile(role));
                }
                else
                {
                    Console.WriteLine(fileReader.ReadFile());
                }

                Console.WriteLine("---------------------------------------------------------------------\n");
            }
        }

        private static FileTypes GetFileType()
        {
            Console.WriteLine("\nPlease selected a file type (Text, Xml, Json):");
            var fileTypeInput = Console.ReadLine();

            if (!Enum.TryParse(fileTypeInput, true, out FileTypes fileType))
            {
                Console.WriteLine("\nInvalid file type. Please try again.\n");

                return GetFileType();
            }

            return fileType;
        }

        private static bool GetEncryptionInput()
        {
            Console.WriteLine("\nUse encryption? (True/False):");
            var useEncryptionInput = Console.ReadLine();

            if (!bool.TryParse(useEncryptionInput, out var useEncryption))
            {
                Console.WriteLine("\nInvalid input. Please try again.\n");

                return GetEncryptionInput();
            }

            return useEncryption;
        }

        public static bool GetAuthorizationInput()
        {
            Console.WriteLine("\nUse authorization? (True/False):");
            var useAuthorizationInput = Console.ReadLine();

            if (!bool.TryParse(useAuthorizationInput, out var useAuthorization))
            {
                Console.WriteLine("\nInvalid input. Please try again.\n");

                return GetAuthorizationInput();
            }

            return useAuthorization;
        }

        public static string GetRoleInput()
        {
            Console.WriteLine("\nPlease enter your role:");
            var roleInput = Console.ReadLine();

            return roleInput;
        }
    }
}