using Komdiagnostika.ViewModels;
using Prism.Ioc;
using System.Windows;

namespace Komdiagnostika.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IContainerProvider container)
        {
            InitializeComponent();
        }
    }
}
