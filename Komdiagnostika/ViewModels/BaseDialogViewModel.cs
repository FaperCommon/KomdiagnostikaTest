using Prism.Services.Dialogs;
using System;

namespace Komdiagnostika.ViewModels
{
    public class BaseDialogViewModel : BaseViewModel, IDialogAware
    {
        protected IDialogParameters _dialogParametres;
        public event Action<IDialogResult> RequestClose;

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
