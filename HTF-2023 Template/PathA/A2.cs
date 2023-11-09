using Common;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace PathA
{
    public class A2
    {
        private readonly HackTheFutureClient _client;

        public A2()
        {
            _client = new HackTheFutureClient();
        }

        public async Task GetStart()
        {
            await _client.Login("ChatMT", "SzqvyB3meD");
            var response = await _client.GetAsync($"/api/path/a/medium/start");
            Console.WriteLine(response);
        }

        public async Task GetPostSample()
        {
            await _client.Login("ChatMT", "SzqvyB3meD");
            var response = await _client.GetAsync($"/api/path/a/medium/sample");
            var stringResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(stringResponse);

            var puzzleInfo = JsonConvert.DeserializeObject<PuzzleInfo>(stringResponse);

            var finalCoordinates = GetFinalCoordinates(puzzleInfo.Start, puzzleInfo.Directions, puzzleInfo.AmountOfVines);
            Console.WriteLine($"Final Coordinates: {finalCoordinates}");

            var postResponse = await _client.PostAsJsonAsync($"/api/path/a/medium/sample", finalCoordinates);
            var content = await postResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Result: " + content);
        }
        public async Task GetPostPuzzle()
        {
            await _client.Login("ChatMT", "SzqvyB3meD");
            var response = await _client.GetAsync($"/api/path/a/medium/puzzle");
            var stringResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine(stringResponse);

            var puzzleInfo = JsonConvert.DeserializeObject<PuzzleInfo>(stringResponse);

            var finalCoordinates = GetFinalCoordinates(puzzleInfo.Start, puzzleInfo.Directions, puzzleInfo.AmountOfVines);
            Console.WriteLine($"Final Coordinates: {finalCoordinates}");

            var postResponse = await _client.PostAsJsonAsync($"/api/path/a/medium/puzzle", finalCoordinates);
            var content = await postResponse.Content.ReadAsStringAsync();
            Console.WriteLine("Result: " + content);
        }

        public string GetFinalCoordinates(string start, List<string> directions, int gridSideLength)
        {
            var startCoordinates = start.Split(',');

            var x = int.Parse(startCoordinates[0]);
            var y = int.Parse(startCoordinates[1]);

            foreach (var direction in directions)
            {
                int newX = x;
                int newY = y;

                switch (direction)
                {
                    case "U":
                        newY++;
                        break;
                    case "D":
                        newY--;
                        break;
                    case "L":
                        newX--;
                        break;
                    case "R":
                        newX++;
                        break;
                    case "UL":
                        newX--;
                        newY++;
                        break;
                    case "UR":
                        newX++;
                        newY++;
                        break;
                    case "DL":
                        newX--;
                        newY--;
                        break;
                    case "DR":
                        newX++;
                        newY--;
                        break;
                    default:
                        break;
                }

                if (newX >= 0 && newX < gridSideLength && newY >= 0 && newY < gridSideLength)
                {
                    x = newX;
                    y = newY;
                }
            }

            return $"{x},{y}";
        }

    }
}
