using DesignPatterns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.InterviewQuestions
{
    public class LocateUniverseFormilaDemo : IExecuteDemo
    {
        public string GetFile(string path)
        {
            string filePath = null;
            if (Directory.GetFiles(path).Contains("universe-formula"))
            {
                filePath = path;
            }
            else
            {
                foreach (var subDirectory in Directory.GetDirectories(path))
                {
                    GetFile(subDirectory);
                }
            }

            return filePath;
        }
        public string LocateUniverseFormila()
        {
            //var path = "/tem/documents";
            var path = "C:\\Users\\AX412BC\\workspace\\tutos\\DesignPatterns\\Sample";
            return GetFile(path);
        }
        public void Execute()
        {
            var result = LocateUniverseFormila();
            Console.WriteLine(result);
        }
    }
}
