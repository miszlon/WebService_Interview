using AwesomeBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeBlog.Infrastructure
{
    public class BlogRepository
    {

        //private readonly DatabaseContext _databaseContext;

        //public BlogRepository(DatabaseContext databaseContext)
        //{
        //    _databaseContext = databaseContext;
        //}

        //public async Task<ICollection<Blog>> GetBlogs() => await _databaseContext.GetCollection<Blog>().AsQueryable().ToListAsync();
        //public async Task<Blog> GetBlog(Guid id) => await _databaseContext.GetCollection<Blog>().AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        //public async Task Create(Blog blog)
        //{
        //    await _databaseContext.GetCollection<Blog>().InsertOneAsync(blog);
        //}
        //public async Task<bool> Delete(Guid id)
        //{
        //    var result = await _databaseContext.GetCollection<Blog>().DeleteOneAsync(x => x.Id == id);
        //    return result.DeletedCount > 0;
        //}
        //public async Task<bool> Update(Blog blog)
        //{
        //    var blogEntity = await GetBlog(blog.Id);

        //    if (blogEntity == null)
        //        return false;

        //    blogEntity.Author = blog.Author;
        //    blogEntity.Name = blog.Name;
        //    blogEntity.CreatedOn = blog.CreatedOn;
        //    await _databaseContext.GetCollection<Blog>().ReplaceOneAsync(x => x.Id == blog.Id, blog);

        //    return true;
        //}
        //public async Task<bool> AddPost(Guid id, Post post)
        //{
        //    var entity = await GetBlog(id);

        //    if (entity == null)
        //        return false;

        //    entity.AddPost(post);

        //    await _databaseContext.GetCollection<Blog>().ReplaceOneAsync(x => x.Id == id, entity);

        //    return true;
        //}
    }
}
