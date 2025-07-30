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
        public async Task<List<Email>> GetByProjectIdAsync(string id) =>
            await _emailCollection.Find(e => e.ProjectId == id && e.IsApproved == true).ToListAsync();
        public async Task CreateAsync(Email email) =>
            await _emailCollection.InsertOneAsync(email);

        public async Task UpdateAsync(string id, Email email) =>
            await _emailCollection.ReplaceOneAsync(u => u.Id == id, email);

        public async Task DeleteAsync(string id) =>
            await _emailCollection.DeleteOneAsync(u => u.Id == id);

        public async Task<bool> UpdateEmailAsync(string id, UpdateEmailDto updateDto)
        {
            var filter = Builders<Email>.Filter.Eq(e => e.Id, id);
            var updates = new List<UpdateDefinition<Email>>();

            if (updateDto.IsRead.HasValue)
                updates.Add(Builders<Email>.Update.Set(e => e.IsRead, updateDto.IsRead.Value));

            if (updateDto.IsTapped.HasValue)
                updates.Add(Builders<Email>.Update.Set(e => e.IsTapped, updateDto.IsTapped.Value));

            if (!updates.Any())
                return false;

            var updateDefinition = Builders<Email>.Update.Combine(updates);
            var result = await _emailCollection.UpdateOneAsync(filter, updateDefinition);

            return result.ModifiedCount > 0;
        }
                    
    }
}
