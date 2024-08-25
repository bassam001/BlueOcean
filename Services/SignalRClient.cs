using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

public class SignalRClient
{
    private HubConnection _connection;
    public event Action<string> OnMessageReceived;
    public async Task InitializeAsync()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("https://cstrader.be/hubs/changetrackerhub", options =>
            {
                options.Headers.Add("trader-key", "YIE3TH72BJ8KPASL5EJUI06CTJVL09I8");
            })
            .Build();

        _connection.On<string>("DateTimeChanged", (dateTime) =>
        {
            ShowMessage($"Time updated: {dateTime}");
        });

        _connection.On<string>("BoatsChanged", (message) =>
        {
            ShowMessage($"Boats changed: {message}");
        });

        await _connection.StartAsync();
    }

    private void ShowMessage(string message)
    {

    }
    private void NotifyMessageReceived(string message)
    {
        OnMessageReceived?.Invoke(message);
    }
}
