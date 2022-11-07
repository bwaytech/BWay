using BWay.Infra.Interfaces;
using System.Security.Cryptography;

namespace BWay.Infra.Utils
{
    public class Util : IUtil
    {
        public Guid CriarNovoId()
        {
            return Guid.NewGuid();
        }

        public List<T> Embaralhar<T>(List<T> roleta)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = roleta.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = roleta[k];
                roleta[k] = roleta[n];
                roleta[n] = value;
            }

            return roleta;
        }
    }
}
