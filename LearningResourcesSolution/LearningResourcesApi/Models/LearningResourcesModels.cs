using System.ComponentModel.DataAnnotations;

namespace LearningResourcesApi.Models;

public record LearningResourcesSummaryItem(
    string Id, string Name, string Description, string Link);

public record LearningResourcesResponse(List<LearningResourcesSummaryItem> Data);

public record LearningResourcesCreateRequest: IValidatableObject
{
    [Required, MaxLength(100)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(200)]
    public string Description { get; init; } = string.Empty;

    [Required]
    public string Link { get; init; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        if(Name.ToLowerInvariant().Contains("darth"))
        {
            yield return new ValidationResult("sorry no star wars");
        }
        if(Link.ToLowerInvariant().Contains("facebook"))
        {
            yield return new ValidationResult("no face book");
        }
    }
}

