namespace CA.Blocks.Application.Common.Interfaces;

public interface ICurrentUser
{
    public string IPAddress { get; }
    public string UserName { get; }
}
