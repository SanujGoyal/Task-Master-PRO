using TODO.Models;

namespace TODO.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        Task<List<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetById(Guid id);
        void AddTask(Tasks task);
        void DeleteTask(Guid id);
        void UpdateTask(Tasks task);
        Task UpdateStatusById(Guid id, bool isCompleted);
    }

}
