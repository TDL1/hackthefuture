using Common;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PathB
{
    public class B2
    {
        private HackTheFutureClient _httpClient;
        private string _password = "SzqvyB3meD";
        private string _teamName = "ChatMT";
        public B2()
        {
            _httpClient = new HackTheFutureClient();
        }
        public async Task GetAsync()
        {
            await _httpClient.Login(_teamName, _password);
            var response = await _httpClient.GetAsync($"/api/path/b/medium/start");
            Console.WriteLine(response);

        }
        //char[] _characters = { 'Ⰰ', 'Ⰱ', 'Ⰲ', 'Ⰳ', 'Ⰴ', 'Ⱑ', 'Ⰵ', 'Ⰶ', 'Ⰷ', 'Ⰸ', 'Ⰹ', 'Ⰺ', 'Ⰻ', 'Ⰽ','Ⰾ'
        //        , 'Ⰿ', 'Ⱁ', 'Ⱅ', 'Ⱆ', 'Ⱈ', 'Ⱉ', 'Ⱊ', 'Ⱋ', 'Ⱌ', 'Ⱍ', 'Ⱏ' };

        static string FindCommonCharacters(string[] stringArray)
        {
           


            HashSet<char> commonCharacters = new HashSet<char>(stringArray[0]);

            foreach (string s in stringArray)
            {

                commonCharacters.IntersectWith(s);
            }

            List<char>commons = commonCharacters.ToList();
            List <char> noDupes = commons.Distinct().ToList();
            return new string(noDupes.ToArray());
        }
        public async Task GetSampleAsync()
        {
            await _httpClient.Login(_teamName, _password);
            var response = await _httpClient.GetStringAsync($"/api/path/b/medium/sample");
            var json = JsonConvert.DeserializeObject <string[]>(response);
           
            string commonCharacters = FindCommonCharacters(json);
      
                    
            var postresponse = await _httpClient.PostAsJsonAsync<string>($"/api/path/b/medium/sample", commonCharacters);
            var content = await postresponse.Content.ReadAsStringAsync();
            Console.WriteLine(content);



        }
        public async Task GetPuzzleAsync()
        {
            await _httpClient.Login(_teamName, _password);
            var response = await _httpClient.GetStringAsync($"/api/path/b/medium/puzzle");
            var json = JsonConvert.DeserializeObject<string[]>(response);

            string commonCharacters = FindCommonCharacters(json);


            var postresponse = await _httpClient.PostAsJsonAsync<string>($"/api/path/b/medium/puzzle", commonCharacters);
            var content = await postresponse.Content.ReadAsStringAsync();
            Console.WriteLine(content);



        }
    }
      

        
      
    }

