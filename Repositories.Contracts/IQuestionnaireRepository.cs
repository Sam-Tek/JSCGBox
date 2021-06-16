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

        public Task CreateAsync(Questionnaire result);

        public Task EditAsync(Questionnaire result);

        public Task DeleteAsync(Questionnaire result);
    }
}
