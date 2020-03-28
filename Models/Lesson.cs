using System;

namespace zadanie0.Models
{
    public class Lesson
    {
        private string number;
        private string subject;
        private DateTime date;

        public string Number { get => number; set => number = value; }
        public string Subject { get => subject; set => subject = value; }
        public DateTime Date { get => date; set => date = value; }

        public Lesson(string subject, string number)
        {
            this.subject = subject;
            this.number = number;
            this.date = System.DateTime.Now;
        }

        public Lesson(string subject, string number, DateTime date)
        {
            this.subject = subject;
            this.number = number;
            this.date = date;
        }

        public override string ToString()
        {
            return $"{subject}, lesson {number}, {date}";
        }
    }
}
