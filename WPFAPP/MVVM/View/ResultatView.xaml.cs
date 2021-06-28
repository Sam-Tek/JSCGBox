using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;
using WPFAPP.MVVM.ViewModel;

namespace WPFAPP.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour ResultatView.xaml
    /// </summary>
    public partial class ResultatView : UserControl
    {
        private IUnityContainer _unityContainer;
        public ResultatView(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            DataContext = _unityContainer.Resolve<ResultatViewModel>();
            InitializeComponent();
        }
    }
}
