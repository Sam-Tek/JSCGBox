using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;
using BusinessTests.Mock;
using Entities;

namespace Business.Tests
{
    [TestClass()]
    public class QuestionnaireBusinessTests
    {
        [TestMethod()]
        public async Task GetQuestionnairesAsyncTestAsync()
        {
            // arrange
            IQuestionnaireBusiness questionnaireBusiness = new QuestionnaireBusiness(new MockQuestionnaireRepository());
            // act
            IQueryable<Questionnaire> questionnaires = await questionnaireBusiness.GetQuestionnairesAsync();
            // assert
            Assert.AreEqual(questionnaires.Count(), 1);
        }

        //Code Gaëtan pour tester le repositorie
        //[TestMethod()]
        //public void GetLastPostTest()
        //{
        //    // Créer une BDD en mémoire dédié au test
        //    // Nécéssite le package Microsoft.EntityFrameworkCore.InMemory
        //    var builder = new DbContextOptionsBuilder<WikyCoreDbContext>()
        //                     .UseInMemoryDatabase("Wiky");

        //    var context = new WikyCoreDbContext(null, builder.Options);

        //    context.Database.EnsureDeleted(); // Supprime la BDD entre chaque test
        //                                      // Act + Assert
        //    context.Posts.Add(new Entities.Post { Id = 1, Author = "a", DateCreate = DateTime.Now.AddHours(-1) });
        //    context.Posts.Add(new Entities.Post { Id = 2, Author = "a", DateCreate = DateTime.Now });
        //    context.SaveChanges();
        //    var repo = new PostRepository(context);

        //    var last = repo.GetLastPost();

        //    Assert.AreEqual(last.Id, 2);
        //}
    }
}