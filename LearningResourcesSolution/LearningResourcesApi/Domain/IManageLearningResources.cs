namespace LearningResourcesApi.Domain;

public interface IManageLearningResources
{
    Task<LearningResourcesSummaryItem> AddResourceAsyncRequest(LearningResourcesCreateRequest request);
    Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token);
    Task RemoveItemAsync(int resourceId);
}
