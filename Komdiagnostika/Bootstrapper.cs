using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Common;
using DAL.Repository;
using Komdiagnostika.ViewModels;
using Komdiagnostika.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using System;
using System.Configuration;
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
            containerRegistry.RegisterDialog<StoreView, StoreViewModel>();

            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                var options = optionsBuilder
                    .UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
                    .Options;
                containerRegistry.RegisterInstance(optionsBuilder.Options);
                containerRegistry.Register<IStoreService>(() => new StoreService(new StoreRepository(new AppDbContext(options)))); 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
