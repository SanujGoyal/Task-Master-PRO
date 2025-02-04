using TODO.Models;

namespace TODO.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<Categories>> GetAllCategoriesAsync();
        Task<Categories> GetById(Guid id);
        Task<List<Tasks>> GetTaskByCategoriesId(Guid id);
        void AddCategories(Categories category);
        void DeleteCategories(Guid id);

        void UpdateCategories(Categories category);
    }
}
