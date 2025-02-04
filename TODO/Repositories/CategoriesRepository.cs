using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TODO.Context;
using TODO.Models;
using TODO.Repositories.Interfaces;

namespace TODO.Repositories
{

    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly TodoDbContext _context;

        public CategoriesRepository(TodoDbContext context)
        {
            _context = context;
        }

        public void AddCategories(Categories category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategories(Guid id)
        {
            //fetching and deleting tasks associated with a particular category
            var taskData = _context.Tasks.Where(x => x.CategoriesId == id).ToList();
            _context.Tasks.RemoveRange(taskData);

            //fetching and deleting the category itself
            var data = _context.Categories.FirstOrDefault(x => x.CategoriesId == id);
            _context.Categories.Remove(data);
            _context.SaveChanges();
        }

        public async Task<List<Categories>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Categories> GetById(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<Tasks>> GetTaskByCategoriesId(Guid id)
        {
            var data = await _context.Tasks.Where(x => x.CategoriesId == id).Include(x => x.Categories).ToListAsync();
            return data;
        }

        public void UpdateCategories(Categories category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
