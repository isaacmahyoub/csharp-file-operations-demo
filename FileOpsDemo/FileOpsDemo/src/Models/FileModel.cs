using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOpsDemo.src.Models
{
    public class FileModel
    {
        public string FilePath { get; set; }
        public string Content { get; set; }

        public bool FileExists => File.Exists(FilePath);

        public void ReadFile()
        {
            if (FileExists)
            {
                Content = File.ReadAllText(FilePath);
            }
            else
            {
                throw new FileNotFoundException("File not found");
            }
        }

        public void SaveFile()
        {
            File.WriteAllText(FilePath, Content);
        }

        public void CreateFile()
        {
            if (!FileExists)
            {
                File.WriteAllText(FilePath, Content);
            }
            else
            {
                throw new IOException("File already exists");
            }
        }

        public void DeleteFile()
        {
            if (FileExists)
            {
                File.Delete(FilePath);
            }
        }
    }
}
