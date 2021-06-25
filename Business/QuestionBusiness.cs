using Business.Contracts;
using Entities;
using Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class QuestionBusiness : IQuestionBusiness
    {
        private IQuestionRepository _questionRepository;
        
        public QuestionBusiness(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IQueryable<Question>> GetQuestionsAsync()
        {
            return await _questionRepository.GetQuestionsAsync();
        }

        public async Task<IQueryable<Question>> GetQuestionsByQuestionnaireAsync(int questionnaireId)
        {
            return await _questionRepository.GetQuestionsByQuestionnaireAsync(questionnaireId);
        }

        public async Task<Question> DetailAsync(int id)
        {
            return await _questionRepository.DetailAsync(id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _questionRepository.ExistAsync(id);
        }

        public async Task CreateAsync(Question question)
        {
            await _questionRepository.CreateAsync(question);
        }

        public async Task EditAsync(Question question)
        {
            await _questionRepository.EditAsync(question);
        }

        public async Task DeleteAsync(Question question)
        {
            await _questionRepository.DeleteAsync(question);
        }

        public async Task<Question> GetFirstQuestionAsync(Questionnaire questionnaire)
        {
            return await _questionRepository.GetFirstQuestionAsync(questionnaire);
        }

        public async Task<Question> GetNextQuestionAsync(Question questionInProgress)
        {
            return await _questionRepository.GetNextQuestionAsync(questionInProgress);
        }

        ///get the good number of order ex old question is 1, 2 and this method get 3
        public async Task<int> GetNextOrderQuestionAsync(Questionnaire questionnaire)
        {
            IQueryable<Question> questions = await GetQuestionsByQuestionnaireOrderAsync(questionnaire.Id);
            if (questions.Count() > 0)
                return questions.LastOrDefault().Order + 1;
            return 1;
        }

        public async Task<IQueryable<Question>> GetQuestionsByQuestionnaireOrderAsync(int questionnaireId)
        {
            return await _questionRepository.GetQuestionsByQuestionnaireOrderAsync(questionnaireId);
        }

        public async Task<int> OrderExistSoCreateAsync(Questionnaire questionnaire, Question question)
        {
            bool OrderExist;

            if (question.Id == 0)
            {
                OrderExist = await _questionRepository.OrderExistAsync(questionnaire, question.Order);
            }
            else
            {
                OrderExist = await _questionRepository.OrderExistExcludeQuestionAsync(questionnaire, question);
            }

            //if it already exists we create a new one
            if (OrderExist == true)
            {
                return await GetNextOrderQuestionAsync(questionnaire);
            }
            return question.Order;
        }
    }
}
