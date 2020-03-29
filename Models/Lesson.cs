using System;

namespace zadanie0.Models
{
    public class Lesson
    {
        public int Index { get; private set; }
        public string Number { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }

        public Lesson(string subject, string number)
        {
            Subject = subject;
            Number = number;
            Date = DateTime.Now;
        }

        public Lesson(int index, string subject, string number, DateTime date)
        {
            Index = index;
            Subject = subject;
            Number = number;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Subject}, lesson {Number}, {Date}";
        }
    }
}
