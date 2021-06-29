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
            Assert.AreEqual(questionnaires.Count(), 2);
        }
    }
}