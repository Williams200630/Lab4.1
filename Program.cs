using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


namespace Lab4
{
    class Program
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Выберите задание для выполнения:");
                Console.WriteLine("1. Задание 1 ");
                Console.WriteLine("2. Задание 2 ");
                Console.WriteLine("3. Задание 3");
                Console.WriteLine("4. Задание 4");
                Console.WriteLine("5. Задание 5");
                Console.WriteLine("6. Задание 6");
                Console.WriteLine("7. Задание 7");
                Console.WriteLine("8. Задание 8");
                Console.WriteLine("9. Задание 9");
                Console.WriteLine("10. Задание 10");
                Console.WriteLine("0. Выход");
                Console.Write("Введите номер задания: ");

                string input = Console.ReadLine();
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RunTask1();
                            break;
                        case 2:
                            RunTask2();
                            break;
                        case 3:
                            RunTask3();
                            break;
                        case 4:
                            RunTask4();
                            break; // Добавлен break
                        case 5:
                            RunTask5();
                            break;
                        case 6:
                            RunTask6();
                            break;
                        case 7:
                            RunTask7();
                            break;
                        case 8:
                            RunTask8();
                            break;
                        case 9:
                            RunTask9();
                            break;
                        case 10:
                            RunTask10();
                            break;
                        case 0:
                            Console.WriteLine("Программа завершена.");
                            return; // Завершаем программу
                        default:
                            Console.WriteLine("Неверный номер задания. Пожалуйста, выберите один из предложенных.");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод, пожалуста введите число");
                }
                Console.WriteLine();
            }
        }

        static void RunTask1()
        {
            Console.WriteLine("Введите предложение, завершенное точкой:");
            string input = Console.ReadLine();
            if (input == null || !input.EndsWith("."))
            {
                Console.WriteLine("Ошибка: предложение должно заканчиваться точкой.");
                return;
            }
            // Первый способ: обработка строки как массива символов
            Console.WriteLine("Первый способ (обработка строки как массива символов):");
            FindUniqueCharactersUsingArray(input);
            // Второй способ: использование методов класса string
            Console.WriteLine("\nВторой способ (методы класса string):");
            FindUniqueCharactersUsingStringMethods(input);
        }
        static void FindUniqueCharactersUsingArray(string text)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (charCount.ContainsKey(c))
                    {
                        charCount[c]++;
                    }
                    else
                    {
                        charCount[c] = 1;
                    }
                }
            }

            // Вывод символов, которые встречаются ровно один раз
            foreach (var item in charCount)
            {
                if (item.Value == 1)
                {
                    Console.Write(item.Key + " ");
                }
            }
            Console.WriteLine();
        }
        // Способ 2: использование методов класса string 
        static void FindUniqueCharactersUsingStringMethods(string text)
        {
            var uniqueChars = text
                .Where(c => char.IsLetterOrDigit(c)) // Учитываем только буквы и цифры
                .GroupBy(c => c)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key);
            foreach (char c in uniqueChars)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
        static void RunTask2()

        {
            Console.WriteLine("Введите предложение, завершенное точкой:");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.EndsWith("."))
            {
                Console.WriteLine("Ошибка: предложение должно заканчиваться точкой.");
                return;
            }
            // Первый способ: обработка строки как массива символов
            Console.WriteLine("Первый способ (обработка строки как массива символов):");
            string resultUsingArray = FormatStringUsingArray(input);
            Console.WriteLine(resultUsingArray);
            // Второй способ: использование методов класса string
            Console.WriteLine("\nВторой способ (методы класса string):");
            string resultUsingStringMethods = FormatStringUsingStringMethods(input);
            Console.WriteLine(resultUsingStringMethods);
        }
        // Способ 1: обработка строки как массива символов
        static string FormatStringUsingArray(string text)
        {
            StringBuilder result = new StringBuilder();
            int wordCount = 0;
            bool inWord = false;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetterOrDigit(c))
                {
                    if (!inWord)
                    {
                        wordCount++;
                        inWord = true;
                    }
                    result.Append(c);
                }
                else
                {
                    if (inWord)
                    {
                        result.Append($"({wordCount})");
                        inWord = false;
                    }
                    result.Append(c);
                }
            }

            if (inWord)  // Обработка последнего слова
            {
                result.Append($"({wordCount})");
            }

            return result.ToString();
        }
        // Способ 2: использование методов класса string
        static string FormatStringUsingStringMethods(string text)
        {
            string textWithoutPeriod = text.TrimEnd('.');
            string[] words = Regex.Split(textWithoutPeriod, @"[\s.,-]+");
            StringBuilder result = new StringBuilder();
            int wordCount = 0;

            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word) && Regex.IsMatch(word, @"\w+"))
                {
                    wordCount++;
                    result.Append($"{word}({wordCount})");
                }
            }

            result.Append("."); // Восстанавливаем точку в конце предложения
            return result.ToString();
        }
        static void RunTask3()
        {
            Console.WriteLine("Введите текст из нескольких слов, завершенный точкой:");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !input.EndsWith("."))
            {
                Console.WriteLine("Ошибка: текст должен заканчиваться точкой.");
                return;
            }
            // Первый способ: обработка строки как массива символов
            Console.WriteLine("Первый способ (обработка строки как массива символов):");
            string reversedUsingArray = ReverseWordsUsingArray(input);
            Console.WriteLine(reversedUsingArray);
            // Второй способ: использование классов string и StringBuilder
            Console.WriteLine("\nВторой способ (классы string и StringBuilder):");
            string reversedUsingStringBuilder = ReverseWordsUsingStringBuilder(input);
            Console.WriteLine(reversedUsingStringBuilder);
        }
        // Способ 1: обработка строки как массива символов 
        static string ReverseWordsUsingArray(string text)
        {
            text = text.TrimEnd(); // Убираем точку, чтоби не мешала разбиению на слова
            char[] charArray = text.ToCharArray();
            StringBuilder word = new StringBuilder();
            StringBuilder result = new StringBuilder();
            var words = new System.Collections.Generic.List<string>();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] != ' ')
                {
                    word.Append(charArray[i]); // добавляем символ к слову
                }
                else if (word.Length > 0)
                {
                    words.Add(word.ToString()); // добавляем слово в список
                    word.Clear(); // очищаем StringBuilder для следующего слова
                }
            }
            if (word.Length > 0)
            {
                words.Add(word.ToString()); // добавляем последнее слово
            }
            for (int i = words.Count - 1; i >= 0; i--)
            {
                result.Append(words[i]);
                if (i != 0)
                {
                    result.Append(" ");
                }
            }
            result.Append("."); //добавляем точку в конце
            return result.ToString();
        }
        // Способ 2: использование классов string и StringBuilder
        static string ReverseWordsUsingStringBuilder(string text)
        {
            text = text.TrimEnd('.');
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            for (int i = words.Length - 1; i >= 0; i--)
            {
                result.Append(words[i]);
                if (i > 0)
                {
                    result.Append(" ");
                }
            }
            result.Append(".");
            return result.ToString();
        }
        static void RunTask4()
        {
            Console.WriteLine("Введите 7 строк текста:");
            string[] lines = new string[7];
            for (int i = 0; i < 7; i++)
            {
                lines[i] = Console.ReadLine();
            }
            // Первый способ: обработка строки как массива символов
            Console.WriteLine("\nПервый способ (обработка строки как массива символов):");
            FindLinesWithComAndMinSpacesUsingArray(lines);
            // Второй способ: использование методов класса string
            Console.WriteLine("\nВторой способ (методы класса string):");
            FindLinesWithComAndMinSpacesUsingStringMethods(lines);
        }
        // способ 1:обработка строки как массива символов
        static void FindLinesWithComAndMinSpacesUsingArray(string[] lines)
        {
            int minSpacesIndex = -1;
            int minSpaceCount = int.MaxValue;
            Console.WriteLine("Строки, содержащие хотя бы одно слово, оканчивающееся на .com: ");

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                bool hasComWord = false;
                int spaceCount = 0;

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == ' ')
                    {
                        spaceCount++;
                    }

                    if (j >= 3 && j < line.Length && line[j - 3] == '.' && line.Substring(j - 2, 3).ToLower() == "com")
                    {
                        hasComWord = true;
                    }


                }
                if (hasComWord)
                {
                    Console.WriteLine(line);
                }
                if (spaceCount < minSpaceCount)
                {
                    minSpaceCount = spaceCount;
                    minSpacesIndex = i;
                }
            }


            Console.WriteLine($"Номер строки с наименьшим числом пробелов: {minSpacesIndex + 1}");
        }

        // Способ 2: использование методов класса string
        static void FindLinesWithComAndMinSpacesUsingStringMethods(string[] lines)
        {
            int minSpacesIndex = -1;
            int minSpaceCount = int.MaxValue;
            Console.WriteLine("Строки, содержащие хотя бы одно слово, оканчивающееся на .com:");

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (Regex.IsMatch(line, @"\b\w+\.com\b", RegexOptions.IgnoreCase))
                {
                    Console.WriteLine(line);
                }

                int spaceCount = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;
                if (spaceCount < minSpaceCount)
                {
                    minSpaceCount = spaceCount;
                    minSpacesIndex = i;
                }

            }

            Console.WriteLine($"Номер строки с наименьшим числом пробелов: {minSpacesIndex + 1}");
        }
        static void RunTask5()
        {
            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();
            // Первый способ: обработка строки как массива символов
            Console.WriteLine("\nПервый способ (обработка строки как массива символов):");
            FindWordsUsingArray(input);
            // Второй способ: использование регулярных выражений
            Console.WriteLine("\nВторой способ (использование регулярных выражений):");
            FindWordsUsingRegex(input);
        }
        // способ 1: обработка строки как массива символов
        static void FindWordsUsingArray(string text)
        {
            var words = new System.Collections.Generic.List<string>();
            StringBuilder word = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetterOrDigit(c))
                {
                    word.Append(c);
                }
                else
                {
                    // Проверка слова, если слово завершено
                    if (word.Length > 0 && IsValidWord(word.ToString()))
                    {
                        words.Add(word.ToString());
                    }
                    word.Clear();
                }
            }
            // Проверка последнего слова в строке
            if (word.Length > 0 && IsValidWord(word.ToString()))
            {
                words.Add(word.ToString());
            }

            Console.WriteLine("Найденные слова: ");
            foreach (var foundWord in words)
            {
                Console.WriteLine(foundWord);
            }
        }

        // способ 2: использование регулярных выражений
        static void FindWordsUsingRegex(string text)
        {
            // Регулярное выражение: слово, начинающееся с заглавной латинской буквы и заканчивается двумя цифрами
            string pattern = @"\b[A-Z][a-zA-Z]*\d{2}\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            Console.WriteLine("Найденные слова: ");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }

        // Вспомогательный метод для проверки слов
        static bool IsValidWord(string word)
        {
            if (word.Length >= 3 &&
                char.IsUpper(word[0]) &&
                char.IsDigit(word[^1]) &&
                char.IsDigit(word[^2]))
            {
                return true;
            }
            return false;
        }
        static void RunTask6()
        {
            Console.WriteLine("Введите выражение вида 'число + число = число' (с пробелами, возможны отрицательнные числа):");
            string input = Console.ReadLine();
            /* 
             Шаблон регулярного выражения: \s*(-?\d+)\s*\+\s*(-?\d+)\s*=\s*(-?\d+)\s*
             \s* - произвольное количество пробелов.
            (-?\d+) - число, которое может быть отрицательным (опциональный - перед одной или более цифрами \d+)
            \+ и = - символы + и =, между которыми могут быть пробелы.
            Этот шаблон позволяет выделить два операнда и результат, независимо от количества пробелов между ними.
            */
            // Регулярное выражение для парсинга строки
            string pattern = @"\s*(-?\d+)\s*\+\s*(-?\d+)\s*=\s*(-?\d+)\s*";
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                // Преобразование найденных значений в целые числа
                int operand1 = int.Parse(match.Groups[1].Value);
                int operand2 = int.Parse(match.Groups[2].Value);
                int result = int.Parse(match.Groups[3].Value);
                // Вывод переменных
                Console.WriteLine($"Первое число: {operand1}");
                Console.WriteLine($"Второе число: {operand2}");
                Console.WriteLine($"Результат: {result}");
                //Проверка корректности суммы
                if (operand1 + operand2 == result)
                {
                    Console.WriteLine("Сумма правильная.");
                }
                else
                {
                    Console.WriteLine("Ошибка: сумма неверна.");
                }
            }
        }
        static void RunTask7()
        {
            string[] tracklist = {
            "Gentle Giant – Free Hand [6:15]",
            "Supertramp – Child Of Vision [07:27]",
            "Camel – Lawrence [10:46]",
            "Yes – Don’t Kill The Whale [3:55]",
            "10CC – Notell Hotel [04:58]",
            "Nektar – King Of Twilight [4:16]",
            "The Flower Kings – Monsters & Men [21:19]",
            "Focus – Le Clochard [1:59]",
            "Pendragon – Fallen Dream And Angel [5:23]",
             "Kaipa – Remains Of The Day (08:02)"
        };

            List<Track> tracks = new List<Track>();
            int totalDuration = 0;

            // Регулярное выражение для поиска продолжительности трека
            string pattern = @"\[(\d+):(\d+)\]|\((\d+):(\d+)\)";

            foreach (string line in tracklist)
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    // Извлекаем минуты и секунды
                    int minutes = int.Parse(match.Groups[1].Value != "" ? match.Groups[1].Value : match.Groups[3].Value);
                    int seconds = int.Parse(match.Groups[2].Value != "" ? match.Groups[2].Value : match.Groups[4].Value);

                    // Рассчитываем продолжительность трека в секундах
                    int durationInSeconds = minutes * 60 + seconds;
                    totalDuration += durationInSeconds;

                    // Добавляем трек в список
                    tracks.Add(new Track(line, durationInSeconds));
                }
            }
            // Находим самый длинный и самый короткий трек
            Track longestTrack = null;
            Track shortestTrack = null;
            foreach (Track track in tracks)
            {
                if (longestTrack == null || track.DurationInSeconds > longestTrack.DurationInSeconds)
                {
                    longestTrack = track;
                }
                if (shortestTrack == null || track.DurationInSeconds < shortestTrack.DurationInSeconds)
                {
                    shortestTrack = track;
                }
            }

            // Поиск пары с минимальной разницей во времени звучания
            Track minDiffTrack1 = null;
            Track minDiffTrack2 = null;
            int minDifference = int.MaxValue;
            for (int i = 0; i < tracks.Count; i++)
            {
                for (int j = i + 1; j < tracks.Count; j++)
                {
                    int difference = Math.Abs(tracks[i].DurationInSeconds - tracks[j].DurationInSeconds);
                    if (difference < minDifference)
                    {
                        minDifference = difference;
                        minDiffTrack1 = tracks[i];
                        minDiffTrack2 = tracks[j];
                    }
                }
            }

            // Вывод результатов
            Console.WriteLine("Общее время звучания всех песен: " + FormatTime(totalDuration));
            Console.WriteLine("Самая длинная песня: " + longestTrack.Title + " (" + FormatTime(longestTrack.DurationInSeconds) + ")");
            Console.WriteLine("Самая короткая песня: " + shortestTrack.Title + " (" + FormatTime(shortestTrack.DurationInSeconds) + ")");
            Console.WriteLine("Пара песен с минимальной разницей во времени звучания:");
            Console.WriteLine($"1. {minDiffTrack1.Title} ({FormatTime(minDiffTrack1.DurationInSeconds)})");
            Console.WriteLine($"2. {minDiffTrack2.Title} ({FormatTime(minDiffTrack2.DurationInSeconds)})");
            Console.WriteLine("Разница во времени: " + FormatTime(minDifference));
        }

        public class Track
        {
            public string Title { get; set; }
            public int DurationInSeconds { get; set; }

            public Track(string title, int durationInSeconds)
            {
                Title = title;
                DurationInSeconds = durationInSeconds;
            }
        }
        // Метод для форматирования времени в формате "мин:сек" 
        public static string FormatTime(int totalSeconds) // Первое определение
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
        static void RunTask8()
        {
            Console.WriteLine("Введите текст для шифрования/дешифрования:");
            string input = Console.ReadLine();
            string encryptedText = EncryptAtbash(input);
            Console.WriteLine("Зашифрованный текст (Атбаш): " + encryptedText);
            string decryptedText = EncryptAtbash(encryptedText); //Атбаш симметричен, поэтому используем ту же формулу
            Console.WriteLine("Расвифрованный текст (Атбаш): " + decryptedText);
        }
        public static string EncryptAtbash(string text)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        // Обработка заглавных латинских символов
                        result.Append((char)('A' + ('Z' - c)));
                    }
                    else if (char.IsLower(c))
                    {
                        // Обработка строчных латинских символов
                        result.Append((char)('a' + ('z' - c)));
                    }
                    else if (c >= 'А' && c <= 'Я')
                    {
                        // Обработка заглавных кириллических символов
                        result.Append((char)('А' + ('Я' - c)));
                    }
                    else if (c >= 'а' && c <= 'я')
                    {
                        // Обработка строчных кириллических символов
                        result.Append((char)('а' + ('я' - c)));
                    }
                }
                else
                {
                    // Для остальных символов добавляем символ без изменений
                    result.Append(c);
                }
            }
            return result.ToString(); // Возвращаем зашифрованный текст
        }
        static void RunTask9()
        {
            Console.WriteLine("Введите текст: ");
            string input = Console.ReadLine();

            // Первый способ: обработка строки как массива символов 
            string resultByArray = RemoveWordsByArrayMethod(input);
            Console.WriteLine("Результат (через массив строк): ");
            Console.WriteLine(resultByArray);

            // Второй способ: использование String и StringBuilder
            string resultByStringMethods = RemoveWordsByStringMethod(input);
            Console.WriteLine("Результат (через String и StringBuilder): ");
            Console.WriteLine(resultByStringMethods);
        }

        // Первый способ: Обработка строки как массива символов 
        protected static string RemoveWordsByArrayMethod(string text)
        {
            StringBuilder result = new StringBuilder();
            string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    char firstChar = char.ToLower(word[0]);
                    char lastChar = char.ToLower(word[word.Length - 1]);
                    if (firstChar != lastChar)
                    {
                        result.Append(word).Append(" ");
                    }
                }
            }
            return result.ToString().Trim();
        }


        // Второй способ: Использование String и StringBuilder
        protected static string RemoveWordsByStringMethod(string text)
        {
            StringBuilder result = new StringBuilder();
            string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    if (char.ToLower(word[0]) != char.ToLower(word[word.Length - 1]))
                    {
                        result.Append(word).Append(" ");
                    }
                }
            }
            return result.ToString().Trim();
        }
        static void RunTask10()
        {
            Console.WriteLine("Введите текст для поиска дат:");
            string input = Console.ReadLine();
            // Регулярное выражение для поиска дат в формате "дд-ми-гггг" 
            string datePattern = @"\b(\d{2})-(\d{2})-(\d{4})\b";
            // Поиск всех дат, подходящих под шаблон
            MatchCollection matches = Regex.Matches(input, datePattern);
            Console.WriteLine("Найденные даты:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
            // Вывод общего количества найденных дат
            Console.WriteLine($"Всего найдено дат: {matches.Count}");
        }
    }
}






































































