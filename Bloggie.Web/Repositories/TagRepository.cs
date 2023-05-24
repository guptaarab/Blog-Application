using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public TagRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await bloggieDbContext.Tags.AddAsync(tag);
            await bloggieDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await bloggieDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                bloggieDbContext.Tags.Remove(existingTag);
                await bloggieDbContext.SaveChangesAsync();
                return existingTag;
            }

            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await bloggieDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            var tag = bloggieDbContext.Tags.FirstOrDefault(x => x.Id == id);
            return Task.FromResult<Tag?>(tag);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingtag = await bloggieDbContext.Tags.FindAsync(tag.Id);

            if(existingtag != null)
            {
                existingtag.Name = tag.Name;
                existingtag.DisplayName = tag.DisplayName;

                await bloggieDbContext.SaveChangesAsync();

                return existingtag;
            }

            return null;
        }
    }
}
