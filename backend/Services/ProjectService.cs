using Backend.Models;
using Backend.Services.Interfaces;
using MongoDB.Driver;

namespace Backend.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMongoCollection<Project> _projectCollection;

        public ProjectService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _projectCollection = database.GetCollection<Project>("projects");
        }

        public async Task<List<Project>> GetAllAsync() =>
            await _projectCollection.Find(_ => true).ToListAsync();

        public async Task<Project?> GetByIdAsync(string id) =>
            await _projectCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        public async Task<List<Project>> GetByUserIdAsync(string userId)
        {
            return await _projectCollection.Find(p => p.UserId == userId).ToListAsync();
        }
        public async Task CreateAsync(Project project) =>
            await _projectCollection.InsertOneAsync(project);

        public async Task UpdateAsync(string id, Project project) =>
            await _projectCollection.ReplaceOneAsync(u => u.Id == id, project);

        public async Task DeleteAsync(string id) =>
            await _projectCollection.DeleteOneAsync(u => u.Id == id);
    }
}
