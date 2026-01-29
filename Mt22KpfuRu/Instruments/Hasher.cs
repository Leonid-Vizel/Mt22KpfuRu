using System.Security.Cryptography;
using System.Text;

namespace Mt22KpfuRu.Instruments;

public static class Hasher
{
    private const string Pbkdf2Prefix = "pbkdf2-sha256";
    private const int DefaultIterations = 600_000;
    private const int SaltSize = 16;
    private const int SubkeySize = 32; // 256-bit

    /// <summary>
    /// Legacy hash used by the original project (SHA384 of an interleaving of login+password).
    /// Kept for backward compatibility so existing Admins.XML can be verified and upgraded.
    /// </summary>
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

    /// <summary>
    /// Secure password hashing (PBKDF2-HMACSHA256) storage format:
    /// pbkdf2-sha256$&lt;iterations&gt;$&lt;saltB64&gt;$&lt;subkeyB64&gt;
    /// </summary>
    public static string HashPassword(string password, int iterations = DefaultIterations)
    {
        if (string.IsNullOrEmpty(password)) return "";

        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] subkey = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations,
            HashAlgorithmName.SHA256,
            SubkeySize);

        return $"{Pbkdf2Prefix}${iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(subkey)}";
    }

    /// <summary>
    /// Verifies a stored password hash.
    /// - If stored hash is PBKDF2, verifies it.
    /// - If stored hash is legacy, verifies legacy and returns an upgraded PBKDF2 hash to persist.
    /// </summary>
    public static bool TryVerifyAndUpgrade(string storedHash, string login, string password, out string? upgradedHash)
    {
        upgradedHash = null;

        if (string.IsNullOrEmpty(storedHash) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(login))
            return false;

        if (storedHash.StartsWith(Pbkdf2Prefix + "$", StringComparison.Ordinal))
        {
            return VerifyPbkdf2(storedHash, password);
        }

        // Legacy verification
        string legacy = ComputeHash(login, password);
        bool ok = CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(storedHash),
            Encoding.UTF8.GetBytes(legacy));

        if (ok)
        {
            upgradedHash = HashPassword(password);
        }
        return ok;
    }

    private static bool VerifyPbkdf2(string storedHash, string password)
    {
        // pbkdf2-sha256$iterations$salt$subkey
        string[] parts = storedHash.Split('$');
        if (parts.Length != 4) return false;
        if (!string.Equals(parts[0], Pbkdf2Prefix, StringComparison.Ordinal)) return false;
        if (!int.TryParse(parts[1], out int iterations) || iterations < 10_000) return false;

        byte[] salt, expected;
        try
        {
            salt = Convert.FromBase64String(parts[2]);
            expected = Convert.FromBase64String(parts[3]);
        }
        catch
        {
            return false;
        }

        byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations,
            HashAlgorithmName.SHA256,
            expected.Length);

        return CryptographicOperations.FixedTimeEquals(actual, expected);
    }
}
