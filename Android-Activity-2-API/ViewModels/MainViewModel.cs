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
        // Collection to store the list of holidays
        public ObservableCollection<CanadaHoliday> Holidays { get; } = new();

        // Instance of the HolidayAPI service
        HolidayAPI holidayAPI;

        // Command to retrieve holidays
        public Command GetHolidaysCommand { get; }

        // Private field to store the value of the 'NameEn' property
        private string nameEn; 

        public string NameEn
        {
            // Getter for the 'NameEn' property
            get { return nameEn; }
            // Setter for the 'NameEn' property
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
            // Set the title of the view model
            Title = "Canada Holiday";

            // Assign the provided 'HolidayAPI' instance to the 'holidayAPI' field
            this.holidayAPI = holidayAPI;

            // Create a new command that calls the 'GetHolidayAsync' method when executed
            GetHolidaysCommand = new Command(async () => await GetHolidayAsync()); 
        }

        async Task GetHolidayAsync()
        {
            if (IsBusy)
                return;

            try
            {
                // Set the IsBusy flag to indicate that the operation is in progress
                IsBusy = true;

                // Retrieve holidays from the API
                var holidays = await holidayAPI.GetCanadaHolidaysAsync();

                // Clear the existing list of holidays
                Holidays.Clear();

                // Add each holiday to the collection
                foreach (var holiday in holidays)
                    Holidays.Add(holiday); 

                // Update the UI elements with the holiday data
                if (Holidays.Count > 0)
                {
                    var firstHoliday = Holidays[0];

                    // Update the NameEn property with the name of the first holiday
                    NameEn = firstHoliday.NameEn;

                    // Update the Date property with the date of the first holiday

                    // Update the IsFederal property with the federal status of the first holiday
                    Date = firstHoliday.Date;

                    // Update the ObservedDate property with the observed date of the first holiday
                    IsFederal = firstHoliday.IsFederal;

                    // Update the ObservedDate property with the observed date of the first holiday
                    ObservedDate = firstHoliday.ObservedDate; 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get holidays: {ex.Message}");
                // Display an error alert if an exception occurs
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK"); 
            }
            finally
            {
                // Reset the IsBusy flag
                IsBusy = false; 
            }
        }
    }
}
