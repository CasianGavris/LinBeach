using LinBeach.Data;
using LinBeach.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinBeach.Repositories
{
    public class EventPostRep : IEventPostRep
    {
        private readonly LinBeachDbContext linBeachDbContext;

        public EventPostRep(LinBeachDbContext linBeachDbContext)
        {
            this.linBeachDbContext = linBeachDbContext;
        }
        public async Task<EventPost> AddAsync(EventPost post)
        {
            await linBeachDbContext.EventPosts.AddAsync(post);
            await linBeachDbContext.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var currentEventPost = await linBeachDbContext.EventPosts.FindAsync(id);
            if (currentEventPost != null)
            {
                linBeachDbContext.EventPosts.Remove(currentEventPost);
                await linBeachDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<EventPost>> GetAllAsync()
        {
            return await linBeachDbContext.EventPosts.ToListAsync();
            
        }

        public async Task<EventPost> GetAsync(Guid id)
        {
            return await linBeachDbContext.EventPosts.FindAsync(id);
        }

        public async Task<EventPost> GetAsync(string urlHandle)
        {
            return await linBeachDbContext.EventPosts.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<EventPost> UpdateAsync(EventPost post)
        {
            var currentEventPost = await linBeachDbContext.EventPosts.FindAsync(post.Id);
            if (currentEventPost != null)
            {
                currentEventPost.Title = post.Title;
                currentEventPost.EventDate = post.EventDate;
                currentEventPost.Content = post.Content;
                
                currentEventPost.ImageUrl = post.ImageUrl;
                currentEventPost.UrlHandle = post.UrlHandle;

            }
            await linBeachDbContext.SaveChangesAsync();
            return currentEventPost;
        }
    }
}
