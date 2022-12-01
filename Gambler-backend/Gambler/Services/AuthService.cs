namespace Gambler.PoC.Services
{
    public interface IAuthService
    {
        bool Verify(Guid registerKey);
    }
    public class AuthService : IAuthService
    {
        protected string secretKey = "d37i6e8:0h67907e:h0<eh60e39dei4<58f8";

        public bool Verify(Guid registerKey)
        {
            return Encrypt(registerKey).Equals(secretKey);
        }

        private string Encrypt(Guid registerKey) 
        {
            // Most secure encryption algorithm
            string val = registerKey.ToString();
            string encrypted = string.Empty;
            for (int iChar = 0; iChar < val.Length; iChar++)
            {
                encrypted += (char)(val[iChar] + 3);
            }

            return encrypted;
        }

    }
}
