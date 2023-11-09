using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PathB
{
    public class B3
    {
        private HackTheFutureClient _httpClient;
        private string _password = "SzqvyB3meD";
        private string _teamName = "ChatMT";
        public B3()
        {
            _httpClient = new HackTheFutureClient();
        }
        public async Task GetAsync()
        {
            await _httpClient.Login(_teamName, _password);
            var response = await _httpClient.GetAsync($"/api/path/b/hard/start");
            Console.WriteLine(response);

        }
        public async Task GetSampleAsync()
        {
            await _httpClient.Login(_teamName, _password);
            var response = await _httpClient.GetStringAsync($"/api/path/b/hard/sample");
            var json = JsonConvert.DeserializeObject<string[]>(response);

            


            //var postresponse = await _httpClient.PostAsJsonAsync<string>($"/api/path/b/hard/sample", commonCharacters);
            //var content = await postresponse.Content.ReadAsStringAsync();
           



        }
    }
}
