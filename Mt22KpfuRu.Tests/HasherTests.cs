using Mt22KpfuRu.Instruments;
using Xunit;

namespace Mt22KpfuRu.Tests;

public class HasherTests
{
    [Fact]
    public void HashPassword_ProducesPbkdf2Format()
    {
        var hash = Hasher.HashPassword("P@ssw0rd!");
        Assert.StartsWith("pbkdf2-sha256$", hash);
        var parts = hash.Split('$');
        Assert.Equal(4, parts.Length);
        Assert.True(int.Parse(parts[1]) >= 10000);
        Assert.False(string.IsNullOrWhiteSpace(parts[2]));
        Assert.False(string.IsNullOrWhiteSpace(parts[3]));
    }

    [Fact]
    public void TryVerifyAndUpgrade_Pbkdf2Hash_VerifiesWithoutUpgrade()
    {
        var hash = Hasher.HashPassword("secret");
        var ok = Hasher.TryVerifyAndUpgrade(hash, login: "admin", password: "secret", out var upgraded);
        Assert.True(ok);
        Assert.Null(upgraded);

        var bad = Hasher.TryVerifyAndUpgrade(hash, login: "admin", password: "wrong", out _);
        Assert.False(bad);
    }

    [Fact]
    public void TryVerifyAndUpgrade_LegacyHash_VerifiesAndReturnsUpgradeHash()
    {
        var login = "admin";
        var password = "secret";
        var legacy = Hasher.ComputeHash(login, password);

        var ok = Hasher.TryVerifyAndUpgrade(legacy, login, password, out var upgraded);
        Assert.True(ok);
        Assert.NotNull(upgraded);
        Assert.StartsWith("pbkdf2-sha256$", upgraded);

        // upgraded hash should verify
        var ok2 = Hasher.TryVerifyAndUpgrade(upgraded!, login, password, out var upgraded2);
        Assert.True(ok2);
        Assert.Null(upgraded2);
    }
}
