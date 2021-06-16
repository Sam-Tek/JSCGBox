﻿using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IQuestionRepository
    {
        public Task<IQueryable<Question>> GetQuestionsAsync();

        public Task<Question> DetailAsync(int id);

        public Task CreateAsync(Question result);

        public Task EditAsync(Question result);

        public Task DeleteAsync(Question result);
    }
}
