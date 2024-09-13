namespace Buoi9.BaitapRandomChooser
{
    public class RandomLetterChooser : RandomStringChooser
    {
        private string Word { get; set; }

        public RandomLetterChooser(string word) : base(GetSingleLetters(word))
        {
        }

        private static string[] GetSingleLetters(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return Array.Empty<string>();
            }

            var singleLetters = new string[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                singleLetters[i] = str[i].ToString();
            }

            return singleLetters;
        }
    }
}