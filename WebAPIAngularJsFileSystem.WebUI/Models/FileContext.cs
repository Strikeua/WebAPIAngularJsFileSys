using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIAngularJsFileSystem.WebAPI.Models;

namespace WebAPIAngularJsFileSystem.WebAPI.Models
{
    public class FileContext
    {
        public List<FileModel> Files = new List<FileModel>();
        public List<DirectoryModel> Directories = new List<DirectoryModel>();
        public int Count10Mb { get; set; }
        public int Count10_50Mb { get; set; }
        public int Count100Mb { get; set; }
    }
}