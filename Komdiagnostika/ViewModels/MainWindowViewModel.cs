using Komdiagnostika.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.Generic;

namespace Komdiagnostika.ViewModelss
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        public IList<StoreViewModel> _stores { get; private set; }
        public DelegateCommand<object[]> SelectedCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;

            _title = "Komdiagnostika";

            SelectedCommand = new DelegateCommand<object[]>(OnItemSelected);
        }

        private void OnItemSelected(object[] selectedItems)
        {
            //if (selectedItems != null && selectedItems.Count() > 0)
            //{
            //    SelectedItemText = selectedItems.FirstOrDefault().ToString();
            //}
        }
    }
}
