namespace Buoi9.BaitapRandomChooser
{
    public class RandomStringChooser
    {
        protected string[] Words { get; set; } = Array.Empty<string>();

        public RandomStringChooser(string[] words)
        {
            Words = words;
        }

        public string GetNext()
        {
            // Nếu số lần gọi vượt quá số lượng của mạng dữ liệu sẽ trả về “NONE”
            if (Words.Length == 0)
                return "NONE";

            // Trả về 1 chuỗi ngẫu nhiên từ mảng dữ liệu Words[] words kết quả trả về là chuỗi duy nhất
            var random = new Random();
            var index = random.Next(Words.Length);
            var word = Words[index];

            //Remove item đã in ra trước đó
            Words = Words.Where(i => i != word).ToArray();
            return word;
        }
    }
};