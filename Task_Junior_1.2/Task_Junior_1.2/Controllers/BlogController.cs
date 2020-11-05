using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Junior_1._2.Models;

namespace Task_Junior_1._2.Controllers
{
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly Task_JuniorContext _context;

        public BlogController(Task_JuniorContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Authorize(Roles ="Admin,User")]
        public async Task<ActionResult<IEnumerable<Blog>>> Blogs()
        {
            return await _context.Blog.ToListAsync();
        }
        

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<Blog>> Blog(Guid id)
        {
            var blog = await _context.Blog.FindAsync(id);

            if (blog == null)
            {
                return NotFound();
            }

            return blog;
        }

        
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(Guid id,[FromBody] Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Blog>> Create([FromBody] Blog blog)
        {
            _context.Blog.Add(blog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BlogExists(blog.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Create", new { id = blog.Id }, blog);
        }

         
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Blog>> Delete(Guid id)
        {
            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        private bool BlogExists(Guid id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }
    }
}
