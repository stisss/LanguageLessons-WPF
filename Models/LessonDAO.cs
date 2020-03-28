using System;
using System.IO;
using System.Collections;

namespace zadanie0.Models
{
    class LessonDAO : IDAO<Lesson>
    {
        private string path = @"../../../Saves/lessons.txt";
        public LessonDAO()
        {
        }

        public void AddItem(Lesson lesson)
        {
            string save = lesson.Subject + "," + lesson.Number + "," + lesson.Date;

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(save);
            }

        }

        public Lesson GetItem(int index)
        {
            return null;
        }

        public void UpdateItem(int index)
        {

        }

        public void DeleteItem(int index)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(path))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int lineCounter = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    if (lineCounter != index)
                    {
                        sw.WriteLine(line);
                    }
                    lineCounter++;
                }
            }

            File.Delete(path);
            File.Move(tempFile, path);
            WordDAO tempDAO = new WordDAO(index);
            tempDAO.CascadeDelete();
        }

        public ArrayList GetData()
        {
            ArrayList items = new ArrayList();
            string buffer = "";
            string[] temp = new string[3];

            if (File.Exists(path))
            {
                using (var sr = File.OpenText(path))
                {
                    while ((buffer = sr.ReadLine()) != null)
                    {
                        temp = buffer.Split(",");
                        items.Add(new Lesson(temp[0], temp[1], DateTime.Parse(temp[2])));
                    }

                }
            }
            return items;
        }
    
    }
}
