using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IQuestionBusiness
    {
        public Task<IQueryable<Question>> GetQuestionsAsync();

        public Task<IQueryable<Question>> GetQuestionsByQuestionnaireAsync(int questionnaireId);

        public Task<Question> DetailAsync(int id);

        public Task<bool> ExistAsync(int id);

        public Task CreateAsync(Question result);

        public Task EditAsync(Question result);

        public Task DeleteAsync(Question result);

        public Task<Question> GetFirstQuestionAsync(Questionnaire questionnaire);

        public Task<Question> GetNextQuestionAsync(Question questionInProgress);

        ///<summary>get the good number of order ex old question is 1, 2 and this method get 3</summary>
        public Task<int> GetNextOrderQuestionAsync(Questionnaire questionnaire);

        public Task<IQueryable<Question>> GetQuestionsByQuestionnaireOrderAsync(int questionnaireId);

        /// <summary>
        /// Check if this order already exists in bdd if it is not defined we create it
        /// </summary>
        /// <returns>this method returns a value for order</returns>
        public Task<int> OrderExistSoCreateAsync(Questionnaire questionnaire, Question question);
    }
}
