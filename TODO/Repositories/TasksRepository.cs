using Microsoft.EntityFrameworkCore;
using TODO.Context;
using TODO.Models;
using TODO.Repositories.Interfaces;

namespace TODO.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TodoDbContext _context;

        public TasksRepository(TodoDbContext context)
        {
            _context = context;
        }
        public void AddTask(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Guid id)
        {
            var data = _context.Tasks.Where(x => x.TaskId == id).FirstOrDefault();
            _context.Tasks.Remove(data);
            _context.SaveChanges();
        }

        public async Task<List<Tasks>> GetAllTasksAsync()
        {
            return await _context.Tasks.Include(x => x.Categories).ToListAsync();
        }

        public async Task<Tasks> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }


        public async Task UpdateStatusById(Guid id, bool isCompleted)
        {
            var data = _context.Tasks.FirstOrDefault(x => x.TaskId == id);

            if (data == null)
            {
                throw new Exception("Task not found.");
            }

            data.IsCompleted = isCompleted;

            _context.Tasks.Update(data);

            _context.SaveChanges();
        }

        public void UpdateTask(Tasks task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
