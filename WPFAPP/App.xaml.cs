using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Business;
using Business.Contracts;
using Repositories.Api;
using Repositories.Contracts;
using Unity;
using WPFAPP.MVVM.View;
using WPFAPP.MVVM.ViewModel;

namespace WPFAPP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
 
            IUnityContainer container = new UnityContainer().AddExtension(new Diagnostic());
            container.RegisterType<IQuestionBusiness, QuestionBusiness>();
            container.RegisterType<IQuestionRepository, QuestionRepository>();
            container.RegisterType<IQuestionnaireBusiness, QuestionnaireBusiness>();
            container.RegisterType<IQuestionnaireRepository, QuestionnaireRepository>();
            container.RegisterType<HomeViewModel>();
            container.RegisterType<ResultatViewModel>();
            container.RegisterType<HomeView>();
            container.RegisterType<ResultatView>();
            container.RegisterInstance(container);
            

            var window = new MainWindow
            {
                DataContext = container.Resolve<MainViewModel>()
            };
            window.Show();
        }
    }
}
