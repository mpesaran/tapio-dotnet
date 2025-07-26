using Backend.Models;
using Backend.Services.Interfaces;
using MongoDB.Driver;

namespace Backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMongoCollection<Email> _emailCollection;

        public EmailService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _emailCollection = database.GetCollection<Email>("emails");
        }

        public async Task<List<Email>> GetAllAsync() =>
            await _emailCollection.Find(_ => true).ToListAsync();

        public async Task<Email?> GetByIdAsync(string id) =>
            await _emailCollection.Find(u => u.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Email email) =>
            await _emailCollection.InsertOneAsync(email);

        public async Task UpdateAsync(string id, Email email) =>
            await _emailCollection.ReplaceOneAsync(u => u.Id == id, email);

        public async Task DeleteAsync(string id) =>
            await _emailCollection.DeleteOneAsync(u => u.Id == id);
    }
}
