using Common;
using System.Net.Http.Json;
using System.Text;

namespace PathA
{
    public class A1
    {
        private readonly HackTheFutureClient _client;

        public A1()
        {
            _client = new HackTheFutureClient();
        }

        public async Task GetStart()
        {
            await _client.Login("ChatMT", "SzqvyB3meD");
            var response = await _client.GetAsync($"/api/path/a/easy/start");
            Console.WriteLine(response);
        }

        public async Task GetPostSample()
        {
            await _client.Login("ChatMT", "SzqvyB3meD");
            var response = await _client.GetAsync($"/api/path/a/easy/sample");
            Console.WriteLine(response);
            var hieroglyhs = await response.Content.ReadAsStringAsync();
            var decodedGlyphs = DecodeHieroglyphs(hieroglyhs);
            var postResponse = await _client.PostAsJsonAsync($"/api/path/a/easy/sample", decodedGlyphs);
            var content = await postResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Decoded Hieroglyphs: " + content);
        }

        public async Task GetPostPuzzle()
        {
            await _client.Login("ChatMT", "SzqvyB3meD");
            var response = await _client.GetAsync($"/api/path/a/easy/puzzle");
            Console.WriteLine(response);
            var hieroglyhs = await response.Content.ReadAsStringAsync();
            var decodedGlyphs = DecodeHieroglyphs(hieroglyhs);
            var postResponse = await _client.PostAsJsonAsync($"/api/path/a/easy/puzzle", decodedGlyphs);
            var content = await postResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Decoded Hieroglyphs: " + content);
        }

        private string DecodeHieroglyphs(string hieroglyphs)
        {
            StringBuilder decodedMessage = new StringBuilder();
            foreach (char hieroglyph in hieroglyphs)
            {
                if (HieroglyphAlphabet.Characters.ContainsKey(hieroglyph))
                {
                    decodedMessage.Append(HieroglyphAlphabet.Characters[hieroglyph]);
                }
                else
                {
                    decodedMessage.Append(hieroglyph);
                }
            }

            return decodedMessage.ToString();
        }
    }
}
