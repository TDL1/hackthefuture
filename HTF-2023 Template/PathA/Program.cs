using Common;
using System.Net.Http.Json;
using System.Text;

namespace PathA
{
    public class Program
    {
        private readonly HackTheFutureClient _client;

        public Program()
        {
            _client = new HackTheFutureClient();
        }

        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.GetStart();
            await program.GetPostSample();
            await program.GetPostPuzzle();
        }

        async Task GetStart()
        {
            await _client.Login("ChatMT", "SzqvyB3meD");
            var response = await _client.GetAsync($"/api/path/a/easy/start");
            Console.WriteLine(response);
        }

        async Task GetPostSample()
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

        async Task GetPostPuzzle()
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

        string DecodeHieroglyphs(string hieroglyphs)
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