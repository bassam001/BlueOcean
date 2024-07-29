public class TraderApiClient
{
    private readonly HttpClient _httpClient;
    private const string TraderKey = "YIE3TH72BJ8KPASL5EJUI06CTJVL09I8";

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

}
