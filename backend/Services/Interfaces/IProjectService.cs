using Backend.Models;

namespace Backend.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<List<Project>> GetByUserIdAsync(string userId);
        Task<Project?> GetByIdAsync(string id);
        Task CreateAsync(Project project);
        Task UpdateAsync(string id, Project project);
        Task DeleteAsync(string id);
    }
}
