using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IQuestionnaireBusiness
    {
        public Task<IQueryable<Questionnaire>> GetQuestionnairesAsync();

        public Task<Questionnaire> DetailAsync(int id);

        public Task CreateAsync(Questionnaire result);

        public Task EditAsync(Questionnaire result);

        public Task DeleteAsync(Questionnaire result);
    }
}
