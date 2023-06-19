using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Android_Activity_2_API.ViewModels
{
	public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
    }
}

