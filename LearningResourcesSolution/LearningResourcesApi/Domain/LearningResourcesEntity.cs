namespace LearningResourcesApi.Domain;

public class LearningResourcesEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public DateTime WhenCreated { get; set; }
    public DateTime? WhenRemoved { get; set; }
}
