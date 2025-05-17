using System.Security.Cryptography;
using System.Text;

namespace Core.Security.Hashing;

public class HashingHelper
{
    public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
    {
        using(var hmac = new HMACSHA512())
        {
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Şifre + salt kullanarak hash üretir
            passwordSalt = hmac.Key; //Rastgele salt üretir
        }
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != passwordHash[i])
                    return false;
            }
        }
        return true;
    }
}
