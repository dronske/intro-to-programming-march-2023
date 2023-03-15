namespace LearningResourcesApi.Models;

public record LearningResourcesSummaryItem(
    string Id, string Name, string Description, string Link);

public record LearningResourcesResponse(List<LearningResourcesSummaryItem> Data);

