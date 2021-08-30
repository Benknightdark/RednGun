using RedGunMVVM.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace RedGunMVVM.ViewModels
{
    public class RedGunViewModel
    {
        // 彈跳視窗Service
        public DialogService _dialogService => DependencyService.Get<DialogService>();

        // 頁面切換Service
        public NavigationService _navigationService => DependencyService.Get<NavigationService>();

        // Shell頁面切換Service
        public ShellService _shellService => DependencyService.Get<ShellService>();

        // 常用Service
        public CommonService _commonService => DependencyService.Get<CommonService>();

        public RedGunViewModel()
        {
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
    }
}