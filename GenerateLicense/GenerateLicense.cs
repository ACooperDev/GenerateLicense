using System;
using System.Security.Cryptography;
using System.Text;

namespace Genesys
{
    /// <summary>
    /// This class produces a unique and encrypted license for a given PC fingerprint.
    /// Note this application requires the use of:
    ///     System
    ///     System.Security.Cryptography
    ///     System.Text
    /// </summary>
    internal class GenerateLicense
    {
        static void Main(string[] args)
        {
            //Entry point for a PC fingerprint.
            Console.WriteLine("Enter PC fingerprint.");
            string input = Console.ReadLine();

            //Encrypt the PC fingerprint using SHA256 encryption algorithm.
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                //Output instructions and the encrypted license.
                Console.WriteLine("This license is unique to the PC fingerprint provided.");
                Console.WriteLine("Save it as a .txt file and store it in a secure location.");
                Console.WriteLine("License:" + BitConverter.ToString(hashBytes).Replace("-", "").ToLower());
            }

            Console.ReadLine();
        }
    }
}
