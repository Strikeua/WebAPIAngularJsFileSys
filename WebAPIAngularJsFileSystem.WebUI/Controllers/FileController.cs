using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using WebAPIAngularJsFileSystem.WebAPI.Models;
using System.Web.WebPages;

namespace WebAPIAngularJsFileSystem.WebAPI.Controllers
{
    public class FileController : ApiController
    {
        FileContext db = new FileContext();
        
                
        // GET: api/File?path
        public FileContext Get(string path)
        {
            List<string> files = new List<string>();
            List<string> directories = new List<string>();
            
            // check if path is empty
            if (path.IsEmpty())
            {
                directories.AddRange(Environment.GetLogicalDrives());
            }
            
            List<FileModel> myfiles = new List<FileModel>();
            List<DirectoryModel> mydirectories = new List<DirectoryModel>();

            DirectoryInfo dir = new DirectoryInfo("F:\\FRAPSMOVIE");

            foreach(var item in dir.GetDirectories())
            {
                mydirectories.Add(new DirectoryModel() { Name = item.Name });
            }
            db.Directories.AddRange(mydirectories);

            FileInfo[] fileArr = dir.GetFiles("*.*",SearchOption.AllDirectories);

            foreach (FileInfo f in fileArr)
            {
                if (f.Length < 10485760) db.Count10Mb++;
                if (f.Length > 10485760 && f.Length < 52428800) db.Count10_50Mb++;
                if (f.Length > 104857600) db.Count100Mb++;
                
                myfiles.Add(new FileModel() { Name = f.Name, Size = f.Length }); 
            }

            db.Files.AddRange(myfiles);
            
            return db;
                           
            //return directories.AsEnumerable();            
        }
        
        // GET: api/File/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/File
        public void Post([FromBody]string value)
        {
        }
               
    }
}
