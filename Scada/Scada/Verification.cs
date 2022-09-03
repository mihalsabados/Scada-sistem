using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Scada
{
    internal class Verification
    {
        private CspParameters csp;
        private RSACryptoServiceProvider rsa;

        public void ImportPublicKey(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    csp = new CspParameters();
                    rsa = new RSACryptoServiceProvider(csp);
                    string text = reader.ReadToEnd();
                    rsa.FromXmlString(text);
                }
            }
        }

        public bool VerifyMessage(string message, byte[] signature)
        {
            using (SHA256 sha = SHA256Managed.Create())
            {
                var hashValue = sha.ComputeHash(Encoding.UTF8.GetBytes(message));
                var deformatter = new RSAPKCS1SignatureDeformatter(rsa);
                deformatter.SetHashAlgorithm("SHA256");

                return deformatter.VerifySignature(hashValue, signature);
            }
        }
    }
}