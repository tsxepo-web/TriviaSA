using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaSA.Core.Entities;
using TriviaSA.Core.Interfaces;

namespace TriviaSA.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IMongoCollection<Questions> _collection;
        public QuestionRepository(IMongoCollection<Questions>  collection)
        {
            _collection = collection;
        }
        public async Task CreateQuestionAsync(Questions question)
        {
            await _collection.InsertOneAsync(question);
        }

        public async Task DeleteQuestionAsync(string id)
        {
            await _collection.DeleteOneAsync(q => q.Id == id);
        }

        public async Task<Questions> GetQuestionByIdAsync(string id)
        {
            return await _collection.Find(q => q.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Questions>> GetQuestionsAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Questions> GetRandomQuestionAsync()
        {
            var count = (int)await _collection.CountDocumentsAsync(FilterDefinition<Questions>.Empty);
            var randomIndex = new Random().Next(0, count);
            return await _collection.Find(FilterDefinition<Questions>.Empty).Skip(randomIndex).Limit(1).SingleOrDefaultAsync();
        }

        public async Task UpdateQuestionAsync(Questions question)
        {
            await _collection.ReplaceOneAsync(q => question.Id == question.Id, question);
        }
    }
}
