using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaSA.Core.Entities;
using TriviaSA.Core.Interfaces;

namespace TriviaSA.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository) => _questionRepository = questionRepository;
        public async Task CreateQuestionAsync(Questions question)
        {
            await _questionRepository.CreateQuestionAsync(question);
        }

        public async Task DeleteQuestionAsync(string id)
        {
            await (_questionRepository.DeleteQuestionAsync(id));
        }

        public async Task<Questions> GetQuestionByIdAsync(string id)
        {
            return await _questionRepository.GetQuestionByIdAsync(id);
        }

        public Task<IEnumerable<Questions>> GetQuestionsAsync()
        {
            return _questionRepository.GetQuestionsAsync();
        }

        public async Task<Questions> GetRandomQuestionAsync()
        {
            return await (_questionRepository.GetRandomQuestionAsync());
        }

        public async Task UpdateQuestionAsync(Questions question)
        {
            await _questionRepository.UpdateQuestionAsync(question);
        }
    }
}
