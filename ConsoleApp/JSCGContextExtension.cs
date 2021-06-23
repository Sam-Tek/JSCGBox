using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Repositories;

namespace ConsoleApp
{
    // ReSharper disable once InconsistentNaming
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
                new User
                {
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
            };
            #endregion

            #region Questionnaires
            var questionnaires = new List<Questionnaire>()
            {
                new Questionnaire
                {
                    Title = "Title Questionnaire A",
                    DefaultTimer = 30,
                    User = users[0],
                },
                new Questionnaire
                {
                    Title = "Title Questionnaire B",
                    DefaultTimer = 60,
                    User = users[1],
                },
                new Questionnaire
                {
                    Title = "Title Questionnaire C",
                    DefaultTimer = 120,
                    User = users[4],
                },
                new Questionnaire
                {
                    Title = "Title Questionnaire D",
                    DefaultTimer = 60,
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
                    Order = 1,
                    Questionnaire = questionnaires[0],
                },
                new Question
                {
                    Entitled = "Entitled Question B",
                    Timer = 120,
                    Order = 1,
                    Questionnaire = questionnaires[1],
                },
                new Question
                {
                    Entitled = "Entitled Question C",
                    Timer = 30,
                    Order = 1,
                    Questionnaire = questionnaires[2],
                },
                new Question
                {
                    Entitled = "Entitled Question D",
                    Timer = 15,
                    Order = 1,
                    Questionnaire = questionnaires[3],
                },
                new Question
                {
                    Entitled = "Entitled Question E",
                    Timer = 20,
                    Order = 2,
                    Questionnaire = questionnaires[2],
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
                new Proposal
                {
                    Entitled = "Entitled Proposal E",
                    IsCorrect = false,
                    Question = questions[2],
                },
                new Proposal
                {
                    Entitled = "Entitled Proposal F",
                    IsCorrect = false,
                    Question = questions[4],
                },
                new Proposal
                {
                    Entitled = "Entitled Proposal G",
                    IsCorrect = false,
                    Question = questions[4],
                },
                new Proposal
                {
                    Entitled = "Entitled Proposal H",
                    IsCorrect = false,
                    Question = questions[4],
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
                },
                new Result
                {
                    Note = 19,
                    ResponseDate = new DateTime(2021, 06, 15),
                    User = users[1],
                },
                new Result
                {
                    Note = 18.5,
                    ResponseDate = new DateTime(2021, 06, 14),
                    User = users[2],
                },
                new Result
                {
                    Note = 17.5,
                    ResponseDate = new DateTime(2021, 06, 13),
                    User = users[3],
                },
                new Result
                {
                    Note = 15,
                    ResponseDate = new DateTime(2021, 06, 23),
                    User = users[4],
                    Proposals = new List<Proposal>()
                    {
                        proposals[5],
                        proposals[6]
                    }
                },
            };
            #endregion

            context.Users.AddRange(users);
            context.Questionnaires.AddRange(questionnaires);
            context.Questions.AddRange(questions);
            context.Proposals.AddRange(proposals);
            context.Results.AddRange(results);
            context.SaveChanges();
        }
    }
}
