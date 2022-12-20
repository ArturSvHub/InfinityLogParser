using Microsoft.AspNetCore.Components.Forms;

using System.IO;

namespace InfinityLogParser.Services
{
    public class FilesService
    {
        public string FilesPath { get; private set; }
        public DirectoryInfo CurrentDirrectory { get; private set; }
        private List<string> filesNames;
        public FilesService()
        {
            FilesPath =
            Path.Combine(Environment.CurrentDirectory, "wwwroot", "files");
            CurrentDirrectory= new DirectoryInfo(FilesPath);
            filesNames = new();
        }

        public List<FileInfo> GetFilesByName(string name)
        {
            if(GetFiles().Count>0)
            {
                return GetFiles().Where(f=>f.Name.Contains(name)).ToList();
            }
            else
            {
                return GetFiles();
            }
        }
        public bool ContainsByName(string name)
        {
            var files = GetFiles();
            bool res = false;
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Name.Contains(name))
                        res= true;
                }
            }
            return res;
        }
        public void DeleteAllFiles()
        {
            foreach (var file in CurrentDirrectory.GetFiles()) 
            {
                file.Delete();
            }
        }
        public void DeleteFile(FileInfo file)
        {
            if(file.Exists)
            {
                file.Delete();
            }
        }
        public async Task AddFilesToCurrentDirrectory(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles(e.FileCount))
            {
                var path = Path.Combine(FilesPath, file.Name);
                await using FileStream fs = new(path, FileMode.Create);
                using var stream = file.OpenReadStream(maxAllowedSize: long.MaxValue);
                await stream.CopyToAsync(fs);
                filesNames.Add(file.Name);
            }
        }
        public List<FileInfo> GetFiles()
        {
            return CurrentDirrectory.GetFiles().ToList();
        }
    }
}
