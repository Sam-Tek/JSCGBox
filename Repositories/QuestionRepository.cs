using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class QuestionRepository
    {
        private JSCGContext _context;

        public QuestionRepository(JSCGContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Question>> GetQuestionAsync()
        {
            var questions = await _context.Questions.ToListAsync();
            return questions.AsQueryable();
        }

        public async Task<Question> DetailsAsync(int id)
        {
            return await _context.Questions.FirstOrDefaultAsync(b => b.Id == id);
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
    }
}
