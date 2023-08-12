namespace DemoAuth.Interfaces
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
    }
}
