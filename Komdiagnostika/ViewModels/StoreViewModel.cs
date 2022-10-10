using DAL.Entities;
using Komdiagnostika.ViewModels;
using Prism.Events;

namespace Komdiagnostika.ViewModelss
{
    public class StoreViewModel : BaseViewModel
    {
        private IEventAggregator _eventAggregator;
        private Store _store;

        public StoreViewModel(Store store, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _store = store;

            _title = "Store";
        }

        public string Name
        {
            get => _store.Name;
            set
            {
                _store.Name = value;
                RaisePropertyChanged();
            }
        }

        public string Author
        {
            get => _store.Author;
            set
            {
                _store.Author = value;
                RaisePropertyChanged();
            }
        }

        public int Year
        {
            get => _store.Year;
            set
            {
                _store.Year = value;
                RaisePropertyChanged();
            }
        }

        public string ISBN
        {
            get => _store.ISBN;
            set
            {
                _store.ISBN = value;
                RaisePropertyChanged();
            }
        }

        public string Img
        {
            get => _store.Img;
            set
            {
                _store.Img = value;
                RaisePropertyChanged();
            }
        }

        public string Desc
        {
            get => _store.Desc;
            set
            {
                _store.Desc = value;
                RaisePropertyChanged();
            }
        }
    }
}
