using System.Reflection;
using LR1.Services;

namespace LR1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string BaseApiUrl = "https://api.languagetool.org/v2";
            var client = new HttpClient();
            var apiClient = new ApiClient(client);

            // Приклад використання GET методу
            var textToCheck = "I hav a problem";
            var language = "en-US";
            var apiUrl = $"{BaseApiUrl}/check?text={textToCheck}&language={language}";
            var getResult = await apiClient.Get(apiUrl);

            if (getResult.HttpStatusCode == 200)
            {
                Console.WriteLine($"Message: {getResult.Message}");
                Console.WriteLine($"Status Code: {getResult.HttpStatusCode}");
                Console.WriteLine($"Data: {getResult.Data[0]}");
            }
            else
            {
                Console.WriteLine($"Error: {getResult.Message}");
            }

            // Приклад використання POST методу
            var postData = "text=I have a problem&language=en-US"; // Параметри для POST запиту
            var postUrl = $"{BaseApiUrl}/check";
            var postResult = await apiClient.Post(postUrl, postData);

            if (postResult.HttpStatusCode == 200)
            {
                Console.WriteLine($"Message: {postResult.Message}");
                Console.WriteLine($"Status Code: {postResult.HttpStatusCode}");
                Console.WriteLine($"Data: {postResult.Data[0]}");
            }
            else
            {
                Console.WriteLine($"Error: {postResult.Message}");
            }


            var languagesUrl = $"{BaseApiUrl}/languages";
            var languagesResult = await apiClient.Get(languagesUrl);

            if (languagesResult.HttpStatusCode == 200)
            {
                Console.WriteLine($"Message: {languagesResult.Message}");
                Console.WriteLine($"Status Code: {languagesResult.HttpStatusCode}");
                Console.WriteLine("Available languages:");
                foreach (var lang in languagesResult.Data)
                {
                    Console.WriteLine(lang);
                }
            }
            else
            {
                Console.WriteLine($"Error: {languagesResult.Message}");
            }

            // Виклик, що спричинить помилку з кодом 500
            var invalidUrl = $"{BaseApiUrl}/invalid_endpoint";
            var invalidResult = await apiClient.Get(invalidUrl);
            Console.WriteLine(invalidResult.HttpStatusCode);
            if (invalidResult.HttpStatusCode == 500)
            {
                Console.WriteLine($"Error: {invalidResult.Message}");
            }
            Console.ReadLine();
        }
    }
}