using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Android_Activity_2_API.Model;
using Android_Activity_2_API.Service;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Android_Activity_2_API.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public ObservableCollection<CanadaHoliday> Holidays { get; } = new();
        HolidayAPI holidayAPI;
        public Command GetHolidaysCommand { get; }

        private string nameEn;
        public string NameEn
        {
            get { return nameEn; }
            set { SetProperty(ref nameEn, value); }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        private bool isFederal;
        public bool IsFederal
        {
            get { return isFederal; }
            set { SetProperty(ref isFederal, value); }
        }

        private string observedDate;
        public string ObservedDate
        {
            get { return observedDate; }
            set { SetProperty(ref observedDate, value); }
        }

        public MainViewModel(HolidayAPI holidayAPI)
        {
            Title = "Canada Holiday";
            this.holidayAPI = holidayAPI;
            GetHolidaysCommand = new Command(async () => await GetHolidayAsync());
        }

        async Task GetHolidayAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var holidays = await holidayAPI.GetCanadaHolidaysAsync();

                Holidays.Clear();
                foreach (var holiday in holidays)
                    Holidays.Add(holiday);

                // Update the UI elements with the holiday data
                if (Holidays.Count > 0)
                {
                    var firstHoliday = Holidays[0];
                    NameEn = firstHoliday.NameEn;
                    Date = firstHoliday.Date;
                    IsFederal = firstHoliday.IsFederal;
                    ObservedDate = firstHoliday.ObservedDate;
                    // Update other UI elements with relevant properties
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get holidays: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}