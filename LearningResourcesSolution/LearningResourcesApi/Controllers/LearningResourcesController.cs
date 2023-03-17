using LearningResourcesApi.Domain;

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
    private readonly IManageLearningResources _resourceManager;

    public LearningResourcesController(IManageLearningResources resourceManager)
    {
        _resourceManager = resourceManager;
    }

    [HttpPost("/watched-learning-resources")]
    public async Task<ActionResult> MoveToWatched([FromBody] LearningResourcesSummaryItem request)
    {
        bool exists = await _resourceManager.MoveItemToWatchedAsync(request);
        if (!exists)
        {
            return BadRequest();
        } else {
            return NoContent();
        }
    }

        [HttpGet("/learning-resources")]
        public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources(CancellationToken token)
        {
            //var data = await _context.LearningResources
            //    .Where(item => item.WhenRemoved == null)
            //    .Select(item => new LearningResourcesSummaryItem(item.Id.ToString(), item.Name, item.Description, item.Link))
            //    .ToListAsync(token);
            //var response = new LearningResourcesResponse(data);
            LearningResourcesResponse response = await _resourceManager.GetCurrentResourcesAsync(token);
            return Ok(response);
        }

    [HttpGet("/learning-resources/{resourceId:int}")]
        public async Task<ActionResult<LearningResourcesSummaryItem>> GetById(int resourceId)
        {
            LearningResourcesSummaryItem? response = await _resourceManager.GetResourceByIdAsync(resourceId);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("/learning-resources")]
        public async Task<ActionResult<LearningResourcesSummaryItem>> AddResource([FromBody] LearningResourcesCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var entity = new LearningResourcesEntity
            //{
            //    // Mapping - can used AutoMapper library
            //    Name = request.Name,
            //    Description = request.Description,
            //    Link = request.Link,
            //    WhenCreated = DateTime.Now
            //};
            //_context.LearningResources.Add(entity);
            //await _context.SaveChangesAsync();
            //var response = new LearningResourcesSummaryItem(entity.Id.ToString(), entity.Name, entity.Description, entity.Link);
            LearningResourcesSummaryItem response = await _resourceManager.AddResourceAsyncRequest(request);
            return Ok(response);
        }

        [HttpDelete("/learning-resources/{resourceId:int}")]
        public async Task<ActionResult> Remove(int resourceId)
        {
            await _resourceManager.RemoveItemAsync(resourceId);
            return NoContent();
        }
    }