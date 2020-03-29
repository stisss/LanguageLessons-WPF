using System;
using System.Collections;
using System.IO;

namespace zadanie0.Models
{
    class WordDAO : IDAO<Word>
    {
        private string path = @"../../../Saves/words.txt";
        private int parentIndex;

        public WordDAO(int index)
        {
            parentIndex = index;
        }
        public void AddItem(Word item)
        {
            string save = parentIndex + "," + GetNewIndex() + "," + item.ForeignWord + "," + item.Meaning;

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
                string[] temp;

                while ((line = sr.ReadLine()) != null)
                {
                    temp = line.Split(",");
                    if (Int32.Parse(temp[1]) != index)
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
            string[] temp;

            if (File.Exists(path))
            {
                using (var sr = File.OpenText(path))
                {
                    while ((buffer = sr.ReadLine()) != null)
                    {
                        temp = buffer.Split(",");
                        if (temp[0].Equals(parentIndex.ToString()))
                        {
                            items.Add(new Word(Int32.Parse(temp[0]), Int32.Parse(temp[1]), temp[2], temp[3]));
                        }
                    }
                }
            }
            return items;
        }

        public Word GetItem(int index)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(int index, Word item)
        {
            string foreign = item.ForeignWord;
            string meaning = item.Meaning;

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
                    if (Int32.Parse(temp[1]) != index)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        temp[2] = foreign;
                        temp[3] = meaning;
                        sw.WriteLine(String.Join(',', temp));
                    }
                    lineCounter++;
                }
            }

            File.Delete(path);
            File.Move(tempFile, path);
        }

        public void CascadeDelete()
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
                    if (Int32.Parse(temp[0]) != parentIndex)
                    {
                        sw.WriteLine(line);
                    }
                    lineCounter++;
                }
            }

            File.Delete(path);
            File.Move(tempFile, path);
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
                    index = Int32.Parse(temp[1]);
                }
                return index + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
