using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace RealTimeUnit
{
    class Program
    {
        private CspParameters csp;
        private static RSACryptoServiceProvider rsa;
        const string EXPORT_FOLDER = @"C:\public_key\";
        static void Main(string[] args)
        {
            ServiceReference.RealTimeUnitClient client = new ServiceReference.RealTimeUnitClient();
            Program pr = new Program();
            pr.CreateAsmKeys();
            bool badAddress;
            int id = 0;
            do
            {
                badAddress = false;
                Console.WriteLine("Insert address on which you want to publish: ");
                string address = Console.ReadLine();
                id = client.RealTimeUnitInit(address);
                if (id == -1)
                {
                    Console.WriteLine("Address is already taken. Please try again.");
                    badAddress = true;
                }

            } while (badAddress);

            string fileName = ExportPublicKey(id);
            client.SetPublicKey(fileName);
            double lowLimit = 0;
            double highLimit = 0;
            bool badRange;
            do
            {
                badRange = false;
                Console.WriteLine("Insert low limit: ");
                lowLimit = Double.Parse(Console.ReadLine());
                Console.WriteLine("Insert high limit: ");
                highLimit = Double.Parse(Console.ReadLine());

                if (lowLimit >= highLimit)
                {
                    badRange = true;
                    Console.WriteLine("Bad range!");
                }
            } while (badRange);

            double writeTime = 0;
            bool badInput;
            do
            {
                badInput = false;
                Console.WriteLine("Insert writeTime: ");
                try
                {
                    writeTime = Double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad input");
                    badInput = true;
                }
                if (writeTime <= 0)
                {
                    Console.WriteLine("time must be > 0!");
                    badInput = true;
                }
            } while (badInput);

            Random rand = new Random();
            while (true)
            {
                double value = rand.Next((int)lowLimit, (int)highLimit);
                string message = "message=" + value;
                Console.WriteLine(message+" by "+id);
                client.SetValue(message, SignMessage(message));
                Thread.Sleep((int)(writeTime*1000));
            }

        }

        private static byte[] SignMessage(string message)
        {
            using (SHA256 sha = SHA256Managed.Create())
            {
                var hashValue = sha.ComputeHash(Encoding.UTF8.GetBytes(message));
                var formatter = new RSAPKCS1SignatureFormatter(rsa);
                formatter.SetHashAlgorithm("SHA256");
                return formatter.CreateSignature(hashValue);
            }
        }

        public void CreateAsmKeys()
        {
            csp = new CspParameters();
            rsa = new RSACryptoServiceProvider(csp);
        }

        private static string ExportPublicKey(int id)
        {
            string PUBLIC_KEY_FILE = @"" + id + ".txt";
            //Kreiranje foldera za eksport ukoliko on ne postoji
            if (!(Directory.Exists(EXPORT_FOLDER)))
                Directory.CreateDirectory(EXPORT_FOLDER);
            string path = Path.Combine(EXPORT_FOLDER, PUBLIC_KEY_FILE);
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(rsa.ToXmlString(false));
            }
            return path;
        }
    }
}
