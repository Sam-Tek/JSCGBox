using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTests.Mock
{
    public class MockProposalRepository : IProposalRepository
    {
        public Task CreateAsync(Proposal proposal)
        {
            throw new NotImplementedException();
        }

        public Task CreateProposalResultAsync(Proposal proposal, Result result)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Proposal proposal)
        {
            throw new NotImplementedException();
        }

        public Task<Proposal> DetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Proposal proposal)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Proposal>> GetProposalsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Proposal>> GetProposalsByQuestionAsync(int questionId)
        {
            List<Proposal> proposals = new()
            {
                new Proposal()
                {
                    Entitled = "1",
                    IsCorrect = false,
                    QuestionId = questionId,
                    Results = new List<Result>()
                    {
                        new Result()
                        {
                            ResponseDate = new DateTime(2021,06,05),
                            Note = 20,
                            UserId = "test01"                        }
                    }
                },
                new Proposal()
                {
                    Entitled = "2",
                    IsCorrect = true,
                    QuestionId = questionId,
                    Results = new List<Result>()
                    {
                        new Result()
                        {
                            ResponseDate = new DateTime(2021,06,10),
                            Note = 10,
                            UserId = "test02"
                        }
                    }
                },
                new Proposal()
                {
                    Entitled = "3",
                    IsCorrect = false,
                    QuestionId = questionId,
                    Results = new List<Result>()
                    {
                        new Result()
                        {
                            ResponseDate = new DateTime(2021,06,10),
                            Note = 15,
                            UserId = "test03"
                        }
                    }
                },
            };

            return Task.FromResult(proposals.AsQueryable());
        }
    }
}
