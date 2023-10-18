Console.WriteLine("Введіть текстовий рядок:");
string inputText = Console.ReadLine();

// Розділити текст на слова та підрахувати кількість різних слів
string[] words = inputText.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
int uniqueWordsCount = words.Distinct().Count();

Console.WriteLine($"Кількість різних слів: {uniqueWordsCount}");

// Підрахувати кількість використаних символів
int usedCharactersCount = inputText.Replace(" ", "").Length;
Console.WriteLine($"Кількість використаних символів: {usedCharactersCount}");

// Видалити слова з подвоєними літерами
string[] wordsWithoutDuplicates = RemoveWordsWithDuplicates(words);
string cleanedText = string.Join(" ", wordsWithoutDuplicates);

Console.WriteLine("Текст після видалення слів з подвоєними літерами:");
Console.WriteLine(cleanedText);

static bool HasDuplicateLetters(string word)
{
    return word.GroupBy(c => c).Any(group => group.Count() > 1);
}
static string[] RemoveWordsWithDuplicates(string[] words)
{
    List<string> filteredWords = new List<string>();

    foreach (string word in words)
    {
        if (!HasDuplicateLetters(word))
        {
            filteredWords.Add(word);
        }
    }

    return filteredWords.ToArray();
}