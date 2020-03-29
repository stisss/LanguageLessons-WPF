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
            string save = GetNewIndex() + "," + lesson.Subject + "," + lesson.Number + "," + lesson.Date;

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(save);
            }

        }

        public Lesson GetItem(int index)
        {
            return null;
        }

        public void UpdateItem(int index, Lesson item)
        {
            string subject = item.Subject;
            string number = item.Number;

            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(path))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int lineCounter = 0;
                string[] temp;

                while ((line = sr.ReadLine()) != null)
                {
                    temp = line.Split(",");
                    if (Int32.Parse(temp[0]) != index)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        temp[1] = subject;
                        temp[2] = number;
                        sw.WriteLine(String.Join(',', temp));
                    }
                    lineCounter++;
                }
            }

            File.Delete(path);
            File.Move(tempFile, path);
        }

        public void DeleteItem(int index)
        {
            string tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(path))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;
                int lineCounter = 0;
                string[] temp;

                while ((line = sr.ReadLine()) != null)
                {
                    temp = line.Split(",");
                    if (Int32.Parse(temp[0]) != index)
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
            string[] temp;

            if (File.Exists(path))
            {
                using (var sr = File.OpenText(path))
                {
                    while ((buffer = sr.ReadLine()) != null)
                    {
                        temp = buffer.Split(",");
                        items.Add(new Lesson(Int32.Parse(temp[0]), temp[1], temp[2], DateTime.Parse(temp[3])));
                    }
                }
            }
            return items;
        }

        public int GetNewIndex()
        {
            if (File.Exists(path))
            {
                string buffer = "";
                int index = 0;
                string[] temp = new string[4];


                using (var sr = File.OpenText(path))
                {
                    while ((buffer = sr.ReadLine()) != null)
                    {
                        temp = buffer.Split(",");
                    }
                    index = Int32.Parse(temp[0]);
                }
                return index+1;
            }
            else
            {
                return 0;
            }
        }
    
    }
}
