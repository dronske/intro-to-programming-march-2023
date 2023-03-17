namespace LearningResourcesApi.Adapters;

// Create one of these classes for EACH of the external APIs that are called
// Each "server" that is called into
public class OnCallDeveloperLookupApiAdapter
{
    private readonly HttpClient _httpClient;

    public OnCallDeveloperLookupApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OnCallApiModel> GetOnCallDeveloperAsync()
    {
        var responseMessage = await _httpClient.GetAsync("/oncalldeveloper");
        responseMessage.EnsureSuccessStatusCode();

        var message = await responseMessage.Content.ReadFromJsonAsync<OnCallApiModel>();

        if (message != null)
        {
            return message;
        } else
        {
            throw new Exception("Didn't get any database");
        }
    }
}
