using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\Stanislav\Desktop\Text1.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        string text = File.ReadAllText(filePath);
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        char[] separators = { ' ', '\n', '\r', '\t' };
        string[] words = noPunctuationText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
        foreach (string word in words)
        {
            string lowercaseWord = word.ToLower(); // нижний регистр, чтобы не разделять одинаковые слова, у которых первая буква отличается только регистром
            if (wordFrequency.ContainsKey(lowercaseWord))
            {
                wordFrequency[lowercaseWord]++;  // увеличиваем значение по ключу если уже встречалось, а если нет, то присваиваем 1 и так для каждого слова
            }
            else
            {
                wordFrequency[lowercaseWord] = 1;
            }
        }

        // Сортировка по убыванию
        var sortedWordFrequency = wordFrequency.OrderByDescending(pair => pair.Value);

        Console.WriteLine("Топ 10 наиболее часто встречаемых слов:");

        int count = 0;
        foreach (var entry in sortedWordFrequency)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} раз");
            count++;

            if (count == 10)
                break;
        }
        Console.ReadKey();
    }
}
