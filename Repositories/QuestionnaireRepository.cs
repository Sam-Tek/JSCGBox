using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class QuestionnaireRepository
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

        public async Task<Questionnaire> DetailsAsync(int id)
        {
            return await _context.Questionnaires.FirstOrDefaultAsync(b => b.Id == id);
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
