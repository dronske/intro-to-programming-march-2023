namespace LearningResourcesApi.Domain;

public class EntityFrameworkResourceManager : IManageLearningResources
{
    private readonly LearningResourcesDataContext _context;

    public EntityFrameworkResourceManager(LearningResourcesDataContext context)
    {
        _context = context;
    }

    public async Task<LearningResourceSummaryItem> AddResourceAsync(LearningResourcesCreateRequest request)
    {
      
       var entity = new LearningResourcesEntity
       {
           // "Mapping" - AutoMapper
           Name = request.Name,
           Description = request.Description,
           Link = request.Link,
           WhenCreated = DateTime.Now
       };
        //   - tell our DataContext about it.
        _context.LearningResources.Add(entity);
        //   - tell the DataContext to save the data.
        await _context.SaveChangesAsync(); // Order Up!
        // Return a Success Status Code*
        //   - With a copy of the brand new entity
        var response = new LearningResourceSummaryItem(entity.Id.ToString(), entity.Name, entity.Description, entity.Link);
        return response;
    }

    public async Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token)
    {
        await Task.Delay(3000, token);
        var data = await _context.LearningResources
            .Where(item => item.WhenRemoved == null)
            .Select(item => new LearningResourceSummaryItem(
                item.Id.ToString(), item.Name, item.Description, item.Link))
            .ToListAsync(token);

        var response = new LearningResourcesResponse(data);
        return response;
    }
}
