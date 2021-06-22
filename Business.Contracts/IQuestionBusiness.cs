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

        public Task CreateAsync(Question result);

        public Task EditAsync(Question result);

        public Task DeleteAsync(Question result);
    }
}
