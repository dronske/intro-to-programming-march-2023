

using LearningResourcesApi.Domain;

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
   
    private readonly IManageLearningResources _resourceManager;

    public LearningResourcesController(IManageLearningResources resourceManager)
    {
        _resourceManager = resourceManager;
    }

    [HttpPost("/learning-resources")]
    public async Task<ActionResult<LearningResourceSummaryItem>> AddResources(
        [FromBody] LearningResourcesCreateRequest request)
    {
        //Thread.Sleep(3000); // 
        // Validate it.. If it doesn't meet the invariants, return a 400.
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        LearningResourceSummaryItem response = await _resourceManager.AddResourceAsync(request);
        return Ok(response);

    }


    [HttpGet("/learning-resources")]
    public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources(CancellationToken token)
    {

        // Write the Code I wish I had
        LearningResourcesResponse response = await _resourceManager.GetCurrentResourcesAsync(token);
        return Ok(response);
    }
}
