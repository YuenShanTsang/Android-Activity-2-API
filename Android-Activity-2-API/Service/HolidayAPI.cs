using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Android_Activity_2_API.Model;

namespace Android_Activity_2_API.Service
{
    public class HolidayAPI
    {
        HttpClient httpClient;

        public HolidayAPI()
        {
            this.httpClient = new HttpClient();
        }

        List<CanadaHoliday> HolidayList;

        public async Task<List<CanadaHoliday>> GetCanadaHolidaysAsync()
        {
            Console.WriteLine("Holiday Service is working");
            if (HolidayList?.Count > 0)
                return HolidayList;

            // API Endpoint
            var response = await httpClient.GetAsync("https://canada-holidays.ca/api/v1/holidays?year=2022&optional=false");

            if (response.IsSuccessStatusCode)
            {
                var holiday = await response.Content.ReadFromJsonAsync<Holiday>();
                HolidayList = holiday.holidays.ToList();
            }
            Console.WriteLine("Holiday List Size " + HolidayList.Count.ToString());


            return HolidayList;
        }

    }
}