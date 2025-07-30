using Backend.Models;

namespace Backend.Services.Interfaces
{
    public interface IEmailService
    {
        Task<List<Email>> GetAllAsync();
        Task<Email?> GetByIdAsync(string id);
        Task<List<Email>> GetByProjectIdAsync(string id);
        Task CreateAsync(Email email);
        Task UpdateAsync(string id, Email email);
        Task DeleteAsync(string id);
        Task<bool> UpdateEmailAsync(string id, UpdateEmailDto updateDto);
    }
}
public class UpdateEmailDto
{
    public bool? IsRead { get; set; }
    public bool? IsTapped { get; set; }
}
