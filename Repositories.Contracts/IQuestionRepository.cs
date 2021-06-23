using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IQuestionRepository
    {
        public Task<IQueryable<Question>> GetQuestionsAsync();

        public Task<IQueryable<Question>> GetQuestionsByQuestionnaireAsync(int questionnaireId);

        public Task<Question> DetailAsync(int id);

        public Task<bool> ExistAsync(int id);

        public Task CreateAsync(Question result);

        public Task EditAsync(Question result);

        public Task DeleteAsync(Question result);

        public Task<Question> GetNextQuestionAsync(Question questionInProgress);
    }
}
