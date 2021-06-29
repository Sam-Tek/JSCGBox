using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Business;
using Business.Contracts;
using Microsoft.Extensions.Configuration;
using Repositories.Api;
using Repositories.Contracts;
using Unity;
using WPFAPP.View;
using WPFAPP.ViewModel;

namespace WPFAPP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IConfiguration _configuration;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            _configuration = builder.Build();
 
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
            container.RegisterInstance(_configuration);
            

            var window = new MainWindow
            {
                DataContext = container.Resolve<MainViewModel>()
            };
            window.Show();
        }
    }
}
