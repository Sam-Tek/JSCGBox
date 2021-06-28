using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unity;
using WPFAPP.Core;
using WPFAPP.View;

namespace WPFAPP.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ResultatViewCommand { get; set; }
        public HomeView HomeVM { get; set; }
        public ResultatView ResultatVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private IUnityContainer _unityContainer;
        
        public MainViewModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            HomeVM = _unityContainer.Resolve<HomeView>();
            ResultatVM = _unityContainer.Resolve<ResultatView>();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            ResultatViewCommand = new RelayCommand(o =>
            {
                CurrentView = ResultatVM;
            });
        }
    }
}
