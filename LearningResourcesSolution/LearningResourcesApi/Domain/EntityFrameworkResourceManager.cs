using System.Reflection.Metadata.Ecma335;

namespace LearningResourcesApi.Domain
{
    public class EntityFrameworkResourceManager : IManageLearningResources
    {
        private readonly LearningResourcesDataContext _context;
        public EntityFrameworkResourceManager(LearningResourcesDataContext context)
        {
            _context = context;
        }
        public async Task<LearningResourcesSummaryItem> AddResourceAsyncRequest(LearningResourcesCreateRequest request)
        {
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
            var response = MapFromDomain(entity);
            return response;
        }

        public async Task<LearningResourcesResponse> GetCurrentResourcesAsync(CancellationToken token)
        {
            var data = await _context.GetActiveLearningResources()
                .Select(item => MapFromDomain(item))
                .ToListAsync(token);
            var response = new LearningResourcesResponse(data);
            return response;
        }

        public async Task<LearningResourcesSummaryItem?> GetResourceByIdAsync(int resourceId)
        {
            var item = await _context.GetActiveLearningResources()
                .Where(item => item.Id == resourceId)
                .Select(item => MapFromDomain(item))
                .SingleOrDefaultAsync();
            return item;
        }

        public async Task RemoveItemAsync(int resourceId)
        {
            var item = await _context.GetActiveLearningResources()
                .SingleOrDefaultAsync(item => item.Id == resourceId);
            if(item != null)
            {
                item.WhenRemoved = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        private static LearningResourcesSummaryItem MapFromDomain(LearningResourcesEntity item)
        {
            return new LearningResourcesSummaryItem(item.Id.ToString(), item.Name, item.Description, item.Link, item.HasBeenWatched);
        }

        public async Task<bool> MoveItemToWatchedAsync(LearningResourcesSummaryItem request)
        {
            var id = int.Parse(request.Id);
            var item = await _context.GetActiveLearningResources()
                .SingleOrDefaultAsync(item => item.Id == id);
            if(item != null)
            {
                item.HasBeenWatched = true;
                await _context.SaveChangesAsync();
                return true;
            } else
            {
                return false;
            }
        }
    }
}