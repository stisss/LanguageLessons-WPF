using System;
using System.Collections;
using System.IO;

namespace zadanie0.Models
{
    class WordDAO : IDAO<Word>
    {
        private string path = @"../../../Saves/lesson";
        private int index;

        public WordDAO(int index)
        {
            this.index = index;
            this.path += index + ".txt";
        }
        public void AddItem(Word item)
        {
            string save = item.ForeignWord + "," + item.Meaning;

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(save);
            }
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
        }

        public ArrayList GetData()
        {
            ArrayList items = new ArrayList();
            string buffer = "";
            string[] temp = new string[2];

            if (File.Exists(path))
            {
                using (var sr = File.OpenText(path))
                {
                    while ((buffer = sr.ReadLine()) != null)
                    {
                        temp = buffer.Split(",");
                        items.Add(new Word(temp[0], temp[1]));
                    }

                }
            }
            return items;
        }

        public Word GetItem(int index)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(int index)
        {
            throw new NotImplementedException();
        }

        public void CascadeDelete()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                string nextPath = @"../../../Saves/lesson";
                int nextIndex = index + 1;
                while (File.Exists(nextPath + nextIndex + ".txt"))
                {
                    File.Move(nextPath + nextIndex + ".txt", nextPath + (nextIndex-1) + ".txt");
                    nextIndex++;
                }
            }
    }
}
}
