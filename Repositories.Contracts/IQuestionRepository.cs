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

        public Task<IQueryable<Question>> GetQuestionsByQuestionnaireOrderAsync(int questionnaireId);

        public Task<Question> DetailAsync(int id);

        public Task<bool> ExistAsync(int id);

        public Task CreateAsync(Question result);

        public Task EditAsync(Question result);

        public Task DeleteAsync(Question result);

        public Task<Question> GetFirstQuestionAsync(Questionnaire questionnaire);

        public Task<Question> GetNextQuestionAsync(Question questionInProgress);

        /// <summary>check if this order already exists in bdd</summary>
        public Task<bool> OrderExistAsync(Questionnaire questionnaire, int order);

        /// <summary>check if this order already exists in bdd and exclude a question, for edition of question</summary>
        public Task<bool> OrderExistExcludeQuestionAsync(Questionnaire questionnaire, Question question);
    }
}
