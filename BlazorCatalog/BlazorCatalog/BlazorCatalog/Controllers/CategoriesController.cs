namespace BlazorCatalog.Controllers
{
    using BlazorCatalog.Context;
    using BlazorCatalog.Shared.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get() 
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name ="GetCategory")]
        public async Task<ActionResult<Category>> Get(int id) 
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if (category == null)
                return NotFound($"Category with id={id} not found");

            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category) 
        {
            _context.Add(category);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetCategory", 
                new { id = category.CategoryId }, category);
        }

        [HttpPut]
        public async Task<ActionResult<Category>> Put(Category category) 
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id) 
        {
            var category = new Category { CategoryId = id };
            _context.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }
    }
}
