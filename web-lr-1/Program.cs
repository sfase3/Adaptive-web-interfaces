using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        // 1 System.Collections
        DoCollection();

        // 2 Робота з датами використовуючи System.DateTime
        ManipulateDates();

        // 3 потоки з System.Threading
        PerformMultithreading();

        // 4 діагностика з System.Diagnostics
        ShowProcessInfo();

        // 5 інтернет операції з System.Net
         DownloadWebPage("https://uk.javascript.info/");
        Console.ReadLine();
    }

    // System.Collections
    static void DoCollection()
    {
        ArrayList list = new ArrayList();
        list.Add("Hello");
        list.Add("world");
        list.Add("its");
        list.Add("time");
        list.Add("to");
        list.Add("play");
        list.Add("with");
        list.Add("me");

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    // System.DateTime
    static void ManipulateDates()
    {
        DateTime currentDate = DateTime.Now;
        Console.WriteLine("Теперешня дата: " + currentDate);
        DateTime futureDate = currentDate.AddDays(12);
        Console.WriteLine("Дата через 12 днів: " + futureDate);
    }

    // System.Threading
    static void PerformMultithreading()
    {
        Thread myThread = new Thread(MyThreadMethod);
        myThread.Start();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Основний потік: {i}");
            Thread.Sleep(1000);
        }
    }

    static void MyThreadMethod()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Вторинний потік: {i}");
            Thread.Sleep(1500);
        }
    }

    // System.Diagnostics
    static void ShowProcessInfo()
    {
        Process currentProcess = Process.GetCurrentProcess();
        Console.WriteLine("Ідентифікатор процесу: " + currentProcess.Id);
        Console.WriteLine("Назва процесу: " + currentProcess.ProcessName);
    }

    // System.Net
    static void DownloadWebPage(string url)
    {
        using (System.Net.WebClient client = new System.Net.WebClient())
        {
            string content = client.DownloadString(url);
            Console.WriteLine("Веб сторінка складає: " + content.Length + " символів");
        }
    }
}
