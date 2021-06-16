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
    }
}
