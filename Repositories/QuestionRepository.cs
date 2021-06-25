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
    public class QuestionRepository : IQuestionRepository
    {
        private JSCGContext _context;

        public QuestionRepository(JSCGContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Question>> GetQuestionsAsync()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions.AsQueryable();
        }

        public async Task<IQueryable<Question>> GetQuestionsByQuestionnaireAsync(int questionnaireId)
        {
            var questions = await _context.Questions.Where(q => q.Questionnaire.Id == questionnaireId).ToListAsync();
            return questions.AsQueryable();
        }

        public async Task<Question> DetailAsync(int id)
        {
            return await _context.Questions.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Questions.AnyAsync(q => id == q.Id);
        }

        public async Task CreateAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Question question)
        {
            _context.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Question question)
        {
            _context.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task<Question> GetFirstQuestionAsync(Questionnaire questionnaire)
        {
            return await _context.Questions.OrderBy(q => q.Order).FirstOrDefaultAsync(q => q.Questionnaire.Id == questionnaire.Id);
        }

        public async Task<Question> GetNextQuestionAsync(Question questionInProgress)
        {
            return await _context.Questions.OrderBy(q => q.Order).FirstOrDefaultAsync(q => q.Questionnaire.Id == questionInProgress.QuestionnaireId && q.Order > questionInProgress.Order);
        }
    }
}
