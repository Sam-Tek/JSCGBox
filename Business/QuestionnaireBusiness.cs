using Business.Contracts;
using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class QuestionnaireBusiness : IQuestionnaireBusiness
    {
        private IQuestionnaireRepository _questionnaireRepository;

        public QuestionnaireBusiness(IQuestionnaireRepository questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }

        public async Task<IQueryable<Questionnaire>> GetQuestionnairesAsync()
        {
            return await _questionnaireRepository.GetQuestionnairesAsync();
        }

        public async Task<Questionnaire> DetailAsync(int id)
        {
            return await _questionnaireRepository.DetailAsync(id);
        }

        //Added this method because for edit questionnaire I must be sure that the questionnaire belongs to one user
        public async Task<Questionnaire> DetailByUserIdAsync(int id, string userId)
        {
            return await _questionnaireRepository.DetailByUserIdAsync(id,userId);
        }

        public async Task CreateAsync(Questionnaire result)
        {
            await _questionnaireRepository.CreateAsync(result);
        }

        public async Task EditAsync(Questionnaire result)
        {
            await _questionnaireRepository.EditAsync(result);
        }

        public async Task DeleteAsync(Questionnaire result)
        {
            await _questionnaireRepository.DeleteAsync(result);
        }
    }
}
