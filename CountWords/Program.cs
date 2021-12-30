using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText(@"C:\temp1\Text1.txt");

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // выводим количество
            Console.WriteLine("Количество слов в тексте: " + words.Length);

            //создаем словарь
            Dictionary<string, int> dictionaryWords =
                new Dictionary<string, int>();

            //заполняем словарь
            foreach (var word in words)
            {
                if (!dictionaryWords.ContainsKey(word))
                {
                    dictionaryWords.Add(word, 1);
                }
                else
                {
                    dictionaryWords[word]++;
                }
            }

            Console.WriteLine("10 самых встречающихся слов");

            //используем сортировку
            foreach (var pair in dictionaryWords.OrderByDescending(pair => pair.Value).Take(10))
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}