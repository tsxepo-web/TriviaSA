using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaSA.Core.Entities;

namespace TriviaSA.Core.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Questions>> GetQuestionsAsync();
        Task<Questions> GetQuestionByIdAsync(string id);
        Task CreateQuestionAsync(Questions question);
        Task UpdateQuestionAsync(Questions question);
        Task DeleteQuestionAsync(string id);
        Task<Questions> GetRandomQuestionAsync();
    }
}
