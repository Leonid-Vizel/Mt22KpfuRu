namespace Mt22KpfuRu.Services.Security;

public sealed class SystemClock : IClock
{
    public DateTime Now => DateTime.Now;
}
