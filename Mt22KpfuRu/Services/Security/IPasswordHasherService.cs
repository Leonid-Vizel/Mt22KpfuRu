namespace Mt22KpfuRu.Services.Security;

public interface IPasswordHasherService
{
    string Hash(string plainPassword);
    bool VerifyAndMaybeUpgrade(string storedHash, string login, string plainPassword, out string? upgradedHash);
}
