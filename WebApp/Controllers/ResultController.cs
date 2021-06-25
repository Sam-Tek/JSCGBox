using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ResultController : Controller
    {
        private IResultBusiness _resultBusiness;

        public ResultController(IResultBusiness resultBusiness)
        {
            _resultBusiness = resultBusiness;
        }

        public async Task<IActionResult> Index(int id)
        {
            Result result = await _resultBusiness.DetailAsync(id);
            int nbPoints = 0;
            int nbPointsOutOf20 = 0;

            if (result.Proposals.Count > 0)
            {
                Questionnaire questionnaire = result.Proposals.FirstOrDefault().Question.Questionnaire;
                // Nombre de propositions correctes ?
                int nbCorrectProposals = 0;
                foreach (Question question in questionnaire.Questions)
                {
                    foreach (Proposal proposal in question.Proposals)
                    {
                        if (proposal.IsCorrect)
                        {
                            nbCorrectProposals++;
                        }
                    }
                }
                // Nombre de réponses correctes ?
                foreach (Proposal proposal in result.Proposals)
                {
                    if (proposal.IsCorrect)
                    {
                        nbPoints++;
                    }
                }
                // Note sur 20
                if (nbCorrectProposals > 0)
                {
                    nbPointsOutOf20 = (int)Math.Ceiling((decimal)nbPoints * 20 / nbCorrectProposals);
                }
            }
            // Mise à jour de la note
            result.Note = nbPointsOutOf20;
            await _resultBusiness.EditAsync(result);

            return View(result);
        }
    }
}
