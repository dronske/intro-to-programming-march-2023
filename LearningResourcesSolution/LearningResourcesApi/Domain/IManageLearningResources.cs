namespace LearningResourcesApi.Domain;

public interface IManageLearningResources
{
    Task<LearningResourcesSummaryItem> AddResourceAsyncRequest(LearningResourcesCreateRequest request);
    Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token);
    Task<LearningResourcesSummaryItem?> GetResourceByIdAsync(int resourceId);
    Task<bool> MoveItemToWatchedAsync(LearningResourcesSummaryItem request);
    Task RemoveItemAsync(int resourceId);
}
