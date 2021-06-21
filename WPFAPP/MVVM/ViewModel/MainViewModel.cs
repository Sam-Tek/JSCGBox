﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAPP.Core;

namespace WPFAPP.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ResultatViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public ResultatViewModel ResultatVM { get; set; }

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
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            ResultatVM = new ResultatViewModel();
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
