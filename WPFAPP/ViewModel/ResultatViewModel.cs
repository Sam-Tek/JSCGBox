using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;
using Entities;

namespace WPFAPP.ViewModel
{
    class ResultatViewModel
    {
        private IQuestionnaireBusiness _questionnaireBusiness;

        public ObservableCollection<Questionnaire> Questionnaires { get; set; }
        
        public ResultatViewModel(IQuestionnaireBusiness questionnaireBusiness)
        {
            _questionnaireBusiness = questionnaireBusiness;
            Questionnaires = new ObservableCollection<Questionnaire>();
            LoadQuestionnaires();
        }

        public ResultatViewModel()
        {
            throw new NotImplementedException();
        }

        public async void LoadQuestionnaires()
        {
            var questionnaires = await _questionnaireBusiness.GetQuestionnairesAsync();
            foreach (var questionnaire in questionnaires)
            {
                Questionnaires.Add(questionnaire);
            }
        }
    }
}
