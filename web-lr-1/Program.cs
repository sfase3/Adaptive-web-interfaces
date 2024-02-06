using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Виклик методів для роботи з класом Thread
        ThreadExample();

        // Виклик методів для роботи з Async - Await
        await AsyncAwaitExample();

        // Виклик асинхронного методу з використанням GetAsync
        await GetAsyncExample();

        Console.ReadLine();
    }

    // Приклад роботи з класом Thread
    static void ThreadExample()
    {
        Console.WriteLine("Початок роботи з класом Thread");

        Thread thread1 = new Thread(ThreadMethod1);
        Thread thread2 = new Thread(ThreadMethod2);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Завершено роботу з класом Thread");
    }

    static void ThreadMethod1()
    {
        Console.WriteLine("ThreadMethod1 почав виконання");
        Thread.Sleep(3000);
        Console.WriteLine("ThreadMethod1 завершив виконання");
    }

    static void ThreadMethod2()
    {
        Console.WriteLine("ThreadMethod2 почав виконання");
        Thread.Sleep(2000);
        Console.WriteLine("ThreadMethod2 завершив виконання");
    }

    // Приклад роботи з Async - Await
    static async Task AsyncAwaitExample()
    {
        Console.WriteLine("Початок роботи з Async - Await");

        Console.WriteLine("Виклик асинхронного методу 1");
        await AsyncMethod1();

        Console.WriteLine("Виклик асинхронного методу 2");
        await AsyncMethod2();

        Console.WriteLine("Завершено роботу з Async - Await");
    }

    static async Task AsyncMethod1()
    {
        Console.WriteLine("AsyncMethod1 почав виконання");
        await Task.Delay(3000);
        Console.WriteLine("AsyncMethod1 завершив виконання");
    }

    static async Task AsyncMethod2()
    {
        Console.WriteLine("AsyncMethod2 почав виконання");
        await Task.Delay(2000);
        Console.WriteLine("AsyncMethod2 завершив виконання");
    }

    // Приклад роботи з GetAsync
    static async Task GetAsyncExample()
    {
        Console.WriteLine("Початок роботи з GetAsync");

        string url = "https://jsonplaceholder.typicode.com/todos/1";
        string result = await GetAsync(url);

        Console.WriteLine($"Отримані дані: {result}");

        Console.WriteLine("Завершено роботу з GetAsync");
    }

    // Асинхронний метод для отримання даних за допомогою HttpClient
    static async Task<string> GetAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"Помилка отримання даних. Код статусу: {response.StatusCode}";
            }
        }
    }
}
