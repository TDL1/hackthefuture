using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PathB
{
    public class B1
    {
        private HackTheFutureClient _httpClient;
        private string _password = "SzqvyB3meD";
        private string _teamName = "ChatMT";
        public B1()
        {
            _httpClient = new HackTheFutureClient();
            //_httpClient.Login(_teamName, _password);

            
        }
        public async Task GetAsync()
        {
            await _httpClient.Login(_teamName, _password);
            var response = await _httpClient.GetAsync($"/api/path/b/easy/start");
            Console.WriteLine(response);

        }
        public async Task GetSampleAsync()
        {
            await _httpClient.Login(_teamName, _password);
            var response = await _httpClient.GetStringAsync($"/api/path/b/easy/sample");
            var json = JsonConvert.DeserializeObject<MayanCalendarChallengeDto>(response);
            var startdate = json.StartDate;
            var enddate = json.EndDate;

            int difference = enddate.DayNumber - startdate.DayNumber;

            string Day = json.Day;
            int dayNumber = ((int)Enum.Parse(typeof(DayOfWeek), Day));

            int amountofoneweekday = (difference / 7);

            for (int i = 0; i < difference % 7; i++)
            {
                if (dayNumber == 2 || dayNumber == 3)
                {
                    amountofoneweekday += 1;
                }
                dayNumber = (dayNumber + 1) % 7;
            }
            var postresponse = await _httpClient.PostAsJsonAsync<int>($"/api/path/b/easy/sample", amountofoneweekday);
            var content = await postresponse.Content.ReadAsStringAsync();

            Console.WriteLine(content);




        }
        public async Task GetPuzzleAsync()
        {
            await _httpClient.Login(_teamName, _password);
            var response = await _httpClient.GetStringAsync($"/api/path/b/easy/puzzle");
            var json = JsonConvert.DeserializeObject<MayanCalendarChallengeDto>(response);
            var startdate = json.StartDate;
            var enddate = json.EndDate;

            int difference = enddate.DayNumber - startdate.DayNumber;

            string Day = json.Day;
            int dayNumber = ((int)Enum.Parse(typeof(DayOfWeek), Day));

            int amountofoneweekday = (difference / 7);

            for (int i = 0; i < difference % 7; i++)
            {
                if (dayNumber == 2 || dayNumber == 3)
                {
                    amountofoneweekday += 1;
                }
                dayNumber = (dayNumber + 1) % 7;
            }
            var postresponse = await _httpClient.PostAsJsonAsync<int>($"/api/path/b/easy/puzzle", amountofoneweekday);
            var content = await postresponse.Content.ReadAsStringAsync();

            Console.WriteLine(content);




        }
    }
}
