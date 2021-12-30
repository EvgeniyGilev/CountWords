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
            char[] delimiters = new char[] {' ', '\r', '\n'};

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            Console.WriteLine(words.Length);
            
        }
    }
}