using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIAngularJsFileSystem.WebUI.Models;
using System.IO;

namespace WebAPIAngularJsFileSystem.WebUI.File
{
    public class FileManager : IFileManager
    {
        private string workingFolder { get; set; }

        public FileManager(string myFolder)
        {
            workingFolder = myFolder;
            CheckTargetDirectory();
        }

        public IEnumerable<FileViewModel> getFiles()
        {
            List<FileViewModel> files = new List<FileViewModel>();
            DirectoryInfo filesFolder = new DirectoryInfo(workingFolder);

            files = filesFolder.EnumerateFiles()
                .Where(f => new[] { "" }.Contains(f.Extension.ToLower()))
                .Select(f => new FileViewModel
                {
                    Name = f.Name,
                    Size = f.Length / 1024
                }).ToList();

            return files;
        }

        private void CheckTargetDirectory()
        {
            if (!Directory.Exists(this.workingFolder))
            {
                throw new ArgumentException("the destination path " + this.workingFolder + " could not be found");
            }
        }
    }
}