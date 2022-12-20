using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class ParserFile
    {
        public List<ParserObject> ParserObjects { get;private set; }
        public ParserFile()
        {
            ParserObjects = new();
        }
        public void AddParserObjectsByKeyWord(string keyWord, FileInfo file)
        {
            var lines = File.ReadAllLines(file.FullName);
            var linesIndexes = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(keyWord))
                {
                    linesIndexes.Add(i);
                }
            }
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < linesIndexes.Count; j++)
                {
                    if (j < linesIndexes.Count-1 && i == linesIndexes[j])
                    {
                        var pObj = new ParserObject();
                        for (int x = linesIndexes[j]; x < linesIndexes[j + 1]; x++)
                        {
                            pObj.LineObjects.Add(new LineObject(lines[x].Split(' ').ToList()));
                        }
                        ParserObjects.Add(pObj);
                    }
                    else if (j ==linesIndexes.Count-1&& i == linesIndexes[j]) 
                    {
                        var pObj = new ParserObject();
                        for (int x = linesIndexes[j]; x < lines.Length; x++)
                        {
                            pObj.LineObjects.Add(new LineObject(lines[x].Split(' ').ToList()));
                        }
                        ParserObjects.Add(pObj);
                    }

                }
            }
        }

    }
}
