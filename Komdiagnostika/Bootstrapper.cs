using Komdiagnostika.ViewModelss;
using Komdiagnostika.Views;
using Prism.Ioc;
using System.Windows;

namespace Komdiagnostika
{
    public class Bootstrapsper : Prism.Unity.PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(DependencyObject shell)
        {
            base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<StoreViewModel>("StoreViewModel");
        }
    }
}
