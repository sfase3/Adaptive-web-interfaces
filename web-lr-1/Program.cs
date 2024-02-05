namespace WEB_LR_1;
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        do
        {
            DisplayMenu();

            Console.Write("Оберіть варіант меню: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CountWords();
                        break;

                    case 2:
                        DoMath();
                        break;

                    case 0:
                        Console.WriteLine("poka!");
                        return;

                    default:
                        Console.WriteLine("Неправильний варіант");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неправильний варіант");
            }

            Console.WriteLine();
        } while (true);
    }


    static void DisplayMenu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine("0. Вихід");
        Console.WriteLine("1. Підрахувати кількість слів");
        Console.WriteLine("2. Випадковий математичний вираз");
    }

    // 1
    static void CountWords()
    {
        Console.Write("Введіть текст: ");
        string? userInput = Console.ReadLine();

        MatchCollection wordMatches = Regex.Matches(userInput, "[a-zA-Z0-9]");
        string[] wordsArray;

        if (wordMatches.Count() > 0)
        {
            wordsArray = userInput.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Кількість слів: {wordsArray.Length}");
            return;
        }

        string currentDirectoryPath = Directory.GetCurrentDirectory();
        string fileContent = File.ReadAllText(Path.Combine(currentDirectoryPath, "loremipsum.txt"));
        wordsArray = fileContent.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine($"Зміст файлу: {fileContent}");
        Console.WriteLine($"Кількість слів: {wordsArray.Length}");


    }

    // 2
    static void DoMath()
    {
        Console.Clear();

        Console.Write("Введіть математичний вираз: ");
        string text = Console.ReadLine();

        try
        {
            System.Data.DataTable table = new System.Data.DataTable();
            double result = Convert.ToDouble(table.Compute(text, string.Empty));
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
        Console.ReadKey();
    }
}
