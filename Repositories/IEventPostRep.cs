using LinBeach.Models.Domain;

namespace LinBeach.Repositories
{
    public interface IEventPostRep
    {
        Task<IEnumerable<EventPost>> GetAllAsync();
        Task<EventPost> GetAsync(Guid id);
        Task<EventPost> GetAsync(string urlHandle);
        Task<EventPost> AddAsync(EventPost post);
        Task<EventPost> UpdateAsync(EventPost post);
        Task<bool> DeleteAsync(Guid id); 
    }
}
