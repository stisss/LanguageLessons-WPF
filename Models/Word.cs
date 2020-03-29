namespace zadanie0.Models
{
    public class Word
    {
        public int Index { get; private set; }
        public int ParentIndex { get; private set; }
        public string ForeignWord { get; set; }
        public string Meaning { get; set; }

        public Word(string foreignWord, string meaning)
        {
            Meaning = meaning;
            ForeignWord = foreignWord;
        }

        public Word(string foreignWord, string meaning, int parentIndex)
        {
            Meaning = foreignWord;
            ForeignWord = meaning;
            ParentIndex = parentIndex;
        }

        public Word(int parentIndex, int index, string foreignWord, string meaning)
        {
            ForeignWord = foreignWord;
            Meaning = meaning;
            ParentIndex = parentIndex;
            Index = index;
        }

        public override string ToString()
        {
            return $"{ForeignWord} - {Meaning}";
        }
    }
}
