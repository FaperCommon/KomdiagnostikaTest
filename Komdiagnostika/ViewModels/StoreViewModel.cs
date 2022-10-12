using Komdiagnostika.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;
using System;

namespace Komdiagnostika.ViewModels
{
    public class StoreViewModel : BaseDialogViewModel
    {
        private IEventAggregator _eventAggregator;
        private StoreModel _store;

        public string Name
        {
            get => _store.Name;
            set
            {
                _store.Name = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string Author
        {
            get => _store.Author;
            set
            {
                _store.Author = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public int Year
        {
            get => _store.Year;
            set
            {
                _store.Year = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string ISBN
        {
            get => _store.ISBN;
            set
            {
                _store.ISBN = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string Img
        {
            get => _store.Img;
            set
            {
                _store.Img = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
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

        public DelegateCommand SaveCommand { get; set; }

        public StoreViewModel(IEventAggregator eventAggregator) : base()
        {
            _eventAggregator = eventAggregator;

            Title = "Store";

            SaveCommand = new DelegateCommand(Save, CanSave);
        }

        private void Save()
        {
            DialogResult result = new DialogResult();
            result.Parameters.Add("isSuccess", true);
            RaiseRequestClose(result);
        }

        //just a joke
        public const int FirstYearBook = 868;

        private bool CanSave()
        {
            return !String.IsNullOrWhiteSpace(Name) &&
                !String.IsNullOrWhiteSpace(Author) &&
                !String.IsNullOrWhiteSpace(ISBN) &&
                !String.IsNullOrWhiteSpace(Img) &&
                Year >= FirstYearBook;
        }

        #region IDialogAware

        public override void OnDialogClosed()
        {
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            _dialogParametres = parameters;
            _store = parameters.GetValue<StoreModel>("Store");
        }

        #endregion
    }
}
