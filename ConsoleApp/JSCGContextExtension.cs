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
                    FirstName = "Hugo",
                    LastName = "Jardin",
                    Email = "Hugo01@gmail.com",
                    UserName = "Hugo01@gmail.com",
                    NormalizedUserName = "HUGO01@GMAIL.COM",
                    NormalizedEmail = "HUGO01@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAELW9+NMrd+vrzU7dp4C/Ez20jRNbdCNlCKBezP9nSbWbkiJjaPLvAagnn1nlEzQUDg==",
                    SecurityStamp = "4AMX3MIGT4JZSIWHCWIG4742AZBTEZR3",
                    ConcurrencyStamp = "78bd4e7f-8bb5-4863-84bf-1d83bfdfa1c4",
                    LockoutEnabled = true,
                },
                new User
                {
                    FirstName = "Tom",
                    LastName = "Fretin",
                    Email = "Tom01@gmail.com",
                    UserName = "Tom01@gmail.com",
                    NormalizedUserName = "TOM01@GMAIL.COM",
                    NormalizedEmail = "TOM01@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEMO4qzGQPXzqO5mpot0RxtYptfFCQF0O3SXqA4Q41gMk6BatAmNTjM4/U2/qbXf0ww==",
                    SecurityStamp = "R5MF5ENK3Z3JDORO6DKT37HNNDASVYNR",
                    ConcurrencyStamp = "6bc6ce41-6ba5-4f8d-aaf1-4b8e3173d7e5",
                    LockoutEnabled = true,
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
                    Title = "Capitales des pays de l'Amérique du sud",
                    DefaultTimer = 30,
                    User = users[0],
                },
                new Questionnaire
                {
                    Title = "Mers du monde",
                    DefaultTimer = 60,
                    User = users[0],
                },
                new Questionnaire
                {
                    Title = "Films de Bruce Willis",
                    DefaultTimer = 120,
                    User = users[1],
                },
                new Questionnaire
                {
                    Title = "Vainqueurs de Roland Garros",
                    DefaultTimer = 60,
                    User = users[2],
                },
            };
            #endregion

            #region Questions
            var questions = new List<Question>()
            {
                new Question //0
                {
                    Entitled = "Quelle est la capitale de l'Uruguay ?",
                    Timer = 60,
                    Order = 1,
                    Questionnaire = questionnaires[0],
                },
                new Question //1
                {
                    Entitled = "De quel pays Quito est-elle la capitale ?",
                    Timer = 90,
                    Order = 3,
                    Questionnaire = questionnaires[0],
                },
                new Question //2
                {
                    Entitled = "Quelle est la capitale de la Bolivie ?",
                    Order = 4,
                    Questionnaire = questionnaires[0],
                },
                new Question //3
                {
                    Entitled = "Paramaribo est-elle la capitale d'un pays d'Amérique du sud ?",
                    Timer = 30,
                    Order = 5,
                    Questionnaire = questionnaires[0],
                },
                new Question //4
                {
                    Entitled = "Quelle mer est frontalière du Soudan ?",
                    Timer = 20,
                    Order = 2,
                    Questionnaire = questionnaires[1],
                },
                new Question //5
                {
                    Entitled = "La mer noire est frontalière de quels pays ?",
                    Timer = 30,
                    Order = 3,
                    Questionnaire = questionnaires[1],
                },
                new Question //6
                {
                    Entitled = "Quel est le nom de la mer entre le Japon et la Corée ?",
                    Timer = 30,
                    Order = 4,
                    Questionnaire = questionnaires[1],
                },
                new Question //7
                {
                    Entitled = "De quelle année date le Sixième sens ?",
                    Timer = 30,
                    Order = 1,
                    Questionnaire = questionnaires[2],
                },
                new Question //8
                {
                    Entitled = "Bruce Willis a-t-il joué dans Pulp Fiction ?",
                    Order = 2,
                    Questionnaire = questionnaires[2],
                },
                new Question //9
                {
                    Entitled = "Combien de films Die Hard ont-été tournés ?",
                    Order = 3,
                    Questionnaire = questionnaires[2],
                },
                new Question //10
                {
                    Entitled = "En quelle année Nadal gagne-t-il son premier Roland Garros ?",
                    Order = 1,
                    Questionnaire = questionnaires[3],
                },
                new Question //11
                {
                    Entitled = "Qui est le dernier vainqueur américain de Roland Garros ?",
                    Order = 2,
                    Questionnaire = questionnaires[3],
                },
                new Question //12
                {
                    Entitled = "Combien de Roland Garros a remporté Novak Djokovic ?",
                    Order = 3,
                    Questionnaire = questionnaires[3],
                },
            };
            #endregion

            #region Proposals
            var proposals = new List<Proposal>()
            {
                new Proposal //0
                {
                    Entitled = "Asuncion",
                    IsCorrect = false,
                    Question = questions[0],
                },
                new Proposal //1
                {
                    Entitled = "Santiago",
                    IsCorrect = false,
                    Question = questions[0],
                },
                new Proposal //2
                {
                    Entitled = "Montevideo",
                    IsCorrect = true,
                    Question = questions[0],
                },
                new Proposal //3
                {
                    Entitled = "Venezuela",
                    IsCorrect = false,
                    Question = questions[1],
                },
                new Proposal //4
                {
                    Entitled = "Equateur",
                    IsCorrect = true,
                    Question = questions[1],
                },
                new Proposal //5
                {
                    Entitled = "Colombie",
                    IsCorrect = false,
                    Question = questions[1],
                },
                new Proposal //6
                {
                    Entitled = "Chili",
                    IsCorrect = false,
                    Question = questions[1],
                },
                new Proposal //7
                {
                    Entitled = "La Paz",
                    IsCorrect = true,
                    Question = questions[2],
                },
                new Proposal //8
                {
                    Entitled = "Bogota",
                    IsCorrect = false,
                    Question = questions[2],
                },
                new Proposal //9
                {
                    Entitled = "Lima",
                    IsCorrect = false,
                    Question = questions[2],
                },
                new Proposal //10
                {
                    Entitled = "Oui",
                    IsCorrect = true,
                    Question = questions[3],
                },
                new Proposal //11
                {
                    Entitled = "Non",
                    IsCorrect = false,
                    Question = questions[3],
                },
                new Proposal //12
                {
                    Entitled = "La mer Egée",
                    IsCorrect = false,
                    Question = questions[4],
                },
                new Proposal //13
                {
                    Entitled = "La mer Rouge",
                    IsCorrect = true,
                    Question = questions[4],
                },
                new Proposal //14
                {
                    Entitled = "La mer Morte",
                    IsCorrect = false,
                    Question = questions[4],
                },
                new Proposal //15
                {
                    Entitled = "Grèce",
                    IsCorrect = false,
                    Question = questions[5],
                },
                new Proposal //16
                {
                    Entitled = "Ukraine",
                    IsCorrect = true,
                    Question = questions[5],
                },
                new Proposal //17
                {
                    Entitled = "Turquie",
                    IsCorrect = true,
                    Question = questions[5],
                },
                new Proposal //18
                {
                    Entitled = "Hongrie",
                    IsCorrect = false,
                    Question = questions[5],
                },
                new Proposal //19
                {
                    Entitled = "La mer du Japon",
                    IsCorrect = true,
                    Question = questions[6],
                },
                new Proposal //20
                {
                    Entitled = "La mer de Corée",
                    IsCorrect = false,
                    Question = questions[6],
                },
                new Proposal //21
                {
                    Entitled = "La mer de Chine",
                    IsCorrect = false,
                    Question = questions[6],
                },
                new Proposal //22
                {
                    Entitled = "1995",
                    IsCorrect = false,
                    Question = questions[7],
                },
                new Proposal //23
                {
                    Entitled = "2001",
                    IsCorrect = false,
                    Question = questions[7],
                },
                new Proposal //24
                {
                    Entitled = "1999",
                    IsCorrect = true,
                    Question = questions[7],
                },
                new Proposal //25
                {
                    Entitled = "Oui",
                    IsCorrect = true,
                    Question = questions[8],
                },
                new Proposal //26
                {
                    Entitled = "Non",
                    IsCorrect = false,
                    Question = questions[8],
                },
                new Proposal //27
                {
                    Entitled = "3",
                    IsCorrect = false,
                    Question = questions[9],
                },
                new Proposal //28
                {
                    Entitled = "4",
                    IsCorrect = false,
                    Question = questions[9],
                },
                new Proposal //29
                {
                    Entitled = "5",
                    IsCorrect = true,
                    Question = questions[9],
                },
                new Proposal //30
                {
                    Entitled = "2002",
                    IsCorrect = false,
                    Question = questions[10],
                },
                new Proposal //31
                {
                    Entitled = "2004",
                    IsCorrect = false,
                    Question = questions[10],
                },
                new Proposal //32
                {
                    Entitled = "2005",
                    IsCorrect = true,
                    Question = questions[10],
                },
                new Proposal //33
                {
                    Entitled = "Jim Courier",
                    IsCorrect = false,
                    Question = questions[11],
                },
                new Proposal //34
                {
                    Entitled = "Pete Sampras",
                    IsCorrect = false,
                    Question = questions[11],
                },
                new Proposal //35
                {
                    Entitled = "Andre Agassi",
                    IsCorrect = true,
                    Question = questions[11],
                },
                new Proposal //36
                {
                    Entitled = "1",
                    IsCorrect = false,
                    Question = questions[12],
                },
                new Proposal //37
                {
                    Entitled = "2",
                    IsCorrect = true,
                    Question = questions[12],
                },
                new Proposal //38
                {
                    Entitled = "3",
                    IsCorrect = false,
                    Question = questions[12],
                },
            };
            #endregion

            #region Result
            var results = new List<Result>()
            {
                new Result
                {
                    Note = 13,
                    ResponseDate = new DateTime(2021, 06, 16),
                    User = users[0],
                    Proposals = new List<Proposal>()
                    {
                        proposals[31],
                        proposals[35],
                        proposals[37]
                    }
                },
                new Result
                {
                    Note = 10,
                    ResponseDate = new DateTime(2021, 06, 20),
                    User = users[1],
                    Proposals = new List<Proposal>()
                    {
                        proposals[0],
                        proposals[4],
                        proposals[9],
                        proposals[10]
                    }
                },
                new Result
                {
                    Note = 10,
                    ResponseDate = new DateTime(2021, 06, 14),
                    User = users[1],
                    Proposals = new List<Proposal>()
                    {
                        proposals[13],
                        proposals[17],
                        proposals[19]
                    }
                },
                new Result
                {
                    Note = 20,
                    ResponseDate = new DateTime(2021, 06, 23),
                    User = users[2],
                    Proposals = new List<Proposal>()
                    {
                        proposals[24],
                        proposals[25],
                        proposals[29]
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
