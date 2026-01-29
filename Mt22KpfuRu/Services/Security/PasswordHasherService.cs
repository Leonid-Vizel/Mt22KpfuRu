using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Services.Security;

public sealed class PasswordHasherService : IPasswordHasherService
{
    public string Hash(string plainPassword) => Hasher.HashPassword(plainPassword);

    public bool VerifyAndMaybeUpgrade(string storedHash, string login, string plainPassword, out string? upgradedHash)
        => Hasher.TryVerifyAndUpgrade(storedHash, login, plainPassword, out upgradedHash);
}
