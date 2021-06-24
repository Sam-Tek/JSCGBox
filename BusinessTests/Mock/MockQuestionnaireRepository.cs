using Entities;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTests.Mock
{
    class MockQuestionnaireRepository : IQuestionnaireRepository
    {
        public Task CreateAsync(Questionnaire result)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Questionnaire result)
        {
            throw new NotImplementedException();
        }

        public Task<Questionnaire> DetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Questionnaire> DetailByUserIdAsync(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Questionnaire result)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Questionnaire>> GetQuestionnairesAsync()
        {
            List<Questionnaire> questionnaires = new List<Questionnaire>
            {
                new Questionnaire()
                {
                    Id = 1,
                    DefaultTimer = 60,
                    Title = "Questionnaire Test",
                    Questions = new Collection<Question>(){ new Question(){ Id = 1, Entitled = "Entitled", Timer = 30, Order = 1 } },
                    User = new User
                    {
                        Id = "dzdzdzdz",
                        FirstName = "Test01",
                        LastName = "User",
                        Email = "Test01@user.fr",
                        UserName = "Test01@user.fr",
                        NormalizedUserName = "TEST01@USER.FR",
                        NormalizedEmail = "TEST01@USER.FR",
                        EmailConfirmed = true,
                        PasswordHash = "AQAAAAEAACcQAAAAEM0he6rEcsxEawZcjY3+RX7FBs9sHpAW80ISRfR2aejHaepPBKoUZkiU4zNGbXMcFQ==",
                        SecurityStamp = "GXH3W5ETKCQVFYOIXFUI7BGLZ7WIHVML",
                        ConcurrencyStamp = "caa5f686-ac42-46f7-ac5e-03d93d7ce843",
                        LockoutEnabled = true,
                    },
                    UserId = "dzdzdzdz" 
                }
            };
            return Task.FromResult(questionnaires.AsQueryable());
        }
    }
}
