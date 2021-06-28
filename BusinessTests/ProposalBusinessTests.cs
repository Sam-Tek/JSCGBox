using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessTests.Mock;
using Business.Contracts;
using Entities;

namespace Business.Tests
{
    [TestClass()]
    public class ProposalBusinessTests
    {
        [TestMethod()]
        public async Task GetResultByUserIdAndQuestionnaireIdAndDateAsyncTest()
        {
            // arrange
            IProposalBusiness proposalBusiness = new ProposalBusiness(new MockProposalRepository(), new MockQuestionRepository());
            string userId = "test02";
            int questionnaireId = 5;
            DateTime date = new DateTime(2021,06,10);
            // act
            Result result = await proposalBusiness.GetResultByUserIdAndQuestionnaireIdAndDateAsync(userId, questionnaireId, date);
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Note, 10);
        }
    }
}