using LearningResourcesApi.Domain;

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;

    public LearningResourcesController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/learning-resources")]
    public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources()
    {
        var data = await _context.LearningResources
            .Where(item => item.WhenRemoved == null)
            .Select(item => new LearningResourcesSummaryItem(item.Id.ToString(), item.Name, item.Description, item.Link))
            .ToListAsync();
        var response = new LearningResourcesResponse(data);
        return Ok(response);
    }

    [HttpPost("/learning-resources")]
    public async Task<ActionResult<LearningResourcesSummaryItem>> AddResource([FromBody] LearningResourcesCreateRequest request)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var entity = new LearningResourcesEntity
        {
            // Mapping - can used AutoMapper library
            Name = request.Name,
            Description = request.Description,
            Link = request.Link,
            WhenCreated = DateTime.Now
        };
        _context.LearningResources.Add(entity);
        await _context.SaveChangesAsync();
        var response = new LearningResourcesSummaryItem(entity.Id.ToString(), entity.Name, entity.Description, entity.Link);
        return Ok(response);
    }
}