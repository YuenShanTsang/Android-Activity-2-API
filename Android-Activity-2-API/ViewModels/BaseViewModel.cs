using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Android_Activity_2_API.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        // Notifies property change for the computed property IsNotBusy
        [NotifyPropertyChangedFor(nameof(IsNotBusy))] 
        bool isBusy;

        [ObservableProperty]
        string title;

        // Computed property that returns the negation of IsBusy
        public bool IsNotBusy => !IsBusy; 

    }
}
