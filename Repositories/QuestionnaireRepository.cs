using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private JSCGContext _context;

        public QuestionnaireRepository(JSCGContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Questionnaire>> GetQuestionnairesAsync()
        {
            var questionnaires = await _context.Questionnaires.ToListAsync();
            return questionnaires.AsQueryable();
        }

        public async Task<Questionnaire> DetailAsync(int id)
        {
            return await _context.Questionnaires.FirstOrDefaultAsync(b => b.Id == id);
        }

        //Added this method because for edit questionnaire I must be sure that the questionnaire belongs to one user
        public async Task<Questionnaire> DetailByUserIdAsync(int id, string userId)
        {
            return await _context.Questionnaires.FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);
        }

        public async Task CreateAsync(Questionnaire questionnaire)
        {
            _context.Questionnaires.Add(questionnaire);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Questionnaire questionnaire)
        {
            _context.Update(questionnaire);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Questionnaire questionnaire)
        {
            _context.Remove(questionnaire);
            await _context.SaveChangesAsync();
        }
    }
}
