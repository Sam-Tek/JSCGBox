using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class JSCGContextExtension
    {
        public static void Initialize(this JSCGContext context, bool dropAlways = false)
        {
            //To drop database or not
            if (dropAlways)
                context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //if db has been already seeded
            if (context.Users.Any())
                return;

            #region Users
            var users = new List<User>()
            {
                new User
                {
                    FirstName = "Gaétan",
                    LastName = "SORIN",
                    Email = "gaetan@sorin.fr",
                },
                new User
                {
                    FirstName = "Claude",
                    LastName = "GBEMENOU",
                    Email = "claude@gbemenou.fr",
                },
                new User
                {
                    FirstName = "Jérémy",
                    LastName = "SAUDEMONT",
                    Email = "jeremy@saudemont.fr",
                },
                new User
                {
                    FirstName = "Ruben",
                    LastName = "SAMY",
                    Email = "ruben@samy.fr",
                },
            };
            #endregion

            #region Questionnaires
            var questionnaires = new List<Questionnaire>()
            {
                new Questionnaire
                {
                    Title = "Title Questionnaire A",
                    User = users[0],
                },
                new Questionnaire
                {
                    Title = "Title Questionnaire B",
                    User = users[1],
                },
                new Questionnaire
                {
                    Title = "Title Questionnaire C",
                    User = users[2],
                },
                new Questionnaire
                {
                    Title = "Title Questionnaire D",
                    User = users[3],
                },
            };
            #endregion

            #region Questions
            var questions = new List<Question>()
            {
                new Question
                {
                    Entitled = "Entitled Question A",
                    Timer = 60,
                    Questionnaire = questionnaires[0],
                },
                new Question
                {
                    Entitled = "Entitled Question B",
                    Timer = 120,
                    Questionnaire = questionnaires[1],
                },
                new Question
                {
                    Entitled = "Entitled Question C",
                    Timer = 30,
                    Questionnaire = questionnaires[2],
                },
                new Question
                {
                    Entitled = "Entitled Question D",
                    Timer = 15,
                    Questionnaire = questionnaires[3],
                },
            };
            #endregion

            #region Proposals
            var proposals = new List<Proposal>()
            {
                new Proposal
                {
                    Entitled = "Entitled Proposal A",
                    IsCorrect = true,
                    Question = questions[0],
                },
                new Proposal
                {
                    Entitled = "Entitled Proposal B",
                    IsCorrect = true,
                    Question = questions[1],
                },
                new Proposal
                {
                    Entitled = "Entitled Proposal C",
                    IsCorrect = true,
                    Question = questions[2],
                },
                new Proposal
                {
                    Entitled = "Entitled Proposal D",
                    IsCorrect = false,
                    Question = questions[3],
                },
            };
            #endregion

            #region Result
            var results = new List<Result>()
            {
                new Result
                {
                    Note = 20,
                    ResponseDate = new DateTime(2021, 06, 16),
                    User = users[0],
                    Proposals = proposals,
                },
                new Result
                {
                    Note = 19,
                    ResponseDate = new DateTime(2021, 06, 15),
                    User = users[1],
                    Proposals = proposals,
                },
                new Result
                {
                    Note = 18.5,
                    ResponseDate = new DateTime(2021, 06, 14),
                    User = users[2],
                    Proposals = proposals,
                },
                new Result
                {
                    Note = 17.5,
                    ResponseDate = new DateTime(2021, 06, 13),
                    User = users[3],
                    Proposals = proposals,
                },
            };
            #endregion

            context.Users.AddRange(users);
            context.Questionnaires.AddRange(questionnaires);
            context.Questions.AddRange(questions);
            context.Proposals.AddRange(proposals);
            context.Results.AddRange(results);
        }
    }
}
