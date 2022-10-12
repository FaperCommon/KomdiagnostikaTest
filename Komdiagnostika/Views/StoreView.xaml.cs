using Komdiagnostika.ViewModels;
using Prism.Ioc;
using System.Windows;
using System.Windows.Controls;

namespace Komdiagnostika.Views
{
    /// <summary>
    /// Логика взаимодействия для StoreView.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        public StoreView(IContainerProvider container)
        {
            InitializeComponent();
        }
    }
}
