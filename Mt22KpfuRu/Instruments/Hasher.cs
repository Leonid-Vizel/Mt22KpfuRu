using System.Security.Cryptography;
using System.Text;

namespace Mt22KpfuRu.Instruments;

public static class Hasher
{
    public static string ComputeHash(string login, string password)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(login))
        {
            return "";
        }
        StringBuilder rawBuilder = new StringBuilder();
        int counter = 0;
        int iteration = 0;
        while (rawBuilder.Length != login.Length + password.Length)
        {
            if (iteration % 2 == 0)
            {
                if (counter >= password.Length)
                {
                    rawBuilder.Append(login[counter]);
                }
                else
                {
                    rawBuilder.Append(password[counter]);
                }
            }
            else
            {
                if (counter >= login.Length)
                {
                    rawBuilder.Append(password[counter]);
                }
                else
                {
                    rawBuilder.Append(login[counter]);
                }
                counter++;
            }
            iteration++;
        }
        using (SHA384 hash = SHA384.Create())
        {
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(rawBuilder.ToString()));
            StringBuilder finalBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                finalBuilder.Append(bytes[i].ToString("x2"));
            }
            return finalBuilder.ToString();
        }
    }
}
