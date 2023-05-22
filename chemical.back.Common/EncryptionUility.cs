namespace Hls.Hotel.Transversal.Common
{
    public class EncryptUility
    {

        public static string Encrypt(string cadena)
        {
            return BCrypt.Net.BCrypt.HashPassword(cadena);
        }

        public static bool Verify(string cadena, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(cadena, hash);
        }
    }
}
