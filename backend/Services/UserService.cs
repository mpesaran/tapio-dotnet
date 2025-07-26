using Backend.Models;
using Backend.Services.Interfaces;
using MongoDB.Driver;

namespace Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _userCollection = database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAllAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetByIdAsync(string id) =>
            await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User user) =>
            await _userCollection.InsertOneAsync(user);

        public async Task UpdateAsync(string id, User user) =>
            await _userCollection.ReplaceOneAsync(u => u.Id == id, user);

        public async Task DeleteAsync(string id) =>
            await _userCollection.DeleteOneAsync(u => u.Id == id);
    }
}
