
public class TraderApiClient
{
    private readonly HttpClient _httpClient;

    public TraderApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CompanyData> GetCompanyAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "company");
        request.Headers.Add("trader-key", "YIE3TH72BJ8KPASL5EJUI06CTJVL09I8");
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
        request.Headers.Add("trader-key", "YIE3TH72BJ8KPASL5EJUI06CTJVL09I8");
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
}