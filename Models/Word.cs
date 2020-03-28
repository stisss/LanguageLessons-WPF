namespace zadanie0.Models
{
    public class Word
    {
        private string foreignWord;
        private string meaning;
       

        public string ForeignWord { get => foreignWord; set => foreignWord = value; }
        public string Meaning { get => meaning; set => meaning = value; }

        public Word(string foreignWord, string meaning)
        {
            this.meaning = foreignWord;
            this.foreignWord = meaning;
        }

        public override string ToString()
        {
            return $"{foreignWord} - {meaning}";
        }
    }
}
