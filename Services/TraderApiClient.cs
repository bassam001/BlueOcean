

using Microsoft.AspNetCore.SignalR.Client;

public class TraderApiClient
{
    private readonly HttpClient _httpClient;
    private HubConnection _hubConnection;

    //to do later
    //should be  Environment.GetEnvironmentVariable("TRADER_API_KEY");
    //hardcoding
    private const string TraderKey = "YIE3TH72BJ8KPASL5EJUI06CTJVL09I8";

    private const int _maxRetrykeren= 3;
    private const int _delayinMilliseconden = 2000;

    public TraderApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CompanyData> GetCompanyAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "company");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<CompanyData>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching company data: {response.ReasonPhrase}");
        }
    }

    public async Task<List<GameBoat>> GetAvailableBoatsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "boat/all");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<GameBoat>>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching boats data: {response.ReasonPhrase}");
        }
    }

    public async Task<List<GameBoatWithCargo>> GetBoatAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "boat");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<GameBoatWithCargo>>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching boats with cargo data: {response.ReasonPhrase}");
        }
    }

    public async Task<GameBoatWithCargo> GetBoatAsync(Guid boatId)
    {
        var boats = await GetBoatAsync();

       return boats.FirstOrDefault(b => b.Id == boatId);

    }



    public async Task<double> FuelBoatAsync(string boatId, int amount)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"boat/fuel/{boatId}/{amount}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<double>();
        }
        else
        {
            throw new HttpRequestException($"Error fueling boat: {response.ReasonPhrase}");
        }
    }



    public async Task<int> RepairBoatAsync(string boatId, int amount)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"boat/repair/{boatId}/{amount}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<int>();
        }
        else
        {
            throw new HttpRequestException($"Error repairing boat: {response.ReasonPhrase}");
        }
    }

    public async Task<List<CompanyData>> GetAllCompaniesAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "company/all");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<CompanyData>>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching all companies: {response.ReasonPhrase}");
        }
    }

    public async Task<List<GameContract>> GetPlayerContractsAsync(bool includeDone)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"contract/me/{includeDone}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<GameContract>>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching player contracts: {response.ReasonPhrase}");
        }
    }

    public async Task<List<GameAvailableContract>> GetAvailableContractsAsync(int? skip = null, int? take = null)
    {
        var query = $"contract/available?skip={skip}&take={take}";
        var request = new HttpRequestMessage(HttpMethod.Get, query);
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<GameAvailableContract>>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching available contracts: {response.ReasonPhrase}");
        }
    }

    public async Task<bool> TakeContractAsync(string contractId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"contract/take/{contractId}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        else
        {
            throw new HttpRequestException($"Error taking contract: {response.ReasonPhrase}");
        }
    }

    public async Task<int> CancelContractAsync(string contractId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"contract/cancel/{contractId}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<int>();
        }
        else
        {
            throw new HttpRequestException($"Error canceling contract: {response.ReasonPhrase}");
        }
    }

    public async Task<GameData> GetGameDataAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "game");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<GameData>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching game data: {response.ReasonPhrase}");
        }
    }

    public async Task<string> GetCurrentGameDateAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "game/date");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new HttpRequestException($"Error fetching current game date: {response.ReasonPhrase}");
        }
    }

    public async Task<bool> StopGameAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "game/stop");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            throw new HttpRequestException($"Error stopping the game: {response.ReasonPhrase}");
        }
    }

    public async Task<List<GameBoatForSale>> GetMarketBoatsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "market");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<GameBoatForSale>>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching market boats: {response.ReasonPhrase}");
        }
    }

    public async Task<int> BuyBoatAsync(string boatId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"market/buy/{boatId}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<int>();
        }
        else
        {
            throw new HttpRequestException($"Error buying boat: {response.ReasonPhrase}");
        }
    }

    public async Task<bool> SellBoatAsync(string boatId, int amount)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"market/sell/{boatId}/{amount}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        else
        {
            throw new HttpRequestException($"Error selling boat: {response.ReasonPhrase}");
        }
    }

    public async Task<List<GamePlayer>> GetAllPlayersAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "player");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<GamePlayer>>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching all players: {response.ReasonPhrase}");
        }
    }

    public async Task<bool> MoveBoatAsync(string boatId, int moveToNode)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"boat/moveto/{boatId}/{moveToNode}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            throw new HttpRequestException($"Error moving boat: {response.ReasonPhrase}");
        }
    }

    public async Task<List<GameLocation>> GetAllLocationsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "location");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<GameLocation>>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching locations: {response.ReasonPhrase}");
        }
    }

    public async Task<bool> LoadCargoAsync(string boatId, string contractId, int amount)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"boat/load/{boatId}/{contractId}/{amount}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        else
        {
            throw new HttpRequestException($"Error loading cargo: {response.ReasonPhrase}");
        }
    }

    public async Task<bool> UnloadCargoAsync(string boatId, string contractId, int amount)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"boat/unload/{boatId}/{contractId}/{amount}");
        request.Headers.Add("trader-key", TraderKey);
        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        else
        {
            throw new HttpRequestException($"Error unloading cargo: {response.ReasonPhrase}");
        }
    }


    public async Task ShowErrorMessage(string message)
    {
        throw new HttpRequestException($"Error: {message}");
    }

    public async Task<int> GetDistanceAsync(int fromNodeId, int toNodeId)
    {
        //traag, moet herbekeken
        var request = new HttpRequestMessage(HttpMethod.Get, $"location/distance/{fromNodeId}/{toNodeId}");
        request.Headers.Add("trader-key", TraderKey);

        var response = await _httpClient.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<int>();
        }
        else
        {
            throw new HttpRequestException($"Error fetching distance: {response.ReasonPhrase}");
        }
    }
    public async Task InitializeSignalRAsync()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://cstrader.be/hubs/changetrackerhub", options =>
            {
                options.Headers.Add("trader-key", TraderKey);
            })
            .Build();

        _hubConnection.On<GameBoatWithCargo>("BoatsChanged", OnBoatsChanged);

        await _hubConnection.StartAsync();
    }


    public void OnBoatsChanged(GameBoatWithCargo updatedBoat)
    {
        Console.WriteLine($"Boat updated: {updatedBoat.Id}");
    }

    public async Task DisposeSignalRAsync()
    {
        if (_hubConnection != null)
        {
            await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();
        }
    }

 

}
