using Prism.Mvvm;

namespace Komdiagnostika.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {
        protected string _title = "";
        public string Title
        {
            get => _title;
            set { SetProperty(ref _title, value); }
        }

    }
}
