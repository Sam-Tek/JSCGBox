using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IQuestionnaireRepository
    {
        public Task<IQueryable<Questionnaire>> GetQuestionnairesAsync();

        public Task<Questionnaire> DetailAsync(int id);

        //Added this method because for edit questionnaire I must be sure that the questionnaire belongs to one user
        public Task<Questionnaire> DetailByUserIdAsync(int id, string userId);

        public Task CreateAsync(Questionnaire result);

        public Task EditAsync(Questionnaire result);

        public Task DeleteAsync(Questionnaire result);
    }
}
