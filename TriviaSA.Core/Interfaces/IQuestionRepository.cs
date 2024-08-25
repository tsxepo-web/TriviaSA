using TriviaSA.Core.Entities;

namespace TriviaSA.Core.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Questions>> GetQuestionsAsync();
        Task<Questions> GetQuestionByIdAsync(string id);
        Task CreateQuestionAsync(Questions question);
        Task UpdateQuestionAsync(Questions question);
        Task DeleteQuestionAsync(string id);
        Task<Questions> GetRandomQuestionAsync();
    }
}
