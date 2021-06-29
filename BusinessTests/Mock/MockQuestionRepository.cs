using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTests.Mock
{
    public class MockQuestionRepository : IQuestionRepository
    {
        public Task CreateAsync(Question result)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Question result)
        {
            throw new NotImplementedException();
        }

        public Task<Question> DetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Question result)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetFirstQuestionAsync(Questionnaire questionnaire)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetNextQuestionAsync(Question questionInProgress)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Question>> GetQuestionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Question>> GetQuestionsByQuestionnaireAsync(int questionnaireId)
        {
            List<Question> questions = new()
            {
                new Question()
                {
                    Entitled = "Combien de Roland Garros a remporté Novak Djokovic ?",
                    Order = 1,
                    QuestionnaireId = questionnaireId,
                },
                new Question()
                {
                    Entitled = "Qui est le dernier vainqueur américain de Roland Garros ?",
                    Order = 2,
                    QuestionnaireId = questionnaireId,
                },
            };

            return Task.FromResult(questions.AsQueryable());
        }

        public Task<IQueryable<Question>> GetQuestionsByQuestionnaireOrderAsync(int questionnaireId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OrderExistAsync(Questionnaire questionnaire, int order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OrderExistExcludeQuestionAsync(Questionnaire questionnaire, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
